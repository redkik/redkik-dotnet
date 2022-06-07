[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
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
   PM> Install-Package Redkik.NET
   ```

### Usage

1. Call the initialize function to set the base url
   ```c#
   Redkik.API.Initialize("https://demo.broker.com");
   ```
2. Login to the service to recieve a token
   ```c#
   Redkik.Classes.Token? token = await Redkik.API.Login(REDKIK_EMAIL, REDKIK_PASSWORD);
   ```
3. Get some required data to populate your form
   ```c#
   List<Redkik.Classes.Commodity>? commodities = await Redkik.API.GetCommodities();
   List<Redkik.Classes.Country>? countries = await Redkik.API.GetCountries();
   ```
4. Collect the information needed for a quote using your preferred method
5. Submit the quote to recieve offers
   ```c#
   Redkik.Classes.Response<List<Redkik.Classes.Offer>>? offers = await Redkik.API.GetOffers(payload);
   ```
6. Purchase an offer
   ```c#
   Redkik.Classes.Response<Redkik.Classes.Booking>? booking = await RedkikAPI.PurchaseOffer(offer);
   ```

[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/dotnet-redkik.svg?style=for-the-badge
[contributors-url]: https://github.com/redkik/dotnet-redkik/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/redkik/dotnet-redkik.svg?style=for-the-badge
[forks-url]: https://github.com/redkik/dotnet-redkik/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/dotnet-redkik.svg?style=for-the-badge
[stars-url]: https://github.com/redkik/dotnet-redkik/stargazers
[issues-shield]: https://img.shields.io/github/issues/redkik/dotnet-redkik.svg?style=for-the-badge
[issues-url]: https://github.com/redkik/dotnet-redkik/issues
[license-shield]: https://img.shields.io/github/license/redkik/dotnet-redkik.svg?style=for-the-badge
[license-url]: https://github.com/redkik/dotnet-redkik/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/company/redkik/
