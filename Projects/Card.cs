using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Projects
{
    class Card
    {
        ImageBrush imgBlank = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/blank.png")));
        ImageBrush imgBack = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_back.png")));
        ImageBrush imgTable = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/table_top.jpg")));
        public Dictionary<string, ImageBrush> CardTypes = new Dictionary<string, ImageBrush>
        {
            {"Coins", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_coins.png")))},
            {"Dynamite", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_dynamite.png")))},
            {"Knight", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_knight.png")))},
            {"Lamp", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_lamp.png")))},
            {"Shield", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_shield.png")))},
            {"Sword", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_sword.png")))},
            {"Torch", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_torch.png")))}
        };
        protected static SoundPlayer flipSound = new SoundPlayer(Properties.Resources.CardFlip);
        public static SoundPlayer FlipSound
        {
            get
            {
                return flipSound;
            }
        }

        protected int cardType;
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

        protected ImageBrush img;
        public ImageBrush IMG
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

        protected bool matched = false;
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

        public Card(int cardType)
        {
            CardType = cardType;
            IMG = CardTypes.Values.ToArray()[cardType];
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
                    img.ImageSource = CardTypes.Values.ToArray()[0].ImageSource;
                    break;
                case 1:
                    img.ImageSource = CardTypes.Values.ToArray()[1].ImageSource;
                    break;
                case 2:
                    img.ImageSource = CardTypes.Values.ToArray()[2].ImageSource;
                    break;
                case 3:
                    img.ImageSource = CardTypes.Values.ToArray()[3].ImageSource;
                    break;
                case 4:
                    img.ImageSource = CardTypes.Values.ToArray()[4].ImageSource;
                    break;
                case 5:
                    img.ImageSource = CardTypes.Values.ToArray()[5].ImageSource;
                    break;
                case 6:
                    img.ImageSource = CardTypes.Values.ToArray()[6].ImageSource;
                    break;
                case 7:
                    img.ImageSource = CardTypes.Values.ToArray()[7].ImageSource;
                    break;
                case 8:
                    img.ImageSource = CardTypes.Values.ToArray()[8].ImageSource;
                    break;
                case 9:
                    img.ImageSource = CardTypes.Values.ToArray()[9].ImageSource;
                    break;
                case 10:
                    img.ImageSource = CardTypes.Values.ToArray()[10].ImageSource;
                    break;
                case 11:
                    img.ImageSource = CardTypes.Values.ToArray()[11].ImageSource;
                    break;
                case 12:
                    img.ImageSource = CardTypes.Values.ToArray()[12].ImageSource;
                    break;
                case 13:
                    img.ImageSource = CardTypes.Values.ToArray()[13].ImageSource;
                    break;

                default:
                    Console.WriteLine("Invalid image number");
                    break;
            }
        }

        public void Hide()
        {
            if (matched)
            {
                img.ImageSource = imgBlank.ImageSource;
            }
            else
            {
                img.ImageSource = imgBack.ImageSource;
            }
        }
        
        public void Reset()
        {
            matched = false;
        }
    }
}
