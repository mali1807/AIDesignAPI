using Microsoft.AspNetCore.Http;
using File = Entities.Concrete.File;

namespace Business.Storages.Concrete
{
    public class Storage
    {
        protected async Task<string> FileRenameAsync(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string oldFileName = Path.GetFileNameWithoutExtension(fileName);
            string dateTime = DateTime.UtcNow.ToString("ddMMyyyyHHmmsss");
            string fileRename = $"{CharacterRegulatory(oldFileName + dateTime)}{extension}";
            return fileRename;
        }

        private static string CharacterRegulatory(string name)
            => name.Replace("\"", "")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("/", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("_", "")
                .Replace(" ", "-")
                .Replace("@", "")
                .Replace("€", "")
                .Replace("¨", "")
                .Replace("~", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace(".", "-")
                .Replace("Ö", "o")
                .Replace("ö", "o")
                .Replace("Ü", "u")
                .Replace("ü", "u")
                .Replace("ı", "i")
                .Replace("İ", "i")
                .Replace("ğ", "g")
                .Replace("Ğ", "g")
                .Replace("æ", "")
                .Replace("ß", "")
                .Replace("â", "a")
                .Replace("î", "i")
                .Replace("ş", "s")
                .Replace("Ş", "s")
                .Replace("Ç", "c")
                .Replace("ç", "c")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
    }
}
