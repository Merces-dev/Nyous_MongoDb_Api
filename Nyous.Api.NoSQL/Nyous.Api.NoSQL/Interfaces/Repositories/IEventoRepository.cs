using Nyous.Api.NoSQL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.Api.NoSQL.Interfaces.Repositories
{
    interface IEventoRepository
    {
        List<EventoDomain> Listar();
        EventoDomain BuscarPorId(string id);
        void Adicionar(EventoDomain evento);
        void Atualizar(string id, EventoDomain evento);
        void Remover(string id);
    }
}
