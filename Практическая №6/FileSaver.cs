using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Практическая__6
{
    class FileSaver
    {
        public Figure FileReader(string path)
        {
            Figure figure = null;
            if (path.EndsWith(".txt"))
            {
                return txtReader(path, figure);
            }

            else if (path.EndsWith(".json"))
            {
                return jsonReader(path, figure);
            }

            else if (path.EndsWith(".xml"))
            {
                return xmlReader(path, figure);
            }

            else
            {
                Console.WriteLine("Введён неверный формат. Повторите попытку");
                return null;
            }
        }

        public Figure txtReader(string path, Figure figure)
        {
            string[] lines = File.ReadAllLines(path);
            figure = new(lines[0], int.Parse(lines[1]), int.Parse(lines[2]));
            return figure;
        }

        public Figure jsonReader(string path, Figure figure)
        {
            string text = File.ReadAllText(path);
            figure = JsonConvert.DeserializeObject<Figure>(text);
            return figure;
        }

        public Figure xmlReader(string path, Figure figure)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Figure));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                figure  = (Figure)xml.Deserialize(fs);
            }
            return figure;
        }

        public void Filesaver(Figure figure, string savepath)
        {
            if (savepath.EndsWith(".txt"))
            {
                txtSaver(figure, savepath);
            }

            else if (savepath.EndsWith(".json"))
            {
                jsonSaver(figure, savepath);
            }

            else if (savepath.EndsWith(".xml"))
            {
                xmlSaver(figure, savepath);
            }
        }

        public void txtSaver(Figure figure, string savepath)
        {
            File.Create(savepath).Dispose();
            string[] lines = { figure.figurename, figure.width.ToString(), figure.height.ToString() };
            File.WriteAllLines(savepath, lines);
        }

        public void jsonSaver(Figure figure, string savepath)
        {
            string json = JsonConvert.SerializeObject(figure);
            File.WriteAllText(savepath, json);
        }

        private void xmlSaver(Figure figure, string savepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Figure));
            using (FileStream fs = new FileStream(savepath, FileMode.Create))
            {
                serializer.Serialize(fs, figure);
            }
        }
    }
}