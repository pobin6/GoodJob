using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void threadOver();
        //上一页
        private void lastPage_Click(object sender, EventArgs e)
        {
            if (spotCheck.PageCurrent > 1)
            {
                spotCheck.Rows.Clear();
                spotCheck.Rows.Add(spotCheck.Title);
                spotCheck.Rows[0].DefaultCellStyle.BackColor = Color.White;
                spotCheck.PageCurrent--;
                for (int i = (spotCheck.PageCurrent - 1) * spotCheck.PageSize; i < (spotCheck.PageCurrent) * spotCheck.PageSize; i++)
                    spotCheck.Rows.Add(spotCheck.RowsData[i]);
            }
            spotCheck.RowCount = 11;
        }
        //下一页
        private void nextPage_Click(object sender, EventArgs e)
        {
            if (spotCheck.PageCurrent <= spotCheck.PageCount)
            {
                spotCheck.Rows.Clear();
                spotCheck.Rows.Add(spotCheck.Title);
                spotCheck.Rows[0].DefaultCellStyle.BackColor = Color.White;
                if (spotCheck.NMax - spotCheck.PageSize * spotCheck.PageCurrent <= spotCheck.PageSize)
                {
                    for (int i = spotCheck.PageCurrent * spotCheck.PageSize; i < spotCheck.NMax; i++)
                        spotCheck.Rows.Add(spotCheck.RowsData[i]);
                    spotCheck.PageCurrent++;
                }
                else
                {
                    for (int i = spotCheck.PageCurrent * spotCheck.PageSize; i < (spotCheck.PageCurrent + 1) * spotCheck.PageSize; i++)
                        spotCheck.Rows.Add(spotCheck.RowsData[i]);
                    spotCheck.PageCurrent++;
                }
                spotCheck.RowCount = 11;
            }
        }
        //本页全通过
        private void allowAll_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < spotCheck.RowCount; i++)
            {
                if (spotCheck[0, i].Value != null&&spotCheck[5,i].Value.Equals("未通过"))
                {
                    spotCheck.AllPassCount += 1;
                    spotCheck[5, i].Value = "通过";
                    spotCheck.RowsData[i - 1 + (spotCheck.PageCurrent - 1) * spotCheck.PageSize][5] = "通过";
                }
            }
            if (spotCheck.AllPassCount > spotCheck.NMax-10)
                this.totalSureBtn.Enabled = true;
        }

        //本页全通过
        private void totalSure_Click(object sender, EventArgs e)
        {
            DialogResult res=MessageBox.Show("一共存在"+(spotCheck.NMax-spotCheck.AllPassCount)+"个项目未通过点检，是否继续确认?","确认提示",MessageBoxButtons.YesNo);
            if(res.ToString()=="Yes")
            {
                this.m = new manager();
                this.m.Show();
                Thread t = new Thread(waitUser);
                t.Start();
                Console.WriteLine("asdf");
            }
        }
        public void waitUser()
        {
            while (this.m.name == null) ;
            Console.WriteLine(this.m.name);
            this.Invoke(new threadOver(showUser));
        }
        public void showUser()
        {
            int i;
            for (i = 1; i < 11; i++)
                if (this.spotCheckNote[1, i].Value == null)
                    break;
            this.spotCheckNote[0, i].Value = (i == 1) ? 1 : (int)this.spotCheckNote[0, i - 1].Value + 1;
            this.spotCheckNote[1, i].Value = "asasdf";
            this.spotCheckNote[2, i].Value = "sdfadsf";
            this.spotCheckNote[3, i].Value = "sdfasdfads";
            this.spotCheckNote[4, i].Value = "bcasxda";
            this.spotCheckNote[5, i].Value = this.m.name;
        }
        //点检表的检查通过事件
        private void View_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (spotCheck.AllPassCount > spotCheck.NMax - 10)
            {
                this.totalSureBtn.Enabled = true;
            }
            else if (spotCheck.AllPassCount <= spotCheck.NMax - 10)
                this.totalSureBtn.Enabled = false;
        }

    }
}