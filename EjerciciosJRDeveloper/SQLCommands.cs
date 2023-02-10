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
        private static string rutaBDD = MyDocumentsPath + "\\Personas.sqlite";

        public static void CheckDataBaseExist()
        {
            if (!File.Exists(rutaBDD))
            {
                CreateDataBase();
                Stack<PersonaModel> personas = RegistrosBase();
                foreach (PersonaModel persona in personas)
                    InsertIntoDataBase(persona);
            }
        }

        public static SQLiteConnection GetInstance()
        {
            // Devuelve una instancia de la base de datos
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", rutaBDD)
            );

            db.Open();

            return db;
        }

        private static void CreateDataBase()
        {
            SQLiteConnection.CreateFile("Personas.sqlite");
            using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
            {
                Conexion.Open();
                SQLiteCommand cmd = Conexion.CreateCommand();

                cmd.CommandText = "CREATE TABLE Persona(IdRegistro INTEGER PRIMARY KEY AUTOINCREMENT, Nombre TEXT, Apellidos TEXT, FechaNacimiento INTEGER, FechaRegistroEnSistema TEXT)";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
        }

        public static void InsertIntoDataBase(PersonaModel persona)
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
                        "'" + persona.Nombre + "', " +
                        "'" + persona.Apellido + "', " +
                        persona.FechaNacimiento + ", " +
                        "'" + persona.FechaRegistro.ToString() + "')";
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
            }
        }

        public static Stack<PersonaModel> GetRecords()
        {
            Stack<PersonaModel> records = new Stack<PersonaModel>();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Persona";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    records.Push(CreateRecordModel(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al cargar los registros");
                throw;
            }

            return records;
        }

        public static Stack<PersonaModel> GetRecordsLike(char inicial)
        {
            Stack<PersonaModel> records = new Stack<PersonaModel>();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Persona WHERE Nombre LIKE '" + inicial + "%'";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    records.Push(CreateRecordModel(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al cargar los registros");
                throw;
            }

            return records;
        }

        private static PersonaModel CreateRecordModel(SQLiteDataReader reader)
        {
            PersonaModel persona = new PersonaModel();

            persona.IdRegistro = int.Parse(reader["IdRegistro"].ToString());
            persona.Nombre = reader["Nombre"].ToString();
            persona.Apellido = reader["Apellidos"].ToString();
            persona.FechaNacimiento = int.Parse(reader["FechaNacimiento"].ToString());
            persona.FechaRegistro = DateTime.Parse(reader["FechaRegistroEnSistema"].ToString());
            
            return persona;
        }

        public static Stack<PersonaModel> RegistrosBase()
        {
            Stack<PersonaModel> personas = new Stack<PersonaModel>();
            
            PersonaModel persona = new PersonaModel();
            persona.IdRegistro = 1;
            persona.Nombre = "Pedro";
            persona.Apellido = "Mola";
            persona.FechaNacimiento = 19791011;
            persona.FechaRegistro = DateTime.Now;
            personas.Push(persona);

            persona = new PersonaModel();
            persona.IdRegistro = 2;
            persona.Nombre = "Pablo";
            persona.Apellido = "Videgaray";
            persona.FechaNacimiento = 19750105;
            persona.FechaRegistro = DateTime.Now;
            personas.Push(persona);

            persona = new PersonaModel();
            persona.IdRegistro = 3;
            persona.Nombre = "Sonia";
            persona.Apellido = "Lopez";
            persona.FechaNacimiento = 19850306;
            persona.FechaRegistro = DateTime.Now;
            personas.Push(persona);

            persona = new PersonaModel();
            persona.IdRegistro = 4;
            persona.Nombre = "Alex";
            persona.Apellido = "Perez";
            persona.FechaNacimiento = 19800708;
            persona.FechaRegistro = DateTime.Now;
            personas.Push(persona);

            return personas;
        }
    }
}
