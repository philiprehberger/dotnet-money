using Xunit;
using Philiprehberger.Money;

namespace Philiprehberger.Money.Tests;

public class MoneyTests
{
    [Fact]
    public void Of_CreatesCorrectMinorUnits()
    {
        var money = Money.Of(12.99m, Currencies.USD);
        Assert.Equal(1299, money.AmountInMinorUnits);
        Assert.Equal("USD", money.Currency.Code);
    }

    [Fact]
    public void Add_SameCurrency_Succeeds()
    {
        var a = Money.Of(10m, Currencies.USD);
        var b = Money.Of(5.50m, Currencies.USD);
        var result = a + b;
        Assert.Equal(15.50m, result.ToDecimal());
    }

    [Fact]
    public void Add_DifferentCurrency_Throws()
    {
        var a = Money.Of(10m, Currencies.USD);
        var b = Money.Of(10m, Currencies.EUR);
        Assert.Throws<InvalidOperationException>(() => a + b);
    }

    [Fact]
    public void Multiply_ScalesCorrectly()
    {
        var money = Money.Of(10m, Currencies.USD);
        var result = money * 1.5m;
        Assert.Equal(15.00m, result.ToDecimal());
    }

    [Fact]
    public void Format_IncludesSymbolAndAmount()
    {
        var money = Money.Of(12.99m, Currencies.USD);
        Assert.Equal("$12.99", money.Format());
    }
}
