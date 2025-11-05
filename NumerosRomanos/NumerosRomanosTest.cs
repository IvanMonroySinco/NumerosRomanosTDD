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

    [Theory]
    [InlineData(6, "VI"),InlineData(7, "VII"),InlineData(8, "VIII")]
    public void Si_SeConvierteNumeroMayorACincoYMenorANueve_Debe_RetornarVSeguidoDeNVecesIMenosCinco(int numero, string resultadoEsperado)
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(numero);
        
        conversion.Should().Be(resultadoEsperado); 
    }
    
    [Fact]
    public void Si_SeConvierteNumeroNueve_Debe_RetornarIX()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(9);
        
        conversion.Should().Be("IX"); 
    }
    
    [Theory]
    [InlineData(10, "X"),InlineData(20, "XX"),InlineData(30, "XXX")]
    public void Si_SeConvierteNumerosDecenas_Debe_RetornarNVecesX(int numero, string resultadoEsperado)
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(numero);
        
        conversion.Should().Be(resultadoEsperado); 
    }

    [Fact]
    public void Si_SeConvierteNumeroCuarenta_Debe_RetornarXL()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(40);
        
        conversion.Should().Be("XL"); 
    }
    
    
    [Fact]
    public void Si_SeConvierteNumeroCincuenta_Debe_RetornarL()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(50);
        
        conversion.Should().Be("L"); 
    }

    [Theory]
    [InlineData(12, "XII"),InlineData(41, "XLI"),InlineData(55, "LV")]
    public void Si_ConvierteUnNumeroConResiduo_Debe_IncluirSuCaracter(int numero, string resultadoEsperado)
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(numero);
        
        conversion.Should().Be(resultadoEsperado); 
    }

    [Fact]
    public void Si_SeConvierteNumeroNoventa_Debe_RetornarXC()
    {
     
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(90);
        
        conversion.Should().Be("XC");    
    }
}

public class ConvertidorNumerosRomanos
{
    public string Convertir(int numero)
    {
        if (numero >= 50 && numero < 60) return $"L{Convertir(numero-50)}";;
        if (numero >= 40 && numero < 50 ) return $"XL{Convertir(numero-40)}";
        if (numero >= 10)
        {
            int decenas = numero / 10;
            int unidades = numero % 10;

            string cadenaDecenas = new string('X', decenas);
            string cadenaUnidades = Convertir(unidades);
            return $"{cadenaDecenas}{cadenaUnidades}";
        }
        if (numero == 4) return "IV";
        if (numero == 5) return "V";
        if (numero < 4) return new string('I', numero);
        if (numero < 9) return "V" + new string('I', numero - 5);
        if (numero == 9) return "IX";
        return "";
    }
}