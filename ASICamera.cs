using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ZWO
{
    /// <summary>All function to control the ZWO ASI camera.</summary>
    /// <remarks>Infos taken from "ASICamera2 Software Development Kit.pdf" and "ASICamera2.h".</remarks>
    public class ASICameraDll
    {
        /// <summary>Accessible control types.</summary>
        public enum ASI_CONTROL_TYPE
        {

            /// <summary>Gain.</summary> 
            ASI_GAIN = 0,
            /// <summary>Exposure time [us].</summary> 
            ASI_EXPOSURE,
            /// <summary>Gamma with range 1 to 100 (nominally 50).</summary> 
            ASI_GAMMA,
            /// <summary>Red component of white balance.</summary> 
            ASI_WB_R,
            /// <summary>Blue component of white balance.</summary> 
            ASI_WB_B,
            /// <summary>Pixel value offset (a bias, not a scale factor).</summary> 
            ASI_BRIGHTNESS,
            /// <summary>The total data transfer rate percentage.</summary> 
            ASI_BANDWIDTHOVERLOAD,
            /// <summary>Over clock.</summary> 
            ASI_OVERCLOCK,
            /// <summary>Sensor temperature 10 times the actual temperature.</summary> 
            ASI_TEMPERATURE,
            /// <summary>Image flip.</summary> 
            ASI_FLIP,
            /// <summary>Maximum gain when auto adjust.</summary> 
            ASI_AUTO_MAX_GAIN,
            /// <summary>Maximum exposure time when auto adjust [us].</summary> 
            ASI_AUTO_MAX_EXP,
            /// <summary>Target brightness when auto adjust.</summary> 
            ASI_AUTO_MAX_BRIGHTNESS,
            /// <summary>Hardware binning of pixels.</summary> 
            ASI_HARDWARE_BIN,
            /// <summary>High speed mode</summary> 
            ASI_HIGH_SPEED_MODE,
            /// <summary>Coolerpower percent (only cool camera)</summary> 
            ASI_COOLER_POWER_PERC,
            /// <summary>Sensor's target temperature (only cool camera) - don't multiply by 10.</summary> 
            ASI_TARGET_TEMP,
            /// <summary>Open cooler (only cool</summary> 
            ASI_COOLER_ON,
            /// <summary>Lead to a smaller grid at software bin mode for color camera.</summary> 
            ASI_MONO_BIN,
            /// <summary>Only cooled camera has fan.</summary> 
            ASI_FAN_ON,
            /// <summary>Currently only supported by 1600 mono camera.</summary> 
            ASI_PATTERN_ADJUST,
            ASI_ANTI_DEW_HEATER,
            ASI_HUMIDITY,
            ASI_ENABLE_DDR
        }

        /// <summary>Supported image types.</summary> 
        public enum ASI_IMG_TYPE
        {
            /// <summary>Each pixel is an 8 bit (1 byte) gray level.</summary> 
            ASI_IMG_RAW8 = 0,
            /// <summary>Each pixel consists of RGB, 3 bytes totally (color cameras only).</summary> 
            ASI_IMG_RGB24,
            /// <summary>2 byte s for every pixel with 65536 gray levels.</summary> 
            ASI_IMG_RAW16,
            /// <summary>Mono chrome mode 1 byte every pixel (color camer as only).</summary> 
            ASI_IMG_Y8,
            /// <summary>End-of-enum.</summary> 
            ASI_IMG_END = -1
        }


        public enum ASI_GUIDE_DIRECTION
        {
            ASI_GUIDE_NORTH = 0,
            ASI_GUIDE_SOUTH,
            ASI_GUIDE_EAST,
            ASI_GUIDE_WEST
        }

        public enum ASI_BAYER_PATTERN
        {
            ASI_BAYER_RG = 0,
            ASI_BAYER_BG,
            ASI_BAYER_GR,
            ASI_BAYER_GB
        };

        /// <summary>Status of the exposure sequence.</summary> 
        public enum ASI_EXPOSURE_STATUS
        {
            /// <summary>Idle states, you can start exposure now.</summary> 
            ASI_EXP_IDLE = 0,
            /// <summary>Exposing.</summary> 
            ASI_EXP_WORKING,
            /// <summary>Exposure finished and waiting for download.</summary> 
            ASI_EXP_SUCCESS,
            /// <summary>Exposure failed, you need to start exposure again.</summary> 
            ASI_EXP_FAILED,
        };

        /// <summary>Error codes.</summary> 
        public enum ASI_ERROR_CODE
        {
            /// <summary>.</summary> 
            ASI_SUCCESS = 0,
            /// <summary>No camera connected or index value out of boundary.</summary> 
            ASI_ERROR_INVALID_INDEX,
            /// <summary>Invalid ID.</summary> 
            ASI_ERROR_INVALID_ID,
            /// <summary>Invalid control type.</summary> 
            ASI_ERROR_INVALID_CONTROL_TYPE,
            /// <summary>Camera didn't open.</summary> 
            ASI_ERROR_CAMERA_CLOSED,
            /// <summary>Failed to find the camera, maybe the camera has been removed.</summary> 
            ASI_ERROR_CAMERA_REMOVED,
            /// <summary>Cannot find the path of the file.</summary> 
            ASI_ERROR_INVALID_PATH,
            ASI_ERROR_INVALID_FILEFORMAT,
            /// <summary>Wrong video format size.</summary> 
            ASI_ERROR_INVALID_SIZE,
            /// <summary>Unsupported image formate.</summary> 
            ASI_ERROR_INVALID_IMGTYPE,
            /// <summary>The startpos is out of boundary.</summary> 
            ASI_ERROR_OUTOF_BOUNDARY,
            /// <summary>Timeout.</summary> 
            ASI_ERROR_TIMEOUT,
            /// <summary>Stop capture first.</summary> 
            ASI_ERROR_INVALID_SEQUENCE,
            /// <summary>Buffer size is not big enough.</summary> 
            ASI_ERROR_BUFFER_TOO_SMALL, 
            ASI_ERROR_VIDEO_MODE_ACTIVE,
            ASI_ERROR_EXPOSURE_IN_PROGRESS,
            /// <summary>General error, eg: value is out of valid range.</summary> 
            ASI_ERROR_GENERAL_ERROR,
            ASI_ERROR_END
        };

        /// <summary>Boolean type</summary> 
        public enum ASI_BOOL
        {
            /// <summary>FALSE.</summary> 
            ASI_FALSE = 0,
            /// <summary>TRUE</summary> 
            ASI_TRUE
        };

        /// <summary>Image flip.</summary> 
        public enum ASI_FLIP_STATUS
        {
            /// <summary>Original.</summary> 
            ASI_FLIP_NONE = 0,
            /// <summary>Horizontal flip.</summary> 
            ASI_FLIP_HORIZ,
            /// <summary>Vertical flip.</summary> 
            ASI_FLIP_VERT,
            /// <summary>Both horizontal and vertical flip.</summary> 
            ASI_FLIP_BOTH
        };

        /// <summary>Information about the selected camera.</summary> 
        public struct ASI_CAMERA_INFO
        {
            /// <summary>The name of the camera, you can display this to the UI - char[64].</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
            public byte[] Name;
            /// <summary>This is used to control everything of the camera in other functions.</summary> 
            public int CameraID;
            /// <summary>The max pixel height of the camera.</summary> 
            public int MaxHeight;
            /// <summary>The max pixel width of the camera.</summary> 
            public int MaxWidth;
            /// <summary>Is the camera a color camera?</summary> 
            public ASI_BOOL IsColorCam;
            /// <summary>Bayer pattern of the camera.</summary> 
            public ASI_BAYER_PATTERN BayerPattern;
            /// <summary>1 means bin1 which is supported by every camera, 2 means bin 2 etc.. 0 is the end of supported binning method - int[16].</summary> 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public int[] SupportedBins;
            /// <summary>This array will content with the support output format type.IMG_END is the end of supported video format - ASI_IMG_TYPE[8].</summary> 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public ASI_IMG_TYPE[] SupportedVideoFormat;
            /// <summary>The pixel size of the camera, unit is um. such like 5.6um.</summary> 
            public double PixelSize;
            /// <summary>Does the camera hava a mechanical shutter?</summary> 
            public ASI_BOOL MechanicalShutter;
            /// <summary>Does the camera has a ST4 port?</summary> 
            public ASI_BOOL ST4Port;
            /// <summary>Is the camera a cooled camera?</summary> 
            public ASI_BOOL IsCoolerCam;
            /// <summary>Does the camera provide a USB3 host?</summary> 
            public ASI_BOOL IsUSB3Host;
            /// <summary>Is the camera a USB3 camera?</summary> 
            public ASI_BOOL IsUSB3Camera;
            /// <summary>Electrons per ADU.</summary> 
            public float ElecPerADU;
            /// <summary>The actual ADC depth of image sensor.</summary> 
            public int BitDepth;
            /// <summary>Is the camera a trigger camera?</summary> 
            public ASI_BOOL IsTriggerCam;
            /// <summary>.</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
            public byte[] Unused;//[16];
            /// <summary>Return the Name field as a string.</summary> 
            public string NameAsString
            {
                get { return Encoding.ASCII.GetString(Name).TrimEnd((Char)0); }
            }
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct ASI_CONTROL_CAPS
        {
            /// <summary>The name of the Control like Exposure, Gain etc.</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
            public byte[] Name;
            /// <summary>Description of this control.</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 128)]
            public byte[] Description;
            public int MaxValue;
            public int MinValue;
            public int DefaultValue;
            /// <summary>Support auto set 1, don't support 0.</summary> 
            public ASI_BOOL IsAutoSupported;
            /// <summary>Some control like temperature can only be read by some cameras.</summary> 
            public ASI_BOOL IsWritable;
            /// <summary>This is used to get value and set value of the control.</summary> 
            public ASI_CONTROL_TYPE ControlType;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32)]
            public byte[] Unused;//[32];

            public string NameAsString
            {
                get { return Encoding.ASCII.GetString(Name).TrimEnd((Char)0); }
            }

            public string DescriptionAsString
            {
                get { return Encoding.ASCII.GetString(Description).TrimEnd((Char)0); }
            }
        }


        public struct ASI_ID
        {
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
            public byte[] ID;
            public string IDAsString
            {
                get { return Encoding.ASCII.GetString(ID).TrimEnd((Char)0); }
            }
        }

        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetNumOfConnectedCameras", CallingConvention = CallingConvention.Cdecl)]
        private static extern int ASIGetNumOfConnectedCameras32();

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetNumOfConnectedCameras", CallingConvention = CallingConvention.Cdecl)]
        private static extern int ASIGetNumOfConnectedCameras64();


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetCameraProperty", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetCameraProperty32(out ASI_CAMERA_INFO pASICameraInfo, int iCameraIndex);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetCameraProperty", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetCameraProperty64(out ASI_CAMERA_INFO pASICameraInfo, int iCameraIndex);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIOpenCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIOpenCamera32(int iCameraID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIOpenCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIOpenCamera64(int iCameraID);

        [DllImport("ASICamera2.dll", EntryPoint = "ASIInitCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIInitCamera32(int iCameraID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIInitCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIInitCamera64(int iCameraID);

        [DllImport("ASICamera2.dll", EntryPoint = "ASICloseCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASICloseCamera32(int iCameraID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASICloseCamera", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASICloseCamera64(int iCameraID);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetNumOfControls", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetNumOfControls32(int iCameraID, out int piNumberOfControls);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetNumOfControls", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetNumOfControls64(int iCameraID, out int piNumberOfControls);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetControlCaps", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetControlCaps32(int iCameraID, int iControlIndex, out ASI_CONTROL_CAPS pControlCaps);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetControlCaps", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetControlCaps64(int iCameraID, int iControlIndex, out ASI_CONTROL_CAPS pControlCaps);

        
        [DllImport("ASICamera2.dll", EntryPoint = "ASISetControlValue", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetControlValue32(int iCameraID, ASI_CONTROL_TYPE ControlType, int lValue, ASI_BOOL bAuto);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASISetControlValue", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetControlValue64(int iCameraID, ASI_CONTROL_TYPE ControlType, int lValue, ASI_BOOL bAuto);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetControlValue", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetControlValue32(int iCameraID, ASI_CONTROL_TYPE ControlType, out int plValue, out ASI_BOOL pbAuto);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetControlValue", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetControlValue64(int iCameraID, ASI_CONTROL_TYPE ControlType, out int plValue, out ASI_BOOL pbAuto);


        [DllImport("ASICamera2.dll", EntryPoint = "ASISetROIFormat", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetROIFormat32(int iCameraID, int iWidth, int iHeight, int iBin, ASI_IMG_TYPE Img_type);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASISetROIFormat", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetROIFormat64(int iCameraID, int iWidth, int iHeight, int iBin, ASI_IMG_TYPE Img_type);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetROIFormat", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetROIFormat32(int iCameraID, out int piWidth, out int piHeight, out int piBin, out ASI_IMG_TYPE pImg_type);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetROIFormat", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetROIFormat64(int iCameraID, out int piWidth, out int piHeight, out int piBin, out ASI_IMG_TYPE pImg_type);


        [DllImport("ASICamera2.dll", EntryPoint = "ASISetStartPos", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetStartPos32(int iCameraID, int iStartX, int iStartY);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASISetStartPos", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetStartPos64(int iCameraID, int iStartX, int iStartY);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetStartPos", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetStartPos32(int iCameraID, out int piStartX, out int piStartY);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetStartPos", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetStartPos64(int iCameraID, out int piStartX, out int piStartY);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIStartVideoCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStartVideoCapture32(int iCameraID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIStartVideoCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStartVideoCapture64(int iCameraID);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIStopVideoCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStopVideoCapture32(int iCameraID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIStopVideoCapture", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStopVideoCapture64(int iCameraID);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetVideoData", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetVideoData32(int iCameraID, IntPtr pBuffer, int lBuffSize, int iWaitms);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetVideoData", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetVideoData64(int iCameraID, IntPtr pBuffer, int lBuffSize, int iWaitms);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIPulseGuideOn", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOn32(int iCameraID, ASI_GUIDE_DIRECTION direction);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIPulseGuideOn", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOn64(int iCameraID, ASI_GUIDE_DIRECTION direction);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIPulseGuideOff", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOff32(int iCameraID, ASI_GUIDE_DIRECTION direction);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIPulseGuideOff", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOff64(int iCameraID, ASI_GUIDE_DIRECTION direction);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIStartExposure", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStartExposure32(int iCameraID, ASI_BOOL bIsDark);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIStartExposure", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStartExposure64(int iCameraID, ASI_BOOL bIsDark);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIStopExposure", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStopExposure32(int iCameraID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIStopExposure", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIStopExposure64(int iCameraID);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetExpStatus", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetExpStatus32(int iCameraID, out ASI_EXPOSURE_STATUS pExpStatus);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetExpStatus", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetExpStatus64(int iCameraID, out ASI_EXPOSURE_STATUS pExpStatus);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetDataAfterExp", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetDataAfterExp32(int iCameraID, IntPtr pBuffer, int lBuffSize);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetDataAfterExp", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetDataAfterExp64(int iCameraID, IntPtr pBuffer, int lBuffSize);


        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetGainOffset", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetGainOffset32(int iCameraID, out int Offset_HighestDR, out int Offset_UnityGain, out int Gain_LowestRN, out int Offset_LowestRN);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetGainOffset", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetGainOffset64(int iCameraID, out int Offset_HighestDR, out int Offset_UnityGain, out int Gain_LowestRN, out int Offset_LowestRN);

        [DllImport("ASICamera2.dll", EntryPoint = "ASIGetID", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetID32(int iCameraID, out ASI_ID pID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASIGetID", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASIGetID64(int iCameraID, out ASI_ID pID);

        [DllImport("ASICamera2.dll", EntryPoint = "ASISetID", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetID32(int iCameraID, ASI_ID ID);

        [DllImport("ASICamera2_x64.dll", EntryPoint = "ASISetID", CallingConvention = CallingConvention.Cdecl)]
        private static extern ASI_ERROR_CODE ASISetID64(int iCameraID, ASI_ID ID);



        public static int ASIGetNumOfConnectedCameras() { return IntPtr.Size == 8 /* 64bit */ ? ASIGetNumOfConnectedCameras64() : ASIGetNumOfConnectedCameras32(); }

        public static ASI_ERROR_CODE ASIGetCameraProperty(out ASI_CAMERA_INFO pASICameraInfo, int iCameraIndex)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetCameraProperty64(out pASICameraInfo, iCameraIndex) : ASIGetCameraProperty32(out pASICameraInfo, iCameraIndex); }

        public static ASI_ERROR_CODE ASIOpenCamera(int iCameraID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIOpenCamera64(iCameraID) : ASIOpenCamera32(iCameraID); }

        public static ASI_ERROR_CODE ASIInitCamera(int iCameraID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIInitCamera64(iCameraID) : ASIInitCamera32(iCameraID); }

        public static ASI_ERROR_CODE ASICloseCamera(int iCameraID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASICloseCamera64(iCameraID) : ASICloseCamera32(iCameraID); }

        public static ASI_ERROR_CODE ASIGetNumOfControls(int iCameraID, out int piNumberOfControls)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetNumOfControls64(iCameraID, out piNumberOfControls) : ASIGetNumOfControls32(iCameraID, out piNumberOfControls); }

        public static ASI_ERROR_CODE ASIGetControlCaps(int iCameraID, int iControlIndex, out ASI_CONTROL_CAPS pControlCaps)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetControlCaps64(iCameraID, iControlIndex, out pControlCaps) : ASIGetControlCaps32(iCameraID, iControlIndex, out pControlCaps); }

        public static ASI_ERROR_CODE ASISetControlValue(int iCameraID, ASI_CONTROL_TYPE ControlType, int lValue)
        { return IntPtr.Size == 8 /* 64bit */ ? ASISetControlValue64(iCameraID, ControlType, lValue, ASI_BOOL.ASI_FALSE) : ASISetControlValue32(iCameraID, ControlType, lValue, ASI_BOOL.ASI_FALSE); }

        public static int ASIGetControlValue(int iCameraID, ASI_CONTROL_TYPE ControlType)
        {
            ASI_BOOL pbAuto;
            int plValue;
            ASI_ERROR_CODE err = IntPtr.Size == 8 /* 64bit */ ? ASIGetControlValue64(iCameraID, ControlType, out plValue, out pbAuto) : ASIGetControlValue32(iCameraID, ControlType, out plValue, out pbAuto);
            return plValue;
        }

        public static ASI_ERROR_CODE ASISetROIFormat(int iCameraID, int iWidth, int iHeight, int iBin, ASI_IMG_TYPE Img_type)
        { return IntPtr.Size == 8 /* 64bit */ ? ASISetROIFormat64(iCameraID, iWidth, iHeight, iBin, Img_type) : ASISetROIFormat32(iCameraID, iWidth, iHeight, iBin, Img_type); }

        public static ASI_ERROR_CODE ASIGetROIFormat(int iCameraID, out int piWidth, out int piHeight, out int piBin, out ASI_IMG_TYPE pImg_type)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetROIFormat64(iCameraID, out piWidth, out piHeight, out piBin, out pImg_type) : ASIGetROIFormat32(iCameraID, out piWidth, out piHeight, out piBin, out pImg_type); }

        public static ASI_ERROR_CODE ASISetStartPos(int iCameraID, int iStartX, int iStartY)
        { return IntPtr.Size == 8 /* 64bit */ ? ASISetStartPos64(iCameraID, iStartX, iStartY) : ASISetStartPos32(iCameraID, iStartX, iStartY); }

        public static ASI_ERROR_CODE ASIGetStartPos(int iCameraID, out int piStartX, out int piStartY)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetStartPos64(iCameraID, out piStartX, out piStartY) : ASIGetStartPos32(iCameraID, out piStartX, out piStartY); }

        public static ASI_ERROR_CODE ASIStartVideoCapture(int iCameraID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIStartVideoCapture64(iCameraID) : ASIStartVideoCapture32(iCameraID); }

        public static ASI_ERROR_CODE ASIStopVideoCapture(int iCameraID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIStopVideoCapture64(iCameraID) : ASIStopVideoCapture32(iCameraID); }

        public static ASI_ERROR_CODE ASIGetVideoData(int iCameraID, IntPtr pBuffer, int lBuffSize, int iWaitms)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetVideoData64(iCameraID, pBuffer, lBuffSize, iWaitms) : ASIGetVideoData32(iCameraID, pBuffer, lBuffSize, iWaitms); }

        public static ASI_ERROR_CODE ASIPulseGuideOn(int iCameraID, ASI_GUIDE_DIRECTION direction)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIPulseGuideOn64(iCameraID, direction) : ASIPulseGuideOn32(iCameraID, direction); }

        public static ASI_ERROR_CODE ASIPulseGuideOff(int iCameraID, ASI_GUIDE_DIRECTION direction)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIPulseGuideOff64(iCameraID, direction) : ASIPulseGuideOff32(iCameraID, direction); }

        public static ASI_ERROR_CODE ASIStartExposure(int iCameraID, ASI_BOOL bIsDark)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIStartExposure64(iCameraID, bIsDark) : ASIStartExposure32(iCameraID, bIsDark); }

        public static ASI_ERROR_CODE ASIStopExposure(int iCameraID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIStopExposure64(iCameraID) : ASIStopExposure32(iCameraID); }

        public static ASI_ERROR_CODE ASIGetExpStatus(int iCameraID, out ASI_EXPOSURE_STATUS pExpStatus)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetExpStatus64(iCameraID, out pExpStatus) : ASIGetExpStatus32(iCameraID, out pExpStatus); }

        public static ASI_ERROR_CODE ASIGetDataAfterExp(int iCameraID, IntPtr pBuffer, int lBuffSize)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetDataAfterExp64(iCameraID, pBuffer, lBuffSize) : ASIGetDataAfterExp32(iCameraID, pBuffer, lBuffSize); }

        public static ASI_ERROR_CODE ASIGetGainOffset(int iCameraID, out int Offset_HighestDR, out int Offset_UnityGain, out int Gain_LowestRN, out int Offset_LowestRN)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetGainOffset64(iCameraID, out Offset_HighestDR, out Offset_UnityGain, out Gain_LowestRN, out Offset_LowestRN) : ASIGetGainOffset32(iCameraID, out Offset_HighestDR, out Offset_UnityGain, out Gain_LowestRN, out Offset_LowestRN); }


        public static ASI_ERROR_CODE ASIGetID(int iCameraID, out ASI_ID pID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASIGetID64(iCameraID, out pID) : ASIGetID32(iCameraID, out pID); }

        public static ASI_ERROR_CODE ASISetID(int iCameraID, ASI_ID ID)
        { return IntPtr.Size == 8 /* 64bit */ ? ASISetID64(iCameraID, ID) : ASISetID32(iCameraID, ID); }

    }


}
