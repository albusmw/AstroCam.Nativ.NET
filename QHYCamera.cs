using System;
using System.Runtime.InteropServices;
using System.Text;

// Taken from   https://www.qhyccd.com/index.php?m=content&c=index&a=show&catid=127&id=169

namespace QHY
{
    public class QHYCamera
    {

        public enum CONTROL_ID

        {
            CONTROL_BRIGHTNESS = 0, //!< image brightness
            CONTROL_CONTRAST, //!< image contrast
            CONTROL_WBR, //!< red of white balance
            CONTROL_WBB, //!< blue of white balance
            CONTROL_WBG, //!< the green of white balance
            CONTROL_GAMMA, //!< screen gamma
            CONTROL_GAIN, //!< camera gain
            CONTROL_OFFSET, //!< camera offset
            CONTROL_EXPOSURE, //!< expose time (us)
            CONTROL_SPEED, //!< transfer speed
            CONTROL_TRANSFERBIT, //!< image depth bits
            CONTROL_CHANNELS, //!< image channels
            CONTROL_USBTRAFFIC, //!< hblank
            CONTROL_ROWNOISERE, //!< row denoise
            CONTROL_CURTEMP, //!< current cmos or ccd temprature
            CONTROL_CURPWM, //!< current cool pwm
            CONTROL_MANULPWM, //!< set the cool pwm
            CONTROL_CFWPORT, //!< control camera color filter wheel port
            CONTROL_COOLER, //!< check if camera has cooler
            CONTROL_ST4PORT, //!< check if camera has st4port
            CAM_COLOR,
            CAM_BIN1X1MODE, //!< check if camera has bin1x1 mode
            CAM_BIN2X2MODE, //!< check if camera has bin2x2 mode
            CAM_BIN3X3MODE, //!< check if camera has bin3x3 mode
            CAM_BIN4X4MODE, //!< check if camera has bin4x4 mode
            CAM_MECHANICALSHUTTER, //!< mechanical shutter
            CAM_TRIGER_INTERFACE, //!< triger
            CAM_TECOVERPROTECT_INTERFACE, //!< tec overprotect
            CAM_SINGNALCLAMP_INTERFACE, //!< singnal clamp
            CAM_FINETONE_INTERFACE, //!< fine tone
            CAM_SHUTTERMOTORHEATING_INTERFACE, //!< shutter motor heating
            CAM_CALIBRATEFPN_INTERFACE, //!< calibrated frame
            CAM_CHIPTEMPERATURESENSOR_INTERFACE, //!< chip temperaure sensor
            CAM_USBREADOUTSLOWEST_INTERFACE, //!< usb readout slowest
            CAM_8BITS, //!< 8bit depth
            CAM_16BITS, //!< 16bit depth
            CAM_GPS, //!< check if camera has gps
            CAM_IGNOREOVERSCAN_INTERFACE, //!< ignore overscan area
            QHYCCD_3A_AUTOBALANCE,
            QHYCCD_3A_AUTOEXPOSURE,
            QHYCCD_3A_AUTOFOCUS,
            CONTROL_AMPV, //!< ccd or cmos ampv
            CONTROL_VCAM, //!< Virtual Camera on off
            CAM_VIEW_MODE,
            CONTROL_CFWSLOTSNUM, //!< check CFW slots number
            IS_EXPOSING_DONE,
            ScreenStretchB,
            ScreenStretchW,
            CONTROL_DDR,
            CAM_LIGHT_PERFORMANCE_MODE,
            CAM_QHY5II_GUIDE_MODE,
            DDR_BUFFER_CAPACITY,
            DDR_BUFFER_READ_THRESHOLD
        };

        public enum BAYER_ID
        {
            BAYER_GB = 1,
            BAYER_GR,
            BAYER_BG,
            BAYER_RG
        };

