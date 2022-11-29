using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharp_LB2_Var4
{
    public partial class FormFactory
    {
        Form formMerge;
        ComboBox comboBoxMerge1, comboBoxMerge2;

        public void initializeFormMerge()
        {
            formMerge = new Form()
            {
                Width = 625,
                Height = 170,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = "Об'єднання заводів"
            };
            formMerge.Show();

            Label label1 = new Label()
            {
                Location = new Point(20, 20),
                Width = 280,
                Text = "Оберіть завод, в який буде виконано об'єднання"
            };
            formMerge.Controls.Add(label1);

            Label label2 = new Label()
            {
                Location = new Point(310, 20),
                Width = 280,
                Text = "Оберіть завод, з якого буде виконано об'єднання"
            };
            formMerge.Controls.Add(label2);

            comboBoxMerge1 = new ComboBox()
            {
                Location = new Point(20, 50),
                Width = 280
            };
            addComboBoxInfo(comboBoxMerge1);
            formMerge.Controls.Add(comboBoxMerge1);

            comboBoxMerge2 = new ComboBox()
            {
                Location = new Point(310, 50),
                Width = 280
            };
            addComboBoxInfo(comboBoxMerge2);
            formMerge.Controls.Add(comboBoxMerge2);

            Button buttonDone = new Button()
            {
                Location = new Point(275, 80),
                Width = 60,
                Height = 30,
                Text = "Done"
            };
            buttonDone.Click += new System.EventHandler(buttonDoneMergeOnClick);
            formMerge.Controls.Add(buttonDone);
        }

        private void buttonDoneMergeOnClick(object sender, EventArgs eventArgs)
        {
            if (comboBoxMerge1.SelectedIndex == -1 || comboBoxMerge2.SelectedIndex == -1)
                MessageBox.Show("Оберіть заводи для об'єднання!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxMerge1.SelectedIndex == comboBoxMerge2.SelectedIndex)
                MessageBox.Show("Не можна обирати один і той самий завод для об'єднання!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                arr.ElementAt(comboBoxMerge1.SelectedIndex).numberWorkshops += arr.ElementAt(comboBoxMerge2.SelectedIndex).numberWorkshops;
                arr.ElementAt(comboBoxMerge1.SelectedIndex).amountWorkers += arr.ElementAt(comboBoxMerge2.SelectedIndex).amountWorkers;
                arr.ElementAt(comboBoxMerge1.SelectedIndex).amountCraftsmen += arr.ElementAt(comboBoxMerge2.SelectedIndex).amountCraftsmen;

                HashSet<Factory> tempArr = new HashSet<Factory>();
                for (int i = 0; i < arr.Count(); i++)
                {
                    if (i != comboBoxMerge2.SelectedIndex)
                        tempArr.Add(arr.ElementAt(i));
                }
                arr = tempArr;
                comboBoxFactories.Items.Clear();
                addComboBoxInfo(comboBoxFactories);
                MessageBox.Show("Успішне об'єднання!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formMerge.Close();
            }
        }
    }
}
