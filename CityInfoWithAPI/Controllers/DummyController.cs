using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfoWithAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoWithAPI.Controllers
{
    public class DummyController:Controller
    {
        private CityInfoContext _ctx;

        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }
    }
}
