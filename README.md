# Philiprehberger.Money

[![CI](https://github.com/philiprehberger/dotnet-money/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-money/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.Money.svg)](https://www.nuget.org/packages/Philiprehberger.Money)
[![Last updated](https://img.shields.io/github/last-commit/philiprehberger/dotnet-money)](https://github.com/philiprehberger/dotnet-money/commits/main)

Immutable Money value type with integer arithmetic, ISO 4217 currencies, and proportional allocation.

## Installation

```bash
dotnet add package Philiprehberger.Money
```

## Usage

```csharp
using Philiprehberger.Money;

// Create
var price = Money.Of(12.99m, Currencies.USD);   // $12.99
var tax   = Money.Of(1.04m,  Currencies.USD);   // $1.04

// Arithmetic
var total = price + tax;                         // $14.03
var half  = total.Multiply(0.5m);               // $7.02

// Format
Console.WriteLine(total.Format());              // $14.03
Console.WriteLine(total.ToDecimal());           // 14.03
```

### Arithmetic

```csharp
using Philiprehberger.Money;

var price = Money.Of(29.99m, Currencies.USD);
var tax = price.Multiply(0.08m);
var total = price.Add(tax);
var refund = total.Negate();
```

### Percentage and Tax

```csharp
using Philiprehberger.Money;

var subtotal = Money.Of(100m, Currencies.USD);

// Calculate a percentage of an amount
var tip = subtotal.Percentage(15m);              // $15.00

// Add tax to a subtotal
var withTax = subtotal.AddPercentage(8.5m);      // $108.50
```

### Rounding

```csharp
using Philiprehberger.Money;

var amount = Money.Of(10.555m, Currencies.USD);

// Default rounding (midpoint away from zero)
var rounded = amount.Round(1);                                       // $10.60

// Banker's rounding (midpoint to even)
var bankers = amount.Round(1, RoundingMode.BankersRounding);         // $10.56

// Truncate towards zero
var truncated = Money.Of(10.99m, Currencies.USD).Round(0, RoundingMode.TowardsZero); // $10.00
```

### Allocation

```csharp
using Philiprehberger.Money;

var total = Money.Of(100m, Currencies.USD);
var shares = total.Allocate(50, 30, 20); // [$50.00, $30.00, $20.00]
var thirds = total.Divide(3);            // [$33.34, $33.33, $33.33]
```

### Currency Conversion

```csharp
using Philiprehberger.Money;

var usd = Money.Of(100m, Currencies.USD);
var eur = usd.Convert(Currencies.EUR, 0.92m); // EUR 92.00
var brl = usd.Convert(Currencies.BRL, 5.05m); // BRL 505.00
```

### Parsing

```csharp
using Philiprehberger.Money;

var a = Money.Parse("$12.99");            // USD 12.99
var b = Money.Parse("EUR 100.50");        // EUR 100.50

if (Money.TryParse("$9.99", out var parsed))
    Console.WriteLine(parsed);            // $9.99
```

## API

### `Money`

| Method | Description |
|--------|-------------|
| `Of(decimal, Currency)` | Create from a decimal amount |
| `AmountInMinorUnits` | Raw integer (e.g. 1299 for $12.99) |
| `Currency` | The associated currency |
| `Add(Money)` | Add; throws if currencies differ |
| `Subtract(Money)` | Subtract; throws if currencies differ |
| `Multiply(decimal)` | Scale by a factor |
| `Negate()` | Arithmetic negation |
| `Abs()` | Absolute value |
| `Percentage(decimal)` | Returns the given percentage of this amount |
| `AddPercentage(decimal)` | Returns amount plus the given percentage |
| `Round(int)` | Round to decimal places (default: midpoint away from zero) |
| `Round(int, RoundingMode)` | Round with a specific rounding mode |
| `Allocate(int[])` | Proportional distribution with remainder handling |
| `Divide(int)` | Split into equal parts with remainder distribution |
| `Convert(Currency, decimal)` | Convert to another currency with an exchange rate |
| `Parse(string)` | Parse a formatted string like `"$12.99"` or `"EUR 100.50"` |
| `TryParse(string, out Money)` | Try to parse; returns `bool` |
| `ToDecimal()` | Convert back to `decimal` |
| `Format()` | Symbol + amount string, e.g. `$12.99` |
| `+`, `-`, `*` | Operator overloads |
| `>`, `<`, `>=`, `<=` | Comparison operators |

### `RoundingMode`

| Value | Description |
|-------|-------------|
| `MidpointAwayFromZero` | Standard rounding (default) |
| `BankersRounding` | Rounds midpoint to nearest even number |
| `TowardsZero` | Truncates fractional digits |
| `AwayFromZero` | Always rounds away from zero |

### `Currencies`

54 pre-defined ISO 4217 constants including all G20 currencies: `USD`, `EUR`, `GBP`, `JPY`, `CHF`, `CAD`, `AUD`, `SEK`, `NOK`, `DKK`, `BRL`, `CNY`, `INR`, `MXN`, `ZAR`, `KRW`, `SGD`, `HKD`, `TWD`, `THB`, `MYR`, `PHP`, `IDR`, `VND`, `PLN`, `CZK`, `HUF`, `TRY`, `RUB`, `ILS`, `AED`, `SAR`, `NZD`, `ARS`, `CLP`, `COP`, `PEN`, `EGP`, `NGN`, `KES`, `GHS`, `UAH`, `RON`, `BGN`, `HRK`, `ISK`, `RSD`, `KWD`, `BHD`, `OMR`, `QAR`, `BDT`, `PKR`, `LKR`.

## Development

```bash
dotnet build src/Philiprehberger.Money.csproj --configuration Release
```

## Support

If you find this project useful:

⭐ [Star the repo](https://github.com/philiprehberger/dotnet-money)

🐛 [Report issues](https://github.com/philiprehberger/dotnet-money/issues?q=is%3Aissue+is%3Aopen+label%3Abug)

💡 [Suggest features](https://github.com/philiprehberger/dotnet-money/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement)

❤️ [Sponsor development](https://github.com/sponsors/philiprehberger)

🌐 [All Open Source Projects](https://philiprehberger.com/open-source-packages)

💻 [GitHub Profile](https://github.com/philiprehberger)

🔗 [LinkedIn Profile](https://www.linkedin.com/in/philiprehberger)

## License

[MIT](LICENSE)
