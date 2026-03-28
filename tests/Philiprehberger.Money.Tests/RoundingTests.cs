using Xunit;
using Philiprehberger.Money;

namespace Philiprehberger.Money.Tests;

public class RoundingTests
{
    [Fact]
    public void Round_DefaultMode_RoundsAwayFromZero()
    {
        var money = Money.Of(10.555m, Currencies.USD);
        var rounded = money.Round(1);
        Assert.Equal(10.60m, rounded.ToDecimal());
    }

    [Fact]
    public void Round_BankersRounding_RoundsToEven()
    {
        // Use JPY (0 decimal places) so rounding to 0 places actually works
        var money = Money.Of(11m, Currencies.JPY);
        var rounded = money.Round(0, RoundingMode.BankersRounding);
        Assert.Equal(11m, rounded.ToDecimal());
    }

    [Fact]
    public void Round_TowardsZero_Truncates()
    {
        var money = Money.Of(10.99m, Currencies.USD);
        var rounded = money.Round(0, RoundingMode.TowardsZero);
        Assert.Equal(10m, rounded.ToDecimal());
    }

    [Fact]
    public void Round_AwayFromZero_RoundsUp()
    {
        var money = Money.Of(10.50m, Currencies.USD);
        var rounded = money.Round(0, RoundingMode.AwayFromZero);
        Assert.Equal(11m, rounded.ToDecimal());
    }

    [Fact]
    public void Round_SameOrMoreDecimalPlaces_ReturnsUnchanged()
    {
        var money = Money.Of(10.55m, Currencies.USD);
        var rounded = money.Round(2);
        Assert.Equal(10.55m, rounded.ToDecimal());

        var rounded3 = money.Round(3);
        Assert.Equal(10.55m, rounded3.ToDecimal());
    }
}
