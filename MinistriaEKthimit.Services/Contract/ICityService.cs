﻿using MinistriaEKthimit.Messaging.Helpers;
using MinistriaEKthimit.Messaging.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Services.Contract
{
    public interface ICityService
    {
        ResponseBase GetCityById(CityRequest request);
        ResponseBase GetAllCities();
        ResponseBase GetCityById(int id);
    }
}
