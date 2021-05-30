namespace Core.Utilities.Results
{
    //İşlem sonucu default fasle olması için oluşturuldu.
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}