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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<UsuarioDomain> _usuarios;
        public  UsuarioRepository(INyousDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _usuarios = database.GetCollection<UsuarioDomain>(settings.UsuariosCollectionName);
        }
        public void Adicionar(UsuarioDomain usuario)
        {
            try
            {
                _usuarios.InsertOne(usuario);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Alterar(string id, UsuarioDomain usuario)
        {
            try
            {
                _usuarios.ReplaceOne(u => u.Id == id, usuario);
                _usuarios.InsertOne(usuario);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public UsuarioDomain BuscarPorId(string id)
        {
            try
            {
                return _usuarios.Find<UsuarioDomain>(u => u.Id == id).First();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<UsuarioDomain> Listar()
        {
            try
            {
                return _usuarios.AsQueryable<UsuarioDomain>().ToList();
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
                _usuarios.DeleteOne(u => u.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
