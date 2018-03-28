using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace XMLImage
{
    class XMLeXtension
    {
        public void XMLParser(Records aRecords)
        {
            //Folder Directory for Writing
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CSVs\\XMLConv";


            StringBuilder aFileName = new StringBuilder(); ;
            //Creating one document for all records
            XElement xmlElements = new XElement("Records");
            try
            {
                //var xEle = new XElement("Records");
                //Each Record
                foreach (Record aRecord in aRecords)
                {
                    aFileName.Clear();
                    aFileName.AppendFormat("AFS{0}PR", aRecord.PRNUM);
                    XDocument PRRecord = new XDocument(
                    //var iElement =  new XElement("PRRECORD",
                                    new XElement("PRRECORD",
                                    new XElement("FirstName", aRecord.FIRSTNM),
                                    new XElement("LastName", aRecord.LASTNM),
                                    new XElement("PR_Number", aRecord.PRNUM),
                                    new XElement("Amount", aRecord.AMOUNT),
                                    new XElement("Date", aRecord.DATE),
                                    new XElement("Department", aRecord.DEPT)
                              ));
                    //TODO Write each record as a seperate file

                    //TODO Retreive each file and assign xslt
                    //Create transform object and Load XSLT
                    using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("XMLImage.XSLTPR.xslt"))
                    using (XmlReader reader = XmlReader.Create(strm))
                    using (XmlWriter writer = PRRecord.CreateWriter())
                    {
                        XslCompiledTransform aXslTrans = new XslCompiledTransform();
                        aXslTrans.Load(reader);
                        aXslTrans.Transform(PRRecord.CreateNavigator(), writer);
                        Console.WriteLine(PRRecord);
                        
                        PRRecord.Save(dir + "\\" + aFileName + ".xml");
                        File.WriteAllText(dir + "\\" + aFileName +".txt", PRRecord.ToString());
                        //TODO Transfer PRROCRDS.DOCUMENT to PDF

                        //SAVE document

                        Console.WriteLine("You made here Yah!");
                        PRRecord.Document.RemoveNodes();

                        //aXslTrans.
                    }

                    //PRRecord.Save(dir + "\\" + aFileName +".xml");
                    //aXslTrans

                    //TODO After transform Create PDF or Image

                    //TO Save each PDF or Image
                    //xEle.Add(iElement);
                }
                //aXslTrans.Transform(xEle, null);
                //xEle.Save(dir + "\\PRRecord2.xml");
                //File.WriteAllText(dir + "\\PRRecords2.txt", xEle.ToString());
                Console.WriteLine("Converted to XML");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

    }
}
