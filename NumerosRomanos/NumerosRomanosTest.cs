using FluentAssertions;

namespace NumerosRomanos;

public class NumerosRomanosTest
{
    [Theory]
    [InlineData(1, "I"),InlineData(2, "II"),InlineData(3, "III")]
    public void Si_SeConvierteUnNumeroMenorACuatro_Debe_RetornarNVecesI(int numero, string resultadoEsperado)
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(numero);
        
        conversion.Should().Be(resultadoEsperado); 
    }
    
    [Fact]
    public void Si_SeConvierteNumeroCuatro_Debe_RetornarIV()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(4);
        
        conversion.Should().Be("IV"); 
    }
    
    [Fact]
    public void Si_SeConvierteNumeroCinco_Debe_RetornarV()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(5);
        
        conversion.Should().Be("V"); 
    }
}

public class ConvertidorNumerosRomanos
{
    public string Convertir(int numero)
    {
        if (numero == 5)
            return "V";
        if (numero == 4)
            return "IV";
        if (numero < 4)
            return new string('I', numero);
        return "I";
    }
}