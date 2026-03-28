using Xunit;
using Philiprehberger.Money;

namespace Philiprehberger.Money.Tests;

public class PercentageTests
{
    [Fact]
    public void Percentage_CalculatesCorrectAmount()
    {
        var money = Money.Of(100m, Currencies.USD);
        var result = money.Percentage(8.5m);
        Assert.Equal(8.50m, result.ToDecimal());
    }

    [Fact]
    public void Percentage_ZeroPercent_ReturnsZero()
    {
        var money = Money.Of(50m, Currencies.USD);
        var result = money.Percentage(0m);
        Assert.Equal(0m, result.ToDecimal());
    }

    [Fact]
    public void Percentage_HundredPercent_ReturnsSameAmount()
    {
        var money = Money.Of(42.50m, Currencies.EUR);
        var result = money.Percentage(100m);
        Assert.Equal(42.50m, result.ToDecimal());
    }

    [Fact]
    public void AddPercentage_AddsTaxToAmount()
    {
        var money = Money.Of(100m, Currencies.USD);
        var result = money.AddPercentage(8.5m);
        Assert.Equal(108.50m, result.ToDecimal());
    }

    [Fact]
    public void AddPercentage_ZeroPercent_ReturnsSameAmount()
    {
        var money = Money.Of(75.00m, Currencies.EUR);
        var result = money.AddPercentage(0m);
        Assert.Equal(75.00m, result.ToDecimal());
    }
}
