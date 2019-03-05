using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WPFGoT.Models;

namespace WPFGoT.ViewModels
{
    class CharacterWPFViewModel : ViewModelBase
    {
        private CharacterWPFModel _characterModel;
        public ObservableCollection<CharacterWPFModel> listCharacters { get; set; }
        public ObservableCollection<HouseWPFModel> listHouses { get; set; }

        public int Bravoury
        {
            get { return _characterModel.Bravoury; }
            set
            {
                if (value != _characterModel.Bravoury)
                    _characterModel.Bravoury = value;
                base.OnPropertyChanged("Bravoury");
            }
        }
        public int Crazyness
        {
            get { return _characterModel.Crazyness; }
            set
            {
                if (value != _characterModel.Crazyness)
                    _characterModel.Crazyness = value;
                base.OnPropertyChanged("Crazyness");
            }
        }

        public string FirstName
        {
            get { return _characterModel.FirstName; }
            set
            {
                if (value != _characterModel.FirstName)
                    _characterModel.FirstName = value;
                base.OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _characterModel.LastName; }
            set
            {
                if (value != _characterModel.LastName)
                    _characterModel.LastName = value;
                base.OnPropertyChanged("LastName");
            }
        }
        public int ID
        {
            get { return _characterModel.ID; }
            set
            {
                if (value != _characterModel.ID)
                    _characterModel.ID = value;
                base.OnPropertyChanged("ID");
            }
        }
        public int ID_House
        {
            get { return _characterModel.ID_House; }
            set
            {
                if (value != _characterModel.ID_House)
                    _characterModel.ID_House = value;
                base.OnPropertyChanged("ID_House");
            }
        }

        public int Pv
        {
            get { return _characterModel.Pv; }
            set
            {
                if (value != _characterModel.Pv)
                    _characterModel.Pv = value;
                base.OnPropertyChanged("Pv");
            }
        }

        public CharacterWPFViewModel()
        {
            _characterModel = new CharacterWPFModel();
            listCharacters = new ObservableCollection<CharacterWPFModel>();
            listHouses = new ObservableCollection<HouseWPFModel>();

        }

        public async void LoadCharacters()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49463/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/characters");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    foreach(CharacterWPFModel c in JsonConvert.DeserializeObject<ObservableCollection<CharacterWPFModel>>(temp))
                    {
                        this.listCharacters.Add(c);
                    }
                }
            }
        }

        public async void LoadHouses()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49463/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/houses");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    foreach (HouseWPFModel h in JsonConvert.DeserializeObject<ObservableCollection<HouseWPFModel>>(temp))
                    {
                        this.listHouses.Add(h);
                    }
                }
            }
        }

        public void ChangeHouse(int index)
        {
            if (index >= 0)
            {
                _characterModel.ID_House = listHouses.ElementAt(index).ID;
            }
        }

        public void SavePerso()
        {
            _characterModel.ID = listCharacters.Count+1;
            this.listCharacters.Add(_characterModel);
            ThronesTournamentManager m = new ThronesTournamentManager();
            m.AddCharacter(_characterModel.Transform());
            /*
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49463/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(_characterModel);
                var htppcontent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/characters", htppcontent);
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Succès");
                }
            }*/
        }

        public CharacterWPFViewModel(int bravoury, int crazyness, string firstName, string lastName, int pv)
        {
            Bravoury = bravoury;
            Crazyness = crazyness;
            FirstName = firstName;
            LastName = lastName;
            Pv = pv;
        }

        public CharacterWPFViewModel(CharacterWPFModel other)
        {
            _characterModel = other;
        }
    }
}
