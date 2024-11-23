using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color storkeColor = Colors.Black;
        Brush strokeBrush = Brushes.Black;
        Point start, dest;
        public MainWindow()
        {
            InitializeComponent();
            strokeColorPicker.SelectedColor = storkeColor;
        }

        private void myCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //把滑鼠變成筆
            myCanvas.Cursor = Cursors.Pen;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //從e取得滑鼠放開座標
            dest = e.GetPosition(myCanvas);
            //按下去起點變化，放開終點鎖定
            statusPoint.Content = $"({Convert.ToInt32(start.X)},{Convert.ToInt32(start.Y)}) - ({Convert.ToInt32(dest.X)},{Convert.ToInt32(dest.Y)})";
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var brush = new SolidColorBrush(storkeColor);
            //滑鼠放開，畫線
            Line line = new Line
            {
                X1 = start.X,
                Y1 = start.Y,
                X2 = dest.X,
                Y2 = dest.Y,
                Stroke = brush,
                StrokeThickness = 2
            };
            myCanvas.Children.Add(line);
        }

        private void strokeColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            storkeColor = strokeColorPicker.SelectedColor.Value;
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //從e取得滑鼠按下座標，改變鼠標
            start = e.GetPosition(myCanvas);
            myCanvas.Cursor = Cursors.Cross;
        }
    }
}