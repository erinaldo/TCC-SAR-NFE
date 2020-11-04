using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace Tingle
{
    class Nfe
    {
        //Atributos para abrir o Esquema XML
        public static string Path { get; set; }
        public static DataSet XMLSchema = new DataSet();

        //Abrir o arquivo XML
        public static void Open()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                CheckPathExists = true,
                CheckFileExists = true,
                Title = "Insira seu documento",
                Filter = "Arquivo XML|*.xml"

            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Path = fileDialog.FileName.ToString();
            }
        }

        //Ler o Esquema XML com a função do DataSet
        public static void Read()
        {
            XMLSchema.ReadXml(Path);
        }
    }
}
