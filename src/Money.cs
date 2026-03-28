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
/// Specifies how midpoint values are rounded during monetary calculations.
/// </summary>
public enum RoundingMode
{
    /// <summary>Rounds midpoint values away from zero (standard rounding). This is the default.</summary>
    MidpointAwayFromZero,

    /// <summary>Rounds midpoint values to the nearest even number (banker's rounding).</summary>
    BankersRounding,

    /// <summary>Rounds towards zero, truncating any fractional digits.</summary>
    TowardsZero,

    /// <summary>Rounds away from zero (ceiling for positives, floor for negatives).</summary>
    AwayFromZero
}

/// <summary>
/// Well-known ISO 4217 currency constants.
/// </summary>
public static class Currencies
{
    /// <summary>United States Dollar (USD).</summary>
    public static Currency USD { get; } = new("USD", "$", 2);
    /// <summary>Euro (EUR).</summary>
    public static Currency EUR { get; } = new("EUR", "\u20ac", 2);
    /// <summary>British Pound Sterling (GBP).</summary>
    public static Currency GBP { get; } = new("GBP", "\u00a3", 2);
    /// <summary>Japanese Yen (JPY).</summary>
    public static Currency JPY { get; } = new("JPY", "\u00a5", 0);
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

    // G20 and common world currencies

    /// <summary>Brazilian Real (BRL).</summary>
    public static Currency BRL { get; } = new("BRL", "R$", 2);
    /// <summary>Chinese Yuan (CNY).</summary>
    public static Currency CNY { get; } = new("CNY", "\u00a5", 2);
    /// <summary>Indian Rupee (INR).</summary>
    public static Currency INR { get; } = new("INR", "\u20b9", 2);
    /// <summary>Mexican Peso (MXN).</summary>
    public static Currency MXN { get; } = new("MXN", "$", 2);
    /// <summary>South African Rand (ZAR).</summary>
    public static Currency ZAR { get; } = new("ZAR", "R", 2);
    /// <summary>South Korean Won (KRW).</summary>
    public static Currency KRW { get; } = new("KRW", "\u20a9", 0);
    /// <summary>Singapore Dollar (SGD).</summary>
    public static Currency SGD { get; } = new("SGD", "$", 2);
    /// <summary>Hong Kong Dollar (HKD).</summary>
    public static Currency HKD { get; } = new("HKD", "$", 2);
    /// <summary>New Taiwan Dollar (TWD).</summary>
    public static Currency TWD { get; } = new("TWD", "NT$", 2);
    /// <summary>Thai Baht (THB).</summary>
    public static Currency THB { get; } = new("THB", "\u0e3f", 2);
    /// <summary>Malaysian Ringgit (MYR).</summary>
    public static Currency MYR { get; } = new("MYR", "RM", 2);
    /// <summary>Philippine Peso (PHP).</summary>
    public static Currency PHP { get; } = new("PHP", "\u20b1", 2);
    /// <summary>Indonesian Rupiah (IDR).</summary>
    public static Currency IDR { get; } = new("IDR", "Rp", 2);
    /// <summary>Vietnamese Dong (VND).</summary>
    public static Currency VND { get; } = new("VND", "\u20ab", 0);
    /// <summary>Polish Zloty (PLN).</summary>
    public static Currency PLN { get; } = new("PLN", "z\u0142", 2);
    /// <summary>Czech Koruna (CZK).</summary>
    public static Currency CZK { get; } = new("CZK", "K\u010d", 2);
    /// <summary>Hungarian Forint (HUF).</summary>
    public static Currency HUF { get; } = new("HUF", "Ft", 2);
    /// <summary>Turkish Lira (TRY).</summary>
    public static Currency TRY { get; } = new("TRY", "\u20ba", 2);
    /// <summary>Russian Ruble (RUB).</summary>
    public static Currency RUB { get; } = new("RUB", "\u20bd", 2);
    /// <summary>Israeli New Shekel (ILS).</summary>
    public static Currency ILS { get; } = new("ILS", "\u20aa", 2);
    /// <summary>United Arab Emirates Dirham (AED).</summary>
    public static Currency AED { get; } = new("AED", "AED", 2);
    /// <summary>Saudi Riyal (SAR).</summary>
    public static Currency SAR { get; } = new("SAR", "SAR", 2);
    /// <summary>New Zealand Dollar (NZD).</summary>
    public static Currency NZD { get; } = new("NZD", "$", 2);
    /// <summary>Argentine Peso (ARS).</summary>
    public static Currency ARS { get; } = new("ARS", "$", 2);
    /// <summary>Chilean Peso (CLP).</summary>
    public static Currency CLP { get; } = new("CLP", "$", 0);
    /// <summary>Colombian Peso (COP).</summary>
    public static Currency COP { get; } = new("COP", "$", 2);
    /// <summary>Peruvian Sol (PEN).</summary>
    public static Currency PEN { get; } = new("PEN", "S/", 2);
    /// <summary>Egyptian Pound (EGP).</summary>
    public static Currency EGP { get; } = new("EGP", "E\u00a3", 2);
    /// <summary>Nigerian Naira (NGN).</summary>
    public static Currency NGN { get; } = new("NGN", "\u20a6", 2);
    /// <summary>Kenyan Shilling (KES).</summary>
    public static Currency KES { get; } = new("KES", "KSh", 2);
    /// <summary>Ghanaian Cedi (GHS).</summary>
    public static Currency GHS { get; } = new("GHS", "GH\u20b5", 2);
    /// <summary>Ukrainian Hryvnia (UAH).</summary>
    public static Currency UAH { get; } = new("UAH", "\u20b4", 2);
    /// <summary>Romanian Leu (RON).</summary>
    public static Currency RON { get; } = new("RON", "lei", 2);
    /// <summary>Bulgarian Lev (BGN).</summary>
    public static Currency BGN { get; } = new("BGN", "лв", 2);
    /// <summary>Croatian Kuna (HRK).</summary>
    public static Currency HRK { get; } = new("HRK", "kn", 2);
    /// <summary>Icelandic Krona (ISK).</summary>
    public static Currency ISK { get; } = new("ISK", "kr", 0);
    /// <summary>Serbian Dinar (RSD).</summary>
    public static Currency RSD { get; } = new("RSD", "din", 2);
    /// <summary>Kuwaiti Dinar (KWD).</summary>
    public static Currency KWD { get; } = new("KWD", "KWD", 3);
    /// <summary>Bahraini Dinar (BHD).</summary>
    public static Currency BHD { get; } = new("BHD", "BHD", 3);
    /// <summary>Omani Rial (OMR).</summary>
    public static Currency OMR { get; } = new("OMR", "OMR", 3);
    /// <summary>Qatari Riyal (QAR).</summary>
    public static Currency QAR { get; } = new("QAR", "QAR", 2);
    /// <summary>Bangladeshi Taka (BDT).</summary>
    public static Currency BDT { get; } = new("BDT", "\u09f3", 2);
    /// <summary>Pakistani Rupee (PKR).</summary>
    public static Currency PKR { get; } = new("PKR", "Rs", 2);
    /// <summary>Sri Lankan Rupee (LKR).</summary>
    public static Currency LKR { get; } = new("LKR", "Rs", 2);

