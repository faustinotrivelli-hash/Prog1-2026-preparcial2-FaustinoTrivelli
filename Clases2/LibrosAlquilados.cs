namespace Biblioteca;

public class LibrosAlquilados : Catalogo
{
    public int DiasAlquiler;
    public LibrosAlquilados(string codISBN, string titulo, decimal precioBase, int diasAlquiler) : base(codISBN, titulo, precioBase)
    {
        if (diasAlquiler <= 0)
        {
            throw new ArgumentException("El costo del libro alquilado no puede ser menor o igual a cero");
        }
        
        DiasAlquiler = diasAlquiler;
    }

    public override decimal CalcularPrecioFinal(decimal precioBase, int diasAlquiler)
    {
        decimal resultado = precioBase * diasAlquiler;
        decimal precioFinal = resultado * 0.15;

        return precioFinal;
    }
}