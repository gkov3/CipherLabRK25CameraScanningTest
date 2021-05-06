using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RK25CameraTest
{
    public partial class MainPage : ContentPage
    {

        public int  Count{ get; set; }
        public String Barcode { get; set; }
        public String Type { get; set; }
        public String Error { get; set; }

        public ICommand ScanBarcode { get; }
        public MainPage()
        {
            InitializeComponent();
            ScanBarcode = new Command(async (o) => await OnScanBarcode(o));
            BindingContext = this;
        }

        private async Task OnScanBarcode(object obj)
        {
            try
            {

                var t = await Xamarin.Forms.DependencyService.Resolve<ICameraBarcode>(DependencyFetchTarget.GlobalInstance).ScanBarcode();
                Count++;
                Error = "";
                Barcode = t.Code;
                Type = t.Type;

            }
            catch (Exception e)
            {
                Error = e.ToString();
            }
            finally {
                OnPropertyChanged(null);
            }


        }

        

        
    }
}
