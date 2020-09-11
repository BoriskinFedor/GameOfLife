using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public GameEngine game;
        WriteableBitmap writeableBmp;
        public int GenerationCounter = 0;
        public int WindowWidth;
        public int WindowHeight;
        bool EnableFutureView = false;
        Color StableStateColor = Colors.LightGray;
        Color DieStateColor = Colors.Orange;
        Color LifeStateColor = Colors.LightGreen;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeParameters()
        {
            timer.Interval = TimeSpan.FromTicks(1000000);
            timer.Tick += NextGen;

            game = new GameEngine(WindowWidth, WindowHeight, 8, 8, false);
        }

        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();
            subWindow.Owner = this;
            subWindow.Show();
        }

        public void RefreshGrido()
        {
            //Grido.Children.Clear();
            writeableBmp.Clear();

            Text_GenCounter.Text = $"Поколение: {GenerationCounter}";
            int Resolution = game.CellSize;
            Color color = Colors.LightGray;
            bool Condition;

            for (int x = 0; x < game.Cols; x++)
            {
                for (int y = 0; y < game.Rows; y++)
                {
                    if (EnableFutureView)
                        color = FutureViewColor(x, y);

                    Condition = game.Field[x, y] || color == LifeStateColor;
                    if (Condition)
                    {
                        int realX = x * Resolution;
                        int realY = y * Resolution;
                        writeableBmp.FillRectangle(realX, realY, realX + Resolution - 1, realY + Resolution - 1, color);
                    }
                }
            }
        }

        public Color FutureViewColor(int x, int y)
        {
            int currentIndex = game.Field[x, y] ? 1 : 0;
            int nextIndex = game.FieldNext[x, y] ? 1 : 0;

            if (nextIndex - currentIndex == 1)
                return LifeStateColor;
            else if (nextIndex - currentIndex == -1)
                return DieStateColor;
            return StableStateColor;
        }

        private void NextGen(object sender, EventArgs e)
        {
            game.NextGeneration();
            GenerationCounter++;
            RefreshGrido();
        }

        private void MenuItem_OneStep_Click(object sender, RoutedEventArgs e)
        {
            game.NextGeneration();
            GenerationCounter++;
            RefreshGrido();
        }

        private void BitmapImage_Loaded(object sender, RoutedEventArgs e)
        {
            WindowWidth = (int)Bitmap.ActualWidth;
            WindowHeight = (int)Bitmap.ActualHeight;
            writeableBmp = BitmapFactory.New(WindowWidth, WindowHeight);
            bitmapImage.Source = writeableBmp;

            InitializeParameters();
        }

        private void BitmapImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (game != null)
            {
                if (GenerationCounter == 0)
                    GenerationCounter = 1;

                Point point = e.GetPosition(bitmapImage);
                int X = (int)point.X / game.CellSize;
                int Y = (int)point.Y / game.CellSize;

                X = X >= game.Cols ? X - 1 : X;
                Y = Y >= game.Rows ? Y - 1 : Y;

                game.AddLiveCell(X, Y);
                RefreshGrido();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EnableFutureView = true;
            RefreshGrido();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            EnableFutureView = false;
            RefreshGrido();
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
                timer.Stop();
        }

        private void Button_Run_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
                timer.Start();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Clear_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
                timer.Stop();

            game = new GameEngine(WindowWidth, WindowHeight, 8, 8, false);
            RefreshGrido();
        }
    }
}
