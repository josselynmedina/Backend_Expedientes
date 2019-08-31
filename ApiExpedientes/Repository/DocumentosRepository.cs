using ApiExpedientes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiExpedientes.Repository
{
    public class DocumentosRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ProcesoLogisticoEntities"].ToString();
            con = new SqlConnection(constr);
        }

        public bool AddDocumentos(Documento obj)
        {
            connection();
            SqlCommand conm = new SqlCommand("SP_DOCUMENTO_CREATE", con);
            conm.CommandType = CommandType.StoredProcedure;
            conm.Parameters.AddWithValue("@Documento", obj.Documento1);
            //conm.Parameters.AddWithValue("@CreatedDate", DateTime.Today);
            //conm.Parameters.AddWithValue("@ModifiedDate", DateTime.Today);
            //conm.Parameters.AddWithValue("@CreatedBy", 1);
            //conm.Parameters.AddWithValue("@ModifiedBy", 1);

            con.Open();
            int i = conm.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}