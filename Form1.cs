using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Game : Form
    {
        private int verVelocity = 0;
        private int horVelocity = 0;
        private int pacmanImageCounter = 1;
        private int enemyImageCounter = 1;
        private string direction;
        private bool gamePaused = false;

        int heroSpeed = 1;
        Random rand = new Random();
        int score = 0;
        public Game()
        {
            InitializeComponent();
            this.KeyPreview = true;
            InitializeHero();
            InitilizeTimers();
            PlaySound("pacman_intro.wav");

        }
        

        private void InitilizeTimers()
        {
            TimerMain.Interval = 10;
            TimerMain.Start();

            TimerAnimateGhost.Interval = 300;
            TimerAnimateGhost.Start();

            TimerPacman.Interval = 100;
            TimerPacman.Start();
        }

        private void AddGhost()
        {
            PictureBox ghost = new PictureBox();
            ghost.Width = 20;
            ghost.Height = 20;
            ghost.Left = rand.Next(0, (ClientRectangle.Width - 50));
            ghost.Top = rand.Next(0, (ClientRectangle.Height - 50));
            ghost.SizeMode = PictureBoxSizeMode.StretchImage;
            ghost.Image = Properties.Resources.enemy1_1;
            ghost.BackColor = Color.Transparent;
            ghost.Tag = "ghost";
            this.Controls.Add(ghost);
        }

        private void InitializeHero()
        {
            Hero.BackColor = Color.Transparent;
            Hero.Width = 40;
            Hero.Height = 40;
            Hero.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void HeroEnemyCollision()
        {
            foreach(Control contr in this.Controls)
            {
                if(contr.Tag == "ghost")
                {
                    if (Hero.Bounds.IntersectsWith(contr.Bounds))
                    {
                        GameOver();
                    }
                }
            }
        }

        private void GameOver()
        {
            TimerMain.Stop();
            TimerPacman.Stop();
            PlaySound("game_over.wav");
            MessageBox.Show("GAME OVER");
            Application.Restart();
            Environment.Exit(0);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                PlaySound("pacman_move.wav");

            if (e.KeyCode == Keys.Up)
            {
                verVelocity = -heroSpeed;
                horVelocity = 0;
                direction = "up";
            }
            else if (e.KeyCode == Keys.Down)
            {
                verVelocity = heroSpeed;
                horVelocity = 0;
                direction = "down";
            }
            else if (e.KeyCode == Keys.Left)
            {
                verVelocity = 0;
                horVelocity = -heroSpeed;
                direction = "left";
            }                
            else if (e.KeyCode == Keys.Right)
            {
                verVelocity = 0;
                horVelocity = heroSpeed;
                direction = "right";
            }
            
            else if (e.KeyCode == Keys.P)
            {
                if (gamePaused)
                {
                    TimerMain.Start();
                    TimerPacman.Start();
                    gamePaused = false;
                    ScoreLabel.Text = "Score: " + score.ToString();
                }
                else
                {
                    TimerMain.Stop();
                    TimerPacman.Stop();
                    gamePaused = true;
                    ScoreLabel.Text = "Game Paused...";
                }                
            }
            else if (e.KeyCode == Keys.T)
            {
                SaySomething("Cool");
            }
            else if (e.KeyCode == Keys.C)
            {
                ShowCoordinates();
            }
        }

        private void SaySomething(string word)
        {
            MessageBox.Show(word);
        }

        private void ShowCoordinates()
        {
            string message;
            message = "Left=" + Hero.Left.ToString() + "; Top =" + Hero.Top.ToString();
            SaySomething(message);
            
        }

        private void PlaySound(string file)
        {
            string path = @"C:\Users\aannu\Downloads\Sounds\Sounds\" + file;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);

            try
            {
                player.Play();
            }
            catch(Exception e)
            {
                
            }           
        }

        private void HeroMove()
        {
            
            Hero.Top += verVelocity;
            Hero.Left += horVelocity;
            

        }

        private void HeroRectangleCollision()
        {
            if (Hero.Top < 0)
                Hero.Top = ClientRectangle.Height;
            if (Hero.Top > ClientRectangle.Height)
                Hero.Top = 0;
            if (Hero.Left < 0)
                Hero.Left = ClientRectangle.Width;
            if (Hero.Left > ClientRectangle.Width)
                Hero.Left = 0;
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            
            HeroMove();
            HeroRectangleCollision();
            HeroFoodCollision();
            HeroEnemyCollision();
        }

        private void HeroFoodCollision()
        {
            if (Hero.Bounds.IntersectsWith(Food.Bounds))
            {
                Food.Top = rand.Next(0, (ClientRectangle.Height - 50));
                Food.Left = rand.Next(0, (ClientRectangle.Width - 50));
                score++; //score += 1;
                ScoreLabel.Text = "Score: " + score.ToString();
                heroSpeed += 1;
                PlaySound("pacman_eat.wav");
                AddGhost();
            }
        }

        private void TimerPacman_Tick(object sender, EventArgs e)
        {
            string pacmanImageName = "pacman_" + pacmanImageCounter.ToString();
            Hero.Image = (Image)Properties.Resources.ResourceManager.GetObject(pacmanImageName);
            pacmanImageCounter += 1;
            
            if (pacmanImageCounter > 4) pacmanImageCounter = 1;

            if (direction == "up")
                Hero.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            else if (direction == "down")
                Hero.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else if(direction == "left")
                Hero.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            else if(direction == "right")
                Hero.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
        }

        private void TimerAnimateGhost_Tick(object sender, EventArgs e)
        {
            PictureBox ghost;
            string enemyImageName = "enemy1_" + enemyImageCounter.ToString();
            
            foreach(Control contr in this.Controls)
            {
                if (contr.Tag == "ghost")
                {
                    ghost = (PictureBox)contr;
                    ghost.Image = (Image)Properties.Resources.ResourceManager.GetObject(enemyImageName);
                }
            }
            
            enemyImageCounter += 1;
            if (enemyImageCounter > 2) enemyImageCounter = 1;
        }

        
    }
}
