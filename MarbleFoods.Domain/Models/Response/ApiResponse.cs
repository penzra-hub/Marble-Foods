﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models.Response
{
    public class ApiResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
