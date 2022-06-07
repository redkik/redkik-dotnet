<div align="center">
  <img src="https://img.shields.io/github/contributors/redkik/dotnet-redkik.svg?style=for-the-badge" />
  <img src="https://img.shields.io/github/stars/redkik/dotnet-redkik.svg?style=for-the-badge" />
  <a href="https://github.com/redkik/dotnet-redkik/issues"><img src="https://img.shields.io/github/issues/redkik/dotnet-redkik.svg?style=for-the-badge" /></a>
  <a href="https://github.com/redkik/dotnet-redkik/blob/main/LICENSE.txt"><img src="https://img.shields.io/github/license/redkik/dotnet-redkik?style=for-the-badge" /></a>
</div>

<br />
<div align="center">
  <a href="https://github.com/redkik/dotnet-redkik">
    <img src="https://www.redkik.com/wp-content/uploads/2021/01/redkik-logo.png" alt="Logo" width="250" height="87">
  </a>

  <h3 align="center">Redkik .NET Wrapper Utilities</h3>

  <p align="center">
    A simple wrapper library written in C#.NET6 to easily integrate Redkik's API into your project
    <br />
    <br />
    <a href="https://github.com/redkik/dotnet-redkik/issues">Report Bug</a>
    ·
    <a href="https://github.com/redkik/dotnet-redkik/issues">Request Feature</a>
  </p>
</div>

### Prerequisites

1. [Get in touch](https://www.redkik.com/schedule-a-demo/) with us to get your demo login credentials and API keys
2. Install the library from NuGet
   ```sh
   PM> Install-Package Redkik
   ```
3. Import the namespaces
   ```c#
   using Redkik;
   using Redkik.Classes;
   ```

### Usage

1. Call the initialize function to set the base url
   ```c#
   API.Initialize("https://demo.broker.com");
   ```
2. Login to the service to recieve a token
   ```c#
   Token? token = await API.Login(REDKIK_EMAIL, REDKIK_PASSWORD);
   ```
3. Get some required data to populate your form
   ```c#
   List<Commodity>? commodities = await API.GetCommodities();
   List<Country>? countries = await API.GetCountries();
   ```
4. Collect the information needed for a quote using your preferred method
5. Submit the quote to recieve offers
   ```c#
   Response<List<Offer>>? offers = await API.GetOffers(payload);
   ```
6. Purchase an offer
   ```c#
   Response<Booking>? booking = await API.PurchaseOffer(offer);
   ```
