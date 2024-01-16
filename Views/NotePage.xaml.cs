using FreeNotes.Models;
using Microsoft.Maui.Controls.Handlers;

namespace FreeNotes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId
    {
        set
        {
            LoadNote(value);
        }
    }
    //  string fileName = Path.Combine(FileSystem.AppDataDirectory, "nota.txt");
    public NotePage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;

        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(appDataPath, randomFileName));
	}

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            File.WriteAllText(note.FileName, TextEditor.Text); 
        }

         await Shell.Current.GoToAsync("..");
    }

    private async void btnExcluir_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            } 
        }
        await Shell.Current.GoToAsync("..");
    }

    public void LoadNote(string fileName)
    {
        Note note = new Note();

        note.FileName = fileName;

        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(fileName);
            note.Text = File.ReadAllText(fileName);
        }

        BindingContext = note;
    }
}