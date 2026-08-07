// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setViewportSet
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setViewportSet : buSerilization
{
  public bool ShowCoordinateSystemIcon = true;
  public bool ShowOrigineIcon = true;
  public bool ShowOrigineCaption = true;
  public bool MovePositionEnable = false;
  public Pnt3D MovePositionValue = new Pnt3D();
  public int OrigineSize = 5;
  public OriginIconType OrigineIcon = OriginIconType.Ball;
  public bool ShowCubeIcon = true;
  public bool ShowToolbar = true;
  public bool ShowGrid = false;
  public bool ZoomReverse = false;
  public bool InitViewAsTopView = false;
  public bool View2D = false;
  public bool TopMost = true;
  public bool DisableVViewportRotate = false;
  public ProjectionModeType Projection = ProjectionModeType.Perspective;
  public Color BottomColor = Color.DarkGray;
  public Color IntermediateColor = Color.White;
  public Color TopColor = Color.SlateGray;
  public DisplayModeType DisplayMode = DisplayModeType.Rendered;

  public setViewportSet()
  {
  }

  public setViewportSet(setViewportSet data)
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