    /// <summary>All pre-defined currencies for lookup.</summary>
    public static readonly Currency[] All =
    [
        USD, EUR, GBP, JPY, CHF, CAD, AUD, SEK, NOK, DKK,
        BRL, CNY, INR, MXN, ZAR, KRW, SGD, HKD, TWD, THB,
        MYR, PHP, IDR, VND, PLN, CZK, HUF, TRY, RUB, ILS,
        AED, SAR, NZD, ARS, CLP, COP, PEN, EGP, NGN, KES,
        GHS, UAH, RON, BGN, HRK, ISK, RSD, KWD, BHD, OMR,
        QAR, BDT, PKR, LKR
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
    /// Returns a new <see cref="Money"/> representing the given percentage of this amount.
    /// For example, <c>Money.Of(100m, Currencies.USD).Percentage(8.5m)</c> returns <c>$8.50</c>.
    /// </summary>
    /// <param name="percent">The percentage value (e.g. 8.5 for 8.5%).</param>
    public Money Percentage(decimal percent)
    {
        var result = (long)Math.Round(AmountInMinorUnits * percent / 100m, MidpointRounding.ToEven);
        return new Money(result, Currency);
    }

    /// <summary>
    /// Returns a new <see cref="Money"/> with the given percentage added to the original amount.
    /// Useful for tax-inclusive calculations. For example,
    /// <c>Money.Of(100m, Currencies.USD).AddPercentage(8.5m)</c> returns <c>$108.50</c>.
    /// </summary>
    /// <param name="percent">The percentage to add (e.g. 8.5 for 8.5%).</param>
    public Money AddPercentage(decimal percent)
    {
        var additional = (long)Math.Round(AmountInMinorUnits * percent / 100m, MidpointRounding.ToEven);
        return new Money(AmountInMinorUnits + additional, Currency);
    }

    /// <summary>
    /// Rounds the amount to the specified number of decimal places using the default
    /// rounding mode (<see cref="RoundingMode.MidpointAwayFromZero"/>).
    /// </summary>
    /// <param name="decimalPlaces">The number of decimal places to round to.</param>
    public Money Round(int decimalPlaces)
    {
        return Round(decimalPlaces, RoundingMode.MidpointAwayFromZero);
    }

    /// <summary>
    /// Rounds the amount to the specified number of decimal places using the given rounding mode.
    /// </summary>
    /// <param name="decimalPlaces">The number of decimal places to round to.</param>
    /// <param name="mode">The rounding strategy to apply.</param>
    public Money Round(int decimalPlaces, RoundingMode mode)
    {
        if (decimalPlaces < 0)
            throw new ArgumentException("Decimal places must be non-negative.", nameof(decimalPlaces));

        if (decimalPlaces >= Currency.DecimalPlaces)
            return this;

        var decimalAmount = ToDecimal();
        var midpoint = ToMidpointRounding(mode);
        var rounded = Math.Round(decimalAmount, decimalPlaces, midpoint);
        return Of(rounded, Currency);
    }

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

    private static MidpointRounding ToMidpointRounding(RoundingMode mode) => mode switch
    {
        RoundingMode.MidpointAwayFromZero => MidpointRounding.AwayFromZero,
        RoundingMode.BankersRounding => MidpointRounding.ToEven,
        RoundingMode.TowardsZero => MidpointRounding.ToZero,
        RoundingMode.AwayFromZero => MidpointRounding.AwayFromZero,
        _ => MidpointRounding.AwayFromZero
    };

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
