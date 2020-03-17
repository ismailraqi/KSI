using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ksi.ViewModels
{
    public class PickerRepViewModel : INotifyPropertyChanged
    { 
        public List<Reponse> rep1 { get; set; }
        public PickerRepViewModel()
        {
            rep1 = GetRep().OrderBy(t => t.Rep).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]
                                                string propertyName =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _myRep;
        public string MyRep
        {
            get { return _myRep; }
            set
            {
                if (_myRep != value)
                {
                    _myRep = value;
                    OnPropertyChanged();
                }
            }
        }

        private Reponse _selectedRep { get; set; }
        public Reponse SelectedRep
        {
            get { return _selectedRep; }
            set
            {
                if (_selectedRep != value)
                {
                    _selectedRep = value;
                    // Do whatever functionality you want...When a selectedItem is changed..
                    // write code here..
                    MyRep = "Selected City : " + _selectedRep.Id;
                }
            }
        }
        //public List<Reponse> rep2 { get; set; }
        //public List<Reponse> rep3 { get; set; }
        //public List<Reponse> rep4 { get; set; }
        //public List<Reponse> rep5 { get; set; }
        //public List<Reponse> rep6 { get; set; }
        //public List<Reponse> rep7 { get; set; }
        //public List<Reponse> rep8 { get; set; }
        //public List<Reponse> rep9 { get; set; }
        //public List<Reponse> rep10 { get; set; }
        public List<Reponse> GetRep()
        {
            var reps = new List<Reponse>()
            {
                new Reponse(){Id = 11,Rep="Rep number 1"},
                new Reponse(){Id = 12,Rep="Rep number 2"},
                new Reponse(){Id = 13,Rep="Rep number 3"}

            };
            return reps;
        }



    }
    public class Reponse
    { 
        public int Id { get; set; }
        public string Rep { get; set; }
    }
}
