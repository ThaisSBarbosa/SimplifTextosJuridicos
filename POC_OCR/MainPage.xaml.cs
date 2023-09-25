namespace POC_OCR;

public partial class MainPage : ContentPage
{
	public MainPage()
    {
        InitializeComponent();

        string textoCapturado = OCRService.ReadTextFromImage(ObtemPastaProjeto(), "teste.png");
        RetornoOCR.Text = textoCapturado;
    }

    private static string ObtemPastaProjeto()
    {
        // "C:\\POC_OCR\\POC_OCR\\";
        // O app executa na pasta C:\POC_OCR\POC_OCR\bin\Debug\net6.0-windows10.0.19041.0\win10-x64\AppX
        // para chegar na pasta que contém o projeto, é necessário voltar 6 pastas.

        var pastaProjeto = AppDomain.CurrentDomain.BaseDirectory;
        for (int i = 0; i < 6; i++)
        {
            Directory.GetParent(pastaProjeto);
            pastaProjeto = Directory.GetParent(pastaProjeto).FullName;
        }

        return pastaProjeto;
    }
}

