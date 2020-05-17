namespace Signals
{
    partial class GraphicsSignalView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plusB = new System.Windows.Forms.Button();
            this.minusB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // plusB
            // 
            this.plusB.Location = new System.Drawing.Point(36, 21);
            this.plusB.Name = "plusB";
            this.plusB.Size = new System.Drawing.Size(75, 23);
            this.plusB.TabIndex = 0;
            this.plusB.Text = "+";
            this.plusB.UseVisualStyleBackColor = true;
            this.plusB.Click += new System.EventHandler(this.plusB_Click);
            // 
            // minusB
            // 
            this.minusB.Location = new System.Drawing.Point(36, 84);
            this.minusB.Name = "minusB";
            this.minusB.Size = new System.Drawing.Size(75, 23);
            this.minusB.TabIndex = 1;
            this.minusB.Text = "-";
            this.minusB.UseVisualStyleBackColor = true;
            this.minusB.Click += new System.EventHandler(this.minusB_Click);
            // 
            // GraphicsSignalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.minusB);
            this.Controls.Add(this.plusB);
            this.Name = "GraphicsSignalView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button plusB;
        private System.Windows.Forms.Button minusB;
    }
}
