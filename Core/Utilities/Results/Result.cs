namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Peki neden proplara set koymadık ? Kodumzu standartize etmek için. Başarım classları böyle diye kural.
        //Bu opsiyon constructor. Mesaj yazmak istemezsek sadece alttaki çalışır. Mesaj koyarsak bu çalışır
        //ek success parametreli constructoru da calistirir+
        public Result(bool success, string message) : this(success)//Tek parametreliyi de çalışır.
        {                                                        //This demek o sınıfın kendisi
            Message = message;                                     //Bu metod çalıştığında otomatik olarak alttaki de çalışır.
        }

        //Bu mecburi constructor
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; } //readonlyler constructor ile set edilebilir

        public string Message { get; }
    }
}