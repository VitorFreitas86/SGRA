using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WebApplication10.BAL
{
    public class StampDocument
    {
        public static void PutImageWaterMark(string path, string imagePath)
        {

            byte[] _byte = File.ReadAllBytes(path);
            PdfReader reader = new PdfReader(_byte);
            PdfStamper pdfStamper = new PdfStamper(reader,
            new FileStream(path, FileMode.Create));
            Image img = iTextSharp.text.Image.GetInstance(imagePath);
            PdfContentByte content;
            img.SetAbsolutePosition(065, 315);
            for (int i = 0; i < reader.NumberOfPages; i++)
            {
                content = pdfStamper.GetUnderContent(i + 1);
                content.AddImage(img);
            }
            pdfStamper.Close();

        }
    }
    


}
