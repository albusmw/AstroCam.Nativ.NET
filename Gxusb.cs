using System;
using System.Runtime.InteropServices;

namespace MoravianCameraSDK
{
    ///<summary>'gxusb.dll' handles all CCD-based Gx cameras (G0 to G4, Mark I and Mark II) connected directly to the host computer through USB 2.0 hi-speed lines(480 Mbps).</summary>
    public class Gxusb
    {

        const string CameraDriverDllName = "gXusb.dll";
        const CallingConvention DLLCallCon = CallingConvention.Cdecl;
        const CharSet DLLCharSet = CharSet.Ansi;

        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════
        // Camera Enumeration / Connection
        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════

        ///<summary>This callback function is called for each connected camera and the camera identifier is passed as an argument.</summary>
        ///<param name="CameraId">Camera identifier.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
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

        ///<summary>Returns integer value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetBooleanParameter(UIntPtr Handle, Enums.eBoolCamera Index, out byte Value);

        ///<summary>Returns integer value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetIntegerParameter(UIntPtr Handle, Enums.eIntCamera Index, out int Value);

        ///<summary>Returns float value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="Value">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetValue(UIntPtr Handle, Enums.eValueCamera Index, out float Value);

        ///<summary>Returns string value depending on the Index parameter.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">Index = parameter to read value.</param>
        ///<param name="StringBufferLastIndex">Last 0-based index of the string buffer (if the buffer is 128 character long, the value is 127).</param>
        ///<param name="String">Value read.</param>
        ///<returns>If the function does not 'understand' the passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern bool GetStringParameter(UIntPtr Handle, Enums.eStringCamera Index, int StringBufferLastIndex, System.Text.StringBuilder String);

        ///<summary>Enumerates all read modes provided by the camera.</summary>
        ///<param name="Handle">Camera handle as returned during the Initialize call.</param>
        ///<param name="Index">The caller passes index beginning with 0 and repeats the call with incremented index until the call returns FALSE.</param>
        ///<param name="StringBufferLastIndex">Last 0-based index of the string buffer (if the buffer is 128 character long, the value is 127).</param>
        ///<param name="String">Value read.</param>
        ///<returns>If the function does not 'understand' passed Index, it returns FALSE.</returns>
        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateReadModes(UIntPtr Handle, int Index, int StringBufferLastIndex, System.Text.StringBuilder String);

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
        public static extern void SetGain(UIntPtr Handle, uint gain);

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
        public static extern byte SetFan(UIntPtr Handle, byte On);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetWindowHeating(UIntPtr Handle, byte On);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetPreflash(UIntPtr Handle, double PreflashTime, uint ClearNum);

        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════
        // Image Handling
        // ════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte ClearSensor(UIntPtr Handle);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte Open(UIntPtr Handle);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte Close(UIntPtr Handle);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte BeginExposure(UIntPtr Handle, byte UseShutter);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte EndExposure(UIntPtr Handle, byte UseShutter, byte AbortData);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImage(UIntPtr Handle, int x, int y, int w, int d, uint BufferLen, ushort[] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImage8b(UIntPtr Handle, int x, int y, int w, int d, uint BufferLen, ushort[] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImage16b(UIntPtr Handle, int x, int y, int w, int d, uint BufferLen, ushort[] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImageExposure(UIntPtr Handle, double ExpTime, byte UseShutter, int x, int y, int w, int d, uint BufferLen, ushort[] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImageExposure8b(UIntPtr Handle, double ExpTime, byte UseShutter, int x, int y, int w, int d, uint BufferLen, ushort[] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetImageExposure16b(UIntPtr Handle, double ExpTime, byte UseShutter, int x, int y, int w, int d, uint BufferLen, ushort[] BufferAdr);

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
        public static extern byte AdjustSubFrame(UIntPtr Handle, out int x, out int y, out int w, out int d);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern void GetLastErrorString(UIntPtr Handle, int String_HIGH, System.Text.StringBuilder String);

    }
}
