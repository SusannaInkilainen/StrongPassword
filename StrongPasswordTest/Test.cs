using StrongPassword;

namespace StrongPasswordTest;

public class Test
{
    private readonly PasswordStrengthChecker _checker = new PasswordStrengthChecker();
    
    // Salasana ei voi olla tyhjä
    [Fact]
    public void CalculateStrength_GivesZeroForEmptyPassword()
    {
        int score = _checker.CountScore("");
        Assert.Equal(0, score);
    }
    
    // salasanaan annetaan pelkkiä numeroita
    [Fact]
    public void CalculateStrength_GivesOneForOnlyNumbers()
    {
        int score = _checker.CountScore("1234567");
        Assert.Equal(1, score);
    }
    
    // vahvan salasanan testaaminen
    [Fact]
    public void CalculateStrength_GivesFiveForStrongPassword()
    {
        int score = _checker.CountScore("Str0ng!Pass");
        Assert.Equal(5, score);
    }
    
    // Testataan salosana, johon on miksattu iso kirjain, pieni kirjain ja numerot
    [Fact]
    public void CalculateStrength_GivesCorrectScoreForMixedCase()
    {
        int score = _checker.CountScore("Abc123");
        Assert.Equal(3, score);
    }
    
    // testataan null
    [Fact]
    public void CalculateStrength_ThrowsExceptionForNullPassword()
    {
        Assert.Throws<ArgumentNullException>(() => _checker.CountScore(null));
    }

    // käytetään theoryä testaamaan, että määritelmät ovat oikein. 
    [Theory]
    [InlineData(0, "Heikko")]
    [InlineData(2, "Heikko")]
    [InlineData(3, "Kohtalainen")]
    [InlineData(4, "Kohtalainen")]
    [InlineData(5, "Vahva")]
    public void GetStrengthCategory_ReturnsCorrectCategory(int score, string expected)
    {
        string category = _checker.GetCategory(score);
        Assert.Equal(expected, category);
    }
}