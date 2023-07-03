using GalaSoft.MvvmLight.Command;
using MedCatalog.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace MedCatalog.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {

        public ObservableCollection<Drug> Drugs { get; set; }
        private Drug selectedDrug;
        private string selectedDrugName;

        public Drug MySelectedDrug
        {
            get { return selectedDrug; }
            set { selectedDrug = value; OnPropertyChanged("MySelectedDrug"); }
        }


        public string MySelectedDrugName
        {
            get { return selectedDrugName; }
            set { selectedDrugName = value; OnPropertyChanged("MySelectedDrugName"); }
        }



        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(SearchDrug);

                return searchCommand;
            }
        }
        public void SearchDrug()
        {
            bool flag = false;
            foreach (Drug drug in Drugs)
            {

                if (drug.Name.ToLower() == selectedDrugName.ToLower())
                {
                    flag = true;
                    MySelectedDrug = drug;
                }          
            }
            if (!flag)
                MessageBox.Show("Препарат не найден");
        } 




        public MainVM()
        {
            Drugs = new ObservableCollection<Drug>();
            using (MyApplicationContext context = new MyApplicationContext())
            {
                foreach (Drug drug in context.Drugs)
                {
                    Drugs.Add(drug);
                }
            }
            MySelectedDrug = Drugs[0];

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
