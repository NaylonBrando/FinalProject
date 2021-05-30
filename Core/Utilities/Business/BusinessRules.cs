using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params tipinde istedigimiz kadar parametre yollayabiliriz, bütün parametreleri array haline getirip logicse atar
        //parametre ile yollagımız iş kurallarından başarısız olan business'a yolla
        public static IResult Run(params IResult[] logics)
        {
            //parametre ile yollagımız iş kurallarından başarısız olan business
            foreach (var logic in logics)
            {
                if (!logic.Success) // logic==false
                {
                    return logic;
                }
            }
            return null;
        }
    }
}