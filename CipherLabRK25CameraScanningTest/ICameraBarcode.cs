using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RK25CameraTest
{

    public class BarcodeResult {
        public String Code { get; set; }
        public String Type { get; set; }
    }
    public interface ICameraBarcode
    {
        Task<BarcodeResult> ScanBarcode();
    }
}
