using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace WebApplication10.Admin
{
    public partial class gerir_cartao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (GridView_cartao.AllowPaging == true)
                ApplyPaging();
            }
            else
            {
                carrega_cartao();
            }

        }

        private void ApplyPaging()
        {
            //////////////////PAGINAMENTO DA GRIDVIEW E CRIACAO DO TEMPLATE COM CSS DOS BOTOES//////////////////
            try
            {
                GridViewRow row = GridView_cartao.BottomPagerRow;
                PlaceHolder ph;
                LinkButton lnkPaging;
                LinkButton lnkFirstPage;
                LinkButton lnkPrevPage;
                LinkButton lnkNextPage;
                LinkButton lnkLastPage;
                lnkFirstPage = new LinkButton();
                lnkFirstPage.Text = Server.HtmlEncode(".");
                lnkFirstPage.Width = Unit.Pixel(32);
                lnkFirstPage.Height = Unit.Pixel(32);
                lnkFirstPage.CssClass = "LinkPaging_first";
                lnkFirstPage.ToolTip = "Primeira Página";
                lnkFirstPage.CommandName = "Page";
                lnkFirstPage.CommandArgument = "first";
                lnkPrevPage = new LinkButton();
                lnkPrevPage.CssClass = "LinkPaging_anterior";
                lnkPrevPage.ToolTip = "Página Anterior";
                lnkPrevPage.Text = Server.HtmlEncode(".");
                lnkPrevPage.Width = Unit.Pixel(32);
                lnkPrevPage.Height = Unit.Pixel(32);
                lnkPrevPage.CommandName = "Page";
                lnkPrevPage.CommandArgument = "prev";
                ph = (PlaceHolder)row.FindControl("ph");
                ph.Controls.Add(lnkFirstPage);
                ph.Controls.Add(lnkPrevPage);
                if (GridView_cartao.PageIndex == 0)
                {
                    lnkFirstPage.Enabled = false;
                    lnkPrevPage.Enabled = false;
                }
                for (int i = 1; i <= GridView_cartao.PageCount; i++)
                {
                    lnkPaging = new LinkButton();
                    lnkPaging.Width = Unit.Pixel(22);
                    lnkPaging.Height = Unit.Pixel(22);
                    lnkPaging.CssClass = "LinkPaging";
                    lnkPaging.Text = i.ToString();
                    lnkPaging.ToolTip = "Página " + i;
                    lnkPaging.CommandName = "Page";
                    lnkPaging.CommandArgument = i.ToString();
                    if (i == GridView_cartao.PageIndex + 1)
                        lnkPaging.CssClass = "LinkPaging_selected";

                    ph = (PlaceHolder)row.FindControl("ph");
                    ph.Controls.Add(lnkPaging);
                }
                lnkNextPage = new LinkButton();
                lnkNextPage.Text = Server.HtmlEncode(" . ");
                lnkNextPage.Width = Unit.Pixel(32);
                lnkNextPage.Height = Unit.Pixel(32);
                lnkNextPage.CssClass = "LinkPaging_proximo";
                lnkNextPage.ToolTip = "Página Seguinte";
                lnkNextPage.CommandName = "Page";
                lnkNextPage.CommandArgument = "next";
                lnkLastPage = new LinkButton();
                lnkLastPage.Text = Server.HtmlEncode(".");
                lnkLastPage.CssClass = "LinkPaging_last";
                lnkLastPage.ToolTip = "Última Página";
                lnkLastPage.Width = Unit.Pixel(32);
                lnkLastPage.Height = Unit.Pixel(32);
                lnkLastPage.CommandName = "Page";
                lnkLastPage.CommandArgument = "last";
                ph = (PlaceHolder)row.FindControl("ph");
                ph.Controls.Add(lnkNextPage);
                ph = (PlaceHolder)row.FindControl("ph");
                ph.Controls.Add(lnkLastPage);
                if (GridView_cartao.PageIndex == GridView_cartao.PageCount - 1)
                {
                    lnkNextPage.Enabled = false;
                    lnkLastPage.Enabled = false;
                }
            }
            catch { }
        }



        protected void carrega_cartao()
        {
            //////////////////CARREGAR GRIDVIEW CARTAO PRINCIPAL//////////////////
            BAL_cartao cartao = new BAL_cartao();
            GridView_cartao.DataSource = cartao.get_cartao_all();
            GridView_cartao.DataBind();
        }

        protected void GridView_cartao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //////////////////PAGINAMENTO GRIDVIEW PRINCIPAL//////////////////
            GridView_cartao.PageIndex = e.NewPageIndex;
            carrega_cartao();
        }

        protected void GridView_cartao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            foradeprazo();//////////////////HACK PARA MANTER A COR DOS QUE ESTAO FORA DE PRAZO//////////////////
            if (e.CommandName.ToString() == "send_email")
            {
                //////////////////ENIVAR EMAIL//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_cartao.DataKeys[rowIndex].Value);
                BAL_cartao cartao = new BAL_cartao();
                Label path1 = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotocopia_bi");
                Label path2 = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotocopia_vinculo_laboral");
                Label path3 = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotografia");
                Label path4 = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_registo_criminal");
                Label path5 = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotocopia_cartao_acompanhante");
                Label path6 = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_path_doc_final");
                acessos MyMasterPage = (acessos)Page.Master;
                MyMasterPage.painel_email = cartao.email_by_id(id);
                string[] docs_upload = { path1.Text, path2.Text, path3.Text, path4.Text, path5.Text, path6.Text };
                MyMasterPage.documentos_conducao = docs_upload;

            }

            if (e.CommandName.ToString() == "hide")
            {
                //////////ESCONDER CHILD PANELS////////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = false;
                Panel_renovacao.Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView_cartao.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                GridView_cartao.SelectedIndex = -1;
                int DemoId = Convert.ToInt32(gvr.RowIndex.ToString());
                GridView_cartao.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#e8e8e8");
                this.UpdatePanel1.Update();
                foradeprazo();
                GridView_cartao.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d4465");
                GridView_cartao.Rows[DemoId].Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");

            }

            if (e.CommandName.ToString() == "renovacao")
            {
                //////////////////RENOVACAO //////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_cartao.DataKeys[rowIndex].Value);
                ViewState["id_cartao"] = id;
                GridView_cartao.SelectedIndex = rowIndex;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = false;
                Panel_renovacao.Visible = true;
                Label estado_inactivo = (Label)GridView_cartao.Rows[rowIndex].FindControl("lbl_estado");
                ImageButton ImageButton_hide = (ImageButton)GridView_cartao.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                if (estado_inactivo.Text == "Inactivo")
                {
                    //////////////////ESCONDER ADMINISTRACAO DAS CHILDGRIDS SE O PEDIDO ESTIVER INATIVO//////////////////
                    GridView GridView_renovacao = (GridView)GridView_cartao.Rows[rowIndex].Cells[17].FindControl("GridView_renovacao") as GridView;
                    GridView_renovacao.Columns[7].Visible=false;
                        
                }
                GridView_cartao.SelectedIndex = rowIndex;
                GridView_cartao.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_cartao.Rows[rowIndex].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                GridView_cartao.SelectedRow.Attributes.Remove("onmouseover");
            }
            if (e.CommandName.ToString() == "segunda_via")
              {
                  //////////////////PEDIDO DE SEGUNDA VIA//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_cartao.DataKeys[rowIndex].Value);
                ViewState["id_cartao"] = id;
                GridView_cartao.SelectedIndex = rowIndex;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = true;
                Panel_renovacao.Visible = false;
                Label estado_inactivo = (Label)GridView_cartao.Rows[rowIndex].FindControl("lbl_estado");
                ImageButton ImageButton_hide = (ImageButton)GridView_cartao.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                if (estado_inactivo.Text == "Inactivo")
                {
                    //////////////////ESCONDER ADMINISTRACAO DAS CHILDGRIDS SE O PEDIDO ESTIVER INATIVO//////////////////
                    GridView GridView_segunda_via = (GridView)GridView_cartao.Rows[rowIndex].Cells[16].FindControl("GridView_segunda_via") as GridView;
                    GridView_segunda_via.Columns[5].Visible = false;
                   
                }
                GridView_cartao.SelectedIndex = rowIndex;
                GridView_cartao.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_cartao.Rows[rowIndex].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                GridView_cartao.SelectedRow.Attributes.Remove("onmouseover");
            }
            if (e.CommandName.ToString() == "fotocopia_bi")
            {
                //////////////////DOWNLOAD FOTOCOPIA BI//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotocopia_bi");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
   

            }
            if (e.CommandName.ToString() == "fotocopia_vinculo_laboral")
            {
                //////////////////DOWNLOAD VINCULO LABORAL//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotocopia_vinculo_laboral");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
   
            }
            if (e.CommandName.ToString() == "fotografia")
            {
                //////////////////DOWNLOAD FOTOGRAFIA//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotografia");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
   
            }
            if (e.CommandName.ToString() == "registo_criminal")
            {
                //////////////////DOWNLOAD REGISTO CRIMINAL//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_registo_criminal");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
   
            }
            if (e.CommandName.ToString() == "fotocopia_cartao_acompanhante")
            {
                //////////////////DOWNLOAD FOTOCOPIA CARTAO ACOMPANHANTE//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_fotocopia_cartao_acompanhante");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
   
            }
            if (e.CommandName.ToString() == "path_doc_final")
            {
                //////////////////DOWNLOAD DOCUMANTO FINAL//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_cartao.Rows[rowIndex].FindControl("lb_path_doc_final");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
   
            }

            if (e.CommandName.ToString() == "admin")
            {
                //////////////////ADMINISTRAR//////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_cartao.DataKeys[rowIndex].Value);
                ViewState["id_cartao"] = id;
                cartao_admin.Visible = true;             
                cartao_admin.acao = "0";
                cartao_admin.enable_num_cartao = true;
                carregar_tb(id,0);

                this.ModalPopupExtender1.Show();
            }
        }

        protected void carregar_tb(int id,int acao)
        {
            if (acao == 0)
            {
                //////////////////CARREGAR TEXTBOX NO CASO DE SER UM CRIACAO DE UM NOVO//////////////////
                BAL_cartao cartao = new BAL_cartao();
                List<PROP_cartao> lista_cartao = new List<PROP_cartao>();
                lista_cartao = cartao.get_cartao_admin_by_id(id);
                cartao_admin.psp = lista_cartao[0].parecer_psp;
                cartao_admin.d_psp = lista_cartao[0].parecer_psp_data;
                cartao_admin.sef = lista_cartao[0].perecer_sef;
                cartao_admin.d_sef = lista_cartao[0].parecer_sef_data;
                cartao_admin.outros_servicos = lista_cartao[0].parecer_outros;
                cartao_admin.d_outros_servicos = lista_cartao[0].parecer_outros_data;
                cartao_admin.num_cartao = lista_cartao[0].num_cartao;
                cartao_admin.validade_cartao = lista_cartao[0].validade_acesso;
                cartao_admin.estado = lista_cartao[0].estado;
                cartao_admin.cor = lista_cartao[0].cor;
                cartao_admin.tipo_de_cartao = lista_cartao[0].tipo_de_pedido;
                cartao_admin.conferido = lista_cartao[0].conferido;
                cartao_admin.pagamento = lista_cartao[0].pagamento;
                cartao_admin.id_cartao = lista_cartao[0].idcartao;
                cartao_admin.path_doc_final = lista_cartao[0].path_doc_final;
                cartao_admin.fotocopia_bi = lista_cartao[0].fotocopia_bi;
                cartao_admin.fotocopia_cartao_acompanhante = lista_cartao[0].fotocopia_cartao_acompanhante;
                cartao_admin.fotocopia_vinculo_laboral = lista_cartao[0].fotocopia_vinculo_laboral;
                cartao_admin.fotografia = lista_cartao[0].fotografia;
                cartao_admin.registo_criminal = lista_cartao[0].registo_criminal;
                cartao_admin.areas = lista_cartao[0].areas;
                cartao_admin.estado = lista_cartao[0].estado;
                cartao_admin.cb_portas_by_bd (lista_cartao[0].autorizacao_portas);
                cartao_admin.tb_msg_psp= lista_cartao[0].msg_psp;
                cartao_admin.tb_msg_sef= lista_cartao[0].msg_sef;
                cartao_admin.num_cartao_color = false;
                //////////////////SE O CARTAO NAO TIVER NUMERO IRA FAZER O COUNT DA DB E INCREMENTAR - SUGERINDO AO USER//////////////////
                if (lista_cartao[0].num_cartao=="")
                {               
                BAL_cartao numero = new BAL_cartao();
                int num_cartao = Convert.ToInt32(numero.numero_cartao());
                //num_cartao = num_cartao ;
                /////////////ALTERAR A COR PARA ORANGE QD NAO EXISTIR NUMERO ASSOCIADO///////////////
                cartao_admin.num_cartao = num_cartao.ToString();
                cartao_admin.num_cartao_color=true;
                }
  
            }
            if (acao == 1 || acao==2)
            {
                //////////////////CARREGAR AS TEXT BOX CASO SEJA RENOVACAO OU SEGUNDAVIA//////////////////
                BAL_cartao cartao = new BAL_cartao();
                List<PROP_cartao> lista_cartao = new List<PROP_cartao>();
                lista_cartao = cartao.get_cartao_admin_by_id(id);
                cartao_admin.psp = lista_cartao[0].parecer_psp;
                cartao_admin.d_psp = lista_cartao[0].parecer_psp_data;
                cartao_admin.sef = lista_cartao[0].perecer_sef;
                cartao_admin.d_sef = lista_cartao[0].parecer_sef_data;
                cartao_admin.outros_servicos = lista_cartao[0].parecer_outros;
                cartao_admin.d_outros_servicos = lista_cartao[0].parecer_outros_data;
                cartao_admin.num_cartao = lista_cartao[0].num_cartao;
                cartao_admin.validade_cartao = lista_cartao[0].validade_acesso;
                cartao_admin.estado = lista_cartao[0].estado;
                cartao_admin.cor = lista_cartao[0].cor;
                cartao_admin.tipo_de_cartao = lista_cartao[0].tipo_de_pedido;
                cartao_admin.conferido = lista_cartao[0].conferido;
                cartao_admin.pagamento = lista_cartao[0].pagamento;
                cartao_admin.id_cartao = lista_cartao[0].idcartao;
                cartao_admin.path_doc_final = lista_cartao[0].path_doc_final;
                cartao_admin.fotocopia_bi = lista_cartao[0].fotocopia_bi;
                cartao_admin.fotocopia_cartao_acompanhante = lista_cartao[0].fotocopia_cartao_acompanhante;
                cartao_admin.fotocopia_vinculo_laboral = lista_cartao[0].fotocopia_vinculo_laboral;
                cartao_admin.fotografia = lista_cartao[0].fotografia;
                cartao_admin.registo_criminal = lista_cartao[0].registo_criminal;
                cartao_admin.areas = lista_cartao[0].areas;   
            }
        }
      
        protected void GridView_cartao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImageButton_hide = (ImageButton)e.Row.FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                Label cartao_acompanhate = ((Label)e.Row.FindControl("lb_fotocopia_cartao_acompanhante"));
                Label registo_criminal = ((Label)e.Row.FindControl("lb_registo_criminal"));
                Label lb_fotocopia_bi = (Label)e.Row.FindControl("lb_fotocopia_bi");
                Label lb_fotocopia_vinculo_laboral = (Label)e.Row.FindControl("lb_fotocopia_vinculo_laboral");             
                Label lb_path_doc_final = (Label)e.Row.FindControl("lb_path_doc_final");

                //////////////////VERIFICA SE AS LABELS TEM VALOR NO CASO DE TEREM POE OS BOTOES DA GRIDVIEW VISIVEIS//////////////////
                if (lb_path_doc_final.Text != "")
                {
                    ImageButton path_doc_final = (ImageButton)e.Row.FindControl("path_doc_final");
                    path_doc_final.Visible = true;
                }
                if (lb_fotocopia_vinculo_laboral.Text != "")
                {
                    ImageButton fotocopia_vinculo_laboral = (ImageButton)e.Row.FindControl("fotocopia_vinculo_laboral");
                    fotocopia_vinculo_laboral.Visible = true;
                }
                if (lb_fotocopia_bi.Text != "")
                {
                    ImageButton fotocopia_bi = (ImageButton)e.Row.FindControl("fotocopia_bi");
                    fotocopia_bi.Visible = true;
                }
                
                if (cartao_acompanhate.Text != "")
                {
                    ImageButton ib_acompanhante = (ImageButton)e.Row.FindControl("fotocopia_cartao_acompanhante");
                    ib_acompanhante.Visible = true;
                }

                if (registo_criminal.Text != "")
                {
                    ImageButton ib_registo = (ImageButton)e.Row.FindControl("registo_criminal");
                    ib_registo.Visible = true;
                }
                Label label_foto = ((Label)e.Row.FindControl("lb_fotografia"));
                if (label_foto.Text != "")
                {
                    string fileName = label_foto.Text;
                    char[] separator = new char[] { '\\' };
                    string[] strSplitArr = fileName.Split(separator);
                    string caminho_foto;
                    string nome_foto;
                    caminho_foto = strSplitArr[0].ToString() + "\\" + strSplitArr[1].ToString() + "\\" + strSplitArr[2].ToString() + "\\" + strSplitArr[3].ToString() + "\\" + strSplitArr[4].ToString() + "\\";
                    nome_foto ="~/fotos" +"/" + strSplitArr[3].ToString() + "/" + strSplitArr[4].ToString() + "/" + strSplitArr[5].ToString();
                    ////////////////////////////THUMBNAILS PARA A FOTOGRAFIA NO ROOTAPP/////////////////////////////
                    ImageButton ImageButton_foto = ((ImageButton)e.Row.FindControl("ImageButton_foto"));

                    ImageButton_foto.ImageUrl = nome_foto;

                }
                Label Label1 = ((Label)e.Row.FindControl("entidade_identidade"));
                BAL_entidades entidade = new BAL_entidades();
                string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
                Label1.Text = convert;
                int ID = Convert.ToInt32(GridView_cartao.DataKeys[e.Row.RowIndex].Values[0].ToString());
                BAL_cartao cartao = new BAL_cartao();
                LinkButton segunda_via = (LinkButton)e.Row.FindControl("segunda_via");
                segunda_via.Text = cartao.numero_segunda_via_cartao(ID).ToString();
                LinkButton renovacao = (LinkButton)e.Row.FindControl("renovacao");
                renovacao.Text = cartao.numero_renovacao_cartao(ID).ToString();
                Label Label_validade = ((Label)e.Row.FindControl("validade_acesso"));
                if (Label_validade.Text != "")
                {
                    if (Convert.ToDateTime(Label_validade.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#fedad9");
                    }
                }
                GridView GridView_segunda_via = (GridView)e.Row.Cells[16].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)e.Row.Cells[17].FindControl("GridView_renovacao") as GridView;
                GridView_segunda_via.DataSource = cartao.select_segunda_via_cartao_by_idcartao(ID);
                GridView_segunda_via.DataBind();

                GridView_renovacao.DataSource = cartao.select_renovacao_cartao_by_idcartao(ID);
                GridView_renovacao.DataBind();

                if (GridView_segunda_via.Rows.Count > 0)
                {
                    ImageButton admin_segunda = GridView_segunda_via.Rows[0].FindControl("admin") as ImageButton;
                    admin_segunda.Visible = true;
                    ImageButton path_doc_final = (ImageButton)e.Row.FindControl("path_doc_final");
                    path_doc_final.Visible = false;

                }
                if (GridView_renovacao.Rows.Count > 0)
                {
                    ImageButton admin_renovacao = GridView_renovacao.Rows[0].FindControl("admin") as ImageButton;
                    admin_renovacao.Visible = true;
                    ImageButton path_doc_final = (ImageButton)e.Row.FindControl("path_doc_final");
                    path_doc_final.Visible = false;

                }
            }
        }
       
        protected void GridView_segunda_via_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
            if (e.CommandName.ToString() == "doc_final_via")
            {
                try
                {
                    ////////////////////////////DOWNLOAD DOCUMENTO FINAL DA SEGUNDA VIA/////////////////////////////
                    GridView GridView_segunda_via = (GridView)GridView_cartao.SelectedRow.Cells[17].FindControl("GridView_segunda_via") as GridView;
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    Label path = (Label)GridView_segunda_via.Rows[rowIndex].FindControl("lb_path_doc_final_via");
                    char[] separator = new char[] { '\\' };
                    string[] strSplitArr = path.Text.Split(separator);
                    Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[6].ToString() + "&FilePath=" + path.Text);
   
                }
                catch { }
            }
            if (e.CommandName.ToString() == "admin_via")
            {
                try
                {  ////////////////////////////ADMINISTRAR SEGUNDA VIA DE CARTAO/////////////////////////////
                    GridView GridView_segunda_via = (GridView)GridView_cartao.SelectedRow.Cells[17].FindControl("GridView_segunda_via") as GridView;
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int id = Convert.ToInt32(GridView_segunda_via.DataKeys[rowIndex].Value);
                    int id_cartao = Convert.ToInt32(ViewState["id_cartao"].ToString());
                    cartao_admin.Visible = true;
                    cartao_admin.id_cartao_renovacao = id;
                    carregar_tb(id_cartao, 1);
                    cartao_admin.acao = "1";
                    cartao_admin.enable_num_cartao = false;
                    BAL_cartao cartao = new BAL_cartao();
                    cartao_admin.estado = cartao.estado_segunda_via_cartao(id);
                    this.ModalPopupExtender1.Show();
                }
                catch { }
            }
        }

        protected void GridView_renovacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "fotocopia_cartao")
            {
                try
                {
                    ////////////////////////////DOWNLOAD FOTOCOPIA CARTAO/////////////////////////////
                    GridView GridView_renovacao = (GridView)GridView_cartao.SelectedRow.Cells[17].FindControl("GridView_renovacao") as GridView;
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    Label path = (Label)GridView_renovacao.Rows[rowIndex].FindControl("lb_fotocopia_cartao_identificacao");
                    char[] separator = new char[] { '\\' };
                    string[] strSplitArr = path.Text.Split(separator);
                    Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
   
                }
                catch { }
            }
            if (e.CommandName.ToString() == "doc_final_renovacao") 
            {
                try
                {
                    ////////////////////////////DOWNLOAD DOCUMENTO FINAL DE RENOVACAO/////////////////////////////
                    GridView GridView_renovacao = (GridView)GridView_cartao.SelectedRow.Cells[17].FindControl("GridView_renovacao") as GridView;
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    Label path = (Label)GridView_renovacao.Rows[rowIndex].FindControl("lb_doc_path_renovacao_cartao");
                    char[] separator = new char[] { '\\' };
                    string[] strSplitArr = path.Text.Split(separator);
                    Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[6].ToString() + "&FilePath=" + path.Text);
   
                }
                catch { }
            }
            if (e.CommandName.ToString() == "admin_renovacao")
            {
                try
                {
                    ////////////////////////////ADMINISTRACAO DE RENOVACAO/////////////////////////////
                    GridView GridView_renovacao = (GridView)GridView_cartao.SelectedRow.Cells[17].FindControl("GridView_renovacao") as GridView;
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    int id = Convert.ToInt32(GridView_renovacao.DataKeys[rowIndex].Value);
                    int id_cartao = Convert.ToInt32(ViewState["id_cartao"].ToString());
                    cartao_admin.Visible = true;
                    cartao_admin.id_cartao_renovacao = id;
                    carregar_tb(id_cartao, 2);
                    cartao_admin.acao = "2";
                    cartao_admin.enable_num_cartao = false;
                    BAL_cartao cartao = new BAL_cartao();
                    cartao_admin.estado = cartao.estado_renovacao_cartao(id);
                    this.ModalPopupExtender1.Show();
                }catch{}
            }
        }

        protected void Cancel_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~\\Admin\\gerir_cartao.aspx");
            //ModalPopupExtender1.Hide();
        }
        protected void GridView_child_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }

        protected void ImageButton_filtros_Click(object sender, ImageClickEventArgs e)
        {
            ////////////////////////////FILTROS/////////////////////////////
            if (Panel_filtros.Visible == true)
            {
                Panel_filtros.Visible = false;
                GridView_cartao.AllowPaging = true;
                carrega_cartao();
            }
            else
            {
                Panel_filtros.Visible = true;
                GridView_cartao.AllowPaging = false;
                carrega_cartao();
            }
        }

        protected void RB_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            foradeprazo();  ////////////////////////////MANTEM A COR/////////////////////////////
            if (RB_filtro.SelectedIndex == 0)
            {
                tb_pesq_num.Visible = true;
                ddl_estado.Visible = false;
                tb_nome.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton4.Visible = false;
                ImageButton3.Visible = true;
                ImageButton2.Visible = false;
                ImageButton1.Visible = false;
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                tb_nome.Visible = false;
                ib_data.Visible = true;
                tb_data.Visible = true;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton4.Visible = true;
                ImageButton3.Visible = false;
                ImageButton2.Visible = false;
                ImageButton1.Visible = false;

            }
            if (RB_filtro.SelectedIndex == 3)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = true;
                tb_nome.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton4.Visible = false;
                ImageButton3.Visible = false;
                ImageButton2.Visible = false;
                ImageButton1.Visible = true;

            }
            if (RB_filtro.SelectedIndex == 2)
            {
                tb_nome.Visible = true;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton4.Visible = false;
                ImageButton3.Visible = false;
                ImageButton2.Visible = true;
                ImageButton1.Visible = false;

            }
            if (RB_filtro.SelectedIndex == 4)
            {
                tb_nome.Visible = false;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
                ddl_entidade.Visible = true;
                ImageButton4.Visible = false;
                ImageButton3.Visible = false;
                ImageButton2.Visible = false;
                ImageButton1.Visible = false;
                carrega_entidade();
            }
        }

        protected void ib_pesq_Click(object sender, ImageClickEventArgs e)
        {
            ////////////////////////////EVENTO DE PESQUISAR FILTROS/////////////////////////////
           
            int i = 0;
            if (RB_filtro.SelectedIndex == 0)
            {
                while (i < GridView_cartao.Rows.Count)
                {
                    Label num = GridView_cartao.Rows[i].FindControl("lbnum") as Label;
                    if (num.Text == tb_pesq_num.Text)
                        GridView_cartao.Rows[i].Visible = true;
                    else
                        GridView_cartao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                while (i < GridView_cartao.Rows.Count)
                {
                    Label lbdatareg = GridView_cartao.Rows[i].FindControl("lbdatareg") as Label;
                    if (lbdatareg.Text == tb_data.Text)
                        GridView_cartao.Rows[i].Visible = true;
                    else
                        GridView_cartao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                while (i < GridView_cartao.Rows.Count)
                {
                    Label lbl_estado = GridView_cartao.Rows[i].FindControl("lbl_estado") as Label;
                    if (lbl_estado.Text == ddl_estado.SelectedValue.ToString())
                        GridView_cartao.Rows[i].Visible = true;
                    else
                        GridView_cartao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 2)
            {
                BAL_cartao cartao = new BAL_cartao();
                GridView_cartao.DataSource = cartao.filtro_cartao_by_nome(tb_nome.Text);
                GridView_cartao.DataBind();
            }
            if (RB_filtro.SelectedIndex == 4)
            {
                while (i < GridView_cartao.Rows.Count)
                {
                    Label entidade_identidade = GridView_cartao.Rows[i].FindControl("entidade_identidade") as Label;
                    if (entidade_identidade.Text == ddl_entidade.SelectedValue.ToString())
                        GridView_cartao.Rows[i].Visible = true;
                    else
                        GridView_cartao.Rows[i].Visible = false;
                    i++;
                }
            }
            foradeprazo();
        }
        public void carrega_entidade()
        {
            BAL_entidades entidade = new BAL_entidades();
            List<PROP_entidade> entidades = new List<PROP_entidade>();
            entidades = entidade.get_entidade(null);
            ddl_entidade.DataSource = entidades;
            ddl_entidade.DataTextField = "nome";
            ddl_entidade.DataBind();
            ddl_entidade.Items.Insert(0, "Selecione");
        }

        protected void GridView_cartao_DataBound(object sender, EventArgs e)
        {
            ApplyPaging();
            try
            {
                GridViewRow PagerRow = GridView_cartao.BottomPagerRow;
                Label b = (Label)PagerRow.FindControl("Label_pager_status");
                b.Text = "Página " + (GridView_cartao.PageIndex + 1) + " de " + GridView_cartao.PageCount; ;
            }
            catch { }
        }
        ////////////////////////////MANTER A COR DAS QUES ESTAO FORA DE PRAZO/////////////////////////////
        protected void foradeprazo()
        {
            foreach (GridViewRow row in GridView_cartao.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (row.FindControl("validade_acesso")!=null)
                    {
                    Label Label_validade = ((Label)row.FindControl("validade_acesso"));
                    if (Label_validade.Text != "")
                    {
                        if (Convert.ToDateTime(Label_validade.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
   
                            row.BackColor = System.Drawing.Color.FromName("#fedad9");
                        }
                    }
                    }
                }
            }
        }


    }
}