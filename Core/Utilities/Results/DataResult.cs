namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //Hem data listesi hem true-false hemde mesaj döndüren metod
        //T data, Resulttan farklı oldugu için konuldu //2:15:00
        public DataResult(T data, bool success, string message) : base(success, message) //
        {
            Data = data;
        }

        public DataResult(T data, bool sucess) : base(sucess)
        {
            Data = data;
        }

        public T Data { get; }
    }
}