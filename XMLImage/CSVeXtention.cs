using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLImage
{
    class CSVeXtention
    {
        public static Records CSVParser(string[] aFile)
        {
            //Declare variable
            Records aRecordList = new Records();
            //loop through each line from CSV File
            foreach (string line in aFile)
            {
                line.Trim();
                //Parse through each attribute
                using (StringReader stream = new StringReader(line))
                //Use TextField Parser in the event delimator include quotes 
                using (TextFieldParser parser = new TextFieldParser(stream))
                {
                    parser.SetDelimiters(new string[] { "," });
                    parser.HasFieldsEnclosedInQuotes = true;

                    while (!parser.EndOfData)
                    {
                        Record rR = new Record();
                        string[] fields = parser.ReadFields();
                        Debug.WriteLine(fields.Length);
                        foreach (var field in fields)
                        {
                            Debug.WriteLine(field);
                        }
                        //Assign csv row to Object
                        rR.FIRSTNM  = fields[0];
                        rR.LASTNM   = fields[1];
                        rR.PRNUM    = fields[2];
                        rR.AMOUNT   = fields[3];
                        rR.DATE     = Convert.ToDateTime(fields[4]);
                        rR.DEPT     = fields[5];
                        //Add Object to List<>
                        aRecordList.Add(rR);
                    }
                }
            }
            return aRecordList;
        }
    }
}
