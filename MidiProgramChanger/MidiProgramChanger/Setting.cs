using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiProgramChanger
{
    public partial class Setting : Form
    {

        public SettingList NewSettingList { get; set; }
        private readonly SettingList _oldSettingList;

        public Setting(SettingList settingList, string dispTab = "")
        {
            InitializeComponent();

            NewSettingList = settingList;
            _oldSettingList = settingList;


            switch (dispTab.ToUpper())
            {
                case "ENV":
                    tabControl1.SelectedTab = TabPageEnv;
                    break;
                default:
                    tabControl1.SelectedTab = TabPageInst;
                    break;
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            instrumentBindingSource.DataSource = NewSettingList.InstrumentList;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            XmlController<SettingList>.TrySerialize(SettingList.SettingFileName, NewSettingList);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            NewSettingList = _oldSettingList;
        }

        private void DgInst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgInst.BeginEdit(true);
        }

        private void DgInst_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                _ = MessageBox.Show(this,
                                    $"({e.ColumnIndex}, {e.RowIndex}) のセルでエラーが発生しました。\r\n説明: {e.Exception.Message}",
                                    "エラーが発生しました",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }
    }
}
