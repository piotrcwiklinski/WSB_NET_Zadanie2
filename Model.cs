using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Net_ININ3_PR1_z1
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string własnaNazwa = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(własnaNazwa));
        }

        internal void Resetuj()
        {
            Zeruj();
        }
        internal void Zeruj()
        {
            IO = "0";
            EQ = "";
            flagaPrzecinka = false;
            flagaUłamka = false;
            flagaWyniku = false;
            flagaDzialania = 0;
        }
        internal void UsuńZnak()
        {
            if (buforIO.Length == 1 || buforIO == "0," || buforIO == "-0,")
                Zeruj();
            else
            {
                char usuwanyZnak = buforIO[^1];
                IO = buforIO.Substring(0, buforIO.Length - 1);
                flagaPrzecinka = false;
                if (buforIO[^1] == ',')
                {
                    flagaUłamka = false;
                    flagaPrzecinka = true;
                }
            }
        }
        internal void DopiszCyfrę(string cyfra)
        {
            if (buforIO == "0" || flagaWyniku == true) 
            { 
                buforIO = "";
                EQ = "";
                flagaDzialania = 0;
                flagaPrzecinka = false;
                flagaUłamka = false;
                flagaWyniku = false; 
            }
            else if(flagaPrzecinka)
            {
                flagaUłamka = true;
                flagaPrzecinka = false;
            }
            IO += cyfra;
        }
        internal void ZmieńZnak()
        {
            if (buforIO == "0" || buforIO == "")
                return;
            if (buforIO[0] == '-')
            {
                IO = buforIO.Substring(1);
            }
            else
            {
                IO = "-" + buforIO;
            }
        }
        internal void Dodaj()
        {
            if (flagaDzialania == 1 && buforIO == "")
                return;
            else if (flagaDzialania == 1 && buforIO != "")
                ObliczWynik();
            else if (flagaDzialania == 0)
            {
                arg1 = float.Parse(buforIO);
                flagaWyniku = false;
                flagaDzialania = 1;
                EQ = buforIO + "+";
                buforIO = "";
                flagaUłamka = false;

            }
            else
            {
                flagaDzialania = 1;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                EQ = buforEQ + "+";
            }
        }
        internal void Odejmij()
        {
            if (flagaDzialania == 2 && buforIO == "")
                return;
            else if (flagaDzialania == 2 && buforIO != "")
                ObliczWynik();
            else if (flagaDzialania == 0)
            {
                arg1 = float.Parse(buforIO);
                flagaWyniku = false;
                flagaDzialania = 2;
                EQ = buforIO + "-";
                buforIO = "";
                flagaUłamka = false;

            }
            else
            {
                flagaDzialania = 2;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                EQ = buforEQ + "-";
            }
        }

        internal void Pomnoz()
        {
            if (flagaDzialania == 3 && buforIO == "")
                return;
            else if (flagaDzialania == 3 && buforIO != "")
                ObliczWynik();
            else if (flagaDzialania == 0)
            {
                arg1 = float.Parse(buforIO);
                flagaWyniku = false;
                flagaDzialania = 3;
                EQ = buforIO + "*";
                buforIO = "";
                flagaUłamka = false;

            }
            else
            {
                flagaDzialania = 3;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                EQ = buforEQ + "*";
            }
        }

        internal void Podziel()
        {
            if (flagaDzialania == 4 && buforIO == "")
                return;
            else if (flagaDzialania == 4 && buforIO != "")
                ObliczWynik();
            else if (flagaDzialania == 0)
            {
                arg1 = float.Parse(buforIO);
                flagaWyniku = false;
                flagaDzialania = 4;
                EQ = buforIO + "/";
                buforIO = "";
                flagaUłamka = false;

            }
            else
            {
                flagaDzialania = 4;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                EQ = buforEQ + "/";
            }
        }

        internal void DzielModulo()
        {
            if (flagaDzialania == 5 && buforIO == "")
                return;
            else if (flagaDzialania == 5 && buforIO != "")
                ObliczWynik();
            else if (flagaDzialania == 0)
            {
                arg1 = float.Parse(buforIO);
                flagaWyniku = false;
                flagaDzialania = 5;
                EQ = buforIO + "%";
                buforIO = "";
                flagaUłamka = false;

            }
            else
            {
                flagaDzialania = 5;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                EQ = buforEQ + "%";
            }
        }

        internal void Poteguj()
        {
            if (flagaDzialania == 6 && buforIO == "")
                return;
            else if (flagaDzialania == 6 && buforIO != "")
                ObliczWynik();
            else if (flagaDzialania == 0)
            {
                arg1 = float.Parse(buforIO);
                flagaWyniku = false;
                flagaDzialania = 6;
                EQ = buforIO + "(do pot.)";
                buforIO = "";
                flagaUłamka = false;

            }
            else
            {
                flagaDzialania = 6;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                EQ = buforEQ + "(do pot.)";
            }
        }

        internal void Pierwiastkuj()
        {
            if (flagaDzialania == 7 && buforIO == "")
                return;
            else if (flagaDzialania == 7 && buforIO != "")
            {
                ObliczWynik();
            }
            else if (flagaDzialania == 0)
            {
                EQ = "";
                flagaDzialania = 7;
                ObliczWynik();
            }
            else
            {
                flagaDzialania = 7;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                buforIO = buforEQ;
                ObliczWynik();
            }
        }

        internal void WezOdwrotnosc()
        {
            if (flagaDzialania == 8 && buforIO == "")
                return;
            else if (flagaDzialania == 8 && buforIO != "")
            {
                ObliczWynik();
            }
            else if (flagaDzialania == 0)
            {
                EQ = "";
                flagaDzialania = 8;
                ObliczWynik();
            }
            else
            {
                flagaDzialania = 8;
                EQ = buforEQ.Substring(0, buforEQ.Length - 1);
                buforIO = buforEQ;
                ObliczWynik();
            }
        }



        internal void ObliczWynik()
        {
            if (flagaDzialania == 0)
                return;
            else
            {
                switch (flagaDzialania)
                {
                    case 1:
                        if (buforIO != "")
                        {
                            odp = arg1 + float.Parse(buforIO);
                            EQ = EQ + buforIO + "=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;
                    
                    case 2:
                        if (buforIO != "")
                        {
                            odp = arg1 - float.Parse(buforIO);
                            EQ = EQ + buforIO + "=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;
                    
                case 3:
                    if (buforIO != "")
                        {
                            odp = arg1 * float.Parse(buforIO);
                            EQ = EQ + buforIO + "=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;
                    
                case 4:
                     if (buforIO != "")
                        {
                            odp = arg1 / float.Parse(buforIO);
                            EQ = EQ + buforIO + "=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;

                    case 5:
                        if (buforIO != "")
                        {
                            odp = arg1 % float.Parse(buforIO);
                            EQ = EQ + buforIO + "=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;

                    case 6:
                        if (buforIO != "")
                        {
                            double tempResult = Math.Pow(arg1, double.Parse(buforIO));
                            odp = (float)tempResult;
                            EQ = EQ + buforIO + "=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;

                    case 7:
                        if (buforIO != "")
                        {
                            double tempResult = Math.Sqrt(double.Parse(buforIO));
                            odp = (float)tempResult;
                            EQ = "(pierw. kw.)" + buforIO + "=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;

                    case 8:
                        if (buforIO != "")
                        {
                            odp = 1.0f / float.Parse(buforIO);
                            EQ = "(1/" + buforIO + ")=" + odp;
                            Wyniki = EQ + "\n" + buforWyniki;
                            IO = "" + odp;
                            flagaWyniku = true;
                            flagaDzialania = 0;
                        }
                        else if (buforIO == "")
                        {
                            return;
                        }
                        break;

                    default:
                        break;


                }
            }
        }

        internal void Przecinek()
        {
            if (flagaUłamka)
                return;
            else if(flagaPrzecinka)
            {
                IO = buforIO.Substring(0, buforIO.Length - 1);
                flagaPrzecinka = false;
            }
            else
            {
                IO += ",";
                flagaPrzecinka = true;
            }
        }

        bool
            flagaPrzecinka = false,
            flagaUłamka = false,
            flagaWyniku = false
            ;
        string buforIO = "0";
        string buforEQ = "";
        string buforWyniki = "";
        int flagaDzialania = 0;
        public string IO {
            get { return buforIO; }
            set
            {
                buforIO = value;
                OnPropertyChanged();
            }
        }

        public string EQ
        {
            get { return buforEQ; }
            set
            {
                buforEQ = value;
                OnPropertyChanged();
            }
        }

        public string Wyniki
        {
            get
            {
                if (buforWyniki == "") { return "Brak historii do wyświetlenia."; }
                else { return buforWyniki; }
            }
            set
            {
                buforWyniki = value;
                OnPropertyChanged();
            }
        }



        float arg1 = 0.0f;
        float odp = 0.0f;
    }
}
