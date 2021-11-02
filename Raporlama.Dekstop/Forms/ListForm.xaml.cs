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
    /// Interaction logic for ListForm.xaml
    /// </summary>
    public partial class ListForm : Window
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        UserDto _user;
        public ListForm(IReportService reportService, UserDto user)
        {
            _user = user;
            _reportService = reportService;
            InitializeComponent();
            lblUser.Text = _user.Name;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_max_Click(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                grd_main.Margin = new Thickness(0, 0, 0, 0);
                dtgReport.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                this.WindowState = WindowState.Normal;
                grd_main.Margin = new Thickness(15);
            }
        }
        private void btnMuhasebe_click(object sender, RoutedEventArgs e)
        {
            ClearDataGrid();
            int reportType = 2;

            var result = _reportService.GetByCompanyIdAndReportType(_user.CompanyId, reportType);

            if (result.IsSuccessful)
            {
                dtgReport.ItemsSource = result.Result;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Sorun", MessageBoxButton.OK);
            }
        }

        private void btnFinans_click(object sender, RoutedEventArgs e)
        {
            ClearDataGrid();
            int reportType = 1;
            var result = _reportService.GetByCompanyIdAndReportType(_user.CompanyId, reportType);

            if (result.IsSuccessful)
            {
                dtgReport.ItemsSource = result.Result;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Sorun", MessageBoxButton.OK);
            }
        }

        private void btnSatinalma_click(object sender, RoutedEventArgs e)
        {
            ClearDataGrid();
            int reportType = 3;
            var result = _reportService.GetByCompanyIdAndReportType(_user.CompanyId, reportType);

            if (result.IsSuccessful)
            {
                dtgReport.ItemsSource = result.Result;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Sorun", MessageBoxButton.OK);
            }
            //işlemler
        }

        private void btnSatis_click(object sender, RoutedEventArgs e)
        {
            ClearDataGrid();
            int reportType = 4;
            var result = _reportService.GetByCompanyIdAndReportType(_user.CompanyId, reportType);

            if (result.IsSuccessful)
            {
                dtgReport.ItemsSource = result.Result;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Sorun", MessageBoxButton.OK);
            }
        }
        private void ClearDataGrid()
        {
            dtgReport.ItemsSource = null;
        }

        private void btn_hamburgermenuMousedown(object sender, MouseButtonEventArgs e)
        {
            if (btn_hamburgermenu.Width != 60) 
            { 

            GridLength grid = new GridLength(80, GridUnitType.Pixel);
            grd_column.Width= grid;

            lbl_menu1.Visibility = Visibility.Hidden;
            lbl_menu2.Visibility = Visibility.Hidden;
            lbl_menu3.Visibility = Visibility.Hidden;
            lbl_menu4.Visibility = Visibility.Hidden;

            lbl_logo.Width = 0;
            btn_hamburgermenu.Width = 60;
            lbl_altpencere.Visibility = Visibility.Hidden;
            }
            else
            {
                GridLength grid = new GridLength(220, GridUnitType.Pixel);
                grd_column.Width = grid;

                lbl_menu1.Visibility = Visibility.Visible;
                lbl_menu2.Visibility = Visibility.Visible;
                lbl_menu3.Visibility = Visibility.Visible;
                lbl_menu4.Visibility = Visibility.Visible;

                lbl_logo.Width = 150;
                btn_hamburgermenu.Width =100;
                lbl_altpencere.Visibility = Visibility.Visible;
            }
        }

        private void btnLogout_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm(_userService, _reportService);
            login.Show();
           
        }
    }
}
