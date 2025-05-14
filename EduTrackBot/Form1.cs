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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EduTrackBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void buttoHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "EduTrack.chm");
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string helpFilePath = Path.Combine(Application.StartupPath, "EduTrack.chm");

            if (!File.Exists(helpFilePath))
            {
                MessageBox.Show("Файл справки не найден: " + helpFilePath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Help.ShowHelp(this, helpFilePath);
        }

        //обработка F1 для контекстной справки
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                var focusedControl = this.ActiveControl;
                if (focusedControl != null)
                {
                    string helpKeyword = "";

                    //определяем HelpID в зависимости от активного элемента
                    if (focusedControl == textBox1)
                        helpKeyword = "ID_TEXTBOX_INPUT";
                    else if (focusedControl == buttonHelp)
                        helpKeyword = "ID_BUTTON_HELP";
                    else
                        helpKeyword = "ID_MAIN_FORM"; //по умолчанию

                    string helpFilePath = Path.Combine(Application.StartupPath, "MyAppHelp.chm");
                    Help.ShowHelp(this, helpFilePath, HelpNavigator.Topic, helpKeyword);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
