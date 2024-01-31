namespace Kosov1;

public partial class Password : ContentPage
{
	public Password()
	{
		InitializeComponent();
	}

    private async void PasswordCheck(object sender, EventArgs e)
    {
        if (PasswordEntry.Text == "123") await Navigation.PushAsync(new MainPage());
        else DisplayAlert("Ошибка", "Неверный пароль", "Ок"); 
    }
}