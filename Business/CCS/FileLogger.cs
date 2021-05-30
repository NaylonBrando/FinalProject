using System;

namespace Business.CCS
{
    public class FileLogger : Ilogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya Loglandı");
        }
    }
}