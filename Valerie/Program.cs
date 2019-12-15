using System;
using System.Diagnostics;

namespace Valerie
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string ulaz = null;
            string[] dijelovi = null;
            string naredba = null;
            string prvi_uvjet = null;
            string drugi_uvjet = null;
            string zadnji_rezultati = null;

            int maksimalna_udaljenost = 30;
            int duzina_teksta = 0;

            while (true)
            {
                ulaz = Console.ReadLine();

                dijelovi = ulaz.Split(' ');
                naredba = dijelovi[0];

                Process[] popis_procesa = Process.GetProcesses();

                // ispisi_procese @regName chrome
                if (naredba == "ispisi_procese")
                {
                    try
                    {
                        prvi_uvjet = dijelovi[1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        prvi_uvjet = "";
                    }

                    try
                    {
                        drugi_uvjet = dijelovi[2];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        drugi_uvjet = "";
                    }

                    if (prvi_uvjet == "@regName")
                    {
                        foreach (Process trenutni_proces in popis_procesa)
                        {
                            if (drugi_uvjet == trenutni_proces.ProcessName.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    trenutni_proces.ProcessName, trenutni_proces.Id));
                                // Console.WriteLine("Process: {0} {1}", trenutni_proces.ProcessName, "ID:" + trenutni_proces.Id);
                            }
                        }
                    }

                    // ispisi_procese @!regName chrome
                    else if (prvi_uvjet == "@!regName")
                    {
                        foreach (Process trenutni_proces in popis_procesa)
                        {
                            if (drugi_uvjet != trenutni_proces.ProcessName.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    trenutni_proces.ProcessName, trenutni_proces.Id));
                            }
                        }
                    }

                    else if (prvi_uvjet == "@regID")
                    {
                        foreach (Process trenutni_proces in popis_procesa)
                        {
                            if (drugi_uvjet.ToString() == trenutni_proces.Id.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    trenutni_proces.ProcessName, trenutni_proces.Id));
                            }
                        }
                    }
                    // ispisi_procese @!regID 5516
                    else if (prvi_uvjet == "@!regID")
                    {
                        foreach (Process trenutni_proces in popis_procesa)
                        {
                            if (drugi_uvjet.ToString() != trenutni_proces.Id.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    trenutni_proces.ProcessName, trenutni_proces.Id));
                            }
                        }
                    }
                }

                else if (naredba == "ispisi_zadnje")
                {
                    Console.WriteLine(zadnji_rezultati);
                }

                // else if (naredba == "spremi")
                // {
                //     Console.WriteLine(zadnji_rezultati);
                // }
            }
        }
    }
}