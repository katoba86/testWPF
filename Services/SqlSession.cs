using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Management;

namespace T1.Services;



public class SqlSession : IDbSession
{
    private readonly SqliteConnection _connection;

    public SqlSession()
    {
        _connection = new SqliteConnection("Data Source=D:\\test.db");
        _connection.Open(); // Einmalig öffnen beim Start
    }

    // Nach außen wird nur das standardisierte IDbConnection-Interface übergeben
    public IDbConnection Connection => _connection;

    public void Dispose()
    {
        if (_connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }
        _connection.Dispose();
    }
}