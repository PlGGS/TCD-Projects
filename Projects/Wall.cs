﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Projects
{
    public class Wall
    {
        public enum WallTypes
        {
            Top,
            Bottom,
            Left,
            Right
        };

        protected Point _point1;
        public Point Point1
        {
            get
            {
                return _point1;
            }
            set
            {
                _point1 = value;
            }
        }

        protected Point _point2;
        public Point Point2
        {
            get
            {
                return _point2;
            }
            set
            {
                _point2 = value;
            }
        }

        protected WallTypes _type;
        public WallTypes Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;

                switch (_type)
                {
                    case WallTypes.Top:
                        _point1 = new Point(_chunkMazeSpot.X * _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height);
                        _point2 = new Point(_chunkMazeSpot.X * _chunkSize.Width + _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height);
                        _rect = new Rectangle(_point1.X, _point1.Y, _chunkSize.Width, 1);
                        break;
                    case WallTypes.Bottom:
                        _point1 = new Point(_chunkMazeSpot.X * _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height + _chunkSize.Height);
                        _point2 = new Point(_chunkMazeSpot.X * _chunkSize.Width + _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height + _chunkSize.Height);
                        _rect = new Rectangle(_point1.X, _point1.Y, _chunkSize.Width, 1);
                        break;
                    case WallTypes.Left:
                        _point1 = new Point(_chunkMazeSpot.X * _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height);
                        _point2 = new Point(_chunkMazeSpot.X * _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height + _chunkSize.Height);
                        _rect = new Rectangle(_point1.X, _point1.Y, 1, _chunkSize.Height);
                        break;
                    case WallTypes.Right:
                        _point1 = new Point(_chunkMazeSpot.X * _chunkSize.Width + _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height);
                        _point2 = new Point(_chunkMazeSpot.X * _chunkSize.Width + _chunkSize.Width, _chunkMazeSpot.Y * _chunkSize.Height + _chunkSize.Height);
                        _rect = new Rectangle(_point1.X, _point1.Y, 1, _chunkSize.Height);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid WallType!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }

        protected bool _built = true;
        public bool Built
        {
            get
            {
                return _built;
            }
            set
            {
                _built = value;
            }
        }

        protected Point _chunkMazeSpot;
        public Point ChunkMazeSpot
        {
            get
            {
                return _chunkMazeSpot;
            }
            set
            {
                _chunkMazeSpot = value;
            }
        }

        protected Size _chunkSize;
        public Size ChunkSize
        {
            get
            {
                return _chunkSize;
            }
            set
            {
                _chunkSize = value;
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


        public Wall(Point MazeSpot, Size Size)
        {
            ChunkMazeSpot = MazeSpot;
            ChunkSize = Size;
        }

        public void Draw(Graphics g)
        {
            if (_built)
            {
                g.DrawRectangle(Pens.Green, _rect);
            }
        }

        public void Print()
        {
            Console.WriteLine($"- Type: {_type}, Built: {_built}");
        }
    }
}
