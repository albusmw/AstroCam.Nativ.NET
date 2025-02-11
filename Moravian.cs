using System;

namespace MoravianCameraSDK
{
    ///<summary>Available enums.</summary>
    public class Enums
    {

        public const Byte BOOL_TRUE = 1;
        public const Byte BOOL_FALSE = 0;

        ///<summary>Boolean values including error.</summary>
        public enum eBoolAndError : uint
        {
            ///<summary>TRUE.</summary>
            bTrue ,
            ///<summary>FALSE.</summary>
            bFalse ,
            ///<summary>Error.</summary>
            error 
        };

        ///<summary>Parameters that return a boolean parameter.</summary>
        public enum eBoolCamera : uint
        {
            /// <summary>TRUE if camera currently connected</summary>
            gbpConnected = 0,
            /// <summary>TRUE if camera supports sub-frame read</summary>
            gbpSubFrame = 1,
            /// <summary>TRUE if camera supports multiple read modes</summary>
            gbpReadModes = 2,
            /// <summary>TRUE if camera is equipped with mechanical shutter</summary>
            gbpShutter = 3,
            /// <summary>TRUE if camera is equipped with active CCD cooler</summary>
            gbpCooler = 4,
            /// <summary>TRUE if camera fan can be controlled (switched on and off)</summary>
            gbpFan = 5,
            /// <summary>TRUE if camera controls filter wheel</summary>
            gbpFilters = 6,
            /// <summary>TRUE if camera is capable to guide the telescope mount</summary>
            gbpGuide = 7,
            /// <summary>TRUE if camera can control the CCD window heating</summary>
            gbpWindowHeating = 8,
            /// <summary>TRUE if camera can use CCD preflash</summary>
            gbpPreflash = 9,
            /// <summary>TRUE if camera horizontal and vertical binning can differ</summary>
            gbpAsymmetricBinning = 10,
            /// <summary>TRUE if filter focusing offsets are expressed in micrometers</summary>
            gbpMicrometerFilterOffsets = 11,
            /// <summary>TRUE if camera can return power utilization in GetValue</summary>
            gbpPowerUtilization = 12,
            /// <summary>TRUE if camera can return used gain in GetValue</summary>
            gbpGain = 13,
            /// <summary>TRUE if the sensor is equipped with electronic shutter</summary>
            gbpElectronicShutter = 14,
            /// <summary>TRUE if the sensor is equipped with GPS receiver</summary>
            gbpGPS = 16,
            /// <summary>TRUE if the camera is capable of serial exposures</summary>
            gbpContinuousExposures = 17,
            /// <summary>TRUE if the sensor is equipped with hardware trigger port</summary>
            gbpTrigger = 18,
            /// <summary>TRUE if camera is configured</summary>
            gbpConfigured = 127,
            /// <summary>TRUE if camera has Bayer RGBG filters on sensor</summary>
            gbpRGB = 128,
            /// <summary>TRUE if camera has CMY filters on sensor</summary>
            gbpCMY = 129,
            /// <summary>TRUE if camera has CMYG filters on sensor</summary>
            gbpCMYG = 130,
            /// <summary>TRUE if camera Bayer masks starts on horizontal odd pixel</summary>
            gbpDebayerXOdd = 131,
            /// <summary>TRUE if camera Bayer masks starts on vertical odd pixel</summary>
            gbpDebayerYOdd = 132,
            /// <summary>TRUE if CCD detector is interlaced (else progressive)</summary>
            gbpInterlaced = 256
        }

        ///<summary>Parameters that return a boolean parameter.</summary>
        public enum eBoolSFW : uint
        {
            /// <summary>TRUE if filter wheel currently connected.</summary>
            gbConnected = 0,
            /// <summary>TRUE if filter wheel initialized (zero filter position found).</summary>
            gbInitialized = 1,
            /// <summary>TRUE if filter focusing offsets are expressed in micrometers.</summary>
            gbMicrometerFilterOffsets = 2,
            /// <summary>TRUE if camera is configured.</summary>
            gbpConfigured = 127,
        }

