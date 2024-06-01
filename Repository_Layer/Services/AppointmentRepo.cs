using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ModelLayer.Models;
using Repository_Layer.Interfaces;
using System.Reflection;
using System.Net;

namespace Repository_Layer.Services
{
    public class AppointmentRepo : IAppointmentRepo
    {
        readonly SqlConnection conn = new SqlConnection();
        readonly string connString;
        readonly IConfiguration config;
        public AppointmentRepo(IConfiguration configuration)
        {
            this.config = configuration;
            connString = configuration.GetConnectionString("HospitalDBConn");
            conn.ConnectionString = connString;
        }
        public bool AddAppointment(AppointmentModel AMmodel)
        {
            try
            {
                if (conn != null)
                {
                    SqlCommand Insertcmd = new SqlCommand("AddAppointment", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    Insertcmd.Parameters.AddWithValue("@DoctorId", AMmodel.Doctorid);
                    Insertcmd.Parameters.AddWithValue("@PatientId", AMmodel.Patientid);
                    Insertcmd.Parameters.AddWithValue("@AppointmentDate", AMmodel.date);
                    Insertcmd.Parameters.AddWithValue("@StartTime", AMmodel.Starttime);
                    Insertcmd.Parameters.AddWithValue("@EndTime", AMmodel.Endtime);
                    Insertcmd.Parameters.AddWithValue("@Concern", AMmodel.concern);
                    conn.Open();
                    Insertcmd.ExecuteNonQuery();
                    return true;
                }
                return false;
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

        public List<AppointmentModel> GetAllAppointment()
        {
            List<AppointmentModel> AMlist = new List<AppointmentModel>();
            try
            {
                if (conn != null)
                {
                    conn.Open();
                    SqlCommand GetList = new SqlCommand("AllAppointmentDetails", conn);
                    SqlDataReader reader = GetList.ExecuteReader();
                    while (reader.Read())
                    {
                        AppointmentModel appointment = new AppointmentModel()
                        {
                            AMId = (int)reader["AppointmentId"],
                            Doctorid = (int)reader["DoctorFkId"],
                            Patientid = (int)reader["PatientFkId"],
                            date = (DateTime)reader["AppointmentDate"],
                            Starttime = Convert.ToDateTime(reader["StartTime"].ToString()),
                            Endtime = Convert.ToDateTime(reader["EndTime"].ToString()),
                            concern = (string)reader["concern"]
                        };

                        AMlist.Add(appointment);
                    }
                    return AMlist;
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
        public List<DoctorWithPatient> GetDoctorWithPatients()
        {
            List<DoctorWithPatient> DWPlist = new List<DoctorWithPatient>();
            try
            {
                if (conn != null)
                {
                    conn.Open();
                    SqlCommand GetList = new SqlCommand("getDoctorwithPatientDetails", conn);
                    SqlDataReader reader = GetList.ExecuteReader();
                    while (reader.Read())
                    {
                        DoctorWithPatient appointment = new DoctorWithPatient()
                        {
                            DoctorName = (string)reader["DoctorNames"],
                            DoctorImage = (string)reader["DoctorImages"],
                            PatientId = (int)reader["PatientID"],
                            PatientName = (string)reader["PatientName"],
                            PatientEmail = (string)reader["PatientEmail"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            PatientAge = (int)reader["PatientAge"],
                            Gender = (string)reader["Gender"],
                            Address = (string)reader["PatientAddress"],
                            PatientImage = (string)reader["PatientImage"],
                            BloodGroup = (string)reader["BloodGroup"],
                            Concern = (string)reader["Concern"]
                        };

                        DWPlist.Add(appointment);
                    }
                    return DWPlist;
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
    }
}
