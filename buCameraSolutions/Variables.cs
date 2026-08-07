// Decompiled with JetBrains decompiler
// Type: buCameraSolutions.Variables
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

#nullable enable
namespace buCameraSolutions;

public static class Variables
{
  public static string exeMode = string.Empty;
  public static string camModel = string.Empty;
  public static string canonTv = string.Empty;
  public static string canonIso = string.Empty;
  public static string canonAv = string.Empty;
  public static Matrix<double> cameraMatrix = new Matrix<double>(3, 3);
  public static Matrix<double> distCoeffs = new Matrix<double>(5, 1);
  public static Mat rvec = new Mat();
  public static Mat tvec = new Mat();
  public static List<PointF> articlePoints = new List<PointF>();

  [field: DebuggerBrowsable]
  public static bool AutoCorrectLens { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoTopView { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal TopViewWidth { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal TopViewHeight { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal MarkerSize { get; set; }

  [field: DebuggerBrowsable]
  public static string StretchType { get; set; } = "Normal";

  [field: DebuggerBrowsable]
  public static bool AutoRotateLeft { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoRotateRight { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoMirrorHorizontal { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoMirrorVertical { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal RotationValue { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal DistStrK1 { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal DistStrK2 { get; set; }

  [field: DebuggerBrowsable]
  public static bool RotationFirst { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoRotation { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoStretch { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoContour { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal DistX { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal DistY { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal DelayTime { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal gencamExpManual { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal gencamGain { get; set; }

  [field: DebuggerBrowsable]
  public static bool gencamExpAuto { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal gencamExpLowL { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal gencamExpUpL { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal backHueRange { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal backSatRange { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal backValRange { get; set; }

  [field: DebuggerBrowsable]
  public static string backColorspace { get; set; } = "LAB";

  [field: DebuggerBrowsable]
  public static Decimal minArea { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal contourDist { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal contourSensitivity { get; set; }

  [field: DebuggerBrowsable]
  public static string pointSaveMethod { get; set; } = "Milimeter";

  [field: DebuggerBrowsable]
  public static bool contourShowArea { get; set; }

  [field: DebuggerBrowsable]
  public static bool contourShowPoints { get; set; }

  [field: DebuggerBrowsable]
  public static string contourShowcase { get; set; } = "Rectangle";

  [field: DebuggerBrowsable]
  public static string contourMethod { get; set; } = "Simplified";

  [field: DebuggerBrowsable]
  public static Decimal contourCornerAngle { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal contourLineFit { get; set; }

  [field: DebuggerBrowsable]
  public static bool addOffset { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal offsetTop { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal offsetBottom { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal offsetLeft { get; set; }

  [field: DebuggerBrowsable]
  public static Decimal offsetRight { get; set; }

  [field: DebuggerBrowsable]
  public static double FocalLength { get; set; }

  [field: DebuggerBrowsable]
  public static double SensorWidth { get; set; }

  [field: DebuggerBrowsable]
  public static double SensorHeight { get; set; }

  [field: DebuggerBrowsable]
  public static double PrincipalPointX { get; set; }

  [field: DebuggerBrowsable]
  public static double PrincipalPointY { get; set; }

  [field: DebuggerBrowsable]
  public static string EthernetName { get; set; } = "Ethernet";

  [field: DebuggerBrowsable]
  public static string EthernetPortIP { get; set; } = "172.16.39.200";

  [field: DebuggerBrowsable]
  public static string EthernetCameraIP { get; set; } = "172.16.39.19";

  [field: DebuggerBrowsable]
  public static double StoneThickness { get; set; }

  [field: DebuggerBrowsable]
  public static double OffsetMpX { get; set; }

  [field: DebuggerBrowsable]
  public static double OffsetMpY { get; set; }

  [field: DebuggerBrowsable]
  public static double OffsetCenterX { get; set; }

  [field: DebuggerBrowsable]
  public static double OffsetCenterY { get; set; }

  [field: DebuggerBrowsable]
  public static bool AutoCalcOffset { get; set; }

  [field: DebuggerBrowsable]
  public static PointF[] dragPoints { get; set; }

  public static void ReadExeSettings(string txtSettingsPath)
  {
    try
    {
      string[] strArray = File.ReadAllLines(txtSettingsPath);
      Variables.exeMode = Variables.GetValue(strArray[0]);
      if (string.IsNullOrWhiteSpace(Variables.exeMode))
        throw new Exception("TV (Shutter speed) cannot be empty.");
      Variables.camModel = Variables.GetValue(strArray[1]);
      if (string.IsNullOrWhiteSpace(Variables.camModel))
        throw new Exception("ISO cannot be empty.");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing camera settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  public static void ReadMenuSettings(string txtSettingsPath)
  {
    try
    {
      if (!File.Exists(txtSettingsPath))
        return;
      string[] strArray = File.ReadAllLines(txtSettingsPath);
      Variables.AutoCorrectLens = strArray.Length >= 12 ? bool.Parse(Variables.GetValue(strArray[0])) : throw new Exception("Menu settings file does not contain enough lines.");
      Variables.AutoTopView = bool.Parse(Variables.GetValue(strArray[1]));
      Variables.TopViewWidth = Decimal.Parse(Variables.GetValue(strArray[2]));
      Variables.TopViewHeight = Decimal.Parse(Variables.GetValue(strArray[3]));
      Variables.MarkerSize = Decimal.Parse(Variables.GetValue(strArray[4]));
      Variables.StretchType = Variables.GetValue(strArray[5]);
      Variables.AutoRotateLeft = bool.Parse(Variables.GetValue(strArray[6]));
      Variables.AutoRotateRight = bool.Parse(Variables.GetValue(strArray[7]));
      Variables.AutoMirrorHorizontal = bool.Parse(Variables.GetValue(strArray[8]));
      Variables.AutoMirrorVertical = bool.Parse(Variables.GetValue(strArray[9]));
      Variables.RotationValue = Decimal.Parse(Variables.GetValue(strArray[10]));
      (Variables.DistStrK1, Variables.DistStrK2) = Variables.Get2Values(strArray[11]);
      Variables.RotationFirst = bool.Parse(Variables.GetValue(strArray[12]));
      Variables.AutoRotation = bool.Parse(Variables.GetValue(strArray[13]));
      Variables.AutoStretch = bool.Parse(Variables.GetValue(strArray[14]));
      (Variables.DistX, Variables.DistY) = Variables.Get2Values(strArray[15]);
      Variables.DelayTime = Decimal.Parse(Variables.GetValue(strArray[16 /*0x10*/]));
      Variables.addOffset = bool.Parse(Variables.GetValue(strArray[17]));
      Variables.offsetTop = Decimal.Parse(Variables.GetValue(strArray[18]));
      Variables.offsetBottom = Decimal.Parse(Variables.GetValue(strArray[19]));
      Variables.offsetLeft = Decimal.Parse(Variables.GetValue(strArray[20]));
      Variables.offsetRight = Decimal.Parse(Variables.GetValue(strArray[21]));
      Variables.AutoContour = bool.Parse(Variables.GetValue(strArray[22]));
      Variables.AutoCalcOffset = bool.Parse(Variables.GetValue(strArray[23]));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing settings: " + ex.Message);
    }
  }

  public static void WriteMenuSettings(string txtSettingsPath)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(txtSettingsPath))
      {
        ((TextWriter) streamWriter).WriteLine($"Auto Correct Lens: {Variables.AutoCorrectLens}");
        ((TextWriter) streamWriter).WriteLine($"Auto Top View: {Variables.AutoTopView}");
        ((TextWriter) streamWriter).WriteLine($"Top View Width: {Variables.TopViewWidth}");
        ((TextWriter) streamWriter).WriteLine($"Top View Height: {Variables.TopViewHeight}");
        ((TextWriter) streamWriter).WriteLine($"Marker Size: {Variables.MarkerSize}");
        ((TextWriter) streamWriter).WriteLine("Stretch Type: " + Variables.StretchType);
        ((TextWriter) streamWriter).WriteLine($"Auto Rotate Left: {Variables.AutoRotateLeft}");
        ((TextWriter) streamWriter).WriteLine($"Auto Rotate Right: {Variables.AutoRotateRight}");
        ((TextWriter) streamWriter).WriteLine($"Auto Mirror Horizontal: {Variables.AutoMirrorHorizontal}");
        ((TextWriter) streamWriter).WriteLine($"Auto Mirror Vertical: {Variables.AutoMirrorVertical}");
        ((TextWriter) streamWriter).WriteLine($"Rotation Value: {Variables.RotationValue}");
        ((TextWriter) streamWriter).WriteLine($"Distortion Strength: {Variables.DistStrK1}, {Variables.DistStrK2}");
        ((TextWriter) streamWriter).WriteLine($"Rotation First: {Variables.RotationFirst}");
        ((TextWriter) streamWriter).WriteLine($"Auto Rotation: {Variables.AutoRotation}");
        ((TextWriter) streamWriter).WriteLine($"Auto Stretch: {Variables.AutoStretch}");
        ((TextWriter) streamWriter).WriteLine($"Distortion XY: {Variables.DistX}, {Variables.DistY}");
        ((TextWriter) streamWriter).WriteLine($"Delay Time: {Variables.DelayTime}");
        ((TextWriter) streamWriter).WriteLine($"Add Offset: {Variables.addOffset}");
        ((TextWriter) streamWriter).WriteLine($"Offset Top: {Variables.offsetTop}");
        ((TextWriter) streamWriter).WriteLine($"Offset Bottom: {Variables.offsetBottom}");
        ((TextWriter) streamWriter).WriteLine($"Offset Left: {Variables.offsetLeft}");
        ((TextWriter) streamWriter).WriteLine($"Offset Right: {Variables.offsetRight}");
        ((TextWriter) streamWriter).WriteLine($"Auto Contour: {Variables.AutoContour}");
        ((TextWriter) streamWriter).WriteLine($"Auto Calculation Offset: {Variables.AutoCalcOffset}");
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing settings: " + ex.Message);
    }
  }

  private static string GetValue(string line)
  {
    int num = line.IndexOf(": ");
    if (num == -1 || num + 2 >= line.Length)
      throw new Exception("Invalid format in line: " + line);
    return line.Substring(num + 2).Trim();
  }

  private static (Decimal, Decimal) Get2Values(string line)
  {
    string[] strArray1 = line.Split(new string[1]{ ": " }, StringSplitOptions.None);
    string[] strArray2 = strArray1.Length >= 2 ? ((IEnumerable<string>) strArray1[1].Trim().Split(new char[1]
    {
      ','
    }, StringSplitOptions.RemoveEmptyEntries)).Select<string, string>((Func<string, string>) (c => c.Trim())).ToArray<string>() : throw new Exception("Invalid line format. Missing colon separator.");
    if (strArray2.Length != 2)
      throw new Exception($"Invalid coordinate format. Expected 2 values, found {strArray2.Length}.");
    Decimal result1;
    if (!Decimal.TryParse(strArray2[0], out result1))
      throw new Exception("Invalid X value: " + strArray2[0]);
    Decimal result2;
    if (!Decimal.TryParse(strArray2[1], out result2))
      throw new Exception("Invalid Y value: " + strArray2[1]);
    return (result1, result2);
  }

  public static void ReadCanonSettings(string cameraSettings)
  {
    try
    {
      string[] strArray = File.ReadAllLines(cameraSettings);
      Variables.canonTv = Variables.GetValue(strArray[0]);
      if (string.IsNullOrWhiteSpace(Variables.canonTv))
        throw new Exception("TV (Shutter speed) cannot be empty.");
      Variables.canonIso = Variables.GetValue(strArray[1]);
      if (string.IsNullOrWhiteSpace(Variables.canonIso))
        throw new Exception("ISO cannot be empty.");
      Variables.canonAv = Variables.GetValue(strArray[2]);
      if (string.IsNullOrWhiteSpace(Variables.canonAv))
        throw new Exception("AV (Aperture) cannot be empty.");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing camera settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  public static void WriteCanonSettings(string cameraSettings)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(cameraSettings))
      {
        ((TextWriter) streamWriter).WriteLine("TV: " + Variables.canonTv);
        ((TextWriter) streamWriter).WriteLine("ISO: " + Variables.canonIso);
        ((TextWriter) streamWriter).WriteLine("AV: " + Variables.canonAv);
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing settings: " + ex.Message);
    }
  }

  public static void ReadGencamSettings(string cameraSettings)
  {
    try
    {
      string[] strArray = File.ReadAllLines(cameraSettings);
      Variables.gencamExpManual = Decimal.Parse(Variables.GetValue(strArray[0]));
      Variables.gencamGain = Decimal.Parse(Variables.GetValue(strArray[1]));
      Variables.gencamExpAuto = bool.Parse(Variables.GetValue(strArray[2]));
      Variables.gencamExpLowL = Decimal.Parse(Variables.GetValue(strArray[3]));
      Variables.gencamExpUpL = Decimal.Parse(Variables.GetValue(strArray[4]));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing camera settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  public static void WriteGencamSettings(string cameraSettings)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(cameraSettings))
      {
        ((TextWriter) streamWriter).WriteLine($"Manual Exposure Time: {Variables.gencamExpManual}");
        ((TextWriter) streamWriter).WriteLine($"Gain: {Variables.gencamGain}");
        ((TextWriter) streamWriter).WriteLine($"Auto Exposure: {Variables.gencamExpAuto}");
        ((TextWriter) streamWriter).WriteLine($"Auto Exposure Lower Limit: {Variables.gencamExpLowL}");
        ((TextWriter) streamWriter).WriteLine($"Auto Exposure Upper Limit: {Variables.gencamExpUpL}");
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing settings: " + ex.Message);
    }
  }

  public static void ReadCameraSettings(string settingsFile)
  {
    switch (Variables.camModel)
    {
      case "Gencam":
        Variables.ReadGencamSettings(Path.Combine(settingsFile, "gencamSettings.txt"));
        break;
      case "Canon":
        Variables.ReadCanonSettings(Path.Combine(settingsFile, "canonSettings.txt"));
        break;
    }
  }

  public static void WriteCameraSettings(string settingsFile)
  {
    switch (Variables.camModel)
    {
      case "Gencam":
        Variables.WriteGencamSettings(Path.Combine(settingsFile, "gencamSettings.txt"));
        break;
      case "Canon":
        Variables.WriteCanonSettings(Path.Combine(settingsFile, "canonSettings.txt"));
        break;
    }
  }

  public static void LoadDragPoints()
  {
    string str = Path.Combine("C:\\Your\\Path\\Here", "dragPoints.txt");
    if (!File.Exists(str))
      return;
    try
    {
      string[] strArray1 = File.ReadAllLines(str);
      if (strArray1.Length != 4)
        return;
      Variables.dragPoints = new PointF[4];
      for (int index = 0; index < 4; ++index)
      {
        string[] strArray2 = strArray1[index].Split(',', StringSplitOptions.None);
        float x = float.Parse(strArray2[0]);
        float y = float.Parse(strArray2[1]);
        Variables.dragPoints[index] = new PointF(x, y);
      }
    }
    catch
    {
    }
  }

  public static void ReadEdgeSettings(string txtSettingsPath)
  {
    try
    {
      if (!File.Exists(txtSettingsPath))
        return;
      string[] strArray = File.ReadAllLines(txtSettingsPath);
      Variables.backHueRange = strArray.Length >= 12 ? Decimal.Parse(Variables.GetValue(strArray[0])) : throw new Exception("Settings file does not contain enough lines for detection settings.");
      Variables.backSatRange = Decimal.Parse(Variables.GetValue(strArray[1]));
      Variables.backValRange = Decimal.Parse(Variables.GetValue(strArray[2]));
      Variables.minArea = Decimal.Parse(Variables.GetValue(strArray[3]));
      Variables.contourDist = Decimal.Parse(Variables.GetValue(strArray[4]));
      Variables.contourSensitivity = Decimal.Parse(Variables.GetValue(strArray[5]));
      Variables.backColorspace = Variables.GetValue(strArray[6]);
      Variables.pointSaveMethod = Variables.GetValue(strArray[7]);
      Variables.contourShowPoints = bool.Parse(Variables.GetValue(strArray[8]));
      Variables.contourShowArea = bool.Parse(Variables.GetValue(strArray[9]));
      Variables.contourShowcase = Variables.GetValue(strArray[10]);
      Variables.contourMethod = Variables.GetValue(strArray[11]);
      Variables.contourCornerAngle = Decimal.Parse(Variables.GetValue(strArray[12]));
      Variables.contourLineFit = Decimal.Parse(Variables.GetValue(strArray[13]));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing settings variables: " + ex.Message);
    }
  }

  public static void ReadEthernetSettings(string ethernetSettingsPath)
  {
    try
    {
      if (!File.Exists(ethernetSettingsPath))
        return;
      string[] strArray = File.ReadAllLines(ethernetSettingsPath);
      Variables.EthernetName = Variables.GetValue(strArray[0]);
      Variables.EthernetPortIP = Variables.GetValue(strArray[1]);
      Variables.EthernetCameraIP = Variables.GetValue(strArray[2]);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing settings variables: " + ex.Message);
    }
  }

  public static void ReadCalibOffsetStone(string calcOffsetPath, CultureInfo culture)
  {
    try
    {
      if (!File.Exists(calcOffsetPath))
        return;
      string[] strArray = File.ReadAllLines(calcOffsetPath);
      if (strArray.Length < 3)
        return;
      Variables.StoneThickness = double.Parse(Variables.GetValue(strArray[0]), (IFormatProvider) culture);
      Variables.OffsetMpX = double.Parse(Variables.GetValue(strArray[1]), (IFormatProvider) culture);
      Variables.OffsetMpY = double.Parse(Variables.GetValue(strArray[2]), (IFormatProvider) culture);
      Variables.OffsetCenterX = double.Parse(Variables.GetValue(strArray[3]), (IFormatProvider) culture);
      Variables.OffsetCenterY = double.Parse(Variables.GetValue(strArray[4]), (IFormatProvider) culture);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing Stone Offset variables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  public static void WriteCalibOffsetStone(string calcOffsetPath, CultureInfo culture)
  {
    try
    {
      using (StreamWriter streamWriter1 = new StreamWriter(calcOffsetPath))
      {
        StreamWriter streamWriter2 = streamWriter1;
        double num = Variables.StoneThickness;
        string str1 = "Stone Thickness: " + num.ToString((IFormatProvider) culture);
        ((TextWriter) streamWriter2).WriteLine(str1);
        StreamWriter streamWriter3 = streamWriter1;
        num = Variables.OffsetMpX;
        string str2 = "Multiplier X: " + num.ToString((IFormatProvider) culture);
        ((TextWriter) streamWriter3).WriteLine(str2);
        StreamWriter streamWriter4 = streamWriter1;
        num = Variables.OffsetMpY;
        string str3 = "Multiplier Y: " + num.ToString((IFormatProvider) culture);
        ((TextWriter) streamWriter4).WriteLine(str3);
        StreamWriter streamWriter5 = streamWriter1;
        num = Variables.OffsetCenterX;
        string str4 = "Offset Center X: " + num.ToString((IFormatProvider) culture);
        ((TextWriter) streamWriter5).WriteLine(str4);
        StreamWriter streamWriter6 = streamWriter1;
        num = Variables.OffsetCenterY;
        string str5 = "Offset Center Y: " + num.ToString((IFormatProvider) culture);
        ((TextWriter) streamWriter6).WriteLine(str5);
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing Stone Offset settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }
}
