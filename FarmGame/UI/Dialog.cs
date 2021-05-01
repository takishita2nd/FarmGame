using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class Dialog
    {
        private bool _isShow;
        public bool IsShow
        {
            get
            {
                return _isShow;
            }
        }

        private SpriteNode[] _node = new SpriteNode[18];
        private TextNode[] _text = new TextNode[3];

        private const int xPosition = 300;
        private const int yPosition = 200;
        private const int yTextOffset = 20;
        public Dialog()
        {
            _isShow = false;
            int index = 0;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            float partswidth = _node[0].ContentSize.X / 3.0f;
            float partsheight = _node[0].ContentSize.Y / 3.0f;
            _node[index].Src = new RectF(0, 0, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition, yPosition);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth, 0, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth, yPosition);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, 0, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 2, yPosition);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, 0, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 3, yPosition);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, 0, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 4, yPosition);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 2, 0, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 5, yPosition);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(0, partsheight * 1, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition, yPosition + partsheight);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth, partsheight * 1, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth, yPosition + partsheight);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, partsheight * 1, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 2, yPosition + partsheight);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, partsheight * 1, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 3, yPosition + partsheight);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, partsheight * 1, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 4, yPosition + partsheight);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 2, partsheight * 1, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 5, yPosition + partsheight);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(0, partsheight * 2, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition, yPosition + partsheight * 2);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth, partsheight * 2, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth, yPosition + partsheight * 2);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, partsheight * 2, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 2, yPosition + partsheight * 2);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, partsheight * 2, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 3, yPosition + partsheight * 2);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 1, partsheight * 2, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 4, yPosition + partsheight * 2);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

            _node[index] = new SpriteNode();
            _node[index].Texture = Texture2D.Load("008_b.png");
            _node[index].Src = new RectF(partswidth * 2, partsheight * 2, partswidth, partsheight);
            _node[index].Position = new Vector2F(xPosition + partswidth * 5, yPosition + partsheight * 2);
            _node[index].ZOrder = Common.Parameter.ZOrder.Alarm;
            index++;

        }

        /**
         * <summary>ダイアログ表示</summary>
         * */
        public void SetNode(string message, Node parent)
        {
            foreach (var n in _node)
            {
                parent.AddChildNode(n);
            }
            for (int line = 0; line < 3; line++)
            {
                _text[line] = new TextNode();
                _text[line].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
                _text[line].Color = new Color(255, 255, 255);
                _text[line].Position = new Vector2F(xPosition, yPosition + _text[line].ContentSize.Y * line + yTextOffset);
                _text[line].ZOrder = Common.Parameter.ZOrder.Alarm;
                parent.AddChildNode(_text[line]);
            }
            UpdateText(message);
            _isShow = true;
        }

        /**
         * <summary>ダイアログ非表示</summary>
         * */
        public void RemoveNode(Node parent)
        {
            foreach (var n in _node)
            {
                parent.RemoveChildNode(n);
            }
            foreach (var t in _text)
            {
                if(t != null)
                {
                    parent.RemoveChildNode(t);
                }
            }
            _isShow = false;
        }

        public void UpdateText(string message)
        {
            var messages = message.Split("\n");
            for (int line = 0; line < 3; line++)
            {
                if (line < messages.Length)
                {
                    _text[line].Text = messages[line];
                }
                else
                {
                    _text[line].Text = string.Empty;
                }
            }
        }
    }
}
