using MongoDB.Driver;
using Nyous.Api.NoSQL.Context;
using Nyous.Api.NoSQL.Domains;
using Nyous.Api.NoSQL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.Api.NoSQL.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IMongoCollection<EventoDomain> _eventos;
        public EventoRepository(INyousDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _eventos = database.GetCollection <EventoDomain>(settings.EventosCollectionName);
        }
        public void Adicionar(EventoDomain evento)
        {
            try
            {
                _eventos.InsertOne(evento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(string id, EventoDomain evento)
        {
            try
            {
                _eventos.ReplaceOne(e => e.Id == id, evento);
                _eventos.InsertOne(evento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public EventoDomain BuscarPorId(string id)
        {
            try
            {
                return _eventos.Find<EventoDomain>(e => e.Id == id).First();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<EventoDomain> Listar()
        {
            try
            {
                return _eventos.AsQueryable<EventoDomain>().ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(string id)
        {
            try
            {
                _eventos.DeleteOne(e => e.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
