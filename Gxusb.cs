﻿using System;
using System.Runtime.InteropServices;

namespace MoravianCameraSDK
{
    public class Gxusb
    {

        const string CameraDriverDllName = "gXusb.dll";
        const CallingConvention DLLCallCon = CallingConvention.Cdecl;
        const CharSet DLLCharSet = CharSet.Ansi;

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Camera Enumeration / Connection
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EnumCallBack(uint CameraId);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Enumerate(EnumCallBack cb);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern UIntPtr Initialize(uint CameraId);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Release(UIntPtr Handle);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void RegisterNotifyHWND(UIntPtr Handle, IntPtr HWND);

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Getting Values
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetBooleanParameter(UIntPtr Handle, Enums.eBoolParameters Index, out byte Value);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetIntegerParameter(UIntPtr Handle, Enums.eIntParameters Index, out int Value);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern bool GetStringParameter(UIntPtr Handle, Enums.eStringParameters Index, int String_HIGH, System.Text.StringBuilder String);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetValue(UIntPtr Handle, Enums.eValueParameters Index, out float Value);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateReadModes(UIntPtr Handle, int Index, int String_HIGH, System.Text.StringBuilder String);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateFilters(UIntPtr Handle, uint Index, int String_HIGH, System.Text.StringBuilder String, out uint Color);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateFilters2(UIntPtr Handle, uint Index, int String_HIGH, System.Text.StringBuilder String, out uint Color, out int Offset);

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Setting Values
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetReadMode(UIntPtr Handle, int Mode);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetBinning(UIntPtr Handle, uint x, uint y);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void SetGain(UIntPtr Handle, uint gain);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetFilter(UIntPtr Handle, uint Index);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void SetTemperature(UIntPtr Handle, float Temperature);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void SetTemperatureRamp(UIntPtr Handle, float TemperatureRamp);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetFan(UIntPtr Handle, byte On);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetWindowHeating(UIntPtr Handle, byte On);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetPreflash(UIntPtr Handle, double PreflashTime, uint ClearNum);

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Image Handling
        // ══════════════════════════════════════════════════════════════════════════════════════════════

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

        // ══════════════════════════════════════════════════════════════════════════════════════════════
        // Misc
        // ══════════════════════════════════════════════════════════════════════════════════════════════

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte MoveTelescope(UIntPtr Handle, short RADurationMs, short DecDurationMs);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte MoveInProgress(UIntPtr Handle, out byte Moving);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte AdjustSubFrame(UIntPtr Handle, out int x, out int y, out int w, out int d);

        [DllImport(CameraDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern void GetLastErrorString(UIntPtr Handle, int String_HIGH, System.Text.StringBuilder String);

    }
}
