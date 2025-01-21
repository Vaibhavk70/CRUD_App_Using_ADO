using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD_App_Using_ADO.Models
{
    public class EmployeeDBContext
    {
        public string CS = ConfigurationManager.ConnectionStrings["EMP_DB"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> EmployeesList = new List<Employee>();
            SqlConnection Con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("SpGetEmployee", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            Con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())

            {
                Employee emp = new Employee();
                emp.ID = Convert.ToInt32 (dr.GetValue(0).ToString());
                emp.Fname = dr.GetValue(1).ToString();
                emp.Lname = dr.GetValue(2).ToString();
                emp.Salary = Convert.ToInt32(dr.GetValue(3).ToString());
                emp.Dept = dr.GetValue(4).ToString();
                emp.City = dr.GetValue(5).ToString();

                EmployeesList.Add(emp);
            }

            Con.Close();

            return EmployeesList;
        }

        public bool AddEmployee(Employee emp)
        {
            SqlConnection Con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("spAddEmployee", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fname", emp.Fname);
            cmd.Parameters.AddWithValue("@Lname", emp.Lname);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@Dept", emp.Dept);
            cmd.Parameters.AddWithValue("@City", emp.City);
            Con.Open();

            int i = cmd.ExecuteNonQuery();

            Con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee emp)
        {
            SqlConnection Con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", emp.ID);
            cmd.Parameters.AddWithValue("@Fname", emp.Fname);
            cmd.Parameters.AddWithValue("@Lname", emp.Lname);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@Dept", emp.Dept);
            cmd.Parameters.AddWithValue("@City", emp.City);
            Con.Open();

            int i = cmd.ExecuteNonQuery();

            Con.Close();
            if (i > 0)
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