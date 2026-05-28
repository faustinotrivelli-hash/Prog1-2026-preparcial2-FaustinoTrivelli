namespace Biblioteca;

public class BibliotecaService : Orden
{
    List<Orden> Historial = new List<Orden>();

    public void AgregarOrden(Orden orden) => Historial.Add(orden);

    public BuscarPorOrdenUsuario(string nomUsuario)
    {
        for (int i=0; i< Historial.Count; i++)
        {
            if (Historial[i].NomUsuario == nomUsuario)
            {
                return Historial[i];
            }
        }
        return null;
    }

    public decimal ObtenerTotalRecaudado()
    {
        decimal total = Historial.Catalogo.CalcularPrecioFinal.Sum();
    }
}
