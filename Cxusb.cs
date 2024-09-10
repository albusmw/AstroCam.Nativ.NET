using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace MoravianCameraSDK
{

    using INTEGER = System.Int32;
    using CARDINAL = System.UInt32;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    // 'cxusb.dll' driver handles large cooled C1×, C3, C4 and C5 camera lines, as well as a rollingshutter sensor based C2-9000.
    public class Cxusb
    {

        const string CameraDriverDllName = "cxusb.dll";
        const CallingConvention DLLCallCon = CallingConvention.Cdecl;
        const CharSet DLLCharSet = CharSet.Ansi;


        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Camera Enumeration / Connection
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        [UnmanagedFunctionPointer(DLLCallCon)]
        public delegate void EnumCallBack(uint CameraId);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Enumerate(EnumCallBack cb);

        ///<summary>Initialize the camera and get a handle to it.</summary>
        ///<param name="CameraId">ID of the camera read during the Enumerate calls.</param>
        ///<returns>Camere handle to access the camera.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern UIntPtr Initialize(uint CameraId);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Release(UIntPtr Handle);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void RegisterNotifyHWND(UIntPtr Handle, IntPtr HWND);

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Getting Values
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>Returns boolean value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetBooleanParameter(UIntPtr Handle, Enums.eBoolParameters Index, out byte Value);

        ///<summary>Returns integer value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetIntegerParameter(UIntPtr Handle, Enums.eIntParameters Index, out INTEGER Value);

        ///<summary>Returns float value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetValue(UIntPtr Handle, Enums.eValueParameters Index, out float Value);

        ///<summary>Returns string value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="StringBufferLastIndex">Last 0-based index of the string buffer (if the buffer is 128 character long, the value is 127).</param>
        ///<param name="String">Value read.</param>
        ///<returns>If the function does not 'understand' passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte GetStringParameter(UIntPtr Handle, Enums.eStringParameters Index, int StringBufferLastIndex, System.Text.StringBuilder String);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateReadModes(UIntPtr Handle, CARDINAL Index, int String_HIGH, System.Text.StringBuilder String);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateFilters(UIntPtr Handle, uint Index, int String_HIGH, System.Text.StringBuilder String, out uint Color);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateFilters2(UIntPtr Handle, uint Index, int String_HIGH, System.Text.StringBuilder String, out uint Color, out int Offset);

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Setting Values
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>Sets required read mode.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetReadMode(UIntPtr Handle, int Mode);

        ///<summary>Sets the required read binning. If the camera does not support binning, this function has no effect.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetBinning(UIntPtr Handle, uint x, uint y);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void SetGain(UIntPtr Handle, uint gain);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetFilter(UIntPtr Handle, uint Index);

        ///<summary>Sets the required chip temperature. If the camera has no cooler, this function has no effect.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Temperature">Temperature parameter, expressed in degrees Celsius.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void SetTemperature(UIntPtr Handle, float Temperature);

        ///<summary>Sets the maximum speed with which the driver changes chip temperature. If the camera has no cooler, this function has no effect.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="TemperatureRamp">Ramp parameter, expressed in degrees Celsius per minute.</param>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void SetTemperatureRamp(UIntPtr Handle, float TemperatureRamp);

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

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Image Handling
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>When the 'Camera timing asynchronous' interface is used, every exposure starts with 'StartExposure' call.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="ExpTime">Exposure time [s].</param>
        ///<param name="UseShutter">Open or close the shutter.</param>
        ///<param name="x">Sub-frame x coordinate; if not supported by camera, set to 0.</param>
        ///<param name="y">Sub-frame y coordinate; if not supported by camera, set to 0.</param>
        ///<param name="w">Sub-frame width; if not supported by camera, set to chip width.</param>
        ///<param name="d">Sub-frame depth; if not supported by camera, set to chip depth.</param>
        ///<returns></returns>
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
        public static extern byte ReadImageExposure(UIntPtr Handle, uint BufferLen, ushort[] BufferAdr);

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Misc
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte MoveTelescope(UIntPtr Handle, short RADurationMs, short DecDurationMs);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte MoveInProgress(UIntPtr Handle, out byte Moving);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImageTimeStamp(UIntPtr Handle, out int Year, out int Month, out int Day, out int Hour, out int Minute, out double Second);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetGPSData(UIntPtr Handle, out double Lat, out double Lon, out double MSL, out int Year, out int Month, out int Day, out int Hour, out int Minute, out double Second, out uint Satellites, out byte Fix);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern bool GetLastErrorString(UIntPtr Handle, int String_HIGH, System.Text.StringBuilder String);

    }
}
