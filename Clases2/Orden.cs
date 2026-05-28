namespace Biblioteca;

public class Orden
{
    private static int idIncr = 0;
    private int IDunico;
    public string NomUsuario {get; set;}
    public Catalogo catalogo {get; set;}
    public decimal TotalPagar {get;}

    public Orden(int idUnico, string nomUsuario, Catalogo catalogo)
    {
        IDunico = id++;
        this.catalogo = catalogo;
        NomUsuario = nomUsuario;

    }
}