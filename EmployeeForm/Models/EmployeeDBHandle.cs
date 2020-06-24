using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeForm.Models
{
    public class EmployeeDBHandle
    {

        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["employeeconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW EMPLOYEE *********************
        public bool AddEmployee(EmployeeModel emodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("usp_AddNewEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", emodel.Name);
            cmd.Parameters.AddWithValue("@Age", emodel.Age);
            cmd.Parameters.AddWithValue("@Gender", emodel.Age);
            cmd.Parameters.AddWithValue("@Email", emodel.Email);
            cmd.Parameters.AddWithValue("@City", emodel.City);
            cmd.Parameters.AddWithValue("@Resume", emodel.Resume);
            cmd.Parameters.AddWithValue("@Education", emodel.Education);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW EMPLOYEE DETAILS ********************
        public List<EmployeeModel> GetEmployee()
        {
            connection();
            List<EmployeeModel> employeelist = new List<EmployeeModel>();

            SqlCommand cmd = new SqlCommand("usp_GetEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                employeelist.Add(
                    new EmployeeModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Age = Convert.ToString(dr["Age"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Email = Convert.ToString(dr["Email"]),
                        City = Convert.ToString(dr["City"]),
                        Resume = Convert.ToString(dr["Resume"]),
                        Education = Convert.ToString(dr["Education"])
                    });
            }
            return employeelist;
        }

      
    }
}
