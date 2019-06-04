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
using MidiProgramChanger.Properties;

namespace MidiProgramChanger
{
    public partial class Main : Form
    {
        private SettingList _settingList;

        public Main()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();

            if (!XmlController<SettingList>.TryDeserialize(SettingList.SettingFileName, out _settingList))
            {
                _settingList = new SettingList
                {
                    InstrumentList = new List<Instrument>()
                };
            }

            if (2 <= args.Length)
            {
                Parallel.For(0, args.Length - 1, i =>
                {

                    string exportPath = Common.GetNewFilePath(args[i + 1], Common.ExportType.SerialNumber);
                    MidiController midiCon = new MidiController(_settingList);
                    if (midiCon.Convert(args[i + 1],  exportPath))
                    {
                        _ = MessageBox.Show(this,
                                            $"{exportPath}にファイルを出力しました。",
                                            "成功",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    }
                });
            }
        }


        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (FileDialog.TryGetOpenPath(out string filePath))
            {
                txtImportPath.Text = filePath;
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            var midiCon = new MidiController(_settingList);

            string exportPath = Common.GetNewFilePath(txtImportPath.Text, Common.ExportType.SerialNumber);
           
            if (midiCon.Convert(txtImportPath.Text, exportPath))
            {
                _ = MessageBox.Show(this,
                                    $"{exportPath}にファイルを出力しました。",
                                    "成功",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting setting;

            if (sender == MenuEnv)
            {
                setting = new Setting(_settingList, "ENV");
            }
            else
            {
                setting = new Setting(_settingList);
            }

            if (setting.ShowDialog() == DialogResult.OK)
            {
                _settingList = setting.NewSettingList;
            }

        }
    }
}
