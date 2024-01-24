using Entity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Data
{
    public class MedicamentoData
    {
        public List<MedicamentoEntity> getMedicamentos()
        {
            List<MedicamentoEntity> result = null;
            var lst = new List<MedicamentoEntity>();
            SqlConnection con = new SqlConnection("server=.\\SQLEXPRESS; Initial Catalog = farmacia; Integrated Security = true; TrustServerCertificate = true");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Medicamentos]", con);

            con.Open();
            da.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                result = new List<MedicamentoEntity>();
            }
            foreach(DataRow dr in dt.Rows)
            {
                var medicamento = new MedicamentoEntity();
                medicamento.IdMedicamento =Convert.ToInt32(dr["IdMedicamento"].ToString());
                medicamento.Nombre= dr["Nombre"].ToString();
                medicamento.Stock = Convert.ToInt32(dr["Stock"].ToString());
                medicamento.FechaCaducidad = Convert.ToDateTime(dr["FechaCaducidad"]);
                medicamento.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                lst.Add(medicamento);
            }
            return lst;
        }
        public bool DeleteMedicamento(int IdMedicamento)
        {
            bool result = false;
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = farmacia; Integrated Security = true; TrustServerCertificate = true");
            SqlCommand cmd = new SqlCommand("sp_DeleteMedicamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdMedicamento",IdMedicamento);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            result = true;
            return result;
        }
        public bool AddMedicamento(MedicamentoEntity medicamento)
        {
            bool result = false;
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = farmacia; Integrated Security = true; TrustServerCertificate = true");
            SqlCommand cmd = new SqlCommand("AddMedicamento", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre",medicamento.Nombre);
            cmd.Parameters.AddWithValue("@Stock", medicamento.Stock);
            cmd.Parameters.AddWithValue("@FechaCaducidad", medicamento.FechaCaducidad);
            cmd.Parameters.AddWithValue("@FechaIngreso", medicamento.FechaIngreso);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close(); 
            result = true;
            return result;
        }
        public bool UpdateMedicamento(MedicamentoEntity medicamento)
        {
            bool result = false;
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = farmacia; Integrated Security = true; TrustServerCertificate = true");
            SqlCommand cmd = new SqlCommand("sp_UpdateMedicamento", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdMedicamento",medicamento.IdMedicamento);
            cmd.Parameters.AddWithValue("@Nombre", medicamento.Nombre);
            cmd.Parameters.AddWithValue("@Stock", medicamento.Stock);
            cmd.Parameters.AddWithValue("@FechaCaducidad", medicamento.FechaCaducidad);
            cmd.Parameters.AddWithValue("@FechaIngreso", medicamento.FechaIngreso);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            result = true;
            return result;
        }
        public MedicamentoEntity getMedicamentoById(int IdMedicamento)
        {
            MedicamentoEntity result = null;
       
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = farmacia; Integrated Security = true; TrustServerCertificate = true");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Medicamentos] Where IdMedicamento = @IdMedicamento", con);
            da.SelectCommand.Parameters.AddWithValue("@IdMedicamento",IdMedicamento);

            con.Open();
            da.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                result = new MedicamentoEntity();
            }
            foreach(DataRow dr in dt.Rows)
            {
                result.IdMedicamento =Convert.ToInt32(dr["IdMedicamento"].ToString());
                result.Nombre = dr["Nombre"].ToString();
                result.Stock = Convert.ToInt32(dr["Stock"].ToString());
                result.FechaCaducidad = Convert.ToDateTime(dr["FechaCaducidad"]);
                result.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                break;
            }
            return result;
        }
    }
}
