using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PingPong.ViewModels;
using Xamarin.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PingPong.View;
using PingPong;
using PingPong.Models;

namespace PingPong.ViewModels
{
    public class Data  
    {
        public Item OldItem { get; set; }

        public ObservableCollection<Item> items { get; set; }

        public Data()
        {
            try
            {
                items = new ObservableCollection<Item>();

                string fn = "data.json";

                var assembly = typeof(Home).GetTypeInfo().Assembly;

                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{fn}");

                var reader = new StreamReader(stream);

                var js = reader.ReadToEnd();

                stream.Close();

                items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(js);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        public void show(Item _item)
        {

            if (_item.IsVisible)
            {
                _item.IsVisible = false;
            }
            else
            {
                _item.IsVisible = true;
            }
            
            update(_item);
        }

        private void update(Item item)
        {
            var index=items.IndexOf(item);

            items.Remove(item);
            items.Insert(index, item);
        }
    }
}
