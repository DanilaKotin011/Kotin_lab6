using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Kotin_lab6.Models;
using System.Collections.ObjectModel;

namespace Kotin_lab6.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        public FirstViewModel(List<Note> ItemsList)
        {
            ItemsAll = ItemsList;
            Currentdate = DateTime.Today;
            changeItems(); 
        }

        DateTimeOffset currentdate;
        public DateTimeOffset Currentdate
        {
            get 
            {
                return currentdate;
            } 
            set
            {
                this.RaiseAndSetIfChanged(ref currentdate, value);
                changeItems();
            }
        }
        public void changeItems()
        {
            List<Note> Items = new List<Note>();
            foreach (var item in ItemsAll)
            {
                if (item.Date.Equals(Currentdate)) Items.Add(item);
            }
            ItemsCurrent = Items;
        }

        public List<Note> ItemsAll { get; set; }
        public List<Note> itemscurrent;

        public List<Note> ItemsCurrent
        {
            get
            {
                return itemscurrent;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref itemscurrent, value);
            }
        }

    }

    

    


}
