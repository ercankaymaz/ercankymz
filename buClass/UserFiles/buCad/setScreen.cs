// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setScreen
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setScreen : buSerilization
{
  public bool ShowCoordinateSystemIcon = true;
  public bool ShowOrigineIcon = true;
  public bool ShowOrigineCaption = true;
  public int OrigineSize = 5;
  public OriginIconType OrigineIcon = OriginIconType.Ball;
  public bool ShowCubeIcon = true;
  public bool ShowToolbar = true;

  public setScreen()
  {
  }

  public setScreen(setScreen data)
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
