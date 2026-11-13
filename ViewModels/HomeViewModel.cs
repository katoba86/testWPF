using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1.Entities;
using T1.Repository;
using T1.Services;

namespace T1.ViewModels;

public partial class HomeViewModel : ObservableObject
{

    private readonly ISettingsService _settingsService;
    private readonly IDbSession _dbSession;

    private readonly ClientRepository clientRepository;


    public HomeViewModel(ISettingsService settingsService, IDbSession dbSession)
    {
        _settingsService = settingsService;
        _dbSession = dbSession;        
        clientRepository= new(_dbSession.Connection);
    }


    [ObservableProperty]
    private ObservableCollection<Client> data = new([]);
      

    [RelayCommand]
    private async Task loadClientsAsync()
    {

        var clientsFromDB = await clientRepository.GetClients();
        Data = new ObservableCollection<Client>(clientsFromDB);        
    }

}
