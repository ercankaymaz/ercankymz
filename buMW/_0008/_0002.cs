// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buImages;
using buMW.CamForms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u0008;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
internal class \u0002 : Attribute
{
  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_StockDef) this).PropertiesForm.Inited)
      return;
    ((F_StockDef) this).ControlUpdate();
    if (control2.Name == ((F_StockDef) this).combo_stocktype.Name)
    {
      if (((F_StockDef) this).combo_stocktype.SelectedIndex == 0)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.BoundingBoxRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 1)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.SurfacesRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 2)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentRough;
    }
    else if (control2.Name == ((\u0006.\u0001) this).combo_direction.Name)
    {
      if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 0)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 1)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 2)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 3)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 4)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.NoImage;
    }
    if (control2.Name == ((F_StockDef) this).combo_tool.Name)
    {
      if (((F_StockDef) this).combo_tool.SelectedIndex == 0)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentInsideRough;
      else if (((F_StockDef) this).combo_tool.SelectedIndex == 1)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentCenterRough;
      else if (((F_StockDef) this).combo_tool.SelectedIndex == 2)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentOutsideRough;
    }
    ((F_StockDef) this).PropertiesForm.Inited = false;
    ((F_StockDef) this).Apply();
    ((F_StockDef) this).ControlUpdate();
    ((F_StockDef) this).PropertiesForm.Inited = true;
  }
}
