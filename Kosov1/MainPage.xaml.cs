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
            disciplines.Add(new Discipline { Name = "Математика ", Teacher = "Кавасаки В.О.", ClassNumber = 44, HoursAmount = 64 });
            disciplines.Add(new Discipline { Name = "Физика ", Teacher = "Стрипер Г.П.", ClassNumber = 12, HoursAmount = 32 });
            disciplines.Add(new Discipline { Name = "Физ-ра ", Teacher = "Крико А.А.", ClassNumber = 0, HoursAmount = 16 });
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
    }
}
