using System.Text.RegularExpressions;

namespace StrongPassword;

public class PasswordStrengthChecker
{
    public int CountScore(string password)
    {
        if (password == null) 
            throw new ArgumentNullException(nameof(password));
        
        int score = 0;
        
        // Regex
        if (password.Length >= 8) score++;
        if (Regex.IsMatch(password, "[A-Z]")) score++;
        if (Regex.IsMatch(password, "[a-z]")) score++;
        if (Regex.IsMatch(password, "[0-9]")) score++;
        if (Regex.IsMatch(password, "[!@#$%^&*(),.?\":{}|<>]")) score++;
        
        return score;
    }

    public string GetCategory(int score)
    {
        
        return score switch
        {
            <= 2 => "Heikko",
            3 or 4 => "Kohtalainen",
            5 => "Vahva",
            _ => "Tuntematon"
        };
    }
}