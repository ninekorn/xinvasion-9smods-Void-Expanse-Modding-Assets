using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string exportedToFolderPath = "";
        public static string VEBOOSTERSFORSHOPREACTOR3DSINGLEJPGTEXTURES = "VEBOOSTERSFORSHOPREACTOR3DSINGLEJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPREACTOR3DSINGLEXML = "VEBOOSTERSFORSHOPREACTOR3DSINGLEXML";
        public static string VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG = "VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG";

        public static string VEBOOSTERSFORSHOPReactorBasicDualJPGTEXTURES = "VEBOOSTERSFORSHOPReactorBasicDualJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPReactorBasicDualXML = "VEBOOSTERSFORSHOPReactorBasicDualXML";
        public static string VEBOOSTERSFORCONTENTReactorBasicDualJPG = "VEBOOSTERSFORCONTENTReactorBasicDualJPG";

        public static string VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES = "VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPReactorBasicSingleXML = "VEBOOSTERSFORSHOPReactorBasicSingleXML";
        public static string VEBOOSTERSFORCONTENTReactorBasicSingleJPG = "VEBOOSTERSFORCONTENTReactorBasicSingleJPG";

        public static string VEBOOSTERSFORSHOPengine_ionJPGTEXTURES = "VEBOOSTERSFORSHOPengine_ionJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPengine_ionXML = "VEBOOSTERSFORSHOPengine_ionXML";
        public static string VEBOOSTERSFORCONTENTengine_ionJPG = "VEBOOSTERSFORCONTENTengine_ionJPG";

        public static string VEBOOSTERSFORSHOPengine_plasmaJPGTEXTURES = "VEBOOSTERSFORSHOPengine_plasmaJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPengine_plasmaXML = "VEBOOSTERSFORSHOPengine_plasmaXML";
        public static string VEBOOSTERSFORCONTENTengine_plasmaJPG = "VEBOOSTERSFORCONTENTengine_plasmaJPG";


        public static string VEBOOSTERSFORSHOPengine_powerbossJPGTEXTURES = "VEBOOSTERSFORSHOPengine_powerbossJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPengine_powerbossXML = "VEBOOSTERSFORSHOPengine_powerbossXML";
        public static string VEBOOSTERSFORCONTENTengine_powerbossJPG = "VEBOOSTERSFORCONTENTengine_powerbossJPG";

        public static string VEBOOSTERSFORSHOPengine_combat_thrustersadvancedJPGTEXTURES = "VEBOOSTERSFORSHOPengine_combat_thrustersadvancedJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPengine_combat_thrustersadvancedXML = "VEBOOSTERSFORSHOPengine_combat_thrustersadvancedXML";
        public static string VEBOOSTERSFORCONTENTengine_combat_thrustersadvancedJPG = "VEBOOSTERSFORCONTENTengine_combat_thrustersadvancedJPG";

        public static string VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES = "VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPengine_cruiseXML = "VEBOOSTERSFORSHOPengine_cruiseXML";
        public static string VEBOOSTERSFORCONTENTengine_cruiseJPG = "VEBOOSTERSFORCONTENTengine_cruiseJPG";


        public static string VEBOOSTERSFORSHOPengine_neutronJPGTEXTURES = "VEBOOSTERSFORSHOPengine_neutronJPGTEXTURES";
        public static string VEBOOSTERSFORSHOPengine_neutronXML = "VEBOOSTERSFORSHOPengine_neutronXML";
        public static string VEBOOSTERSFORCONTENTengine_neutronJPG = "VEBOOSTERSFORCONTENTengine_neutronJPG";

        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //https://stackoverflow.com/questions/9065598/if-a-folder-does-not-exist-create-it
            /*string subPath = "ImagesPath"; // your code goes here

            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));
            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
            */

            exportedToFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string extension = ".log";
            //filePath += @"\Error Log\" + extension;





            VEBOOSTERSFORSHOPREACTOR3DSINGLEJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPREACTOR3DSINGLEJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPREACTOR3DSINGLEJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPREACTOR3DSINGLEJPGTEXTURES);
            }

            var fi = new FileInfo(VEBOOSTERSFORSHOPREACTOR3DSINGLEJPGTEXTURES);
            fi.Refresh();


            VEBOOSTERSFORSHOPREACTOR3DSINGLEXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPREACTOR3DSINGLEXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPREACTOR3DSINGLEXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPREACTOR3DSINGLEXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPREACTOR3DSINGLEXML);
            fi.Refresh();

            /*
            VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTREACTOR3DSINGLEJPG);
            fi.Refresh();*/




      
            VEBOOSTERSFORSHOPReactorBasicDualJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPReactorBasicDualJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPReactorBasicDualJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPReactorBasicDualJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPReactorBasicDualJPGTEXTURES);
            fi.Refresh();

            //TO READD LATER
            //TO READD LATER
            //TO READD LATER
            /*VEBOOSTERSFORSHOPReactorBasicDualXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPReactorBasicDualXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPReactorBasicDualXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPReactorBasicDualXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPReactorBasicDualXML);
            fi.Refresh();

            VEBOOSTERSFORCONTENTReactorBasicDualJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTReactorBasicDualJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTReactorBasicDualJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTReactorBasicDualJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTReactorBasicDualJPG);
            fi.Refresh();*/
            //TO READD LATER
            //TO READD LATER
            //TO READD LATER




            VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPReactorBasicSingleJPGTEXTURES);
            fi.Refresh();






            VEBOOSTERSFORSHOPengine_ionJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_ionJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_ionJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_ionJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_ionJPGTEXTURES);
            fi.Refresh();

            /*VEBOOSTERSFORSHOPengine_ionXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_ionXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_ionXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_ionXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_ionXML);
            fi.Refresh();


            VEBOOSTERSFORCONTENTengine_ionJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTengine_ionJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTengine_ionJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTengine_ionJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTengine_ionJPG);
            fi.Refresh();*/
















            //engine_plasma
            VEBOOSTERSFORSHOPengine_plasmaJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_plasmaJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_plasmaJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_plasmaJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_plasmaJPGTEXTURES);
            fi.Refresh();

            /*VEBOOSTERSFORSHOPengine_plasmaXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_plasmaXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_plasmaXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_plasmaXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_plasmaXML);
            fi.Refresh();


            VEBOOSTERSFORCONTENTengine_plasmaJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTengine_plasmaJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTengine_plasmaJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTengine_plasmaJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTengine_plasmaJPG);
            fi.Refresh();*/
            //engine_plasma






            //engine_powerboss
            VEBOOSTERSFORSHOPengine_powerbossJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_powerbossJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_powerbossJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_powerbossJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_powerbossJPGTEXTURES);
            fi.Refresh();

            /*VEBOOSTERSFORSHOPengine_powerbossXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_powerbossXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_powerbossXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_powerbossXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_powerbossXML);
            fi.Refresh();


            VEBOOSTERSFORCONTENTengine_powerbossJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTengine_powerbossJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTengine_powerbossJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTengine_powerbossJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTengine_powerbossJPG);
            fi.Refresh();*/
            //engine_powerboss


















            //engine_combat_thrustersadvanced
            VEBOOSTERSFORSHOPengine_combat_thrustersadvancedJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_combat_thrustersadvancedJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_combat_thrustersadvancedJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_combat_thrustersadvancedJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_combat_thrustersadvancedJPGTEXTURES);
            fi.Refresh();

            /*VEBOOSTERSFORSHOPengine_combat_thrustersadvancedXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_combat_thrustersadvancedXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_combat_thrustersadvancedXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_combat_thrustersadvancedXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_combat_thrustersadvancedXML);
            fi.Refresh();


            VEBOOSTERSFORCONTENTengine_combat_thrustersadvancedJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTengine_combat_thrustersadvancedJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTengine_combat_thrustersadvancedJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTengine_combat_thrustersadvancedJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTengine_combat_thrustersadvancedJPG);
            fi.Refresh();*/
            //engine_combat_thrustersadvanced


















            //engine_cruise
            VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_cruiseJPGTEXTURES);
            fi.Refresh();

            /*VEBOOSTERSFORSHOPengine_cruiseXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_cruiseXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_cruiseXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_cruiseXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_cruiseXML);
            fi.Refresh();


            VEBOOSTERSFORCONTENTengine_cruiseJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTengine_cruiseJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTengine_cruiseJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTengine_cruiseJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTengine_cruiseJPG);
            fi.Refresh();*/
            //engine_cruise





            //engine_neutron
            VEBOOSTERSFORSHOPengine_neutronJPGTEXTURES = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_neutronJPGTEXTURES;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_neutronJPGTEXTURES))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_neutronJPGTEXTURES);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_neutronJPGTEXTURES);
            fi.Refresh();

            /*VEBOOSTERSFORSHOPengine_neutronXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPengine_neutronXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPengine_neutronXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPengine_neutronXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPengine_neutronXML);
            fi.Refresh();*/

            /*
            VEBOOSTERSFORCONTENTengine_neutronJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTengine_neutronJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTengine_neutronJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTengine_neutronJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTengine_neutronJPG);
            fi.Refresh();*/
            //engine_neutron










            //TO READD LATER
            //TO READD LATER
            //TO READD LATER
            /*VEBOOSTERSFORSHOPReactorBasicSingleXML = exportedToFolderPath + "\\" + VEBOOSTERSFORSHOPReactorBasicSingleXML;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORSHOPReactorBasicSingleXML))
            {
                Directory.CreateDirectory(VEBOOSTERSFORSHOPReactorBasicSingleXML);
            }

            fi = new FileInfo(VEBOOSTERSFORSHOPReactorBasicSingleXML);
            fi.Refresh();

            VEBOOSTERSFORCONTENTReactorBasicSingleJPG = exportedToFolderPath + "\\" + VEBOOSTERSFORCONTENTReactorBasicSingleJPG;// @"LAYERS\PNG\";
            if (!Directory.Exists(VEBOOSTERSFORCONTENTReactorBasicSingleJPG))
            {
                Directory.CreateDirectory(VEBOOSTERSFORCONTENTReactorBasicSingleJPG);
            }

            fi = new FileInfo(VEBOOSTERSFORCONTENTReactorBasicSingleJPG);
            fi.Refresh();*/
            //TO READD LATER
            //TO READD LATER
            //TO READD LATER









            Application.Run(new Form1());
            Console.WriteLine("consolemode started");
        }

        /*public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;*/









        /*if (args.Length > 0 && args[0] == "console")
        {
            Console.WriteLine("Hello world!");
            Console.ReadLine();
        }
        else
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }*/











        /*static class Program
        {
            /*
        DEMO CODE ONLY: In general, this approach calls for re-thinking 
        your architecture!
        There are 4 possible ways this can run:
        1) User starts application from existing cmd window, and runs in GUI mode
        2) User double clicks to start application, and runs in GUI mode
        3) User starts applicaiton from existing cmd window, and runs in command mode
        4) User double clicks to start application, and runs in command mode.

        To run in console mode, start a cmd shell and enter:
            c:\path\to\Debug\dir\WindowsApplication.exe console
            To run in gui mode,  EITHER just double click the exe, OR start it from the cmd prompt with:
            c:\path\to\Debug\dir\WindowsApplication.exe (or pass the "gui" argument).
            To start in command mode from a double click, change the default below to "console".
        In practice, I'm not even sure how the console vs gui mode distinction would be made from a
        double click...
            string mode = args.Length > 0 ? args[0] : "console"; //default to console
        

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool AllocConsole();

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool FreeConsole();

            [DllImport("kernel32", SetLastError = true)]
            static extern bool AttachConsole(int dwProcessId);

            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", SetLastError = true)]
            static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

            [STAThread]
            static void Main(string[] args)
            {
                //TODO: better handling of command args, (handle help (--help /?) etc.)
                string mode = args.Length > 0 ? args[0] : "gui"; //default to gui

                if (mode == "gui")
                {
                    MessageBox.Show("Welcome to GUI mode");

                    Application.EnableVisualStyles();

                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.Run(new Form1());
                }
                else if (mode == "console")
                {

                    //Get a pointer to the forground window.  The idea here is that
                    //IF the user is starting our application from an existing console
                    //shell, that shell will be the uppermost window.  We'll get it
                    //and attach to it
                    IntPtr ptr = GetForegroundWindow();

                    int u;

                    GetWindowThreadProcessId(ptr, out u);

                    Process process = Process.GetProcessById(u);

                    if (process.ProcessName == "cmd")    //Is the uppermost window a cmd process?
                    {
                        AttachConsole(process.Id);

                        //we have a console to attach to ..
                        Console.WriteLine("hello. It looks like you started me from an existing console.");
                    }
                    else
                    {
                        //no console AND we're in console mode ... create a new console.

                        AllocConsole();

                        Console.WriteLine(@"hello. It looks like you double clicked me to start
                   AND you want console mode.  Here's a new console.");
                        Console.WriteLine("press any key to continue ...");
                        Console.ReadLine();
                    }

                    FreeConsole();
                }
            }*/































        /*class GuiRedirect
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool AttachConsole(int dwProcessId);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetStdHandle(StandardHandle nStdHandle);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetStdHandle(StandardHandle nStdHandle, IntPtr handle);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern FileType GetFileType(IntPtr handle);

            private enum StandardHandle : uint
            {
                Input = unchecked((uint)-10),
                Output = unchecked((uint)-11),
                Error = unchecked((uint)-12)
            }

            private enum FileType : uint
            {
                Unknown = 0x0000,
                Disk = 0x0001,
                Char = 0x0002,
                Pipe = 0x0003
            }

            private static bool IsRedirected(IntPtr handle)
            {
                FileType fileType = GetFileType(handle);

                return (fileType == FileType.Disk) || (fileType == FileType.Pipe);
            }

            public static void Redirect()
            {
                if (IsRedirected(GetStdHandle(StandardHandle.Output)))
                {
                    var initialiseOut = Console.Out;
                }

                bool errorRedirected = IsRedirected(GetStdHandle(StandardHandle.Error));
                if (errorRedirected)
                {
                    var initialiseError = Console.Error;
                }

                AttachConsole(-1);

                if (!errorRedirected)
                    SetStdHandle(StandardHandle.Error, GetStdHandle(StandardHandle.Output));
            }
        }*/







        /*[STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // initialize console handles
            InitConsoleHandles();

            if (args.Length != 0)
            {

                if (args[0].Equals("waitfordebugger"))
                {
                    MessageBox.Show("Attach the debugger now");
                }
                if (args[0].Equals("version"))
                {
                    String TypeOfBuild = "";
    #if DEBUG
                    TypeOfBuild = "d";
    #else
                TypeOfBuild = "r";
    #endif
                    String output = TypeOfBuild + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    //Just for the fun of it
                    Console.Write(output);
                    Console.Beep(4000, 100);
                    Console.Beep(2000, 100);
                    Console.Beep(1000, 100);
                    Console.Beep(8000, 100);
                    return;
                }
            }
        }
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(UInt32 dwProcessId);
        [DllImport("kernel32.dll")]
        private static extern bool GetFileInformationByHandle(SafeFileHandle hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);
        [DllImport("kernel32.dll")]
        private static extern SafeFileHandle GetStdHandle(UInt32 nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern bool SetStdHandle(UInt32 nStdHandle, SafeFileHandle hHandle);
        [DllImport("kernel32.dll")]
        private static extern bool DuplicateHandle(IntPtr hSourceProcessHandle, SafeFileHandle hSourceHandle, IntPtr hTargetProcessHandle, out SafeFileHandle lpTargetHandle, UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwOptions);
        private const UInt32 ATTACH_PARENT_PROCESS = 0xFFFFFFFF;
        private const UInt32 STD_OUTPUT_HANDLE = 0xFFFFFFF5;
        private const UInt32 STD_ERROR_HANDLE = 0xFFFFFFF4;
        private const UInt32 DUPLICATE_SAME_ACCESS = 2;
        struct BY_HANDLE_FILE_INFORMATION
        {
            public UInt32 FileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
            public UInt32 VolumeSerialNumber;
            public UInt32 FileSizeHigh;
            public UInt32 FileSizeLow;
            public UInt32 NumberOfLinks;
            public UInt32 FileIndexHigh;
            public UInt32 FileIndexLow;
        }
        static void InitConsoleHandles()
        {
            SafeFileHandle hStdOut, hStdErr, hStdOutDup, hStdErrDup;
            BY_HANDLE_FILE_INFORMATION bhfi;
            hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            hStdErr = GetStdHandle(STD_ERROR_HANDLE);
            // Get current process handle
            IntPtr hProcess = Process.GetCurrentProcess().Handle;
            // Duplicate Stdout handle to save initial value
            DuplicateHandle(hProcess, hStdOut, hProcess, out hStdOutDup,
            0, true, DUPLICATE_SAME_ACCESS);
            // Duplicate Stderr handle to save initial value
            DuplicateHandle(hProcess, hStdErr, hProcess, out hStdErrDup,
            0, true, DUPLICATE_SAME_ACCESS);
            // Attach to console window – this may modify the standard handles
            AttachConsole(ATTACH_PARENT_PROCESS);
            // Adjust the standard handles
            if (GetFileInformationByHandle(GetStdHandle(STD_OUTPUT_HANDLE), out bhfi))
            {
                SetStdHandle(STD_OUTPUT_HANDLE, hStdOutDup);
            }
            else
            {
                SetStdHandle(STD_OUTPUT_HANDLE, hStdOut);
            }
            if (GetFileInformationByHandle(GetStdHandle(STD_ERROR_HANDLE), out bhfi))
            {
                SetStdHandle(STD_ERROR_HANDLE, hStdErrDup);
            }
            else
            {
                SetStdHandle(STD_ERROR_HANDLE, hStdErr);
            }
        }*/

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

    }
}
