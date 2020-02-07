using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Monitoramento_De_Servicos.viewmodels;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;


namespace MgContecnicaTeste
{
    public partial class Contatos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)

        {



            try
            {

                var autenticacao = (autenticacaoViewModel)Session["autentica"];


                if (autenticacao == null)
                {



                    if (!IsPostBack)
                    {
                        Session.Remove("autentica");
                    }

                }
            }

            catch { }

        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //* Deixa visivel os campos de textos com função de inserção de dados.
        protected void Btn_Novo_Click(object sender, EventArgs e)
        {
            var autenticacao = (autenticacaoViewModel)Session["autentica"];


            Txtb_nmUsuario.Visible = true;
            Txtb_dsEmail.Visible = true;
            Txtb_dsCelular.Visible = true;
            Txtb_dsStatus.Visible = true;
            Txtb_dsPrioridade.Visible = true;


            Label_Usuario.Visible = true;
            Label_Email.Visible = true;
            Label_Celular.Visible = true;
            Label_Status.Visible = true;
            Label_Prioridade.Visible = true;


            Txtb_nmUsuario.Text = "";
            Txtb_dsEmail.Text = "";
            Txtb_dsCelular.Text = "";
            Txtb_dsStatus.Text = "ATIVO";
            Txtb_dsPrioridade.Text = "";
            Txtb_Procura.Text = "";
            Txtb_dsStatus.Visible = true;


            ///* Oculta as textbox da opção procura e exibe o botão  novo.
            Txtb_Procura.Visible = false;
            Consulta.Visible = false;
            Btn_Salvar.Visible = true;
            ///*Inicia uma sessão e dps faz uma validação do tipo bool.



        }

        protected void Btn_Procura_Click(object sender, EventArgs e)

        {
            ///* Oculta as textbox da opção novo e exibe da opção procura.

            Txtb_Procura.Visible = true;
            Txtb_nmUsuario.Visible = false;
            Txtb_dsCelular.Visible = false;
            Txtb_dsEmail.Visible = false;
            Txtb_dsStatus.Visible = false;
            Txtb_dsPrioridade.Visible = false;
            Btn_Salvar.Visible = false;
            Consulta.Visible = true;
            Label_Usuario.Visible = false;
            Label_Email.Visible = false;
            Label_Email.Visible = false;
            Label_Celular.Visible = false;
            Label_Status.Visible = false;
            Label_Prioridade.Visible = false;


        }

        private void PopulaGrid()
        {
            try
            {
                var autenticacao = (autenticacaoViewModel)Session["autentica"];
                var aut = new autenticacaoViewModel();

                DataSet ds = new DataSet();
                var cnn = string.Format("Data Source=LAPTOP-6BM5FJHM\\SQLEXPRESS; Initial Catalog=ListaDeContatosDB; Integrated Security=True;");

                string strStringcnn = cnn;
                var comando = string.Format("select * from tblContatos where nmUsuario like '{0}%' and (dsStatus = 'Ativo'  or dsStatus = 'ATIVO') order by nmUsuario", Txtb_Procura.Text);
                string strStringComando = comando;
                string strNome = Txtb_Procura.Text.ToLower();

                SqlConnection objSqlcnn = new SqlConnection(strStringcnn);
                SqlCommand objSqlComando = new SqlCommand(strStringComando, objSqlcnn);

                objSqlcnn.Open();
                if (objSqlcnn.State == ConnectionState.Open)
                {
                    DataTable dt = new DataTable();

                    SqlConnection con = new SqlConnection(cnn);
                    SqlDataAdapter adapt = new SqlDataAdapter(comando, con);
                    con.Open();
                    adapt.Fill(dt);
                    aut.table = dt;
                    Session.Add("autentica", aut);
                    if (dt.Rows.Count > 0)
                    {

                        grdShow.DataSource = dt;
                        grdShow.DataBind();

                    }

                    else
                    {

                        Response.Write("<script> alert('Não encontrado!')</script>");

                    }

                }
                objSqlcnn.Close();
                Txtb_Procura.Text = "";
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('Erro')</script>");

            }
        }

        protected void Txtb_Procura_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Consulta_Click(object sender, EventArgs e)
        {

            PopulaGrid();

        }

        protected void ConectarBanco()

        {
            try
            {

                Txtb_nmUsuario.Visible = false;
                Txtb_dsEmail.Visible = false;
                Txtb_dsCelular.Visible = false;
                Txtb_dsStatus.Visible = false;
                Txtb_dsPrioridade.Visible = false;
                Btn_Salvar.Visible = false;
                Btn_Novo.Visible = true;
                Btn_Procura.Visible = true;
                Label_Usuario.Visible = false;
                Label_Email.Visible = false;
                Label_Celular.Visible = false;
                Label_Status.Visible = false;
                Label_Prioridade.Visible = false;
                Txtb_Procura.Text = "";
                var autenticacao = (autenticacaoViewModel)Session["autentica"];
                if (autenticacao == null)
                {



                    if (!IsPostBack)
                    {

                        Session.Remove("autentica");
                    }
                    if (autenticacao != null)
                    {
                        ConectarBanco();
                        PopulaGrid();

                        var cnn = string.Format("Data Source=LAPTOP-6BM5FJHM\\SQLEXPRESS; Initial Catalog=ListaDeContatosDB; Integrated Security=True;");

                        SqlConnection conectar = new SqlConnection(cnn);
                        SqlCommand cmd = conectar.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = conectar;
                    }
                }
            }
            catch (Exception ex)
            {


            }




        }

        private void CarregarBases()
        {

            try
            {
                var cnn = string.Format("Data Source=LAPTOP-6BM5FJHM\\SQLEXPRESS; Initial Catalog=ListaDeContatosDB; Integrated Security=True;");


                SqlConnection conectar = new SqlConnection(cnn);
                try
                {
                    DataTable table = new DataTable();

                    if (conectar.State != ConnectionState.Open)
                    {
                        conectar.Open();
                    }
                    using (var cmd = conectar.CreateCommand())
                    {
                        cmd.CommandText = "select ServiceName, LastInteration from Monitoria where ServiceName like '%%'";
                        cmd.CommandType = CommandType.Text;
                        using (var dr = cmd.ExecuteReader())
                        {
                            table.Load(dr);
                        }
                    }
                    conectar.Close();


                    DataBind();
                }
                catch
                {
                    Response.Redirect("~/Monitora.aspx", false);
                }




            }
            finally { }
        }//----------------------------------------------------------------------------------------------------------------------------------------
        //* Faz a conexão ao banco selecionado no datagrid. 





        protected void Btn_Salvar_Click(object sender, EventArgs e)
        {
            var autenticacao = (autenticacaoViewModel)Session["autentica"];

            if (autenticacao.editar_campo)

            {

                try
                {

                    var cnn = string.Format("Data Source=LAPTOP-6BM5FJHM\\SQLEXPRESS; Initial Catalog=ListaDeContatosDB; Integrated Security=True;");
                    autenticacao.strcon = cnn;
                    SqlConnection conectar = new SqlConnection(cnn);
                    SqlCommand cmd = conectar.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conectar;

                    if ((Txtb_nmUsuario.Text?.Length == 0 && Txtb_dsCelular.Text?.Length == 0 && Txtb_dsEmail.Text?.Length == 0 && Txtb_dsStatus.Text == "Ativo") || (Txtb_dsStatus.Text == "ATIVO" && Txtb_dsPrioridade.Text?.Length == 0))
                    {
                        Response.Write("<script> alert('Nenhum campo teve valor inserido!')</script>");
                    }

                    if (Txtb_dsCelular.Text?.Length == 0 || Txtb_nmUsuario.Text?.Length == 0 || Txtb_dsEmail.Text?.Length == 0)

                    {

                        Response.Write("<script> alert('Informações obrigatórias não foram inseridas!')</script>");
                    }

                    if (Txtb_nmUsuario.Text != "" && Txtb_dsCelular.Text != "" && Txtb_dsEmail.Text != "" && autenticacao.editar_campo)

                    {
                        conectar.Open();
                        cmd.CommandText = "update [tblContatos] set nmUsuario=@Usuario, dsCelular=@Celular, dsEmail=@Email, dsStatus=@Status ,dsPrioridade=@Prioridade where Id = @IdUsuario";

                        cmd.Parameters.Add(new SqlParameter("@Usuario", Txtb_nmUsuario.Text));
                        cmd.Parameters.Add(new SqlParameter("@Celular", Txtb_dsCelular.Text));
                        cmd.Parameters.Add(new SqlParameter("@Email", Txtb_dsEmail.Text));
                        cmd.Parameters.Add(new SqlParameter("@Status", Txtb_dsStatus.Text));
                        cmd.Parameters.Add(new SqlParameter("@Prioridade", Txtb_dsPrioridade.Text));
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", autenticacao.idUsuario));

                        DataTable table = new DataTable();
                        cmd.ExecuteNonQuery();

                        Txtb_nmUsuario.Text = String.Empty;
                        Txtb_dsCelular.Text = String.Empty;
                        Txtb_dsEmail.Text = String.Empty;
                        Txtb_dsStatus.Text = String.Empty;
                        Txtb_dsPrioridade.Text = String.Empty;
                        Txtb_dsStatus.Text = "ATIVO";

                        Response.Write("<script> alert('Ação efetuada com sucesso!')</script>");
                        PopulaGrid();

                    }

                }
                catch (Exception ex) { Response.Write("<script> alert('Falha ao salvar!')</script>"); }

            }

            if (!autenticacao.editar_campo)

            {

                try
                {

                    var cnn = string.Format("Data Source=LAPTOP-6BM5FJHM\\SQLEXPRESS; Initial Catalog=ListaDeContatosDB; Integrated Security=True;");


                    autenticacao.strcon = cnn;
                    SqlConnection conectar = new SqlConnection(cnn);
                   
                    SqlCommand cmd = conectar.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conectar;

                    if ((Txtb_nmUsuario.Text?.Length == 0 && Txtb_dsCelular.Text?.Length == 0 && Txtb_dsEmail.Text?.Length == 0 && Txtb_dsStatus.Text == "Ativo") || (Txtb_dsStatus.Text == "ATIVO" && Txtb_dsPrioridade.Text?.Length == 0))
                    {

                    }

                    if (Txtb_dsCelular.Text?.Length == 0 || Txtb_nmUsuario.Text?.Length == 0 || Txtb_dsEmail.Text?.Length == 0)

                    {

                        Response.Write("<script> alert('Informações obrigatórias não foram inseridas!')</script>");
                    }

                    if (Txtb_nmUsuario.Text != ""
                        && Txtb_dsCelular.Text != ""
                        && Txtb_dsEmail.Text != ""
                        && !autenticacao.editar_campo)

                    {
                        conectar.Open();
                        cmd.CommandText = ("insert into  [tblContatos] (nmUsuario, dsCelular, dsEmail, dsStatus ,dsPrioridade) values(@Usuario,@Celular,@Email,@Status,@Prioridade)");

                        cmd.Parameters.Add(new SqlParameter("@Usuario", Txtb_nmUsuario.Text));
                        cmd.Parameters.Add(new SqlParameter("@Celular", Txtb_dsCelular.Text));
                        cmd.Parameters.Add(new SqlParameter("@Email", Txtb_dsEmail.Text));
                        cmd.Parameters.Add(new SqlParameter("@Status", Txtb_dsStatus.Text));
                        cmd.Parameters.Add(new SqlParameter("@Prioridade", Txtb_dsPrioridade.Text));

                        var table = new DataTable();
                        table.Load(cmd.ExecuteReader());
                        Txtb_nmUsuario.Text = String.Empty;
                        Txtb_dsCelular.Text = String.Empty;
                        Txtb_dsEmail.Text = String.Empty;
                        Txtb_dsStatus.Text = String.Empty;
                        Txtb_dsPrioridade.Text = String.Empty;
                        Txtb_dsStatus.Text = "ATIVO";

                        Response.Write("<script> alert('Ação efetuada com sucesso!')</script>");
                        PopulaGrid();

                    }

                }
                catch (Exception ex) { throw ex; }

            }
        }





        protected void grdShow_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            try
            {

                if (e.CommandName == "Editar")
                {
                    var autenticacao = (autenticacaoViewModel)Session["autentica"];

                    autenticacao.editar_campo = true;

                    Txtb_nmUsuario.Visible = true;
                    Txtb_dsEmail.Visible = true;
                    Txtb_dsCelular.Visible = true;
                    Txtb_dsStatus.Visible = true;
                    Txtb_dsPrioridade.Visible = true;

                    Label_Usuario.Visible = true;
                    Label_Email.Visible = true;
                    Label_Celular.Visible = true;
                    Label_Status.Visible = true;
                    Label_Prioridade.Visible = true;
                    Btn_Salvar.Visible = true;


                    DataSet ds = new DataSet();

                    var cnn = string.Format("Data Source=LAPTOP-6BM5FJHM\\SQLEXPRESS; Initial Catalog=ListaDeContatosDB; Integrated Security=True;");
                    SqlConnection conectar = new SqlConnection(cnn);
                    string strStringcnn = cnn;
                    SqlConnection objSqlcnn = new SqlConnection(strStringcnn);
                    conectar.Open();

                    if (conectar.State == ConnectionState.Open)
                    {
                        Txtb_nmUsuario.Text = "";
                        Txtb_dsEmail.Text = "";
                        Txtb_dsCelular.Text = "";
                        Txtb_dsStatus.Text = "";
                        Txtb_dsPrioridade.Text = "";

                        SqlCommand cmd = conectar.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        int index = Convert.ToInt32(((System.Web.UI.WebControls.GridViewRow)((System.Web.UI.Control)e.CommandSource).DataItemContainer).RowIndex);
                        GridViewRow row = grdShow.Rows[index];
                        string linhaIndex = grdShow.Rows[index].Cells[0].Text;
                        autenticacao.idUsuario = linhaIndex;
                        var procura_por_id = string.Format("select * from tblContatos where Id = '{0}'", linhaIndex);
                        cmd.CommandText = procura_por_id;
                        SqlDataReader dr = (cmd.ExecuteReader());

                        while (dr.Read())
                        {


                            Txtb_nmUsuario.Text = Convert.ToString(dr["nmUsuario"]);
                            Txtb_dsCelular.Text = Convert.ToString(dr["dsCelular"]);
                            Txtb_dsEmail.Text = Convert.ToString(dr["dsEmail"]);
                            Txtb_dsStatus.Text = Convert.ToString(dr["dsStatus"]);
                            Txtb_dsPrioridade.Text = Convert.ToString(dr["dsPrioridade"]);

                        }

                        conectar.Close();


                    }

                    autenticacao.editar_campo = true;
                }

                if (e.CommandName == "Deletar")

                {

                    var autenticacao = (autenticacaoViewModel)Session["autentica"];
                    var aut = new autenticacaoViewModel();
                    DataSet ds = new DataSet();

                    var cnn = string.Format("Data Source=LAPTOP-6BM5FJHM\\SQLEXPRESS; Initial Catalog=ListaDeContatosDB; Integrated Security=True;");
                    SqlConnection conectar = new SqlConnection(cnn);

                    int index = Convert.ToInt32(((System.Web.UI.WebControls.GridViewRow)((System.Web.UI.Control)e.CommandSource).DataItemContainer).RowIndex);
                    GridViewRow row = grdShow.Rows[index];
                    string linhaIndex = grdShow.Rows[index].Cells[0].Text;
                    aut.idUsuario = linhaIndex;

                    string strStringcnn = cnn;
                    SqlConnection objSqlcnn = new SqlConnection(strStringcnn);
                    conectar.Open();

                    if (conectar.State == ConnectionState.Open)
                    {

                        SqlCommand cmd = conectar.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "UPDATE [tblContatos] SET dsStatus = @Status WHERE Id = @Index";

                        cmd.Parameters.Add(new SqlParameter("@Index", linhaIndex));
                        cmd.Parameters.Add(new SqlParameter("@Status", "Cancelado"));

                        cmd.ExecuteNonQuery();
                        conectar.Close();
                        objSqlcnn.Close();
                        PopulaGrid();

                    }
                }
            }

            catch (Exception ex) { throw ex; }



        }

        protected void grdShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}