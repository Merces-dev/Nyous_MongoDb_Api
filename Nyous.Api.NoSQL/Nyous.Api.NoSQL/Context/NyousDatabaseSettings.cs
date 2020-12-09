﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.Api.NoSQL.Context
{
    public class NyousDatabaseSettings : INyousDatabaseSettings
    {
        public string EventosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get ; set ; }
        public string UsuariosCollectionName { get; set; }
    }
    public interface INyousDatabaseSettings
    {
        string EventosCollectionName { get; set; }
        string UsuariosCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}