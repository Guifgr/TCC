using TccUmc.Utility.Helpers;
using Xunit;

namespace TccUmc.Test.helpers;

public class DocumentValidationTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("93.819.070/0001-58")]
    public void ShoudFailWhenCnpjIsInvalid(string cnpj)
    {
        Assert.False(Validate.IsCnpj(cnpj));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("006.122.990-32")]
    public void FailWhenCpfIsInvalid(string cpf)
    {
        Assert.False(Validate.IsCpf(cpf));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("email.com")]
    [InlineData("email.email")]
    public void FailWhenEmailIsInvalid(string email)
    {
        Assert.False(Validate.IsEmailValid(email));
    }
}