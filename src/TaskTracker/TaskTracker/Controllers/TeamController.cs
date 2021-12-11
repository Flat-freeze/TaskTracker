using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using TaskTracker.Data;
using TaskTracker.Models;

using X.PagedList;
using Calabonga.OperationResults;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using TaskTracker.ViewModels;
using System.Text.Json;
using Microsoft.Build.Evaluation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TeamController : OperationController
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger _logger;

    public TeamController(ILogger<Team> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    // GET: api/<CommandController>
    [HttpGet]
    public OperationResult<PageOf<Team>> Get(int page = 1, int count = 5)
    {
        var hContext = HttpContext;   
        var data = _dbContext.Commands.Where(c=>c.IdCreatedBy == UserId).ToPagedList(page, count).ToPageOf();
        var result = GetResult(data, "Page of Commands");
        return result;
    }

    // GET api/<CommandController>/5
    [HttpGet("{id}")]
    public OperationResult<Team> Get(Guid id)
    {
        var operation = OperationResult.CreateResult<Team>();
        var res = _dbContext.Commands.FirstOrDefault(c => c.Id.Equals(id));

        if (res == null) operation.AddError(new NullReferenceException());
        else operation.Result = res;
        return operation;
    }

    // POST api/<CommandController>
    [HttpPost]
    public IActionResult Post([FromBody] JsonElement seriCommand)
    {
        var message = "Fine";
        var command = seriCommand.Deserialize<Team>();
        var result = new OperationResult<Team>();
        try
        {
            result.AddInfo("Add creator to command");
            command.Users.Add(_dbContext.Users.First(u => u.Id == UserId));
            command.UpdatedAt = DateTime.UtcNow;
            command.CreatedAt = DateTime.UtcNow;
            command.IdCreatedBy = UserId;
            command.IdUpdatedBy = UserId;

            result.AddInfo("Add command to db");
            _dbContext.Commands.Add(command);
            _dbContext.SaveChanges();
            message = $"Command {command.Id} is added by {UserId}";
        }
        catch (Exception e)
        {
            result.AddError(e);
            return Ok(result);
        }
        _logger.LogInformation(message);
        result.AddSuccess(message);
        return Ok(result);
    }

    [HttpPost("delete")]
    public IActionResult DeleteMany([FromBody] JsonElement json)
    {
        var message = "Fine";
        var commands = json.Deserialize<Team[]>();
        var result = new OperationResult<Team[]>();
        try
        {
            result.AddInfo("Remove command");
            _dbContext.Commands.RemoveRange(commands);
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            result.AddError(e);
            return Ok(result);
        }
        message = $"Commands deleted";
        result.AddSuccess(message);
        _logger.LogInformation(message);
        return Ok();
    }

    // PUT api/<CommandController>/5
    [HttpPut("{id}")]
    public OperationResult Put(Guid id, [FromBody] JsonElement seriCommand)
    {
        var message = "Fine";
        var command = seriCommand.Deserialize<Team>();
        var result = new OperationResult<Team>();
        try
        {
            var dbCommand = _dbContext.Commands.Include(c=>c.Users).First(x => x.Id == id);
            dbCommand.Title = command.Title;
            dbCommand.Description = command.Description;
            dbCommand.Users = command.Users;
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            result.AddError(e);
            return result;
        }
        result.AddSuccess("Update command");
        return result;
    }

    // DELETE api/<CommandController>/5
    [HttpDelete("{id}")]
    public OperationResult Delete(Guid id)
    {
        var operation = OperationResult.CreateResult<Team>();
        try
        {
            operation.AddInfo("Remove command");
            _dbContext.Commands.Remove(new Team() { Id = id });
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            operation.AddError(e);
            return operation;
        }

        string message = $"Command {id} deleted";
        operation.AddSuccess(message);
        _logger.LogInformation(message);
        return operation;
    }
}