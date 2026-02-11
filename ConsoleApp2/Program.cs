using System.IO;
using System.Windows.Xps.Packaging;

namespace ConsoleApp2;

internal static class Program
{
    [STAThread] // Required for WPF
    private static void Main(string[] args)
    {
        const string outPath = "./output.xps";
        const string inPath = "./Employee List.xps";

        File.Create(outPath).Dispose();
        using var outputDoc = new XpsDocument(outPath, FileAccess.ReadWrite);
        using var inputDoc = new XpsDocument(inPath, FileAccess.Read);
        var fds = inputDoc.GetFixedDocumentSequence();
        var writer = XpsDocument.CreateXpsDocumentWriter(outputDoc);
        writer.Write(fds.DocumentPaginator);
    }
}