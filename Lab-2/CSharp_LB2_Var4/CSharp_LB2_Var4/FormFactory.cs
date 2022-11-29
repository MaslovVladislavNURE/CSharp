using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_LB2_Var4
{
    public partial class FormFactory : Form
    {
        HashSet<Factory> arr, arrCopy;


        public FormFactory()
        {
            InitializeComponent();
            arr = new HashSet<Factory>();
            arrCopy = new HashSet<Factory>();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hiringFiringWorkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initializeFormHiringFiring(1);
            comboBoxFactories.SelectedIndex = -1;
        }

        private void hiringFiringCraftsmenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initializeFormHiringFiring(2);
            comboBoxFactories.SelectedIndex = -1;
        }

        private void copyFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arr.Count() == 0)
                MessageBox.Show("Ви ще не додали жодного заводу!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxFactories.SelectedIndex == -1)
                MessageBox.Show("Оберіть завод зі списку!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                arrCopy.Add(new Factory(arr.ElementAt(comboBoxFactories.SelectedIndex)));
                MessageBox.Show("Успішне копіювання!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxFactoriesCopy.Items.Add(arrCopy.ElementAt(arr.Count() - 1).factoryName);
                comboBoxFactories.SelectedIndex = -1;
            }
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arr.Count() < 2)
                MessageBox.Show("Недостатньо заводів для об'єднання!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                initializeFormMerge();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxFactoryName.Text == "" || textBoxNumberWorkshops.Text == "" ||
                textBoxAmountWorkers.Text == "" || textBoxAmountCraftsmen.Text == "" ||
                textBoxSalaryWorker.Text == "" || textBoxSalaryCraftsman.Text == "" ||
                textBoxProfitWorker.Text == "" || textBoxProfitCraftsman.Text == "")
                MessageBox.Show("Недостатньо даних!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool checkRepeat = checkFactoriesRepeat(textBoxFactoryName.Text);
                if (checkRepeat)
                    MessageBox.Show("Такий завод вже існує!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    int tempNumberWorkshops, tempAmountWorkers, tempAmountCraftsmen, tempSalaryWorker, tempSalaryCraftman, tempProfitWorker, tempProfitCraftman;
                    Int32.TryParse(textBoxNumberWorkshops.Text, out tempNumberWorkshops);
                    Int32.TryParse(textBoxAmountWorkers.Text, out tempAmountWorkers);
                    Int32.TryParse(textBoxAmountCraftsmen.Text, out tempAmountCraftsmen);
                    Int32.TryParse(textBoxSalaryWorker.Text, out tempSalaryWorker);
                    Int32.TryParse(textBoxSalaryCraftsman.Text, out tempSalaryCraftman);
                    Int32.TryParse(textBoxProfitWorker.Text, out tempProfitWorker);
                    Int32.TryParse(textBoxProfitCraftsman.Text, out tempProfitCraftman);
                    if (tempNumberWorkshops <= 0)
                        MessageBox.Show("Неправильна вказана кількість цехів!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (tempAmountWorkers <= 0)
                        MessageBox.Show("Неправильна вказана кількість робітників!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (tempAmountCraftsmen <= 0)
                        MessageBox.Show("Неправильна вказана кількість майстрів", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (tempSalaryWorker <= 0)
                        MessageBox.Show("Неправильно вказана зарплата працівника!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (tempSalaryCraftman <= 0)
                        MessageBox.Show("Неправильно вказана зарплата майстра!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (tempProfitWorker == 0)
                        MessageBox.Show("Неправильно вказаний прибуток з одного робітника!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (tempProfitCraftman == 0)
                        MessageBox.Show("Неправильно вказаний прибуток з одного майстра!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (tempAmountCraftsmen * 10 < tempAmountWorkers)
                        MessageBox.Show("Недостатньо майстрів! Один майстер на 10 робітників.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Factory temp = new Factory();
                        temp.factoryName = textBoxFactoryName.Text;
                        temp.numberWorkshops = tempNumberWorkshops;
                        temp.amountWorkers = tempAmountWorkers;
                        temp.amountCraftsmen = tempAmountCraftsmen;
                        temp.salaryWorker = tempSalaryWorker;
                        temp.salaryCraftman = tempSalaryCraftman;
                        temp.profitWorker = tempProfitWorker;
                        temp.profitCraftman = tempProfitCraftman;
                        arr.Add(temp);
                        comboBoxFactories.Items.Add(temp.factoryName);
                        clearForm();
                    }
                }
            }
        }

        private void buttonShowCopy_Click(object sender, EventArgs e)
        {
            if (arrCopy.Count() == 0)
                MessageBox.Show("Ви ще не скопіювали жодного заводу!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxFactoriesCopy.SelectedIndex == -1)
                MessageBox.Show("Оберіть скопійований завод зі списку!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                addInfoToDataGridView(dataGridView1, comboBoxFactoriesCopy.SelectedIndex, 2);
                comboBoxFactoriesCopy.SelectedIndex = -1;
            }

        }

        private void comparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arr.Count() < 2)
                MessageBox.Show("Недостатня кількість заводів!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                initializeFormComparison();
        }

        private void investmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arr.Count() == 0)
                MessageBox.Show("Ви ще не додали жодного заводу!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxFactories.SelectedIndex == -1)
                MessageBox.Show("Оберіть завод зі списку!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                initializeFormInvestment();
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (arr.Count() == 0)
                MessageBox.Show("Ви ще не додали жодного заводу!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxFactories.SelectedIndex == -1)
                MessageBox.Show("Оберіть завод зі списку!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                addInfoToDataGridView(dataGridView1, comboBoxFactories.SelectedIndex, 1);
                comboBoxFactories.SelectedIndex = -1;
            }
        }
    }
}