        /// <summary>This function need to be call when first using QHYCCD SDK. If the SDK is already initialized. You can still call this and it will re-initialize the resource. Looks like a new start.</summary>
        /// <returns>This function will return the the QHYCCD_ERROR code. 0=success</returns>
        [DllImport("qhyccd.dll", EntryPoint = "InitQHYCCDResource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 InitQHYCCDResource();

        /// <summary>This function will scan all QHYCCD cameras connecting with the computer. The return value is the number of cameras.</summary>
        /// <returns>If one camera connected with the computer. the return value is 1.  If two cameras connected, it return 2 , and so on.</returns>
        [DllImport("qhyccd.dll", EntryPoint = "ReleaseQHYCCDResource", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 ReleaseQHYCCDResource();

        [DllImport("qhyccd.dll", EntryPoint = "ScanQHYCCD",CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 ScanQHYCCD();

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDId",CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDId(int index, StringBuilder id);

        [DllImport("qhyccd.dll", EntryPoint = "OpenQHYCCD",CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern IntPtr OpenQHYCCD(StringBuilder id);

        /// <summary>
        /// This function will initialize the camera hardware and other basic settings This function should be call after SetQHYCCDStreamMode. After this function called. The camera hardware will be ready to use.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <remarks>In this function. the SDK will initialize some basic setting like the image bit depth, ROI, exposure time etc.   These parameter can be also changed separately later with the Parameter Command.</remarks>
        [DllImport("qhyccd.dll", EntryPoint = "InitQHYCCD", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 InitQHYCCD(IntPtr handle);

        [DllImport("qhyccd.dll", EntryPoint = "CloseQHYCCD",CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 CloseQHYCCD(IntPtr handle);

        [DllImport("qhyccd.dll", EntryPoint = "SetQHYCCDBinMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 SetQHYCCDBinMode(IntPtr handle, UInt32 wbin, UInt32 hbin);

        [DllImport("qhyccd.dll", EntryPoint = "SetQHYCCDParam", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 SetQHYCCDParam(IntPtr handle, CONTROL_ID controlid, double value);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDMemLength", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDMemLength(IntPtr handle);

        [DllImport("qhyccd.dll", EntryPoint = "ExpQHYCCDSingleFrame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 ExpQHYCCDSingleFrame(IntPtr handle);

        [DllImport("qhyccd.dll", EntryPoint = "CancelQHYCCDExposing", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 CancelQHYCCDExposing(IntPtr handle);

        [DllImport("qhyccd.dll", EntryPoint = "CancelQHYCCDExposingAndReadout", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 CancelQHYCCDExposingAndReadout(IntPtr handle);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDSingleFrame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDSingleFrame(IntPtr handle, ref UInt32 w, ref UInt32 h, ref UInt32 bpp, ref UInt32 channels, byte* rawArray);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDSingleFrame", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDSingleFrame(IntPtr handle, ref UInt32 w, ref UInt32 h, ref UInt32 bpp, ref UInt32 channels, IntPtr pBuffer);

        //public unsafe static UInt32 C_GetQHYCCDSingleFrame(IntPtr handle, ref UInt32 w, ref UInt32 h, ref UInt32 bpp, ref UInt32 channels, byte[] rawArray)

        //{

        //    UInt32 ret;
        //    fixed (byte* prawArray = rawArray)
        //    ret = GetQHYCCDSingleFrame(handle, ref w, ref h, ref bpp, ref channels, prawArray);
        //    return ret;

        //}


        /// <summary>
        /// This function will output the basic information of the camera.  Includes the physical pixel size, the basic pixel array size. and the current image depth.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="chipw"></param>
        /// <param name="chiph"></param>
        /// <param name="imagew">The image array width and height is the maxium image width and height. Even in small ROI or in overscan area removed mode. this size will not change.</param>
        /// <param name="imageh">The image array width and height is the maxium image width and height. Even in small ROI or in overscan area removed mode. this size will not change.</param>
        /// <param name="pixelw">Please note the pixel width and pixel height is in physical. So even with BIN22, the pixel size is still the physical pixel size, it will not change with the binning setting.</param>
        /// <param name="pixelh">Please note the pixel width and pixel height is in physical. So even with BIN22, the pixel size is still the physical pixel size, it will not change with the binning setting.</param>
        /// <param name="bpp">The image depth bpp, will be changed if user set the bitDepth by the Set Parameter command </param>
        /// <returns></returns>
        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDChipInfo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDChipInfo(IntPtr handle, ref double chipw, ref double chiph, ref UInt32 imagew, ref UInt32 imageh, ref double pixelw, ref double pixelh, ref UInt32 bpp);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDOverScanArea", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDOverScanArea(IntPtr handle, ref UInt32 startx, ref UInt32 starty, ref UInt32 sizex, ref UInt32 sizey);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDEffectiveArea", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDEffectiveArea(IntPtr handle, ref UInt32 startx, ref UInt32 starty, ref UInt32 sizex, ref UInt32 sizey);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDFWVersion", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDFWVersion(IntPtr handle, byte* verBuf);

        public unsafe static UInt32 C_GetQHYCCDFWVersion(IntPtr handle, byte[] verBuf)

        {

            fixed (byte* pverBuf = verBuf)

                return GetQHYCCDFWVersion(handle, pverBuf);

        }

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDParam", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern double GetQHYCCDParam(IntPtr handle, CONTROL_ID controlid);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDParamMinMaxStep", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDParamMinMaxStep(IntPtr handle, CONTROL_ID controlid, ref double min, ref double max, ref double step);

        [DllImport("qhyccd.dll", EntryPoint = "ControlQHYCCDGuide", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 ControlQHYCCDGuide(IntPtr handle, byte Direction, UInt16 PulseTime);

        [DllImport("qhyccd.dll", EntryPoint = "ControlQHYCCDTemp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 ControlQHYCCDTemp(IntPtr handle, double targettemp);

        [DllImport("qhyccd.dll", EntryPoint = "SendOrder2QHYCCDCFW", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 SendOrder2QHYCCDCFW(IntPtr handle, String order, int length);

        [DllImport("qhyccd.dll", EntryPoint = "IsQHYCCDControlAvailable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 IsQHYCCDControlAvailable(IntPtr handle, CONTROL_ID controlid);

        [DllImport("qhyccd.dll", EntryPoint = "ControlQHYCCDShutter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 ControlQHYCCDShutter(IntPtr handle, byte targettemp);

        [DllImport("qhyccd.dll", EntryPoint = "SetQHYCCDResolution", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 SetQHYCCDResolution(IntPtr handle, UInt32 startx, UInt32 starty, UInt32 sizex, UInt32 sizey);

        /// <summary>
        /// There is two basic streaming mode for QHYCCD. One is the Single Capture Mode. Another is the Video Streaming Mode.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="mode">Mode=0: Single Capture Mode; Mode = 1: Video Streaming Mode</param>
        /// <returns></returns>
        [DllImport("qhyccd.dll", EntryPoint = "SetQHYCCDStreamMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 SetQHYCCDStreamMode(IntPtr handle, UInt32 mode);



        //EXPORTFUNC uint32_t STDCALL GetQHYCCDCFWStatus(qhyccd_handle *handle,char *status)

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDCFWStatus", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDCFWStatus(IntPtr handle, StringBuilder cfwStatus);

        [DllImport("qhyccd.dll", EntryPoint = "GetQHYCCDSDKVersion",CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDSDKVersion(ref UInt32 year, ref UInt32 month, ref UInt32 day, ref UInt32 subday);


    }
}
