using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
//using java.io;

//using org.apache;
//using org.apache.fop;
//using org.apache.fop.apps;
//using org.apache.fop.tools;
//using org.xml.sax;

public class PrintPdf //: System.Web.UI.Page
{
    //private void Page_Load(object sender, System.EventArgs e)
    //{
    //    byte[] productBytes = System.Text.Encoding.UTF8.GetBytes(this.GetProductInfoInXml());
    //    MemoryStream ms = new MemoryStream(productBytes);
    //    byte[] pdf = PdfRenderer.ToByteArray(ms, Server.MapPath("productinfo.xslt"));
    //    CreatePdf(pdf);
    //}

    //private void CreatePdf(byte[] pdf)
    //{
    //    Response.ClearHeaders();
    //    Response.AddHeader("Accept-Header", pdf.Length.ToString());
    //    Response.ContentType = "application/pdf";
    //    Response.Flush();
    //    Response.BinaryWrite(pdf);
    //    Response.End();

    //}


    private string GetProductInfoInXml()
    {
        MemoryStream ms = new MemoryStream();
        XmlTextWriter w = new XmlTextWriter(ms, Encoding.UTF8)
        {
            Formatting = Formatting.Indented
        };
        w.WriteStartDocument();
        w.WriteStartElement("customer");
        w.WriteStartElement("detail");
        w.WriteElementString("name", "Homer Simpson");
        w.WriteElementString("address", "123 Test Lane");
        w.WriteElementString("city", "Los Angeles");
        w.WriteElementString("state", "California");
        w.WriteEndElement();
        w.WriteStartElement("detail");
        w.WriteElementString("name", "Bart Simpson");
        w.WriteElementString("address", "456 Test Lane");
        w.WriteElementString("city", "San Diego");
        w.WriteElementString("state", "California");
        w.WriteEndElement();
        w.WriteEndElement();
        w.Flush();
        w.Close();
        string xml = System.Text.Encoding.UTF8.GetString(ms.ToArray());
        ms.Flush();
        ms.Close();
        return xml;
    }
}

public class PdfRenderer
{
    //public static byte[] ToByteArray(System.IO.Stream inputStream, string xsltPath)
    //{
    //    return ToByteArray(bosStream(inputStream, xsltPath).toByteArray());
    //}

    //private static byte[] ToByteArray(SByte[] source)
    //{
    //    byte[] bytes = new byte[source.Length];
    //    System.Buffer.BlockCopy(source, 0, bytes, 0, source.Length);
    //    return bytes;
    //}

    //private static ByteArrayOutputStream bosStream(System.IO.Stream inputStream, string xsltPath)
    //{
    //    XslTransform tr = new XslTransform();
    //    XmlUrlResolver res = new XmlUrlResolver();
    //    XmlDocument xmlDoc = new XmlDocument();
    //    xmlDoc.Load(inputStream);
    //    res.Credentials = System.Net.CredentialCache.DefaultCredentials;
    //    System.IO.StringWriter sw = new System.IO.StringWriter();
    //    tr.Load(xsltPath, res);
    //    tr.Transform(xmlDoc.CreateNavigator(), null, sw, res);
    //    ByteArrayOutputStream output = new ByteArrayOutputStream();
    //    Driver dr = new Driver(new InputSource(new java.io.StringReader(sw.ToString())), output);
    //    dr.setRenderer(Driver.RENDER_PDF);
    //    dr.run();
    //    output.close();
    //    return output;
    //}
}
