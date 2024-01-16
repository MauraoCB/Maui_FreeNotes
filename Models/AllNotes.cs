using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeNotes.Models
{
    public class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public AllNotes() => LoadNotes();

        public void LoadNotes()
        {
           Notes.Clear();

            //Obtém a pasta onde as notas foram gravadas
            string appPathData = FileSystem.AppDataDirectory;

            //Usa extensões linq para carregar os arquivos *.notes.txt
            IEnumerable<Note> notes = Directory
                                     //Seleciona os nomes dos rquivos do diretório
                                     .EnumerateFiles(appPathData, "*.notes.txt")

                                     //Cada nome de arquivo é usada para criar uma nova nota
                                     .Select(fileName => new Note()
                                     {
                                         FileName = fileName,
                                         Text = File.ReadAllText(fileName),
                                         Date = File.GetCreationTime(fileName)
                                     }).OrderBy(note => note.Date);

            //Adiciona cada nota na ObservableCollection
            foreach (Note note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
