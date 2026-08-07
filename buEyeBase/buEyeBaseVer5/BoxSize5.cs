// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.BoxSize5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Globalization;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class BoxSize5 : buSerilization5
{
  public double SurfaceNormalLength;
  public double LeadInDistance;
  public double SafeDistance;
  public double ToolOffset;

  public static Pnt6DSimMove DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt6DSimMove pnt6DsimMove = (Pnt6DSimMove) new AlingmentPoints3D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("A:", "");
      Value = Value.Replace("B:", "");
      Value = Value.Replace("C:", "");
      Value = Value.Replace("F:", "");
      Value = Value.Replace("S:", "");
      Value = Value.Replace("T:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = double.Parse(strArray[2], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = double.Parse(strArray[2], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).A = double.Parse(strArray[3], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length >= 6)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = double.Parse(strArray[2], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).A = double.Parse(strArray[3], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).B = double.Parse(strArray[4], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      if (strArray.Length >= 7)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = double.Parse(strArray[2], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).A = double.Parse(strArray[3], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).B = double.Parse(strArray[4], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).C = double.Parse(strArray[5], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).FeedRate = double.Parse(strArray[6], (IFormatProvider) provider);
      }
      if (strArray.Length >= 8)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = double.Parse(strArray[2], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).A = double.Parse(strArray[3], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).B = double.Parse(strArray[4], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).C = double.Parse(strArray[5], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).FeedRate = double.Parse(strArray[6], (IFormatProvider) provider);
        ((MeshToSurfacePointsCalculations) pnt6DsimMove).SpindleRpm = double.Parse(strArray[7], (IFormatProvider) provider);
      }
      if (strArray.Length >= 9)
      {
        ((MeshToSurfacePointsSettings) pnt6DsimMove).X = double.Parse(strArray[0], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Y = double.Parse(strArray[1], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).Z = double.Parse(strArray[2], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).A = double.Parse(strArray[3], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).B = double.Parse(strArray[4], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).C = double.Parse(strArray[5], (IFormatProvider) provider);
        ((MeshToSurfacePointsSettings) pnt6DsimMove).FeedRate = double.Parse(strArray[6], (IFormatProvider) provider);
        ((MeshToSurfacePointsCalculations) pnt6DsimMove).SpindleRpm = double.Parse(strArray[7], (IFormatProvider) provider);
        ((MeshToSurfacePointsCalculations) pnt6DsimMove).ToolNo = double.Parse(strArray[8], (IFormatProvider) provider);
      }
      return pnt6DsimMove;
    }
    catch (Exception ex)
    {
      return (Pnt6DSimMove) new AlingmentPoints3D();
    }
  }

  public string ToDef()
  {
    return $"X:{((MeshToSurfacePointsSettings) this).X.ToString()}; Y:{((MeshToSurfacePointsSettings) this).Y.ToString()}; Z:{((MeshToSurfacePointsSettings) this).Z.ToString()}; A:{((MeshToSurfacePointsSettings) this).A.ToString()}; B:{((MeshToSurfacePointsSettings) this).B.ToString()}; C:{((MeshToSurfacePointsSettings) this).C.ToString()}; F:{((MeshToSurfacePointsSettings) this).FeedRate.ToString()}; S:{((MeshToSurfacePointsCalculations) this).SpindleRpm.ToString()}; T:{((MeshToSurfacePointsCalculations) this).ToolNo.ToString()}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{((MeshToSurfacePointsSettings) this).X.ToString()}; Y:{((MeshToSurfacePointsSettings) this).Y.ToString()}; Z:{((MeshToSurfacePointsSettings) this).Z.ToString()}; A:{((MeshToSurfacePointsSettings) this).A.ToString()}; B:{((MeshToSurfacePointsSettings) this).B.ToString()}; C:{((MeshToSurfacePointsSettings) this).C.ToString()}; F:{((MeshToSurfacePointsSettings) this).FeedRate.ToString()}; S:{((MeshToSurfacePointsCalculations) this).SpindleRpm.ToString()}; T:{((MeshToSurfacePointsCalculations) this).ToolNo.ToString()}";
  }

  public abstract void m00027A();
}
