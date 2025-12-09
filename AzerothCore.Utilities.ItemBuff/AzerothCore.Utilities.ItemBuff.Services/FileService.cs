namespace AzerothCore.Utilities.ItemBuff.Services
{
    public class FileService
    {

        public List<string> ListFiles(string path)
        {
            var list = new List<string>();

            var files = Directory.EnumerateFiles(path);

            return files.ToList();
        }

        public List<string> LoadItems(string file)
        {
            var list = new List<string>();

            using (var reader = File.OpenText(file))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            return list;
        }

        public void SaveQuery(List<string> queries, string file)
        {
            using(var writer = File.CreateText(file))
            {
                foreach (var query in queries)
                {
                    writer.WriteLine(query);
                }
            }
        }
        public string LoadJsonFile(string file)
        {
            if (File.Exists(file))
            {
                using (var reader = File.OpenText(file))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                return String.Empty;
            }
        }

        public void SaveJsonFile(string file, string json)
        {
            using(var writer = File.CreateText(file))
            {
                writer.Write(json);
            }
        }
    }
}
