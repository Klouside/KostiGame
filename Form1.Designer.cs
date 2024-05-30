namespace Game
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
            this.btnNextTurn = new System.Windows.Forms.Button();
            this.lblBankBalance = new System.Windows.Forms.Label();
            this.pnlCenterDice = new System.Windows.Forms.Panel();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.pnlDices = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClearData = new System.Windows.Forms.Button();
            this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.txtPlayerBet = new System.Windows.Forms.TextBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnRemovePlayer = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbAddPlayers = new System.Windows.Forms.GroupBox();
            this.gbGameElements = new System.Windows.Forms.GroupBox();
            this.gbAddPlayers.SuspendLayout();
            this.gbGameElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNextTurn
            // 
            this.btnNextTurn.Enabled = false;
            this.btnNextTurn.Location = new System.Drawing.Point(19, 125);
            this.btnNextTurn.Name = "btnNextTurn";
            this.btnNextTurn.Size = new System.Drawing.Size(175, 71);
            this.btnNextTurn.TabIndex = 5;
            this.btnNextTurn.Text = "Сделать\r\nход";
            this.btnNextTurn.UseVisualStyleBackColor = true;
            this.btnNextTurn.Click += new System.EventHandler(this.BtnNextTurn_Click);
            // 
            // lblBankBalance
            // 
            this.lblBankBalance.AutoSize = true;
            this.lblBankBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBankBalance.Location = new System.Drawing.Point(15, 24);
            this.lblBankBalance.Name = "lblBankBalance";
            this.lblBankBalance.Size = new System.Drawing.Size(135, 24);
            this.lblBankBalance.TabIndex = 6;
            this.lblBankBalance.Text = "Баланс банка:";
            // 
            // pnlCenterDice
            // 
            this.pnlCenterDice.Location = new System.Drawing.Point(19, 288);
            this.pnlCenterDice.Name = "pnlCenterDice";
            this.pnlCenterDice.Size = new System.Drawing.Size(175, 35);
            this.pnlCenterDice.TabIndex = 21;
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(536, 591);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(110, 23);
            this.btnShowLog.TabIndex = 31;
            this.btnShowLog.Text = "Показать лог";
            this.btnShowLog.UseVisualStyleBackColor = true;
            this.btnShowLog.Click += new System.EventHandler(this.BtnShowLog_Click);
            // 
            // pnlDices
            // 
            this.pnlDices.Location = new System.Drawing.Point(200, 51);
            this.pnlDices.Name = "pnlDices";
            this.pnlDices.Size = new System.Drawing.Size(446, 231);
            this.pnlDices.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "Центр стола";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(196, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 24);
            this.label5.TabIndex = 34;
            this.label5.Text = "Результат броска";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(420, 591);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(110, 23);
            this.btnClearData.TabIndex = 35;
            this.btnClearData.Text = "Очистить данные";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.BtnClearData_Click);
            // 
            // flpPlayers
            // 
            this.flpPlayers.Location = new System.Drawing.Point(200, 288);
            this.flpPlayers.Name = "flpPlayers";
            this.flpPlayers.Size = new System.Drawing.Size(446, 297);
            this.flpPlayers.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Укажите имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Укажите ставку";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(21, 40);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(179, 20);
            this.txtPlayerName.TabIndex = 39;
            // 
            // txtPlayerBet
            // 
            this.txtPlayerBet.Location = new System.Drawing.Point(21, 81);
            this.txtPlayerBet.Name = "txtPlayerBet";
            this.txtPlayerBet.Size = new System.Drawing.Size(179, 20);
            this.txtPlayerBet.TabIndex = 40;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(21, 327);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(179, 46);
            this.btnStartGame.TabIndex = 41;
            this.btnStartGame.Text = "Начать игру";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // btnRemovePlayer
            // 
            this.btnRemovePlayer.Location = new System.Drawing.Point(21, 298);
            this.btnRemovePlayer.Name = "btnRemovePlayer";
            this.btnRemovePlayer.Size = new System.Drawing.Size(179, 23);
            this.btnRemovePlayer.TabIndex = 42;
            this.btnRemovePlayer.Text = "Удалить игрока";
            this.btnRemovePlayer.UseVisualStyleBackColor = true;
            this.btnRemovePlayer.Click += new System.EventHandler(this.BtnRemovePlayer_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(21, 107);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(179, 23);
            this.btnAddPlayer.TabIndex = 43;
            this.btnAddPlayer.Text = "Добавить игрока";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.BtnAddPlayer_Click);
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(21, 158);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(179, 134);
            this.lstPlayers.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Участники";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(19, 349);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 24);
            this.label6.TabIndex = 46;
            // 
            // gbAddPlayers
            // 
            this.gbAddPlayers.Controls.Add(this.btnStartGame);
            this.gbAddPlayers.Controls.Add(this.btnRemovePlayer);
            this.gbAddPlayers.Controls.Add(this.lstPlayers);
            this.gbAddPlayers.Controls.Add(this.label4);
            this.gbAddPlayers.Controls.Add(this.label1);
            this.gbAddPlayers.Controls.Add(this.txtPlayerName);
            this.gbAddPlayers.Controls.Add(this.txtPlayerBet);
            this.gbAddPlayers.Controls.Add(this.label2);
            this.gbAddPlayers.Controls.Add(this.btnAddPlayer);
            this.gbAddPlayers.Location = new System.Drawing.Point(12, 12);
            this.gbAddPlayers.Name = "gbAddPlayers";
            this.gbAddPlayers.Size = new System.Drawing.Size(220, 402);
            this.gbAddPlayers.TabIndex = 47;
            this.gbAddPlayers.TabStop = false;
            // 
            // gbGameElements
            // 
            this.gbGameElements.Controls.Add(this.btnNextTurn);
            this.gbGameElements.Controls.Add(this.lblBankBalance);
            this.gbGameElements.Controls.Add(this.label6);
            this.gbGameElements.Controls.Add(this.flpPlayers);
            this.gbGameElements.Controls.Add(this.pnlCenterDice);
            this.gbGameElements.Controls.Add(this.btnShowLog);
            this.gbGameElements.Controls.Add(this.btnClearData);
            this.gbGameElements.Controls.Add(this.pnlDices);
            this.gbGameElements.Controls.Add(this.label5);
            this.gbGameElements.Controls.Add(this.label3);
            this.gbGameElements.Location = new System.Drawing.Point(238, 12);
            this.gbGameElements.Name = "gbGameElements";
            this.gbGameElements.Size = new System.Drawing.Size(664, 620);
            this.gbGameElements.TabIndex = 48;
            this.gbGameElements.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(914, 646);
            this.Controls.Add(this.gbGameElements);
            this.Controls.Add(this.gbAddPlayers);
            this.Name = "Form1";
            this.Text = "Игра \"Тузы\"";
            this.gbAddPlayers.ResumeLayout(false);
            this.gbAddPlayers.PerformLayout();
            this.gbGameElements.ResumeLayout(false);
            this.gbGameElements.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNextTurn;
        private System.Windows.Forms.Label lblBankBalance;
        private System.Windows.Forms.Panel pnlCenterDice;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Panel pnlDices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.FlowLayoutPanel flpPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.TextBox txtPlayerBet;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnRemovePlayer;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbAddPlayers;
        private System.Windows.Forms.GroupBox gbGameElements;
    }
}

