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
using WPFDevelopers.Helpers;
using System.Media;
using System.Windows.Media.Animation;
using System.IO;
//using EMTD.ComLibrary;
using Shake;
namespace Wpf_Study
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
      

        private void Clik_me_Click(object sender, RoutedEventArgs e)
        {
            TextBoxShowHello.Text = "你好！欢迎登录!";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void TextBoxShowHello_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;          // 把窗口自身当 ViewModel

        }

        
        private ICommand _shakeCmd;
        public ICommand ShakeWindowCommand =>
            _shakeCmd ?? (_shakeCmd = new RelayCommand(o => WindowHelper.WindowShake()));
        // 就地放一个 RelayCommand
        public class RelayCommand : ICommand
        {
            private readonly Action<object> _execute;
            public RelayCommand(Action<object> execute) => _execute = execute;
            public bool CanExecute(object parameter) => true;
            public void Execute(object parameter) => _execute(parameter);
            public event EventHandler CanExecuteChanged { add { } remove { } }
        }

    }
}
