using System.Collections.ObjectModel;
using System.Text.Json;

namespace Kosov1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Value.disciplines = new ObservableCollection<Discipline>();
            Value.disciplines.Add(new Discipline { Name = "Математика", Teacher = "Кавасаки В.О.", ClassNumber = 44, HoursAmount = 64 });
            Value.disciplines.Add(new Discipline { Name = "Физика", Teacher = "Стрипер Г.П.", ClassNumber = 12, HoursAmount = 32 });
            Value.disciplines.Add(new Discipline { Name = "Физ-ра", Teacher = "Крико А.А.", ClassNumber = 0, HoursAmount = 16 });
            Value.disciplines.Add(new Discipline { Name = "Менеджмент", Teacher = "Shluxa G.G.", ClassNumber = -200, HoursAmount = 555 });
            Value.disciplines.Add(new Discipline { Name = "Менеджмент", Teacher = "Shluxa G.G.", ClassNumber = -200, HoursAmount = 555 });
            Value.disciplines.Add(new Discipline { Name = "Менеджмент", Teacher = "Shluxa G.G.", ClassNumber = -200, HoursAmount = 555 });
            ItemsList.ItemsSource = Value.disciplines;
        }

        protected virtual void OnAppearing()
        {
            ItemsList.ItemsSource = Value.disciplines;
        }

        private void FindClass(object sender, EventArgs e)
        {
            if (Int32.TryParse(Find.Text, out int searchCab))
            {
                foreach (var objects in Value.disciplines)
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
            string JsonString = JsonSerializer.Serialize(Value.disciplines);
            StreamWriter sw = new StreamWriter(Path.Combine(mainDir, "Value.disciplines.txt"));
            sw.WriteLine(JsonString);
            sw.Close();
        }

        private void Load(object sender, EventArgs e)
        {
            StreamReader sw = new StreamReader(Path.Combine(mainDir, "Value.disciplines.txt"));
            string jsonString = sw.ReadLine();
            Value.disciplines = JsonSerializer.Deserialize<ObservableCollection<Discipline>>(jsonString);
            sw.Close();
            ItemsList.ItemsSource = Value.disciplines;
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
                Value.disciplines.Remove(discip);
            }
        }

        private async void EditClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Edit());
        }

        private async void AddClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Add());
        }

    }
}
