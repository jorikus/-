using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			mode = DrowMode.LINE;
		}

		enum DrowMode
		{
			PEN,
			LINE,
			ELLIPS,
			RECTANGLE
		}

		Point startPoint;
		Line line;
		Ellipse ellipse;
		Rectangle rectangle;

		Color color;
		Color fillColor;

		DrowMode mode;

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			mode = DrowMode.LINE;
		}
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			mode = DrowMode.PEN;
		}
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
			mode = DrowMode.ELLIPS;
		}
		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			mode = DrowMode.RECTANGLE;
		}

		private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
			startPoint = e.GetPosition(canvas);
            switch (mode)
            {
				case DrowMode.PEN:
					startPoint = e.GetPosition(canvas);
					break;
				case DrowMode.LINE:
					line = new Line();
					line.Stroke = new SolidColorBrush(color);
					line.X1 = startPoint.X;
					line.X2 = startPoint.X;
					line.Y1 = startPoint.Y;
					line.Y2 = startPoint.Y;
					canvas.Children.Add(line);
					break;
				case DrowMode.ELLIPS:
					ellipse = new Ellipse();
					ellipse.Stroke = new SolidColorBrush(color);
					canvas.Children.Add(ellipse);
					Canvas.SetTop(ellipse, startPoint.Y);
					Canvas.SetLeft(ellipse, startPoint.X);
					ellipse.Width = 0;
					ellipse.Height = 0;
					break;
				case DrowMode.RECTANGLE:
					rectangle = new Rectangle();
					rectangle.Stroke = new SolidColorBrush(color);
					canvas.Children.Add(rectangle);
					Canvas.SetTop(rectangle, startPoint.Y);
					Canvas.SetLeft(rectangle, startPoint.X);
					rectangle.Width = 0;
					rectangle.Height = 0;
					break;
			}
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
			if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (mode)
                {
					case DrowMode.PEN:
						Point tempPoint_1 = e.GetPosition(canvas);
						line = new Line();
						line.Stroke = new SolidColorBrush(color);
						line.X1 = startPoint.X;
						line.Y1 = startPoint.Y;
						line.X2 = tempPoint_1.X;
						line.Y2 = tempPoint_1.Y;
						canvas.Children.Add(line);
						startPoint = tempPoint_1;
						break;
					case DrowMode.LINE:
						line.X2 = e.GetPosition(canvas).X;
						line.Y2 = e.GetPosition(canvas).Y;
						break;
					case DrowMode.ELLIPS:
						Point tempPoint_2 = e.GetPosition(canvas);
						double w = tempPoint_2.X - startPoint.X;
						double h = tempPoint_2.Y - startPoint.Y;
						if (w < 0)
                        {
							w = -w;
							Canvas.SetLeft(ellipse, tempPoint_2.X);
                        }
						if (h < 0)
                        {
							h = -h;
							Canvas.SetTop(ellipse, tempPoint_2.Y);
                        }
						ellipse.Width = w;
						ellipse.Height = h;
						break;
					case DrowMode.RECTANGLE:
						Point tempPoint_3 = e.GetPosition(canvas);
						double w2 = tempPoint_3.X - startPoint.X;
						double h2 = tempPoint_3.Y - startPoint.Y;
						if (w2 < 0)
						{
							w2 = -w2;
							Canvas.SetLeft(rectangle, tempPoint_3.X);
						}
						if (h2 < 0)
						{
							h2 = -h2;
							Canvas.SetTop(rectangle, tempPoint_3.Y);
						}
						rectangle.Width = w2;
						rectangle.Height = h2;
						break;
				}
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				color = ((SolidColorBrush)((Label)sender).Background).Color;
			}
			else if (e.RightButton == MouseButtonState.Pressed)
			{
				fillColor = ((SolidColorBrush)((Label)sender).Background).Color;
			}
		}

        
    }
}
