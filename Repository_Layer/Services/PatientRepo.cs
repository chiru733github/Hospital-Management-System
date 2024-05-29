using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ModelLayer.Models;
using Repository_Layer.Interfaces;

namespace Repository_Layer.Services
{
    public class PatientRepo : IPatientRepo
    {
        readonly SqlConnection conn = new SqlConnection();
        readonly string connString;
        readonly IConfiguration config;
        public PatientRepo(IConfiguration configuration)
        {
            this.config = configuration;
            connString = configuration.GetConnectionString("HospitalDBConn");
            conn.ConnectionString = connString;
        }
        public bool AddPatient(PatientModel Patientmodel)
        {
            try
            {
                conn.Open();
                SqlCommand Insertcmd = new SqlCommand("AddPatient", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Insertcmd.Parameters.AddWithValue("@PatientName", Patientmodel.Name);
                Insertcmd.Parameters.AddWithValue("@PatientEmail",Patientmodel.Email);
                Insertcmd.Parameters.AddWithValue("@PhoneNumber", Patientmodel.PhoneNumber);
                Insertcmd.Parameters.AddWithValue("@PatientAge", Patientmodel.Age);
                Insertcmd.Parameters.AddWithValue("@Gender", Patientmodel.Gender);
                Insertcmd.Parameters.AddWithValue("@PatientAddress", Patientmodel.Address);
                Insertcmd.Parameters.AddWithValue("@PatientImage",Patientmodel.PatientImage);
                Insertcmd.Parameters.AddWithValue("@BloodGroup",Patientmodel.BloodGroup);
                Insertcmd.Parameters.AddWithValue("@SufferFrom", Patientmodel.SufferFrom);
                Insertcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        
        public List<PatientModel> GetAllPatient()
        {
            List<PatientModel> PatientList = new List<PatientModel>();
            try
            {
                conn.Open();
                SqlCommand GetList = new SqlCommand("AllPatientDetails", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = GetList.ExecuteReader();
                while (reader.Read())
                {
                    PatientModel Patient = new PatientModel();
                    Patient.Id = (int)reader["PatientID"];
                    Patient.Name = (string)reader["PatientName"];
                    Patient.Email = (string)reader["PatientEmail"];
                    Patient.PhoneNumber = (string)reader["PhoneNumber"];
                    Patient.Age = (int)reader["PatientAge"];
                    Patient.Gender = (string)reader["Gender"];
                    Patient.Address = (string)reader["PatientAddress"];
                    Patient.PatientImage = (string)reader["PatientImage"];
                    Patient.BloodGroup = (string)reader["BloodGroup"];
                    Patient.SufferFrom = (string)reader["SufferFrom"];
                    Patient.IsTrash = (bool)reader["IsTrash"];
                    PatientList.Add(Patient);
                }
                return PatientList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public PatientModel Login(LoginPatient Patient)
        {
            try
            {
                if (conn != null)
                {
                    conn.Open();
                    SqlCommand login = new SqlCommand("LoginPatient",conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    login.Parameters.AddWithValue("@PatientId", Patient.Id);
                    login.Parameters.AddWithValue("@PatientName", Patient.Name);
                    SqlDataReader reader = login.ExecuteReader();
                    if(reader.Read())
                    {
                        PatientModel patient = new PatientModel()
                        {
                            Id = (int)reader["PatientId"],
                            Name= (string)reader["PatientName"]
                        };
                        return patient;
                    }
                }
                return null;
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
            finally
            {
                conn.Close();
            }
        }
        public PatientModel GetPatientById(int Id)
        {
            try
            {
                conn.Open();
                SqlCommand GetById = new SqlCommand("GetPatient", conn)
                {
                    CommandType= CommandType.StoredProcedure,
                };
                GetById.Parameters.AddWithValue("@PatientID", Id);
                SqlDataReader reader = GetById.ExecuteReader();
                if(reader.Read())
                {
                    PatientModel Patient = new PatientModel();

                    Patient.Id = (int)reader["PatientID"];
                    Patient.Name = (string)reader["PatientName"];
                    Patient.Email = (string)reader["PatientEmail"];
                    Patient.PhoneNumber = (string)reader["PhoneNumber"];
                    Patient.Age = (int)reader["PatientAge"];
                    Patient.Gender = (string)reader["Gender"];
                    Patient.Address = (string)reader["PatientAddress"];
                    Patient.PatientImage = (string)reader["PatientImage"];
                    Patient.BloodGroup = (string)reader["BloodGroup"];
                    Patient.SufferFrom = (string)reader["SufferFrom"];
                    Patient.IsTrash = (bool)reader["IsTrash"];
                    return Patient;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        public bool UpdatePatient(PatientModel patient)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdatePatient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", patient.Id);
                cmd.Parameters.AddWithValue("@PatientName", patient.Name);
                cmd.Parameters.AddWithValue("@PatientEmail", patient.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                cmd.Parameters.AddWithValue("@PatientAge", patient.Age);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@PatientAddress", patient.Address);
                cmd.Parameters.AddWithValue("@PatientImage", patient.PatientImage);
                cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
                cmd.Parameters.AddWithValue("@SufferFrom", patient.SufferFrom);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool DeletePatientById(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeletePatient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }

}
