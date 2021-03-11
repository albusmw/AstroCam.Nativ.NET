Option Explicit On
Option Strict On

Namespace QHY

    '''<summary>Access the QHYDLL.dll class calls with logging.</summary>
    Public Class QHY

        '''<summary>DLL call log.</summary>
        Public Shared CallLog As New List(Of List(Of KeyValuePair(Of String, Object)))

        '''<summary>Location of the log file.</summary>
        Public Shared Property LogFile As String = String.Empty

        Public Class LogKeys
            Public Const FunctionName As String = "<FunctionName>"
            Public Const CallStart As String = "<CallStart>"
            Public Const CallEnd As String = "<CallEnd>"
            Public Const Returns As String = "<returns>"
        End Class

        Public Shared Function BeginQHYCCDLive(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> BeginQHYCCDLive"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.BeginQHYCCDLive(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function CancelQHYCCDExposing(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> CancelQHYCCDExposing"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.CancelQHYCCDExposing(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function CancelQHYCCDExposingAndReadout(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> CancelQHYCCDExposingAndReadout"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.CancelQHYCCDExposingAndReadout(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function CloseQHYCCD(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> CloseQHYCCD"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.CloseQHYCCD(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<param name="handle">The camera handle returned by OpenQHYCCD.</param>
        '''<param name="targettemp">[IN] CCD target temperature.</param>
        Public Shared Function ControlQHYCCDTemp(ByVal handle As IntPtr, ByVal targettemp As Double) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> ControlQHYCCDTemp"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("targettemp", targettemp))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.ControlQHYCCDTemp(handle, targettemp)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>Start the expose of a frame.</summary>
        '''<param name="handle">[IN] The camera handle returned by OpenQHYCCD.</param>
        '''<returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function ExpQHYCCDSingleFrame(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> ExpQHYCCDSingleFrame"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.ExpQHYCCDSingleFrame(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>Used to get effective size And start position.</summary>
        '''<param name="handle">[IN] The camera handle returned by OpenQHYCCD.</param>
        '''<param name="startx">[OUT] The start position of image effective area in horizontal direction.</param>
        '''<param name="starty">[OUT] The start position of image effective area in vertical direction.</param>
        '''<param name="sizex">[OUT] The width of image effective area.</param>
        '''<param name="sizey">[OUT] The height of image effective area.</param>
        '''<returns>On success, return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function GetQHYCCDEffectiveArea(ByVal handle As IntPtr, ByRef startx As UInt32, ByRef starty As UInt32, ByRef sizex As UInt32, ByRef sizey As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDEffectiveArea"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDEffectiveArea(handle, startx, starty, sizex, sizey)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("startx", startx))
            Args.Add(New KeyValuePair(Of String, Object)("starty", starty))
            Args.Add(New KeyValuePair(Of String, Object)("sizex", sizex))
            Args.Add(New KeyValuePair(Of String, Object)("sizey", sizey))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>Gets the camera ID, which Is stored in a character array And if run successfully, it will return QHYCCD_SUCCESS.The ID of each camera consists of the camera model And serial number.For example, qhy183c-c915484fa76ea7552, QHY183C in the front Is the camera model, And c915484fa76ea7552 in the back Is the serial number of the camera. Each camera has its own serial number, which Is different even for different cameras of the same model. Its role Is to distinguish between cameras, which are necessary when testing multiple cameras.</summary>
        '''<param name="index">[IN] This is the index of the array of camera structure - must be lower than the equal of ScanQHYCCD(); return value</param>
        '''<param name="id">[OUT] A pointer variate which is char type, it is used to receive camera ID that returned by function.</param>
        Public Shared Function GetQHYCCDId(ByVal index As Integer, ByRef id As System.Text.StringBuilder) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDId"))
            Args.Add(New KeyValuePair(Of String, Object)("index", index))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDId(index, id)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("id", id))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDCFWStatus(ByVal handle As IntPtr, ByVal cfwStatus As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDCFWStatus"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDCFWStatus(handle, cfwStatus)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("cfwStatus", cfwStatus))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>This function will output the basic information of the camera.  Includes the physical pixel size, the basic pixel array size. And the current image depth.</summary>
        '''<param name="handle">The camera handle returned by OpenQHYCCD.</param>
        '''<param name="chipw">Chip width [mm].</param>
        '''<param name="chiph">Chip height [mm].</param>
        '''<param name="imagew">The image array width And height Is the maxium image width And height. Even in small ROI Or in overscan area removed mode. this size will Not change.</param>
        '''<param name="imageh">The image array width And height Is the maxium image width And height. Even in small ROI Or in overscan area removed mode. this size will Not change.</param>
        '''<param name="pixelw">Please note the pixel width And pixel height Is in physical. So even with BIN22, the pixel size Is still the physical pixel size, it will Not change with the binning setting.</param>
        '''<param name="pixelh">Please note the pixel width And pixel height Is in physical. So even with BIN22, the pixel size Is still the physical pixel size, it will Not change with the binning setting.</param>
        '''<param name="bpp">The image depth bpp, will be changed if user set the bitDepth by the Set Parameter command </param>
        '''<returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function GetQHYCCDChipInfo(ByVal handle As IntPtr, ByRef chipw As Double, ByRef chiph As Double, ByRef imagew As UInt32, ByRef imageh As UInt32, ByRef pixelw As Double, ByRef pixelh As Double, ByRef bpp As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDChipInfo"))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDChipInfo(handle, chipw, chiph, imagew, imageh, pixelw, pixelh, bpp)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("chipw", chipw))
            Args.Add(New KeyValuePair(Of String, Object)("chiph", chiph))
            Args.Add(New KeyValuePair(Of String, Object)("imagew", imagew))
            Args.Add(New KeyValuePair(Of String, Object)("imageh", imageh))
            Args.Add(New KeyValuePair(Of String, Object)("pixelw", pixelw))
            Args.Add(New KeyValuePair(Of String, Object)("pixelh", pixelh))
            Args.Add(New KeyValuePair(Of String, Object)("bpp", bpp))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDLiveFrame(ByVal handle As IntPtr, ByRef ImageWidth As UInt32, ByRef ImageHeight As UInt32, ByRef bpp As UInt32, ByRef channels As UInt32, ByRef pBuffer As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDLiveFrame"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDLiveFrame(handle, ImageWidth, ImageHeight, bpp, channels, pBuffer)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("ImageWidth", ImageWidth))
            Args.Add(New KeyValuePair(Of String, Object)("ImageHeight", ImageHeight))
            Args.Add(New KeyValuePair(Of String, Object)("bpp", bpp))
            Args.Add(New KeyValuePair(Of String, Object)("channels", channels))
            Args.Add(New KeyValuePair(Of String, Object)("pBuffer", pBuffer))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDMemLength(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDMemLength"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDMemLength(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDNumberOfReadModes(ByVal handle As IntPtr, ByRef numModes As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDNumberOfReadModes"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDNumberOfReadModes(handle, numModes)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("numModes", numModes))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>Some CCD have overscan area,this function Is used to get the size And start position of image.</summary>
        '''<param name="handle">The camera handle returned by OpenQHYCCD.</param>
        '''<param name="startx">The start position of image overscan area in horizontal direction.</param>
        '''<param name="starty">The start position of image overscan area in vertical direction.</param>
        '''<param name="sizex">The width of image overscan area.</param>
        '''<param name="sizey">The height of image overscan area.</param>
        '''<returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function GetQHYCCDOverScanArea(ByVal handle As IntPtr, ByRef startx As UInt32, ByRef starty As UInt32, ByRef sizex As UInt32, ByRef sizey As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDOverScanArea"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDOverScanArea(handle, startx, starty, sizex, sizey)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("startx", startx))
            Args.Add(New KeyValuePair(Of String, Object)("starty", starty))
            Args.Add(New KeyValuePair(Of String, Object)("sizex", sizex))
            Args.Add(New KeyValuePair(Of String, Object)("sizey", sizey))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>This function can get camera information according to CONTROL_ID, for example, expose time, gain, offset.</summary>
        '''<param name="handle">The camera handle returned by OpenQHYCCD.</param>
        '''<param name="controlid">The corresponding control ID.</param>
        '''<returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function GetQHYCCDParam(ByVal handle As IntPtr, ByVal controlid As QHYCamera.QHY.CONTROL_ID) As Double
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDParam"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("controlid", controlid))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As Double = QHYCamera.QHYDLL.GetQHYCCDParam(handle, controlid)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDParamMinMaxStep(ByVal handle As IntPtr, ByVal controlid As QHYCamera.QHY.CONTROL_ID, ByRef Min As Double, ByRef Max As Double, ByRef Stepping As Double) As QHYCamera.QHY.QHYCCD_ERROR
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDParamMinMaxStep"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("controlid", controlid))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As QHYCamera.QHY.QHYCCD_ERROR = QHYCamera.QHYDLL.GetQHYCCDParamMinMaxStep(handle, controlid, Min, Max, Stepping)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("Min", Min))
            Args.Add(New KeyValuePair(Of String, Object)("Max", Max))
            Args.Add(New KeyValuePair(Of String, Object)("Stepping", Stepping))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDReadModeName(ByVal handle As IntPtr, ByVal modeNumber As UInt32, ByRef name As System.Text.StringBuilder) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDReadModeName"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("modeNumber", modeNumber))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDReadModeName(handle, modeNumber, name)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("name", name))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDReadModeResolution(ByVal handle As IntPtr, ByVal modeNumber As UInt32, ByRef width As UInt32, ByRef height As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDReadModeResolution"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("modeNumber", modeNumber))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDReadModeResolution(handle, modeNumber, width, height)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("width", width))
            Args.Add(New KeyValuePair(Of String, Object)("height", height))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function GetQHYCCDSDKVersion(ByRef year As UInt32, ByRef month As UInt32, ByRef day As UInt32, ByRef subday As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDSDKVersion"))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDSDKVersion(year, month, day, subday)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("year", year))
            Args.Add(New KeyValuePair(Of String, Object)("month", month))
            Args.Add(New KeyValuePair(Of String, Object)("day", day))
            Args.Add(New KeyValuePair(Of String, Object)("subday", subday))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>This function retrieves the version of the camera driver (firmware), which is a date, such as 18-3-30.</summary>
        '''<param name="handle">[IN] The camera handle returned by OpenQHYCCD.</param>
        '''<param name="verBuf">[OUT] Used to store the information about firmware version.</param>
        '''<returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function GetQHYCCDFWVersion(ByVal handle As IntPtr, ByVal buf As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDFWVersion"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDFWVersion(handle, buf)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("buf", buf))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>Used to get a frame image data And store data in "ImgData" variate.</summary>
        '''<param name="handle">[IN] The camera handle returned by OpenQHYCCD.</param>
        '''<param name="ImageWidth">[OUT] The width of image.</param>
        '''<param name="ImageHeight">[OUT] The height of image.</param>
        '''<param name="bpp">[OUT] The bit depth of image.</param>
        '''<param name="channels">[OUT] The channel of image.</param>
        '''<param name="rawArray">[OUT] Used to receive image data.</param>
        '''<returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function GetQHYCCDSingleFrame(ByVal handle As IntPtr, ByRef ImageWidth As UInt32, ByRef ImageHeight As UInt32, ByRef bpp As UInt32, ByRef channels As UInt32, ByVal rawArray As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- GetQHYCCDSingleFrame"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            StoreCurrentLog()
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.GetQHYCCDSingleFrame(handle, ImageWidth, ImageHeight, bpp, channels, rawArray)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)("ImageWidth", ImageWidth))
            Args.Add(New KeyValuePair(Of String, Object)("ImageHeight", ImageHeight))
            Args.Add(New KeyValuePair(Of String, Object)("bpp", bpp))
            Args.Add(New KeyValuePair(Of String, Object)("channels", channels))
            Args.Add(New KeyValuePair(Of String, Object)("rawArray", rawArray))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function InitQHYCCD(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> InitQHYCCD"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.InitQHYCCD(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function InitQHYCCDResource() As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> InitQHYCCDResource"))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.InitQHYCCDResource()
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function IsQHYCCDControlAvailable(ByVal handle As IntPtr, ByVal controlid As QHYCamera.QHY.CONTROL_ID) As QHYCamera.QHY.QHYCCD_ERROR
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "<- IsQHYCCDControlAvailable"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("controlid", controlid))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As QHYCamera.QHY.QHYCCD_ERROR = QHYCamera.QHYDLL.IsQHYCCDControlAvailable(handle, controlid)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function OpenQHYCCD(ByVal handle As System.Text.StringBuilder) As IntPtr
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> OpenQHYCCD"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As IntPtr = QHYCamera.QHYDLL.OpenQHYCCD(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function ReleaseQHYCCDResource() As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> ReleaseQHYCCDResource"))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.ReleaseQHYCCDResource()
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function ScanQHYCCD() As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> ScanQHYCCD"))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.ScanQHYCCD()
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>Used to control filter wheel.</summary>
        '''<param name="handle">The camera handle returned by OpenQHYCCD.</param>
        '''<param name="order">The target position of filter wheel.</param>
        '''<param name="length">The length of "order".</param>
        '''<returns>On success,return QHYCCD_SUCCESS, another QHYCCD_ERROR code on other failures.</returns>
        Public Shared Function SendOrder2QHYCCDCFW(ByVal handle As IntPtr, ByVal order As IntPtr, ByVal length As Integer) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> SendOrder2QHYCCDCFW"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("order", order))
            Args.Add(New KeyValuePair(Of String, Object)("length", length))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.SendOrder2QHYCCDCFW(handle, order, length)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function SetQHYCCDBinMode(ByVal handle As IntPtr, ByVal wbin As UInt32, ByVal hbin As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> SetQHYCCDBinMode"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("wbin", wbin))
            Args.Add(New KeyValuePair(Of String, Object)("hbin", hbin))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.SetQHYCCDBinMode(handle, wbin, hbin)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function SetQHYCCDParam(ByVal handle As IntPtr, ByVal controlid As QHYCamera.QHY.CONTROL_ID, ByVal value As Double) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> SetQHYCCDParam"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("controlid", controlid))
            Args.Add(New KeyValuePair(Of String, Object)("value", value))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.SetQHYCCDParam(handle, controlid, value)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function SetQHYCCDReadMode(ByVal handle As IntPtr, ByVal modeNumber As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> SetQHYCCDReadMode"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("modeNumber", modeNumber))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.SetQHYCCDReadMode(handle, modeNumber)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function SetQHYCCDResolution(ByVal handle As IntPtr, ByVal startx As UInt32, ByVal starty As UInt32, ByVal sizex As UInt32, ByVal sizey As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> SetQHYCCDResolution"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("startx", startx))
            Args.Add(New KeyValuePair(Of String, Object)("starty", starty))
            Args.Add(New KeyValuePair(Of String, Object)("sizex", sizex))
            Args.Add(New KeyValuePair(Of String, Object)("sizey", sizey))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.SetQHYCCDResolution(handle, startx, starty, sizex, sizey)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function SetQHYCCDStreamMode(ByVal handle As IntPtr, ByVal mode As UInt32) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> SetQHYCCDStreamMode"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)("mode", mode))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.SetQHYCCDStreamMode(handle, mode)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        Public Shared Function StopQHYCCDLive(ByVal handle As IntPtr) As UInt32
            Dim Args As New List(Of KeyValuePair(Of String, Object))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.FunctionName, "-> StopQHYCCDLive"))
            Args.Add(New KeyValuePair(Of String, Object)("handle", handle))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallStart, DateTimeOffset.Now))
            Dim RetVal As UInt32 = QHYCamera.QHYDLL.StopQHYCCDLive(handle)
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.CallEnd, DateTimeOffset.Now))
            Args.Add(New KeyValuePair(Of String, Object)(LogKeys.Returns, RetVal))
            CallLog.Add(Args) : Return RetVal
        End Function

        '''<summary>Formated content of the logging.</summary>
        '''<returns>List of log entries.</returns>
        Public Shared Function GetCallLog() As List(Of String)
            Const LogLineLength As Integer = 227
            Dim LogContent As New List(Of String)
            Dim LastEnd As DateTimeOffset
            Dim ms_SingeLast As Integer
            For Each SingleCall As List(Of KeyValuePair(Of String, Object)) In CallLog
                Dim FunctionName As String = String.Empty
                Dim ReturnVal As String = String.Empty
                Dim Arguments As New List(Of String)
                Dim StartTime As DateTimeOffset
                Dim CallDuration As Integer = 0
                'Join all arguments
                For Each Arg As KeyValuePair(Of String, Object) In SingleCall
                    Select Case Arg.Key
                        Case LogKeys.FunctionName
                            FunctionName = CStr(Arg.Value).PadRight(33)
                        Case LogKeys.CallEnd
                            LastEnd = CType(Arg.Value, DateTimeOffset)
                        Case LogKeys.CallStart
                            StartTime = CType(Arg.Value, DateTimeOffset)
                            If LastEnd <> DateTimeOffset.MinValue Then
                                ms_SingeLast = CInt((StartTime - LastEnd).TotalMilliseconds)
                            Else
                                ms_SingeLast = 0
                            End If
                        Case Else
                            'Normal argument
                            Dim ArgValue As String = String.Empty
                            Select Case Arg.Value.GetType
                                Case GetType(Double)
                                    ArgValue = CType(Arg.Value, Double).ValRegIndep
                                Case GetType(System.Text.StringBuilder)
                                    If CType(Arg.Value, System.Text.StringBuilder).Length <= 40 Then
                                        ArgValue = CType(Arg.Value, System.Text.StringBuilder).ToString
                                    Else
                                        ArgValue = "StringBuilder, length <" & CType(Arg.Value, System.Text.StringBuilder).Length.ValRegIndep & ">"
                                    End If
                                Case GetType(IntPtr)
                                    ArgValue = "0x" & Hex(CType(Arg.Value, IntPtr).ToInt64)
                                Case GetType(QHYCamera.QHY.CONTROL_ID)
                                    ArgValue = CType(Arg.Value, QHYCamera.QHY.CONTROL_ID).ToString
                                Case Else
                                    Try
                                        ArgValue = CType(Arg.Value, String)
                                    Catch ex As Exception
                                        ArgValue = "??? <" & Arg.Value.GetType.Name & ">...<" & ex.Message & ">"
                                    End Try
                            End Select
                            If Arg.Key = LogKeys.Returns Then
                                ReturnVal = ArgValue
                            Else
                                Arguments.Add(Arg.Key & "=<" & ArgValue & ">")
                            End If
                    End Select
                Next Arg
                'Build 1 log lone
                CallDuration = CInt((LastEnd - StartTime).TotalMilliseconds)
                Dim LogLine As String = String.Empty
                LogLine &= Format(StartTime.DateTime, "HH:mm:ss.fff")
                LogLine &= " (" & ms_SingeLast.ToString.PadLeft(10) & " ms delay); took " & CallDuration.ToString.PadLeft(7) & " ms: "
                LogLine &= FunctionName & ("(" & Join(Arguments.ToArray, ",") & ")").PadRight(120) & " -> " & ReturnVal.PadLeft(15) & "|"
                If LogLine.Length > LogLineLength Then LogLine = LogLine.Substring(0, LogLineLength)
                LogContent.Add(LogLine)
            Next SingleCall
            Return LogContent
        End Function

        '''<summary>Store the current log and clear the log content.</summary>
        Public Shared Sub StoreCurrentLog()
            System.IO.File.AppendAllLines(LogFile, GetCallLog)
            CallLog.Clear()
        End Sub

    End Class

End Namespace