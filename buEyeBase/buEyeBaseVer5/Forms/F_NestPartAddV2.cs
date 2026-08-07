// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestPartAddV2
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using ImageProcessor.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NestPartAddV2 : Form
{
  internal Label \u0007;
  internal Label \u0008;
  internal TextBox \u0001;
  internal Label \u000E;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_add;
  public Button btn_remove;
  internal NumericUpDown \u0008;
  internal Label \u000F;
  internal NumericUpDown \u000E;
  internal Label \u0010;
  internal ListBox \u0001;
  internal NumericUpDown \u000F;
  internal NumericUpDown \u0010;
  internal NumericUpDown \u0011;
  internal Label \u0011;
  internal NumericUpDown \u0012;
  internal Label \u0012;
  internal TabPage \u0005;
  internal Button \u0001;
  public Panel pnl_model;
  public static byte f000CF8;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public Design viewport;
  public List<LayerBase5> Layers;
  public buNestingResultSettings NestingResultSettings;
  public buNestingRuntime RunParameter;
  public string pathSaveImage;
  public string strSheetName;
  public bool DrawFatBorderAtPreview;
  public buNestingVar NestParameters;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_LayerConvertToTufting) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_LayerConvertToTufting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_LayerConvertToTufting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_LayerConvertToTufting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_LayerConvertToTufting.Captions.Count < 33)
        return;
      this.Text = F_LayerConvertToTufting.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void Apply()
  {
    if (((F_LayerConvertToTufting) this).\u0001.Length > 0)
      ;
    ((F_LayerConvertToTufting) this).Settings.DPI = (int) ((F_LayerTufting) this).\u0002.Value;
    ((F_LayerConvertToTufting) this).Settings.ColorToBWThreshold = (int) ((F_LayerTufting) this).\u0001.Value;
    ((F_LayerConvertToTufting) this).Settings.SplineToleranca = (double) ((F_LayerTufting) this).\u0004.Value;
    ((F_LayerConvertToTufting) this).Settings.SimplifyTolerance = (double) ((F_LayerTufting) this).\u0003.Value;
    if (((F_LayerConvertToTufting) this).\u0001 == null)
      return;
    ((F_LayerConvertToTufting) this).\u0002.Image = this.ConvertToBlackWhite(Color.White);
    ((F_LayerConvertToTufting) this).imageOutput = this.ConvertToBlackWhite(Color.White);
  }

  public Image ConvertToBlackWhite(Color BackColor)
  {
    FastBitmap blackWhite = new FastBitmap(((F_LayerConvertToTufting) this).\u0001);
    for (int x = 0; x < blackWhite.Width; ++x)
    {
      for (int y = 0; y < blackWhite.Height; ++y)
      {
        if (blackWhite.GetPixel(x, y).ToArgb() != BackColor.ToArgb())
          blackWhite.SetPixel(x, y, Color.Black);
      }
    }
    blackWhite.UnlockBitmap();
    return (Image) blackWhite;
  }

  public void GetColors(string FileName)
  {
    ((F_LayerConvertToTufting) this).\u0001.Image = Image.FromFile(FileName);
    ((F_LayerConvertToTufting) this).\u0001.Clear();
    FastBitmap fastBitmap = new FastBitmap(Image.FromFile(FileName));
    ((F_LayerTufting) this).\u0007.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0007.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0006.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0006.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0005.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0005.BorderStyle = BorderStyle.None;
    ((F_LayerConvertToTufting) this).\u0004.BackColor = Color.Gray;
    ((F_LayerConvertToTufting) this).\u0004.BorderStyle = BorderStyle.None;
    ((F_LayerConvertToTufting) this).\u0003.BackColor = Color.Gray;
    ((F_LayerConvertToTufting) this).\u0003.BorderStyle = BorderStyle.None;
    ((F_LayerConvertToTufting) this).\u0002.BackColor = Color.Gray;
    ((F_LayerConvertToTufting) this).\u0002.BorderStyle = BorderStyle.None;
    ((F_LayerConvertToTufting) this).\u0001.BackColor = Color.Gray;
    ((F_LayerConvertToTufting) this).\u0001.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0008.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0008.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0015.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0015.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0014.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0014.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0013.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0013.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0012.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0012.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0011.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0011.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u0010.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u0010.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u000F.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u000F.BorderStyle = BorderStyle.None;
    ((F_LayerTufting) this).\u000E.BackColor = Color.Gray;
    ((F_LayerTufting) this).\u000E.BorderStyle = BorderStyle.None;
    for (int x = 0; x < fastBitmap.Width; ++x)
    {
      for (int y = 0; y < fastBitmap.Height; ++y)
      {
        Color pixel = fastBitmap.GetPixel(x, y);
        if (((F_LayerConvertToTufting) this).\u0001.Count == 0)
        {
          ((F_LayerConvertToTufting) this).\u0001.Add(pixel);
        }
        else
        {
          bool flag = false;
          for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0001.Count - 1; ++index)
          {
            if (buFile5.isColorSimilar(((F_LayerConvertToTufting) this).\u0001[index], pixel, 100.0))
            {
              flag = true;
              index = ((F_LayerConvertToTufting) this).\u0001.Count;
            }
          }
          if (!flag)
            ((F_LayerConvertToTufting) this).\u0001.Add(pixel);
        }
      }
    }
    for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0001.Count - 1; ++index)
    {
      if (index == 0)
        ((F_LayerTufting) this).\u0007.BackColor = ((F_LayerConvertToTufting) this).\u0001[0];
      if (index == 1)
        ((F_LayerTufting) this).\u0006.BackColor = ((F_LayerConvertToTufting) this).\u0001[1];
      if (index == 2)
        ((F_LayerTufting) this).\u0005.BackColor = ((F_LayerConvertToTufting) this).\u0001[2];
      if (index == 3)
        ((F_LayerConvertToTufting) this).\u0004.BackColor = ((F_LayerConvertToTufting) this).\u0001[3];
      if (index == 4)
        ((F_LayerConvertToTufting) this).\u0003.BackColor = ((F_LayerConvertToTufting) this).\u0001[4];
      if (index == 5)
        ((F_LayerConvertToTufting) this).\u0002.BackColor = ((F_LayerConvertToTufting) this).\u0001[5];
      if (index == 6)
        ((F_LayerConvertToTufting) this).\u0001.BackColor = ((F_LayerConvertToTufting) this).\u0001[6];
      if (index == 7)
        ((F_LayerTufting) this).\u0008.BackColor = ((F_LayerConvertToTufting) this).\u0001[7];
      if (index == 8)
        ((F_LayerTufting) this).\u0015.BackColor = ((F_LayerConvertToTufting) this).\u0001[8];
      if (index == 9)
        ((F_LayerTufting) this).\u0014.BackColor = ((F_LayerConvertToTufting) this).\u0001[9];
      if (index == 10)
        ((F_LayerTufting) this).\u0013.BackColor = ((F_LayerConvertToTufting) this).\u0001[10];
      if (index == 11)
        ((F_LayerTufting) this).\u0012.BackColor = ((F_LayerConvertToTufting) this).\u0001[11];
      if (index == 12)
        ((F_LayerTufting) this).\u0011.BackColor = ((F_LayerConvertToTufting) this).\u0001[12];
      if (index == 13)
        ((F_LayerTufting) this).\u0010.BackColor = ((F_LayerConvertToTufting) this).\u0001[13];
      if (index == 14)
        ((F_LayerTufting) this).\u000F.BackColor = ((F_LayerConvertToTufting) this).\u0001[14];
      if (index == 15)
        ((F_LayerTufting) this).\u000E.BackColor = ((F_LayerConvertToTufting) this).\u0001[15];
    }
  }

  public void SetColor()
  {
    FastBitmap fastBitmap = new FastBitmap(Image.FromFile(((F_LayerConvertToTufting) this).\u0001));
    if (((F_LayerConvertToTufting) this).\u0002.Count > 0)
    {
      for (int x = 0; x < fastBitmap.Width; ++x)
      {
        for (int y = 0; y < fastBitmap.Height; ++y)
        {
          Color pixel = fastBitmap.GetPixel(x, y);
          bool flag = false;
          for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
          {
            if (buFile5.isColorSimilar(((F_LayerConvertToTufting) this).\u0002[index], pixel, 50.0))
            {
              flag = true;
              index = ((F_LayerConvertToTufting) this).\u0002.Count;
            }
          }
          if (!flag)
            fastBitmap.SetPixel(x, y, Color.White);
        }
      }
    }
    fastBitmap.UnlockBitmap();
    ((F_LayerConvertToTufting) this).\u0002.Image = (Image) fastBitmap;
    ((F_LayerConvertToTufting) this).\u0001 = (Image) fastBitmap;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
    {
      control = (System.Windows.Forms.Control) obj0;
      string name = control.Name;
    }
    if (obj0.GetType() == typeof (ToolStripMenuItem))
    {
      string name1 = ((ToolStripItem) obj0).Name;
    }
    if (control.Name == ((F_LayerTufting) this).\u0004.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = ((F_LayerConvertToTufting) this).pathInit;
      openFileDialog.Multiselect = false;
      openFileDialog.Filter = "All Image Files|*.bmp;*.png;*.jpg;*.jpeg;*.gif|Bmp Files (*.bmp)|*.bmp|Png Files (*.png)|*.png|Jpg Files (*.jpg)|*.jpg|Gif Files (*.gif)|*.gif";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        ((F_LayerConvertToTufting) this).\u0001 = openFileDialog.FileName;
        ((F_LayerConvertToTufting) this).pathInit = new FileInfo(openFileDialog.FileName).DirectoryName;
        this.GetColors(((F_LayerConvertToTufting) this).\u0001);
      }
    }
    if (control.Name == ((F_LayerTufting) this).\u0002.Name)
    {
      ((F_LayerConvertToTufting) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_LayerConvertToTufting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_LayerConvertToTufting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_LayerTufting) this).\u0003.Name)
      ;
    if (!(control.Name == ((F_LayerConvertToTufting) this).\u0001.Name))
      return;
    this.Apply();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_LayerTufting) this).\u0007.Name)
    {
      if (((F_LayerTufting) this).\u0007.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0007.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0007.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0007.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0007.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0007.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0006.Name)
    {
      if (((F_LayerTufting) this).\u0006.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0006.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0006.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0006.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0006.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0006.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
        }
        this.SetColor();
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0005.Name)
    {
      if (((F_LayerTufting) this).\u0005.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0005.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0005.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0005.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0005.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0005.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (control2.Name == ((F_LayerConvertToTufting) this).\u0004.Name)
    {
      if (((F_LayerConvertToTufting) this).\u0004.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerConvertToTufting) this).\u0004.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0004.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerConvertToTufting) this).\u0004.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerConvertToTufting) this).\u0004.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0004.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
        }
        this.SetColor();
      }
    }
    if (control2.Name == ((F_LayerConvertToTufting) this).\u0003.Name)
    {
      if (((F_LayerConvertToTufting) this).\u0003.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerConvertToTufting) this).\u0003.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0003.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerConvertToTufting) this).\u0003.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerConvertToTufting) this).\u0003.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0003.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (control2.Name == ((F_LayerConvertToTufting) this).\u0002.Name)
    {
      if (((F_LayerConvertToTufting) this).\u0002.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerConvertToTufting) this).\u0002.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0002.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerConvertToTufting) this).\u0002.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerConvertToTufting) this).\u0002.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0002.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
        }
        this.SetColor();
      }
    }
    if (control2.Name == ((F_LayerConvertToTufting) this).\u0001.Name)
    {
      if (((F_LayerConvertToTufting) this).\u0001.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerConvertToTufting) this).\u0001.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0001.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerConvertToTufting) this).\u0001.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerConvertToTufting) this).\u0001.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerConvertToTufting) this).\u0001.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0008.Name)
    {
      if (((F_LayerTufting) this).\u0008.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0008.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0008.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0008.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0008.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0008.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
        }
        this.SetColor();
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0015.Name)
    {
      if (((F_LayerTufting) this).\u0015.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0015.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0015.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0015.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0015.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0015.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0014.Name)
    {
      if (((F_LayerTufting) this).\u0014.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0014.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0014.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0014.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0014.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0014.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
        }
        this.SetColor();
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0013.Name)
    {
      if (((F_LayerTufting) this).\u0013.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0013.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0013.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0013.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0013.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0013.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0012.Name)
    {
      if (((F_LayerTufting) this).\u0012.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0012.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0012.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0012.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0012.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0012.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
        }
        this.SetColor();
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0011.Name)
    {
      if (((F_LayerTufting) this).\u0011.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0011.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0011.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0011.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0011.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0011.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u0010.Name)
    {
      if (((F_LayerTufting) this).\u0010.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u0010.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0010.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u0010.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u0010.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u0010.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
        }
        this.SetColor();
      }
    }
    if (control2.Name == ((F_LayerTufting) this).\u000F.Name)
    {
      if (((F_LayerTufting) this).\u000F.BorderStyle == BorderStyle.None)
      {
        bool flag = false;
        ((F_LayerTufting) this).\u000F.BorderStyle = BorderStyle.FixedSingle;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u000F.BackColor)
            flag = true;
        }
        if (!flag)
          ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u000F.BackColor);
        this.SetColor();
      }
      else
      {
        ((F_LayerTufting) this).\u000F.BorderStyle = BorderStyle.None;
        for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
        {
          if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u000F.BackColor)
          {
            ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
            index = ((F_LayerConvertToTufting) this).\u0002.Count;
          }
          this.SetColor();
        }
      }
    }
    if (!(control2.Name == ((F_LayerTufting) this).\u000E.Name))
      return;
    if (((F_LayerTufting) this).\u000E.BorderStyle == BorderStyle.None)
    {
      bool flag = false;
      ((F_LayerTufting) this).\u000E.BorderStyle = BorderStyle.FixedSingle;
      for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
      {
        if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u000E.BackColor)
          flag = true;
      }
      if (!flag)
        ((F_LayerConvertToTufting) this).\u0002.Add(((F_LayerTufting) this).\u000E.BackColor);
      this.SetColor();
    }
    else
    {
      ((F_LayerTufting) this).\u000E.BorderStyle = BorderStyle.None;
      for (int index = 0; index <= ((F_LayerConvertToTufting) this).\u0002.Count - 1; ++index)
      {
        if (((F_LayerConvertToTufting) this).\u0002[index] == ((F_LayerTufting) this).\u000E.BackColor)
        {
          ((F_LayerConvertToTufting) this).\u0002.RemoveAt(index);
          index = ((F_LayerConvertToTufting) this).\u0002.Count;
        }
      }
      this.SetColor();
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LayerConvertToTufting) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LayerConvertToTufting) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestPartAddV2() => F_LayerConvertToTufting.Captions = new List<string>();
}
