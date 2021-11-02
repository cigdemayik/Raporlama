using Raporlama.Business.Abstracts.Interfaces;
using Raporlama.Business.Dtos.UserDtos;
using Raporlama.Desktop.Models;
using Raporlama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    public partial class ResponsiveForm : Window
    {
        private readonly IReportService _reportService;
        UserDto _user;
        public ResponsiveForm(IReportService reportService, UserDto user)
        {
            _user = user;
            _reportService = reportService;
            InitializeComponent();
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

        private void btnSatinAlma_click(object sender, RoutedEventArgs e)
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


        private void dtgReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ClearDataGrid()
        {
            dtgReport.ItemsSource = null;
        }

        private void btnLogout_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
