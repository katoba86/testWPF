using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1.Services;

public interface ISettingsService
{
    string Version { get; }
    int Called { get; set; }
}
