using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class SpotCheckDataGridView : DataGridView
    {
        private int pageSize = 10;     //每页显示行数
        private int nMax = 0;         //总记录数
        private int pageCount = 0;    //页数＝总记录数/每页显示行数
        private int pageCurrent = 1;   //当前页号
        private int passCount = 0;      //记录当前页检查通过的行数
        private int allPassCount = 0;   //所有页检查通过的行数
        private List<string[]> rowsData;     //表格中每一行的数据
        private string[] title;         //表格的表头
        public SpotCheckDataGridView(string[] title, List<string[]> rowsData, int formWidth, int formHeight)
        {
            formHeight =  (formHeight / 2 - 50)/ 11 * 11;
            formWidth = (formWidth - 2 * formWidth / 80) / 11 * 11;
            this.title = title;
            this.rowsData = rowsData;
            // 
            // spotCheck
            // 
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Size = new System.Drawing.Size(formWidth, formHeight);
            this.TabIndex = 0;
            this.RowTemplate.Height = formHeight / 11;
            this.RowHeadersVisible = false;
            this.ColumnHeadersVisible = false;
            //this.this.ColumnHeadersHeight = 100;
            //this.this.RowHeadersWidth = this.Height/5;
            this.ColumnCount = 6;
            this.Font = new Font("宋体", 11);
            for (int i = 0; i < 5;i++)
                this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.RowsDefaultCellStyle.BackColor = Color.FromArgb(142,229,238);
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(193,255,193);
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //this.this.AutoSize = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.AllowUserToAddRows = false;
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.Rows.Add(title);
            this.Rows[0].DefaultCellStyle.BackColor = Color.White;
            this.NMax = rowsData.Count;
            if (this.NMax <= this.PageSize)
            {
                foreach (string[] rowArray in rowsData)
                {
                    this.Rows.Add(rowArray);
                }
                this.PageCount = 1;
                this.PageCurrent = 1;
            }
            else
            {
                this.PageCount = this.NMax / this.PageSize;
                for (int i = 0; i < 10; i++)
                    this.Rows.Add(rowsData[i]);

                //this.this.ColumnCount = 6;
            }
            this.RowCount = 11;
            this.ScrollBars=ScrollBars.None;
            this.CellClick += new DataGridViewCellEventHandler(this.View_CellClick);
        }
        //点检表的检查通过事件
        private void View_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SpotCheckDataGridView spotCheck = (SpotCheckDataGridView)sender;
            if (e.ColumnIndex == 5 && e.RowIndex > 0)
            {
                if (spotCheck[5, e.RowIndex].Value != null && spotCheck[5, e.RowIndex].Value.Equals("未通过"))
                {
                    spotCheck[5, e.RowIndex].Value = "通过";
                    spotCheck.rowsData[int.Parse((string)spotCheck[0, e.RowIndex].Value) - 1][5] = (string)"通过";
                    spotCheck.PassCount++;
                    spotCheck.allPassCount += 1;
                    if (spotCheck.PassCount == 10)
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
                        spotCheck.PassCount = 0;
                    }
                }
                else
                    if (spotCheck[5, e.RowIndex].Value != null)
                    {
                        spotCheck.PassCount--;
                        spotCheck.allPassCount -= 1;
                        spotCheck[5, e.RowIndex].Value = "未通过";
                        spotCheck.rowsData[int.Parse((string)spotCheck[0, e.RowIndex].Value) - 1][5] = "未通过";
                    }
                //for(int )
            }
        }
        public int PageSize
        {
            set
            {
                pageSize = value;
            }
            get
            {
                return pageSize;
            }
        }
        public int NMax
        {
            set
            {
                nMax = value;
            }
            get
            {
                return nMax;
            }
        }
        public int PageCount
        {
            set
            {
                pageCount = value;
            }
            get
            {
                return pageCount;
            }
        }
        public int PageCurrent
        {
            set
            {
                pageCurrent = value;
            }
            get
            {
                return pageCurrent;
            }
        }
        public int PassCount
        {
            set
            {
                passCount = value;
            }
            get
            {
                return passCount;
            }
        }
        public int AllPassCount
        {
            set
            {
                allPassCount = value;
            }
            get
            {
                return allPassCount;
            }
        }
        public string[] Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
            }
        }
        public List<string[]> RowsData
        {
            set
            {
                rowsData = value;
            }
            get
            {
                return rowsData;
            }
        }
    }
    class SpotCheckButton:Button
    {

    }
}
