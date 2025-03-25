namespace SnowflakeIdGen
{
    partial class SnowflakeIdGenForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnGenerate = new Button();
			textBox1 = new TextBox();
			radioSnowflakeBase62 = new RadioButton();
			radioSnowflake = new RadioButton();
			radioGuid = new RadioButton();
			SuspendLayout();
			// 
			// btnGenerate
			// 
			btnGenerate.Location = new Point(24, 25);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(75, 23);
			btnGenerate.TabIndex = 0;
			btnGenerate.Text = "Generate";
			btnGenerate.UseVisualStyleBackColor = true;
			btnGenerate.Click += btnGenerate_Click;
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Location = new Point(24, 54);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(731, 354);
			textBox1.TabIndex = 1;
			// 
			// radioSnowflakeBase62
			// 
			radioSnowflakeBase62.AutoSize = true;
			radioSnowflakeBase62.Checked = true;
			radioSnowflakeBase62.Location = new Point(121, 27);
			radioSnowflakeBase62.Name = "radioSnowflakeBase62";
			radioSnowflakeBase62.Size = new Size(126, 19);
			radioSnowflakeBase62.TabIndex = 2;
			radioSnowflakeBase62.TabStop = true;
			radioSnowflakeBase62.Text = "Snowflake (Base62)";
			radioSnowflakeBase62.UseVisualStyleBackColor = true;
			radioSnowflakeBase62.CheckedChanged += radioSnowflakeBase62_CheckedChanged;
			// 
			// radioSnowflake
			// 
			radioSnowflake.AutoSize = true;
			radioSnowflake.Location = new Point(282, 27);
			radioSnowflake.Name = "radioSnowflake";
			radioSnowflake.Size = new Size(116, 19);
			radioSnowflake.TabIndex = 3;
			radioSnowflake.Text = "Snowflake (Int64)";
			radioSnowflake.UseVisualStyleBackColor = true;
			radioSnowflake.CheckedChanged += radioSnowflake_CheckedChanged;
			// 
			// radioGuid
			// 
			radioGuid.AutoSize = true;
			radioGuid.Location = new Point(439, 27);
			radioGuid.Name = "radioGuid";
			radioGuid.Size = new Size(50, 19);
			radioGuid.TabIndex = 4;
			radioGuid.Text = "Guid";
			radioGuid.UseVisualStyleBackColor = true;
			radioGuid.CheckedChanged += radioGuid_CheckedChanged;
			// 
			// SnowflakeIdGenForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(radioGuid);
			Controls.Add(radioSnowflake);
			Controls.Add(radioSnowflakeBase62);
			Controls.Add(textBox1);
			Controls.Add(btnGenerate);
			Name = "SnowflakeIdGenForm";
			Text = "Snowflake Id Generator";
			Load += SnowflakeIdGenForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnGenerate;
        private TextBox textBox1;
		private RadioButton radioSnowflakeBase62;
		private RadioButton radioSnowflake;
		private RadioButton radioGuid;
	}
}
