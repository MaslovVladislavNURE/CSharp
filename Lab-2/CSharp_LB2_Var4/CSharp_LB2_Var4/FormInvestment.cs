using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharp_LB2_Var4
{
    //форма інвестиції в завод
    public partial class FormFactory
    {
        Form formInvestment;
        TextBox textBoxInvestment;

        public void initializeFormInvestment()
        {
            formInvestment = new Form()
            {
                Width = 625,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = "Інвестиція на найм співробітників"
            };
            formInvestment.Show();

            textBoxInvestment = new TextBox()
            {
                Location = new Point(20, 50),
                Width = 200,
            };
            formInvestment.Controls.Add(textBoxInvestment);

            Button buttonInvestment = new Button()
            {
                Location = new Point(240, 50),
                Width = 80,
                Height = 30,
                Text = "Інвестувати"
            };
            buttonInvestment.Click += new System.EventHandler(buttonInvestmentOnClick);
            formInvestment.Controls.Add(buttonInvestment);
        }

        private void buttonInvestmentOnClick(object sender, EventArgs eventArgs)
        {
            int investmentParse;
            Int32.TryParse(textBoxInvestment.Text, out investmentParse);
            if (investmentParse <= 0)
                MessageBox.Show("Неправильний формат даних!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int result = arr.ElementAt(comboBoxFactories.SelectedIndex).income(investmentParse);
                MessageBox.Show("Приблизно можливий прибуток складає: " + result + " грн", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
