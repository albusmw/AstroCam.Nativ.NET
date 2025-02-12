using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MoravianCameraSDK
{

    using INTEGER = System.Int32;
    using CARDINAL = System.UInt32;

    ///<summary>DLL interface class derived from the decompiled ascom_usb_sfw64.dll.</summary>
    public class Sfw
    {

        const string FilterWheelDriverDllName = "sfw.dll";
        const CallingConvention DLLCallCon = CallingConvention.Cdecl;
        const CharSet DLLCharSet = CharSet.Ansi;

        [UnmanagedFunctionPointer(DLLCallCon)]
        public delegate void EnumCallBack(uint Id);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte Configure(uint Id);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern ulong Create(uint Id);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Enumerate(EnumCallBack e);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte EnumerateFilters(ulong Handle, uint Index, int String_HIGH, StringBuilder String, out uint Color, out int Offest);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetBoolean(ulong Handle, uint Index, out byte Value);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte GetInteger(ulong Handle, uint Index, out uint Value);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon, CharSet = DLLCharSet)]
        public static extern byte GetString(ulong Handle, uint Index, int String_HIGH, StringBuilder String);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Initialize(ulong Handle);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Release(ulong Handle);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern byte SetFilter(ulong Handle, uint Index);

        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void UnInitialize(ulong Handle);


    }
}
