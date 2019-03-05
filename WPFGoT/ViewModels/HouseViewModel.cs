using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPFGoT.Models;

namespace WPFGoT.ViewModels
{
    class HouseViewModel : ViewModelBase
    {
        private  HouseWPFModel _houseModel;

        public string Name
        {
            get { return _houseModel.Name; }
            set
            {
                if (value != _houseModel.Name)
                    _houseModel.Name = value;
                base.OnPropertyChanged("Name");
            }
        }

        public int NumberOfUnits
        {
            get { return _houseModel.NumberOfUnits; }
            set
            {
                if (value != _houseModel.NumberOfUnits)
                    _houseModel.NumberOfUnits = value;
                base.OnPropertyChanged("NumberOfUnits");
            }
        }

        public int ID
        {
            get { return _houseModel.ID; }
            set
            {
                if (value != _houseModel.ID)
                    _houseModel.ID = value;
                base.OnPropertyChanged("ID");
            }
        }

        public ObservableCollection<HouseWPFModel> listHouses { get; set; }

        public HouseViewModel()
        {
            _houseModel = new HouseWPFModel();
            listHouses = new ObservableCollection<HouseWPFModel>();

        }

        public async void Load()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/houses");
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Chargement");
                    this.listHouses.Clear();
                    string temp = await response.Content.ReadAsStringAsync();
                    foreach (HouseWPFModel h in JsonConvert.DeserializeObject<ObservableCollection<HouseWPFModel>>(temp))
                    {
                        this.listHouses.Add(h);
                    }
                }
            }
        }

        public async void Save()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(_houseModel);
                var htppcontent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/Houses", htppcontent);
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Succès");
                    Load();
                }
            }
        }

        public async void Delete(int idSuppr)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appllication/json"));

                HttpResponseMessage response = await client.DeleteAsync("api/houses/" + idSuppr.ToString());
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Succès");
                    Load();
                }
            }
        }

        public async void Put(int idModif)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appllication/json"));

                _houseModel.ID = idModif;
                var content = JsonConvert.SerializeObject(_houseModel);
                var httpcontent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync("api/houses/" + idModif.ToString(), httpcontent);
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Succès");
                    Load();
                }
            }
        }

        public void ExportFile()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Xml File (*.xml)|.xml";

            if (s.ShowDialog() == true)
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<HouseWPFModel>));
                using (StreamWriter wr = new StreamWriter(s.FileName))
                {
                     xml.Serialize(wr, listHouses);
                }
            }
        }

        public HouseViewModel(string inName, int inNumberOfUnits, int inID)
        {
            Name = inName;
            NumberOfUnits = inNumberOfUnits;
            ID = inID;
        }

        public HouseViewModel(HouseWPFModel other)
        {
            _houseModel = other;
        }
    }
}
