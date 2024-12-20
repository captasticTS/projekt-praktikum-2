using ArrowLog.Database.Models;
using System.Text.RegularExpressions;

namespace ArrowLog.Database.Services;

public static class VerificationService
{
    public static bool VerifyPerson(Person person)
    {
        var namePattern = @"^[A-Za-z\s\-]+$";
        var nickNamePattern = @"^[A-Za-z]+$";
        var emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        var firstNameOkay = Regex.Match(person.FirstName, namePattern).Success
                            && !string.IsNullOrEmpty(person.FirstName);

        var lastNameOkay = Regex.Match(person.LastName, namePattern).Success
                            && !string.IsNullOrEmpty(person.LastName);

        var nickNameOkay = Regex.Match(person.NickName, nickNamePattern).Success
                            && !string.IsNullOrEmpty(person.NickName);

        var emailOkay = Regex.Match(person.Email, emailPattern).Success
                            && !string.IsNullOrEmpty(person.Email);

        return firstNameOkay && lastNameOkay && nickNameOkay && emailOkay;
    }

    public static bool VerifyParcours(Parcours parcours)
    {
        var animalCountOkay = parcours.AnimalCount > 0;

        var nameOkay = !string.IsNullOrEmpty(parcours.Name);

        var locationOkay = !string.IsNullOrEmpty(parcours.Location);

        return animalCountOkay && nameOkay && locationOkay;
    }

    public static bool VerifyGame(Game game)
    {
        var codeOkay = game.Code > 0;

        var dateOkay = game.Date <= DateTime.Now;

        return codeOkay && dateOkay;
    }

    public static bool VerifyRuleset(Ruleset ruleset)
    {
        var nameOkay = !string.IsNullOrEmpty(ruleset.Name);

        return nameOkay;
    }
}
