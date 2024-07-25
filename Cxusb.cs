using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MoravianCameraSDK
{
    public class Cxusb
    {
        #region GetBooleanParameter Indexes

        public const uint gbpConnected = 0;
        public const uint gbpSubFrame = 1;
        public const uint gbpReadModes = 2;
        public const uint gbpShutter = 3;
        public const uint gbpCooler = 4;
        public const uint gbpFan = 5;
        public const uint gbpFilters = 6;
        public const uint gbpGuide = 7;
        public const uint gbpWindowHeating = 8;
        public const uint gbpPreflash = 9;
        public const uint gbpAsymmetricBinning = 10;
        public const uint gbpMicrometerFilterOffsets = 11;
        public const uint gbpPowerUtilization = 12;
        public const uint gbpGain = 13;
        public const uint gbpElectronicShutter = 14;
        public const uint gbpGPS = 16;
        public const uint gbpContinuousExposures = 17;
        public const uint gbpTrigger = 18;
        public const uint gbpConfigured = 127;
        public const uint gbpRGB = 128;
        public const uint gbpCMY = 129;
        public const uint gbpCMYG = 130;
        public const uint gbpDebayerXOdd = 131;
        public const uint gbpDebayerYOdd = 132;
        public const uint gbpInterlaced = 256;

        #endregion

        public enum eIntParameters : uint
        {
            gipCameraId = 0,
            gipChipW = 1,
            gipChipD = 2,
            gipPixelW = 3,
            gipPixelD = 4,
            gipMaxBinningX = 5,
            gipMaxBinningY = 6,
            gipReadModes = 7,
            gipFilters = 8,
            gipMinimalExposure = 9,
            gipMaximalExposure = 10,
            gipMaximalMoveTime = 11,
            gipDefaultReadMode = 12,
            gipPreviewReadMode = 13,
            gipMaxWindowHeating = 14,
            gipMaxFan = 15,
            gipMaxGain = 16,
            gipMaxPossiblePixelValue = 17,
            gipFirmwareMajor = 128,
            gipFirmwareMinor = 129,
            gipFirmwareBuild = 130,
            gipDriverMajor = 131,
            gipDriverMinor = 132,
            gipDriverBuild = 133,
            gipFlashMajor = 134,
            gipFlashMinor = 135,
            gipFlashBuild = 136
        };

        #region GetStringParameter Indexes

        public enum eStringParameters : uint
        {
            gspCameraDescription = 0,
            gspManufacturer = 1,
            gspCameraSerial = 2,
            gspChipDescription = 3
        };



        #endregion

        #region GetValue Indexes

        public const uint gvChipTemperature = 0;
        public const uint gvHotTemperature = 1;
        public const uint gvCameraTemperature = 2;
        public const uint gvEnvironmentTemperature = 3;
        public const uint gvSupplyVoltage = 10;
        public const uint gvPowerUtilization = 11;
        public const uint gvADCGain = 20;

        #endregion

        const string CameraDriverDllName = "cxusb.dll";

        #region Camera Enumeration / Connection

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EnumCallBack(uint CameraId);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Enumerate(EnumCallBack cb);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr Initialize(uint CameraId);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Release(UIntPtr Handle);

        #endregion

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterNotifyHWND(UIntPtr Handle, IntPtr HWND);

        #region Getting Values

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetBooleanParameter(UIntPtr Handle, uint Index, out byte Value);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetIntegerParameter(UIntPtr Handle, eIntParameters Index, out int Value);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern byte GetStringParameter(UIntPtr Handle, uint Index, int String_HIGH, StringBuilder String);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetValue(UIntPtr Handle, uint Index, out float Value);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern byte EnumerateReadModes(UIntPtr Handle, int Index, int String_HIGH, StringBuilder String);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern byte EnumerateFilters(UIntPtr Handle, uint Index, int String_HIGH, StringBuilder String, out uint Color);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern byte EnumerateFilters2(UIntPtr Handle, uint Index, int String_HIGH, StringBuilder String, out uint Color, out int Offset);

        #endregion

        #region Setting Values

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SetReadMode(UIntPtr Handle, int Mode);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SetBinning(UIntPtr Handle, uint x, uint y);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGain(UIntPtr Handle, uint gain);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SetFilter(UIntPtr Handle, uint Index);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTemperature(UIntPtr Handle, float Temperature);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTemperatureRamp(UIntPtr Handle, float TemperatureRamp);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SetFan(UIntPtr Handle, byte On);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SetWindowHeating(UIntPtr Handle, byte On);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SetPreflash(UIntPtr Handle, double PreflashTime, uint ClearNum);

        #endregion

        #region Image Handling

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte StartExposure(UIntPtr Handle, double ExpTime, byte UseShutter, int x, int y, int w, int d);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte StartExposureTrigger(UIntPtr Handle, double ExpTime, byte UseShutter, int x, int y, int w, int d);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte AbortExposure(UIntPtr Handle, byte DownloadFlag);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ImageReady(UIntPtr Handle, out byte Ready);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ReadImage(UIntPtr Handle, uint BufferLen, ushort[] BufferAdr);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte ReadImageExposure(UIntPtr Handle, uint BufferLen, ushort[] BufferAdr);

        #endregion

        #region Misc.

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte MoveTelescope(UIntPtr Handle, short RADurationMs, short DecDurationMs);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte MoveInProgress(UIntPtr Handle, out byte Moving);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetImageTimeStamp(UIntPtr Handle, out int Year, out int Month, out int Day, out int Hour, out int Minute, out double Second);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte GetGPSData(UIntPtr Handle, out double Lat, out double Lon, out double MSL, out int Year, out int Month, out int Day, out int Hour, out int Minute, out double Second, out uint Satellites, out byte Fix);

        [DllImport(CameraDriverDllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetLastErrorString(UIntPtr Handle, int String_HIGH, StringBuilder String);

        #endregion
    }
}
