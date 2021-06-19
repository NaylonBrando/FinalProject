using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Token üretimi gerçekleştirmeye yarayan, şablon, interface
    public interface ITokenHelper
    {
        //OperationClaim:
        //İlgili kullaniciya ve onun yetkilerine bakacak, ona ve yetkilerine göre jwt verecek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

    }

}
