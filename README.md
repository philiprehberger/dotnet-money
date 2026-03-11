# Philiprehberger.Money

An immutable `Money` value type for .NET that stores amounts as integer minor units (cents, pence, etc.) to eliminate floating-point rounding errors. Includes ISO 4217 currency definitions and proportional allocation.

## Install

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

// Compare
bool isExpensive = price > Money.Of(10m, Currencies.USD); // true

// Allocate — split $10 in a 1:1:1 ratio
var tenDollars = Money.Of(10.00m, Currencies.USD);
Money[] shares = tenDollars.Allocate(1, 1, 1);
// shares[0] = $3.34, shares[1] = $3.33, shares[2] = $3.33
```

## API

### `Money`

| Member | Description |
|--------|-------------|
| `Of(decimal, Currency)` | Create from a decimal amount |
| `AmountInMinorUnits` | Raw integer (e.g. 1299 for $12.99) |
| `Currency` | The associated currency |
| `Add(Money)` | Add; throws if currencies differ |
| `Subtract(Money)` | Subtract; throws if currencies differ |
| `Multiply(decimal)` | Scale by a factor |
| `Negate()` | Arithmetic negation |
| `Abs()` | Absolute value |
| `Allocate(int[])` | Proportional distribution with remainder handling |
| `ToDecimal()` | Convert back to `decimal` |
| `Format()` | Symbol + amount string, e.g. `$12.99` |
| `+`, `-`, `*` | Operator overloads |
| `>`, `<`, `>=`, `<=` | Comparison operators |

### `Currencies`

Pre-defined constants: `USD`, `EUR`, `GBP`, `JPY`, `CHF`, `CAD`, `AUD`, `SEK`, `NOK`, `DKK`.

## License

MIT
