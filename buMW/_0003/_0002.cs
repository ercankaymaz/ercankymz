// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buControls.Forms.WinControlForms.Views;
using buImages;
using buMW.CamForms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u0003;

internal class \u0002
{
  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_StockDef) this).combo_stocktype.Name)
    {
      if (((F_StockDef) this).combo_stocktype.SelectedIndex == 0)
      {
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.BoundingBoxRough;
        if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 1)
      {
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.SurfacesRough;
        if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 2)
      {
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentRough;
        if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_StockDef) this).\u0003.Name)
      ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.ToleranceRough;
    else if (control2.Name == ((F_StockDef) this).\u0002.Name)
    {
      if (((F_StockDef) this).combo_stocktype.SelectedIndex == 0)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.BoundingBoxShrinkRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 1)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.SurfacesShrinkRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 2)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentShrinkRough;
    }
    else if (control2.Name == ((F_StockDef) this).\u0001.Name)
    {
      if (((F_StockDef) this).combo_stocktype.SelectedIndex == 0)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.BoundingBoxExpandRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 1)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.SurfacesExpandRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 2)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentExpandRough;
    }
    else if (control2.Name == ((F_StockDef) this).\u0002.Name)
    {
      if (((F_StockDef) this).combo_stocktype.SelectedIndex == 0)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.BoundingBoxShrinkRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 1)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.SurfacesShrinkRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 2)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentShrinkRough;
    }
    else if (control2.Name == ((F_StockDef) this).\u0001.Name)
    {
      if (((F_StockDef) this).combo_stocktype.SelectedIndex == 0)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.BoundingBoxExpandRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 1)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.SurfacesExpandRough;
      else if (((F_StockDef) this).combo_stocktype.SelectedIndex == 2)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentExpandRough;
    }
    else if (control2.Name == ((\u0006.\u0001) this).\u0002.Name)
    {
      ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentDefaultRough;
      if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == ((\u0008.\u0001) this).\u0004.Name)
      {
        if (((F_StockDef) this).combo_tool.SelectedIndex == 0)
        {
          ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentOffsetInsideRough;
          if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
          {
            F_GifView fGifView = new F_GifView();
            fGifView.Init();
            fGifView.StartPosition = FormStartPosition.CenterParent;
            int num = (int) fGifView.ShowDialog();
          }
        }
        else if (((F_StockDef) this).combo_tool.SelectedIndex == 1)
        {
          ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentCenterRough;
          if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
          {
            F_GifView fGifView = new F_GifView();
            fGifView.Init();
            fGifView.StartPosition = FormStartPosition.CenterParent;
            int num = (int) fGifView.ShowDialog();
          }
        }
        else if (((F_StockDef) this).combo_tool.SelectedIndex == 2)
        {
          ((F_StockDef) this).\u0001.Image = (Image) ResourceImage._2DContainmentOffsetOutsideRough;
          if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
          {
            F_GifView fGifView = new F_GifView();
            fGifView.Init();
            fGifView.StartPosition = FormStartPosition.CenterParent;
            int num = (int) fGifView.ShowDialog();
          }
        }
      }
      else if (control2.Name == ((\u0006.\u0001.\u0001) this).chk_stovkhasundercut.Name)
      {
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.NoImage;
        if (((\u0006.\u0001.\u0001) this).\u0003.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (control2.Name == ((F_StockDef) this).\u0001.Name)
        ((F_StockDef) this).\u0001.Image = (Image) ResourceImage.NoImage;
    }
    ((\u0006.\u0001.\u0001) this).\u0003.Checked = false;
  }
}
