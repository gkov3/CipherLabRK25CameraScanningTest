using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MWBarcodeScanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RK25CameraTest.Droid
{
    public class CameraBarcodeScanner: ICameraBarcode
    {
		public Context Context { get; }
		public CameraBarcodeScanner(Context context)
		{
			this.Context = context;
			BarcodeConfig.MWB_setDirection(BarcodeConfig.MWB_SCANDIRECTION_HORIZONTAL | BarcodeConfig.MWB_SCANDIRECTION_VERTICAL);
			BarcodeConfig.MWB_setActiveCodes(BarcodeConfig.MWB_CODE_MASK_39 | BarcodeConfig.MWB_CODE_MASK_128 | BarcodeConfig.MWB_CODE_MASK_EANUPC | BarcodeConfig.MWB_CODE_MASK_QR);
			BarcodeConfig.MWB_setLevel(2);
		}

        

        public async Task<BarcodeResult> ScanBarcode()
        {
			var scanner = new MWBarcodeScanner.Scanner(Context);
			scanner.initDecoder();
			scanner.useHiRes = false;
			var result = await scanner.Scan();
			return new BarcodeResult
			{
				Code = result?.code,
				Type = result?.type
			};
		}

	}
}