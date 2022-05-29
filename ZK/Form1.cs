using ZKSoftwareAPI;
namespace ZK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ZKSoftware dispositivo = new ZKSoftware(Modelo.X628C);
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Desconectar")
            {
                button1.Text = "Conectar";
                dispositivo.DispositivoDesconectar();
                return;

            }
            if (!dispositivo.DispositivoConectar("192.168.17.16", 3, true))
            {
                MessageBox.Show(dispositivo.ERROR);
            }
            else
            {
                button1.Text = "Desconectar";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buscar usuarios del dispositivos
            if (dispositivo.UsuarioBuscarTodos(true))
            {
                comboBox1.DataSource = dispositivo.ListaUsuarios;
            }
            else
            {
                MessageBox.Show(dispositivo.ERROR);

            }
            //consultar total de huellas registradas
            dispositivo.DispositivoConsultar(NumeroDe.HuellasRegistradas);
            lblHuellas.Text = dispositivo.ResultadoConsulta.ToString();

            //consultar total de marcajes de asistencias
            dispositivo.DispositivoConsultar(NumeroDe.RegistrosDeAsistencias);
            lblAsistencias.Text = dispositivo.ResultadoConsulta.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Desabilitar.Text == "Desabilitar")
            {
                Desabilitar.Text = "Habilitar";
                dispositivo.DispositivoCambiarEstatus(Estatus.Deshabilitar);
            }
            else
            {
                Desabilitar.Text = "Habilitar";
                dispositivo.DispositivoCambiarEstatus(Estatus.Habilitar);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dispositivo.DispositivoObtenerRegistrosAsistencias();
            listBox1.DataSource = dispositivo.ListaMarcajes;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dispositivo.DispositivoObtenerRegistrosOperativos();
            listBox2.DataSource = dispositivo.ListaMarcajes;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}