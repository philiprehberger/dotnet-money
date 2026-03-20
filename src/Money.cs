namespace Philiprehberger.Money;

/// <summary>
/// Represents an ISO 4217 currency.
/// </summary>
public readonly record struct Currency(string Code, string Symbol, int DecimalPlaces)
{
    /// <summary>Returns the ISO 4217 currency code.</summary>
    public override string ToString() => Code;
}

/// <summary>
/// Well-known ISO 4217 currency constants.
/// </summary>
public static class Currencies
{
    /// <summary>United States Dollar (USD).</summary>
    public static Currency USD { get; } = new("USD", "$", 2);
    /// <summary>Euro (EUR).</summary>
    public static Currency EUR { get; } = new("EUR", "€", 2);
    /// <summary>British Pound Sterling (GBP).</summary>
    public static Currency GBP { get; } = new("GBP", "£", 2);
    /// <summary>Japanese Yen (JPY).</summary>
    public static Currency JPY { get; } = new("JPY", "¥", 0);
    /// <summary>Swiss Franc (CHF).</summary>
    public static Currency CHF { get; } = new("CHF", "CHF", 2);
    /// <summary>Canadian Dollar (CAD).</summary>
    public static Currency CAD { get; } = new("CAD", "$", 2);
    /// <summary>Australian Dollar (AUD).</summary>
    public static Currency AUD { get; } = new("AUD", "$", 2);
    /// <summary>Swedish Krona (SEK).</summary>
    public static Currency SEK { get; } = new("SEK", "kr", 2);
    /// <summary>Norwegian Krone (NOK).</summary>
    public static Currency NOK { get; } = new("NOK", "kr", 2);
    /// <summary>Danish Krone (DKK).</summary>
    public static Currency DKK { get; } = new("DKK", "kr", 2);

    /// <summary>All pre-defined currencies for lookup.</summary>
    internal static readonly Currency[] All =
    [
        USD, EUR, GBP, JPY, CHF, CAD, AUD, SEK, NOK, DKK
    ];
}

