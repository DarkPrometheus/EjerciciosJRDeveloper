using System.Data.SQLite;

namespace EjerciciosJRDeveloper
{
    public partial class Form1 : Form
    {
        private Stack<PersonaModel> personas = new Stack<PersonaModel>();
        public Form1()
        {
            InitializeComponent();
            InsertarDatosBase();
            InsertData();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtApellido.Text != "")
            {
                plTabla.Controls.Clear();

                PersonaModel persona = new PersonaModel();
                persona.IdRegistro = personas.Peek().IdRegistro + 1;
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
                persona.FechaNacimiento = ((DateTimeOffset)dtpFechaNacimiento.Value).ToUnixTimeSeconds();
                persona.FechaRegistro = DateTime.Now;
                personas.Push(persona);

                InsertData();
            }
        }

        void InsertData()
        {
            foreach (PersonaModel persona in personas)
            {
                SQLCommands.InsertIntoDataBase(persona.Nombre, persona.Apellido, persona.FechaNacimiento, persona.FechaRegistro);
                AddRow(persona.IdRegistro, persona.Nombre, persona.Apellido, persona.FechaNacimiento, persona.FechaRegistro);
            }
        }

        void AddRow(int idRegistro, string nombre, string apellido, long fechaNacimiento, DateTime fechaRegistro)
        {
            Color color = Color.FromArgb(25, 25, 25);
            TableLayoutPanel panel = new TableLayoutPanel()
            {
                BackColor = color,
                Height = 30,
                Width = plTabla.Width,
                Dock = DockStyle.Top
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)22.5));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)22.5));

            plTabla.Controls.Add(panel);

            Label lblId = new Label()
            {
                Name = "Id",
                Text = idRegistro.ToString(),
                BackColor = Color.FromArgb(20, 20, 20),
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblId, 0, 0);

            Label lblNombre = new Label()
            {
                Name = "Nombre",
                Text = nombre,
                BackColor = color,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblNombre, 1, 0);

            Label lblApellido = new Label()
            {
                Name = "Apellido",
                Text = apellido,
                BackColor = color,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblApellido, 2, 0);

            Label lblFechaNacimiento = new Label()
            {
                Name = "FechaNacimiento",
                Text = fechaNacimiento.ToString(),
                BackColor = color,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblFechaNacimiento, 3, 0);

            Label lblFechaRegistro = new Label()
            {
                Name = "FechaRegistro",
                Text = fechaRegistro.ToString(),
                BackColor = color,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblFechaRegistro, 4, 0);

            idRegistro++;
        }

        void InsertarDatosBase()
        {
            //1
            //Pedro
            //Mola
            //19791011
            //FechaYHoraActual

            //2
            //Pablo
            //Videgaray
            //19750105
            //FechaYHoraActual

            //3
            //Sonia
            //Lopez
            //19850306
            //FechaYHoraActual

            //4
            //Alex
            //Perez
            //19800708
            //FechaYHoraActual

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
        }
    }
}