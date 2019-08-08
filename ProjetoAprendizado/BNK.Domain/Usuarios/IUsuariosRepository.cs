using BNK.Domain.Usuarios.Dto;

namespace BNK.Domain.Usuarios
{
    public interface IUsuariosRepository
    {
        int Acesso(UsuarioDto usuario);
    }
}
