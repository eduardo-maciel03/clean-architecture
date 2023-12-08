using AppMaui.ShellModels;

namespace AppMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new AppShellViewModel();
        }
    }
}
