using System.Text;
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
    public void Si_ConvierteNumeroCien_Debe_RetornarC()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(100);
        
        conversion.Should().Be("C"); 
    }
    
    [Fact]
    public void Si_ConvierteNumeroCuatrocientos_Debe_RetornarCD()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(400);
        
        conversion.Should().Be("CD"); 
    }
    
    [Fact]
    public void Si_ConvierteNumeroQuinientos_Debe_RetornarD()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(500);
        
        conversion.Should().Be("D"); 
    }

    [Fact]
    public void Si_ConvierteNumeroNovecientos_Debe_RetornarCM()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(900);
        
        conversion.Should().Be("CM"); 
    }
    
    
    [Fact]
    public void Si_ConvierteNumeroMil_Debe_RetornarM()
    {
        var numerosRomanos = new ConvertidorNumerosRomanos();
        
        var conversion = numerosRomanos.Convertir(1000);
        
        conversion.Should().Be("M"); 
    }  
}

public class ConvertidorNumerosRomanos
{
    private static readonly (int numero, string simbolo)[] MapaCaracteres =
    {        
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    };
    public string Convertir(int numero)
    {
        var resultado = new StringBuilder();
        foreach (var(valor, simbolo) in MapaCaracteres)
        {
            while (numero >= valor)
            {
                resultado.Append(simbolo);
                numero -= valor;
            }
        }

        return resultado.ToString();
    }
}