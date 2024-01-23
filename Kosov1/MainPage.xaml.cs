using Android.OS;
using Kotlin.Reflect;

namespace Kosov1
{
    public partial class MainPage : ContentPage
    {
        List<Discipline> disciplines;

        public MainPage()
        {
            InitializeComponent();
            disciplines = new List<Discipline>();
            disciplines.Add(new Discipline { Name = "Математика", Teacher = "Кавасаки В.О.", ClassNumber = 44, HoursAmount = 64 });
            disciplines.Add(new Discipline { Name = "Физика", Teacher = "Стрипер Г.П.", ClassNumber = 12, HoursAmount = 32 });
            disciplines.Add(new Discipline { Name = "Физ-ра", Teacher = "Крико А.А.", ClassNumber = 0, HoursAmount = 16 });
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

        private void SelectIt(object sender, SelectedItemChangedEventArgs e)
        {
            Discipline gig = new Discipline();
            if (e.SelectedItem != null)
            {
                gig = e.SelectedItem as Discipline;
                SelectedText.Text = gig.Name.ToString();
            }
        }
    }
}
