using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilterWF
{
    static class Program
    {
        public static string srcPath { get; set; } = "";

        public static string srcFilename { get; set; } = "";
        public static string srcFolder { get; set; } = "";
        
        public static string topic { get; set; } = "";

        public static string subTopic { get; set; } = "";

        public static string category { get; set; } = "";
        public static string startFilters { get;  set; } = "";
        public static string skipFilters { get;  set; } = "";
        public static string endFilters { get;  set; } = "";
        public static string categories { get; set; } = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {

                for (int i=0; i< args.Length-1; i=i+2)
                {
                    switch(args[i].ToLower())
                    {
                        case "filename":
                        case "-fn":
                            srcFilename = args[i+1];
                            srcPath = Path.Combine(srcFilename, srcFilename);
                            break;
                        case "directory":
                        case "-d":
                            srcFolder = args[i+1];
                            srcPath = Path.Combine(srcFolder, srcFilename);
                            break;
                        case "path":
                        case "-p":
                            string pth  = args[i + 1];
                            //MessageBox.Show(pth);
                            srcFilename = Path.GetFileName(pth);
                            //MessageBox.Show(srcFilename);
                            srcPath = Path.GetFullPath(srcFilename);
                            //MessageBox.Show(srcPath);
                            srcFolder = srcPath.Replace("\\"+ srcFilename,"");
                            //MessageBox.Show(srcFolder);
                            break;
                        case "topic":
                        case "-t":
                            topic = args[i+1];
                            break;
                        case "subtopic":
                        case "-st":
                            subTopic = args[i+1];
                            break;
                        case "category":
                        case "-cat":
                            category = args[i+1];
                            break;
                        case "categories":
                        case "-cats":
                            categories = args[i + 1];
                            break;
                        case "startFilter":
                        case "-sf":
                            startFilters = args[i + 1];
                            break;
                        case "skipFilter":
                        case "-skip":
                            skipFilters = args[i + 1];
                            break;
                        case "endFilter":
                        case "-ef":
                            endFilters = args[i + 1];
                            break;
                    }
                }
                Application.Run(new Form1());
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
