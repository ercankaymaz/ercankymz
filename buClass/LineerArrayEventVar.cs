// Decompiled with JetBrains decompiler
// Type: buClass.LineerArrayEventVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LineerArrayEventVar : buSerilization
{
  public int ColomnsCountX = 2;
  public double ColomnsDistanceX = 10.0;
  public int RowsCountY = 2;
  public double RowDistanceY = 10.0;
  public int LevelCountZ = 1;
  public double LevelDistanceZ = 10.0;
  public bool MoveByMouse = false;
  public ContentAlignment Alingement = ContentAlignment.BottomLeft;
  public static List<string> Captions = new List<string>();

  public LineerArrayEventVar()
  {
  }

  public LineerArrayEventVar(LineerArrayEventVar data)
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
