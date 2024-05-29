using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ModelLayer.Models;
using Repository_Layer.Interfaces;

namespace Repository_Layer.Services
{
    public class DoctorRepo : IDoctorRepo
    {
        readonly SqlConnection conn = new SqlConnection();
        readonly string connString;
        readonly IConfiguration config;
        public DoctorRepo(IConfiguration configuration)
        {
            this.config = configuration;
            connString = configuration.GetConnectionString("HospitalDBConn");
            conn.ConnectionString = connString;
        }
        public bool AddDoctor(DoctorModel Dmodel)
        {
            try
            {
                conn.Open();
                SqlCommand Insertcmd = new SqlCommand("AddDoctor", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Insertcmd.Parameters.AddWithValue("@DoctorName", Dmodel.Name);
                Insertcmd.Parameters.AddWithValue("@DoctorEmail", Dmodel.Email);
                Insertcmd.Parameters.AddWithValue("@PhoneNumber", Dmodel.PhoneNumber);
                Insertcmd.Parameters.AddWithValue("@DoctorAge", Dmodel.Age);
                Insertcmd.Parameters.AddWithValue("@Gender", Dmodel.gender);
                Insertcmd.Parameters.AddWithValue("@DoctorAddress", Dmodel.Address);
                Insertcmd.Parameters.AddWithValue("@Qualification", Dmodel.Qualification);
                Insertcmd.Parameters.AddWithValue("@Specialization", Dmodel.Specialization);
                Insertcmd.Parameters.AddWithValue("@Experience",Dmodel.Experience);
                Insertcmd.Parameters.AddWithValue("@DoctorImage", Dmodel.DoctorImage);
                Insertcmd.ExecuteNonQuery();
                return true;

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

        public List<DoctorModel> GetAllDoctor()
        {
            List<DoctorModel> DoctorList = new List<DoctorModel>();
            try
            {
                conn.Open();
                SqlCommand GetList = new SqlCommand("select * from Doctor", conn);
                SqlDataReader reader = GetList.ExecuteReader();
                while (reader.Read())
                {
                    DoctorModel Doctor = new DoctorModel()
                    {
                        Id = (int)reader["DoctorId"],
                        Name = (string)reader["DoctorName"],
                        Email = (string)reader["DoctorEmail"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Age = (int)reader["DoctorAge"],
                        gender = (string)reader["Gender"],
                        Address = (string)reader["DoctorAddress"],
                        Qualification = (string)reader["Qualification"],
                        Specialization = (string)reader["Specialization"],
                        Experience = (Double)reader["Experience"],
                        DoctorImage = (string)reader["DoctorImage"],
                        IsTrash = (bool)reader["IsTrash"]
                    };

                    DoctorList.Add(Doctor);
                }
                return DoctorList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public DoctorModel GetDoctorById(int id)
        {
            try
            {
                conn.Open();
                SqlCommand GetById = new SqlCommand("GetDoctor", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                GetById.Parameters.AddWithValue("DoctorId", id);
                SqlDataReader reader = GetById.ExecuteReader();
                DoctorModel Doctor = new DoctorModel();
                if (reader.Read())
                {
                    Doctor.Id = (int)reader["DoctorId"];
                    Doctor.Name = (string)reader["DoctorName"];
                    Doctor.Email = (string)reader["DoctorEmail"];
                    Doctor.PhoneNumber = (string)reader["PhoneNumber"];
                    Doctor.Age = (int)reader["DoctorAge"];
                    Doctor.gender = (string)reader["Gender"];
                    Doctor.Address = (string)reader["DoctorAddress"];
                    Doctor.Qualification = (string)reader["Qualification"];
                    Doctor.Specialization = (string)reader["Specialization"];
                    Doctor.Experience = (Double)reader["Experience"];
                    Doctor.DoctorImage = (string)reader["DoctorImage"];
                    Doctor.IsTrash = (bool)reader["IsTrash"];
                }
                return Doctor;
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
        public bool UpdateDoctor(DoctorModel doctor)
        {
            try
            {
                SqlCommand Updatecmd = new SqlCommand("UpdateDoctor", conn)
                {
                    CommandType = CommandType.StoredProcedure 
                };
                Updatecmd.Parameters.AddWithValue("@DoctorId", doctor.Id);
                Updatecmd.Parameters.AddWithValue("@DoctorName", doctor.Name);
                Updatecmd.Parameters.AddWithValue("@DoctorEmail", doctor.Email);
                Updatecmd.Parameters.AddWithValue("@PhoneNumber", doctor.PhoneNumber);
                Updatecmd.Parameters.AddWithValue("@DoctorAge", doctor.Age);
                Updatecmd.Parameters.AddWithValue("@Gender", doctor.gender);
                Updatecmd.Parameters.AddWithValue("@DoctorAddress", doctor.Address);
                Updatecmd.Parameters.AddWithValue("@Qualification", doctor.Qualification);
                Updatecmd.Parameters.AddWithValue("@Specialization",doctor.Specialization);
                Updatecmd.Parameters.AddWithValue("@Experience", doctor.Experience);
                Updatecmd.Parameters.AddWithValue("@DoctorImage", doctor.DoctorImage);
                conn.Open();
                Updatecmd.ExecuteNonQuery();
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
        public bool DeleteDoctorById(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteDoctor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
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
    }
}
