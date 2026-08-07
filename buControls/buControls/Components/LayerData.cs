// Decompiled with JetBrains decompiler
// Type: buControls.Components.LayerData
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buControls.Components;

public class LayerData
{
  public string Name = "";
  public bool Lock = false;
  public bool Visible = true;
  public Color color = Color.Blue;

  public LayerData()
  {
  }

  public LayerData(string name, bool locked, bool visible, Color clr)
  {
    this.Name = name;
    this.Lock = locked;
    this.Visible = visible;
    this.color = clr;
  }
}
