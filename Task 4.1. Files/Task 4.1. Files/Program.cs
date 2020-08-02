using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FilesTracker.Model;
using FilesTracker.Model.Entities;

namespace FilesTracker
{

    class Program
    {
        //1 or 2
        static int SelectedMode;

        static DateTime BackToDate;

        static Settings Settings = new Settings();



        static void UI()
        {
            while (true)
            {
                Console.WriteLine("Enter tracking directory path:");

                var input = Console.ReadLine();
                if (Directory.Exists(input))
                {
                    Settings.ObservedDirectoryPath = input;
                    break;
                }
                else
                {
                    Console.WriteLine("input");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter backup directory path:");

                var input = Console.ReadLine();
                if (Directory.Exists(input))
                {
                    Settings.WorkDirectoryPath = input;
                    break;
                }
                else
                {
                    Console.WriteLine("Directory does not exist");
                }
            }




            while (true)
            {
                Console.WriteLine("Select mode:");
                Console.WriteLine("1 - Track directory");
                Console.WriteLine("2 - Go to backup");

                var input = Console.ReadLine();
                if (
                    int.TryParse(input, out SelectedMode)
                    &&
                    (
                        SelectedMode == 1
                        || SelectedMode == 2
                    )
                    )
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }

            if (SelectedMode == 2)
            {
                while (true)
                {
                    Console.WriteLine("Enter Date:");


                    var input = Console.ReadLine();
                    if (DateTime.TryParse(input, out BackToDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }
            }

        }


        static void Main(string[] args)
        {
            UI();

            using (DirectoryTrackingSystem trackSystem = new DirectoryTrackingSystem(Settings)
            {
                InActionLog = (logMsg) => Console.WriteLine(logMsg)
            })
            {
                if (SelectedMode == 1)
                {
                    trackSystem.StartListenDirectory();
                    Console.WriteLine("Press \"Enter\" to stop tracking...");
                }
                else
                {
                    trackSystem.GoToLayer(BackToDate);
                    Console.WriteLine("Rollback complete. Press \"Enter\" to exit...");
                }

                Console.ReadLine();
            }
        }
    }
}
