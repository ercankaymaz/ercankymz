// Decompiled with JetBrains decompiler
// Type: buControls.Components.buLayerList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Components;

public class buLayerList : UserControl
{
  public List<LayerData> LayerList = new List<LayerData>();
  public int SelectedLayer = -1;
  public Color colorUnSelected = Color.Silver;
  public Color colorSelected = Color.LightSkyBlue;
  public int LayetItemHeight = 25;
  private IContainer icontainer_0 = (IContainer) null;

  public event buControlEvents.buLayerChangedEventHandler LayerChanged;

  public event buControlEvents.buLayerDoubleClickEventHandler LayerDoubleClick;

  public buLayerList() => Class39.smethod_429(this);

  public void Add(LayerData layer, bool Draw = true)
  {
    this.LayerList.Add(layer);
    if (!Draw)
      return;
    Class39.smethod_836(this);
  }

  public void RemoveAll()
  {
    this.LayerList.Clear();
    Class39.smethod_836(this);
  }

  public void Remove(int index)
  {
    if (!(index >= 0 & index <= this.LayerList.Count - 1))
      return;
    this.LayerList.RemoveAt(index);
    Class39.smethod_836(this);
  }

  public void SetLayer(int Index)
  {
    if (!(Index >= 0 & Index <= this.LayerList.Count - 1))
      return;
    this.SelectedLayer = Index;
    Class39.smethod_836(this);
  }

  public void SetLayer(string Name)
  {
    for (int index = 0; index <= this.LayerList.Count - 1; ++index)
    {
      if (Name == this.LayerList[index].Name)
      {
        this.SelectedLayer = index;
        Class39.smethod_836(this);
        break;
      }
    }
  }

  public void DrawControls() => Class39.smethod_836(this);

  internal void method_0(
    object object_0,
    Color color_0,
    bool bool_0,
    bool bool_1,
    string string_0,
    int int_0)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.buLayerChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buLayerChangedEventHandler_0(object_0, color_0, bool_0, bool_1, string_0, int_0);
    this.SelectedLayer = int_0;
    for (int index = 0; index <= this.Controls.Count - 1; ++index)
    {
      this.Controls[index].BackColor = this.colorUnSelected;
      if (index == this.SelectedLayer)
        this.Controls[index].BackColor = this.colorSelected;
    }
  }

  internal void method_1(
    object object_0,
    Color color_0,
    bool bool_0,
    bool bool_1,
    string string_0,
    int int_0)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.buLayerDoubleClickEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buLayerDoubleClickEventHandler_0(object_0, color_0, bool_0, bool_1, string_0, int_0);
  }

  internal void method_2(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
