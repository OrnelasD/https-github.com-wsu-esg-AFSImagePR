using System;
using System.IO;
using System.Linq;
using System.Text;


namespace XMLImage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Directory is a Folder named "CSVs" on DesKtop
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CSVs";
            //Multiply Files?
            //string [] array1=Directory.GetFiles()
            //Single File Path
            string path = dir + "\\csvTest.csv";//File Name for Conversion
            StringBuilder newFile = new StringBuilder(); // holder to build file
            Records RecordList = new Records();
            string[] file = new string[] { };
            //Read CSV file into arrary
            file = File.ReadAllLines(path).Skip(1).ToArray();
            //excute the CsvParser - csv convert to Record Object -- to Record List
            RecordList = CSVeXtention.CSVParser(file);

            //invoke class
            XMLeXtension aExt = new XMLeXtension();
            //Pass list into XmlParser -- object convert to xml
            aExt.XMLParser(RecordList);

        }
    }
}
