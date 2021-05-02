using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    //İşlem için başaralı mı başarısız mı o ve mesaj döndüren  
    public interface IResult
    {
        bool Success { get; } //Sadece okunabilir
        //Yapılan iş başarılı ise true ..
        string Message { get; } //Yapmaya çalıştığın iş başarılı. Üürn eklendi
    }
}
