using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_Dusk
{
    public partial class Form1 : Form
    {
        List<Rectangular> Main_Panel = new List<Rectangular>();
        List<Rectangular> temp_panel = new List<Rectangular>();
        string tool13 = "\nG0 G54 G90 X0.0000 Y0.0000 M13 S12000\nG43 H13 Z0.6770\n";
        string tool15 = "\nG0 G54 G90 X0.0000 Y0.0000 M13 S10000\nG43 H15 Z0.6770\n";
        string preprecessor = null;
        double sheet_length = 0f;
        double startX = 0;
        string master_code = null;
        bool first = true;
        bool empty = false;
        public string etching = null;
        bool first_etch = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = JobNumberTextBox;
        }

        public string GetEtchingNumber()
        {
            string[] lines = File.ReadAllLines(Application.StartupPath + @"\Preferences.txt");

            return "T" + lines[1];
        }

        public string GetCuttingNumber()
        {
            string[] lines = File.ReadAllLines(Application.StartupPath + @"\Preferences.txt");

            return "T" + lines[0];
        }

        private string GetSavedLocation()
        {
            string[] lines = File.ReadAllLines(Application.StartupPath + @"\Preferences.txt");

            return lines[2];
        }
        /// <summary>
        /// THIS IS THE AREA FOR THE DATA ENTRY AREA OF THE FORM
        /// </summary>

        private void JobNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            double length = 0;
            string msg = string.Empty;
            //ADD CHECK FOR MIN/MAX HEIGHT & LENGTH, 0 QUANTITY, JOB NUMBER LENGTH CheckForNull()

            msg = CheckForNull();

            msg = msg + CheckForMinMax();

            if (string.IsNullOrEmpty(msg))
            {
                length = double.Parse(WidthTextBox.Text) / 25.4;
                ChoosePanelType();
                LengthListBox.Items.Add(LengthTextBox.Text);
                WidthListBox.Items.Add(WidthTextBox.Text);
                QuantityListBox.Items.Add(QuantityTextBox.Text);
                ClearResetForm();
                RunButton.Enabled = true;
                SaveListButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("You have the following problems:\n" + msg);
            }
        }

        private string CheckForMinMax()
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(JobNumberTextBox.Text))
            {
                if (JobNumberTextBox.Text.Length < 5)
                {
                    result = result + "Incorrect job number\n";
                }
            }
            if (!string.IsNullOrEmpty(LengthTextBox.Text))
            {
                if (double.Parse(LengthTextBox.Text) > 3048)
                {
                    result = result + "The height is too large\n";
                }
                else if (double.Parse(LengthTextBox.Text) < 80)
                {
                    result = result + "The length is too narrow\n";
                }
            }
            if (!string.IsNullOrEmpty(WidthTextBox.Text))
            {
                if (double.Parse(WidthTextBox.Text) > 3048)
                {
                    result = result + "The width is too large\n";
                }
                else if (double.Parse(WidthTextBox.Text) < 80)
                {
                    result = result + "The width is too narrow\n";
                }
            }
            if (!string.IsNullOrEmpty(QuantityTextBox.Text))
            {
                if (int.Parse(QuantityTextBox.Text) <= 0)
                {
                    result = result + "Quantity of 0\n";
                }
            }
            if (!string.IsNullOrEmpty(LengthTextBox.Text) && !string.IsNullOrEmpty(WidthTextBox.Text))
            {
                if (double.Parse(LengthTextBox.Text) > 1219 && double.Parse(WidthTextBox.Text) > 1219)
                {
                    result = result + "The piece's dimensions are too big for the materialn";
                }
            }
            return result;
        }

        private string CheckForNull()
        {
            string is_null = string.Empty;
            if (string.IsNullOrEmpty(JobNumberTextBox.Text))
            {
                is_null = is_null + "No job number\n";
            }
            if (string.IsNullOrEmpty(LengthTextBox.Text))
            {
                is_null = is_null + "No panel length\n";
            }
            if (string.IsNullOrEmpty(WidthTextBox.Text))
            {
                is_null = is_null + "No panel width\n";
            }
            if (string.IsNullOrEmpty(QuantityTextBox.Text))
            {
                is_null = is_null + "No quanitity\n";
            }
            if (PlexiTextBox.SelectedIndex == -1)
            {
                is_null = is_null + "No plexiglass type\n";
            }
            return is_null;
        }

        private void ClearResetForm()
        {
            LengthTextBox.Clear();
            WidthTextBox.Clear();
            QuantityTextBox.Clear();
            this.ActiveControl = WidthTextBox;
        }

        //*******************************************************************************************************//

        /// <summary>
        /// THIS IS THE AREA CONTAINING THE RUN BUTTON AND ALL IT'S FUNCTIONS
        /// </summary>

        int count = 1; //This keeps track of how many files are created

        private void RunButton_Click(object sender, EventArgs e)
        {
            AddPanelsToList(); //Add and sort all the panels to the list
            string boxed = null;
            

            if (LengthListBox.Items.Count > 0)
            {
                while (!empty)
                {
                    master_code = PreProcessor(); //Build the preprocessor
                    ChoosePanelType(); //Figure out what size of plexi you're using
                    boxed = CreatePanel();
                    master_code = master_code + Environment.NewLine + etching;
                    master_code = master_code + Environment.NewLine + boxed; // Stack all the panels you can in one sheet
                    master_code = master_code + Environment.NewLine + PostProcessor(); //Add in the post processor
                    SaveANCFile(master_code);
                    etching = String.Empty;
                    if (Main_Panel.Count <= 0)
                    {
                        empty = true;
                        count = 1;
                        startX = 0;
                    }
                    else
                    {
                        master_code = null;
                    }
                }
                empty = false;
            }
            else
            {
                MessageBox.Show("Please enter at least one panel for this job");
            }
            ClearAllInfo();
            MessageBox.Show("Done");
            this.ActiveControl = JobNumberTextBox;
        }

        private void AddPanelsToList()
        {
            double length = 0;
            double width = 0;

            int count = LengthListBox.Items.Count;
            for (int i = 0; i < count; i++)
            {

                length = Double.Parse(LengthListBox.Items[i].ToString());
                width = Double.Parse(WidthListBox.Items[i].ToString());

                // convert the mm to inches

                width = Math.Round(width / 25.4, 4);
                length = Math.Round(length / 25.4, 4);

                Rectangular rec = new Rectangular(length, width, false);
                for (int j = 0; j < int.Parse(QuantityListBox.Items[i].ToString()); j++)
                {
                    Main_Panel.Add(rec);
                }
            }

            Main_Panel = Main_Panel.OrderByDescending(o => o.length).ToList();
            //Need to figure out sorting system
        }

        private string PreProcessor()
        {
            //The stringbuilder puts together all the pre processing before the first etching is done
            StringBuilder sb = new StringBuilder();
            sb.Append("%\n");
            sb.Append("O0001 " + JobNumberTextBox.Text + "\n");
            sb.Append("G0 G20 G91 G28 Z0 M15\n");
            sb.Append("G90 G40 M22\n");
            sb.Append("M88 B0\n");
            sb.Append("M89 B0\n");
            sb.Append("G08 P1\n");
            sb.Append("M25\n");
            preprecessor = sb.ToString();
            return preprecessor;
        }

        private void ChoosePanelType()
        {
            if (PlexiTextBox.GetItemText(PlexiTextBox.SelectedItem) == "Clear PlexiGlass")
            {
                sheet_length = 96;

            }
            else if (PlexiTextBox.GetItemText(PlexiTextBox.SelectedItem) == "Smoked PlexiGlass")
            {
                sheet_length = 120;
            }
        }

        private string CreatePanel()
        {
            int panel_count = 0;
            Rectangular rec = new Rectangular(0, 0, false);
            string panels = null;
            
            foreach (Rectangular rect in Main_Panel)
            {
                rec = RectPanelOrientation(rect);//Reorient and convert to inches
                
                if (sheet_length - rec.width > 0)
                {
                    if (string.IsNullOrEmpty(panels))
                    {
                        panels = CreatePerimeterGCode(rec);
                    }
                    else
                    {
                        panels = panels + Environment.NewLine + CreatePerimeterGCode(rec);
                    }
                    etching = etching + Environment.NewLine + AddEtching(rect);
                    panel_count++;

                }
                else
                {
                    temp_panel.Add(rec);
                }
                if (panel_count == 5)// BOOBS
                {
                    sheet_length = 0;
                }
            }
            etching = etching + "G00   Z0.4270\nG0 Z0.9770\nG80\nG17 G91 G28 Z0 M95\nM92\n";
            //WILL THIS ACTUALLY WORK?
            if (temp_panel.Count > 0)
            {
                Main_Panel.Clear();
                Main_Panel.AddRange(temp_panel);
                temp_panel.Clear();
                first = true;
                startX = 0;
                first_etch = false;
            }
            else
            {
                Main_Panel.Clear(); //?
            }
            

            return panels;

        }

        private string AddEtching(Rectangular rect)
        {
            string[] lines = null;
            StringBuilder sb = new StringBuilder();
            string temp = null;

            if (rect.rotated == true)
            {
                lines = File.ReadAllLines(Application.StartupPath + @"\WORDS-ROTATED.anc");
                if (!first_etch)
                {
                    sb.Append(GetEtchingNumber() + tool15 + "\n");
                    first_etch = true;
                }
                
                //sb.Append("G0 G54 G90 M13 S10000 \nG43 H15 Z0.9770");
                foreach (string line in lines)
                {
                    temp = line;
                    if (!String.IsNullOrEmpty(temp))
                    {
                        if (temp.ToUpper().Contains("X"))
                        {
                            temp = NewXCoor(temp, startX, 2.75);
                        }
                        if (temp.ToUpper().Contains("Y"))
                        {
                            temp = NewYCoor(temp, rect.length, 2.5);
                        }
                        if (!String.IsNullOrEmpty(temp))
                        {
                            sb.Append(temp + "\n");
                        }
                        temp = null;
                    }
                }
            }
            else if (rect.rotated == false)
            {
                lines = File.ReadAllLines(Application.StartupPath + @"\WORDS-UPRIGHT.anc");
                if (!first_etch)
                {
                    sb.Append(GetEtchingNumber() + tool15 + "\n");
                    first_etch = true;
                }
                //sb.Append("G0 G54 G90 M13 S10000 \nG43 H15 Z0.9770");
                foreach (string line in lines)
                {
                    temp = line;
                    if (!String.IsNullOrEmpty(temp))
                    {
                        if (temp.ToUpper().Contains("X"))
                        {
                            temp = NewXCoor(temp, startX, 2.75);
                        }
                        if (temp.ToUpper().Contains("Y"))
                        {
                            temp = NewYCoor(temp, rect.length, rect.length - 1.5);//what
                        }
                        if (!String.IsNullOrEmpty(temp))
                        {
                            sb.Append(temp + "\n");
                        }
                        temp = null;
                    }
                }
            }
            temp = null;
            return sb.ToString();
        }

        private string NewXCoor(string line, double xmove, double adj)
        {
            string result = null, x_temp = null, temp = null;
            double x_cor;
            int index = 0;
            bool done = false;
            //SerializeJSON sj = new SerializeJSON();
            //double wspacing = 0; //This is the spacing for the width of the panel
            double x_adj = xmove - adj;
            index = line.IndexOf("X");
            temp = line.Substring(index + 1);
            while (!done)
            {
                foreach (char c in temp)
                {
                    if (!Char.IsLetter(c))
                    {
                        x_temp = x_temp + c;
                    }
                    else
                    {
                        break;
                    }
                }
                done = true;
            }

            x_cor = double.Parse(x_temp) + x_adj;
            line = line.Replace("X" + x_temp, "X" + x_cor.ToString() + " ");
            result = line;
            return result;
        }

        private string NewYCoor(string line, double ymove, double adj)
        {
            string result = null, y_temp = null, temp = null;
            double y_cor;
            int index = 0;
            bool done = false;
            //SerializeJSON js = new SerializeJSON();
            //double y_adjust = Properties.Settings.Default.YCoorAdjustment;
            double y_adjust = ymove - adj;
            index = line.IndexOf("Y");
            temp = line.Substring(index + 1);
            while (!done)
            {
                foreach (char c in temp)
                {
                    if (!Char.IsLetter(c))
                    {
                        y_temp = y_temp + c;
                    }
                    else
                    {
                        break;
                    }
                }
                done = true;
            }

            if (y_temp != null)
            {
                y_cor = double.Parse(y_temp) + y_adjust;
                line = line.Replace("Y" + y_temp, "Y" + y_cor.ToString() + " ");
            }
            
            result = line;
            return result;
        }

        private Rectangular RectPanelOrientation(Rectangular rect)
        {
            double temp = 0;
            if (rect != null)
            {
                if (rect.length < rect.width && rect.rotated == false)//??
                {
                    temp = rect.width;
                    rect.width = rect.length;
                    rect.length = temp;
                    rect.rotated = true;
                }
                if (rect.length > 48)
                {
                    temp = rect.width;
                    rect.width = rect.length;
                    rect.length = temp;
                    if (!rect.rotated)
                    {
                        rect.rotated = true;
                    }
                    else
                    {
                        rect.rotated = false;
                    }
                }
            }


            return rect;
        }

        private string CreatePerimeterGCode(Rectangular rec)
        {
            StringBuilder gcode = new StringBuilder();
            double x_adj = 0;
            double rCode = 0.126;
            double frontX = startX + rec.width + x_adj;
            double frontY = rec.length;
            //double spacing = 0.25; //The spacing between edges and panels
            if (first)
            {
                gcode.Append(GetCuttingNumber() + tool13);
                first = false;
            }
            //gcode.Append("\nG0 Z0.9770\n");
            gcode.Append(String.Format("G00 X{0} Y{1} Z{2}\n", frontX + rCode, frontY / 2, 0.5));
            gcode.Append(String.Format("G00 X{0} Z{1}\n", frontX + (2 * rCode), 0.2));
            gcode.Append(String.Format("G01 X{0} Y{1} Z{2} F25.\n", frontX + rCode, frontY / 2 - 1, -0.001));
            gcode.Append(String.Format("G01 Y{0} F110.\n", frontY));
            gcode.Append(String.Format("G03 X{0} Y{1} R{2}\n", frontX, frontY + rCode, rCode));
            gcode.Append(String.Format("G01 X{0}\n", startX));
            gcode.Append(String.Format("G03 X{0} Y{1} R{2}\n", startX - rCode, frontY, rCode));
            gcode.Append("G01 Y0.0000 \n");//after this be bad
            gcode.Append(String.Format("G03 X{0} Y{1} R{2}\n", startX, 0 - rCode, rCode));
            gcode.Append(String.Format("G01 X{0} \n", frontX));
            gcode.Append(String.Format("G03 X{0} Y{1} R{2}\n", frontX + rCode, 0.0000, rCode));
            gcode.Append(String.Format("G01 Y{0}\n", frontY / 2));
            gcode.Append("G00 Z0.5\n");

            //add part width to 0
            startX = startX + rec.width + 0.5;
            sheet_length = sheet_length - (rec.width + (0.5));
            //Export string to make the master code
            return gcode.ToString();
        }

        private string PostProcessor()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("G80\n");
            sb.Append("M22\n");
            sb.Append("G91 G28 Z0 M15\n");
            sb.Append("G90 H0 M25\n");
            sb.Append("M88 B0\n");
            sb.Append("M89 B0\n");
            sb.Append("G91 G28\n");
            sb.Append("G90 X0.0000 Y0.0000\n");
            sb.Append("M07\n");
            sb.Append("G08 P0\n");
            sb.Append("M30\n");
            sb.Append("%");

            return sb.ToString();
        }

        private void SaveANCFile(string master_code)
        {
            string path = GetSavedLocation() + @"\" + JobNumberTextBox.Text + "-" + GetPlexiType();
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                File.WriteAllText(path + @"\" + JobNumberTextBox.Text + "-" + count.ToString() + ".anc", master_code);
            }
            else
            {
                File.WriteAllText(path + @"\" + JobNumberTextBox.Text+ "-" + count.ToString() + ".anc", master_code);
            }
            
            count++;
            //MessageBox.Show("Done motherfucker!!");
        }

        private string GetPlexiType()
        {
            string type = string.Empty;

            if (PlexiTextBox.SelectedIndex == 0)
            {
                type = "CLEAR";

            }
            else if (PlexiTextBox.SelectedIndex == 1)
            {
                type = "SMOKED";
            }

            return type;
        }

        private void ClearAllInfo()
        {
            JobNumberTextBox.Clear();
            PlexiTextBox.SelectedIndex = -1;
            LengthTextBox.Clear();
            WidthTextBox.Clear();
            QuantityTextBox.Clear();
            LengthListBox.Items.Clear();
            WidthListBox.Items.Clear();
            QuantityListBox.Items.Clear();
            RunButton.Enabled = false;
            EditLengthTextBox.Clear();
            EditWidthTextBox.Clear();
            EditQuantityTextBox.Clear();
            SaveListButton.Enabled = false;

            preprecessor = null;
            sheet_length = 0f;
            startX = 0;
            master_code = null;
            first = true;
            empty = false;
            etching = null;
            first_etch = false;
    }

        //*******************************************************************************************************//

        /// <summary>
        /// THIS AREA IS FOR THE FUNCTIONS THAT ARE TO EDIT THE LIST BEFORE IT'S CREATED
        /// </summary>

        private void LengthListBox_Click(object sender, EventArgs e)
        {
            EditPanelDetails(LengthListBox.SelectedIndex);
            WidthListBox.SelectedIndex = LengthListBox.SelectedIndex;
            QuantityListBox.SelectedIndex = LengthListBox.SelectedIndex;
        }

        private void EditPanelDetails(int selectedIndex)
        {
            EditLengthTextBox.Text = LengthListBox.Items[selectedIndex].ToString();
            EditWidthTextBox.Text = WidthListBox.Items[selectedIndex].ToString();
            EditQuantityTextBox.Text = QuantityListBox.Items[selectedIndex].ToString();
            EditButton.Enabled = true;
        }

        private void WidthListBox_Click(object sender, EventArgs e)
        {
            EditPanelDetails(WidthListBox.SelectedIndex);
            LengthListBox.SelectedIndex = WidthListBox.SelectedIndex;
            QuantityListBox.SelectedIndex=WidthListBox.SelectedIndex;
        }

        private void QuantityListBox_Click(object sender, EventArgs e)
        {
            EditPanelDetails(QuantityListBox.SelectedIndex);
            LengthListBox.SelectedIndex=QuantityListBox.SelectedIndex;
            WidthListBox.SelectedIndex= QuantityListBox.SelectedIndex;
        }

        private void deletePanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LengthListBox.Items.RemoveAt(LengthListBox.SelectedIndex);
            WidthListBox.Items.RemoveAt(WidthListBox.SelectedIndex);
            QuantityListBox.Items.RemoveAt(QuantityListBox.SelectedIndex);
            EditLengthTextBox.Clear();
            EditWidthTextBox.Clear();
            EditQuantityTextBox.Clear();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearAllInfo();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(EditLengthTextBox.Text))
            {
                if (LengthListBox.SelectedIndex != -1)
                {
                    LengthListBox.Items[LengthListBox.SelectedIndex] = EditLengthTextBox.Text;
                    WidthListBox.Items[WidthListBox.SelectedIndex] = EditWidthTextBox.Text;
                    QuantityListBox.Items[QuantityListBox.SelectedIndex] = EditQuantityTextBox.Text;
                }
                EditLengthTextBox.Clear();
                EditWidthTextBox.Clear();
                EditQuantityTextBox.Clear();
            }
        }

        private void clearPanelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LengthListBox.Items.Clear();
            WidthListBox.Items.Clear();
            QuantityListBox.Items.Clear();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences frm = new Preferences();
            frm.ShowDialog();
        }

        private void SaveListButton_Click(object sender, EventArgs e)
        {
            SaveListtoFile();
        }

        private void SaveListtoFile()
        {
            int dacount = 0;
            string item = string.Empty;
            string path = GetSavedLocation() + @"\" + JobNumberTextBox.Text + "-" + GetPlexiType();

            if (LengthListBox.Items.Count >= 1)
            {
                dacount = LengthListBox.Items.Count;

                for (int i = 0; i < dacount; i++)
                {
                    item = item + GetListItem(i) + Environment.NewLine;
                }
            }
            //Save to file
            if (!string.IsNullOrEmpty(JobNumberTextBox.Text) && PlexiTextBox.SelectedIndex != -1)
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    File.WriteAllText(path + @"\" + JobNumberTextBox.Text + ".gpcs", item);
                }
                else
                {
                    File.WriteAllText(path + @"\" + JobNumberTextBox.Text + ".gpcs", item);
                }
                MessageBox.Show("The file has been saved in " + JobNumberTextBox.Text + "-" + GetPlexiType());
            }
        }

        private string GetListItem(int i)
        {
            string result = string.Empty;

            result = LengthListBox.Items[i].ToString() + "!" + WidthListBox.Items[i].ToString() + "!" + QuantityListBox.Items[i].ToString();

            return result;
        }

        private void LoadListButton_Click(object sender, EventArgs e)
        {
            LoadListFromFile();
        }

        private void LoadListFromFile()
        {
            if (!string.IsNullOrEmpty(JobNumberTextBox.Text) && PlexiTextBox.SelectedIndex != -1)                
            {
                string path = GetSavedLocation() + @"\" + JobNumberTextBox.Text + "-" + GetPlexiType();
                if (Directory.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path + @"\" + JobNumberTextBox.Text + ".gpcs");
                    LoadListBoxes(lines);                    
                }
                RunButton.Enabled = true;
            }
            else
            {
                if (OpenSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string name = OpenSaveFileDialog.FileName;
                    string[] lines = File.ReadAllLines(name);
                    LoadListBoxes(lines);
                    GetJobNumberFromFile(name);
                    GetPlexiTypeFromFile(name);
                    RunButton.Enabled = true;
                    this.ActiveControl = WidthTextBox;
                }
            }
        }

        private void LoadListBoxes(string[] lines)
        {
            foreach (string thing in lines)
            {
                string[] panels = thing.Split('!');
                LengthListBox.Items.Add(panels[0]);
                WidthListBox.Items.Add(panels[1]);
                QuantityListBox.Items.Add(panels[2]);
            }
        }

        private void GetJobNumberFromFile(string name)
        {
            int index = name.LastIndexOf(@"\") + 1;
            int second = name.LastIndexOf('.');
            if (index != -1)
            {
                JobNumberTextBox.Text = name.Substring(index, name.Length - second);
            }

        }

        private void GetPlexiTypeFromFile(string name)
        {
            if (name.Contains("SMOKED"))
            {
                PlexiTextBox.SelectedIndex = 1;
            }
            else if (name.Contains("CLEAR"))
            {
                PlexiTextBox.SelectedIndex = 0;
            }
        }

        //*******************************************************************************************************//
    }
}
