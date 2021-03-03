using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class AlartDialog
    {
        private bool _isShow;
        public bool IsShow
        {
            get
            {
                return _isShow;
            }
        }

        private SpriteNode[] _node = new SpriteNode[8];
        private TextNode _text = new TextNode();

        private const int xPosition = 300;
        private const int yPosition = 200;
        private const int yTextOffset = 20;
        public AlartDialog()
        {
            _isShow = false;

            _node[0] = new SpriteNode();
            _node[0].Texture = Texture2D.Load("008_b.png");
            float partswidth = _node[0].ContentSize.X / 3.0f;
            float partsheight = _node[0].ContentSize.Y / 3.0f;
            _node[0].Src = new RectF(0, 0, partswidth, partsheight);
            _node[0].Position = new Vector2F(xPosition, yPosition);
            _node[0].ZOrder = Parameter.ZOrder.Alarm;

            _node[1] = new SpriteNode();
            _node[1].Texture = Texture2D.Load("008_b.png");
            _node[1].Src = new RectF(partswidth, 0, partswidth, partsheight);
            _node[1].Position = new Vector2F(xPosition + partswidth, yPosition);
            _node[1].ZOrder = Parameter.ZOrder.Alarm;

            _node[2] = new SpriteNode();
            _node[2].Texture = Texture2D.Load("008_b.png");
            _node[2].Src = new RectF(partswidth * 1, 0, partswidth, partsheight);
            _node[2].Position = new Vector2F(xPosition + partswidth * 2, yPosition);
            _node[2].ZOrder = Parameter.ZOrder.Alarm;

            _node[3] = new SpriteNode();
            _node[3].Texture = Texture2D.Load("008_b.png");
            _node[3].Src = new RectF(partswidth * 2, 0, partswidth, partsheight);
            _node[3].Position = new Vector2F(xPosition + partswidth * 3, yPosition);
            _node[3].ZOrder = Parameter.ZOrder.Alarm;

            _node[4] = new SpriteNode();
            _node[4].Texture = Texture2D.Load("008_b.png");
            _node[4].Src = new RectF(0, partsheight * 2, partswidth, partsheight);
            _node[4].Position = new Vector2F(xPosition, yPosition + partsheight);
            _node[4].ZOrder = Parameter.ZOrder.Alarm;

            _node[5] = new SpriteNode();
            _node[5].Texture = Texture2D.Load("008_b.png");
            _node[5].Src = new RectF(partswidth, partsheight * 2, partswidth, partsheight);
            _node[5].Position = new Vector2F(xPosition + partswidth, yPosition + partsheight);
            _node[5].ZOrder = Parameter.ZOrder.Alarm;

            _node[6] = new SpriteNode();
            _node[6].Texture = Texture2D.Load("008_b.png");
            _node[6].Src = new RectF(partswidth * 1, partsheight * 2, partswidth, partsheight);
            _node[6].Position = new Vector2F(xPosition + partswidth * 2, yPosition + partsheight);
            _node[6].ZOrder = Parameter.ZOrder.Alarm;

            _node[7] = new SpriteNode();
            _node[7].Texture = Texture2D.Load("008_b.png");
            _node[7].Src = new RectF(partswidth * 2, partsheight * 2, partswidth, partsheight);
            _node[7].Position = new Vector2F(xPosition + partswidth * 3, yPosition + partsheight);
            _node[7].ZOrder = Parameter.ZOrder.Alarm;

            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(255, 255, 255);
            _text.Position = new Vector2F(xPosition, yPosition + yTextOffset);
            _text.ZOrder = FarmGame.Parameter.ZOrder.Alarm;
        }

        public void SetNode(string message, Node parent)
        {
            _text.Text = message;
            foreach (var n in _node)
            {
                parent.AddChildNode(n);
            }
            parent.AddChildNode(_text);
            _isShow = true;
        }

        public void RemoveNode(Node parent)
        {
            foreach (var n in _node)
            {
                parent.RemoveChildNode(n);
            }
            parent.RemoveChildNode(_text);
            _isShow = false;
        }
    }
}
