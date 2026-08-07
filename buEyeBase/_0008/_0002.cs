// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Shape;
using devDept.Eyeshot;
using dummy_ptr;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace \u0008;

internal class \u0002
{
  public const MarbleCommandsEntity Edge = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const MarbleCommands None = ; // Unable to render the field
  public const MarbleCommands MaterialContourDefine = ; // Unable to render the field
  public const MarbleCommands SlabBorder = ; // Unable to render the field
  public const MarbleCommands DrawParts = ; // Unable to render the field
  [SpecialName]
  public int value__;

  static string \u0001([In] int obj0)
  {
    int num1 = obj0;
    byte[] numArray1 = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001;
    int index1 = num1;
    int index2 = index1 + 1;
    int num2 = (int) numArray1[index1];
    int count;
    if ((num2 & 128 /*0x80*/) == 0)
    {
      count = num2;
      if (count == 0)
        return string.Empty;
    }
    else if ((num2 & 64 /*0x40*/) == 0)
    {
      count = ((num2 & 63 /*0x3F*/) << 8) + (int) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001[index2++];
    }
    else
    {
      int num3 = (num2 & 31 /*0x1F*/) << 24;
      byte[] numArray2 = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001;
      int index3 = index2;
      int num4 = index3 + 1;
      int num5 = (int) numArray2[index3] << 16 /*0x10*/;
      int num6 = num3 + num5;
      byte[] numArray3 = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001;
      int index4 = num4;
      int num7 = index4 + 1;
      int num8 = (int) numArray3[index4] << 8;
      int num9 = num6 + num8;
      byte[] numArray4 = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001;
      int index5 = num7;
      index2 = index5 + 1;
      int num10 = (int) numArray4[index5];
      count = num9 + num10;
    }
    try
    {
      byte[] bytes = Convert.FromBase64String(Encoding.UTF8.GetString(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001, index2, count));
      string str = string.Intern(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
      if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001)
        \u0007.\u0001.\u0001(str, obj0);
      return str;
    }
    catch
    {
      return (string) null;
    }
  }

  static void \u0001([In] F_CutList obj0)
  {
    if (!((F_DrillList) obj0).PropertiesForm.Inited)
      return;
    ((F_DrillList) obj0).viewportLayout.Entities.Clear();
    ((F_DrillList) obj0).viewportLayout.SetView(viewType.Isometric, true, false);
    ((F_DrillList) obj0).viewportLayout.Invalidate();
  }

