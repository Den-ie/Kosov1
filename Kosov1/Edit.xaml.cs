namespace Kosov1;

public partial class Edit : ContentPage
{
	public Edit()
	{
		InitializeComponent();
	}

    private void Edding(object sender, EventArgs e)
    {

    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}