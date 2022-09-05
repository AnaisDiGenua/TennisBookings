﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TennisBookings.Models;
using TennisBookings.Services;

namespace TennisBookings.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            var weatherForecaster = new WeatherForecaster();
            var currentWeather = weatherForecaster.GetCurrentWeather();

            switch (currentWeather.WeatherCondition)
            {
                case WeatherCondition.Sun:
                    viewModel.WeatherDescription = "It's sunny right now. A great day for tennis.";
                    break;

                case WeatherCondition.Rain:
                    viewModel.WeatherDescription = "We're sorry but it's raining here. No outdoor courts in use.";
                    break;

                default:
                    viewModel.WeatherDescription = "We don't have the latest weather information right now, please check again later.";
                    break;
            }

            return View(viewModel);
        }
    }
}
