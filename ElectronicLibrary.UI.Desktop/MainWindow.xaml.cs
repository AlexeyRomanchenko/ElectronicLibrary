using ElectronicLibrary.UI.Desktop.ViewModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ElectronicLibrary.UI.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var loadBusinessTask = Task.Run(()=> {
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());
                Thread.Sleep(5000);
                var businessData = File.ReadAllLines($"{Environment.CurrentDirectory}\\Store\\business.csv");
                System.Diagnostics.Debug.WriteLine("Business " + DateTime.Now.ToString());
                return businessData;
            });
            var loadFinancialTask = Task.Run(()=> 
            {
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());
                Thread.Sleep(5000);
                var financies = File.ReadAllLines($"{Environment.CurrentDirectory}\\Store\\financial.csv");
                System.Diagnostics.Debug.WriteLine("Financial " + DateTime.Now.ToString());
                return financies;
            });
            //, TaskContinuationOptions.OnlyOnRanToCompletion
            loadBusinessTask.ContinueWith(task => 
            {
                // ConcurrentBag is a thread safe option of list
                var businesses = new ConcurrentBag<BusinessViewModel>();
                foreach (string businessInfo in task.Result.Skip(1))
                {
                    var data = businessInfo.Split(',');
                    var businessViewModel = new BusinessViewModel
                    {
                        Description = data[0],
                        Industry = data[1],
                        Size = data[2]
                    };
                    businesses.Add(businessViewModel);
                }
                Dispatcher.Invoke(() =>
                {
                    economicsGrid.ItemsSource = businesses;
                });
                System.Diagnostics.Debug.WriteLine("Throwing source " + DateTime.Now.ToString());
                System.Diagnostics.Debug.WriteLine("Here I am");
            });
           
        }
    }
}
