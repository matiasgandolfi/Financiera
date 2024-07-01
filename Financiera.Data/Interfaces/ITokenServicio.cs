using Financiera.Models.Models;

namespace Financiera.Data.Interfaces
{
    public interface ITokenServicio
    {
        Task<string> CrearToken(UsuarioAplicacionModel usuario);
    }
}