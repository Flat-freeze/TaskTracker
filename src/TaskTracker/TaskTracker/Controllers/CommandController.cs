using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Data;
using TaskTracker.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Controllers;

[ Route( "api/[controller]" ) ]
[ ApiController ]
[ Authorize ]
public class CommandController : ControllerBase
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger              _logger;

	public CommandController( ILogger logger, ApplicationDbContext dbContext )
	{
		_logger    = logger;
		_dbContext = dbContext;
	}

	// GET: api/<CommandController>
	[ HttpGet ]
	public IEnumerable<Command> Get()
	{
		var a = User;

		return _dbContext.Commands.ToList();
	}

	// GET api/<CommandController>/5
	[ HttpGet( "{id}" ) ]
	public string Get( int id ) => "value";

	// POST api/<CommandController>
	[ HttpPost ]
	public void Post( [ FromBody ] string value ) { }

	// PUT api/<CommandController>/5
	[ HttpPut( "{id}" ) ]
	public void Put( int id, [ FromBody ] string value ) { }

	// DELETE api/<CommandController>/5
	[ HttpDelete( "{id}" ) ]
	public void Delete( int id ) { }
}