using System;
using System.Runtime.InteropServices;
using System.Text;

// Taken from   https://www.qhyccd.com/index.php?m=content&c=index&a=show&catid=127&id=169
//              https://note.youdao.com/share/?token=9991AC90E811437290EB9AD0D2B15912&gid=7195236
//              https://www.qhyccd.com/index.php?m=content&c=index&a=show&catid=94&id=55&cut=1
//              C:\Users\albusmw\Dropbox\Astro\Literatur\QHY SDK Doku.pdf

namespace QHY
{
    ///<summary>DLL functions for the QHY cameras.</summary>
    public class QHYCamera
    {

        const string DLLName = "qhyccd.dll";
        const CharSet DLLCharSet = CharSet.Ansi;
        const CallingConvention DLLCallCon = CallingConvention.StdCall;

        ///<summary>Error codes.</summary>
        public enum QHYCCD_ERROR
        {
            ///<summary>No error.</summary>
            QHYCCD_SUCCESS = 0,
            ///<summary>Error (no further information).</summary>
            QHYCCD_ERROR = -1,
            ///<summary>No device present.</summary>
            QHYCCD_ERROR_NO_DEVICE =     -2,
            
        }

        /// <summary>Available control ID's.</summary>
        public enum CONTROL_ID
        {
            /// <summary>image brightness.</summary>
            CONTROL_BRIGHTNESS = 0,
            /// <summary>image contrast</summary>
            CONTROL_CONTRAST,
            /// <summary>red of white balance</summary>
            CONTROL_WBR,
            /// <summary>blue of white balance</summary>
            CONTROL_WBB,
            /// <summary>the green of white balance</summary>
            CONTROL_WBG,
            /// <summary>screen gamma</summary>
            CONTROL_GAMMA,
            /// <summary>camera gain</summary>
            CONTROL_GAIN,
            /// <summary>camera offset</summary>
            CONTROL_OFFSET,
            /// <summary>expose time (us)</summary>
            CONTROL_EXPOSURE,
            /// <summary>transfer speed</summary>
            CONTROL_SPEED,
            /// <summary>image depth bits</summary>
            CONTROL_TRANSFERBIT,
            /// <summary>image channels</summary>
            CONTROL_CHANNELS,
            /// <summary>hblank</summary>
            CONTROL_USBTRAFFIC,
            /// <summary>row denoise</summary>
            CONTROL_ROWNOISERE,
            /// <summary>current cmos or ccd temprature</summary>
            CONTROL_CURTEMP,
            /// <summary>current cool pwm</summary>
            CONTROL_CURPWM,
            /// <summary>set the cool pwm</summary>
            CONTROL_MANULPWM,
            /// <summary>Control camera color filter wheel port</summary>
            CONTROL_CFWPORT,
            /// <summary>check if camera has cooler</summary>
            CONTROL_COOLER,
            /// <summary>check if camera has st4port</summary>
            CONTROL_ST4PORT,
            CAM_COLOR,
            /// <summary>check if camera has bin1x1 mode</summary>
            CAM_BIN1X1MODE,
            /// <summary>check if camera has bin2x2 mode</summary>
            CAM_BIN2X2MODE,
            /// <summary>check if camera has bin3x3 mode</summary>
            CAM_BIN3X3MODE,
            /// <summary>check if camera has bin4x4 mode</summary>
            CAM_BIN4X4MODE,
            /// <summary>mechanical shutter</summary>
            CAM_MECHANICALSHUTTER,
            /// <summary>triger</summary>
            CAM_TRIGER_INTERFACE,
            /// <summary>tec overprotect</summary>
            CAM_TECOVERPROTECT_INTERFACE,
            /// <summary>singnal clamp</summary>
            CAM_SINGNALCLAMP_INTERFACE,
            /// <summary>fine tone</summary>
            CAM_FINETONE_INTERFACE,
            /// <summary>shutter motor heating</summary>
            CAM_SHUTTERMOTORHEATING_INTERFACE,
            /// <summary>calibrated frame</summary>
            CAM_CALIBRATEFPN_INTERFACE,
            /// <summary>chip temperaure sensor</summary>
            CAM_CHIPTEMPERATURESENSOR_INTERFACE,
            /// <summary>usb readout slowest</summary>
            CAM_USBREADOUTSLOWEST_INTERFACE,
            /// <summary>8bit depth</summary>
            CAM_8BITS,
            /// <summary>16bit depth</summary>
            CAM_16BITS,
            /// <summary>Check if camera has gps</summary>
            CAM_GPS,
            /// <summary>Ignore overscan area</summary>
            CAM_IGNOREOVERSCAN_INTERFACE,
            QHYCCD_3A_AUTOBALANCE,
            QHYCCD_3A_AUTOEXPOSURE,
            QHYCCD_3A_AUTOFOCUS,
            /// <summary>ccd or cmos ampv</summary>
            CONTROL_AMPV,
            /// <summary>Virtual Camera on off</summary>
            CONTROL_VCAM,
            CAM_VIEW_MODE,
            /// <summary>Check CFW slots number</summary>
            CONTROL_CFWSLOTSNUM,
            IS_EXPOSING_DONE,
            ScreenStretchB,
            ScreenStretchW,
            CONTROL_DDR,
            CAM_LIGHT_PERFORMANCE_MODE,
            CAM_QHY5II_GUIDE_MODE,
            DDR_BUFFER_CAPACITY,
            DDR_BUFFER_READ_THRESHOLD
        };

