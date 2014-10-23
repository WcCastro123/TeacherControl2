using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace RegEstudiantes.Presentacion
{
    public partial class IniciarAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AsignaturaDropDownList.DataSource = Asignaturas.Listar("1=1", "IdAsignatura,Nombre");
                AsignaturaDropDownList.DataValueField = "IdAsignatura";
                AsignaturaDropDownList.DataTextField = "Nombre";
                AsignaturaDropDownList.DataBind();
            }
        }

        protected void IniciarButton_Click(object sender, EventArgs e)
        {
            Asistencias  Asistencia = new Asistencias();
            Asistencia.IdAsistencia  = 0;
            Asistencia.Fecha = DateTime.Now;
            Asistencia.IdAsignatura = Convert.ToInt32( AsignaturaDropDownList.SelectedValue);
            Asistencia.IdSeccion = 1;
            Asistencia.IdSemestre  = 1;

            if (Asistencia.Insertar())
            {
                Response.Redirect("PasarAsistencia.aspx?IdAsistencia=" + Asistencia.IdAsistencia.ToString());
            }
        }
    }
}