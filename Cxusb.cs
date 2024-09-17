using System;
using System.Runtime.InteropServices;

namespace MoravianCameraSDK
{

    using INTEGER = System.Int32;
    using CARDINAL = System.UInt32;

    ///<summary>'cxusb.dll' driver handles large cooled C1×, C3, C4 and C5 camera lines, as well as a rollingshutter sensor based C2-9000.</summary>
    public class Cxusb
    {

        const string CameraDriverDllName = "cxusb.dll";
        const CallingConvention DLLCallCon = CallingConvention.Cdecl;
        const CharSet DLLCharSet = CharSet.Ansi;

        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════
        // Camera Enumeration / Connection
        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>This callback function is called for each connected camera and the camera identifier is passed as an argument.</summary>
        ///<param name="CameraId">Camera identifier.</param>
        [UnmanagedFunctionPointer(DLLCallCon)]
        public delegate void EnumCallBack(uint CameraId);

        ///<summary>Enumerate allows discovering of all cameras currently connected to the host PC.</summary>
        ///<param name="CallBackPointer">Pointer to callback function 'CallbackProc' with single unsigned integer argument. This callback function is called for each connected camera and the camera identifier is passed as an argument.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Enumerate(EnumCallBack CallBackPointer);

        ///<summary>Initialize the camera and get a handle to it.</summary>
        ///<param name="CameraId">ID of the camera read during the Enumerate calls.</param>
        ///<returns>Camere handle to access the camera.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern UIntPtr Initialize(uint CameraId);

        ///<summary>When the camera is no longer used, the handle must be released by the 'Release' call.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<remarks>No other function (with the exception of 'Enumerate' and 'Initialize') may be called after the 'Release' call.</remarks>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Release(UIntPtr Handle);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void RegisterNotifyHWND(UIntPtr Handle, IntPtr HWND);

        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════
        // Getting Values
        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>Returns boolean value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetBooleanParameter(UIntPtr Handle, Enums.eBoolParameters Index, out byte Value);

        ///<summary>Returns integer value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetIntegerParameter(UIntPtr Handle, Enums.eIntParameters Index, out INTEGER Value);

        ///<summary>Returns float value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetValue(UIntPtr Handle, Enums.eValueParameters Index, out float Value);

        ///<summary>Returns string value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="StringBufferLastIndex">Last 0-based index of the string buffer (if the buffer is 128 character long, the value is 127).</param>
        ///<param name="String">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte GetStringParameter(UIntPtr Handle, Enums.eStringParameters Index, int StringBufferLastIndex, System.Text.StringBuilder String);

        ///<summary>Enumerates all read modes provided by the camera.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">The caller passes index beginning with 0 and repeats the call with incremented index until the call returns FALSE.</param>
        ///<param name="StringBufferLastIndex">Last 0-based index of the string buffer (if the buffer is 128 character long, the value is 127).</param>
        ///<param name="String">Value read.</param>
        ///<returns>If the function does not 'understand' passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateReadModes(UIntPtr Handle, CARDINAL Index, int StringBufferLastIndex, System.Text.StringBuilder String);

        ///<summary>Enumerates all filters provided by the camera.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">The caller passes index beginning with 0 and repeats the call with incremented index until the call returns FALSE.</param>
        ///<param name="StringBufferLastIndex">Last 0-based index of the string buffer (if the buffer is 128 character long, the value is 127).</param>
        ///<param name="String">Value read.</param>
        ///<param name="Color">Color parameter hints the Windows color, which can be used to draw the filter name in the application.</param>
        ///<returns>If the function does not 'understand' passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateFilters(UIntPtr Handle, uint Index, int StringBufferLastIndex, System.Text.StringBuilder String, out uint Color);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateFilters2(UIntPtr Handle, uint Index, int String_HIGH, System.Text.StringBuilder String, out uint Color, out int Offset);

        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════
        // Setting Values
        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>Sets required read mode.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Mode">Required read mode.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetReadMode(UIntPtr Handle, int Mode);

