using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DemoTest.DAL
{
    public class CommonMethod
    {
        public void InsertErrorLog(string err)
        {
            string FileName = DateTime.Now.ToString("dd-MM-yyyy");
            string LogPath = ConfigurationManager.AppSettings["ErrorLogLocation"].ToString();
            if (!System.IO.Directory.Exists(LogPath))
            {
                System.IO.Directory.CreateDirectory(LogPath);
            }
            LogPath = LogPath + FileName + ".txt";

            System.IO.FileStream Fs = new System.IO.FileStream(@LogPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            //set up a streamwriter for adding text
            System.IO.StreamWriter sw = new System.IO.StreamWriter(Fs);
            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, System.IO.SeekOrigin.End);
            sw.WriteLine("------------------------------------------------------------------------------------------------");
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine("Message Start:");
            sw.WriteLine(err); //add the text
            sw.WriteLine("Message End:");
            sw.WriteLine("------------------------------------------------------------------------------------------------");
            sw.Flush();//add the text to the underlying filestream
            sw.Close();//close the writer

        }

    }
}