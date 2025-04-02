// Tehtävänä on tehdä C#-konsolisovellus, joka tarkistaa käyttäjän antaman salasanan vahvuuden ja antaa palautetta sen
// turvallisuudesta. Sovellus antaa pisteitä eri kriteerien perusteella ja antaa käyttäjälle arvion, onko salasana heikko,
// kohtalainen vai vahva.

// See https://aka.ms/new-console-template for more information

using StrongPassword;


{
    Console.WriteLine("Syötä salasana sen vahvuuden arvioimiseksi:");
    string password = Console.ReadLine();

    var checker = new PasswordStrengthChecker();
    int score = checker.CountScore(password);
    string category = checker.GetCategory(score);
    
    if (score <= 2)
        Console.ForegroundColor = ConsoleColor.Red; // Heikko
    else if (score <= 4)
        Console.ForegroundColor = ConsoleColor.Yellow; // Kohtalainen
    else
        Console.ForegroundColor = ConsoleColor.Green; // Vahva
    
    Console.WriteLine($"Salasanasi on vahvuudeltaan: {category} \nPisteet: {score}/5");
    Console.ResetColor();

}