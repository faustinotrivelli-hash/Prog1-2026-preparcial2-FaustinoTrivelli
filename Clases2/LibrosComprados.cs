namespace Biblioteca;

public class LibrosComprados : Catalogo
{
    public string Formato {get; set;}
    public LibrosComprados(string codISBN, string titulo, decimal precioBase, string formato) : base(codISBN, titulo, precioBase)
    {
        Formato = formato;
    }
    
    public override decimal CalcularPrecioFinal(decimal precioBase)
    {
        return precioBase + (precioBase * 0.10);
    }
}
