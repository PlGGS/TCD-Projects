using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects
{
    public class Runner
    {
        public Point StartingPos;

        protected Point _position;
        public Point Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Point MidPosition
        {
            get
            {
                return new Point(_position.X + Size.Width / 2, _position.Y + Size.Height / 2);
            }
        }

        protected Size _size;
        public Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        protected Rectangle _rect;
        public Rectangle Rect
        {
            get
            {
                return _rect;
            }
        }

        public Runner(Size size, int formX, int formY)
        {
            StartingPos = new Point(5, 5);
            _position = StartingPos;
            _size = size;
        }

        public void Draw(Graphics g)
        {
            _rect = new Rectangle(_position, _size);
            g.DrawRectangle(Pens.Orange, _rect);
        }
    }
}
