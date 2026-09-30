namespace ValutaExchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skapa en konsolapplikation som konverterar en summa pengar
            //från en valuta till en annan.
            //Inkludera typkonverteringar, operatörer och kontrollflöde.

            //Instruktioner:
            //Be användaren att ange en summa pengar i SEK.
            // Att skriva ut grejer i terminal man använder Console.WriteLine()
            // läsa in data från terminalen använder man Console.ReadLine().

            //Jag frågar användaren att ange en summa pengar i SEK.
            Console.WriteLine("Ange en summa pengar i SEK:");

            // Jag läser in summan från terminalen från använderan SOM ETT STRÄNG 
            string summaSEKSomString = Console.ReadLine()!;

            Console.WriteLine("Du angav: " + summaSEKSomString);

            // Jag konverterar summan från string till double
            double beloppSEKSOMCIFRA = double.Parse(summaSEKSomString);

            //Ange en lista över tillgängliga valutor(t.ex.EUR, GBP, JPY, USD).
            Console.WriteLine("Du kan konvertera till bara dessa EUR, GBP, JPY, USD");

            // Be användaren att välja en valuta att konvertera till.
            string userInputValuta = Console.ReadLine()!;
            Console.WriteLine("Du valde: " + userInputValuta);

            // Vi behöver en variabel för att lagra det konverterade beloppet * kursen för den valda valutan.
            double summanAnvändarenFårBeroendePåValdValuta = 0.0;


            //Använd en switch-sats för att hantera valutaomvandlingen.
            //Utför omvandlingen med multiplikationsoperatorer och skriv gjutning vid behov.
            switch (userInputValuta)
            {
                case "EUR":
                    //kontrollera kurs
                    double kursEURmotSEK = 0.088; //1 SEK = 0.091 EUR
                    Console.WriteLine("Kursen för EUR mot SEK är: " + kursEURmotSEK);
                    summanAnvändarenFårBeroendePåValdValuta = beloppSEKSOMCIFRA * kursEURmotSEK;
                    break;

                case "JPY":
                    double kursJPYmotSEK = 14.0; //1 SEK = 14 JPY
                    Console.WriteLine("Kursen för JPY mot SEK är: " + kursJPYmotSEK);

                    // Vi gör omvandlingen från SEK till JPY
                    summanAnvändarenFårBeroendePåValdValuta = beloppSEKSOMCIFRA * kursJPYmotSEK;
                    break;

                case "GBP":
                    double kursGBPmotSEK = 0.077; //1 SEK = 0.077 GBP
                    Console.WriteLine("Kursen för GBP mot SEK är: " + kursGBPmotSEK);
                    // Vi gör omvandlingen från SEK till GBP
                    summanAnvändarenFårBeroendePåValdValuta = beloppSEKSOMCIFRA * kursGBPmotSEK;
                    
                    break;

                case "USD":
                    double kursUSDmotSEK = 0.097; //1 SEK = 0.097 USD
                    Console.WriteLine("Kursen för USD mot SEK är: " + kursUSDmotSEK);
                    // Vi gör omvandlingen från SEK till USD
                    summanAnvändarenFårBeroendePåValdValuta = beloppSEKSOMCIFRA * kursUSDmotSEK;

                    break;
                default:
                    Console.WriteLine("Okänt valuter. Vänligen välj en av de tillgängliga valutor: EUR, GBP, JPY, USD.");
                    break;
            }

            //Visa det konverterade beloppet.
            Console.WriteLine($"Beloppet i {userInputValuta} är: " + summanAnvändarenFårBeroendePåValdValuta);

        }
    }
}
