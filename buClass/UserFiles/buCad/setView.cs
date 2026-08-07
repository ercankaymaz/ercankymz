// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setView
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setView : buSerilization
{
  public bool ShowDynamicBigCross = true;
  public bool ShowDynamicCross = true;
  public bool ShowDynamicText = true;
  public bool ShowDynamicTextCommand = true;
  public bool ShowDynamicTextInfo = true;
  public bool ShowDynamicLineArrow = true;
  public bool ShowMaterial = true;
  public double DrawMarkThickness = 2.0;
  public drawPropertiesType displayDynamicBigCrossDisplay = new drawPropertiesType(Color.LightGray, 1f, new drawingPattern());
  public drawPropertiesType displayDynamicCrossDisplay = new drawPropertiesType(Color.Red, 1f, new drawingPattern());
  public drawPropertiesType displayMarker = new drawPropertiesType(Color.Red, 1f, new drawingPattern());
  public Color colorDynamicText = Color.Red;
  public ContentAlignment DynamicTextAlignment = ContentAlignment.MiddleCenter;
  public bool ShowCommandDynamicText = true;
  public bool ShowDxDyDzValuesDynamicText = false;
  public double DynamicTextSize = 10.0;
  public bool ShowEntityPoints = true;
  public drawPropertiesType displayEntityPoints = new drawPropertiesType(Color.Red, 2f, new drawingPattern());
  public bool ShowOsnapPoints = true;
  public drawPropertiesType displayOsnapPoints = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());
  public drawPropertiesType displayOtherPoints = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());
  public Grid Grid = new Grid();
  public ProjectionModeType Projection = ProjectionModeType.Perspective;
  public DisplayModeType DisplayMode = DisplayModeType.Shaded;
  public bool SetViewUsePlane = true;
  public bool SetPlane = false;
  public bool ShowEdges = false;
  public bool CamareRotateEnable = true;
  public bool AutoPanWithMouseCursor = true;
  public double AutoPanScreenPersentage = 5.0;
  public int AutoPanAmount = 100;
  public int AutoPanRepeatTimems = 500;
  public bool ShowSelectedCamPoints = false;
  public bool SetPlaneAccordingToView = false;
  public bool AddViewButtonsToRightClickMenu = false;

  public setView()
  {
  }

  public setView(setView data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }
}
