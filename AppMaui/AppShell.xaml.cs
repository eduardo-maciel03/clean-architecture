using AppMaui.ShellModels;

namespace AppMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new AppShellViewModel();

            var rememberMe = Preferences.Default.Get<bool>(Constants.RememberMe, false);
            StorageOptionsShell.CurrentItem = rememberMe ? HomeViewItem : LoginViewItem;
        }
    }
}
