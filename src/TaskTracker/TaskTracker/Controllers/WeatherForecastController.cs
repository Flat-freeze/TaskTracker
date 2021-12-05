﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Controllers;

[ Authorize ]
[ ApiController ]
[ Route( "api/[controller]" ) ]
public class WeatherForecastController : ControllerBase
{
	private static readonly string[] Summaries =
	{
		"Freezing",
		"Bracing",
		"Chilly",
		"Cool",
		"Mild",
		"Warm",
		"Balmy",
		"Hot",
		"Sweltering",
		"Scorching",
	};

	private readonly ILogger<WeatherForecastController> _logger;

	public WeatherForecastController( ILogger<WeatherForecastController> logger, IHttpContextAccessor httpContextAccessor ) =>
		_logger = logger;

	[ HttpGet ]
	public IEnumerable<WeatherForecast> Get()
	{
		var a = User.FindFirstValue( ClaimTypes.NameIdentifier );

		return Enumerable.Range( 1, 5 )
						 .Select( index => new WeatherForecast
								 {
									 Date         = DateTime.Now.AddDays( index ),
									 TemperatureC = Random.Shared.Next( -20, 55 ),
									 Summary      = Summaries[Random.Shared.Next( Summaries.Length )],
								 }
								)
						 .ToArray();
	}
}