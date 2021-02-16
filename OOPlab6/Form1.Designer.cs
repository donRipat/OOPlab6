namespace OOPlab6
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addShapeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 683);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addShapeToolStripMenuItem1,
            this.selectShapeToolStripMenuItem,
            this.deleteShapeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addShapeToolStripMenuItem1
            // 
            this.addShapeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.segmentToolStripMenuItem,
            this.polygonToolStripMenuItem});
            this.addShapeToolStripMenuItem1.Name = "addShapeToolStripMenuItem1";
            this.addShapeToolStripMenuItem1.Size = new System.Drawing.Size(92, 24);
            this.addShapeToolStripMenuItem1.Text = "Add shape";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.ToolTipText = "Click on form to set a center of the circle.\r\nClick one more time to set a radius" +
    ".";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // segmentToolStripMenuItem
            // 
            this.segmentToolStripMenuItem.Name = "segmentToolStripMenuItem";
            this.segmentToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.segmentToolStripMenuItem.Text = "Segment";
            this.segmentToolStripMenuItem.ToolTipText = "Click on form two times to set a segment.";
            this.segmentToolStripMenuItem.Click += new System.EventHandler(this.segmentToolStripMenuItem_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.polygonToolStripMenuItem.Text = "Polygon";
            this.polygonToolStripMenuItem.ToolTipText = "Click on form as much as you need to set vertexes of a polygon. \r\nTo finish the p" +
    "olygon click on the first vertex.";
            this.polygonToolStripMenuItem.Click += new System.EventHandler(this.polygonToolStripMenuItem_Click);
            // 
            // selectShapeToolStripMenuItem
            // 
            this.selectShapeToolStripMenuItem.Name = "selectShapeToolStripMenuItem";
            this.selectShapeToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.selectShapeToolStripMenuItem.Text = "Select shape";
            this.selectShapeToolStripMenuItem.Click += new System.EventHandler(this.selectShapeToolStripMenuItem_Click);
            // 
            // deleteShapeToolStripMenuItem
            // 
            this.deleteShapeToolStripMenuItem.Name = "deleteShapeToolStripMenuItem";
            this.deleteShapeToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.deleteShapeToolStripMenuItem.Text = "Delete shape";
            this.deleteShapeToolStripMenuItem.ToolTipText = "Highlight shapes with RMB and click here to delete them.";
            this.deleteShapeToolStripMenuItem.Click += new System.EventHandler(this.deleteShapeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Визуальный редактор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addShapeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem segmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectShapeToolStripMenuItem;
    }
}

