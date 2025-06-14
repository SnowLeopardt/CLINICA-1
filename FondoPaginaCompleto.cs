using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;

// Clase para manejar el fondo de la página
public class FondoPaginaCompleto : PdfPageEventHelper
{
    private readonly BaseColor colorFondo;
    public FondoPaginaCompleto(System.Drawing.Color color)
    {
        colorFondo = new BaseColor(color.R, color.G, color.B);
    }
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        // Establecer el fondo de color
        PdfContentByte canvas = writer.DirectContentUnder;
        canvas.SetColorFill(colorFondo);
        canvas.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height);
        canvas.Fill();
    }
    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
        // Cambiar el fondo a blanco al imprimir
        writer.PageEvent = new FondoPaginaBlanco();
    }

    // Clase para el fondo blanco al imprimir
    public class FondoPaginaBlanco : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Establecer el fondo blanco
            PdfContentByte canvas = writer.DirectContentUnder;
            canvas.SetColorFill(BaseColor.WHITE);
            canvas.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height);
            canvas.Fill();
        }
    }
}
