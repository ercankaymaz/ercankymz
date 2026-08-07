// Decompiled with JetBrains decompiler
// Type: buControls.Controls.ColumbProperties
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[Serializable]
public class ColumbProperties
{
  public string Name = "Columb";
  public int Width = 100;
  public bool ReadOnly = false;
  public bool Visible = true;
  public DataGridViewColumnSortMode SortType = DataGridViewColumnSortMode.NotSortable;
  public System.Type Variable;

  public ColumbProperties()
  {
  }

  public ColumbProperties(ColumbProperties data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    this.Variable = data.Variable;
  }

  public ColumbProperties(string name, int width, bool readOnly, System.Type var)
  {
    this.Name = name;
    this.Width = width;
    this.ReadOnly = readOnly;
    this.Variable = var;
  }

  public ColumbProperties(string name, int width, bool readOnly, System.Type var, bool visible)
  {
    this.Name = name;
    this.Width = width;
    this.ReadOnly = readOnly;
    this.Variable = var;
    this.Visible = visible;
  }
}
