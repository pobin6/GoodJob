using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
namespace WindowsFormsApplication2
{
    partial class Form1
    {
        //虚拟数据
        private List<string[]> spotCheckData = new List<string[]>();
        private List<string[]> spotCheckData2 = new List<string[]>();
        string[] row = { "1", "电机", "各紧固件", "无松、缺现象", "周", "未通过"};
        string[] title = { "序号", "点检项目", "点检内容", "点检描述", "点检时间", "是否通过" };
        string[] title2 = { "序号", "点检员编号", "是否存在未通过", "未通过描述", "点检完成时间", "点检员" };
        //窗口像素
        private int formWidth = 750;
        private int formHeight = 730;
        //操作按钮之间的距离
        int dis = 100;
        //最后的信息输入窗
        manager m;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //虚拟数据----------------------------------------------
            for (int i = 0; i < 37;i++ )
            {
                row[0] = i + 1 + "";
                spotCheckData.Add((string[])row.Clone());
            }
            row[0] = "" + 35;
            //----------------------------------------------------

            //空间初始化
            this.spotCheck = new SpotCheckDataGridView(title,spotCheckData,formWidth,formHeight);
            this.spotCheckNote = new SpotCheckDataGridView(title2, spotCheckData2, formWidth, formHeight);
            this.lastPageBtn = new System.Windows.Forms.Button();
            this.nextPageBtn = new System.Windows.Forms.Button();
            this.totalSureBtn = new System.Windows.Forms.Button();
            this.allowAllBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spotCheck)).BeginInit();
            this.SuspendLayout();
            
            //
            // spotCheck
            //
            this.spotCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spotCheck.Location = new System.Drawing.Point(formWidth / 80, formHeight / 50);
            this.spotCheck.Name = "spotCheck";
            this.spotCheck.TabIndex = 0;
            this.spotCheck.CellClick += new DataGridViewCellEventHandler(this.View_CellClick);
            // 
            // spotCheckNote
            // 
            this.spotCheckNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spotCheckNote.Location = new System.Drawing.Point(formWidth / 80, formHeight / 2 + 50 - formHeight / 50);
            this.spotCheckNote.Name = "spotCheckNote";
            this.spotCheckNote.TabIndex = 0;

            //
            //lastPageBtn
            //
            this.lastPageBtn.Location = new System.Drawing.Point(formWidth / 2, formHeight / 2 - 30);
            this.lastPageBtn.Name = "lastPageBtn";
            this.lastPageBtn.Size = new System.Drawing.Size(formWidth / 11, formWidth / 22);
            this.lastPageBtn.TabIndex = 0;
            this.lastPageBtn.Text = "上一页";
            this.lastPageBtn.UseVisualStyleBackColor = true;
            this.lastPageBtn.Click += new System.EventHandler(this.lastPage_Click);
            //
            //nextPageBtn
            //
            this.nextPageBtn.Location = new System.Drawing.Point(formWidth / 2 + dis, formHeight / 2 - 30);
            this.nextPageBtn.Name = "nextPageBtn";
            this.nextPageBtn.Size = new System.Drawing.Size(formWidth / 11, formWidth / 22);
            this.nextPageBtn.TabIndex = 0;
            this.nextPageBtn.Text = "下一页";
            this.nextPageBtn.UseVisualStyleBackColor = true;
            this.nextPageBtn.Click += new System.EventHandler(this.nextPage_Click);
            //
            //allowAllBtn
            //
            this.allowAllBtn.Location = new System.Drawing.Point(formWidth / 2 + 2 * dis, formHeight / 2 - 30);
            this.allowAllBtn.Name = "allowAllBtn";
            this.allowAllBtn.Size = new System.Drawing.Size(formWidth / 11, formWidth / 22);
            this.allowAllBtn.TabIndex = 0;
            this.allowAllBtn.Text = "本页全通过";
            this.allowAllBtn.UseVisualStyleBackColor = true;
            this.allowAllBtn.Click += new System.EventHandler(this.allowAll_Click);
            //
            //totalSureBtn
            //
            this.totalSureBtn.Location = new System.Drawing.Point(formWidth / 2 + 3 * dis, formHeight / 2 - 30);
            this.totalSureBtn.Name = "totalSureBtn";
            this.totalSureBtn.Size = new System.Drawing.Size(formWidth / 11, formWidth / 22);
            this.totalSureBtn.TabIndex = 0;
            this.totalSureBtn.Text = "最后确认";
            this.totalSureBtn.UseVisualStyleBackColor = true;
            this.totalSureBtn.Enabled = false;
            this.totalSureBtn.Click += new System.EventHandler(this.totalSure_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(formWidth, formHeight);
            this.Controls.Add(this.spotCheck);
            this.Controls.Add(this.spotCheckNote);
            this.Controls.Add(this.lastPageBtn);
            this.Controls.Add(this.nextPageBtn);
            this.Controls.Add(this.allowAllBtn);
            this.Controls.Add(this.totalSureBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.spotCheck)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private WindowsFormsApplication2.SpotCheckDataGridView spotCheck;
        private WindowsFormsApplication2.SpotCheckDataGridView spotCheckNote;
        private System.Windows.Forms.Button lastPageBtn;
        private System.Windows.Forms.Button nextPageBtn;
        private System.Windows.Forms.Button allowAllBtn;
        private System.Windows.Forms.Button totalSureBtn;
    }
}

