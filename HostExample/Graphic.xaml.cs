using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Image = System.Windows.Controls.Image;

namespace HostExample
{
    /// <summary>
    /// Interaction logic for Graphic.xaml
    /// </summary>
    public partial class Graphic : Window
    {
        private Image _image;

        public Graphic()
        {
            InitializeComponent();
            //TraceGraphic();

            _image = new Image() { Name = "Histograms" };
            MainGrid.Children.Add(_image);
            _image.Source = DrawHistogram(300, new int[] { 45, 12, 11, 69, 99, 1, 25, 100 });


        }
        public async void StartParty()
        {
            await Task.Delay(1000);

            _image.Source = DrawHistogram(300, new int[] { 45, 12, 11, 69, 99, 1, 25, 100, 30 });
            //Show();
            await Task.Delay(1000);
            

            _image.Source = DrawHistogram(300, new int[] { 45, 25, 100, 30 });

            await Task.Delay(1000);
           
            _image.Source = DrawHistogram(300, new int[] { 45, 12, 11, 69, 99 });
            await Task.Delay(1000);
            
            _image.Source = DrawHistogram(300, new int[] { 45, 12, 11, 69, 99, 1, 25, 100, 30 });
            await Task.Delay(1000);
             
            _image.Source = DrawHistogram(300, new int[] { 11, 69, 99, 1, 25 });
            StartParty();
        }
 
        public BitmapImage DrawHistogram(int imageWidth, int[] histogram)
        {

            int width = imageWidth;
            int height = width;

            var graphical = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(graphical))
            {
                graphics.FillRectangle(Brushes.Transparent, 0, 0, width, height);

                int lasBarEnding = 0;
                int barWidth = width / histogram.Length;

                foreach (var item in histogram)
                {
                    int yStart = (int)(height - (item / 100.0 * height));

                    graphics.FillRectangle(Brushes.Brown, lasBarEnding, yStart, barWidth, height - yStart);
                    graphics.DrawRectangle(new System.Drawing.Pen(Color.PowderBlue, 1), lasBarEnding, yStart, barWidth, height - yStart);
                    lasBarEnding += barWidth + 1;
                }
            }

            using (MemoryStream memory = new MemoryStream())
            {
                graphical.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
