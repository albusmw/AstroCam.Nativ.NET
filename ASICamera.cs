using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ZWO
{
    /// <summary>All function to control the ZWO ASI camera.</summary>
    /// <remarks>Infos taken from "ASICamera2 Software Development Kit.pdf" and "ASICamera2.h".</remarks>
    public class ASICameraDll
    {

        private const int Isx64  = 8;
        private const string DLLx32 = "ASICamera2.dll";
        private const string DLLx64 = "ASICamera2_x64.dll";
        private const CallingConvention DLLCallCon = CallingConvention.Cdecl;

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
            /// <summary>???</summary> 
            ASI_ANTI_DEW_HEATER,
            /// <summary>???</summary> 
            ASI_HUMIDITY,
            /// <summary>???</summary> 
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

        /// <summary>Guider Direction</summary>
        public enum ASI_GUIDE_DIRECTION
        {
            /// <summary>North</summary>
            ASI_GUIDE_NORTH = 0,
            /// <summary>South</summary>
            ASI_GUIDE_SOUTH,
            /// <summary>East</summary>
            ASI_GUIDE_EAST,
            /// <summary>West</summary>
            ASI_GUIDE_WEST
        }

        /// <summary>Bayer pattern orientation.</summary>
        public enum ASI_BAYER_PATTERN
        {
            /// <summary>RGGB</summary>
            ASI_BAYER_RG = 0,
            /// <summary>BGGR</summary>
            ASI_BAYER_BG,
            /// <summary>GRBG</summary>
            ASI_BAYER_GR,
            /// <summary>GBRG</summary>
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
            /// <summary>Invalid file format.</summary> 
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
            /// <summary>Video mode active.</summary> 
            ASI_ERROR_VIDEO_MODE_ACTIVE,
            /// <summary>Exposure in progress.</summary> 
            ASI_ERROR_EXPOSURE_IN_PROGRESS,
            /// <summary>General error, eg: value is out of valid range.</summary> 
            ASI_ERROR_GENERAL_ERROR,
            /// <summary>Last error code enum entry.</summary> 
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

        /// <summary>Structure to hold the details of a certain control property.</summary> 
        [StructLayout(LayoutKind.Sequential)]
        public struct ASI_CONTROL_CAPS
        {
            /// <summary>The name of the Control like Exposure, Gain etc.</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
            public byte[] Name;
            /// <summary>Description of this control.</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 128)]
            public byte[] Description;
            /// <summary>Maximum value.</summary> 
            public int MaxValue;
            /// <summary>Minimum value.</summary> 
            public int MinValue;
            /// <summary>Default value.</summary> 
            public int DefaultValue;
            /// <summary>Support auto set 1, don't support 0.</summary> 
            public ASI_BOOL IsAutoSupported;
            /// <summary>Some control like temperature can only be read by some cameras.</summary> 
            public ASI_BOOL IsWritable;
            /// <summary>This is used to get value and set value of the control.</summary> 
            public ASI_CONTROL_TYPE ControlType;
            /// <summary>???</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32)]
            public byte[] Unused;//[32];
            /// <summary>Name as decoded string.</summary> 
            public string NameAsString
            {
                get { return Encoding.ASCII.GetString(Name).TrimEnd((Char)0); }
            }
            /// <summary>Description as decoded string.</summary> 
            public string DescriptionAsString
            {
                get { return Encoding.ASCII.GetString(Description).TrimEnd((Char)0); }
            }
        }

        /// <summary>Structure to pass to the ASIGetID / ASISetID function.</summary> 
        public struct ASI_ID
        {
            /// <summary>ID.</summary> 
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
            public byte[] ID;
            /// <summary>ID as decoded string.</summary> 
            public string IDAsString
            {
                get { return Encoding.ASCII.GetString(ID).TrimEnd((Char)0); }
            }
        }

        [DllImport(DLLx32, EntryPoint = "ASIGetNumOfConnectedCameras", CallingConvention = DLLCallCon)]
        private static extern int ASIGetNumOfConnectedCameras32();

        [DllImport(DLLx64, EntryPoint = "ASIGetNumOfConnectedCameras", CallingConvention = DLLCallCon)]
        private static extern int ASIGetNumOfConnectedCameras64();

        [DllImport(DLLx32, EntryPoint = "ASIGetCameraProperty", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetCameraProperty32(out ASI_CAMERA_INFO pASICameraInfo, int iCameraIndex);

        [DllImport(DLLx64, EntryPoint = "ASIGetCameraProperty", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetCameraProperty64(out ASI_CAMERA_INFO pASICameraInfo, int iCameraIndex);

        [DllImport(DLLx32, EntryPoint = "ASIOpenCamera", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIOpenCamera32(int iCameraID);

        [DllImport(DLLx64, EntryPoint = "ASIOpenCamera", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIOpenCamera64(int iCameraID);

        [DllImport(DLLx32, EntryPoint = "ASIInitCamera", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIInitCamera32(int iCameraID);

        [DllImport(DLLx64, EntryPoint = "ASIInitCamera", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIInitCamera64(int iCameraID);

        [DllImport(DLLx32, EntryPoint = "ASICloseCamera", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASICloseCamera32(int iCameraID);

        [DllImport(DLLx64, EntryPoint = "ASICloseCamera", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASICloseCamera64(int iCameraID);

        [DllImport(DLLx32, EntryPoint = "ASIGetNumOfControls", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetNumOfControls32(int iCameraID, out int piNumberOfControls);

        [DllImport(DLLx64, EntryPoint = "ASIGetNumOfControls", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetNumOfControls64(int iCameraID, out int piNumberOfControls);

        [DllImport(DLLx32, EntryPoint = "ASIGetControlCaps", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetControlCaps32(int iCameraID, int iControlIndex, out ASI_CONTROL_CAPS pControlCaps);

        [DllImport(DLLx64, EntryPoint = "ASIGetControlCaps", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetControlCaps64(int iCameraID, int iControlIndex, out ASI_CONTROL_CAPS pControlCaps);
        
        [DllImport(DLLx32, EntryPoint = "ASISetControlValue", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetControlValue32(int iCameraID, ASI_CONTROL_TYPE ControlType, int lValue, ASI_BOOL bAuto);

        [DllImport(DLLx64, EntryPoint = "ASISetControlValue", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetControlValue64(int iCameraID, ASI_CONTROL_TYPE ControlType, int lValue, ASI_BOOL bAuto);

        [DllImport(DLLx32, EntryPoint = "ASIGetControlValue", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetControlValue32(int iCameraID, ASI_CONTROL_TYPE ControlType, out int plValue, out ASI_BOOL pbAuto);

        [DllImport(DLLx64, EntryPoint = "ASIGetControlValue", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetControlValue64(int iCameraID, ASI_CONTROL_TYPE ControlType, out int plValue, out ASI_BOOL pbAuto);

        [DllImport(DLLx32, EntryPoint = "ASISetROIFormat", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetROIFormat32(int iCameraID, int iWidth, int iHeight, int iBin, ASI_IMG_TYPE Img_type);

        [DllImport(DLLx64, EntryPoint = "ASISetROIFormat", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetROIFormat64(int iCameraID, int iWidth, int iHeight, int iBin, ASI_IMG_TYPE Img_type);

        [DllImport(DLLx32, EntryPoint = "ASIGetROIFormat", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetROIFormat32(int iCameraID, out int piWidth, out int piHeight, out int piBin, out ASI_IMG_TYPE pImg_type);

        [DllImport(DLLx64, EntryPoint = "ASIGetROIFormat", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetROIFormat64(int iCameraID, out int piWidth, out int piHeight, out int piBin, out ASI_IMG_TYPE pImg_type);

        [DllImport(DLLx32, EntryPoint = "ASISetStartPos", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetStartPos32(int iCameraID, int iStartX, int iStartY);

        [DllImport(DLLx64, EntryPoint = "ASISetStartPos", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetStartPos64(int iCameraID, int iStartX, int iStartY);

        [DllImport(DLLx32, EntryPoint = "ASIGetStartPos", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetStartPos32(int iCameraID, out int piStartX, out int piStartY);

        [DllImport(DLLx64, EntryPoint = "ASIGetStartPos", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetStartPos64(int iCameraID, out int piStartX, out int piStartY);

        [DllImport(DLLx32, EntryPoint = "ASIStartVideoCapture", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStartVideoCapture32(int iCameraID);

        [DllImport(DLLx64, EntryPoint = "ASIStartVideoCapture", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStartVideoCapture64(int iCameraID);

        [DllImport(DLLx32, EntryPoint = "ASIStopVideoCapture", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStopVideoCapture32(int iCameraID);

        [DllImport(DLLx64, EntryPoint = "ASIStopVideoCapture", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStopVideoCapture64(int iCameraID);

        [DllImport(DLLx32, EntryPoint = "ASIGetVideoData", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetVideoData32(int iCameraID, IntPtr pBuffer, int lBuffSize, int iWaitms);

        [DllImport(DLLx64, EntryPoint = "ASIGetVideoData", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetVideoData64(int iCameraID, IntPtr pBuffer, int lBuffSize, int iWaitms);

        [DllImport(DLLx32, EntryPoint = "ASIPulseGuideOn", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOn32(int iCameraID, ASI_GUIDE_DIRECTION direction);

        [DllImport(DLLx64, EntryPoint = "ASIPulseGuideOn", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOn64(int iCameraID, ASI_GUIDE_DIRECTION direction);

        [DllImport(DLLx32, EntryPoint = "ASIPulseGuideOff", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOff32(int iCameraID, ASI_GUIDE_DIRECTION direction);

        [DllImport(DLLx64, EntryPoint = "ASIPulseGuideOff", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIPulseGuideOff64(int iCameraID, ASI_GUIDE_DIRECTION direction);

        [DllImport(DLLx32, EntryPoint = "ASIStartExposure", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStartExposure32(int iCameraID, ASI_BOOL bIsDark);

        [DllImport(DLLx64, EntryPoint = "ASIStartExposure", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStartExposure64(int iCameraID, ASI_BOOL bIsDark);

        [DllImport(DLLx32, EntryPoint = "ASIStopExposure", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStopExposure32(int iCameraID);

        [DllImport(DLLx64, EntryPoint = "ASIStopExposure", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIStopExposure64(int iCameraID);

        [DllImport(DLLx32, EntryPoint = "ASIGetExpStatus", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetExpStatus32(int iCameraID, out ASI_EXPOSURE_STATUS pExpStatus);

        [DllImport(DLLx64, EntryPoint = "ASIGetExpStatus", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetExpStatus64(int iCameraID, out ASI_EXPOSURE_STATUS pExpStatus);

        [DllImport(DLLx32, EntryPoint = "ASIGetDataAfterExp", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetDataAfterExp32(int iCameraID, IntPtr pBuffer, int lBuffSize);

        [DllImport(DLLx64, EntryPoint = "ASIGetDataAfterExp", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetDataAfterExp64(int iCameraID, IntPtr pBuffer, int lBuffSize);

        [DllImport(DLLx32, EntryPoint = "ASIGetGainOffset", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetGainOffset32(int iCameraID, out int Offset_HighestDR, out int Offset_UnityGain, out int Gain_LowestRN, out int Offset_LowestRN);

        [DllImport(DLLx64, EntryPoint = "ASIGetGainOffset", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetGainOffset64(int iCameraID, out int Offset_HighestDR, out int Offset_UnityGain, out int Gain_LowestRN, out int Offset_LowestRN);

        [DllImport(DLLx32, EntryPoint = "ASIGetID", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetID32(int iCameraID, out ASI_ID pID);

        [DllImport(DLLx64, EntryPoint = "ASIGetID", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASIGetID64(int iCameraID, out ASI_ID pID);

        [DllImport(DLLx32, EntryPoint = "ASISetID", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetID32(int iCameraID, ASI_ID ID);

        [DllImport(DLLx64, EntryPoint = "ASISetID", CallingConvention = DLLCallCon)]
        private static extern ASI_ERROR_CODE ASISetID64(int iCameraID, ASI_ID ID);

        ///====================================================================================================================================================

        ///<summary>Get the count of connected ASI cameras.</summary>
        public static int ASIGetNumOfConnectedCameras() { return IntPtr.Size == Isx64 ? ASIGetNumOfConnectedCameras64() : ASIGetNumOfConnectedCameras32(); }

        ///<summary>Get the camera's information for a specific camera index (0 is the first camera).</summary>
        public static ASI_ERROR_CODE ASIGetCameraProperty(out ASI_CAMERA_INFO pASICameraInfo, int iCameraIndex)
        { return IntPtr.Size == Isx64 ? ASIGetCameraProperty64(out pASICameraInfo, iCameraIndex) : ASIGetCameraProperty32(out pASICameraInfo, iCameraIndex); }

        ///<summary>Open camera of a specific camera ID. This will not affect any other camera which is capturing.</summary>
        ///<remarks>This should be the first call to start up a camera.</remarks>
        public static ASI_ERROR_CODE ASIOpenCamera(int iCameraID)
        { return IntPtr.Size == Isx64 ? ASIOpenCamera64(iCameraID) : ASIOpenCamera32(iCameraID); }

        ///<summary>Initialize the specified camera ID, this API only affect the camera you are going to initializeand won't affect other cameras</summary>
        ///<remarks>This should be the second call to start up a camera.</remarks>
        public static ASI_ERROR_CODE ASIInitCamera(int iCameraID)
        { return IntPtr.Size == Isx64 ? ASIInitCamera64(iCameraID) : ASIInitCamera32(iCameraID); }

        ///<summary>Close a specific camera ID so that its resources will be released.</summary>
        ///<remarks>This should be the last call to shut down a camera.</remarks>
        public static ASI_ERROR_CODE ASICloseCamera(int iCameraID)
        { return IntPtr.Size == Isx64 ? ASICloseCamera64(iCameraID) : ASICloseCamera32(iCameraID); }

        ///<summary>Get the number of control types for the specific camera ID.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="piNumberOfControls">Number of control types for the specific camera ID</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIGetNumOfControls(int iCameraID, out int piNumberOfControls)
        { return IntPtr.Size == Isx64 ? ASIGetNumOfControls64(iCameraID, out piNumberOfControls) : ASIGetNumOfControls32(iCameraID, out piNumberOfControls); }

        ///<summary>Get control type's capacity or range of values for a specific control index.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="iControlIndex">Control index.</param>
        ///<param name="pControlCaps">Pointer to control capacity.</param>
        ///<returns>Error code.</returns>
        ///<remarks>iControlIndex is control index, is different from ControlType.</remarks>
        public static ASI_ERROR_CODE ASIGetControlCaps(int iCameraID, int iControlIndex, out ASI_CONTROL_CAPS pControlCaps)
        { return IntPtr.Size == Isx64 ? ASIGetControlCaps64(iCameraID, iControlIndex, out pControlCaps) : ASIGetControlCaps32(iCameraID, iControlIndex, out pControlCaps); }

        ///<summary>Set a specific control type's value for a specific camera ID.</summary>
        public static ASI_ERROR_CODE ASISetControlValue(int iCameraID, ASI_CONTROL_TYPE ControlType, int lValue)
        { return IntPtr.Size == Isx64 ? ASISetControlValue64(iCameraID, ControlType, lValue, ASI_BOOL.ASI_FALSE) : ASISetControlValue32(iCameraID, ControlType, lValue, ASI_BOOL.ASI_FALSE); }

        ///<summary>Get a specific control type's value as currently set for a specific camera ID.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="ControlType">Control type.</param>
        ///<returns>Current value.</returns>
        ///<remarks>pbAuto which returns whether the control is auto adjusted is not returned.</remarks>
        public static int ASIGetControlValue(int iCameraID, ASI_CONTROL_TYPE ControlType)
        {
            ASI_BOOL pbAuto;
            int plValue;
            ASI_ERROR_CODE err = IntPtr.Size == Isx64 ? ASIGetControlValue64(iCameraID, ControlType, out plValue, out pbAuto) : ASIGetControlValue32(iCameraID, ControlType, out plValue, out pbAuto);
            return plValue;
        }

        ///<summary>Set region of interest (ROI) size, binning, and image type.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="iWidth">Image width.</param>
        ///<param name="iHeight">Image height.</param>
        ///<param name="iBin">NxN binning value.</param>
        ///<param name="Img_type">Image type.</param>
        ///<returns>Error code.</returns>
        ///<remarks>In general make sure iWidth%8=0，iHeight%2=0. For the USB2.0 camera ASI120，make sure iWidth* iHeight%1024=0，otherwise the call will result is an error code.</remarks>
        public static ASI_ERROR_CODE ASISetROIFormat(int iCameraID, int iWidth, int iHeight, int iBin, ASI_IMG_TYPE Img_type)
        { return IntPtr.Size == Isx64 ? ASISetROIFormat64(iCameraID, iWidth, iHeight, iBin, Img_type) : ASISetROIFormat32(iCameraID, iWidth, iHeight, iBin, Img_type); }

        ///<summary>Get region of interest (ROI) size, binning, and image type.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="piWidth">Image width.</param>
        ///<param name="piHeight">Image height.</param>
        ///<param name="piBin">NxN binning value.</param>
        ///<param name="pImg_type">Image type.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIGetROIFormat(int iCameraID, out int piWidth, out int piHeight, out int piBin, out ASI_IMG_TYPE pImg_type)
        { return IntPtr.Size == Isx64 ? ASIGetROIFormat64(iCameraID, out piWidth, out piHeight, out piBin, out pImg_type) : ASIGetROIFormat32(iCameraID, out piWidth, out piHeight, out piBin, out pImg_type); }

        ///<summary>Set start position of ROI.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="iStartX">Start position of X-axis</param>
        ///<param name="iStartY">Start position of Y-axis</param>
        ///<returns>Error code.</returns>
        ///<remarks>The position is relative to the image after binning. call this function to change ROI area to the origin after ASISetROIFormat, because ASISetROIFormat will change ROI to the center.</remarks>
        public static ASI_ERROR_CODE ASISetStartPos(int iCameraID, int iStartX, int iStartY)
        { return IntPtr.Size == Isx64 ? ASISetStartPos64(iCameraID, iStartX, iStartY) : ASISetStartPos32(iCameraID, iStartX, iStartY); }

        ///<summary>Get start position of ROI.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="piStartX">Start position of X-axis</param>
        ///<param name="piStartY">Start position of Y-axis</param>
        ///<returns>Error code.</returns>
        ///<remarks>The position is relative to the image after binning.</remarks>
        public static ASI_ERROR_CODE ASIGetStartPos(int iCameraID, out int piStartX, out int piStartY)
        { return IntPtr.Size == Isx64 ? ASIGetStartPos64(iCameraID, out piStartX, out piStartY) : ASIGetStartPos32(iCameraID, out piStartX, out piStartY); }

        ///<summary>Start the continuous video capture.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIStartVideoCapture(int iCameraID)
        { return IntPtr.Size == Isx64 ? ASIStartVideoCapture64(iCameraID) : ASIStartVideoCapture32(iCameraID); }

        ///<summary>Stop the continuous video capture.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIStopVideoCapture(int iCameraID)
        { return IntPtr.Size == Isx64 ? ASIStopVideoCapture64(iCameraID) : ASIStopVideoCapture32(iCameraID); }

        ///<summary>After ASIStartVideoCapture ()，call this function repeatedly to get images on a continuous basis.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="pBuffer">Pointer to image buffer.</param>
        ///<param name="lBuffSize">Size of buffer.</param>
        ///<param name="iWaitms">Wait time, unit is ms, -1 means wait forever.</param>
        ///<returns>Error code.</returns>
        ///<remarks>If read out speed isn't fast enough, new frame is discarded, it is best to create a circular buffer for holding the imagery to operate on the frames asynchronously.</remarks>
        public static ASI_ERROR_CODE ASIGetVideoData(int iCameraID, IntPtr pBuffer, int lBuffSize, int iWaitms)
        { return IntPtr.Size == Isx64 ? ASIGetVideoData64(iCameraID, pBuffer, lBuffSize, iWaitms) : ASIGetVideoData32(iCameraID, pBuffer, lBuffSize, iWaitms); }

        ///<summary>Send ST4 guiding pulse，start guiding，only the camera with ST4 port support.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="direction">Guiding direction.</param>
        ///<returns>Error code.</returns>
        ///<remarks>ASIPulseGuideOff must be called to stop guiding.</remarks>
        public static ASI_ERROR_CODE ASIPulseGuideOn(int iCameraID, ASI_GUIDE_DIRECTION direction)
        { return IntPtr.Size == Isx64 ? ASIPulseGuideOn64(iCameraID, direction) : ASIPulseGuideOn32(iCameraID, direction); }

        ///<summary>Send ST4 guiding pulse，stop guiding，only the camera with ST4 port support.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="direction">Guiding direction.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIPulseGuideOff(int iCameraID, ASI_GUIDE_DIRECTION direction)
        { return IntPtr.Size == Isx64 ? ASIPulseGuideOff64(iCameraID, direction) : ASIPulseGuideOff32(iCameraID, direction); }

        ///<summary>Start a single snap shot. Note that there is a setup time for each snap shot, thus you cannot get two snapshots in succession with a shorter time span that these values.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIStartExposure(int iCameraID, ASI_BOOL bIsDark)
        { return IntPtr.Size == Isx64 ? ASIStartExposure64(iCameraID, bIsDark) : ASIStartExposure32(iCameraID, bIsDark); }

        ///<summary>Stop a single snap shot, this API can be used for very long exposure and you don't want to wait so long such like exposure 5 minutes and you want to cancel after 1 min, then you can call this API.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIStopExposure(int iCameraID)
        { return IntPtr.Size == Isx64 ? ASIStopExposure64(iCameraID) : ASIStopExposure32(iCameraID); }

        ///<summary>Get snap status.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="pExpStatus">Snap status.</param>
        ///<returns>Error code.</returns>
        ///<remarks>After snap is started，the status should be checked continuously.</remarks>
        public static ASI_ERROR_CODE ASIGetExpStatus(int iCameraID, out ASI_EXPOSURE_STATUS pExpStatus)
        { return IntPtr.Size == Isx64 ? ASIGetExpStatus64(iCameraID, out pExpStatus) : ASIGetExpStatus32(iCameraID, out pExpStatus); }

        ///<summary>Get image after snap successfully.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="pBuffer">Pointer to image buffer.</param>
        ///<param name="lBuffSize">Size of buffer.</param>
        ///<returns>Error code.</returns>
        ///<remarks>lBuffSize refer to ASIGetVideoData().</remarks>
        public static ASI_ERROR_CODE ASIGetDataAfterExp(int iCameraID, IntPtr pBuffer, int lBuffSize)
        { return IntPtr.Size == Isx64 ? ASIGetDataAfterExp64(iCameraID, pBuffer, lBuffSize) : ASIGetDataAfterExp32(iCameraID, pBuffer, lBuffSize); }

        public static ASI_ERROR_CODE ASIGetGainOffset(int iCameraID, out int Offset_HighestDR, out int Offset_UnityGain, out int Gain_LowestRN, out int Offset_LowestRN)
        { return IntPtr.Size == Isx64 ? ASIGetGainOffset64(iCameraID, out Offset_HighestDR, out Offset_UnityGain, out Gain_LowestRN, out Offset_LowestRN) : ASIGetGainOffset32(iCameraID, out Offset_HighestDR, out Offset_UnityGain, out Gain_LowestRN, out Offset_LowestRN); }

        ///<summary>Get camera id stored in flash, only available for USB3.0 camera.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="pID">Pointer to the ASI_ID structure.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASIGetID(int iCameraID, out ASI_ID pID)
        { return IntPtr.Size == Isx64 ? ASIGetID64(iCameraID, out pID) : ASIGetID32(iCameraID, out pID); }

        ///<summary>Set camera id stored in flash, only available for USB3.0 camera.</summary>
        ///<param name="iCameraID">Camera ID to access.</param>
        ///<param name="ID">ASI_ID structure.</param>
        ///<returns>Error code.</returns>
        public static ASI_ERROR_CODE ASISetID(int iCameraID, ASI_ID ID)
        { return IntPtr.Size == Isx64 ? ASISetID64(iCameraID, ID) : ASISetID32(iCameraID, ID); }

    }


}
