using FreeNotes.Models;
using System.Windows.Input;

namespace FreeNotes.Views;

public partial class AboutPage : ContentPage
{
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AboutPage()
	{
		InitializeComponent();
        BindingContext = this;

        PopulateCntrols();
    }

    private void PopulateCntrols()
    {
        About about = new About();

        lblDescription.Text = about.Description;
        lblVersion.Text = $"Versão: {about.Version}"; 
        lblCodigoFonte.Text= about.CodigoFonte;
    }

    private async void imgLinkedin_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://www.linkedin.com/in/jos%C3%A9-mauro-da-silva-3b802512/");
    }
}