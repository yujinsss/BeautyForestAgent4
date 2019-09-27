using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace BeautyForestAgent
{
    public partial class FormMemo : Form
    {
        public FormMemo()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("건의사항이 보내졌습니다.", "건의사항 발송");
            this.Close();
        }

        private void BtnLoadFileSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = this.loadFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtLoadFile.Text = this.loadFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소하셨습니다", "알림");
                    break;
            }

        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            if (txtLoadFile.Text == "")
            {
                MessageBox.Show("읽을 파일을 선택해 주세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!File.Exists(txtLoadFile.Text))
            {
                MessageBox.Show("읽을 파일이 없습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (StreamReader sr = new StreamReader(this.txtLoadFile.Text))
            {
                this.txtLoadText.Text = sr.ReadToEnd();
            }

        }

        private void BtnSaveFileSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtSaveFile.Text = this.saveFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소하셨습니다", "알림");
                    break;
            }

        }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            if (txtSaveFile.Text == "")
            {
                MessageBox.Show("저장할 파일을 선택해 주세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(this.txtSaveFile.Text))
                {
                    sw.WriteLine(this.txtSaveText.Text);
                }
                MessageBox.Show("파일 저장 성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("파일 저장에 실패했습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
    }
    }
}
