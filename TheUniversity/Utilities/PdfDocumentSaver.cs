using PdfSharpCore.Pdf;
using System;

namespace TheUniversity.Utilities
{
    public class PdfDocumentSaver
    {
        PdfDocument _document;
        string _fileName = string.Empty;
        public PdfDocumentSaver(PdfDocument document, string fileName)
        {
            _document = document;
            _fileName = fileName;
        }

        public void Save()
        {
            _document.Save($"C:\\{Environment.CurrentDirectory}\\{_fileName}");
        }
    }
}
