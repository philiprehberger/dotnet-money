using Xunit;
using Philiprehberger.Money;

namespace Philiprehberger.Money.Tests;

public class CurrenciesTests
{
    [Fact]
    public void All_ContainsAtLeast50Currencies()
    {
        Assert.True(Currencies.All.Length >= 50);
    }

    [Theory]
    [InlineData("USD", "$", 2)]
    [InlineData("EUR", "\u20ac", 2)]
    [InlineData("JPY", "\u00a5", 0)]
    [InlineData("KRW", "\u20a9", 0)]
    [InlineData("BRL", "R$", 2)]
    [InlineData("KWD", "KWD", 3)]
    [InlineData("BHD", "BHD", 3)]
    public void Currency_HasCorrectProperties(string code, string symbol, int decimalPlaces)
    {
        var currency = Currencies.All.First(c => c.Code == code);
        Assert.Equal(symbol, currency.Symbol);
        Assert.Equal(decimalPlaces, currency.DecimalPlaces);
    }

    [Fact]
    public void All_CodesAreUnique()
    {
        var codes = Currencies.All.Select(c => c.Code).ToList();
        Assert.Equal(codes.Count, codes.Distinct().Count());
    }

    [Fact]
    public void Currency_ToString_ReturnsCode()
    {
        Assert.Equal("USD", Currencies.USD.ToString());
        Assert.Equal("BRL", Currencies.BRL.ToString());
    }

    [Fact]
    public void ThreeDecimalPlaceCurrencies_HaveCorrectMinorUnits()
    {
        var money = Money.Of(1.234m, Currencies.KWD);
        Assert.Equal(1234, money.AmountInMinorUnits);
        Assert.Equal(1.234m, money.ToDecimal());
    }
}
