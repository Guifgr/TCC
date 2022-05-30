using System.Text.RegularExpressions;

namespace TccUmc.Utility.Helpers;

public static class Validate
{
    public static bool IsCnpj(string cnpj)
    {
        var multiplicador1 = new[] {5,4,3,2,9,8,7,6,5,4,3,2};
        var multiplicador2 = new[] {6,5,4,3,2,9,8,7,6,5,4,3,2};
        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;
        var tempCnpj = cnpj.Substring(0, 12);
        var soma = 0;
        for(var i=0; i<12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        var resto = (soma % 11);
        if ( resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        var digito = resto.ToString();
        tempCnpj += digito;
        soma = 0;
        for (var i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito += resto.ToString();
        return cnpj.EndsWith(digito);
    }
    
    public static bool IsCpf(string cpf)
    {
        var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        var tempCpf = cpf.Substring(0, 9);
        var soma = 0;

        for(var i=0; i<9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        var resto = soma % 11;
        if ( resto < 2 )
            resto = 0;
        else
            resto = 11 - resto;
        var digito = resto.ToString();
        tempCpf += digito;
        soma = 0;
        for(var i=0; i<10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito += resto.ToString();
        return cpf.EndsWith(digito);
    }
    
    public static bool IsEmailValid(string email)
    {
        const string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

        return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
    }
}