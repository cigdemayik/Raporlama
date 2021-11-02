using Raporlama.Business.Abstracts.Interfaces;
using Raporlama.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Raporlama.Desktop.Forms
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        private readonly IUserService _userService;
        private readonly IReportService _reportService;
        public LoginForm(IUserService userService, IReportService reportService)
        {
            _reportService = reportService;
            _userService = userService;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var dto = new UserLoginDto()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Password

            };
            var result = _userService.SignIn(dto);

            if (result.IsSuccessful)
            {
                ListForm listForm = new ListForm(_reportService, result.Result);
                listForm.Show();
                this.Close();           }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

