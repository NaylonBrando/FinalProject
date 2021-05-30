namespace Core.Utilities.Results
{
    //İşlem sonucu default true olması için oluşturuldu.
    public class SuccessDataResult<T> : DataResult<T>
    {
        //Sonradan backendi düzenleyecek için versiyonlar bıraktık
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(string message) : base(default, true, message)
        {
        }

        public SuccessDataResult() : base(default, true)
        {
        }
    }
}