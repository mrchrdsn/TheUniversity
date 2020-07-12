using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace TheUniversity.Utilities
{
    public class PdfTranscript
    {
        PdfPage _page;
        XGraphics _gfx;
        XFont _font;
        PdfDocument _document;
        private readonly string FILE_NAME = "transcript.pdf";

        public PdfTranscript()
        {
            _document = BasePdfTemplate.CreateEmptyDocument();
            _page = _document.AddPage();
            _gfx = BasePdfTemplate.SetGraphics(_page);
            _font = BasePdfTemplate.SetBaseFont();
        }

        public PdfDocument GetTranscript()
        {
            WriteTitle();

            SaveDocument();

            return _document;
        }

        private void WriteTitle()
        {
            _gfx.DrawString("Hello, World!", _font, XBrushes.Black,
                new XRect(0, 0, _page.Width, _page.Height),
                XStringFormats.Center);
        }

        private void SaveDocument()
        {
            _document.Save(FILE_NAME);
        }
    }
}