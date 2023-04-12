using IronPdf;

var renderer = new ChromePdfRenderer();
var pdf = renderer.RenderHtmlAsPdf("""
    <div>
        <p>Do you agree to the terms?</p>
        <p>
            <input type="radio" id="yes" name="impact" value="yes">
            <label for="yes">Ja</label><br>
        </p>
        <p>
            <input type="radio" id="no" name="impact" value="no">
            <label for="no">Nein</label><br>
        </p>
    </div>
    """);
pdf.SaveAs("radio.pdf"); // works as expected
var attachment = new PdfDocument("test.pdf");
var pdfWithAttachment = PdfDocument.Merge(pdf, attachment);
pdfWithAttachment.SaveAs("radioWithAttachment.pdf"); // the radio buttons in this pdf are broken
