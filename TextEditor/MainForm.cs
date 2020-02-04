using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public interface IMainForm<T>
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }
    public partial class MainForm : Form, IMainForm<string>
    {
        public MainForm()
        {
            InitializeComponent();
            butOpenFile.Click += new EventHandler(butOpenFile_Click);
            butSaveFile.Click += new EventHandler(butSaveFile_Click);
            fldContent.TextChanged += new EventHandler(fldContent_TextChanged);
            butSelectFile.Click += butSelectFile_Click;
            numFont.ValueChanged += numFont_ValueChaged;

        }
        #region events
        void butOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty); /*при попадании в этот метод (при клике)
            строка 31 вызывает собитые FileOpenClick*/
            
        }
        void butSaveFile_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }
        void fldContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }
        #endregion
        #region IMainForm
        public string FilePath
        {
            get
            {
                return fldFilePath.Text;
            }
        }
        public string Content
        {
            get
            {
                return fldContent.Text;
            }
            set
            {
                fldContent.Text = value;
            }
        }
        public void SetSymbolCount(int count)
        {
            lblSymbolCount.Text = count.ToString();
        }
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        #endregion
        //Часть кода, которая занимается только внутренними элементами управления
        private void butSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt файлы|Все файлы|*.*";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }
        private void numFont_ValueChaged(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numFont.Value);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
