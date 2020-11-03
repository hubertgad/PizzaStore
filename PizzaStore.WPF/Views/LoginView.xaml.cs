using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaStore.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public ICommand LoginCommand
        {
            get { return (ICommand)GetValue(LoginCommandProperty); }
            set { SetValue(LoginCommandProperty, value); }
        }

        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(LoginView), new PropertyMetadata(null));

        public LoginView()
        {
            InitializeComponent();
            passwordBox.Password = "aaa";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginCommand != null)
            {
                string password = passwordBox.Password;
                LoginCommand.Execute(password);
            }
        }
    }
}