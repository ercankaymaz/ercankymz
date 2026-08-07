// Decompiled with JetBrains decompiler
// Type: buClass.Apps.XRayData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass.Apps;

public class XRayData : buSerilization
{
  public double Kv = 100.0;
  public double Ma = 5.0;
  public double Time = 100.0;
  public double Frames = 64.0;
  public double Rot = 0.0;
  public double FlipH = 0.0;
  public double FlipV = 0.0;
  public double GreyC = 0.0;
  public double GreyW = 0.0;
  public double Left = 35.0;
  public double Top = 35.0;
  public double Right = 35.0;
  public double Bottom = 35.0;
  public double GrayAuto = 2.0;
  public bool XRay = false;
  public bool Image = false;
  public bool Video = false;
  public XRayFocus Focus = XRayFocus.Small;
  public double Radius = 0.0;
  public ClockDirectionType ArcDirection = ClockDirectionType.CW;
  public double FeedVel = 2000.0;

  public XRayData()
  {
  }

  public XRayData(XRayData data)
  {
    this.Bottom = data.Bottom;
    this.FlipH = data.FlipH;
    this.FlipV = data.FlipV;
    this.Focus = data.Focus;
    this.Frames = data.Frames;
    this.GreyC = data.GreyC;
    this.GreyW = data.GreyW;
    this.Image = data.Image;
    this.Kv = data.Kv;
    this.Left = data.Left;
    this.Ma = data.Ma;
    this.Right = data.Right;
    this.Rot = data.Rot;
    this.Time = data.Time;
    this.Top = data.Top;
    this.Video = data.Video;
    this.XRay = data.XRay;
    this.Radius = data.Radius;
    this.FeedVel = data.FeedVel;
  }

  public override string ToString() => $"Kv = {this.Kv.ToString()} , Ma : {this.Ma.ToString()}";
}
