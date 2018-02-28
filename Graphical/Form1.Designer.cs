using System.ComponentModel;

namespace Graphical
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.inputTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.usePhaseCheckbox = new System.Windows.Forms.CheckBox();
            this.loadPhaseButton = new System.Windows.Forms.Button();
            this.inputPhaseImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputAmplitudeImage = new System.Windows.Forms.PictureBox();
            this.loadAmplitudeButton = new System.Windows.Forms.Button();
            this.outputTab = new System.Windows.Forms.TabPage();
            this.savePhaseButton = new System.Windows.Forms.Button();
            this.saveAmplitudeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outputPhaseImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outputAmplitudeImage = new System.Windows.Forms.PictureBox();
            this.goButton = new System.Windows.Forms.Button();
            this.loadAmplitudeDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadPhaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.forwardButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lambdaInput = new System.Windows.Forms.TextBox();
            this.zInput = new System.Windows.Forms.TextBox();
            this.deltaZInput = new System.Windows.Forms.TextBox();
            this.hInput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lambdaInputPanel = new System.Windows.Forms.Panel();
            this.zInputPanel = new System.Windows.Forms.Panel();
            this.deltaZInputPanel = new System.Windows.Forms.Panel();
            this.hInputPanel = new System.Windows.Forms.Panel();
            this.saveAmplitudeDialog = new System.Windows.Forms.SaveFileDialog();
            this.savePhaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.inputTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputPhaseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAmplitudeImage)).BeginInit();
            this.outputTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputPhaseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputAmplitudeImage)).BeginInit();
            this.lambdaInputPanel.SuspendLayout();
            this.zInputPanel.SuspendLayout();
            this.deltaZInputPanel.SuspendLayout();
            this.hInputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.inputTab);
            this.tabControl1.Controls.Add(this.outputTab);
            this.tabControl1.Location = new System.Drawing.Point(206, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // inputTab
            // 
            this.inputTab.Controls.Add(this.label2);
            this.inputTab.Controls.Add(this.usePhaseCheckbox);
            this.inputTab.Controls.Add(this.loadPhaseButton);
            this.inputTab.Controls.Add(this.inputPhaseImage);
            this.inputTab.Controls.Add(this.label1);
            this.inputTab.Controls.Add(this.inputAmplitudeImage);
            this.inputTab.Controls.Add(this.loadAmplitudeButton);
            this.inputTab.Location = new System.Drawing.Point(4, 22);
            this.inputTab.Name = "inputTab";
            this.inputTab.Padding = new System.Windows.Forms.Padding(3);
            this.inputTab.Size = new System.Drawing.Size(912, 494);
            this.inputTab.TabIndex = 0;
            this.inputTab.Text = "Входные распределения";
            this.inputTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Распределение фазы";
            // 
            // usePhaseCheckbox
            // 
            this.usePhaseCheckbox.AutoSize = true;
            this.usePhaseCheckbox.Location = new System.Drawing.Point(660, 455);
            this.usePhaseCheckbox.Name = "usePhaseCheckbox";
            this.usePhaseCheckbox.Size = new System.Drawing.Size(226, 17);
            this.usePhaseCheckbox.TabIndex = 5;
            this.usePhaseCheckbox.Text = "Не использовать распределение фазы";
            this.usePhaseCheckbox.UseVisualStyleBackColor = true;
            this.usePhaseCheckbox.CheckedChanged += new System.EventHandler(this.usePhaseCheckbox_CheckedChanged);
            // 
            // loadPhaseButton
            // 
            this.loadPhaseButton.Location = new System.Drawing.Point(486, 451);
            this.loadPhaseButton.Name = "loadPhaseButton";
            this.loadPhaseButton.Size = new System.Drawing.Size(75, 23);
            this.loadPhaseButton.TabIndex = 4;
            this.loadPhaseButton.Text = "Загрузить";
            this.loadPhaseButton.UseVisualStyleBackColor = true;
            this.loadPhaseButton.Click += new System.EventHandler(this.loadPhaseButton_Click);
            // 
            // inputPhaseImage
            // 
            this.inputPhaseImage.Location = new System.Drawing.Point(486, 38);
            this.inputPhaseImage.Name = "inputPhaseImage";
            this.inputPhaseImage.Size = new System.Drawing.Size(400, 400);
            this.inputPhaseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputPhaseImage.TabIndex = 3;
            this.inputPhaseImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Распределение апмлитуды";
            // 
            // inputAmplitudeImage
            // 
            this.inputAmplitudeImage.Location = new System.Drawing.Point(22, 38);
            this.inputAmplitudeImage.Name = "inputAmplitudeImage";
            this.inputAmplitudeImage.Size = new System.Drawing.Size(400, 400);
            this.inputAmplitudeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputAmplitudeImage.TabIndex = 1;
            this.inputAmplitudeImage.TabStop = false;
            // 
            // loadAmplitudeButton
            // 
            this.loadAmplitudeButton.Location = new System.Drawing.Point(22, 451);
            this.loadAmplitudeButton.Name = "loadAmplitudeButton";
            this.loadAmplitudeButton.Size = new System.Drawing.Size(75, 23);
            this.loadAmplitudeButton.TabIndex = 0;
            this.loadAmplitudeButton.Text = "Загрузить";
            this.loadAmplitudeButton.UseVisualStyleBackColor = true;
            this.loadAmplitudeButton.Click += new System.EventHandler(this.loadAmplitudeButton_Click);
            // 
            // outputTab
            // 
            this.outputTab.Controls.Add(this.savePhaseButton);
            this.outputTab.Controls.Add(this.saveAmplitudeButton);
            this.outputTab.Controls.Add(this.label3);
            this.outputTab.Controls.Add(this.outputPhaseImage);
            this.outputTab.Controls.Add(this.label4);
            this.outputTab.Controls.Add(this.outputAmplitudeImage);
            this.outputTab.Location = new System.Drawing.Point(4, 22);
            this.outputTab.Name = "outputTab";
            this.outputTab.Padding = new System.Windows.Forms.Padding(3);
            this.outputTab.Size = new System.Drawing.Size(912, 494);
            this.outputTab.TabIndex = 1;
            this.outputTab.Text = "Выходные распределения";
            this.outputTab.UseVisualStyleBackColor = true;
            // 
            // savePhaseButton
            // 
            this.savePhaseButton.Location = new System.Drawing.Point(486, 451);
            this.savePhaseButton.Name = "savePhaseButton";
            this.savePhaseButton.Size = new System.Drawing.Size(127, 23);
            this.savePhaseButton.TabIndex = 12;
            this.savePhaseButton.Text = "Сохранить в файл";
            this.savePhaseButton.UseVisualStyleBackColor = true;
            this.savePhaseButton.Click += new System.EventHandler(this.savePhaseButton_Click);
            // 
            // saveAmplitudeButton
            // 
            this.saveAmplitudeButton.Location = new System.Drawing.Point(22, 451);
            this.saveAmplitudeButton.Name = "saveAmplitudeButton";
            this.saveAmplitudeButton.Size = new System.Drawing.Size(127, 23);
            this.saveAmplitudeButton.TabIndex = 11;
            this.saveAmplitudeButton.Text = "Сохранить в файл";
            this.saveAmplitudeButton.UseVisualStyleBackColor = true;
            this.saveAmplitudeButton.Click += new System.EventHandler(this.saveAmplitudeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Распределение фазы";
            // 
            // outputPhaseImage
            // 
            this.outputPhaseImage.Location = new System.Drawing.Point(486, 38);
            this.outputPhaseImage.Name = "outputPhaseImage";
            this.outputPhaseImage.Size = new System.Drawing.Size(400, 400);
            this.outputPhaseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputPhaseImage.TabIndex = 9;
            this.outputPhaseImage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Распределение апмлитуды";
            // 
            // outputAmplitudeImage
            // 
            this.outputAmplitudeImage.Location = new System.Drawing.Point(22, 38);
            this.outputAmplitudeImage.Name = "outputAmplitudeImage";
            this.outputAmplitudeImage.Size = new System.Drawing.Size(400, 400);
            this.outputAmplitudeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputAmplitudeImage.TabIndex = 7;
            this.outputAmplitudeImage.TabStop = false;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(1047, 555);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Пуск";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // loadAmplitudeDialog
            // 
            this.loadAmplitudeDialog.DefaultExt = "bmp";
            this.loadAmplitudeDialog.Filter = "BMP files | *.bmp";
            this.loadAmplitudeDialog.Title = "loadAmplitudeDialog";
            // 
            // loadPhaseDialog
            // 
            this.loadPhaseDialog.DefaultExt = "bmp";
            this.loadPhaseDialog.Filter = "BMP files | *.bmp";
            this.loadPhaseDialog.Title = "Загрузить распределение фазы";
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(280, 541);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(42, 23);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = ">>";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // backwardButton
            // 
            this.backwardButton.Location = new System.Drawing.Point(232, 541);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(42, 23);
            this.backwardButton.TabIndex = 3;
            this.backwardButton.Text = "<<";
            this.backwardButton.UseVisualStyleBackColor = true;
            this.backwardButton.Click += new System.EventHandler(this.backwardButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "λ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Z";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "ΔZ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "H";
            // 
            // lambdaInput
            // 
            this.lambdaInput.Location = new System.Drawing.Point(3, 3);
            this.lambdaInput.Name = "lambdaInput";
            this.lambdaInput.Size = new System.Drawing.Size(100, 20);
            this.lambdaInput.TabIndex = 8;
            this.lambdaInput.Validating += new System.ComponentModel.CancelEventHandler(this.lambdaInput_Validating);
            // 
            // zInput
            // 
            this.zInput.Location = new System.Drawing.Point(3, 3);
            this.zInput.Name = "zInput";
            this.zInput.Size = new System.Drawing.Size(100, 20);
            this.zInput.TabIndex = 9;
            this.zInput.Validating += new System.ComponentModel.CancelEventHandler(this.zInput_Validating);
            // 
            // deltaZInput
            // 
            this.deltaZInput.Location = new System.Drawing.Point(3, 3);
            this.deltaZInput.Name = "deltaZInput";
            this.deltaZInput.Size = new System.Drawing.Size(100, 20);
            this.deltaZInput.TabIndex = 10;
            this.deltaZInput.Validating += new System.ComponentModel.CancelEventHandler(this.deltaZInput_Validating);
            // 
            // hInput
            // 
            this.hInput.Location = new System.Drawing.Point(3, 3);
            this.hInput.Name = "hInput";
            this.hInput.Size = new System.Drawing.Size(100, 20);
            this.hInput.TabIndex = 11;
            this.hInput.Validating += new System.ComponentModel.CancelEventHandler(this.hInput_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "нм";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "м";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "м";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "мкм";
            // 
            // lambdaInputPanel
            // 
            this.lambdaInputPanel.Controls.Add(this.lambdaInput);
            this.lambdaInputPanel.Location = new System.Drawing.Point(59, 93);
            this.lambdaInputPanel.Name = "lambdaInputPanel";
            this.lambdaInputPanel.Size = new System.Drawing.Size(106, 26);
            this.lambdaInputPanel.TabIndex = 16;
            // 
            // zInputPanel
            // 
            this.zInputPanel.Controls.Add(this.zInput);
            this.zInputPanel.Location = new System.Drawing.Point(59, 125);
            this.zInputPanel.Name = "zInputPanel";
            this.zInputPanel.Size = new System.Drawing.Size(106, 26);
            this.zInputPanel.TabIndex = 17;
            // 
            // deltaZInputPanel
            // 
            this.deltaZInputPanel.Controls.Add(this.deltaZInput);
            this.deltaZInputPanel.Location = new System.Drawing.Point(59, 157);
            this.deltaZInputPanel.Name = "deltaZInputPanel";
            this.deltaZInputPanel.Size = new System.Drawing.Size(106, 26);
            this.deltaZInputPanel.TabIndex = 18;
            // 
            // hInputPanel
            // 
            this.hInputPanel.Controls.Add(this.hInput);
            this.hInputPanel.Location = new System.Drawing.Point(59, 189);
            this.hInputPanel.Name = "hInputPanel";
            this.hInputPanel.Size = new System.Drawing.Size(106, 26);
            this.hInputPanel.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 616);
            this.Controls.Add(this.hInputPanel);
            this.Controls.Add(this.deltaZInputPanel);
            this.Controls.Add(this.zInputPanel);
            this.Controls.Add(this.lambdaInputPanel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Моделирование дифракции";
            this.tabControl1.ResumeLayout(false);
            this.inputTab.ResumeLayout(false);
            this.inputTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputPhaseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputAmplitudeImage)).EndInit();
            this.outputTab.ResumeLayout(false);
            this.outputTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputPhaseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputAmplitudeImage)).EndInit();
            this.lambdaInputPanel.ResumeLayout(false);
            this.lambdaInputPanel.PerformLayout();
            this.zInputPanel.ResumeLayout(false);
            this.zInputPanel.PerformLayout();
            this.deltaZInputPanel.ResumeLayout(false);
            this.deltaZInputPanel.PerformLayout();
            this.hInputPanel.ResumeLayout(false);
            this.hInputPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage inputTab;
        private System.Windows.Forms.PictureBox inputAmplitudeImage;
        private System.Windows.Forms.Button loadAmplitudeButton;
        private System.Windows.Forms.TabPage outputTab;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.OpenFileDialog loadAmplitudeDialog;
        private System.Windows.Forms.PictureBox inputPhaseImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox usePhaseCheckbox;
        private System.Windows.Forms.Button loadPhaseButton;
        private System.Windows.Forms.OpenFileDialog loadPhaseDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox outputPhaseImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox outputAmplitudeImage;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button savePhaseButton;
        private System.Windows.Forms.Button saveAmplitudeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lambdaInput;
        private System.Windows.Forms.TextBox zInput;
        private System.Windows.Forms.TextBox deltaZInput;
        private System.Windows.Forms.TextBox hInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel lambdaInputPanel;
        private System.Windows.Forms.Panel zInputPanel;
        private System.Windows.Forms.Panel deltaZInputPanel;
        private System.Windows.Forms.Panel hInputPanel;
        private System.Windows.Forms.SaveFileDialog saveAmplitudeDialog;
        private System.Windows.Forms.SaveFileDialog savePhaseDialog;
    }
}

