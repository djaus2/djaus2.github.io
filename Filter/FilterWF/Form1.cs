using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilterWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filename = "";

        private void button1_Click(object sender, EventArgs e)
        {
            filename = "";
            textBox1.Text = "";
            //textBox2.Text = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select Markdown file to filter";
            fdlg.InitialDirectory = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
               "");
            if (textBox2.Text != "")
                fdlg.InitialDirectory = textBox2.Text;
            // fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Markdown (*.md)|*.md|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                filename = fdlg.FileName;
                textBox1.Text = Path.GetFileName(filename);
                textBox2.Text = Path.GetFullPath(filename);

                Output("__CLEAR__");
                StreamReader sr = File.OpenText(filename);
                Output(sr.ReadToEnd());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] args = new string[] { textBox4.Text, textBox3.Text, textBox5.Text };
            Main(args);
        }

        private void Main(string[] args)
        {
            List<string> lineToStartAfter = new List<string>();
            bool started = true;
            List<string> linesToSkipStartingWith = new List<string>();
            List<string> linesToSkipContaining = new List<string>();
            List<string> lineToStopAt = new List<string>();

            Output("__CLEAR__");

            if (args[1].ToLower() == "help")
            {
                Output("Usage: filter [LinesToSkip] [LinesContainingToStartAt] [LinesContainingToStopAt]");
                Output("[..] are optional args.");
                Output("The second arg requires the first arg to be present");
                Output("The third arg requires the first and second args to be present");
                Output("args are either single item or a comma separated list");
                Output("Single filter lists have @ as prefix");
                Output("If any spaces, arg should be in double quotes. (Whole arg not individual, comma sperated items.)");
                Output("LinesToSkip:              + or no prefix: Any line STARTING with one of these filters is skipped.");
                Output("                          + prefix is optional for lines starting with filters.");
                Output("                          Alternative is any filter with - prefix ");
                Output("                          - prefix: Any line CONTAINING that filter is skipped.");
                Output("LinesContainingToStartAt: Lines at start are skipped until first line after line containing one of these filters.");
                Output("LinesContainingToStopAt:  Lines at end are skipped from first line (that line inluded) containing one of these filters.");
                return;
            }
            if (args.Length > 0)
            {
                if (args[0].Length > 0)
                {
                    if (args[0][0] == '@')
                    {
                        // If string starts with @ then use whole argumenet as one (can therefore have a comma)
                        linesToSkipStartingWith = new List<string> { args[0].Substring(1) };
                    }
                    linesToSkipStartingWith = (args[0].Split(new char[] { ',' })).ToList();
                }
            }



            linesToSkipContaining = (from f in linesToSkipStartingWith where f[0] == '-' select f).ToList();
            linesToSkipStartingWith = (from f in linesToSkipStartingWith where f[0] != '-' select f).ToList();
            for (int i = 0; i < linesToSkipStartingWith.Count(); i++)
                if (linesToSkipStartingWith[i][0] == '+')
                    linesToSkipStartingWith[i] = linesToSkipStartingWith[i].Substring(1);

            if (args.Length > 1)
            {
                if (args[1].Length > 0)
                {
                    if (args[1][0] == '@')
                    {
                        // If string starts with @ then use whole argumenet as one (can therefore have a comma)
                        lineToStartAfter = new List<string> { args[1].Substring(1) };
                    }
                    lineToStartAfter = (args[1].Split(new char[] { ',' })).ToList();
                }
            }
            if (lineToStartAfter.Count() > 0)
                started = false;

            if (args.Length > 2)
            {
                if (args[2].Length > 0)
                {
                    if (args[2][0] == '@')
                    {
                        // If string starts with @ then use whole argumenet as one (can therefore have a comma)
                        lineToStopAt = new List<string> { args[2].Substring(1) };
                    }
                    lineToStopAt = (args[2].Split(new char[] { ',' })).ToList();
                }
            }


            if (File.Exists(filename))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
            {
                int skipstart = 0;
                bool stop = false;
                if (!int.TryParse(textBox6.Text, out skipstart))
                {
                    skipstart = 0;
                }
                StreamReader sr = File.OpenText(filename);
                string line;
                while (((line = sr.ReadLine()) != null) && (!stop))
                {
                    if (skipstart-- > 0)
                    {
                        Output(line);
                        continue;
                    }

                    //Skip lines until
                    if (!started)
                    {
                        foreach (var f in lineToStartAfter)
                            if (line.Length >= f.Length)
                                if (line.ToLower().Contains(f.ToLower()))
                                {
                                    started = true;
                                    break;
                                }
                        if (!started)
                            continue;
                    }

                    bool skip = false;
                    //Lines to filter out starting with filter
                    foreach (var f in linesToSkipStartingWith)
                        if (line.Length >= f.Length)
                            if (line.ToLower().Substring(0, f.Length) == f.ToLower())
                            {
                                skip = true;
                                break;
                            }
                    if (skip)
                        continue;

                    skip = false;
                    //Lines to filter out containing filter
                    foreach (var f in linesToSkipContaining)
                        if (line.Length >= f.Length)
                            if (line.ToLower().Contains(f.ToLower()))
                            {
                                skip = true;
                                break;
                            }
                    if (skip)
                        continue;

                    //stopNow asserts skip finishing line
                    bool stopNow = false;
                    //Line to stop at
                    foreach (var f in lineToStopAt)
                        if (line.Length >= f.Length)
                        { 
                
                            if (line.ToLower().Contains(f.ToLower()))
                            {
                                stop = true;
                                break;
                            }
                            else
                            {
                                string subf = f.Substring(1);
                                if ((f[0]=='-') && subf != "")
                                {
                                    if (line.ToLower().Contains(subf.ToLower()))
                                    {
                                        stopNow = true;
                                        break;
                                    }
                                }

                            }

                        }

                    if (stopNow)
                        break;


                    Output(line);
                }
            }



        }

        private void Output(string line)
        {
            if (line == "__CLEAR__")
                textBox7.Text = "";
            else
                textBox7.Text += "\r\n" + line;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog fdlg = new SaveFileDialog();
            fdlg.Title = "Save Markdown file As";
            fdlg.InitialDirectory = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
               "");
            if (textBox2.Text != "")
                fdlg.InitialDirectory = textBox2.Text;
            
            fdlg.Filter = "Markdown (*.md)|*.md|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                //if (File.Exists(fdlg.FileName))
                //{

                //    string message =
                //        "File already exists!\r\n"+ fdlg.FileName;
                //    const string caption = "Save Markdown file As";
                //    var result = MessageBox.Show(message, caption,
                //                                 MessageBoxButtons.OK,
                //                                 MessageBoxIcon.Exclamation);
                //    return;
                //}

                File.WriteAllText(fdlg.FileName, textBox7.Text);                
            }
        }
    }

}


