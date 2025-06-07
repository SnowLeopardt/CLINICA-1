using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;

public class FondoPaginaCompleto : PdfPageEventHelper
{
    private readonly BaseColor _colorFondo;

    public FondoPaginaCompleto(System.Drawing.Color colorFondo)
    {
        _colorFondo = new BaseColor(colorFondo);
    }

    public override void OnEndPage(PdfWriter writer, Document document)
    {
        PdfContentByte cb = writer.DirectContentUnder;

        // Crear la capa manualmente como diccionario PDF
        PdfLayer capaPantalla = new PdfLayer("SoloPantalla", writer);
        PdfDictionary usage = new PdfDictionary();

        PdfDictionary view = new PdfDictionary();
        view.Put(PdfName.VIEWSTATE, PdfName.ON);
        usage.Put(PdfName.VIEW, view);

        PdfDictionary print = new PdfDictionary();
        print.Put(PdfName.PRINTSTATE, PdfName.OFF); // <- Esto desactiva impresión
        usage.Put(PdfName.PRINT, print);

        capaPantalla.Put(PdfName.USAGE, usage);

        cb.BeginLayer(capaPantalla);
        cb.SaveState();

        cb.SetColorFill(_colorFondo);
        cb.Rectangle(0, 0, document.PageSize.Width, document.PageSize.Height);
        cb.Fill();

        cb.RestoreState();
        cb.EndLayer();
    }
}
