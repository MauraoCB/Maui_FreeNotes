using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeNotes.Models
{
    public class About
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string Description => "Applicativo de exemplo de uso da tecnologia .Net Maui, baseado no exemplo do Danilo Filitto, está autorizado o download do código fonte nos links abaixo do GitHub, bem como a sua alterção, desde de que citadas as fontes.";
        public string MoreInfoUrl => "https://dfilitto.bog.br";
        public string CodigoFonte => "Código Fonte";
    }
}
