using Modelo;
using Modelo.ViewModel;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LogicaAccesoDatos
{
    public class EmpleadoDAL
    {
        public string Guardar(Empleado empleado)
        {
            try
            {
                using(var con = DbCommun.Conectar())
                {
                    var query = "sp_GuardarEmpleado";
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CargoId", empleado.CargoId);
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre.ToUpper());
                    command.Parameters.AddWithValue("@Apellido", empleado.Apellido.ToUpper());
                    command.Parameters.AddWithValue("@Edad", empleado.Edad);
                    command.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                    if (command.ExecuteNonQuery() > 0)
                        return "Ok";
                    else
                        return "error";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string Modificar(Empleado empleado)
        {
            try
            {
                using (var con = DbCommun.Conectar())
                {
                    var query = "sp_ModificarEmpleado";
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpleadoId", empleado.EmpleadoId);
                    command.Parameters.AddWithValue("@CargoId", empleado.CargoId);
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre.ToUpper());
                    command.Parameters.AddWithValue("@Apellido", empleado.Apellido.ToUpper());
                    command.Parameters.AddWithValue("@Edad", empleado.Edad);
                    command.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                    if (command.ExecuteNonQuery() > 0)
                        return "Ok";
                    else
                        return "error";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }
        public string Eliminar(Int64 id)
        {
            try
            {
                using (var con = DbCommun.Conectar())
                {
                    var query = "sp_EliminarEmpleado";
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpleadoId", id);
                    if (command.ExecuteNonQuery() > 0)
                        return "Ok";
                    else
                        return "error";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }
        public IEnumerable<EmpleadoVM> ListarEmpleado(string Filtro)
        {
            List<EmpleadoVM> lst = new List<EmpleadoVM>();
            try
            {
                using (var con = DbCommun.Conectar())
                {
                    string query = "sp_ListarEmpleados";
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@filtro", Filtro);
                    IDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lst.Add(new EmpleadoVM
                        {
                            EmpleadoId = reader.GetInt64(0),
                            CargoId = reader.GetInt64(1),
                            NombreCargo = CargoDAL.ObtenerNombreCargo(reader.GetInt64(1)),
                            NombreCompleto = reader.GetString(2) + " " + reader.GetString(3),
                            Edad = reader.GetInt32(4),
                            FechaNacimiento = reader.GetDateTime(5).ToShortDateString()
                        });
                    }
                }
            }
            catch (Exception e)
            {
                lst.Add(new EmpleadoVM { NombreCargo = e.Message });
            }
            return lst;
        }
        public Empleado EmpleadoPorId(Int64 id)
        {
            try
            {
                using (var con = DbCommun.Conectar())
                {
                    var query = "sp_ObtenerPorId";
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpleadoId", id);
                    IDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Empleado
                        {
                            EmpleadoId = reader.GetInt64(0),
                            CargoId = reader.GetInt64(1),
                            Nombre = reader.GetString(2),
                            Apellido=reader.GetString(3),
                            Edad = reader.GetInt32(4),
                            FechaNacimiento = reader.GetDateTime(5)
                        };
                    }
                    else return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