/// <summary>
/// An immutable monetary value stored as an integer number of minor units
/// (e.g. cents for USD) to avoid floating-point rounding errors.
/// </summary>
public readonly record struct Money : IComparable<Money>
{
    /// <summary>Amount expressed in the currency's smallest unit (e.g. cents).</summary>
    public long AmountInMinorUnits { get; }

    /// <summary>The currency this amount is denominated in.</summary>
    public Currency Currency { get; }

    private Money(long amountInMinorUnits, Currency currency)
    {
        AmountInMinorUnits = amountInMinorUnits;
        Currency = currency;
    }

    /// <summary>
    /// Creates a <see cref="Money"/> from a decimal amount.
    /// The value is rounded to the currency's decimal places using banker's rounding.
    /// </summary>
    public static Money Of(decimal amount, Currency currency)
    {
        var factor = (long)Math.Pow(10, currency.DecimalPlaces);
        var minor = (long)Math.Round(amount * factor, MidpointRounding.ToEven);
        return new Money(minor, currency);
    }

    /// <summary>Adds two money values. Throws if currencies differ.</summary>
    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(AmountInMinorUnits + other.AmountInMinorUnits, Currency);
    }

    /// <summary>Subtracts <paramref name="other"/> from this value. Throws if currencies differ.</summary>
    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(AmountInMinorUnits - other.AmountInMinorUnits, Currency);
    }

    /// <summary>Multiplies this value by a scalar factor.</summary>
    public Money Multiply(decimal factor)
    {
        var result = (long)Math.Round(AmountInMinorUnits * factor, MidpointRounding.ToEven);
        return new Money(result, Currency);
    }

    /// <summary>Returns the arithmetic negation of this value.</summary>
    public Money Negate() => new(-AmountInMinorUnits, Currency);

    /// <summary>Returns the absolute value.</summary>
    public Money Abs() => new(Math.Abs(AmountInMinorUnits), Currency);

    /// <summary>
    /// Distributes this amount across <paramref name="ratios"/> proportionally,
    /// ensuring that remainder cents are distributed one at a time to the first shares.
    /// </summary>
    public Money[] Allocate(params int[] ratios)
    {
        if (ratios == null || ratios.Length == 0)
            throw new ArgumentException("At least one ratio must be provided.", nameof(ratios));

        long total = ratios.Sum();
        if (total == 0)
            throw new ArgumentException("Ratios must sum to a non-zero value.", nameof(ratios));

        var results = new long[ratios.Length];
        long remainder = AmountInMinorUnits;

        for (int i = 0; i < ratios.Length; i++)
        {
            results[i] = AmountInMinorUnits * ratios[i] / total;
            remainder -= results[i];
        }

        // Distribute leftover minor units to the first shares
        for (int i = 0; i < remainder; i++)
            results[i]++;

        var currency = Currency;
        return results.Select(a => new Money(a, currency)).ToArray();
    }

    /// <summary>
    /// Converts this money to another currency using the given exchange rate.
    /// The rate represents how many units of the target currency equal one unit of the source currency.
    /// </summary>
    public Money Convert(Currency target, decimal rate)
    {
        if (rate <= 0)
            throw new ArgumentException("Exchange rate must be positive.", nameof(rate));

        var sourceAmount = ToDecimal();
        return Of(sourceAmount * rate, target);
    }

    /// <summary>
    /// Splits this amount into <paramref name="parts"/> equal shares.
    /// Remainder minor units are distributed one at a time to the first shares.
    /// </summary>
    public Money[] Divide(int parts)
    {
        if (parts <= 0)
            throw new ArgumentException("Number of parts must be greater than zero.", nameof(parts));

        long baseAmount = AmountInMinorUnits / parts;
        long remainder = AmountInMinorUnits % parts;

        var results = new Money[parts];
        for (int i = 0; i < parts; i++)
            results[i] = new Money(baseAmount + (i < remainder ? 1 : 0), Currency);

        return results;
    }

    /// <summary>
    /// Parses a formatted money string such as "$12.99", "EUR 100.50", or "42.00 USD".
    /// Matches against pre-defined currencies by symbol and code.
    /// </summary>
    public static Money Parse(string input)
    {
        if (!TryParse(input, out var result))
            throw new FormatException($"Cannot parse '{input}' as a Money value.");
        return result;
    }

    /// <summary>
    /// Attempts to parse a formatted money string. Returns true on success.
    /// </summary>
    public static bool TryParse(string input, out Money result)
    {
        result = default;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        var trimmed = input.Trim();

        // Try each currency by code and symbol
        foreach (var currency in Currencies.All)
        {
            // Try code-first: "USD 12.99" or "USD12.99"
            if (TryMatchPrefix(trimmed, currency.Code, currency, out result))
                return true;

            // Try code-last: "12.99 USD" or "12.99USD"
            if (TryMatchSuffix(trimmed, currency.Code, currency, out result))
                return true;

            // Try symbol-first: "$12.99" or "$ 12.99"
            if (currency.Symbol != currency.Code && TryMatchPrefix(trimmed, currency.Symbol, currency, out result))
                return true;

            // Try symbol-last: "12.99$" or "12.99 $"
            if (currency.Symbol != currency.Code && TryMatchSuffix(trimmed, currency.Symbol, currency, out result))
                return true;
        }

        return false;
    }

    private static bool TryMatchPrefix(string input, string prefix, Currency currency, out Money result)
    {
        result = default;
        if (!input.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            return false;

        var remainder = input[prefix.Length..].Trim();
        if (decimal.TryParse(remainder, System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.InvariantCulture, out var amount))
        {
            result = Of(amount, currency);
            return true;
        }
        return false;
    }

    private static bool TryMatchSuffix(string input, string suffix, Currency currency, out Money result)
    {
        result = default;
        if (!input.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
            return false;

        var remainder = input[..^suffix.Length].Trim();
        if (decimal.TryParse(remainder, System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.InvariantCulture, out var amount))
        {
            result = Of(amount, currency);
            return true;
        }
        return false;
    }

    /// <summary>Converts back to a <see cref="decimal"/> amount.</summary>
    public decimal ToDecimal()
    {
        var factor = (decimal)Math.Pow(10, Currency.DecimalPlaces);
        return AmountInMinorUnits / factor;
    }

    /// <summary>Formats the amount with the currency symbol (e.g. <c>$12.99</c>).</summary>
    public string Format()
    {
        var amount = ToDecimal();
        var formatted = amount.ToString($"F{Currency.DecimalPlaces}");
        return $"{Currency.Symbol}{formatted}";
    }

    /// <inheritdoc/>
    public int CompareTo(Money other)
    {
        EnsureSameCurrency(other);
        return AmountInMinorUnits.CompareTo(other.AmountInMinorUnits);
    }

    /// <summary>Returns the formatted string representation (e.g. <c>$12.99</c>).</summary>
    public override string ToString() => Format();

    private void EnsureSameCurrency(Money other)
    {
        if (Currency.Code != other.Currency.Code)
            throw new InvalidOperationException(
                $"Cannot operate on different currencies: {Currency.Code} and {other.Currency.Code}");
    }

    /// <summary>Adds two money values.</summary>
    public static Money operator +(Money a, Money b) => a.Add(b);
    /// <summary>Subtracts one money value from another.</summary>
    public static Money operator -(Money a, Money b) => a.Subtract(b);
    /// <summary>Multiplies a money value by a scalar factor.</summary>
    public static Money operator *(Money a, decimal b) => a.Multiply(b);
    /// <summary>Returns true if <paramref name="a"/> is greater than <paramref name="b"/>.</summary>
    public static bool operator >(Money a, Money b) => a.CompareTo(b) > 0;
    /// <summary>Returns true if <paramref name="a"/> is less than <paramref name="b"/>.</summary>
    public static bool operator <(Money a, Money b) => a.CompareTo(b) < 0;
    /// <summary>Returns true if <paramref name="a"/> is greater than or equal to <paramref name="b"/>.</summary>
    public static bool operator >=(Money a, Money b) => a.CompareTo(b) >= 0;
    /// <summary>Returns true if <paramref name="a"/> is less than or equal to <paramref name="b"/>.</summary>
    public static bool operator <=(Money a, Money b) => a.CompareTo(b) <= 0;
}
