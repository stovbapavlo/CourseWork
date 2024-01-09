using System;
using System.Data;
using System.IO;
using ExcelDataReader;
using System.Windows.Forms;
using System.Text;
using System.Globalization;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();
        private int selectedSalary;
        private string selectedEmployeeName = string.Empty;
        private double averageDailySalary = 0;
        private int totalSickDays = 0;
        private DateTime startDate;
        private double discountPercentage = 0.0;


        public Form1()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();

            label3.Visible = false;
            label2.Visible = false;
            label8.Visible = false;

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            comboBox1.Visible = false;

            radioButton1.CheckedChanged += radioButton_CheckedChanged;
            radioButton2.CheckedChanged += radioButton_CheckedChanged;

            comboBox1.Items.AddRange(new object[] { 126, 140, 180 });

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            LoadDataAndPopulateListBox();
        }

        private void LoadDataAndPopulateListBox()
        {
            string filePath = @"D:\курсова\CourseWork\CourseWork\bin\Debug\personal.xlsx";

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    table = result.Tables[0];
                }
            }

            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine(column.ColumnName);
            }

            listBox1.DataSource = table;
            listBox1.ValueMember = table.Columns[0].ColumnName;
            listBox1.DisplayMember = table.Columns[0].ColumnName;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex != -1)
            {
                DataRowView selectedRow = (DataRowView)listBox1.SelectedItem;

                string fullName = selectedRow.Row[0].ToString();

                DataRow[] filteredRows = table.Select($"{table.Columns[0].ColumnName} = '{fullName}'");

                if (filteredRows.Length > 0)
                {

                    DateTime startDate = DateTime.ParseExact(filteredRows[0][3].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);


                    discountPercentage = CalculateDiscountPercentage(startDate);

                    double monthlySalary = double.Parse(filteredRows[0][2].ToString());


                    averageDailySalary = (monthlySalary * 12) / 365;
                    textBox1.Text = filteredRows[0][1].ToString();
                    textBox2.Text = filteredRows[0][2].ToString();

                    selectedEmployeeName = fullName;
                    selectedSalary = int.Parse(filteredRows[0][2].ToString());
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                label3.Visible = true;
                label2.Visible = true;
                comboBox1.Visible = false;
            }
            else if (radioButton2.Checked)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = false;

                label2.Visible = true;
                label8.Visible = true;

                comboBox1.Visible = true;
            }

            button2.Visible = radioButton1.Checked || radioButton2.Checked;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedEmployeeName))
                return;

            textBox3.Text = "";
            textBox4.Text = "";

            int totalSalary = CalculateTotalSalary(selectedEmployeeName);

            int daysDifference;

            if (radioButton2.Checked && comboBox1.SelectedItem is int selectedDays)
            {
               
                daysDifference = selectedDays;
                totalSickDays = selectedDays;
            }
            else if (!string.IsNullOrWhiteSpace(textBox4.Text) && int.TryParse(textBox4.Text, out int manualDays))
            {
                if (manualDays <= 0)
                {
                    MessageBox.Show("Кількість днів повинна бути більше або рівною нулю.");
                    return; 
                }

                daysDifference = manualDays;
                totalSickDays = manualDays;
            }
            else
            {
                if (dateTimePicker1.Value > dateTimePicker2.Value)
                {
                    MessageBox.Show("Дата початку не може бути пізнішою, ніж дата кінця, або співпадати з нею.");
                    textBox3.Text = string.Empty;
                    return;
                }

                daysDifference = (int)(dateTimePicker2.Value - dateTimePicker1.Value).TotalDays;

                if (daysDifference <= 0)
                {
                    MessageBox.Show("Кількість днів повинна бути більше або рівною нулю.");
                    return;
                }

                totalSickDays = daysDifference;
            }

            textBox3.Text = $"{selectedEmployeeName}: {totalSalary}$.";

            if (radioButton1.Checked)
            {
                // Обчислення лікарняних
                double sicknessAllowance = CalculateSicknessAllowance(averageDailySalary, daysDifference, discountPercentage);
                textBox3.Text = $"{sicknessAllowance}";
                textBox4.Text = $"{totalSickDays}";
            }
            else if (radioButton2.Checked)
            {
                // Обчислення декретних
                double dailySalary = totalSalary / 365;

                double maternityAllowance = CalculateMaternityAllowance(dailySalary, daysDifference);
                textBox3.Text = $"{maternityAllowance}";
                textBox4.Text = $"{totalSickDays}";
            }
        }


        private double CalculateDiscountPercentage(DateTime startDate)
        {
            int yearsOfWork = (int)Math.Round((DateTime.Now - startDate).TotalDays / 365);

            if (yearsOfWork < 3)
                return 0.50;
            else if (yearsOfWork < 5)
                return 0.60;
            else if (yearsOfWork < 7)
                return 0.70;
            else
                return 1.0;
        }




        private double CalculateMaternityAllowance(double averageDailySalary, int maternityLeaveDays)
        {
            double maternityAllowance = averageDailySalary * maternityLeaveDays;
            return Math.Round(maternityAllowance, 2);
        }



        private double CalculateSicknessAllowance(double averageDailySalary, int totalSickDays, double discountPercentage)
        {
            double dailySalary = averageDailySalary * totalSickDays * discountPercentage;

            return Math.Round(dailySalary, 2);
        }




        private int CalculateTotalSalary(string employeeName)
        {
            DataRow[] filteredRows = table.Select($"{table.Columns[0].ColumnName} = '{employeeName}'");

            if (filteredRows.Length > 0)
            {
                if (int.TryParse(filteredRows[0][2].ToString(), out int monthlySalary))
                {
                    int totalSalary = monthlySalary * 12;
                    return totalSalary;
                }
                else
                {
                    MessageBox.Show("Помилка при отриманні заробітної плати працівника.");
                }
            }

            return 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }
    }//
}
