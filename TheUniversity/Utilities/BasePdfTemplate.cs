using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace TheUniversity.Utilities
{
    public class BasePdfTemplate
    {
        public static PdfPage CreateBlankPage()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            return page;
        }

        public static PdfDocument CreateEmptyDocument()
        {
            PdfDocument pdfDocument = new PdfDocument();

            return pdfDocument;
        }

        public static XGraphics SetGraphics(PdfPage page)
        {
            XGraphics gfx = XGraphics.FromPdfPage(page);
            return gfx;
        }

        public static XFont SetBaseFont()
        {
            XFont font = new XFont("Courier", 12, XFontStyle.Bold);
            return font;
        }
    }
}