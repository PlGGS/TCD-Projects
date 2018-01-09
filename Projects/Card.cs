﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Projects
{
    class Card
    {
        public ImageBrush imgBlank = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/blank.png")));
        public ImageBrush imgBack = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_back.png")));
        public ImageBrush imgCoins = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_coins.png")));
        public ImageBrush imgDynamite = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_dynamite.png")));
        public ImageBrush imgKnight = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_knight.png")));
        public ImageBrush imgLamp = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_lamp.png")));
        public ImageBrush imgShield = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_shield.png")));
        public ImageBrush imgSword = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_sword.png")));
        public ImageBrush imgTorch = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_torch.png")));
        public ImageBrush imgTable = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/table_top.png")));

        public static SoundPlayer flipSound = new SoundPlayer(Properties.Resources.CardFlip);
        public static SoundPlayer FlipSound
        {
            get
            {
                return flipSound;
            }
        }

        enum CardTypes
        {
            Blank,
            Back,
            Coins,
            Dynamite,
            Knight,
            Lamp,
            Shield,
            Sword,
            Torch,
            Table
        };

        public int cardType;
        public int CardType
        {
            get
            {
                return cardType;
            }
            set
            {
                cardType = value;
            }
        }

        public System.Windows.Controls.Image img;
        public System.Windows.Controls.Image IMG
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
            }
        }

        public bool matched = false;
        public bool Matched
        {
            get
            {
                return matched;
            }
            set
            {
                matched = value;
            }
        }

        public void Show()
        {
            if (!matched)
            {
                flipSound.Play();
            }

            switch (cardType)
            {
                case 0:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 1:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 2:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 3:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 4:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 5:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 6:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 7:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 8:
                    img.Source = imgBlank.ImageSource;
                    break;
                case 9:
                    img.Source = imgBlank.ImageSource;
                    break;

                default:
                    img.Source = imgBlank.ImageSource;

                    break;
            }
        }

        public void Hide()
        {
            if (matched)
            {
                img.Source = imgBlank.ImageSource;
            }
            else
            {
                img.Source = imgBack.ImageSource;
            }
        }
        
        public void Reset()
        {
            matched = false;
        }
    }
}
