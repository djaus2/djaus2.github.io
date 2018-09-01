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
using YamlDotNet.RepresentationModel;

namespace FilterWF
{

    public partial class Form1 : Form
    {

        public string[] Categories = new string[0];
        public List<Categoryx> Categorys = new List<Categoryx>();
        string srcFilePath = "";
        string githubioroot = "";

        public Form1()
        {
            InitializeComponent();

            tbSrcFilename.Text = Program.srcFilename;
            tbSrcFolder.Text = Program.srcFolder;
            tbTopic.Text = Program.topic;
            tbSubTopic.Text = Program.subTopic;
            //tbCategory.Text = Program.category;
            tbStartFilterCSVList.Text = Program.startFilters;
            tbSkipListLines.Text = Program.skipFilters.Replace(",","\r\n");
            tbEndFilterCSVList2.Text = Program.endFilters;

            srcFilePath = Program.srcPath;

            githubioroot = Environment.GetEnvironmentVariable("GITHUBIOROOT");
            string ymlPath = Path.Combine(githubioroot,"_config.yml");

            if (File.Exists(ymlPath))
            {
                using (var reader = new StreamReader(ymlPath))
                {
                    // Load the stream
                    var yaml2 = new YamlStream();
                    yaml2.Load(reader);

                    // Examine the stream
                    YamlMappingNode rootNode =
                        (YamlMappingNode)yaml2.Documents[0].RootNode;
                    YamlDotNet.RepresentationModel.YamlNode sections = rootNode["sections"];


                    for (int i = 0; i < sections.AllNodes.Count(); i++)
                    {
                        try
                        {
                            YamlNode section = sections.AllNodes.ToList()[i];

                            string Name = (string)section[0];
                            string Abbrev = (string)section[1];
                            Categorys.Add(new Categoryx(Abbrev, Name));
                        }
                        catch (Exception)
                        {
                            //First section item will catch here as its a list of all nodes.
                            //Just ignore. Could iterate from i=1
                            //Why does this feel like deja vu?
                        }
                    }

                }
                var cats = from c in Categorys select c.Name;
                CategoriesComboBox.Items.AddRange(cats.ToArray());
            }
            else
            {
                Categories = Program.categories.Split(new char[] { ',' });

                CategoriesComboBox.Items.AddRange(Categories);
                if (Program.category != "")
                {
                    if (Categories.ToList().Contains(Program.category))
                        CategoriesComboBox.SelectedItem = Program.category;
                }
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            //tbSrcFilename.Text = "";
            //textBox2.Text = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select Markdown file to filter";
            fdlg.InitialDirectory = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
               "");
            if (tbSrcFolder.Text != "")
                fdlg.InitialDirectory = tbSrcFolder.Text;
            // fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Markdown (*.md)|*.md|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                srcFilePath = fdlg.FileName;
                tbSrcFilename.Text = Path.GetFileName(srcFilePath);
                tbSrcFolder.Text = Path.GetFullPath(srcFilePath).Replace(tbSrcFilename.Text,"");

                //Output("__CLEAR__");
                //StreamReader sr = File.OpenText(filename);
                //Output(sr.ReadToEnd());
                LoadFile();
            }
        }

        private void LoadFile()
        {
            if (File.Exists(srcFilePath))
            {
                tbSrcFilename.Text = Path.GetFileName(srcFilePath);
                tbSrcFolder.Text = Path.GetFullPath(srcFilePath).Replace(tbSrcFilename.Text, ""); ;

                Output("__CLEAR__");
                StreamReader sr = File.OpenText(srcFilePath);
                Output(sr.ReadToEnd());
            }
            else
            {
                string message =
                    "File doesn't exist!\r\n" + srcFilePath;
                const string caption = "Openfile";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Exclamation);
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] args = new string[] {  tbSkipListLines.Text, tbStartFilterCSVList.Text, tbEndFilterCSVList2.Text };
            //Main(args);
            int skipstart = 0;
            if (!int.TryParse(tbNoLinesToSkipAtStart.Text, out skipstart))
            {
                skipstart = 0;
            }

            //FilterCls.filterMD.OutputMsg outMsg = Output;
            string[] Lines = tbOutput.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            tbOutput.Text = "";
            FilterCls.filterMD.ExecFilters(args, Output, skipstart,Lines);
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
                    linesToSkipStartingWith = (args[0].Split(new string[] { "\r","\n" }, StringSplitOptions.RemoveEmptyEntries)).ToList();
                }
            }

            //Skip lines:
            //Starting with is default. + prefix = starting with  - prefix is contains
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


            if (File.Exists(srcFilePath))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
            {
                int skipstart = 0;
                bool stop = false;
                if (!int.TryParse(tbNoLinesToSkipAtStart.Text, out skipstart))
                {
                    skipstart = 0;
                }
                StreamReader sr = File.OpenText(srcFilePath);
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
                                else if ((f[0] == '+') && subf != "")
                                {
                                    if (line.ToLower().Contains(subf.ToLower()))
                                    {
                                        stop = true;
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
                tbOutput.Text = "";
            else
                tbOutput.Text += "\r\n" + line;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filenameMd = DateTime.Now.ToString("yyy-mm-dd").Replace("Z","") + "-" + tbTopic.Text + "-" + CategoriesComboBox.SelectedItem;
            SaveFileDialog fdlg = new SaveFileDialog();
            fdlg.Title = "Save Markdown file As";
            var x = Environment.CurrentDirectory;
            fdlg.InitialDirectory = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
               "");
            if (tbSrcFolder.Text != "")
                fdlg.InitialDirectory = tbSrcFolder.Text;
            if (githubioroot != "")
                fdlg.InitialDirectory = Path.Combine(githubioroot, "_" + CategoriesComboBox.SelectedItem);

            fdlg.Filter = "Markdown (*.md)|*.md|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            fdlg.FileName = filenameMd + ".md";
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
                string header = "";
                if (cbAddHeader.Checked == true)
                {
                    header = "---\r\n";
                    header += "layout: page\r\n";
                    if (tbTopic.Text != "")
                        header += "title: " + tbTopic.Text + "\r\n";
                    if (tbSubTopic.Text != "")
                        header += "subtitle: " + tbSubTopic.Text + "\r\n";
                    if (CategoriesComboBox.SelectedIndex != -1)
                        header += "category: " + CategoriesComboBox.SelectedItem + "\r\n";
                    header += "date: " + DateTime.Now.ToString("u") + "\r\n";
                    header += "---\r\n\r\n";
                    File.WriteAllText(fdlg.FileName, header);
                }
                File.AppendAllText( fdlg.FileName, tbOutput.Text);                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            srcFilePath = Path.Combine(tbSrcFolder.Text, tbSrcFilename.Text);
            LoadFile();
        }


    }

    public class Categoryx
    {
        public string Name { get; set; } = "";
        public string Abbrev { get; set; } = "";

        public Categoryx(string name, string abbrev)
        {
            Name = name;
            Abbrev = abbrev;
        }
    }

}


