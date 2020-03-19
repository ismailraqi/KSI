using ksi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ksi.ViewModels
{
    public class PickerRepViewModel : INotifyPropertyChanged
    {
        ApiService apiService = new ApiService();
        // Model for POST Method to Backend
        public List<Reponse> Results { get; set; }
        // Instantiate a List of Model For each Picker 
        public List<Reponse> rep { get; set; }
        public List<Reponse> rep1 { get; set; }

        public PickerRepViewModel()
        {
            // All Request To retrieve Data from model 
            rep = GetRep().OrderBy(t => t.Rep).ToList();
            rep1 = GetRep1().OrderBy(t => t.Rep).ToList();
        }

        // Method to handle property when it will change ( Hade ta declanche l'evenement fache taytbedel  choix f picker)
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]
                                                string propertyName =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region Answers Q1 Picker Logic 
        // Proerty to store changed value in picker 
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

        // Do whatever functionality you want...When a selectedItem is changed.. 
        private Reponse _selectedRep { get; set; }
        public Reponse SelectedRep
        {
            get { return _selectedRep; }
            set
            {
                if (_selectedRep != value)
                {
                    _selectedRep = value;                  
                    // write code here..
                    MyRep = "Reponse : " + _selectedRep.Id;

                }
            }
        }
        // Answers Value and Id 
        public List<Reponse> GetRep()
        {
            var reps = new List<Reponse>()
            {
                new Reponse(){Id = 11,Rep="Rep number 1",QstN="Q1"},
                new Reponse(){Id = 12,Rep="Rep number 2",QstN="Q1"},
                new Reponse(){Id = 13,Rep="Rep number 3",QstN="Q1"}

            };
            return reps;
        }
        #endregion


        #region Answers Q2 Picker Logic 
        private string _myRep1;
        public string MyRep1
        {
            get { return _myRep1; }
            set
            {
                if (_myRep1 != value)
                {
                    _myRep1 = value;
                    OnPropertyChanged();
                }
            }
        }
        private Reponse _selectedRep1 { get; set; }
        public Reponse SelectedRep1
        {
            get { return _selectedRep1; }
            set
            {
                if (_selectedRep1 != value)
                {
                    _selectedRep1 = value;
                    // Do whatever functionality you want...When a selectedItem is changed..
                    // write code here..
                    MyRep1 = "Reponse : " + _selectedRep1.Id;
                }
            }
        }
        public List<Reponse> GetRep1()
        {
            var reps1 = new List<Reponse>()
            {
                new Reponse(){Id = 15,Rep="Rep number 5",QstN="Q2"},
                new Reponse(){Id = 16,Rep="Rep number 6",QstN="Q2"},
                new Reponse(){Id = 17,Rep="Rep number 7",QstN="Q2"}

            };
            return reps1;
        }
        #endregion


        public List<Reponse> GetReponses()
        {
            Results = new List<Reponse>();
            Results.Add(_selectedRep);
            Results.Add(_selectedRep1);
            return Results;
        }
        public ICommand PostCommand
        {
            get
            {
                return new Command(async () =>
                {
                    responses rs = new responses();
                    rs.Q1 = _selectedRep.Id;
                    rs.Q2 = _selectedRep1.Id;
                    await apiService.PostRepAsync(rs);
                });
            }
        }
    }
    public class Reponse
    { 
        public int Id { get; set; }
        public string Rep { get; set; }
        public string QstN { get; set; }
    }
    public class responses
    {
        public int Q1 { get; set; }
        public int Q2 { get; set; }
    }
}
