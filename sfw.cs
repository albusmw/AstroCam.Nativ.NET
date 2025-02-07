using System;
using System.Runtime.InteropServices;

namespace MoravianCameraSDK
{
    public class Sfw
    {

        const string FilterWheelDriverDllName = "sfw.dll";
        const CallingConvention DLLCallCon = CallingConvention.Cdecl;
        const CharSet DLLCharSet = CharSet.Ansi;

        ///<summary>This callback function is called for each connected filter wheel and the filter wheel identifier is passed as an argument.</summary>
        ///<param name="CameraId">Camera identifier.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EnumCallBack(uint CameraId);

        ///<summary>Enumerate allows discovering of all filter wheels currently connected to the host PC.</summary>
        ///<param name="CallBackPointer">Pointer to callback function 'CallbackProc' with single unsigned integer argument. This callback function is called for each connected filter wheel and the filter wheel identifier is passed as an argument.</param>
        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Enumerate(EnumCallBack CallBackPointer);

        ///<summary>Initialize the filter wheel and get a handle to it.</summary>
        ///<param name="CameraId">ID of the filter wheel read during the Enumerate calls.</param>
        ///<returns>Filter wheel handle to access the filter wheel.</returns>
        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern UIntPtr Initialize(uint CameraId);

        ///<summary>When the filter wheel is no longer used, the handle must be released by the 'Release' call.</summary>
        ///<param name="Handle">Filter wheel handle as returned during the Initialize call.</param>
        ///<remarks>No other function (with the exception of 'Enumerate' and 'Initialize') may be called after the 'Release' call.</remarks>
        [DllImport(FilterWheelDriverDllName, CallingConvention = DLLCallCon)]
        public static extern void Release(UIntPtr Handle);

    }
}
