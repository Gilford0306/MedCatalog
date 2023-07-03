using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace MedCatalog.Model
{
    public class Drug : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string description;
        private string category;
        private string icon;



        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }
        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged("Category"); }
        }
        public string Icon
        {
            get { return icon; }
            set { icon = value; OnPropertyChanged("Icon"); }
        }

        //public override string ToString()
        //{
        //    return $"{Id}) {Name}\t{Description}";
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