        ///<summary>Sets the required read binning.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="x">Binning in X direction.</param>
        ///<param name="y">Binning in Y direction.</param>
        ///<remarks>If the camera does not support binning, this function has no effect.</remarks>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetBinning(UIntPtr Handle, uint x, uint y);

        ///<summary>Sets the required gain.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="gain">Range of parameter gain depends on particular camera hardware, as it typically represents directly a register value.</param>
        ///<remarks>Low limit is 0, high limit is returned by function GetIntegerParameter with index gipMaxGain.</remarks>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetGain(UIntPtr Handle, uint gain);

        ///<summary>Sets the required filter. </summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Filter index.</param>
        ///<remarks>If the camera is not equipped with filter wheel, this function has no effect.</remarks>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetFilter(UIntPtr Handle, uint Index);

        ///<summary>Sets the required chip temperature. If the camera has no cooler, this function has no effect.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Temperature">Temperature parameter, expressed in degrees Celsius.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetTemperature(UIntPtr Handle, float Temperature);

        ///<summary>Sets the maximum speed with which the driver changes chip temperature. If the camera has no cooler, this function has no effect.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="TemperatureRamp">Ramp parameter, expressed in degrees Celsius per minute.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetTemperatureRamp(UIntPtr Handle, float TemperatureRamp);

        ///<summary>If the camera is equipped with cooling fan and allows its control, this function sets the fan rotation speed.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Speed">The maximum value of the Speed parameter should be determined by GetIntegerParameter call with gipMaxFan parameter index.</param>
        ///<remarks>If the particular camera supports only on/off switching, the maximum value should be 1 (fan on), while value 0 means fan off.</remarks>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetFan(UIntPtr Handle, byte Speed);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetWindowHeating(UIntPtr Handle, byte On);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetPreflash(UIntPtr Handle, double PreflashTime, uint ClearNum);

        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════
        // Image Handling
        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>When the 'Camera timing asynchronous' interface is used, every exposure starts with 'StartExposure' call.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="ExpTime">Exposure time [s].</param>
        ///<param name="UseShutter">Open or close the shutter.</param>
        ///<param name="x">Sub-frame x coordinate; if not supported by camera, set to 0.</param>
        ///<param name="y">Sub-frame y coordinate; if not supported by camera, set to 0.</param>
        ///<param name="w">Sub-frame width; if not supported by camera, set to chip width.</param>
        ///<param name="d">Sub-frame depth; if not supported by camera, set to chip depth.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte StartExposure(UIntPtr Handle, double ExpTime, byte UseShutter, int x, int y, int w, int d);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte StartExposureTrigger(UIntPtr Handle, double ExpTime, byte UseShutter, int x, int y, int w, int d);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte AbortExposure(UIntPtr Handle, byte DownloadFlag);

        ///<summary>When the exposure already started by 'StartExposure' call, the 'ImageRady' function returns FALSE in the 'Ready' parameter if the exposure is still running.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Ready">FALSE if the exposure is running, TRUE if not.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte ImageReady(UIntPtr Handle, out byte Ready);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte ReadImage(UIntPtr Handle, uint BufferLen, ushort[] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte ReadImage(UIntPtr Handle, uint BufferLen, ushort[,] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte ReadImageExposure(UIntPtr Handle, uint BufferLen, ushort[] BufferAdr);

        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════
        // Misc
        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>Instructs the camera to initiate telescope movement in the R.A. and/or Dec. axis for the defined period of time (in milliseconds).</summary>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte MoveTelescope(UIntPtr Handle, short RADurationMs, short DecDurationMs);

        ///<summary>Sets the 'Moving' variable to TRUE if the movement started with 'MoveTelescope' call is still in progress.</summary>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte MoveInProgress(UIntPtr Handle, out byte Moving);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImageTimeStamp(UIntPtr Handle, out int Year, out int Month, out int Day, out int Hour, out int Minute, out double Second);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetGPSData(UIntPtr Handle, out double Lat, out double Lon, out double MSL, out int Year, out int Month, out int Day, out int Hour, out int Minute, out double Second, out uint Satellites, out byte Fix);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte GetLastErrorString(UIntPtr Handle, int String_HIGH, System.Text.StringBuilder String);

    }
}
