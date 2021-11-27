using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace ScientificWorksOfTheDepartment
{
	public partial class ScientificWorks : Form
	{
		private string path_xml = @"C:\Users\IdeaPad\source\repos\ScientificWorksOfTheDepartment\XMLFile.xml";
		private string path_xsl = @"C:\Users\IdeaPad\source\repos\ScientificWorksOfTheDepartment\FileXSL.xsl";
		public ScientificWorks()
		{
			InitializeComponent();
			BuildBox(comboBoxNameA, comboBoxFaculty, comboBoxCathedra, comboBoxLab,
                comboBoxPosition, comboBoxStartO, comboBoxEndO, comboBoxWork,
                comboBoxNameC, comboBoxAddress, comboBoxSubord, comboBoxFieldW);
			checkBoxNameA.Enabled = true;
			checkBoxFaculty.Enabled = true;
			checkBoxCathedra.Enabled = true;
			checkBoxLab.Enabled = true;
			checkBoxPosition.Enabled = true;
			checkBoxStartO.Enabled = true;
			checkBoxEndO.Enabled = true;
			checkBoxWork.Enabled = true;
			checkBoxNameC.Enabled = true;
			checkBoxAddress.Enabled = true;
			checkBoxSubord.Enabled = true;
			checkBoxFieldW.Enabled = true;
			radioLinq.Checked = true;
		}

        public void BuildBox(ComboBox name_a_box, ComboBox faculty_box, ComboBox cathedra_box, ComboBox lab_box, 
            ComboBox position_box, ComboBox start_o_box, ComboBox end_o_box, ComboBox work_box, 
            ComboBox name_c_box, ComboBox address_box, ComboBox subord_box, ComboBox field_work_box)
        {
            IStrategy strategy = new LinqToXML();
            List<Works> result = strategy.AnalyzeFile(new Works(), path_xml);
            List<string> name_a = new List<string>();
            List<string> faculty = new List<string>();
            List<string> cathedra = new List<string>();
            List<string> lab = new List<string>();
            List<string> posit = new List<string>();
            List<string> start_o = new List<string>();
            List<string> end_o = new List<string>();
            List<string> work = new List<string>();
            List<string> name_c = new List<string>();
            List<string> address = new List<string>();
            List<string> subord = new List<string>();
            List<string> field_w = new List<string>();

            foreach (Works x in result)
            {
                if (!name_a.Contains(x.author_name))
                    name_a.Add(x.author_name);
                if (!faculty.Contains(x.author_faculty))
                    faculty.Add(x.author_faculty);
                if (!cathedra.Contains(x.author_cathedra))
                    cathedra.Add(x.author_cathedra);
                if (!lab.Contains(x.author_laboratory))
                    lab.Add(x.author_laboratory);
                if (!posit.Contains(x.author_position))
                    posit.Add(x.author_position);
                if (!start_o.Contains(x.author_start_of_office))
                    start_o.Add(x.author_start_of_office);
                if (!end_o.Contains(x.author_end_of_office))
                    end_o.Add(x.author_end_of_office);
                if (!work.Contains(x.scientific_work))
                    work.Add(x.scientific_work);
                if (!name_c.Contains(x.customer_name))
                    name_c.Add(x.customer_name);
                if (!address.Contains(x.customer_address))
                    address.Add(x.customer_address);
                if (!subord.Contains(x.customer_subordination))
                    subord.Add(x.customer_subordination);
                if (!field_w.Contains(x.customer_field_of_work))
                    field_w.Add(x.customer_field_of_work);
            }

            name_a = name_a.OrderBy(x => x).ToList();
            faculty = faculty.OrderBy(x => x).ToList();
            cathedra = cathedra.OrderBy(x => x).ToList();
            lab = lab.OrderBy(x => x).ToList();
            posit = posit.OrderBy(x => x).ToList();
            start_o = start_o.OrderBy(x => x).ToList();
            end_o = end_o.OrderBy(x => x).ToList();
            work = work.OrderBy(x => x).ToList();
            name_c = name_c.OrderBy(x => x).ToList();
            address = address.OrderBy(x => x).ToList();
            subord = subord.OrderBy(x => x).ToList();
            field_w = field_w.OrderBy(x => x).ToList();

            name_a_box.Items.AddRange(name_a.ToArray());
            faculty_box.Items.AddRange(faculty.ToArray());
            cathedra_box.Items.AddRange(cathedra.ToArray());
            lab_box.Items.AddRange(lab.ToArray());
            position_box.Items.AddRange(posit.ToArray());
            start_o_box.Items.AddRange(start_o.ToArray());
            end_o_box.Items.AddRange(end_o.ToArray());
            work_box.Items.AddRange(work.ToArray());
            name_c_box.Items.AddRange(name_c.ToArray());
            address_box.Items.AddRange(address.ToArray());
            subord_box.Items.AddRange(subord.ToArray());
            field_work_box.Items.AddRange(field_w.ToArray());
        }

        private Works Search()
        {
            string[] info = new string[12];

            if (checkBoxNameA.Checked)
                info[0] = Convert.ToString(comboBoxNameA.Text);
            if (checkBoxFaculty.Checked)
                info[1] = Convert.ToString(comboBoxFaculty.Text);
            if (checkBoxCathedra.Checked)
                info[2] = Convert.ToString(comboBoxCathedra.Text);
            if (checkBoxLab.Checked)
                info[3] = Convert.ToString(comboBoxLab.Text);
            if (checkBoxPosition.Checked)
                info[4] = Convert.ToString(comboBoxPosition.Text);
            if (checkBoxStartO.Checked)
                info[5] = Convert.ToString(comboBoxStartO.Text);
            if (checkBoxEndO.Checked)
                info[6] = Convert.ToString(comboBoxEndO.Text);
            if (checkBoxWork.Checked)
                info[7] = Convert.ToString(comboBoxWork.Text);
            if (checkBoxNameC.Checked)
                info[8] = Convert.ToString(comboBoxNameC.Text);
            if (checkBoxAddress.Checked)
                info[9] = Convert.ToString(comboBoxAddress.Text);
            if (checkBoxSubord.Checked)
                info[10] = Convert.ToString(comboBoxSubord.Text);
            if (checkBoxFieldW.Checked)
                info[11] = Convert.ToString(comboBoxFieldW.Text);

            Works search = new Works(info);
            return search;
        }

        private void ParsingForXML()
        {
            Works works = Search();
            List<Works> result;

            if (radioSax.Checked)
            {
                IStrategy parser = new SAX();
                result = parser.AnalyzeFile(works, path_xml);
                Output(result);
            }
            else if (radioDom.Checked)
            {
                IStrategy parser = new DOM();
                result = parser.AnalyzeFile(works, path_xml);
                Output(result);
            }
            else if (radioLinq.Checked)
            {
                IStrategy parser = new LinqToXML();
                result = parser.AnalyzeFile(works, path_xml);
                Output(result);
            }
        }

        private void Output(List<Works> results)
        {
            richTextBox.Clear();
            foreach (Works x in results)
            {
                richTextBox.AppendText("Author`s name: " + x.author_name + "\n");
                richTextBox.AppendText("Author`s faculty: " + x.author_faculty + "\n");
                richTextBox.AppendText("Author`s cathedra: " + x.author_cathedra + "\n");
                richTextBox.AppendText("Author`s laboratory: " + x.author_laboratory + "\n");
                richTextBox.AppendText("Author`s position: " + x.author_position + "\n");
                richTextBox.AppendText("Author`s start of office: " + x.author_start_of_office + "\n");
                richTextBox.AppendText("Author`s end of office: " + x.author_end_of_office + "\n");
                richTextBox.AppendText("Scientific work: " + x.scientific_work + "\n");
                richTextBox.AppendText("Customer`s name: " + x.customer_name + "\n");
                richTextBox.AppendText("Customer`s address: " + x.customer_address + "\n");
                richTextBox.AppendText("Customer`s subordination: " + x.customer_subordination + "\n");
                richTextBox.AppendText("Customer`s field of work: " + x.customer_field_of_work + "\n" + "\n");
            }
        }

        private void IntoHTML()
        {
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(path_xsl);
            string input = path_xml;
            string result = @"C:\Users\IdeaPad\source\repos\ScientificWorksOfTheDepartment\HTML.html";
            xsl.Transform(input, result);
            MessageBox.Show("Done!");
        }

        private void Clear()
        {
            richTextBox.Clear();
            radioDom.Checked = false;
            radioSax.Checked = false;
            radioLinq.Checked = false;

            comboBoxNameA.Text = null;
            comboBoxFaculty.Text = null;
            comboBoxCathedra.Text = null;
            comboBoxLab.Text = null;
            comboBoxPosition.Text = null;
            comboBoxStartO.Text = null;
            comboBoxEndO.Text = null;
            comboBoxWork.Text = null;
            comboBoxNameA.Text = null;
            comboBoxAddress.Text = null;
            comboBoxSubord.Text = null;
            comboBoxFieldW.Text = null;

            checkBoxNameA.Checked = false;
            checkBoxFaculty.Checked = false;
            checkBoxCathedra.Checked = false;
            checkBoxLab.Checked = false;
            checkBoxPosition.Checked = false;
            checkBoxStartO.Checked = false;
            checkBoxEndO.Checked = false;
            checkBoxWork.Checked = false;
            checkBoxNameA.Checked = false;
            checkBoxAddress.Checked = false;
            checkBoxSubord.Checked = false;
            checkBoxFieldW.Checked = false;
        }

        private void Help()
        {
            MessageBox.Show("This is a laboratory work №2 'Processing XML - documents'.\n " +
                "Enter the search parameters you want to find information about scientific work.\n " +
                "Choose how to process the file: Linq to XML, DOM or SAX.\n " +
                "Click the 'Search' button.", "Help", MessageBoxButtons.OK);
        }

		private void btnSearch_Click(object sender, EventArgs e)
		{
            ParsingForXML();
        }

		private void btnToHtml_Click(object sender, EventArgs e)
		{
            IntoHTML();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Clear();
        }

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
            string errorMessage = "";
            errorMessage += "Are you sure you want to exit?";
            DialogResult res = MessageBox.Show(errorMessage, "Exit", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
                Application.Exit();
        }

		private void checkBoxNameA_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxNameA.Checked)
            {
                comboBoxNameA.Enabled = true;
            }
            else
            {
                comboBoxNameA.Enabled = false;
            }
        }

		private void checkBoxFaculty_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxFaculty.Checked)
            {
                comboBoxFaculty.Enabled = true;
            }
            else
            {
                comboBoxFaculty.Enabled = false;
            }
        }

		private void checkBoxCathedra_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxCathedra.Checked)
            {
                comboBoxCathedra.Enabled = true;
            }
            else
            {
                comboBoxCathedra.Enabled = false;
            }
        }

		private void checkBoxLab_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxLab.Checked)
            {
                comboBoxLab.Enabled = true;
            }
            else
            {
                comboBoxLab.Enabled = false;
            }
        }

		private void checkBoxPosition_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxPosition.Checked)
            {
                comboBoxPosition.Enabled = true;
            }
            else
            {
                comboBoxPosition.Enabled = false;
            }
        }

		private void checkBoxStartO_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxStartO.Checked)
            {
                comboBoxStartO.Enabled = true;
            }
            else
            {
                comboBoxStartO.Enabled = false;
            }
        }

		private void checkBoxEndO_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxEndO.Checked)
            {
                comboBoxEndO.Enabled = true;
            }
            else
            {
                comboBoxEndO.Enabled = false;
            }
        }

		private void checkBoxWork_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxWork.Checked)
            {
                comboBoxWork.Enabled = true;
            }
            else
            {
                comboBoxWork.Enabled = false;
            }
        }

		private void checkBoxNameC_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxNameC.Checked)
            {
                comboBoxNameC.Enabled = true;
            }
            else
            {
                comboBoxNameC.Enabled = false;
            }
        }

		private void checkBoxAddress_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxAddress.Checked)
            {
                comboBoxAddress.Enabled = true;
            }
            else
            {
                comboBoxAddress.Enabled = false;
            }
        }

		private void checkBoxSubord_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxSubord.Checked)
            {
                comboBoxSubord.Enabled = true;
            }
            else
            {
                comboBoxSubord.Enabled = false;
            }
        }

		private void checkBoxFieldW_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBoxFieldW.Checked)
            {
                comboBoxFieldW.Enabled = true;
            }
            else
            {
                comboBoxFieldW.Enabled = false;
            }
        }

		private void ScientificWorks_Load(object sender, EventArgs e)
		{

		}
	}
}
