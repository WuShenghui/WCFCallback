using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using Windows_Client_WCF_CallBack.ServiceReference;
using WPF_Client_WCF_CallBack;

namespace Windows_Client_WCF_CallBack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceClient Proxy;
        RequestCallBack callback;
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {


            callback = new RequestCallBack(this);
            //Get the InstanceContext with the help of the CallBack contract class
            InstanceContext context = new InstanceContext(callback);
            Proxy = new ServiceClient(context);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region Test 1
            //Proxy.GetData("mahesh", "mahesh");
            //MessageBox.Show("Values are send to the service");
            #endregion

            #region Test 2,Data from Database
            var textRange = new TextRange(txtResult.Document.ContentStart, txtResult.Document.ContentEnd);
            if (textRange.Text.Length > 0)
            {
                //txtResult.Document.Blocks.Clear();
                textRange.Text = string.Format("Please wait\nResult:\n\n");
            }

            try
            {
                Proxy.GetStoreProcedureData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion
        }
    }
}