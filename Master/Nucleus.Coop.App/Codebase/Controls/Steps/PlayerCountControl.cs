﻿using SplitScreenMe.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UserInputControl = Nucleus.Gaming.UserInputControl;

namespace Nucleus.Gaming.Coop {
    public partial class PlayerCountControl : UserInputControl {
        public override bool CanProceed {
            get { return canProceed; }
        }
        public override string Title {
            get { return "Player Count"; }
        }

        public override bool CanPlay {
            get { return false; }
        }

        private bool canProceed;
        private List<Button> top;
        private List<Button> bot;

        public PlayerCountControl() {
            InitializeComponent();
        }

        //public override void Initialize(HandlerData handlerData, UserGameInfo game, GameProfile profile) {
        public override void Initialize(UserGameInfo game, GameProfile profile) {
            base.Initialize(game, profile);

            this.Controls.Clear();
            canProceed = false;

#if false
            int maxPlayers = handlerData.MaxPlayers;
            int half = (int)Math.Round(maxPlayers / 2.0);
            int width = Size.Width / half;
            int height = Size.Height / 2;
            int player = 2;

            top = new List<Button>();
            bot = new List<Button>();

            int left = Math.Max(half - 1, 1);
            width = Size.Width / left;
            for (int i = 0; i < left; i++) {
                Button btn = MkButton();
                btn.Text = player.ToString();
                player++;

                btn.SetBounds(i * width, 0, width, height);

                top.Add(btn);
                this.Controls.Add(btn);
            }

            half = maxPlayers - half;
            width = Size.Width / half;
            for (int i = 0; i < half; i++) {
                Button btn = MkButton();
                btn.Text = player.ToString();
                player++;

                btn.SetBounds(i * width, height, width, height);

                bot.Add(btn);
                this.Controls.Add(btn);
            }
#endif
        }

        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);

            if (this.game == null) {
                return;
            }

            throw new NotImplementedException();
            //int maxPlayers = this.game.Game.MaxPlayers;
            //int half = (int)Math.Round(maxPlayers / 2.0);
            //int left = Math.Max(half - 1, 1);
            //int width = Size.Width / left;
            //int height = Size.Height / 2;

            //for (int i = 0; i < left; i++)
            //{
            //    Button btn = top[i];
            //    btn.SetBounds(i * width, 0, width, height);
            //}

            //half = maxPlayers - half;
            //width = Size.Width / half;
            //for (int i = 0; i < half; i++)
            //{
            //    Button btn = bot[i];
            //    btn.SetBounds(i * width, height, width, height);
            //}
        }

        private Button MkButton() {
            Button btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = this.Font;
            btn.Click += btn_Click;

            return btn;
        }

        private void btn_Click(object sender, EventArgs e) {
            canProceed = true;

            int playerCount = int.Parse(((Button)sender).Text);

            profile.PlayerData.Clear();
            for (int i = 0; i < playerCount; i++) {
                PlayerInfo player = new PlayerInfo();
                profile.PlayerData.Add(player);
            }

            CanPlayUpdated(true, true);
        }
    }
}
