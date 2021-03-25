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
            this.selectShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addShapeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separateGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveShapesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.selectShapeToolStripMenuItem,
            this.addShapeToolStripMenuItem1,
            this.makeGroupToolStripMenuItem,
            this.separateGroupToolStripMenuItem,
            this.saveShapesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1288, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectShapeToolStripMenuItem
            // 
            this.selectShapeToolStripMenuItem.Name = "selectShapeToolStripMenuItem";
            this.selectShapeToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.selectShapeToolStripMenuItem.Text = "Pointer";
            this.selectShapeToolStripMenuItem.ToolTipText = "Click on object to manipulate with it.";
            this.selectShapeToolStripMenuItem.Click += new System.EventHandler(this.selectShapeToolStripMenuItem_Click);
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
            this.addShapeToolStripMenuItem1.ToolTipText = "Choose a shape from list.";
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.ToolTipText = "Click on form to set a center of the circle.";
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
            // makeGroupToolStripMenuItem
            // 
            this.makeGroupToolStripMenuItem.Name = "makeGroupToolStripMenuItem";
            this.makeGroupToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.makeGroupToolStripMenuItem.Text = "Make group";
            this.makeGroupToolStripMenuItem.ToolTipText = "Click here and click needed shapes to highlight them.\r\nClick here once again to f" +
    "inish making group.";
            this.makeGroupToolStripMenuItem.Click += new System.EventHandler(this.makeGroupToolStripMenuItem_Click);
            // 
            // separateGroupToolStripMenuItem
            // 
            this.separateGroupToolStripMenuItem.Name = "separateGroupToolStripMenuItem";
            this.separateGroupToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.separateGroupToolStripMenuItem.Text = "Separate group";
            this.separateGroupToolStripMenuItem.ToolTipText = "Choose a group and click here to ungroup it";
            this.separateGroupToolStripMenuItem.Click += new System.EventHandler(this.separateGroupToolStripMenuItem_Click);
            // 
            // saveShapesToolStripMenuItem
            // 
            this.saveShapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveShapesToolStripMenuItem1,
            this.loadShapesToolStripMenuItem});
            this.saveShapesToolStripMenuItem.Name = "saveShapesToolStripMenuItem";
            this.saveShapesToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.saveShapesToolStripMenuItem.Text = "File";
            // 
            // saveShapesToolStripMenuItem1
            // 
            this.saveShapesToolStripMenuItem1.Name = "saveShapesToolStripMenuItem1";
            this.saveShapesToolStripMenuItem1.Size = new System.Drawing.Size(166, 26);
            this.saveShapesToolStripMenuItem1.Text = "Save shapes";
            this.saveShapesToolStripMenuItem1.Click += new System.EventHandler(this.saveShapesToolStripMenuItem1_Click);
            // 
            // loadShapesToolStripMenuItem
            // 
            this.loadShapesToolStripMenuItem.Name = "loadShapesToolStripMenuItem";
            this.loadShapesToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.loadShapesToolStripMenuItem.Text = "Load shapes";
            this.loadShapesToolStripMenuItem.Click += new System.EventHandler(this.loadShapesToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.treeView1.Location = new System.Drawing.Point(1006, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(282, 693);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1006, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(282, 34);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1288, 721);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
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
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separateGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveShapesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadShapesToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

