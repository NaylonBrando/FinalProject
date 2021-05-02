using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //IResult'ın liste döndürememesinden dolayı kuruldu. Bunlar list için, add gibi void degil.
    //IResult sadece işlem sonucu verir. 
    //Ek olarak kodda tekrar etmemek için IResult kullandık
    //Bunun dışınada IDataResult kendisine has olarak list döndürecek
    //T, hangi tipi döndüreceğini belirtir
    public interface IDataResult<T>:IResult //Birçok şey döndürebileceği için generic kullandık.
    {
        T Data { get; } //IResulttan farklı data da döndürüypr
    }
}
