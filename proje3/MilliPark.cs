using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje3
{
    class MilliPark
    {
        private string ad;
        public string Ad
        {
            get { return ad; }
        }
        private string il;
        public string Il
        {
            get { return il; }
        }
        private string ilan;
        public string Ilan
        {
            get { return ilan; }
        }
        private int yuzolcumu;
        public int Yuzolcumu
        {
            get { return yuzolcumu; }
        }
        public string bilgiler;
        public string Bilgiler
        {
            get { return bilgiler; }
        }
        public string[] bilgi;
        public string[] Bilgi
        {
            get { return bilgi; }
        }
        

        public MilliPark(string ad, string il, int yuzolcumu, string ilan, string bilgiler)
        {
            this.ad = ad;
            this.il = il;
            this.ilan = ilan;
            this.yuzolcumu = yuzolcumu;
            this.bilgiler = bilgiler;
            bilgi = bilgiler.Split(new string[] { "'"," ",". ",",","(",")","-","\""}, StringSplitOptions.RemoveEmptyEntries);
        }
        public override string ToString()
        {
            return "Milli Parkın adı: " + ad + "\nBulunduğu il: " + il + "\nİlan yılı: " + ilan + "\nYüzölçümü: " + yuzolcumu + " hektar\n" +"Bilgi: "+bilgiler+"\n";
        }
    }
}
