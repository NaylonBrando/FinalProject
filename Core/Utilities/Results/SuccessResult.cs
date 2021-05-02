using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //Bu metodun çalışması için kalıtım aldıgı sınıfın constructoruna da değer yollamak zorunda.
        public SuccessResult(string message):base(true, message) //Base classa default olarak true ve parametreden gelen messageyi yolla
        {

        }
        public SuccessResult() : base(true) //Base classa default olarak true yolla
        {

        }
    }
}
