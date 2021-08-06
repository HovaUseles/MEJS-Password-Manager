using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Password_Manager___Grundforløbsprøve
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opretter listen vi skal holde alle login dataerne med 
            List<LoginClass> loginList = new List<LoginClass> { };

            // Her har vi stien vi opretter filen i
            //string path = "D:\\Google Drive\\Skole\\ZBC - Data og Kommunikation\\Programmering\\Password Manager - Grundforløbsprøve\\Password Manager - Grundforløbsprøve\\loginList.csv";
            string path = @"loginList.csv";


            // Læser vores login fil liste
            using (StreamReader reader = new StreamReader(path))
            {
                // Bruger en while løkke til at tage tekst strengen fra filen og splitte dem om til separete strings, som vi bruger som objekt properties
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    loginList.Add(new LoginClass(Convert.ToInt32(values[0]), values[1], values[2], values[3]));
                }
            }

            // Bruger en bool til at loope alle vores "menuer" indtil brugere bryder ud af dem
            bool looper = true;            

            // Vi bruger løkker til at holde os inde i en "menu", så hvis vi skriver forkert kommer vi tilbage og kan prøve igen.
            // Her starter hovedmenu løkken
            while (looper)
            {
                Console.Clear();
                Console.WriteLine("MEJS Password Manager - Select an option.");
                Console.WriteLine("1 - Show current login list.");
                Console.WriteLine("2 - Add new login.");
                Console.WriteLine("3 - Save list and exit.");

                string userChoice = Console.ReadLine();

                //Hvis brugeren vælger Show current logins
                if (userChoice == "1") 
                {
                    // Ny løkke til Show login list menu
                    // Main Menu -> Show login list
                    while (looper)
                    {
                        Console.Clear();
                        Console.WriteLine("Displaying logins...");

                        //Bruger en foreach løkke til at vise hvert objekt i login listen
                        foreach (LoginClass p in loginList)
                        {
                            Console.WriteLine("ID: " + p.ID);
                            Console.WriteLine("Device:  " + p.device);
                            Console.WriteLine("Username: " + p.username);
                            Console.WriteLine("Password: " + p.password);
                            Console.WriteLine();

                        }

                        //Viser brugerens muligheder og afventer input
                        Console.WriteLine("1 - Edit a login.");
                        Console.WriteLine("2 - Delete a login.");
                        Console.WriteLine("Write exit to go back.");

                        string showMenuChoice = Console.ReadLine();

                        // Exit for at bryde løkken og gå tilbage
                        if (showMenuChoice.ToLower() == "exit")
                        {
                            break;
                        }

                        //Hvis brugeren vælger Edit a login
                        else if (showMenuChoice == "1")
                        {
                            //Ny løkke til edit login menuen
                            //Main Menu -> Show login -> Edit login
                            while (looper)
                            {
                                Console.Clear();

                                //Viser alle logins igen.
                                foreach (LoginClass p in loginList)
                                {
                                    Console.WriteLine("ID: " + p.ID);
                                    Console.WriteLine("Device:  " + p.device);
                                    Console.WriteLine("Username: " + p.username);
                                    Console.WriteLine("Password: " + p.password);
                                    Console.WriteLine();

                                }

                                // Nu skal brugeren vælge hvilken login der skal ændres, de skal skrive ID'et
                                Console.WriteLine("Choose which login to edit? write the ID");
                                Console.WriteLine("Write exit to go back.");
                                string editMenuChoice = Console.ReadLine();

                                // Hvis brugeren skrev exit, bryd den nuværende løkke og derved vend tilbage til den tidligere menu
                                if (editMenuChoice.ToLower() == "exit")
                                {
                                    break;
                                }

                                // Looper gennem alle objekterne indtil den finder en med det matchende ide
                                foreach (LoginClass p in loginList)
                                {
                                    try
                                    {
                                        if (Convert.ToInt32(editMenuChoice) == p.ID)
                                        {
                                            // Ny løkke til What to edit menuen
                                            // Main Menu -> Show logins -> Edit menu -> What to edit
                                            while (looper)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Choose what to edit.");
                                                Console.WriteLine();
                                                Console.WriteLine("1 - Device: (" + p.device + ")");
                                                Console.WriteLine("2 - Username: (" + p.username + ")");
                                                Console.WriteLine("3 - Password: (" + p.password + ")");
                                                Console.WriteLine("Write exit to go back.");
                                                Console.WriteLine();
                                                string editChoice = Console.ReadLine();

                                                // Ændre Device name
                                                if (editChoice == "1")
                                                {
                                                    Console.WriteLine("Write new device name.");
                                                    Console.WriteLine();
                                                    p.device = Console.ReadLine();
                                                }
                                                // Ændre Username
                                                else if (editChoice == "2")
                                                {
                                                    Console.WriteLine("Write new username name.");
                                                    Console.WriteLine();
                                                    p.username = Console.ReadLine();
                                                }
                                                // Ændre Password
                                                else if (editChoice == "3")
                                                {
                                                    Console.WriteLine("Write new password.");
                                                    Console.WriteLine();
                                                    p.password = Console.ReadLine();
                                                }
                                                // Exit for at gå tilbage
                                                else if (editChoice.ToLower() == "exit")
                                                {
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                    catch (Exception Ex)
                                    {
                                        Console.WriteLine(Ex);
                                    }
                                }
                                if (editMenuChoice.All(char.IsDigit))
                                {
                                    if (Convert.ToInt32(editMenuChoice) > loginList.Count)
                                    {
                                        Console.WriteLine("ID not on the list. Press enter to go back.");
                                        Console.ReadLine();
                                    }
                                }

                            }
                        }
                        
                        //Hvis brugeren vælger delete a login
                        else if(showMenuChoice == "2")
                        {
                            //Ny løkke til delete login menuen
                            //Main Menu -> Show login -> Delete login
                            while (looper)
                            {
                                Console.Clear();

                                // Viser alle logins
                                foreach (LoginClass p in loginList)
                                {
                                    Console.WriteLine("ID: " + p.ID);
                                    Console.WriteLine("Device:  " + p.device);
                                    Console.WriteLine("Username: " + p.username);
                                    Console.WriteLine("Password: " + p.password);
                                    Console.WriteLine();

                                }


                              
                                Console.WriteLine("Choose which login to delete. Write the ID");
                                Console.WriteLine("Write exit to go back");
                                string deleteChoice = Console.ReadLine();

                                if (deleteChoice.ToLower() == "exit")
                                {
                                    break;
                                }

                                int temp = 0;
                                // Looper igennem listen for at finde objektet med det matchende ID og gemmer index'et i en int
                                foreach (LoginClass p in loginList)
                                {
                                    if (Convert.ToInt32(deleteChoice) == p.ID)
                                    {
                                        temp = loginList.IndexOf(p);
                                    }
                                }

                                // Ny løkke til delete confirmation menuen
                                //Main Menu -> Show login -> Delete login -> Delete confirmation
                                while (looper)
                                {
                                    Console.Clear();
                                    // Spørger brugeren om de er sikre på at de vil slette login'et
                                    Console.WriteLine("Are you sure you want to delete " + loginList[temp].device + " login (yes or no)");
                                    string confirmation = Console.ReadLine();

                                    if (confirmation.ToLower() == "yes")
                                    {
                                        loginList.RemoveAt(temp);
                                        Console.WriteLine("Login deleted. Enter to continue");
                                        Console.ReadLine();

                                        // Looper igennem liste og sætter ID'erne igen så de følger talrækken
                                        foreach (LoginClass p in loginList)
                                        {
                                            p.ID = loginList.IndexOf(p) + 1;
                                        }
                                        break;

                                    }
                                  
                                }
                            }
                        }
                    }
                }

                //Hvis brugeren vælger Add new login
                else if (userChoice == "2")
                {
                    // Ny løkke til Add login menu
                    // Main Menu -> Add login
                    while (looper)
                    {
                        Console.Clear();
                       
                        Console.WriteLine("Add new login.");
                        Console.WriteLine("Write device name.");
                        Console.WriteLine("Write exit to go back");
                        Console.WriteLine();
                        string deviceInput = Console.ReadLine();
                        Console.WriteLine();

                        // exit går tilbage
                        if (deviceInput.ToLower() == "exit")
                        {
                            break;
                        }

                        Console.WriteLine("Write Username.");
                        Console.WriteLine();
                        string usernameInput = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Write password.");
                        Console.WriteLine();
                        string passwordInput = Console.ReadLine();
                        Console.WriteLine();

                        loginList.Add(new LoginClass(loginList.Count + 1, deviceInput, usernameInput, passwordInput));
                        Console.WriteLine("New login added. Press Enter to go back");
                        Console.ReadLine();
                        break;
                    }
                }

                //Hvis brugeren vælger Save and exit
                else if (userChoice == "3")
                {
                    // Udskriver til filen i CSV format
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        // Looper gennem listen og ligger dem ind i CSV format adskillet med semi-colon
                        foreach (LoginClass p in loginList)
                        {
                            tw.WriteLine("{0};{1};{2};{3}", p.ID, p.device, p.username, p.password);
                        }
                    }
                    break;

                }
            }
        }
    }
}
