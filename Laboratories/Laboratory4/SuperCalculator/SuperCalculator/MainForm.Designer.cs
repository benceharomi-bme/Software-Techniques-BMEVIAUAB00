namespace SuperCalculator
{
    partial class MainForm
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
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.buttonCalcResult = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxParam2 = new System.Windows.Forms.TextBox();
            this.textBoxParam1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewResult
            // 
            this.listViewResult.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.listViewResult.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
            this.listViewResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewResult.Location = new System.Drawing.Point( 12, 134 );
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size( 220, 123 );
            this.listViewResult.TabIndex = 14;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 203;
            // 
            // buttonCalcResult
            // 
            this.buttonCalcResult.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.buttonCalcResult.Location = new System.Drawing.Point( 12, 68 );
            this.buttonCalcResult.Name = "buttonCalcResult";
            this.buttonCalcResult.Size = new System.Drawing.Size( 220, 38 );
            this.buttonCalcResult.TabIndex = 13;
            this.buttonCalcResult.Text = "Calculate Result";
            this.buttonCalcResult.UseVisualStyleBackColor = true;
            this.buttonCalcResult.Click += new System.EventHandler( this.buttonCalcResult_Click );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 9, 118 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 40, 13 );
            this.label3.TabIndex = 12;
            this.label3.Text = "Result:";
            // 
            // textBoxParam2
            // 
            this.textBoxParam2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.textBoxParam2.Location = new System.Drawing.Point( 82, 29 );
            this.textBoxParam2.Name = "textBoxParam2";
            this.textBoxParam2.Size = new System.Drawing.Size( 150, 20 );
            this.textBoxParam2.TabIndex = 11;
            // 
            // textBoxParam1
            // 
            this.textBoxParam1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.textBoxParam1.Location = new System.Drawing.Point( 82, 6 );
            this.textBoxParam1.Name = "textBoxParam1";
            this.textBoxParam1.Size = new System.Drawing.Size( 150, 20 );
            this.textBoxParam1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 9, 32 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 67, 13 );
            this.label2.TabIndex = 9;
            this.label2.Text = "Parameter 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 9, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 67, 13 );
            this.label1.TabIndex = 8;
            this.label1.Text = "Parameter 1:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 247, 273 );
            this.Controls.Add( this.listViewResult );
            this.Controls.Add( this.buttonCalcResult );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.textBoxParam2 );
            this.Controls.Add( this.textBoxParam1 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.MinimumSize = new System.Drawing.Size( 255, 300 );
            this.Name = "MainForm";
            this.Text = "Super Calculator";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonCalcResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxParam2;
        private System.Windows.Forms.TextBox textBoxParam1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