  public static class \u0001
  {
    static void \u0001([In] F_Marble3DCamStrategyMenu obj0)
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_Marble3DCamStrategyMenu));
      ((F_MarbleMaterialSize) obj0).\u0001 = new buGround();
      ((F_MarbleSweepCut) obj0).chk_rough = new buCheckBox();
      ((F_MarbleMaterialSize) obj0).btn_close = new buButton();
      ((F_MarbleMaterialSize) obj0).chk_pencil = new buCheckBox();
      ((F_MarbleMaterialSize) obj0).chk_flatlands = new buCheckBox();
      ((F_MarbleMaterialSize) obj0).chk_parallelcut = new buCheckBox();
      ((F_MarbleMaterialSize) obj0).chk_constantZ = new buCheckBox();
      ((F_MarbleSweepCut) obj0).chk_none = new buCheckBox();
      ((F_MarbleMaterialSize) obj0).\u0001.SuspendLayout();
      obj0.SuspendLayout();
      ((F_MarbleMaterialSize) obj0).\u0001.BackColor = Color.Transparent;
      ((F_MarbleMaterialSize) obj0).\u0001.Controls.Add((Control) ((F_MarbleSweepCut) obj0).chk_none);
      ((F_MarbleMaterialSize) obj0).\u0001.Controls.Add((Control) ((F_MarbleSweepCut) obj0).chk_rough);
      ((F_MarbleMaterialSize) obj0).\u0001.Controls.Add((Control) ((F_MarbleMaterialSize) obj0).btn_close);
      ((F_MarbleMaterialSize) obj0).\u0001.Controls.Add((Control) ((F_MarbleMaterialSize) obj0).chk_pencil);
      ((F_MarbleMaterialSize) obj0).\u0001.Controls.Add((Control) ((F_MarbleMaterialSize) obj0).chk_flatlands);
      ((F_MarbleMaterialSize) obj0).\u0001.Controls.Add((Control) ((F_MarbleMaterialSize) obj0).chk_parallelcut);
      ((F_MarbleMaterialSize) obj0).\u0001.Controls.Add((Control) ((F_MarbleMaterialSize) obj0).chk_constantZ);
      ((F_MarbleMaterialSize) obj0).\u0001.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).\u0001.Display.GradientType = GradientMode.Lineer;
      ((F_MarbleMaterialSize) obj0).\u0001.Display.LineerGradient.FirstColor = Color.Black;
      ((F_MarbleMaterialSize) obj0).\u0001.DisplayBottom.BackColor = Color.Gray;
      ((F_MarbleMaterialSize) obj0).\u0001.DisplayTop.BackColor = Color.LightBlue;
      ((F_MarbleMaterialSize) obj0).\u0001.DisplayTop.Fonts.Alignment = ContentAlignment.MiddleLeft;
      ((F_MarbleMaterialSize) obj0).\u0001.Dock = DockStyle.Fill;
      ((F_MarbleMaterialSize) obj0).\u0001.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).\u0001.Ground.TopHeight = 50;
      ((F_MarbleMaterialSize) obj0).\u0001.Image = (Image) null;
      ((F_MarbleMaterialSize) obj0).\u0001.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_MarbleMaterialSize) obj0).\u0001.Location = new Point(0, 0);
      ((F_MarbleMaterialSize) obj0).\u0001.Name = "buGround1";
      ((F_MarbleMaterialSize) obj0).\u0001.Sizable = true;
      ((F_MarbleMaterialSize) obj0).\u0001.Size = new Size(270, 443);
      ((F_MarbleMaterialSize) obj0).\u0001.SmartBounds = true;
      ((F_MarbleMaterialSize) obj0).\u0001.StartPosition = FormStartPosition.Manual;
      ((F_MarbleMaterialSize) obj0).\u0001.TabIndex = 0;
      ((F_MarbleMaterialSize) obj0).\u0001.Text = "  3D Milling Strategy";
      ((F_MarbleSweepCut) obj0).chk_rough.CheckTick.ColorModeDisplay.BackColor = Color.Green;
      ((F_MarbleSweepCut) obj0).chk_rough.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
      ((F_MarbleSweepCut) obj0).chk_rough.Display.BackColor = Color.DarkGray;
      ((F_MarbleSweepCut) obj0).chk_rough.Display.Fonts.Alignment = ContentAlignment.MiddleLeft;
      ((F_MarbleSweepCut) obj0).chk_rough.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleSweepCut) obj0).chk_rough.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleSweepCut) obj0).chk_rough.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleSweepCut) obj0).chk_rough.Image = (Image) componentResourceManager.GetObject("chk_rough.Image");
      ((F_MarbleSweepCut) obj0).chk_rough.ImageAlign = ContentAlignment.MiddleRight;
      ((F_MarbleSweepCut) obj0).chk_rough.Location = new Point(7, 53);
      ((F_MarbleSweepCut) obj0).chk_rough.Name = "chk_rough";
      ((F_MarbleSweepCut) obj0).chk_rough.Size = new Size((int) byte.MaxValue, 49);
      ((F_MarbleSweepCut) obj0).chk_rough.TabIndex = 232;
      ((F_MarbleSweepCut) obj0).chk_rough.Text = "Rough";
      ((F_MarbleSweepCut) obj0).chk_rough.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(((F_MarbleTextMenu) obj0).\u0001);
      ((F_MarbleMaterialSize) obj0).btn_close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((F_MarbleMaterialSize) obj0).btn_close.BackColor = Color.LightBlue;
      ((F_MarbleMaterialSize) obj0).btn_close.ButtonCopy = false;
      ((F_MarbleMaterialSize) obj0).btn_close.ButtonDownDisplay.BackColor = Color.Silver;
      ((F_MarbleMaterialSize) obj0).btn_close.ButtonOverDisplay.BackColor = Color.Gray;
      ((F_MarbleMaterialSize) obj0).btn_close.Display.BackColor = Color.LightBlue;
      ((F_MarbleMaterialSize) obj0).btn_close.Display.Border.Color = Color.Black;
      ((F_MarbleMaterialSize) obj0).btn_close.Display.Border.Visible = false;
      ((F_MarbleMaterialSize) obj0).btn_close.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).btn_close.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).btn_close.Image = (Image) componentResourceManager.GetObject("btn_close.Image");
      ((F_MarbleMaterialSize) obj0).btn_close.Location = new Point(218, 2);
      ((F_MarbleMaterialSize) obj0).btn_close.Margin = new Padding(4);
      ((F_MarbleMaterialSize) obj0).btn_close.Name = "btn_close";
      ((F_MarbleMaterialSize) obj0).btn_close.Size = new Size(54, 47);
      ((F_MarbleMaterialSize) obj0).btn_close.TabIndex = 221;
      ((F_MarbleMaterialSize) obj0).btn_close.UseMnemonic = false;
      ((F_MarbleMaterialSize) obj0).btn_close.Click += new EventHandler(((F_MarbleTextMenu) obj0).\u0001);
      ((F_MarbleMaterialSize) obj0).chk_pencil.CheckTick.ColorModeDisplay.BackColor = Color.Green;
      ((F_MarbleMaterialSize) obj0).chk_pencil.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
      ((F_MarbleMaterialSize) obj0).chk_pencil.Display.BackColor = Color.DarkGray;
      ((F_MarbleMaterialSize) obj0).chk_pencil.Display.Fonts.Alignment = ContentAlignment.MiddleLeft;
      ((F_MarbleMaterialSize) obj0).chk_pencil.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleMaterialSize) obj0).chk_pencil.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).chk_pencil.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleMaterialSize) obj0).chk_pencil.Image = (Image) componentResourceManager.GetObject("chk_pencil.Image");
      ((F_MarbleMaterialSize) obj0).chk_pencil.ImageAlign = ContentAlignment.MiddleRight;
      ((F_MarbleMaterialSize) obj0).chk_pencil.Location = new Point(7, 309);
      ((F_MarbleMaterialSize) obj0).chk_pencil.Name = "chk_pencil";
      ((F_MarbleMaterialSize) obj0).chk_pencil.Size = new Size((int) byte.MaxValue, 59);
      ((F_MarbleMaterialSize) obj0).chk_pencil.TabIndex = 227;
      ((F_MarbleMaterialSize) obj0).chk_pencil.Text = "Pencil";
      ((F_MarbleMaterialSize) obj0).chk_pencil.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(((F_MarbleTextMenu) obj0).\u0001);
      ((F_MarbleMaterialSize) obj0).chk_flatlands.CheckTick.ColorModeDisplay.BackColor = Color.Green;
      ((F_MarbleMaterialSize) obj0).chk_flatlands.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Display.BackColor = Color.DarkGray;
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Display.Fonts.Alignment = ContentAlignment.MiddleLeft;
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Image = (Image) componentResourceManager.GetObject("chk_flatlands.Image");
      ((F_MarbleMaterialSize) obj0).chk_flatlands.ImageAlign = ContentAlignment.MiddleRight;
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Location = new Point(7, 243);
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Name = "chk_flatlands";
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Size = new Size((int) byte.MaxValue, 59);
      ((F_MarbleMaterialSize) obj0).chk_flatlands.TabIndex = 226;
      ((F_MarbleMaterialSize) obj0).chk_flatlands.Text = "Flatlands";
      ((F_MarbleMaterialSize) obj0).chk_flatlands.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(((F_MarbleTextMenu) obj0).\u0001);
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.CheckTick.ColorModeDisplay.BackColor = Color.Green;
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Display.BackColor = Color.DarkGray;
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Display.Fonts.Alignment = ContentAlignment.MiddleLeft;
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Image = (Image) componentResourceManager.GetObject("chk_parallelcut.Image");
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.ImageAlign = ContentAlignment.MiddleRight;
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Location = new Point(7, 111);
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Name = "chk_parallelcut";
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Size = new Size((int) byte.MaxValue, 59);
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.TabIndex = 223;
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.Text = "Parallel Cut";
      ((F_MarbleMaterialSize) obj0).chk_parallelcut.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(((F_MarbleTextMenu) obj0).\u0001);
      ((F_MarbleMaterialSize) obj0).chk_constantZ.CheckTick.ColorModeDisplay.BackColor = Color.Green;
      ((F_MarbleMaterialSize) obj0).chk_constantZ.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Display.BackColor = Color.DarkGray;
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Display.Fonts.Alignment = ContentAlignment.MiddleLeft;
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Image = (Image) componentResourceManager.GetObject("chk_constantZ.Image");
      ((F_MarbleMaterialSize) obj0).chk_constantZ.ImageAlign = ContentAlignment.MiddleRight;
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Location = new Point(7, 177);
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Name = "chk_constantZ";
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Size = new Size((int) byte.MaxValue, 59);
      ((F_MarbleMaterialSize) obj0).chk_constantZ.TabIndex = 224 /*0xE0*/;
      ((F_MarbleMaterialSize) obj0).chk_constantZ.Text = "Constant Z";
      ((F_MarbleMaterialSize) obj0).chk_constantZ.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(((F_MarbleTextMenu) obj0).\u0001);
      ((F_MarbleSweepCut) obj0).chk_none.CheckTick.ColorModeDisplay.BackColor = Color.Green;
      ((F_MarbleSweepCut) obj0).chk_none.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
      ((F_MarbleSweepCut) obj0).chk_none.Display.BackColor = Color.DarkGray;
      ((F_MarbleSweepCut) obj0).chk_none.Display.Fonts.Alignment = ContentAlignment.MiddleLeft;
      ((F_MarbleSweepCut) obj0).chk_none.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleSweepCut) obj0).chk_none.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleSweepCut) obj0).chk_none.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleSweepCut) obj0).chk_none.Image = (Image) componentResourceManager.GetObject("chk_none.Image");
      ((F_MarbleSweepCut) obj0).chk_none.ImageAlign = ContentAlignment.MiddleRight;
      ((F_MarbleSweepCut) obj0).chk_none.Location = new Point(7, 376);
      ((F_MarbleSweepCut) obj0).chk_none.Name = "chk_none";
      ((F_MarbleSweepCut) obj0).chk_none.Size = new Size((int) byte.MaxValue, 59);
      ((F_MarbleSweepCut) obj0).chk_none.TabIndex = 233;
      ((F_MarbleSweepCut) obj0).chk_none.Text = "None";
      ((F_MarbleSweepCut) obj0).chk_none.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(((F_MarbleTextMenu) obj0).\u0001);
      obj0.AutoScaleMode = AutoScaleMode.None;
      obj0.ClientSize = new Size(270, 443);
      obj0.Controls.Add((Control) ((F_MarbleMaterialSize) obj0).\u0001);
      obj0.FormBorderStyle = FormBorderStyle.None;
      obj0.Name = "F_Marble3DCamStrategyMenu";
      obj0.Text = "Cam Parameters";
      obj0.FormClosing += new FormClosingEventHandler(((F_MarbleTextMenu) obj0).\u0001);
      ((F_MarbleMaterialSize) obj0).\u0001.ResumeLayout(false);
      obj0.ResumeLayout(false);
    }
  }
}
