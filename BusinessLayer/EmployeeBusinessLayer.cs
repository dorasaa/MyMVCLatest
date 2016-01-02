using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

using System.Data.SqlClient;

namespace BusinessLayer
{

    //All business logic
    public class EmployeeBusinessLayer
    {
        //this property is returning collection of employees (in terms if employee object)
        public IEnumerable<Employee> employees
        {
            get
            {
                string connectionString =
                           ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                List<Employee> employees = new List<Employee>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.id = Convert.ToInt32(rdr["employeeid"]);
                        employee.name = rdr["name"].ToString();
                        employee.gender = rdr["gender"].ToString();
                        employee.city = rdr["city"].ToString();
                        employee.deptid = Convert.ToInt32(rdr["deptid"]);

                        employees.Add(employee);
                    }
                }

                return employees;

            }


        }

        public void AddEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.city;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDeptId = new SqlParameter();
                paramDeptId.ParameterName = "@deptid";
                paramDeptId.Value = employee.deptid;
                cmd.Parameters.Add(paramDeptId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void UpdateEmployee(Employee emp)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sqlUpdate = "update tblemployee set name='" + emp.name + "', gender='" + emp.gender + "', city='" +
                                        emp.city + "', deptid=" + emp.deptid + " where employeeid=" + emp.id;

                    SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();


                }

            }
            catch (Exception ex)
            {

                throw ex;

            }


        }

        public void Delete(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sqlUpdate = "delete from tblemployee where employeeid=" + id;

                    SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();


                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}

