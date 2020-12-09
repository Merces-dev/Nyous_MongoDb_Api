using Nyous.Api.NoSQL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.Api.NoSQL.Interfaces.Repositories
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();
        UsuarioDomain BuscarPorId(string id);
        void Remover(string id);
        void Adicionar(UsuarioDomain usuario);
        void Alterar(string id, UsuarioDomain usuario);
    }
}
