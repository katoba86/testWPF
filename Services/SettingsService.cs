using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1.Services;

public class SettingsService : ISettingsService
{

    private int called = 0;

    public string Version { get => "1.0.0"; }

    public int Called { get => called; set => called = value; }
}
