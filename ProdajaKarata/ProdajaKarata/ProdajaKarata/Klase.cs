using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdajaKarata
{
    class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        
        private int _status;
        public int Status
        {
            get { return _status; }
            set
            {
                if (value >= 1 && value < 4) _status = value;
                else throw new Exception("Neispavno unet status");
            }
        }
        public Osoba(string ime, string prezime, string jmbg)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.JMBG = jmbg;
            this.Status = 2; //zaposleni
        }
        public virtual string UpisiKorisnika()
        {
            return this.Status + ";" + this.JMBG + ";" + this.Ime + ";" + this.Prezime;
        }

        public override string ToString()
        {
            return this.JMBG;
        }
    }

    class Student : Osoba
    {
        public string Fax { get; set; }

        public Student(string ime, string prezime, string jmbg, string fax)
            : base(ime, prezime, jmbg)
        {
            Status = 1;
            Fax = fax;
        }
        public override string UpisiKorisnika()
        {
            return this.Status + ";" + this.JMBG + ";" + this.Ime + ";" + this.Prezime + ";" + this.Fax;
        }
    }

    //napisati
    class Zaposleni : Osoba
    {
        private double _plata;
        public double Plata
        {
            get { return this._plata; } 
            set
            {
                if (value > 0) this._plata = value;
                else throw new Exception("Neprihvatljiv unos za platu");
            }
        }
        public Zaposleni(string ime, string prezime, string jmbg, double plata)
            :base(ime, prezime, jmbg)
        {
            this.Plata = plata;
            this.Status = 2;
        }
        public override string UpisiKorisnika()
        {
            return base.UpisiKorisnika()+";"+this.Plata;
        }
    }

    class Penzioner : Osoba
    {
        private int _godina;
        public int Godina
        {
            get { return this._godina; }
            set
            {
                if (value <= DateTime.Today.Year) _godina = value;
                else throw new Exception("Nije prihvatljiv unos godine");
            }
        }
        public Penzioner(string ime, string prezime, string jmbg, int god)
            :base(ime, prezime, jmbg)
        {
            this.Godina = god;
            this.Status = 3;
        }
        public override string UpisiKorisnika()
        {
            return base.UpisiKorisnika() +";"+ this.Godina;
        }
    }

}
