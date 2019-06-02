using System.Windows.Controls;

namespace WPFGame
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
            DataContext = new GameViewModel();
        }
    }
}