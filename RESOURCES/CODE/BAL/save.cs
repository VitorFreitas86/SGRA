using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10.BAL
{
    public static class save

    {
        //public static void AddValidationSummaryItem(this Page page, string errorMessage)
        //{
        //    var validator = new CustomValidator();
        //    validator.IsValid = false;
        //    validator.ErrorMessage = errorMessage;
        //    page.Validators.Add(validator);
        //} 

        public static void SaveFile(this Byte[] fileBytes, string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(fileBytes, 0, fileBytes.Length);
            fileStream.Close();
        }

        public static void Show(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;
            
            page.ClientScript.RegisterStartupScript(owner.GetType(),
                "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}');window.location = 'home.aspx' ;  </script>",
                message));

        }

        //public static void Confirm_button(string message, Control owner)
        //{
        //    Page page = (owner as Page) ?? owner.Page;
        //    if (page == null) return;

        //    page.ClientScript.RegisterStartupScript(owner.GetType(),
        //        "ShowMessage", string.Format("<script type='text/javascript'>     var r = confirm('Press a button');  if (r == true;  { x = 'You pressed OK!';  } else    {  x = 'You pressed Cancel!'; }   </script>",
        //        message));
         
        //}

    }
}