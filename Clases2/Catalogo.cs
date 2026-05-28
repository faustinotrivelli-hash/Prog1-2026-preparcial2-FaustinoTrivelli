namespace Biblioteca;

public class Catalogo
{
    private string CodISBN {get;}
    public string Titulo {get; set;}
    public decimal PrecioBase{get; set;}

    public Catalogo(string codISBN, string titulo, decimal precioBase)
    {
        if (codISBN == "")
        {
            throw new ArgumentException("El código no puede estar vacío o en blanco");
        }
        if (precioBase <= 0){}
        {
            throw new ArgumentException("El precio base no puede ser menor o igual a cero");
        }
        CodISBN = codISBN;
        Titulo = titulo;
        PrecioBase = precioBase;
    }
    public abstract CalcularPrecioFinal();
}
