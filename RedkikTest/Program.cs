using Redkik.Helpers;
using Redkik.Classes;
using Redkik;

try
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("=== Redkik Test Program ======================\n");

    Console.WriteLine("Initializing...");
    API.Initialize("https://demo.broker.com");
    Console.WriteLine("Base URL: {0}\n", API.BaseAddress);

    Console.Write("Enter email: ");
    string? email = Console.ReadLine();
    Console.Write("Enter password: ");
    string? password = Console.ReadLine();
    Console.WriteLine("");

    Console.WriteLine("Logging in...");
    Token? token = await API.Login(email ?? "", password ?? "");
    Console.WriteLine(string.Format("Token ID: {0}\n", token == null ? "N/a" : token.id));

    Console.WriteLine("Querying commodities...");
    List<Commodity>? commodities = await API.GetCommodities();
    Console.WriteLine(string.Format("Recieved {0} commodities\n", commodities == null ? 0 : commodities.Count));

    Console.WriteLine("Querying countries...");
    List<Country>? countries = await API.GetCountries();
    Console.WriteLine(string.Format("Recieved {0} countries\n", countries == null ? 0 : countries.Count));

    if (commodities != null && countries != null)
    {
        Console.WriteLine("Creating quote payload...");

        Console.Write("Enter start date: ");
        DateTimeOffset startTime = new DateTimeOffset(DateTime.Parse(Console.ReadLine() ?? "2022-06-01"));

        Console.Write("Enter end date: ");
        DateTimeOffset endTime = new DateTimeOffset(DateTime.Parse(Console.ReadLine() ?? "2022-06-02"));

        Console.Write("Enter origin: ");
        string origin = Console.ReadLine() ?? "";

        Console.Write("Enter destination: ");
        string destination = Console.ReadLine() ?? "";

        Console.Write("Enter transport type, 1 = land, 2 = sea, 3 = air: ");
        string transportType = Console.ReadLine() ?? "";

        Console.Write("Enter commodity: ");
        Commodity? commodity = ConsoleHelpers.ReadCommodity(commodities);

        Console.Write("Enter commodity description: ");
        string commodityDescription = Console.ReadLine() ?? "";

        Console.Write("Enter insured value: ");
        double insuredValue = double.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter holder type, 1 = company, 2 = private individual: ");
        string holderType = Console.ReadLine() ?? "";

        Console.Write("Enter holder email: ");
        string holderEmail = Console.ReadLine() ?? "";

        string? holderCompanyName = null, holderTaxId = null, holderForname = null, holderSurname = null;
        switch (holderType)
        {
            case "1":
                Console.Write("Enter holder company name: ");
                holderCompanyName = Console.ReadLine() ?? "";
                Console.Write("Enter holder company tax id: ");
                holderTaxId = Console.ReadLine() ?? "";
                break;
            case "2":
                Console.Write("Enter holder forename: ");
                holderForname = Console.ReadLine() ?? "";
                Console.Write("Enter holder surname: ");
                holderSurname = Console.ReadLine() ?? "";
                break;
        }

        Console.Write("Enter holder address street: ");
        string addressStreet = Console.ReadLine() ?? "";

        Console.Write("Enter holder address city: ");
        string addressCity = Console.ReadLine() ?? "";

        Console.Write("Enter holder address state: ");
        string addressState = Console.ReadLine() ?? "";

        Console.Write("Enter holder address postcode: ");
        string addressPostcode = Console.ReadLine() ?? "";

        Console.Write("Enter country: ");
        Country? country = ConsoleHelpers.ReadCountry(countries);

        Console.Write("Enter shipper's reference: ");
        string reference = Console.ReadLine() ?? "";
        Console.WriteLine();

        if (commodity != null && country != null)
        {
            Console.WriteLine("Requesting offers...");
            Response<List<Offer>>? offers = await API.GetOffers(new QuotePayload(
                startTime, endTime, origin, destination, transportType, commodity.id ?? "", commodityDescription, insuredValue, holderType, 
                holderEmail, holderCompanyName, holderTaxId, holderForname, holderSurname, addressStreet, addressCity, addressState, 
                addressPostcode, country.id ?? "", reference
                ));
            if (offers != null && offers.result != null)
            {
                Console.WriteLine(string.Format("Recieved {0} offers\n", offers.result.Count));

                if (offers.result[0].accepted ?? false)
                {
                    Console.WriteLine("Purchasing first offer...");
                    Response<Booking>? booking = await API.PurchaseOffer(offers.result[0]);
                    if (booking != null && booking.result != null)
                    {
                        Console.WriteLine(string.Format("Booking purchased: {0}\n", booking.result.reference));
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("First offer was not accepted: {0}", string.Join(", ", offers.result[0]?.amendments ?? new List<string>())));
                }

            }
        }
    }
}
catch (Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(e.InnerException != null ? e.InnerException.Message : e.Message);
    Console.ForegroundColor = ConsoleColor.White;
}