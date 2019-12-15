using System;
using System.Diagnostics;

namespace Valerie
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = null;
            string[] Fragments = null;
            string Command = null;
            string FirstCodition = null;
            string SecondCondition = null;
            string zadnji_rezultati = null;

            int maksimalna_udaljenost = 30;
            int duzina_teksta = 0;

            if (args.Length > 0)
            {
                Fragments = args;
                Command = Fragments[0];

                Process[] ListOfProcesses = Process.GetProcesses();

                // ListProcess @regName chrome
                if (Command == "ListProcess")
                {
                    try
                    {
                        FirstCodition = Fragments[1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        FirstCodition = "";
                    }

                    try
                    {
                        SecondCondition = Fragments[2];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        SecondCondition = "";
                    }

                    if (FirstCodition == "@regName")
                    {
                        foreach (Process trenutni_proces in ListOfProcesses)
                        {
                            if (SecondCondition == trenutni_proces.ProcessName.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    trenutni_proces.ProcessName, trenutni_proces.Id));
                                // Console.WriteLine("Process: {0} {1}", trenutni_proces.ProcessName, "ID:" + trenutni_proces.Id);
                            }
                        }
                    }

                    // ListProcess @!regName chrome
                    else if (FirstCodition == "@!regName")
                    {
                        foreach (Process trenutni_proces in ListOfProcesses)
                        {
                            if (SecondCondition != trenutni_proces.ProcessName.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    trenutni_proces.ProcessName, trenutni_proces.Id));
                            }
                        }
                    }

                    else if (FirstCodition == "@regID")
                    {
                        foreach (Process CurrentProcess in ListOfProcesses)
                        {
                            if (SecondCondition.ToString() == CurrentProcess.Id.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    CurrentProcess.ProcessName, CurrentProcess.Id));
                            }
                        }
                    }
                    // ListProcess @!regID 5516
                    else if (FirstCodition == "@!regID")
                    {
                        foreach (Process trenutni_proces in ListOfProcesses)
                        {
                            if (SecondCondition.ToString() != trenutni_proces.Id.ToString())
                            {
                                Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                    trenutni_proces.ProcessName, trenutni_proces.Id));
                            }
                        }
                    }
                }

                else if (Command == "ispisi_zadnje")
                {
                    Console.WriteLine(zadnji_rezultati);
                }

                // else if (naredba == "spremi")
                // {
                //     Console.WriteLine(zadnji_rezultati);
                // }
            }

            else
            {
                while (true)
                {
                    input = Console.ReadLine();

                    if (input != null) Fragments = input.Split(' ');
                    Command = Fragments[0];

                    Process[] ListOfProcesses = Process.GetProcesses();

                    // ListProcess @regName chrome
                    if (Command == "ListProcess")
                    {
                        try
                        {
                            FirstCodition = Fragments[1];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            FirstCodition = "";
                        }

                        try
                        {
                            SecondCondition = Fragments[2];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            SecondCondition = "";
                        }

                        if (FirstCodition == "@regName")
                        {
                            foreach (Process trenutni_proces in ListOfProcesses)
                            {
                                if (SecondCondition == trenutni_proces.ProcessName.ToString())
                                {
                                    Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                        trenutni_proces.ProcessName, trenutni_proces.Id));
                                    // Console.WriteLine("Process: {0} {1}", trenutni_proces.ProcessName, "ID:" + trenutni_proces.Id);
                                }
                            }
                        }

                        // ListProcess @!regName chrome
                        else if (FirstCodition == "@!regName")
                        {
                            foreach (Process trenutni_proces in ListOfProcesses)
                            {
                                if (SecondCondition != trenutni_proces.ProcessName.ToString())
                                {
                                    Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                        trenutni_proces.ProcessName, trenutni_proces.Id));
                                }
                            }
                        }

                        else if (FirstCodition == "@regID")
                        {
                            foreach (Process CurrentProcess in ListOfProcesses)
                            {
                                if (SecondCondition.ToString() == CurrentProcess.Id.ToString())
                                {
                                    Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                        CurrentProcess.ProcessName, CurrentProcess.Id));
                                }
                            }
                        }
                        // ListProcess @!regID 5516
                        else if (FirstCodition == "@!regID")
                        {
                            foreach (Process trenutni_proces in ListOfProcesses)
                            {
                                if (SecondCondition.ToString() != trenutni_proces.Id.ToString())
                                {
                                    Console.WriteLine(String.Format("Process: {0,-60} ID: {1,-60}",
                                        trenutni_proces.ProcessName, trenutni_proces.Id));
                                }
                            }
                        }
                    }

                    else if (Command == "Kill")
                    {
                        try
                        {
                            FirstCodition = Fragments[1];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            FirstCodition = "";
                        }

                        try
                        {
                            SecondCondition = Fragments[2];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            SecondCondition = "";
                        }

                        // Kill @regName notepad
                        if (FirstCodition == "@regName")
                        {
                            int counter = 0; // counter for number of killed processes

                            foreach (Process CurrentProcess in ListOfProcesses)
                            {
                                if (SecondCondition == CurrentProcess.ProcessName.ToString())
                                {
                                    CurrentProcess.Kill();
                                    counter++;
                                }
                            }

                            if (counter == 1)
                            {
                                Console.WriteLine("Command executed successfully, {0} process killed.", counter);
                            }
                            else
                            {
                                Console.WriteLine("Command executed successfully, {0} processes killed.", counter);
                            }
                        }
                    }


                    else if (Command == "ispisi_zadnje")
                    {
                        Console.WriteLine(zadnji_rezultati);
                    }
                }

                // else if (naredba == "spremi")
                // {
                //     Console.WriteLine(zadnji_rezultati);
                // }
            }
        }
    }
}