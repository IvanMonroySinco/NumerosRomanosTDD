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
}

public class ConvertidorNumerosRomanos
{
    public object Convertir(int i)
    {
        throw new NotImplementedException();
    }
}