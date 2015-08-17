namespace RESTJsonWin
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
            this._MethodCbx = new System.Windows.Forms.ComboBox();
            this._ServerTxt = new System.Windows.Forms.TextBox();
            this._PathTxt = new System.Windows.Forms.TextBox();
            this._BodyTxt = new System.Windows.Forms.TextBox();
            this._ResponseTxt = new System.Windows.Forms.TextBox();
            this._GoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _MethodCbx
            // 
            this._MethodCbx.FormattingEnabled = true;
            this._MethodCbx.Location = new System.Drawing.Point(12, 12);
            this._MethodCbx.Name = "_MethodCbx";
            this._MethodCbx.Size = new System.Drawing.Size(121, 24);
            this._MethodCbx.TabIndex = 0;
            // 
            // _ServerTxt
            // 
            this._ServerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ServerTxt.Location = new System.Drawing.Point(149, 13);
            this._ServerTxt.Name = "_ServerTxt";
            this._ServerTxt.Size = new System.Drawing.Size(385, 24);
            this._ServerTxt.TabIndex = 1;
            // 
            // _PathTxt
            // 
            this._PathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._PathTxt.Location = new System.Drawing.Point(12, 52);
            this._PathTxt.Name = "_PathTxt";
            this._PathTxt.Size = new System.Drawing.Size(374, 24);
            this._PathTxt.TabIndex = 2;
            // 
            // _BodyTxt
            // 
            this._BodyTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._BodyTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BodyTxt.Location = new System.Drawing.Point(12, 96);
            this._BodyTxt.Multiline = true;
            this._BodyTxt.Name = "_BodyTxt";
            this._BodyTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._BodyTxt.Size = new System.Drawing.Size(522, 351);
            this._BodyTxt.TabIndex = 3;
            // 
            // _ResponseTxt
            // 
            this._ResponseTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ResponseTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ResponseTxt.Location = new System.Drawing.Point(564, 13);
            this._ResponseTxt.Multiline = true;
            this._ResponseTxt.Name = "_ResponseTxt";
            this._ResponseTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._ResponseTxt.Size = new System.Drawing.Size(588, 434);
            this._ResponseTxt.TabIndex = 4;
            // 
            // _GoBtn
            // 
            this._GoBtn.Location = new System.Drawing.Point(407, 52);
            this._GoBtn.Name = "_GoBtn";
            this._GoBtn.Size = new System.Drawing.Size(127, 23);
            this._GoBtn.TabIndex = 5;
            this._GoBtn.Text = "GO";
            this._GoBtn.UseVisualStyleBackColor = true;
            this._GoBtn.Click += new System.EventHandler(this._GoBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 459);
            this.Controls.Add(this._GoBtn);
            this.Controls.Add(this._ResponseTxt);
            this.Controls.Add(this._BodyTxt);
            this.Controls.Add(this._PathTxt);
            this.Controls.Add(this._ServerTxt);
            this.Controls.Add(this._MethodCbx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _MethodCbx;
        private System.Windows.Forms.TextBox _ServerTxt;
        private System.Windows.Forms.TextBox _PathTxt;
        private System.Windows.Forms.TextBox _BodyTxt;
        private System.Windows.Forms.TextBox _ResponseTxt;
        private System.Windows.Forms.Button _GoBtn;
    }
}

