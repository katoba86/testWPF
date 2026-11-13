using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1.Services;

public interface IDbSession : IDisposable
{
    IDbConnection Connection { get; }
}