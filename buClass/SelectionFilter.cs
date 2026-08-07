// Decompiled with JetBrains decompiler
// Type: buClass.SelectionFilter
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SelectionFilter : buSerilization
{
  public bool Solid = true;
  public bool Wireframe = true;
  public bool Cam = false;
  public bool Text = true;
  public bool Image = true;
  public string MatchTag = "";

  public SelectionFilter()
  {
  }

  public SelectionFilter(bool solid, bool wireframe, bool cam, bool image, bool text)
  {
    this.Cam = cam;
    this.Solid = solid;
    this.Wireframe = wireframe;
    this.Image = image;
    this.Text = text;
  }

  public SelectionFilter(SelectedEntities data)
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
