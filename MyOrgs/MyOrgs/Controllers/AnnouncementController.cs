﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyOrgs.Controllers
{
    public class AnnouncementController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}