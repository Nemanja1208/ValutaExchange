using System;
using System.Text;

namespace ValutaExchange
{
    class Program
    {
        const int MinLength = 8;

        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                // Visa felet i stället för att fönstret bara stängs
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEtt fel uppstod:");
                Console.WriteLine(ex);
                Console.ResetColor();
                // nemo nya kommentar
            }

            // Håll fönstret öppet tills användaren trycker på en tangent
            Console.WriteLine("\nTryck på valfri tangent för att avsluta...");
            if (!Console.IsInputRedirected)
                Console.ReadKey(true);
        }

        static void Run()
        {
            // Gör att å, ä, ö visas korrekt (kan kasta fel i vissa miljöer, därför try/catch)
            try { Console.OutputEncoding = Encoding.UTF8; } catch { }

            Console.WriteLine("=== Lösenordskontroll ===");

            bool keepGoing = true;

            // Huvudloop: låter användaren testa flera lösenord
            while (keepGoing)
            {
                Console.Write("\nAnge ett lösenord: ");
                string password = Console.ReadLine();

                // null betyder att konsolen inte kan ta emot inmatning (t.ex. fel debug-läge)
                if (password == null)
                {
                    Console.WriteLine("\nIngen inmatning tillgänglig. Kör appen i en riktig terminal.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Du måste ange ett lösenord.");
                    continue;
                }

                // --- 1. Analysera lösenordet tecken för tecken ---
                bool hasUpper = false;
                bool hasLower = false;
                bool hasDigit = false;
                bool hasSpecial = false;

                foreach (char c in password)
                {
                    if (char.IsUpper(c))
                        hasUpper = true;
                    else if (char.IsLower(c))
                        hasLower = true;
                    else if (char.IsDigit(c))
                        hasDigit = true;
                    else if (!char.IsWhiteSpace(c))
                        hasSpecial = true; // Allt som inte är bokstav, siffra eller mellanslag
                }

                bool hasLength = password.Length >= MinLength;
                bool hasMixedCase = hasUpper && hasLower;

                // --- 2. Räkna poäng (0–4) ---
                int score = 0;
                if (hasLength) score++;
                if (hasMixedCase) score++;
                if (hasDigit) score++;
                if (hasSpecial) score++;

                // --- 3. Visa resultat per kriterium ---
                Console.WriteLine("\nResultat:");
                PrintCheck(hasLength, $"Minst {MinLength} tecken (du har {password.Length})");
                PrintCheck(hasMixedCase, "Både stora och små bokstäver");
                PrintCheck(hasDigit, "Minst en siffra");
                PrintCheck(hasSpecial, "Minst ett specialtecken");

                // --- 4. Bedöm styrkan ---
                // Längd är ett grundkrav: för kort lösenord blir alltid "Svagt"
                string rating;
                ConsoleColor color;

                if (!hasLength || score <= 2)
                {
                    rating = "Svagt";
                    color = ConsoleColor.Red;
                }
                else if (score == 3)
                {
                    rating = "Moderat";
                    color = ConsoleColor.Yellow;
                }
                else
                {
                    rating = "Starkt";
                    color = ConsoleColor.Green;
                }

                Console.Write("\nLösenordets styrka: ");
                Console.ForegroundColor = color;
                Console.WriteLine($"{rating} ({score}/4)");
                Console.ResetColor();

                // --- 5. Tips för förbättring ---
                if (score < 4)
                {
                    Console.WriteLine("\nTips för att förbättra:");
                    if (!hasLength) Console.WriteLine($"- Gör lösenordet minst {MinLength} tecken långt.");
                    if (!hasMixedCase) Console.WriteLine("- Blanda stora och små bokstäver.");
                    if (!hasDigit) Console.WriteLine("- Lägg till minst en siffra.");
                    if (!hasSpecial) Console.WriteLine("- Lägg till ett specialtecken, t.ex. ! @ # $ %.");
                }

                // --- 6. Fråga om användaren vill fortsätta ---
                Console.Write("\nVill du testa ett till lösenord? (j/n): ");
                string answer = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
                keepGoing = answer == "j" || answer == "ja";
            }

            Console.WriteLine("\nHej då!");
        }

        // Hjälpmetod som skriver ut ett kriterium med [x] eller [ ]
        static void PrintCheck(bool passed, string text)
        {
            Console.ForegroundColor = passed ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(passed ? "  [x] " : "  [ ] ");
            Console.ResetColor();
            Console.WriteLine(text);
        }
    }
}