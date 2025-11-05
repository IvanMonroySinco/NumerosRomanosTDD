using FluentAssertions;

namespace NumerosRomanos;

public class NumerosRomanosTest
{
    [Fact]
    public void Si_SeConvierteNumeroUno_Debe_RetornarI()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(1);
        
        conversion.Should().Be("I"); 
    }

    [Fact]
    public void Si_SeConvierteNumeroDos_Debe_RetornarII()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(2);
        
        conversion.Should().Be("II"); 
    }
    
}

public class ConvertidorNumerosRomanos
{
    public string Convertir(int numero)
    {
        if (numero == 2)
            return "II";
        return "I";
    }
}