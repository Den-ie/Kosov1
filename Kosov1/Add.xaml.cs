using System.Collections.ObjectModel;

namespace Kosov1;

public partial class Add : ContentPage
{

    public Add()
    {
        InitializeComponent();
    }

    private void Adding(object sender, EventArgs e)
    {

        try
        {
            Value.disciplines.Add(new Discipline { Name = DisciplineAdd.Text == "��������" ? "�������� ����� �����" : DisciplineAdd.Text, Teacher = TeacherAdd.Text, ClassNumber = Convert.ToInt32(ClassNumberAdd.Text), HoursAmount = Convert.ToInt32(HoursAmountAdd.Text) });
            DisplayAlert("���������!", "���������� ���������", "��");
        }
        catch (Exception ex) { DisplayAlert("������!", "������� ���������� ������", "��"); }
    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}