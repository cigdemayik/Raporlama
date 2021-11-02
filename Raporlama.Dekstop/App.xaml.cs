using Microsoft.Extensions.DependencyInjection;
using Raporlama.Business.DependencyResolver;
using Raporlama.Desktop.Forms;
using System.Windows;

namespace Raporlama.Dekstop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
           
            services.AddTransient(typeof(LoginForm));

            services.AddDependencies();

        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var userLoginForm = serviceProvider.GetService<LoginForm>();
            userLoginForm.Show();
        }
    }


}
