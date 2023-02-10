using System.Data.SQLite;

namespace EjerciciosJRDeveloper
{
    public partial class Form1 : Form
    {
        private Stack<PersonaModel> personas;
        public Form1()
        {
            InitializeComponent();
            SQLCommands.CheckDataBaseExist();
            personas = SQLCommands.GetRecords();

            FillTable();

            toolTip1.SetToolTip(btnConsultar, "Deje el campo vacio para cargar todos los registros");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
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

                SQLCommands.InsertIntoDataBase(persona);

                FillTable();
            }
            else
                lblMessage.Text = "Faltan campos por llenar";
        }

        void AddRow(PersonaModel persona)
        {
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
                Text = persona.IdRegistro.ToString(),
                BackColor = Color.FromArgb(20, 20, 20),
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblId, 0, 0);

            panel.Controls.Add(CreateLabel("Nombre", persona.Nombre), 1, 0);
            panel.Controls.Add(CreateLabel("Apellido", persona.Apellido), 2, 0);
            panel.Controls.Add(CreateLabel("FechaNacimiento", persona.FechaNacimiento.ToString()), 3, 0);
            panel.Controls.Add(CreateLabel("FechaRegistro", persona.FechaRegistro.ToString()), 4, 0);
        }

        private void FillTable()
        {
            foreach (PersonaModel personaModel in personas)
                AddRow(personaModel);
        }

        Color color = Color.FromArgb(25, 25, 25);
        Label CreateLabel(string name, string text)
        {
            Label lbl = new Label()
            {
                Name = name,
                Text = text,
                BackColor = color,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };

            return lbl;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            plTabla.Controls.Clear();
            if (txtChar.Text == "")
                personas = SQLCommands.GetRecords();
            else
            {
                personas = SQLCommands.GetRecordsLike(char.Parse(txtChar.Text));

                if (personas.Count == 0)
                    MessageBox.Show("Sin registros encontrados para la letra " + txtChar.Text, "Sin resultados");
            }
            FillTable();
        }
    }
}