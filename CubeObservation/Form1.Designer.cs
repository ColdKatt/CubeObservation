namespace CubeObservation
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.DrawModeButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.TransparencyButton = new System.Windows.Forms.Button();
            this.ColorChangeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.AutoSize = true;
            this.openGLControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 40;
            this.openGLControl1.Location = new System.Drawing.Point(0, 0);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(784, 561);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLInitialized += new System.EventHandler(this.openGLControl1_OpenGLInitialized);
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseDown);
            this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseMove);
            this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseUp);
            this.openGLControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseWheel);
            // 
            // DrawModeButton
            // 
            this.DrawModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DrawModeButton.Location = new System.Drawing.Point(12, 489);
            this.DrawModeButton.Name = "DrawModeButton";
            this.DrawModeButton.Size = new System.Drawing.Size(241, 60);
            this.DrawModeButton.TabIndex = 1;
            this.DrawModeButton.Text = "Draw Mode: ";
            this.DrawModeButton.UseVisualStyleBackColor = true;
            this.DrawModeButton.Click += new System.EventHandler(this.DrawModeButton_Click);
            // 
            // TransparencyButton
            // 
            this.TransparencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TransparencyButton.Location = new System.Drawing.Point(274, 489);
            this.TransparencyButton.Name = "TransparencyButton";
            this.TransparencyButton.Size = new System.Drawing.Size(241, 60);
            this.TransparencyButton.TabIndex = 2;
            this.TransparencyButton.Text = "Transparency: ";
            this.TransparencyButton.UseVisualStyleBackColor = true;
            this.TransparencyButton.Click += new System.EventHandler(this.TransparencyButton_Click);
            // 
            // ColorChangeButton
            // 
            this.ColorChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorChangeButton.Location = new System.Drawing.Point(531, 489);
            this.ColorChangeButton.Name = "ColorChangeButton";
            this.ColorChangeButton.Size = new System.Drawing.Size(241, 60);
            this.ColorChangeButton.TabIndex = 3;
            this.ColorChangeButton.Text = "Change Color";
            this.ColorChangeButton.UseVisualStyleBackColor = true;
            this.ColorChangeButton.Click += new System.EventHandler(this.ColorChangeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ColorChangeButton);
            this.Controls.Add(this.TransparencyButton);
            this.Controls.Add(this.DrawModeButton);
            this.Controls.Add(this.openGLControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.Button DrawModeButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button TransparencyButton;
        private System.Windows.Forms.Button ColorChangeButton;
    }
}

