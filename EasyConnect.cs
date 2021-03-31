using EasyConnect.easyconnectClasses;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace EasyConnect
{

    public partial class EasyConnect : Form
    {
        public EasyConnect()
        {
            InitializeComponent();
        }
        ConnectClass c = new ConnectClass();
        private void EasyConnect_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dataGridViewContactList.DataSource = dt;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Pobierz wartość z pola wejściowego
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNumber.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = comboBoxGender.Text;

            bool success = c.Insert(c);
            if(success==true)
            {
                MessageBox.Show("Nowy kontakt został pomyślnie wprowadzony.");
                Clear();
            }
            else
            {
                MessageBox.Show("Błąd w dodawaniu nowego kontaktu. Spróbuj ponownie.");
            }

            DataTable dt = c.Select();
            dataGridViewContactList.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metoda do czyszczenia danych po lewej stronie
        public void Clear()
        {
            textBoxContactID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxContactNumber.Text = "";
            textBoxAddress.Text = "";
            comboBoxGender.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(textBoxContactID.Text);
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNumber.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = comboBoxGender.Text;

            bool success = c.Update(c);
            if(success == true)
            {
                MessageBox.Show("Kontakt został pomyślnie zaktualizowany.");
                DataTable dt = c.Select();
                dataGridViewContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Błąd w aktualizacji kontaktu. Spróbuj ponownie.");
            }

        }

        private void dataGridViewContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxContactID.Text = dataGridViewContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridViewContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxContactNumber.Text = dataGridViewContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxAddress.Text = dataGridViewContactList.Rows[rowIndex].Cells[4].Value.ToString();
            comboBoxGender.Text = dataGridViewContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            //Wywołaj metode czyszczenia
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(textBoxContactID.Text);
            bool success = c.Delete(c);
            if(success==true)
            {
                MessageBox.Show("Kontakt został pomyślnie usunięty.");
                DataTable dt = c.Select();
                dataGridViewContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Błąd w usuwaniu kontaktu. Spróbuj ponownie.");
            }
        }

        static string myconnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public object DragGable { get; private set; }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;

            SqlConnection conn = new SqlConnection(myconnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Table_Contact WHERE FirstName LIKE '%" + keyword + "%' OR LastName LIKE '%" + keyword + "%' OR Address LIKE '%" + keyword + "%'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewContactList.DataSource = dt;
        }

        bool mouseDown;
        private Point offset;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
