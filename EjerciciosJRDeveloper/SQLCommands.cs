using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosJRDeveloper
{
    public class SQLCommands
    {
        private static string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string rutaBDD = MyDocumentsPath + "\\Personas";

        public static SQLiteConnection GetInstance()
        {
            // Devuelve una instancia de la base de datos
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", rutaBDD)
            );

            db.Open();

            return db;
        }

        public static void InsertIntoDataBase(string nombre, string apellido, long fechaNacimiento, DateTime fechaRegistro)
        {
            using (var ctx = GetInstance())
            {
                using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                {
                    Conexion.Open();
                    SQLiteCommand cmd = Conexion.CreateCommand();

                    cmd.CommandText = "INSERT INTO Persona(" +
                        "Nombre, " +
                        "Apellidos, " +
                        "FechaNacimiento, " +
                        "FechaRegistroEnSistema)" +
                        "VALUES(" +
                        "'" + nombre   + "', " +
                        "'" + apellido + "', " +
                        fechaNacimiento + ", " +
                        "'" + fechaRegistro.ToString() + "')";
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
            }
        }
    }
}
