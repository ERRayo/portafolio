using PortafolioRayo.Models;

namespace PortafolioRayo.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyecto();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyecto()
        {
            return new List<Proyecto>() { 
            new Proyecto {
                Titulo = "BioApp",
                Descripcion = "Sistema para el control de asistencias",
                Link = "https://github.com/ERRayo?tab=repositories",
                ImagenURL = "/imagenes/bioapp.jpg"
            },
            
            };
        }
    }
}
