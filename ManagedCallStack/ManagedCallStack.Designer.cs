namespace ManagedCallStack
{
    partial class managedCallStack
    {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.processes = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.callStack = new System.Windows.Forms.RichTextBox();
            this.stackObjects = new System.Windows.Forms.DataGridView();
            this.threadsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.processes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.threadsGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1141, 1188);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 0;
            // 
            // processes
            // 
            this.processes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processes.FormattingEnabled = true;
            this.processes.Location = new System.Drawing.Point(0, 0);
            this.processes.Name = "processes";
            this.processes.Size = new System.Drawing.Size(191, 1188);
            this.processes.TabIndex = 0;
            this.processes.SelectedIndexChanged += new System.EventHandler(this.processes_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 150);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.callStack);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.stackObjects);
            this.splitContainer2.Size = new System.Drawing.Size(946, 1038);
            this.splitContainer2.SplitterDistance = 544;
            this.splitContainer2.TabIndex = 3;
            // 
            // callStack
            // 
            this.callStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.callStack.Location = new System.Drawing.Point(0, 0);
            this.callStack.Name = "callStack";
            this.callStack.Size = new System.Drawing.Size(544, 1038);
            this.callStack.TabIndex = 0;
            this.callStack.Text = "";
            this.callStack.WordWrap = false;
            // 
            // stackObjects
            // 
            this.stackObjects.AllowUserToAddRows = false;
            this.stackObjects.AllowUserToDeleteRows = false;
            this.stackObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stackObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackObjects.Location = new System.Drawing.Point(0, 0);
            this.stackObjects.MultiSelect = false;
            this.stackObjects.Name = "stackObjects";
            this.stackObjects.Size = new System.Drawing.Size(398, 1038);
            this.stackObjects.TabIndex = 0;
            // 
            // threadsGrid
            // 
            this.threadsGrid.AllowUserToAddRows = false;
            this.threadsGrid.AllowUserToDeleteRows = false;
            this.threadsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.threadsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.threadsGrid.Location = new System.Drawing.Point(0, 0);
            this.threadsGrid.MultiSelect = false;
            this.threadsGrid.Name = "threadsGrid";
            this.threadsGrid.ReadOnly = true;
            this.threadsGrid.Size = new System.Drawing.Size(946, 150);
            this.threadsGrid.TabIndex = 2;
            this.threadsGrid.SelectionChanged += new System.EventHandler(this.threadsGrid_SelectionChanged);
            // 
            // managedCallStack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 1188);
            this.Controls.Add(this.splitContainer1);
            this.Name = "managedCallStack";
            this.Text = "Managed CallStack";
            this.Load += new System.EventHandler(this.managedCallStack_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox processes;
        private System.Windows.Forms.DataGridView threadsGrid;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox callStack;
        private System.Windows.Forms.DataGridView stackObjects;
    }
}

