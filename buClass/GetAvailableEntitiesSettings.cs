// Decompiled with JetBrains decompiler
// Type: buClass.GetAvailableEntitiesSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

public class GetAvailableEntitiesSettings : buSerilization
{
  public List<string> EntitiesNotAddName = new List<string>();
  public List<string> LayerNameNotAdd = new List<string>();
  public List<Color> ColorsNotAdd = new List<Color>();
  public List<int> EntitiesNotAddIndex = new List<int>();
  public bool VisibleEntity = true;
  public bool AddTextEntities = false;
  public bool AddICurveEntities = true;

  public GetAvailableEntitiesSettings()
  {
  }

  public GetAvailableEntitiesSettings(GetAvailableEntitiesSettings data)
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
    this.ColorsNotAdd.Clear();
    for (int index = 0; index <= data.ColorsNotAdd.Count - 1; ++index)
    {
      List<Color> colorsNotAdd = this.ColorsNotAdd;
      Color color1 = data.ColorsNotAdd[index];
      int a = (int) color1.A;
      color1 = data.ColorsNotAdd[index];
      int r = (int) color1.R;
      color1 = data.ColorsNotAdd[index];
      int g = (int) color1.G;
      color1 = data.ColorsNotAdd[index];
      int b = (int) color1.B;
      Color color2 = Color.FromArgb(a, r, g, b);
      colorsNotAdd.Add(color2);
    }
  }
}
