using System.Collections.ObjectModel;

namespace Kosov1;

public partial class Add : ContentPage
{
    public Add(ObservableCollection<Discipline> disciplines)
    {
        InitializeComponent();
    }

    private void Adding(object sender, EventArgs e)
    {
        
    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}