        ///<summary>Parameters that return a integer parameter.</summary>
        public enum eIntCamera : uint
        {
            /// <summary>Identifier of the current camera</summary>
            gipCameraId = 0,
            /// <summary>Sensor width in pixels</summary>
            gipChipWidth = 1,
            /// <summary>Sensor depth in pixels</summary>
            gipChipDepth = 2,
            /// <summary>Sensor pixel width in nanometers</summary>
            gipPixelWidth = 3,
            /// <summary>Sensor pixel depth in nanometers</summary>
            gipPixelDepth = 4,
            /// <summary>Maximum binning in horizontal direction</summary>
            gipMaxBinningX = 5,
            /// <summary>Maximum binning in vertical direction</summary>
            gipMaxBinningY = 6,
            /// <summary>Number of read modes offered by the camera</summary>
            gipReadModes = 7,
            /// <summary>Number of filters offered by the camera</summary>
            gipFilters = 8,
            /// <summary>Shortest exposure time in microseconds (µs)</summary>
            gipMinimalExposure = 9,
            /// <summary>Longest exposure time in milliseconds (ms)</summary>
            gipMaximalExposure = 10,
            /// <summary>Longest time to move the telescope in milliseconds (ms)</summary>
            gipMaximalMoveTime = 11,
            /// <summary>Read mode to be used as default</summary>
            gipDefaultReadMode = 12,
            /// <summary>Read mode to be used for preview (fast read)</summary>
            gipPreviewReadMode = 13,
            /// <summary>Maximal value for 'SetWindowHeating' call</summary>
            gipMaxWindowHeating = 14,
            /// <summary>Maximal value for 'SetFan' call</summary>
            gipMaxFan = 15,
            /// <summary>Maximum value for 'SetGain' call</summary>
            gipMaxGain = 16,
            /// <summary>Maximum value of (saturated) pixel</summary>
            /// <remarks>Note the value may vary with read mode and binning, read only after 'SetReadMode' and 'SetBinning' calls.</remarks>
            gipMaxPossiblePixelValue = 17,
            /// <summary>Time to digitize one image line of rolling-shutter cameras equpped with GPS receiver</summary>
            gipLineTime = 18,
            /// <summary>Camera firmware version - major</summary>
            gipFirmwareMajor = 128,
            /// <summary>Camera firmware version - minor</summary>
            gipFirmwareMinor = 129,
            /// <summary>Camera firmware version - build</summary>
            gipFirmwareBuild = 130,
            /// <summary>Driver version - major</summary>
            gipDriverMajor = 131,
            /// <summary>Driver version - minor</summary>
            gipDriverMinor = 132,
            /// <summary>Driver version - build</summary>
            gipDriverBuild = 133,
            /// <summary>Flash version - major</summary>
            gipFlashMajor = 134,
            /// <summary>Flash version - minor</summary>
            gipFlashMinor = 135,
            /// <summary>Flash version - build</summary>
            gipFlashBuild = 136
        };

        ///<summary>Parameters that return a integer parameter.</summary>
        public enum eIntSFW : uint
        {
            /// <summary>Filter wheel drive major version.</summary>
            giVersion1 = 0,
            /// <summary>Filter wheel drive minor version.</summary>
            giVersion2 = 1,
            /// <summary>Filter wheel drive build version.</summary>
            giVersion3 = 2,
            /// <summary>Filter wheel drive release version.</summary>
            giVersion4 = 3,
            /// <summary>Unique identifier of the standalone filter wheel.</summary>
            giFilterWheelId = 4,
            /// <summary>Number of filters available.</summary>
            giFilters = 5,
        };

        ///<summary>Parameters that return a string parameter.</summary>
        public enum eStringCamera : uint
        {
            /// <summary>Camera description</summary>
            gspCameraDescription = 0,
            /// <summary>Manufacturer name</summary>
            gspManufacturer = 1,
            /// <summary>Camera serial number</summary>
            gspCameraSerial = 2,
            /// <summary>Used CCD detector description</summary>
            gspChipDescription = 3
        };

        ///<summary>Parameters that return a string parameter.</summary>
        public enum eStringSFW : uint
        {
            /// <summary>Filter wheel description.</summary>
            gsFWDescription = 0,
            /// <summary>Manufacturer name.</summary>
            gsManufacturer = 1,
            /// <summary>Filter wheel serial number.</summary>
            gsSerialNumber = 2,
        };

        ///<summary>Parameters that return a floating point parameter.</summary>
        public enum eValueCamera : uint
        {
            /// <summary>Current temperature of the CCD detector in deg. Celsius</summary>
            gvChipTemperature = 0,
            /// <summary>Current temperature of the cooler hot side in deg. Celsius</summary>
            gvHotTemperature = 1,
            /// <summary>Current temperature inside the camera in deg. Celsius</summary>
            gvCameraTemperature = 2,
            /// <summary>Current temperature of the environment air in deg. Celsius</summary>
            gvEnvironmentTemperature = 3,
            /// <summary>Current voltage of the camera power supply</summary>
            gvSupplyVoltage = 10,
            /// <summary>Current utilization of the CCD cooler (number 0 to 1)</summary>
            gvPowerUtilization = 11,
            /// <summary>Current gain of A/D converter in electrons/ADU</summary>
            gvADCGain = 20
        };

    }
}