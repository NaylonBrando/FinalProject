using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    //Sistemsel hatalar icin
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        

        //bu classı jsona cevirip, öyle response veriyor
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    //validation hatalari icin
    public class ValidationErrorDetails : ErrorDetails
    {
        //fluent validasyon hatalari IEnumerable listesinden geliyor
        public IEnumerable<ValidationFailure> Errors { get; set; }  
    }

}
