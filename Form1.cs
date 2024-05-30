using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private List<Player> players;
        private Bank bank;
        private Game game;
        private readonly LogForm logForm;
        private bool isPreliminaryRound;
        private int currentPlayerIndexInPreliminaryRound;
        private int? initialBet = null;

        public Form1()
        {
            InitializeComponent();
            players = new List<Player>();
            bank = new Bank(0);
            logForm = new LogForm();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            if (pnlCenterDice == null)
            {
                pnlCenterDice = new Panel
                {
                    Size = new Size(250, 100),
                    Location = new Point((ClientSize.Width - pnlCenterDice.Width) / 2, (ClientSize.Height - pnlCenterDice.Height) / 2)
                };
                Controls.Add(pnlCenterDice);
            }

            flpPlayers.AutoScroll = true;
            flpPlayers.WrapContents = true;
            flpPlayers.FlowDirection = FlowDirection.LeftToRight;

            btnNextTurn.Enabled = false;
            btnStartGame.Enabled = false;
            btnRemovePlayer.Enabled = false;

            gbAddPlayers.Location = new Point(10, 10);
            gbGameElements.Location = new Point(10, 10);
            gbGameElements.Visible = false;

            this.Size = new Size(gbAddPlayers.Width + 40, gbAddPlayers.Height + 50);
        }

        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            string playerName = txtPlayerName.Text;
            int playerBet;

            if (!initialBet.HasValue)
            {
                if (string.IsNullOrWhiteSpace(playerName) || !int.TryParse(txtPlayerBet.Text, out playerBet) || playerBet <= 0)
                {
                    MessageBox.Show("Пожалуйста, введите имя игрока и сделайте ставку.");
                    return;
                }
                initialBet = playerBet;
                txtPlayerBet.Enabled = false;
            }
            else
            {
                playerBet = initialBet.Value;
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    MessageBox.Show("Пожалуйста,введите имя игрока.");
                    return;
                }
            }

            var newPlayer = new Player(playerName, playerBet);
            players.Add(newPlayer);
            bank.AddAmount(playerBet);
            LogAction($"Игрок {playerName} добавлен со ставкой {playerBet}.");
            UpdateUI();
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            if (players.Count < 2)
            {
                MessageBox.Show("Необходимы минимум 2 игрока для начала игры.");
                return;
            }

            game = new Game(players, bank, this);

            isPreliminaryRound = true;
            currentPlayerIndexInPreliminaryRound = 0;
            btnNextTurn.Enabled = true;
            LogAction("Игра началась! Проводим предварительный раунд...");
            UpdateUI();

            label6.Text = "Предварительный\nраунд";

            gbAddPlayers.Visible = false;
            gbGameElements.Visible = true;
            AdjustFormSize();
        }

        private void BtnNextTurn_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("Игра не началась. Пожалуйста, запустите игру.");
                return;
            }

            if (isPreliminaryRound)
            {
                HighlightCurrentPlayerInPreliminaryRound();
                ProceedPreliminaryRound();
            }
            else
            {
                game.NextTurn();

                if (!string.IsNullOrEmpty(game.Winner))
                {
                    game.EndGame(bank);
                    btnNextTurn.Enabled = false;
                }

                UpdateUI();

                if (label6.Visible)
                {
                    label6.Visible = false;
                }
            }
        }

        private void HighlightCurrentPlayerInPreliminaryRound()
        {
            foreach (Control control in flpPlayers.Controls)
            {
                if (control is Panel playerPanel)
                {
                    playerPanel.BackColor = SystemColors.Control;
                }
            }

            if (isPreliminaryRound && currentPlayerIndexInPreliminaryRound >= 0 && currentPlayerIndexInPreliminaryRound < flpPlayers.Controls.Count)
            {
                flpPlayers.Controls[currentPlayerIndexInPreliminaryRound].BackColor = Color.Yellow;
            }
        }

        private void ProceedPreliminaryRound()
        {
            if (!isPreliminaryRound) return;

            if (currentPlayerIndexInPreliminaryRound < players.Count)
            {
                var player = players[currentPlayerIndexInPreliminaryRound];
                var diceValues = player.RollDice();
                var combination = new PokerCombination(diceValues);
                LogAction($"{player.Name} выбросил комбинацию: {string.Join(", ", diceValues)}");
                player.Dices = diceValues;

                UpdateDiceImages(diceValues);
                currentPlayerIndexInPreliminaryRound++;

                HighlightCurrentPlayerInPreliminaryRound();

                if (currentPlayerIndexInPreliminaryRound >= players.Count)
                {
                    game.DeterminePlayerOrder();
                    isPreliminaryRound = false;

                    LogAction("Предварительный раунд завершен. Определен порядок ходов.");
                    UpdateUI();

                    var playerOrder = string.Join(",\n", game.Players.Select(p => p.Name));
                    label6.Text = $"Порядок ходов:\n{playerOrder}";
                }
            }
        }

        public void LogAction(string message)
        {
            logForm.AppendLog(message);
            logForm.BringToFront();
        }

        private void BtnClearData_Click(object sender, EventArgs e)
        {
            players.Clear();
            bank = new Bank(0);
            game = null;
            initialBet = null;
            txtPlayerBet.Enabled = true;
            txtPlayerBet.Clear();
            pnlDices.Controls.Clear();
            pnlCenterDice.Controls.Clear();
            UpdateUI();

            gbAddPlayers.Visible = true;
            gbGameElements.Visible = false;
            AdjustFormSize();
        }

        public void UpdateUI()
        {
            lstPlayers.Items.Clear();
            flpPlayers.Controls.Clear();

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string diceImagePath = Path.Combine(imagePath, "dice.png");
            string playerImagePath = Path.Combine(imagePath, "people.png");

            foreach (var player in players)
            {
                var playerItem = new PlayerListItem(player.Name, player.Bet, player.Dices);
                lstPlayers.Items.Add(playerItem);

                var playerPanel = new Panel
                {
                    Size = new Size(132, 75 + 30 * (player.Dices.Count / 5 + 1)),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                var dicePanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Dock = DockStyle.Top,
                    Height = 30 * (player.Dices.Count / 5 + 1)
                };
                for (int i = 0; i < player.Dices.Count; i++)
                {
                    var pbDice = new PictureBox
                    {
                        Size = new Size(20, 20),
                        Image = Image.FromFile(Path.Combine(imagePath, $"dice.png")),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    dicePanel.Controls.Add(pbDice);
                }
                playerPanel.Controls.Add(dicePanel);

                var pbPlayer = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Image.FromFile(playerImagePath),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Top
                };
                playerPanel.Controls.Add(pbPlayer);

                var lblPlayerName = new Label
                {
                    Text = player.Name,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                playerPanel.Controls.Add(lblPlayerName);

                flpPlayers.Controls.Add(playerPanel);
            }

            Player currentPlayer = game?.GetCurrentPlayer();
            HighlightCurrentPlayerCard(currentPlayer);
            HighlightWinnerCard();

            lblBankBalance.Text = $"Баланс банка:\n{bank?.Balance ?? 0}";
            txtPlayerName.Clear();
            btnStartGame.Enabled = players.Count >= 2 && game == null;
            btnRemovePlayer.Enabled = players.Count > 0 && game == null;
            btnClearData.Enabled = players.Count > 0;
        }

        private void AdjustFormSize()
        {
            if (gbAddPlayers.Visible)
            {
                this.Size = new Size(gbAddPlayers.Width + 40, gbAddPlayers.Height + 50);
            }
            else if (gbGameElements.Visible)
            {
                this.Size = new Size(gbGameElements.Width + 40, gbGameElements.Height + 50);
            }
        }

        public void UpdateDiceImages(List<int> dices)
        {
            pnlDices.Controls.Clear();

            int diceSize = 75;
            int margin = 10;

            for (int i = 0; i < dices.Count; i++)
            {
                int diceValue = dices[i];
                if (diceValue >= 1 && diceValue <= 6)
                {
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", $"dice_{diceValue}.png");

                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            var pb = new PictureBox
                            {
                                Size = new Size(diceSize, diceSize),
                                Image = Image.FromFile(imagePath),
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Location = new Point((diceSize + margin) * (i % 5), (diceSize + margin) * (i / 5))
                            };
                            pnlDices.Controls.Add(pb);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading image: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Image {imagePath} not found.");
                    }
                }
                else
                {
                    MessageBox.Show($"Invalid dice value: {diceValue}");
                }
            }

            int rows = (int)Math.Ceiling((double)dices.Count / 5);
            pnlDices.Size = new Size(5 * (diceSize + margin), rows * (diceSize + margin));
        }

        private void HighlightCurrentPlayerCard(Player currentPlayer)
        {
            if (currentPlayer != null)
            {
                foreach (Control control in flpPlayers.Controls)
                {
                    if (control is Panel playerPanel)
                    {
                        if (playerPanel.Controls.OfType<Label>().FirstOrDefault()?.Text == currentPlayer.Name)
                        {
                            playerPanel.BackColor = Color.Yellow;
                        }
                        else
                        {
                            playerPanel.BackColor = SystemColors.Control;
                        }
                    }
                }
            }
        }

        private void HighlightWinnerCard()
        {
            string winnerName = game?.Winner;

            if (!string.IsNullOrEmpty(winnerName))
            {
                foreach (Control control in flpPlayers.Controls)
                {
                    if (control is Panel playerPanel)
                    {
                        if (playerPanel.Controls.OfType<Label>().FirstOrDefault()?.Text == winnerName)
                        {
                            playerPanel.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            playerPanel.BackColor = SystemColors.Control;
                        }
                    }
                }
            }
        }

        public class PlayerListItem
        {
            public string Name { get; set; }
            public int Bet { get; set; }
            public List<int> Dices { get; set; }

            public PlayerListItem(string name, int bet, List<int> dices)
            {
                Name = name;
                Bet = bet;
                Dices = dices;
            }

            public override string ToString()
            {
                return $"{Name} - {Dices.Count} Кости - Ставка: {Bet}";
            }
        }

        private void BtnShowLog_Click(object sender, EventArgs e)
        {
            logForm.Show();
            logForm.BringToFront();
        }

        private void BtnRemovePlayer_Click(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItem is PlayerListItem selectedPlayerItem)
            {
                string playerName = selectedPlayerItem.Name;
                Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

                if (playerToRemove != null)
                {
                    bank.DeductAmount(playerToRemove.Bet);
                    players.Remove(playerToRemove);
                    lstPlayers.Items.Remove(selectedPlayerItem);
                    UpdateUI();
                }
            }
            else
            {
                MessageBox.Show("Выберите игрока из списка, которого вы хотите удалить.");
            }
        }

        public void UpdateCenterDiceImages()
        {
            if (pnlCenterDice == null)
            {
                MessageBox.Show("pnlCenterDice не инициализирована.");
                return;
            }

            pnlCenterDice.Controls.Clear();

            if (Game.CenterDices == null || Game.CenterDices.Count == 0)
            {
                return;
            }

            int diceSize = 30;
            int margin = 5;
            int dicePerRow = 5;

            for (int i = 0; i < Game.CenterDices.Count; i++)
            {
                var pb = new PictureBox
                {
                    Size = new Size(diceSize, diceSize),
                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", $"dice_{Game.CenterDices[i]}.png")),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point((diceSize + margin) * (i % dicePerRow), (diceSize + margin) * (i / dicePerRow))
                };
                pnlCenterDice.Controls.Add(pb);
            }

            int rows = (int)Math.Ceiling((double)Game.CenterDices.Count / dicePerRow);
            pnlCenterDice.Size = new Size(dicePerRow * (diceSize + margin), rows * (diceSize + margin));
        }
    }
}
