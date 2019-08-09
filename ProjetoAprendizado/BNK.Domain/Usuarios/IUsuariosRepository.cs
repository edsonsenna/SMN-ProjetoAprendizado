using BNK.Domain.Contas;
using BNK.Domain.Usuarios.Dto;
using System.Collections.Generic;

namespace BNK.Domain.Usuarios
{
    public interface IUsuariosRepository
    {
        List<ContaDto> Acesso(UsuarioDto usuario);
    }
}
