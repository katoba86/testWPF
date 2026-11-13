using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1.Entities;

namespace T1.Repository;

internal class ClientRepository
{

    IDbConnection _connection;

    public ClientRepository(IDbConnection connection)
    {
        _connection = connection;
    }


    public Task<IEnumerable<Client>> GetClients()
    {
        return _connection.QueryAsync<Client>("Select * from Clients");
        
    }

}
