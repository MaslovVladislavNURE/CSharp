using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharp_LB2_Var4
{
    public partial class FormFactory
    {
        //додавання інформації до ComboBox
        void addComboBoxInfo(ComboBox comboBox)
        {
            for (int i = 0; i < arr.Count; i++)
                comboBox.Items.Add(arr.ElementAt(i).factoryName);
        }

        //очищення форми після додавання інформації
        private void clearForm()
        {
            textBoxFactoryName.Text = "";
            textBoxNumberWorkshops.Text = "";
            textBoxAmountWorkers.Text = "";
            textBoxAmountCraftsmen.Text = "";
            textBoxSalaryWorker.Text = ""; 
            textBoxSalaryCraftsman.Text = "";
            textBoxProfitWorker.Text = "";
            textBoxProfitCraftsman.Text = "";
        }

        //перевірка на повторюваність
        bool checkFactoriesRepeat(string factoryNameCheck)
        {
            bool result = false;

            if (arr.Count() != 0)
            {
                for (int i = 0; i < arr.Count(); i++)
                {
                    if (arr.ElementAt(i).factoryName == factoryNameCheck)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        //фукнція показу інформації на головному екрані за допомогою DataGridView
        public void addInfoToDataGridView(DataGridView dataGridView, int index, int statusWork)
        {
            HashSet<Factory> fArr = new HashSet<Factory>();

            if (statusWork == 1)
                fArr = arr;
            else
                fArr = arrCopy;

            dataGridView.Rows.Clear();
            dataGridView.Rows.Add("Назва заводу", fArr.ElementAt(index).factoryName);
            dataGridView.Rows.Add("К-сть цехів", fArr.ElementAt(index).numberWorkshops);
            dataGridView.Rows.Add("К-сть робітників", fArr.ElementAt(index).amountWorkers);
            dataGridView.Rows.Add("К-сть майстрів", fArr.ElementAt(index).amountCraftsmen);
            dataGridView.Rows.Add("ЗП одного робітника", fArr.ElementAt(index).salaryWorker + " грн");
            dataGridView.Rows.Add("ЗП одного майстра", fArr.ElementAt(index).salaryCraftman + " грн");
            dataGridView.Rows.Add("Прибуток за 1 місяць з одного робітника", fArr.ElementAt(index).profitWorker);
            dataGridView.Rows.Add("Прибуток за 1 місяць з одного майстра", fArr.ElementAt(index).profitCraftman);
        }
    }
}
