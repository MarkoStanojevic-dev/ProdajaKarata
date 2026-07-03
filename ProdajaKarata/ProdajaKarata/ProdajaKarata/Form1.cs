using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProdajaKarata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("korisnici.txt");
            List<Osoba> spisak = new List<Osoba>();
            while(!sr.EndOfStream)
            {
                string red = sr.ReadLine();
                string[] podaci = red.Split(';');
                try
                {
                    if (podaci[0] == "1") spisak.Add(new Student(podaci[2], podaci[3], podaci[1], podaci[4]));
                    else if (podaci[0] == "2") spisak.Add(new Zaposleni(podaci[2], podaci[3], podaci[1], double.Parse(podaci[4])));
                    else spisak.Add(new Penzioner(podaci[2], podaci[3], podaci[1], int.Parse(podaci[4])));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sr.Close();

            foreach(Osoba x in spisak)
            {
                cbxJMBG.Items.Add(x);
            }
        }

        private void cbxJMBG_SelectedIndexChanged(object sender, EventArgs e)
        {
            Osoba x = (Osoba)cbxJMBG.SelectedItem;
            tbxIme.Text = x.Ime;
            tbxPrezime.Text = x.Prezime;
            if(x is Student)
            {
                rbStudent.Checked = true;
                tbxFax.Enabled = true;
                tbxPlata.Enabled = false;
                numGodinaPenzionisanja.Enabled = false;
                tbxFax.Text = ((Student)x).Fax;
            }
            else if(x is Zaposleni)
            {
                rbZaposleni.Checked = true;
                tbxFax.Enabled = false;
                tbxPlata.Enabled = true;
                numGodinaPenzionisanja.Enabled = false;
                tbxPlata.Text = ((Zaposleni)x).Plata.ToString();
            }
            else
            {
                rbPenzioner.Checked = true;
                tbxFax.Enabled = false;
                tbxPlata.Enabled = false;
                numGodinaPenzionisanja.Enabled = true;
                numGodinaPenzionisanja.Value = ((Penzioner)x).Godina;
            }
        }

        private void btnProdaj_Click(object sender, EventArgs e)
        {

        }
    }
}
