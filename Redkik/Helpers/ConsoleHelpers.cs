using System;
using Redkik.Classes;

namespace Redkik.Helpers
{
    public class ConsoleHelpers
    {
        public static Commodity? ReadCommodity(List<Commodity>? commodities, ConsoleColor hintColor = ConsoleColor.DarkGray)
        {
            if (commodities == null)
            {
                return null;
            }

            Commodity? commodity = null;
            int start = Console.CursorLeft;
            string commodityInput = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                int pos = Console.CursorLeft;
                Console.SetCursorPosition(start, Console.CursorTop);
                Console.Write(new string(' ', pos - start));
                Console.SetCursorPosition(start, Console.CursorTop);

                if (info.Key == ConsoleKey.Tab)
                {
                    commodityInput = commodity?.name ?? "";
                    Console.Write(commodityInput);
                }
                else
                {
                    if (info.Key == ConsoleKey.Backspace)
                    {
                        if (!string.IsNullOrEmpty(commodityInput))
                        {
                            commodityInput = commodityInput.Substring(0, commodityInput.Length - 1);
                        }
                    }
                    else
                    {
                        commodityInput += info.KeyChar;
                    }

                    Console.Write(commodityInput);
                    commodity = commodities.Find(c => (c.name ?? "").ToLower().Contains(commodityInput.ToLower()));
                    if (commodity != null && commodity.name != null && commodity.name.ToLower() != commodityInput.ToLower())
                    {
                        ConsoleColor current = Console.ForegroundColor;
                        Console.ForegroundColor = hintColor;
                        Console.Write(commodity.name.Substring(commodityInput.Length));
                        Console.Write(" ...Press tab to accept");
                        Console.ForegroundColor = current;
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return commodity;
        }

        public static Country? ReadCountry(List<Country>? countries, ConsoleColor hintColor = ConsoleColor.DarkGray)
        {
            if (countries == null)
            {
                return null;
            }

            Country? country = null;
            int start = Console.CursorLeft;
            string countryInput = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                int pos = Console.CursorLeft;
                Console.SetCursorPosition(start, Console.CursorTop);
                Console.Write(new string(' ', pos - start));
                Console.SetCursorPosition(start, Console.CursorTop);

                if (info.Key == ConsoleKey.Tab)
                {
                    countryInput = country?.name ?? "";
                    Console.Write(countryInput);
                }
                else
                {
                    if (info.Key == ConsoleKey.Backspace)
                    {
                        if (!string.IsNullOrEmpty(countryInput))
                        {
                            countryInput = countryInput.Substring(0, countryInput.Length - 1);
                        }
                    }
                    else
                    {
                        countryInput += info.KeyChar;
                    }

                    Console.Write(countryInput);
                    country = countries.Find(c => (c.name ?? "").ToLower().Contains(countryInput.ToLower()));
                    if (country != null && country.name != null && country.name.ToLower() != countryInput.ToLower())
                    {
                        ConsoleColor current = Console.ForegroundColor;
                        Console.ForegroundColor = hintColor;
                        Console.Write(country.name.Substring(countryInput.Length));
                        Console.Write(" ...Press tab to accept");
                        Console.ForegroundColor = current;
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return country;
        }
    }
}
