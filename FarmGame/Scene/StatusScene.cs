using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;

namespace FarmGame.Scene
{
    public class StatusScene : Node, IScene
    {
        private const int LabelXIndex = 30;
        private const int LabelYIndex = 190;
        private const int columnInterval = 60;

        CommonMenu menu = null;
        PowerPanel _powerPanel;
        StatusLabel _turnLabel;

        public void Update()
        {
            _turnLabel.SetText("経過ターン:" + GameData.PlayerData.Turn.ToString());
        }

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_main.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = Common.Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("statussign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = Common.Parameter.ZOrder.Sign;
            AddChildNode(sign);

            _powerPanel = new PowerPanel();
            _powerPanel.SetPosition(new Vector2F(sign.Texture.Size.X, 0));
            _powerPanel.SetNode(this);
            _powerPanel.UpdateValue();

            MoneyPanel moneyPanel = new MoneyPanel();
            moneyPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight()));
            moneyPanel.SetNode(this);
            moneyPanel.SetValue(GameData.PlayerData.Money);

            WeatherPanel weatherPanel = new WeatherPanel();
            weatherPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight() + moneyPanel.GetHeight()));
            weatherPanel.SetNode(this);
            weatherPanel.UpdateValue();

            menu = new CommonMenu(this);
            showStatus();
        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            menu.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push)
            {
                menu.Click(position, this);
            }
        }

        private void showStatus()
        {
            _turnLabel = new StatusLabel();
            _turnLabel.SetPosition(new Vector2F(LabelXIndex, LabelYIndex));
            _turnLabel.SetText("経過ターン:" + GameData.PlayerData.Turn.ToString());
            _turnLabel.SetNode(this);

            StatusLabel agricultureLabel = new StatusLabel();
            agricultureLabel.SetPosition(new Vector2F(LabelXIndex, LabelYIndex + columnInterval));
            agricultureLabel.SetText("農業レベル:" + GameData.PlayerData.AgricultureLevel +
                "(" + GameData.PlayerData.AgricultureExperience.ToString() + "/" +
                (GameData.PlayerData.AgricultureLevel * 25).ToString() + ")");
            agricultureLabel.SetNode(this);

            StatusLabel dairyLabel = new StatusLabel();
            dairyLabel.SetPosition(new Vector2F(LabelXIndex, LabelYIndex + columnInterval * 2));
            dairyLabel.SetText("酪農レベル:" + GameData.PlayerData.DairyLevel +
                "(" + GameData.PlayerData.DairyExperience.ToString() + "/" +
                (GameData.PlayerData.DairyLevel * 25).ToString() + ")");
            dairyLabel.SetNode(this);

            StatusLabel processingLabel = new StatusLabel();
            processingLabel.SetPosition(new Vector2F(LabelXIndex, LabelYIndex + columnInterval * 3));
            processingLabel.SetText("工房レベル:" + GameData.PlayerData.ProcessingLevel +
                "(" + GameData.PlayerData.ProcessingExperience.ToString() + "/" +
                (GameData.PlayerData.ProcessingLevel * 25).ToString() + ")");
            processingLabel.SetNode(this);

            StatusLabel managementLabel = new StatusLabel();
            managementLabel.SetPosition(new Vector2F(LabelXIndex, LabelYIndex + columnInterval * 4));
            managementLabel.SetText("経営レベル:" + GameData.PlayerData.ManagementLevel +
                "(" + GameData.PlayerData.ManagementExperience.ToString() + "/" +
                (GameData.PlayerData.ManagementLevel * 25).ToString() + ")");
            managementLabel.SetNode(this);
        }
    }
}
