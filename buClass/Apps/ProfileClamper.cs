// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileClamper
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class ProfileClamper : buSerilization
{
  public double XPosition = 0.0;
  public double GeometrixMaxX = 0.0;
  public double GeometrixMinX = 0.0;
  public double XOffset = 0.0;
  public double Width = 100.0;
  public string Text = "";
  public double MaxPositionRange = 10000.0;
  public double MinPositionRange = 0.0;
  public bool Used = false;
  public bool Enable = true;

  public ProfileClamper()
  {
  }

  public ProfileClamper(ProfileClamper data)
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

  public override string ToString()
  {
    return $"XPosition: {this.XPosition.ToString("f3")} , Used: {this.Used.ToString()}";
  }

  public static void Copy(List<ProfileClamper> RefClamper, ref List<ProfileClamper> CopiedClamper)
  {
    CopiedClamper.Clear();
    CopiedClamper = new List<ProfileClamper>();
    for (int index = 0; index <= RefClamper.Count - 1; ++index)
    {
      ProfileClamper CopiedClamper1 = new ProfileClamper();
      ProfileClamper.Copy(RefClamper[index], ref CopiedClamper1);
      CopiedClamper.Add(CopiedClamper1);
    }
  }

  public static void Copy(ProfileClamper RefClamper, ref ProfileClamper CopiedClamper)
  {
    CopiedClamper = new ProfileClamper(RefClamper);
  }
}
