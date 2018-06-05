namespace GeneticAlgorithms
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.txt_Crossover = new System.Windows.Forms.TextBox();
            this.txt_MutationRate = new System.Windows.Forms.TextBox();
            this.txt_PopulationSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chb_Elitism = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Iterations = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_AverageFitness = new System.Windows.Forms.Label();
            this.lbl_BestFitness = new System.Windows.Forms.Label();
            this.lbl_BestIndividual = new System.Windows.Forms.Label();
            this.lbl_AmountWithBestFitness = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(26, 334);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(100, 40);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Crossover
            // 
            this.txt_Crossover.Location = new System.Drawing.Point(26, 54);
            this.txt_Crossover.Name = "txt_Crossover";
            this.txt_Crossover.Size = new System.Drawing.Size(100, 20);
            this.txt_Crossover.TabIndex = 1;
            this.txt_Crossover.Text = "0.9";
            // 
            // txt_MutationRate
            // 
            this.txt_MutationRate.Location = new System.Drawing.Point(26, 112);
            this.txt_MutationRate.Name = "txt_MutationRate";
            this.txt_MutationRate.Size = new System.Drawing.Size(100, 20);
            this.txt_MutationRate.TabIndex = 2;
            this.txt_MutationRate.Text = "0.1";
            // 
            // txt_PopulationSize
            // 
            this.txt_PopulationSize.Location = new System.Drawing.Point(26, 222);
            this.txt_PopulationSize.Name = "txt_PopulationSize";
            this.txt_PopulationSize.Size = new System.Drawing.Size(100, 20);
            this.txt_PopulationSize.TabIndex = 3;
            this.txt_PopulationSize.Text = "25";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Crossover rate (0..1)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mutation rate (0..1)";
            // 
            // chb_Elitism
            // 
            this.chb_Elitism.AutoSize = true;
            this.chb_Elitism.Location = new System.Drawing.Point(26, 166);
            this.chb_Elitism.Name = "chb_Elitism";
            this.chb_Elitism.Size = new System.Drawing.Size(55, 17);
            this.chb_Elitism.TabIndex = 6;
            this.chb_Elitism.Text = "Elitism";
            this.chb_Elitism.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Population size";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_Iterations
            // 
            this.txt_Iterations.Location = new System.Drawing.Point(26, 280);
            this.txt_Iterations.Name = "txt_Iterations";
            this.txt_Iterations.Size = new System.Drawing.Size(100, 20);
            this.txt_Iterations.TabIndex = 8;
            this.txt_Iterations.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "# of iterations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(26, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 10;
            // 
            // lbl_AverageFitness
            // 
            this.lbl_AverageFitness.AutoSize = true;
            this.lbl_AverageFitness.Location = new System.Drawing.Point(357, 35);
            this.lbl_AverageFitness.Name = "lbl_AverageFitness";
            this.lbl_AverageFitness.Size = new System.Drawing.Size(86, 13);
            this.lbl_AverageFitness.TabIndex = 11;
            this.lbl_AverageFitness.Text = "Average fitness: ";
            // 
            // lbl_BestFitness
            // 
            this.lbl_BestFitness.AutoSize = true;
            this.lbl_BestFitness.Location = new System.Drawing.Point(357, 61);
            this.lbl_BestFitness.Name = "lbl_BestFitness";
            this.lbl_BestFitness.Size = new System.Drawing.Size(64, 13);
            this.lbl_BestFitness.TabIndex = 12;
            this.lbl_BestFitness.Text = "Best fitness:";
            this.lbl_BestFitness.Click += new System.EventHandler(this.label7_Click);
            // 
            // lbl_BestIndividual
            // 
            this.lbl_BestIndividual.AutoSize = true;
            this.lbl_BestIndividual.Location = new System.Drawing.Point(357, 112);
            this.lbl_BestIndividual.Name = "lbl_BestIndividual";
            this.lbl_BestIndividual.Size = new System.Drawing.Size(78, 13);
            this.lbl_BestIndividual.TabIndex = 13;
            this.lbl_BestIndividual.Text = "Best individual:";
            // 
            // lbl_AmountWithBestFitness
            // 
            this.lbl_AmountWithBestFitness.AutoSize = true;
            this.lbl_AmountWithBestFitness.Location = new System.Drawing.Point(357, 93);
            this.lbl_AmountWithBestFitness.Name = "lbl_AmountWithBestFitness";
            this.lbl_AmountWithBestFitness.Size = new System.Drawing.Size(124, 13);
            this.lbl_AmountWithBestFitness.TabIndex = 14;
            this.lbl_AmountWithBestFitness.Text = "Amount with best fitness:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 430);
            this.Controls.Add(this.lbl_AmountWithBestFitness);
            this.Controls.Add(this.lbl_BestIndividual);
            this.Controls.Add(this.lbl_BestFitness);
            this.Controls.Add(this.lbl_AverageFitness);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Iterations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chb_Elitism);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_PopulationSize);
            this.Controls.Add(this.txt_MutationRate);
            this.Controls.Add(this.txt_Crossover);
            this.Controls.Add(this.btn_Start);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Genetic algorithm by Gert-Jan van Houwelingen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_Crossover;
        private System.Windows.Forms.TextBox txt_MutationRate;
        private System.Windows.Forms.TextBox txt_PopulationSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chb_Elitism;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Iterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_AverageFitness;
        private System.Windows.Forms.Label lbl_BestFitness;
        private System.Windows.Forms.Label lbl_BestIndividual;
        private System.Windows.Forms.Label lbl_AmountWithBestFitness;
    }
}

