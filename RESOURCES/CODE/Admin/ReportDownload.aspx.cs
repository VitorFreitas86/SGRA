using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10.Admin
{
    public partial class ReportDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["FileName"] != null && Request.QueryString["FilePath"] != null)
            {
                string filePath = Request.QueryString["FilePath"].ToString();
                string nome = Request.QueryString["FileName"].ToString();
             
                var response = Page.Response;
                response.Clear();
                response.AddHeader("content-disposition", string.Format("attachement; filename=\"{0}\"", nome));
                response.ContentType = "application/octet-stream";
                response.WriteFile(filePath);
                response.End();
            }
        }
    }
}