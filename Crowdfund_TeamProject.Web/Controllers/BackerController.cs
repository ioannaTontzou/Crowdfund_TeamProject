﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crowdfund_TeamProject.Web.Models;
using Crowdfund_TeamProject.Services;
using Crowdfund_TeamProject.Web.Extensions;

namespace Crowdfund_TeamProject.Web.Controllers
{
    public class BackerController : Controller
    {
        private readonly IBackerService bksrv_;

        public BackerController(
         IBackerService bksrv)
        {
            bksrv_ = bksrv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(
           [FromBody] Core.Model.Options.AddBackerOptions options)
        {
            var result = await bksrv_
                .AddBackerAsync(options);
                

            return result.AsStatusResult();

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


    }
    
}