        /// <summary>Bayer pattern orientation.</summary>
        public enum BAYER_ID
        {
            BAYER_GB = 1,
            BAYER_GR,
            BAYER_BG,
            BAYER_RG
        };

        /// <summary>This function need to be call when first using QHYCCD SDK. If the SDK is already initialized. You can still call this and it will re-initialize the resource. Looks like a new start.</summary>
        /// <returns>This function will return the QHYCCD_ERROR code (0=success).</returns>
        [DllImport(DLLName, EntryPoint = "InitQHYCCDResource", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 InitQHYCCDResource();

        /// <summary>Release camera resource.</summary>
        /// <returns>This function will return the QHYCCD_ERROR code (0=success).</returns>
        [DllImport(DLLName, EntryPoint = "ReleaseQHYCCDResource", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 ReleaseQHYCCDResource();

        /// <summary>This function will scan all QHYCCD cameras connecting with the computer. The return value is the number of cameras.</summary>
        /// <returns>If one camera connected with the computer. the return value is 1.  If two cameras connected, it return 2 , and so on.</returns>
        [DllImport(DLLName, EntryPoint = "ScanQHYCCD",CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 ScanQHYCCD();

        [DllImport(DLLName, EntryPoint = "GetQHYCCDId",CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDId(int index, StringBuilder id);

        [DllImport(DLLName, EntryPoint = "OpenQHYCCD",CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern IntPtr OpenQHYCCD(StringBuilder id);

        /// <summary>This function will initialize the camera hardware and other basic settings This function should be call after SetQHYCCDStreamMode. After this function called. The camera hardware will be ready to use.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        /// <remarks>In this function. the SDK will initialize some basic setting like the image bit depth, ROI, exposure time etc. These parameter can be also changed separately later with the Parameter Command.</remarks>
        [DllImport(DLLName, EntryPoint = "InitQHYCCD", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 InitQHYCCD(IntPtr handle);

        [DllImport(DLLName, EntryPoint = "CloseQHYCCD",CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 CloseQHYCCD(IntPtr handle);

        /// <summary>Set camera's bin mode for ouput image data.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="wbin">Width bin mode.</param>
        /// <param name="hbin">Height bin mode.</param>
        [DllImport(DLLName, EntryPoint = "SetQHYCCDBinMode", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 SetQHYCCDBinMode(IntPtr handle, UInt32 wbin, UInt32 hbin);

        /// <summary>Set params to camera.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="controlid">Function type.</param>
        /// <param name="value">Value to camera.</param>
        [DllImport(DLLName, EntryPoint = "SetQHYCCDParam", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 SetQHYCCDParam(IntPtr handle, CONTROL_ID controlid, double value);

        /// <summary>The length of memory required to reach a frame image can be obtained, and the space for image data can be opened up according to the return value.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <returns>Memory [byte] for storing one frame.</returns>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDMemLength", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDMemLength(IntPtr handle);

        /// <summary>Start the expose of a frame.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        [DllImport(DLLName, EntryPoint = "ExpQHYCCDSingleFrame", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 ExpQHYCCDSingleFrame(IntPtr handle);

        [DllImport(DLLName, EntryPoint = "CancelQHYCCDExposing", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 CancelQHYCCDExposing(IntPtr handle);

        [DllImport(DLLName, EntryPoint = "CancelQHYCCDExposingAndReadout", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 CancelQHYCCDExposingAndReadout(IntPtr handle);

        [DllImport(DLLName, EntryPoint = "GetQHYCCDSingleFrame", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDSingleFrame(IntPtr handle, ref UInt32 w, ref UInt32 h, ref UInt32 bpp, ref UInt32 channels, byte* rawArray);

        /// <summary>Used to get a frame image data and store data in "ImgData" variate.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="w">The width of image</param>
        /// <param name="h">The height of image</param>
        /// <param name="bpp">The bit depth of image</param>
        /// <param name="channels">The channel of image</param>
        /// <param name="pBuffer">Used to receive image data</param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDSingleFrame", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDSingleFrame(IntPtr handle, ref UInt32 w, ref UInt32 h, ref UInt32 bpp, ref UInt32 channels, IntPtr pBuffer);

        //public unsafe static UInt32 C_GetQHYCCDSingleFrame(IntPtr handle, ref UInt32 w, ref UInt32 h, ref UInt32 bpp, ref UInt32 channels, byte[] rawArray)

        //{

        //    UInt32 ret;
        //    fixed (byte* prawArray = rawArray)
        //    ret = GetQHYCCDSingleFrame(handle, ref w, ref h, ref bpp, ref channels, prawArray);
        //    return ret;

        //}


        /// <summary>This function will output the basic information of the camera.  Includes the physical pixel size, the basic pixel array size. and the current image depth.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="chipw"></param>
        /// <param name="chiph"></param>
        /// <param name="imagew">The image array width and height is the maxium image width and height. Even in small ROI or in overscan area removed mode. this size will not change.</param>
        /// <param name="imageh">The image array width and height is the maxium image width and height. Even in small ROI or in overscan area removed mode. this size will not change.</param>
        /// <param name="pixelw">Please note the pixel width and pixel height is in physical. So even with BIN22, the pixel size is still the physical pixel size, it will not change with the binning setting.</param>
        /// <param name="pixelh">Please note the pixel width and pixel height is in physical. So even with BIN22, the pixel size is still the physical pixel size, it will not change with the binning setting.</param>
        /// <param name="bpp">The image depth bpp, will be changed if user set the bitDepth by the Set Parameter command </param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDChipInfo", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDChipInfo(IntPtr handle, ref double chipw, ref double chiph, ref UInt32 imagew, ref UInt32 imageh, ref double pixelw, ref double pixelh, ref UInt32 bpp);

        /// <summary>Some CCD have overscan area,this function is used to get the size and start position of image.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="startx">The start position of image overscan area in horizontal direction.</param>
        /// <param name="starty">The start position of image overscan area in vertical direction.</param>
        /// <param name="sizex">The width of image overscan area.</param>
        /// <param name="sizey">The height of image overscan area.</param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDOverScanArea", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDOverScanArea(IntPtr handle, ref UInt32 startx, ref UInt32 starty, ref UInt32 sizex, ref UInt32 sizey);

        /// <summary>Used to get effective size and start position.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="startx">The start position of image effective area in horizontal direction.</param>
        /// <param name="starty">The start position of image effective area in vertical direction.</param>
        /// <param name="sizex">The width of image effective area.</param>
        /// <param name="sizey">The height of image effective area.</param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDEffectiveArea", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDEffectiveArea(IntPtr handle, ref UInt32 startx, ref UInt32 starty, ref UInt32 sizex, ref UInt32 sizey);

        [DllImport(DLLName, EntryPoint = "GetQHYCCDFWVersion", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDFWVersion(IntPtr handle, byte* verBuf);

        [DllImport(DLLName, EntryPoint = "GetQHYCCDParam", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern double GetQHYCCDParam(IntPtr handle, CONTROL_ID controlid);

        /// <summary>Used to get camera parameter's maximum,minimum and step,you can know about camera parameter's range and step(for example gain offset),the parameter object obtained is determined by the CONTROL_ID.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="controlid">The control ID to check the range for.</param>
        /// <param name="min">The parameter's minimum.</param>
        /// <param name="max">The parameter's maximum.</param>
        /// <param name="step">The parameter's step.</param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDParamMinMaxStep", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern QHYCCD_ERROR GetQHYCCDParamMinMaxStep(IntPtr handle, CONTROL_ID controlid, ref double min, ref double max, ref double step);

        [DllImport(DLLName, EntryPoint = "ControlQHYCCDGuide", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 ControlQHYCCDGuide(IntPtr handle, byte Direction, UInt16 PulseTime);

        [DllImport(DLLName, EntryPoint = "ControlQHYCCDTemp", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 ControlQHYCCDTemp(IntPtr handle, double targettemp);

        [DllImport(DLLName, EntryPoint = "SendOrder2QHYCCDCFW", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 SendOrder2QHYCCDCFW(IntPtr handle, String order, int length);

        /// <summary>Used to check if camera has some function by macro.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="controlid">The control ID to check the availability.</param>
        /// <returns>If the camera has some function, it will return QHYCCD_SUCCESS, if not, it will return QHYCCD_ERROR.</returns>
        /// <remarks>When you use the function to check if camera is color camera(CAM_COLOR) the function will return camera's bayer order if it executes successfully, if not, it will return QHYCCD_ERROR.</remarks>
        [DllImport(DLLName, EntryPoint = "IsQHYCCDControlAvailable", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern QHYCCD_ERROR IsQHYCCDControlAvailable(IntPtr handle, CONTROL_ID controlid);

        [DllImport(DLLName, EntryPoint = "ControlQHYCCDShutter", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 ControlQHYCCDShutter(IntPtr handle, byte targettemp);

        [DllImport(DLLName, EntryPoint = "SetQHYCCDResolution", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 SetQHYCCDResolution(IntPtr handle, UInt32 startx, UInt32 starty, UInt32 sizex, UInt32 sizey);

        /// <summary>There is two basic streaming mode for QHYCCD. One is the Single Capture Mode. Another is the Video Streaming Mode.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="mode">Mode=0: Single Capture Mode; Mode = 1: Video Streaming Mode</param>
        /// <returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        [DllImport(DLLName, EntryPoint = "SetQHYCCDStreamMode", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 SetQHYCCDStreamMode(IntPtr handle, UInt32 mode);

        //EXPORTFUNC uint32_t STDCALL GetQHYCCDCFWStatus(qhyccd_handle *handle,char *status)

        [DllImport(DLLName, EntryPoint = "GetQHYCCDCFWStatus", CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDCFWStatus(IntPtr handle, StringBuilder cfwStatus);

        [DllImport(DLLName, EntryPoint = "GetQHYCCDSDKVersion",CharSet = DLLCharSet, CallingConvention = DLLCallCon)]
        public unsafe static extern UInt32 GetQHYCCDSDKVersion(ref UInt32 year, ref UInt32 month, ref UInt32 day, ref UInt32 subday);

        /// <summary>Get the number of read-out modes available for the connected camera.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="numModes">Number of different read-out modes supported.</param>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDNumberOfReadModes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDNumberOfReadModes(IntPtr handle, ref UInt32 numModes);

        /// <summary>Get the name of the specified read-out mode.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="modeNumber">0-based read-out mode number.</param>
        /// <param name="name">Name of the specific mode.</param>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDReadModeName", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDReadModeName(IntPtr handle, UInt32 modeNumber, StringBuilder name);

        /// <summary>Get the resolution available for the specified read-out mode.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="modeNumber">0-based read-out mode number.</param>
        /// <param name="width">Width [pixel] for this mode.</param>
        /// <param name="height">Height [pixel] for this mode.</param>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDReadModeResolution", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDReadModeResolution(IntPtr handle, UInt32 modeNumber, ref UInt32 width, ref UInt32 height);

        

        [DllImport(DLLName, EntryPoint = "SetQHYCCDReadMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 SetQHYCCDReadMode(IntPtr handle, UInt32 modeNumber);

        /// <summary>Get the selected read-out mode.</summary>
        /// <param name="handle">The camera handle returned by OpenQHYCCD.</param>
        /// <param name="modeNumber">Read-out modes selected.</param>
        [DllImport(DLLName, EntryPoint = "GetQHYCCDReadMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern UInt32 GetQHYCCDReadMode(IntPtr handle, ref UInt32 modeNumber);

        // =====================================================================================================================================
        // Derived functions

        public unsafe static UInt32 C_GetQHYCCDFWVersion(IntPtr handle, byte[] verBuf)
        {
            fixed (byte* pverBuf = verBuf)
                return GetQHYCCDFWVersion(handle, pverBuf);
        }

    }
}
