using System.Collections.ObjectModel;
using System.Text.Json;

namespace Kosov1
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Discipline> disciplines;

        public MainPage()
        {
            InitializeComponent();
            disciplines = new ObservableCollection<Discipline>();
            disciplines.Add(new Discipline { Name = "Математика", Teacher = "Кавасаки В.О.", ClassNumber = 44, HoursAmount = 64 });
            disciplines.Add(new Discipline { Name = "Физика", Teacher = "Стрипер Г.П.", ClassNumber = 12, HoursAmount = 32 });
            disciplines.Add(new Discipline { Name = "Физ-ра", Teacher = "Крико А.А.", ClassNumber = 0, HoursAmount = 16 });
            disciplines.Add(new Discipline { Name = "Менеджмент", Teacher = "Shluxa G.G.", ClassNumber = -200, HoursAmount = 555 });
            disciplines.Add(new Discipline { Name = "Менеджмент", Teacher = "Shluxa G.G.", ClassNumber = -200, HoursAmount = 555 });
            disciplines.Add(new Discipline { Name = "Менеджмент", Teacher = "Shluxa G.G.", ClassNumber = -200, HoursAmount = 555 });
            ItemsList.ItemsSource = disciplines;
        }

        private void FindClass(object sender, EventArgs e)
        {
            if (Int32.TryParse(Find.Text, out int searchCab))
            {
                foreach (var objects in disciplines)
                {
                    if (searchCab == objects.ClassNumber) SelectedText.Text = objects.Name;
                    else DisplayAlert("Ошибка!", "Такого кабинета нет", "OK");
                }
            }
            else DisplayAlert("Ошибка!", "Введите номер кабинета", "OK");
        }

        string mainDir = FileSystem.Current.AppDataDirectory;

        private void Save(object sender, EventArgs e)
        {
            string JsonString = JsonSerializer.Serialize(disciplines);
            StreamWriter sw = new StreamWriter(Path.Combine(mainDir, "disciplines.txt"));
            sw.WriteLine(JsonString);
            sw.Close();
        }

        private void Load(object sender, EventArgs e)
        {
            StreamReader sw = new StreamReader(Path.Combine(mainDir, "disciplines.txt"));
            string jsonString = sw.ReadLine();
            disciplines = JsonSerializer.Deserialize<ObservableCollection<Discipline>>(jsonString);
            sw.Close();
            ItemsList.ItemsSource = disciplines;
        }

        private void SelectIt(object sender, SelectedItemChangedEventArgs e)
        {
            Discipline gig = new Discipline();
            if (e.SelectedItem != null)
            {
                gig = e.SelectedItem as Discipline;
                SelectedText.Text = gig.Name.ToString();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            Discipline discip = (Discipline)ItemsList.SelectedItem;
            if (discip != null)
            {
                disciplines.Remove(discip);
            }
        }

        private async void EditClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Edit());
        }

        private async void AddClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Add(disciplines));
        }

    }
}
