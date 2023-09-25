using System.Reflection;
using Tesseract;

public static class OCRService
{
    public static string ReadTextFromImage(string pastaProjeto, string nomeImagem)
    {
        string tessDataPath = Path.Combine(pastaProjeto, "tessdata\\");

        using (var engine = new TesseractEngine(tessDataPath, "por", EngineMode.Default))
        {
            string pathImage = Path.Combine(pastaProjeto, "Resources\\Images\\", nomeImagem);
            using (var image = Pix.LoadFromFile(pathImage))
            {
                using (var page = engine.Process(image))
                {
                    return page.GetText();
                }
            }
        }
    }
}
