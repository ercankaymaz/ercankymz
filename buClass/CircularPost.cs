// Decompiled with JetBrains decompiler
// Type: buClass.CircularPost
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CircularPost : buSerilization
{
  public CircularPostType Type = CircularPostType.Arc;
  public CircularMode Mode = CircularMode.R;
  public CircularIJKMode IJKMode = CircularIJKMode.Center;
  public double DevideLength = 0.1;

  public CircularPost()
  {
  }

  public CircularPost(CircularPost data)
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

  public CircularPost(CircularPostType type, double devidelen)
  {
    this.Type = type;
    this.DevideLength = devidelen;
  }
}
