using System;
using System.Windows;


namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        public GameEngine game;
        private bool IsRandom;
        private bool IsLooped;
        private int Cellsize;
        private int Density;

        public SubWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            int fieldWidth = mainWindow.WindowWidth;
            int fieldHeight = mainWindow.WindowHeight;

            Cellsize = (int)SliderCellsize.Value;
            Density = (int)SliderDensity.Value;

            game = new GameEngine(fieldWidth, fieldHeight, Cellsize, Density, IsRandom, IsLooped);
            game.StartGame();
            mainWindow.game = game;

            mainWindow.GenerationCounter = 1;
            mainWindow.RefreshGrido();

            this.Close();
        }

        private void CheckBox_Random_Checked(object sender, RoutedEventArgs e)
        {
            IsRandom = true;
        }

        private void CheckBox_Random_Unchecked(object sender, RoutedEventArgs e)
        {
            IsRandom = false;
        }

        private void CheckBox_Looped_Checked(object sender, RoutedEventArgs e)
        {
            IsLooped = true;
        }

        private void CheckBox_Looped_Unchecked(object sender, RoutedEventArgs e)
        {
            IsLooped = false;
        }
    }
}
