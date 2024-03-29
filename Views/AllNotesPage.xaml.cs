using FreeNotes.Models;

namespace FreeNotes.Views;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();
		BindingContext = new AllNotes();
	}

    protected override void OnAppearing()
    {
       ((AllNotes)BindingContext).LoadNotes();
    }



    private async void notesCollectin_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var note = (Note)e.CurrentSelection[0];
                        
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FileName}");

            notesCollectin.SelectedItem = null;
        }
    }

    private async void ItemAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }
}