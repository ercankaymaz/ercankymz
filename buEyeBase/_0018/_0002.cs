// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Controls;
using buEyeBaseVer5.Forms.Customer.DincMak;
using buEyeBaseVer5.Forms.Door;
using buEyeBaseVer5.Forms.Layer;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u0018;

internal static class \u0002
{
  internal sealed class \u0001
  {
    public const MarbleCountertopCornerTypes Radius = ; // Unable to render the field
    [SpecialName]
    public int value__;
    public const MarbleCountertopInsideTypes Rectangle = ; // Unable to render the field
    public const MarbleCountertopInsideTypes Circular = ; // Unable to render the field
    public const MarbleCountertopInsideTypes Free = ; // Unable to render the field
    [SpecialName]
    public int value__;
    public const MarbleOsnapCalcType FromOffsetValue = ; // Unable to render the field
    public const MarbleOsnapCalcType OffsetFromToolGeometry = ; // Unable to render the field
    [SpecialName]
    public int value__;
    public const MarbleCountertopCommands None = ; // Unable to render the field
    public const MarbleCountertopCommands SinkShapeChanged = ; // Unable to render the field
    public const MarbleCountertopCommands BuiltInShapeChanged = ; // Unable to render the field
    public const MarbleCountertopCommands SocketShapeChanged = ; // Unable to render the field
    public const MarbleCountertopCommands DataChanged = ; // Unable to render the field
    public const MarbleCountertopCommands FirstRun = ; // Unable to render the field

    static void \u0001([In] F_MarbleContour obj0)
    {
      // ISSUE: unable to decompile the method.
    }

    static void \u0001([In] F_ProfilePatternCopy obj0)
    {
      ((F_ProfileAdd) obj0).\u0001 = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_ProfilePatternCopy));
      ((F_ProfileAdd) obj0).label4 = new Label();
      ((F_ProfileAdd) obj0).label5 = new Label();
      ((F_ProfileAdd) obj0).spn_distance = new NumericUpDown();
      ((F_ProfileAdd) obj0).spn_count = new NumericUpDown();
      ((F_ProfileAdd) obj0).\u0001 = new ImageList(((F_ProfileAdd) obj0).\u0001);
      ((F_ProfileAdd) obj0).btn_cancel = new Button();
      ((F_ProfileAdd) obj0).btn_ok = new Button();
      ((F_ProfileAdd) obj0).label1 = new Label();
      ((F_ProfileAdd) obj0).spn_cutspace = new NumericUpDown();
      ((F_ProfileAdd) obj0).label2 = new Label();
      ((F_ProfileAdd) obj0).\u0001 = new CheckBox();
      ((F_ProfileAdd) obj0).spn_distance.BeginInit();
      ((F_ProfileAdd) obj0).spn_count.BeginInit();
      ((F_ProfileAdd) obj0).spn_cutspace.BeginInit();
      obj0.SuspendLayout();
      ((F_ProfileAdd) obj0).label4.AutoSize = true;
      ((F_ProfileAdd) obj0).label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_ProfileAdd) obj0).label4.Location = new System.Drawing.Point(5, 9);
      ((F_ProfileAdd) obj0).label4.Name = "label4";
      ((F_ProfileAdd) obj0).label4.Size = new Size(74, 18);
      ((F_ProfileAdd) obj0).label4.TabIndex = 2;
      ((F_ProfileAdd) obj0).label4.Text = "Distance";
      ((F_ProfileAdd) obj0).label5.AutoSize = true;
      ((F_ProfileAdd) obj0).label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_ProfileAdd) obj0).label5.Location = new System.Drawing.Point(5, 44);
      ((F_ProfileAdd) obj0).label5.Name = "label5";
      ((F_ProfileAdd) obj0).label5.Size = new Size(53, 18);
      ((F_ProfileAdd) obj0).label5.TabIndex = 0;
      ((F_ProfileAdd) obj0).label5.Text = "Count";
      ((F_ProfileAdd) obj0).spn_distance.DecimalPlaces = 2;
      ((F_ProfileAdd) obj0).spn_distance.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_ProfileAdd) obj0).spn_distance.Location = new System.Drawing.Point(173, 9);
      ((F_ProfileAdd) obj0).spn_distance.Maximum = new Decimal(new int[4]
      {
        100000000,
        0,
        0,
        0
      });
      ((F_ProfileAdd) obj0).spn_distance.Name = "spn_distance";
      ((F_ProfileAdd) obj0).spn_distance.Size = new Size(90, 24);
      ((F_ProfileAdd) obj0).spn_distance.TabIndex = 1;
      ((F_ProfileAdd) obj0).spn_distance.Tag = (object) "3";
      ((F_ProfileAdd) obj0).spn_count.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_ProfileAdd) obj0).spn_count.Location = new System.Drawing.Point(173, 44);
      ((F_ProfileAdd) obj0).spn_count.Maximum = new Decimal(new int[4]
      {
        100000000,
        0,
        0,
        0
      });
      ((F_ProfileAdd) obj0).spn_count.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      ((F_ProfileAdd) obj0).spn_count.Name = "spn_count";
      ((F_ProfileAdd) obj0).spn_count.Size = new Size(90, 24);
      ((F_ProfileAdd) obj0).spn_count.TabIndex = 1;
      ((F_ProfileAdd) obj0).spn_count.Tag = (object) "3";
      ((F_ProfileAdd) obj0).spn_count.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      ((F_ProfileAdd) obj0).\u0001.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC32.ImageStream");
      ((F_ProfileAdd) obj0).\u0001.TransparentColor = Color.Transparent;
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(0, "zDown.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(1, "Speed.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(2, "LeadIn.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(3, "offset.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(4, "Other.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(5, "cancel.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(6, "ok.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(7, "DimensionVertical.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(8, "1492561718_icon-arrow-up-c - Kopya (3).ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(9, "1492561718_icon-arrow-up-c.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(10, "LeadOut.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(11, "Tool5.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(12, "process1.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(13, "Barel.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(14, "Circle.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(15, "Ellipse.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(16 /*0x10*/, "Rectangle.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(17, "RectangleRound.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(18, "CircleDiameter.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(19, "Depth.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(20, "BarelDiameter.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(21, "BarelLength.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(22, "BarelWidth.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(23, "EllipeAngle.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(24, "EllipseHeight.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(25, "EllipseWidth.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(26, "RectangleAngle.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(27, "RectangleHeight.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(28, "RectangleRoundAngle.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(29, "RectangleRoundHeight.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(30, "RectangleRoundWidth.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(31 /*0x1F*/, "RectangleWidth.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(32 /*0x20*/, "RectangleRoundRadius.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(33, "BarelAngle.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(34, "CircleCenter.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(35, "Kertme.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(36, "KertmeDepth.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(37, "KertmeHeight.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(38, "KertmeWidth.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(39, "SawThicknessPersentage.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(40, "LineerArray.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(41, "PlaneABC.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(42, "KertmeDepth2.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(43, "KertmeHeight2.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(44, "KertmeWidth2.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(45, "KertmeStart.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(46, "text.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(47, "Text2.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(48 /*0x30*/, "BottomView.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(49, "FrontView.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(50, "LeftView.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(51, "RigthView.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(52, "TopView.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(53, "copy2.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(54, "Mirror.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(55, "polararray2.ico");
      ((F_ProfileAdd) obj0).\u0001.Images.SetKeyName(56, "PolarArray3.ico");
      ((F_ProfileAdd) obj0).btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((F_ProfileAdd) obj0).btn_cancel.DialogResult = DialogResult.Cancel;
      ((F_ProfileAdd) obj0).btn_cancel.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_ProfileAdd) obj0).btn_cancel.ImageIndex = 5;
      ((F_ProfileAdd) obj0).btn_cancel.ImageList = ((F_ProfileAdd) obj0).\u0001;
      ((F_ProfileAdd) obj0).btn_cancel.Location = new System.Drawing.Point(166, 191);
      ((F_ProfileAdd) obj0).btn_cancel.Margin = new Padding(4);
      ((F_ProfileAdd) obj0).btn_cancel.Name = "btn_cancel";
      ((F_ProfileAdd) obj0).btn_cancel.Size = new Size(98, 39);
      ((F_ProfileAdd) obj0).btn_cancel.TabIndex = 128 /*0x80*/;
      ((F_ProfileAdd) obj0).btn_cancel.Text = "Cancel";
      ((F_ProfileAdd) obj0).btn_cancel.TextAlign = ContentAlignment.MiddleRight;
      ((F_ProfileAdd) obj0).btn_cancel.Click += new EventHandler(((F_PanelCutMaterials) obj0).\u0001);
      ((F_ProfileAdd) obj0).btn_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((F_ProfileAdd) obj0).btn_ok.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_ProfileAdd) obj0).btn_ok.ImageIndex = 6;
      ((F_ProfileAdd) obj0).btn_ok.ImageList = ((F_ProfileAdd) obj0).\u0001;
      ((F_ProfileAdd) obj0).btn_ok.Location = new System.Drawing.Point(60, 191);
      ((F_ProfileAdd) obj0).btn_ok.Margin = new Padding(4);
      ((F_ProfileAdd) obj0).btn_ok.Name = "btn_ok";
      ((F_ProfileAdd) obj0).btn_ok.Size = new Size(98, 39);
      ((F_ProfileAdd) obj0).btn_ok.TabIndex = 129;
      ((F_ProfileAdd) obj0).btn_ok.Text = "Ok";
      ((F_ProfileAdd) obj0).btn_ok.TextAlign = ContentAlignment.MiddleRight;
      ((F_ProfileAdd) obj0).btn_ok.Click += new EventHandler(((F_PanelCutMaterials) obj0).\u0001);
      ((F_ProfileAdd) obj0).label1.AutoSize = true;
      ((F_ProfileAdd) obj0).label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_ProfileAdd) obj0).label1.Location = new System.Drawing.Point(5, 85);
      ((F_ProfileAdd) obj0).label1.Name = "label1";
      ((F_ProfileAdd) obj0).label1.Size = new Size(86, 18);
      ((F_ProfileAdd) obj0).label1.TabIndex = 130;
      ((F_ProfileAdd) obj0).label1.Text = "Cut Space";
      ((F_ProfileAdd) obj0).spn_cutspace.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_ProfileAdd) obj0).spn_cutspace.Location = new System.Drawing.Point(173, 85);
      ((F_ProfileAdd) obj0).spn_cutspace.Maximum = new Decimal(new int[4]
      {
        100000000,
        0,
        0,
        0
      });
      ((F_ProfileAdd) obj0).spn_cutspace.Name = "spn_cutspace";
      ((F_ProfileAdd) obj0).spn_cutspace.Size = new Size(90, 24);
      ((F_ProfileAdd) obj0).spn_cutspace.TabIndex = 131;
      ((F_ProfileAdd) obj0).spn_cutspace.Tag = (object) "3";
      ((F_ProfileAdd) obj0).spn_cutspace.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      ((F_ProfileAdd) obj0).label2.AutoSize = true;
      ((F_ProfileAdd) obj0).label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_ProfileAdd) obj0).label2.Location = new System.Drawing.Point(5, 128 /*0x80*/);
      ((F_ProfileAdd) obj0).label2.Name = "label2";
      ((F_ProfileAdd) obj0).label2.Size = new Size(138, 18);
      ((F_ProfileAdd) obj0).label2.TabIndex = 132;
      ((F_ProfileAdd) obj0).label2.Text = "Show Seperators";
      ((F_ProfileAdd) obj0).\u0001.AutoSize = true;
      ((F_ProfileAdd) obj0).\u0001.Location = new System.Drawing.Point(173, 129);
      ((F_ProfileAdd) obj0).\u0001.Name = "chk_showseperatoes";
      ((F_ProfileAdd) obj0).\u0001.Size = new Size(18, 17);
      ((F_ProfileAdd) obj0).\u0001.TabIndex = 133;
      ((F_ProfileAdd) obj0).\u0001.UseVisualStyleBackColor = true;
      obj0.AutoScaleDimensions = new SizeF(8f, 16f);
      obj0.AutoScaleMode = AutoScaleMode.Font;
      obj0.ClientSize = new Size(269, 237);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).\u0001);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).label2);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).label1);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).spn_cutspace);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).label4);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).label5);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).spn_distance);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).spn_count);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).btn_cancel);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_ProfileAdd) obj0).btn_ok);
      obj0.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      obj0.MaximizeBox = false;
      obj0.MinimizeBox = false;
      obj0.Name = "F_ProfilePatternCopy";
      obj0.StartPosition = FormStartPosition.CenterScreen;
      obj0.Text = "Pattern Copy";
      obj0.FormClosing += new FormClosingEventHandler(((F_PanelCutMaterials) obj0).\u0001);
      ((F_ProfileAdd) obj0).spn_distance.EndInit();
      ((F_ProfileAdd) obj0).spn_count.EndInit();
      ((F_ProfileAdd) obj0).spn_cutspace.EndInit();
      obj0.ResumeLayout(false);
      obj0.PerformLayout();
    }
  }

  internal sealed class \u0002
  {
    public const MarbleCountertopCommands MainShapeChanged = ; // Unable to render the field
    public const MarbleCountertopCommands MainSizeChanged = ; // Unable to render the field
    public const MarbleCountertopCommands OutsideEdgeChanged = ; // Unable to render the field
    public const MarbleCountertopCommands InsideShapeChanged = ; // Unable to render the field
    public const MarbleCountertopCommands InsideSizeChanged = ; // Unable to render the field

    static void \u0001([In] F_MarbleProfileCurveSettings obj0)
    {
      string callMethod = "Profile Cut LoadLanguage";
      try
      {
        ((F_LayerOptionList) obj0).\u0001.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Curve} {buLangTranslate.preDef.Setting}";
        ((F_LayerOptionList) obj0).\u0001.Text = $"{buLangTranslate.preDef.Finish} {buLangTranslate.preDef.Setting}";
        ((F_LayerOptionList) obj0).\u0002.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Setting}";
        ((F_LayerOptionList) obj0).\u0001.Text = $"{buLangTranslate.preDef.Finish} {buLangTranslate.preDef.Setting}";
        ((F_LayerOptionList) obj0).\u0002.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Setting}";
        ((F_LayerOptionList) obj0).spn_finishbwdcuttingfeed.Caption.Caption = $"{buLangTranslate.preDef.Back} {buLangTranslate.preDef.Velocity}";
        ((F_LayerOptionList) obj0).spn_finishcoffset.Caption.Caption = "C " + buLangTranslate.preDef.Offset;
        ((F_LayerOptionList) obj0).spn_finishfwdcutfeed.Caption.Caption = $"{buLangTranslate.preDef.Forward} {buLangTranslate.preDef.Velocity}";
        ((F_LayerOptionList) obj0).spn_finishleadin.Caption.Caption = $"{buLangTranslate.preDef.LeadIn} {buLangTranslate.preDef.Angle}";
        ((F_LayerOptionList) obj0).spn_finishleadout.Caption.Caption = $"{buLangTranslate.preDef.LeadOut} {buLangTranslate.preDef.Angle}";
        ((F_LayerOptionList) obj0).spn_finishminZ.Caption.Caption = buLangTranslate.preDef.Min + " Z";
        ((F_LayerOptionList) obj0).spn_finishplungefeed.Caption.Caption = $"{buLangTranslate.preDef.Plunge} {buLangTranslate.preDef.Velocity}";
        ((F_LayerOptionList) obj0).spn_finishrapiddis.Caption.Caption = buLangTranslate.preDef.RapidDistance;
        ((F_LayerOptionList) obj0).spn_finishsafedis.Caption.Caption = buLangTranslate.preDef.SafeDistance;
        ((F_LayerOptionList) obj0).spn_finishstepang.Caption.Caption = $"{buLangTranslate.preDef.Step} {buLangTranslate.preDef.Angle}";
        ((F_LayerOptionList) obj0).spn_finishsurfoffset.Caption.Caption = $"{buLangTranslate.preDef.Surface} {buLangTranslate.preDef.Offset}";
        ((F_LayerOptionList) obj0).spn_finishverticaldevidedis.Caption.Caption = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Devide} {buLangTranslate.preDef.Distance}";
        ((F_LayerOptionList) obj0).chk_finishperpendicularA.Text = buLangTranslate.preDef.Perpendicular + " A";
        ((F_LayerOptionList) obj0).chk_finishzigzag.Text = $"{buLangTranslate.preDef.Zigzag} {buLangTranslate.preDef.Mode}";
        ((F_LayerOptionList) obj0).spn_roughbwdcuttingfeed.Caption.Caption = $"{buLangTranslate.preDef.Back} {buLangTranslate.preDef.Velocity}";
        ((F_LayerOptionList) obj0).spn_roughcoffset.Caption.Caption = "C " + buLangTranslate.preDef.Offset;
        ((F_LayerOptionList) obj0).spn_roughfwdcuttingfeed.Caption.Caption = $"{buLangTranslate.preDef.Forward} {buLangTranslate.preDef.Velocity}";
        ((F_LayerOptionList) obj0).spn_roughleadin.Caption.Caption = buLangTranslate.preDef.LeadIn;
        ((F_LayerOptionList) obj0).spn_roughleadout.Caption.Caption = buLangTranslate.preDef.LeadOut;
        ((F_LayerOptionList) obj0).spn_roughminZ.Caption.Caption = buLangTranslate.preDef.Min + " Z";
        ((F_LayerOptionList) obj0).spn_roughplungefeed.Caption.Caption = $"{buLangTranslate.preDef.Plunge} {buLangTranslate.preDef.Velocity}";
        ((F_LayerOptionList) obj0).spn_roughrapiddis.Caption.Caption = buLangTranslate.preDef.RapidDistance;
        ((F_LayerOptionList) obj0).spn_roughsafedis.Caption.Caption = buLangTranslate.preDef.SafeDistance;
        ((F_LayerOptionList) obj0).spn_roughstepang.Caption.Caption = $"{buLangTranslate.preDef.Step} {buLangTranslate.preDef.Angle}";
        ((F_LayerOptionList) obj0).spn_roughsurfoffset.Caption.Caption = $"{buLangTranslate.preDef.Surface} {buLangTranslate.preDef.Offset}";
        ((F_LayerOptionList) obj0).spn_roughverticaldevidelen.Caption.Caption = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Devide} {buLangTranslate.preDef.Distance}";
        ((F_LayerOptionList) obj0).chk_roughperpendicularA.Text = buLangTranslate.preDef.Perpendicular + " A";
        ((F_LayerOptionList) obj0).chk_rougjzigzag.Text = $"{buLangTranslate.preDef.Zigzag} {buLangTranslate.preDef.Mode}";
        ((F_LayerOptionList) obj0).btn_ok.Text = buLangTranslate.preDef.Ok;
        ((F_LayerOptionList) obj0).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      }
      catch (Exception ex)
      {
        string str = "";
        buLog.addLog(str, "Not Ok", callMethod);
        buException.throwException(ex, callMethod, true, str);
      }
    }
  }

  internal sealed class \u0003
  {
    [SpecialName]
    public int value__;
    public const MarbleCountertopTypes RectangleType1 = ; // Unable to render the field
    public const MarbleCountertopTypes LType1 = ; // Unable to render the field

    static void \u0001([In] F_MarbleCircularSpeed obj0)
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_MarbleCircularSpeed));
      ((F_MarbleCamSettings) obj0).\u0001 = new buGround();
      ((F_MarbleCamSettings) obj0).btn_remove = new buButton();
      ((F_MarbleCamSettings) obj0).btn_add = new buButton();
      ((F_MarbleCamSettings) obj0).\u0001 = new DataGridView();
      ((F_MarbleCamSettings) obj0).btn_close = new buButton();
      ((F_MarbleCamSettings) obj0).\u0001 = new buButton();
      ((F_MarbleCamSettings) obj0).\u0002 = new buButton();
      ((F_MarbleCamSettings) obj0).\u0001.SuspendLayout();
      ((ISupportInitialize) ((F_MarbleCamSettings) obj0).\u0001).BeginInit();
      obj0.SuspendLayout();
      ((F_MarbleCamSettings) obj0).\u0001.AuxInfo = (string) null;
      ((F_MarbleCamSettings) obj0).\u0001.BackColor = Color.Transparent;
      ((F_MarbleCamSettings) obj0).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamSettings) obj0).btn_remove);
      ((F_MarbleCamSettings) obj0).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamSettings) obj0).btn_add);
      ((F_MarbleCamSettings) obj0).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamSettings) obj0).\u0001);
      ((F_MarbleCamSettings) obj0).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamSettings) obj0).btn_close);
      ((F_MarbleCamSettings) obj0).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamSettings) obj0).\u0001);
      ((F_MarbleCamSettings) obj0).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamSettings) obj0).\u0002);
      ((F_MarbleCamSettings) obj0).\u0001.ControlStyle = ControlStyle.Base2;
      ((F_MarbleCamSettings) obj0).\u0001.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).\u0001.Display.GradientType = GradientMode.Lineer;
      ((F_MarbleCamSettings) obj0).\u0001.Display.LineerGradient.FirstColor = Color.Black;
      ((F_MarbleCamSettings) obj0).\u0001.DisplayBottom.BackColor = Color.Gray;
      ((F_MarbleCamSettings) obj0).\u0001.DisplayTop.BackColor = Color.DimGray;
      ((F_MarbleCamSettings) obj0).\u0001.DisplayTop.Fonts.Font = new Font("Tahoma", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleCamSettings) obj0).\u0001.Dock = DockStyle.Fill;
      ((F_MarbleCamSettings) obj0).\u0001.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).\u0001.Ground.TopHeight = 55;
      ((F_MarbleCamSettings) obj0).\u0001.Image = (Image) null;
      ((F_MarbleCamSettings) obj0).\u0001.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_MarbleCamSettings) obj0).\u0001.Location = new System.Drawing.Point(0, 0);
      ((F_MarbleCamSettings) obj0).\u0001.Name = "buGround1";
      ((F_MarbleCamSettings) obj0).\u0001.Sizable = true;
      ((F_MarbleCamSettings) obj0).\u0001.Size = new Size(603, 800);
      ((F_MarbleCamSettings) obj0).\u0001.SmartBounds = true;
      ((F_MarbleCamSettings) obj0).\u0001.StartPosition = FormStartPosition.Manual;
      ((F_MarbleCamSettings) obj0).\u0001.TabIndex = 0;
      ((F_MarbleCamSettings) obj0).\u0001.Text = "Circular Speeds";
      ((F_MarbleCamSettings) obj0).btn_remove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ((F_MarbleCamSettings) obj0).btn_remove.ButtonCopy = false;
      ((F_MarbleCamSettings) obj0).btn_remove.ButtonDownDisplay.BackColor = Color.DimGray;
      ((F_MarbleCamSettings) obj0).btn_remove.ButtonOverDisplay.BackColor = Color.Gray;
      ((F_MarbleCamSettings) obj0).btn_remove.ControlStyle = ControlStyle.Command2;
      ((F_MarbleCamSettings) obj0).btn_remove.Display.BackColor = Color.DarkGray;
      ((F_MarbleCamSettings) obj0).btn_remove.Display.Fonts.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleCamSettings) obj0).btn_remove.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).btn_remove.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleCamSettings) obj0).btn_remove.Image = (Image) componentResourceManager.GetObject("btn_remove.Image");
      ((F_MarbleCamSettings) obj0).btn_remove.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_MarbleCamSettings) obj0).btn_remove.Location = new System.Drawing.Point(146, 726);
      ((F_MarbleCamSettings) obj0).btn_remove.Name = "btn_remove";
      ((F_MarbleCamSettings) obj0).btn_remove.Size = new Size(135, 65);
      ((F_MarbleCamSettings) obj0).btn_remove.TabIndex = 816;
      ((F_MarbleCamSettings) obj0).btn_remove.Text = "Remove";
      ((F_MarbleCamSettings) obj0).btn_remove.UseMnemonic = false;
      ((F_MarbleCamSettings) obj0).btn_remove.Click += new EventHandler(((F_MarbleToolSawMillingHead) obj0).\u0003);
      ((F_MarbleCamSettings) obj0).btn_add.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      ((F_MarbleCamSettings) obj0).btn_add.ButtonCopy = false;
      ((F_MarbleCamSettings) obj0).btn_add.ButtonDownDisplay.BackColor = Color.DimGray;
      ((F_MarbleCamSettings) obj0).btn_add.ButtonOverDisplay.BackColor = Color.Gray;
      ((F_MarbleCamSettings) obj0).btn_add.ControlStyle = ControlStyle.Command2;
      ((F_MarbleCamSettings) obj0).btn_add.Display.BackColor = Color.DarkGray;
      ((F_MarbleCamSettings) obj0).btn_add.Display.Fonts.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleCamSettings) obj0).btn_add.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).btn_add.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleCamSettings) obj0).btn_add.Image = (Image) componentResourceManager.GetObject("btn_add.Image");
      ((F_MarbleCamSettings) obj0).btn_add.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_MarbleCamSettings) obj0).btn_add.Location = new System.Drawing.Point(5, 726);
      ((F_MarbleCamSettings) obj0).btn_add.Name = "btn_add";
      ((F_MarbleCamSettings) obj0).btn_add.Size = new Size(135, 65);
      ((F_MarbleCamSettings) obj0).btn_add.TabIndex = 815;
      ((F_MarbleCamSettings) obj0).btn_add.Text = "Add";
      ((F_MarbleCamSettings) obj0).btn_add.UseMnemonic = false;
      ((F_MarbleCamSettings) obj0).btn_add.Click += new EventHandler(((F_MarbleToolSawMillingHead) obj0).\u0003);
      ((F_MarbleCamSettings) obj0).\u0001.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ((F_MarbleCamSettings) obj0).\u0001.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      ((F_MarbleCamSettings) obj0).\u0001.Location = new System.Drawing.Point(5, 59);
      ((F_MarbleCamSettings) obj0).\u0001.Margin = new Padding(4);
      ((F_MarbleCamSettings) obj0).\u0001.Name = "DGV_Table";
      ((F_MarbleCamSettings) obj0).\u0001.RowHeadersWidth = 51;
      ((F_MarbleCamSettings) obj0).\u0001.Size = new Size(596, 658);
      ((F_MarbleCamSettings) obj0).\u0001.TabIndex = 267;
      ((F_MarbleCamSettings) obj0).\u0001.CellClick += new DataGridViewCellEventHandler(((F_MarbleToolSawMillingHead) obj0).\u0001);
      ((F_MarbleCamSettings) obj0).btn_close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      ((F_MarbleCamSettings) obj0).btn_close.BackColor = Color.DimGray;
      ((F_MarbleCamSettings) obj0).btn_close.ButtonCopy = false;
      ((F_MarbleCamSettings) obj0).btn_close.ButtonDownDisplay.BackColor = Color.Silver;
      ((F_MarbleCamSettings) obj0).btn_close.ButtonOverDisplay.BackColor = Color.Gray;
      ((F_MarbleCamSettings) obj0).btn_close.ControlStyle = ControlStyle.FormButton;
      ((F_MarbleCamSettings) obj0).btn_close.Display.BackColor = Color.DimGray;
      ((F_MarbleCamSettings) obj0).btn_close.Display.Border.Color = Color.Black;
      ((F_MarbleCamSettings) obj0).btn_close.Display.Border.Visible = false;
      ((F_MarbleCamSettings) obj0).btn_close.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).btn_close.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).btn_close.Image = (Image) componentResourceManager.GetObject("btn_close.Image");
      ((F_MarbleCamSettings) obj0).btn_close.Location = new System.Drawing.Point(543, 4);
      ((F_MarbleCamSettings) obj0).btn_close.Margin = new Padding(4);
      ((F_MarbleCamSettings) obj0).btn_close.Name = "btn_close";
      ((F_MarbleCamSettings) obj0).btn_close.Size = new Size(54, 50);
      ((F_MarbleCamSettings) obj0).btn_close.TabIndex = 247;
      ((F_MarbleCamSettings) obj0).btn_close.UseMnemonic = false;
      ((F_MarbleCamSettings) obj0).btn_close.Click += new EventHandler(((F_MarbleToolSawMillingHead) obj0).\u0002);
      ((F_MarbleCamSettings) obj0).\u0001.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((F_MarbleCamSettings) obj0).\u0001.ButtonCopy = false;
      ((F_MarbleCamSettings) obj0).\u0001.ButtonDownDisplay.BackColor = Color.DimGray;
      ((F_MarbleCamSettings) obj0).\u0001.ButtonOverDisplay.BackColor = Color.Gray;
      ((F_MarbleCamSettings) obj0).\u0001.ControlStyle = ControlStyle.Ok;
      ((F_MarbleCamSettings) obj0).\u0001.Display.BackColor = Color.DarkGray;
      ((F_MarbleCamSettings) obj0).\u0001.Display.Fonts.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleCamSettings) obj0).\u0001.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).\u0001.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleCamSettings) obj0).\u0001.Image = (Image) componentResourceManager.GetObject("btn_ok.Image");
      ((F_MarbleCamSettings) obj0).\u0001.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_MarbleCamSettings) obj0).\u0001.Location = new System.Drawing.Point(315, 726);
      ((F_MarbleCamSettings) obj0).\u0001.Name = "btn_ok";
      ((F_MarbleCamSettings) obj0).\u0001.Size = new Size(135, 65);
      ((F_MarbleCamSettings) obj0).\u0001.TabIndex = 69;
      ((F_MarbleCamSettings) obj0).\u0001.Text = "Ok";
      ((F_MarbleCamSettings) obj0).\u0001.UseMnemonic = false;
      ((F_MarbleCamSettings) obj0).\u0001.Click += new EventHandler(((F_MarbleToolSawMillingHead) obj0).\u0001);
      ((F_MarbleCamSettings) obj0).\u0002.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((F_MarbleCamSettings) obj0).\u0002.ButtonCopy = false;
      ((F_MarbleCamSettings) obj0).\u0002.ButtonDownDisplay.BackColor = Color.DimGray;
      ((F_MarbleCamSettings) obj0).\u0002.ButtonOverDisplay.BackColor = Color.Gray;
      ((F_MarbleCamSettings) obj0).\u0002.ControlStyle = ControlStyle.Cancel;
      ((F_MarbleCamSettings) obj0).\u0002.Display.BackColor = Color.DarkGray;
      ((F_MarbleCamSettings) obj0).\u0002.Display.Fonts.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_MarbleCamSettings) obj0).\u0002.Font = new Font("Microsoft Sans Serif", 10f);
      ((F_MarbleCamSettings) obj0).\u0002.Geometry.ShapeMode = ShapeType.Arc;
      ((F_MarbleCamSettings) obj0).\u0002.Image = (Image) componentResourceManager.GetObject("btn_cancel.Image");
      ((F_MarbleCamSettings) obj0).\u0002.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_MarbleCamSettings) obj0).\u0002.Location = new System.Drawing.Point(456, 726);
      ((F_MarbleCamSettings) obj0).\u0002.Name = "btn_cancel";
      ((F_MarbleCamSettings) obj0).\u0002.Size = new Size(135, 65);
      ((F_MarbleCamSettings) obj0).\u0002.TabIndex = 68;
      ((F_MarbleCamSettings) obj0).\u0002.Text = "Cancel";
      ((F_MarbleCamSettings) obj0).\u0002.UseMnemonic = false;
      ((F_MarbleCamSettings) obj0).\u0002.Click += new EventHandler(((F_MarbleToolSawMillingHead) obj0).\u0002);
      obj0.AutoScaleMode = AutoScaleMode.None;
      obj0.ClientSize = new Size(603, 800);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_MarbleCamSettings) obj0).\u0001);
      obj0.FormBorderStyle = FormBorderStyle.None;
      obj0.Name = "F_MarbleCircularSpeed";
      obj0.Text = "Cam Parameters";
      obj0.FormClosing += new FormClosingEventHandler(((F_MarbleToolSawMillingHead) obj0).\u0001);
      ((F_MarbleCamSettings) obj0).\u0001.ResumeLayout(false);
      ((ISupportInitialize) ((F_MarbleCamSettings) obj0).\u0001).EndInit();
      obj0.ResumeLayout(false);
    }
  }

  internal sealed class \u0004
  {
    public const MarbleCountertopTypes TrapezType1 = ; // Unable to render the field
    public const MarbleCountertopTypes FromDrawing = ; // Unable to render the field
    [SpecialName]
    public int value__;

    static void \u0001([In] \u0012.\u0002 obj0, [In] IntPoint obj1, [In] buClipper obj2)
    {
      \u0081.\u0001 obj = (\u0081.\u0001) new buPipeBendCalc();
      ((PipeBendDiskBlocks) obj).\u0001 = obj0;
      ((PipeBendDiskBlocks) obj).\u0001 = obj1;
      ((PipeBendTempVars) obj2).\u0002.Add(obj);
    }

    static bool \u0001([In] buClipper obj0, [In] \u0084.\u0001 obj1)
    {
      // ISSUE: unable to decompile the method.
    }
  }

  internal sealed class \u0005
  {
    public const MarbleCountertopModes None = ; // Unable to render the field
    public const MarbleCountertopModes Sink = ; // Unable to render the field
    public const MarbleCountertopModes BuiltIn = ; // Unable to render the field
    public const MarbleCountertopModes Socket = ; // Unable to render the field
    public const MarbleCountertopModes Tap = ; // Unable to render the field
    public const MarbleCountertopModes Cavity = ; // Unable to render the field
    public const MarbleCountertopModes Edge = ; // Unable to render the field
    public const MarbleCountertopModes Slat = ; // Unable to render the field
    public const MarbleCountertopModes Chamfer = ; // Unable to render the field
    public const MarbleCountertopModes Pocket = ; // Unable to render the field
    public const MarbleCountertopModes Corner = ; // Unable to render the field
    public const MarbleCountertopModes Radius = ; // Unable to render the field
    public const MarbleCountertopModes Angle = ; // Unable to render the field
    [SpecialName]
    public int value__;

    static void \u0001([In] F_ColorList obj0)
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_ColorList));
      ((F_LayerRouter3X) obj0).\u000E = new Label();
      ((F_LayerRouter3X) obj0).\u000F = new Label();
      ((F_LayerRouter3X) obj0).\u0010 = new Label();
      ((F_LayerRouter3X) obj0).\u0011 = new Label();
      ((F_LayerRouter3X) obj0).\u0012 = new Label();
      ((F_LayerList) obj0).\u0013 = new Label();
      ((F_LayerList) obj0).\u0014 = new Label();
      ((F_LayerList) obj0).\u0015 = new Label();
      ((F_LayerRouter3X) obj0).\u0008 = new Label();
      ((F_LayerRouter3X) obj0).\u0001 = new Label();
      ((F_LayerRouter3X) obj0).\u0002 = new Label();
      ((F_LayerRouter3X) obj0).\u0003 = new Label();
      ((F_LayerRouter3X) obj0).\u0004 = new Label();
      ((F_LayerRouter3X) obj0).\u0005 = new Label();
      ((F_LayerRouter3X) obj0).\u0006 = new Label();
      ((F_LayerRouter3X) obj0).\u0007 = new Label();
      ((F_LayerList) obj0).\u0001 = new ImageList();
      ((F_LayerList) obj0).btn_cancel = new Button();
      ((F_LayerList) obj0).btn_ok = new Button();
      ((F_LayerList) obj0).\u0016 = new Label();
      ((F_LayerList) obj0).\u0017 = new Label();
      ((F_LayerList) obj0).\u0018 = new Label();
      ((F_LayerConvertToTufting) obj0).\u0019 = new Label();
      ((F_LayerConvertToTufting) obj0).\u001A = new Label();
      ((F_LayerConvertToTufting) obj0).\u001B = new Label();
      ((F_LayerConvertToTufting) obj0).\u001C = new Label();
      ((F_LayerConvertToTufting) obj0).\u001D = new Label();
      ((F_LayerConvertToTufting) obj0).\u001E = new Label();
      ((F_LayerConvertToTufting) obj0).\u001F = new Label();
      ((F_LayerConvertToTufting) obj0).\u007F = new Label();
      ((F_LayerConvertToTufting) obj0).\u0080 = new Label();
      ((F_LayerConvertToTufting) obj0).\u0081 = new Label();
      ((F_LayerConvertToTufting) obj0).\u0082 = new Label();
      ((F_LayerConvertToTufting) obj0).\u0083 = new Label();
      ((F_LayerConvertToTufting) obj0).\u0084 = new Label();
      obj0.SuspendLayout();
      ((F_LayerRouter3X) obj0).\u000E.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u000E.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u000E.Location = new System.Drawing.Point(35, 549);
      ((F_LayerRouter3X) obj0).\u000E.Name = "lbl_Color16";
      ((F_LayerRouter3X) obj0).\u000E.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u000E.TabIndex = 20;
      ((F_LayerRouter3X) obj0).\u000E.Tag = (object) "15";
      ((F_LayerRouter3X) obj0).\u000E.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u000F.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u000F.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u000F.Location = new System.Drawing.Point(35, 513);
      ((F_LayerRouter3X) obj0).\u000F.Name = "lbl_Color15";
      ((F_LayerRouter3X) obj0).\u000F.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u000F.TabIndex = 19;
      ((F_LayerRouter3X) obj0).\u000F.Tag = (object) "14";
      ((F_LayerRouter3X) obj0).\u000F.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0010.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0010.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0010.Location = new System.Drawing.Point(35, 477);
      ((F_LayerRouter3X) obj0).\u0010.Name = "lbl_Color14";
      ((F_LayerRouter3X) obj0).\u0010.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0010.TabIndex = 18;
      ((F_LayerRouter3X) obj0).\u0010.Tag = (object) "13";
      ((F_LayerRouter3X) obj0).\u0010.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0011.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0011.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0011.Location = new System.Drawing.Point(35, 441);
      ((F_LayerRouter3X) obj0).\u0011.Name = "lbl_Color13";
      ((F_LayerRouter3X) obj0).\u0011.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0011.TabIndex = 17;
      ((F_LayerRouter3X) obj0).\u0011.Tag = (object) "12";
      ((F_LayerRouter3X) obj0).\u0011.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0012.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0012.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0012.Location = new System.Drawing.Point(35, 405);
      ((F_LayerRouter3X) obj0).\u0012.Name = "lbl_Color12";
      ((F_LayerRouter3X) obj0).\u0012.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0012.TabIndex = 16 /*0x10*/;
      ((F_LayerRouter3X) obj0).\u0012.Tag = (object) "11";
      ((F_LayerRouter3X) obj0).\u0012.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerList) obj0).\u0013.BackColor = Color.Silver;
      ((F_LayerList) obj0).\u0013.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerList) obj0).\u0013.Location = new System.Drawing.Point(35, 369);
      ((F_LayerList) obj0).\u0013.Name = "lbl_Color11";
      ((F_LayerList) obj0).\u0013.Size = new Size(214, 24);
      ((F_LayerList) obj0).\u0013.TabIndex = 15;
      ((F_LayerList) obj0).\u0013.Tag = (object) "10";
      ((F_LayerList) obj0).\u0013.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerList) obj0).\u0014.BackColor = Color.Silver;
      ((F_LayerList) obj0).\u0014.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerList) obj0).\u0014.Location = new System.Drawing.Point(35, 333);
      ((F_LayerList) obj0).\u0014.Name = "lbl_Color10";
      ((F_LayerList) obj0).\u0014.Size = new Size(214, 24);
      ((F_LayerList) obj0).\u0014.TabIndex = 14;
      ((F_LayerList) obj0).\u0014.Tag = (object) "9";
      ((F_LayerList) obj0).\u0014.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerList) obj0).\u0015.BackColor = Color.Silver;
      ((F_LayerList) obj0).\u0015.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerList) obj0).\u0015.Location = new System.Drawing.Point(35, 297);
      ((F_LayerList) obj0).\u0015.Name = "lbl_Color9";
      ((F_LayerList) obj0).\u0015.Size = new Size(214, 24);
      ((F_LayerList) obj0).\u0015.TabIndex = 13;
      ((F_LayerList) obj0).\u0015.Tag = (object) "8";
      ((F_LayerList) obj0).\u0015.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0008.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0008.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0008.Location = new System.Drawing.Point(35, 261);
      ((F_LayerRouter3X) obj0).\u0008.Name = "lbl_Color8";
      ((F_LayerRouter3X) obj0).\u0008.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0008.TabIndex = 12;
      ((F_LayerRouter3X) obj0).\u0008.Tag = (object) "7";
      ((F_LayerRouter3X) obj0).\u0008.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0001.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0001.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0001.Location = new System.Drawing.Point(35, 225);
      ((F_LayerRouter3X) obj0).\u0001.Name = "lbl_Color7";
      ((F_LayerRouter3X) obj0).\u0001.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0001.TabIndex = 11;
      ((F_LayerRouter3X) obj0).\u0001.Tag = (object) "6";
      ((F_LayerRouter3X) obj0).\u0001.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0002.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0002.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0002.Location = new System.Drawing.Point(35, 189);
      ((F_LayerRouter3X) obj0).\u0002.Name = "lbl_Color6";
      ((F_LayerRouter3X) obj0).\u0002.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0002.TabIndex = 10;
      ((F_LayerRouter3X) obj0).\u0002.Tag = (object) "5";
      ((F_LayerRouter3X) obj0).\u0002.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0003.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0003.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0003.Location = new System.Drawing.Point(35, 153);
      ((F_LayerRouter3X) obj0).\u0003.Name = "lbl_Color5";
      ((F_LayerRouter3X) obj0).\u0003.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0003.TabIndex = 9;
      ((F_LayerRouter3X) obj0).\u0003.Tag = (object) "4";
      ((F_LayerRouter3X) obj0).\u0003.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0004.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0004.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0004.Location = new System.Drawing.Point(35, 117);
      ((F_LayerRouter3X) obj0).\u0004.Name = "lbl_Color4";
      ((F_LayerRouter3X) obj0).\u0004.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0004.TabIndex = 8;
      ((F_LayerRouter3X) obj0).\u0004.Tag = (object) "3";
      ((F_LayerRouter3X) obj0).\u0004.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0005.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0005.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0005.Location = new System.Drawing.Point(35, 81);
      ((F_LayerRouter3X) obj0).\u0005.Name = "lbl_Color3";
      ((F_LayerRouter3X) obj0).\u0005.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0005.TabIndex = 7;
      ((F_LayerRouter3X) obj0).\u0005.Tag = (object) "2";
      ((F_LayerRouter3X) obj0).\u0005.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0006.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0006.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0006.Location = new System.Drawing.Point(35, 45);
      ((F_LayerRouter3X) obj0).\u0006.Name = "lbl_Color2";
      ((F_LayerRouter3X) obj0).\u0006.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0006.TabIndex = 6;
      ((F_LayerRouter3X) obj0).\u0006.Tag = (object) "1";
      ((F_LayerRouter3X) obj0).\u0006.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerRouter3X) obj0).\u0007.BackColor = Color.Silver;
      ((F_LayerRouter3X) obj0).\u0007.BorderStyle = BorderStyle.FixedSingle;
      ((F_LayerRouter3X) obj0).\u0007.Location = new System.Drawing.Point(35, 9);
      ((F_LayerRouter3X) obj0).\u0007.Name = "lbl_Color1";
      ((F_LayerRouter3X) obj0).\u0007.Size = new Size(214, 24);
      ((F_LayerRouter3X) obj0).\u0007.TabIndex = 5;
      ((F_LayerRouter3X) obj0).\u0007.Tag = (object) "0";
      ((F_LayerRouter3X) obj0).\u0007.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0002);
      ((F_LayerList) obj0).\u0001.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC32.ImageStream");
      ((F_LayerList) obj0).\u0001.TransparentColor = Color.Transparent;
      ((F_LayerList) obj0).\u0001.Images.SetKeyName(0, "cancel.ico");
      ((F_LayerList) obj0).\u0001.Images.SetKeyName(1, "ok.ico");
      ((F_LayerList) obj0).\u0001.Images.SetKeyName(2, "add5.ico");
      ((F_LayerList) obj0).\u0001.Images.SetKeyName(3, "remove5.ico");
      ((F_LayerList) obj0).btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((F_LayerList) obj0).btn_cancel.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_LayerList) obj0).btn_cancel.ImageIndex = 0;
      ((F_LayerList) obj0).btn_cancel.ImageList = ((F_LayerList) obj0).\u0001;
      ((F_LayerList) obj0).btn_cancel.Location = new System.Drawing.Point(134, 580);
      ((F_LayerList) obj0).btn_cancel.Margin = new Padding(4);
      ((F_LayerList) obj0).btn_cancel.Name = "btn_cancel";
      ((F_LayerList) obj0).btn_cancel.Size = new Size(110, 37);
      ((F_LayerList) obj0).btn_cancel.TabIndex = 104;
      ((F_LayerList) obj0).btn_cancel.Text = "Cancel";
      ((F_LayerList) obj0).btn_cancel.TextAlign = ContentAlignment.MiddleRight;
      ((F_LayerList) obj0).btn_cancel.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0001);
      ((F_LayerList) obj0).btn_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      ((F_LayerList) obj0).btn_ok.ImageAlign = ContentAlignment.MiddleLeft;
      ((F_LayerList) obj0).btn_ok.ImageIndex = 1;
      ((F_LayerList) obj0).btn_ok.ImageList = ((F_LayerList) obj0).\u0001;
      ((F_LayerList) obj0).btn_ok.Location = new System.Drawing.Point(16 /*0x10*/, 580);
      ((F_LayerList) obj0).btn_ok.Margin = new Padding(4);
      ((F_LayerList) obj0).btn_ok.Name = "btn_ok";
      ((F_LayerList) obj0).btn_ok.Size = new Size(110, 37);
      ((F_LayerList) obj0).btn_ok.TabIndex = 105;
      ((F_LayerList) obj0).btn_ok.Text = "Ok";
      ((F_LayerList) obj0).btn_ok.TextAlign = ContentAlignment.MiddleRight;
      ((F_LayerList) obj0).btn_ok.Click += new EventHandler(((F_NestOnlineCalc) obj0).\u0001);
      ((F_LayerList) obj0).\u0016.AutoSize = true;
      ((F_LayerList) obj0).\u0016.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerList) obj0).\u0016.Location = new System.Drawing.Point(0, 11);
      ((F_LayerList) obj0).\u0016.Name = "lbl_1";
      ((F_LayerList) obj0).\u0016.Size = new Size(19, 20);
      ((F_LayerList) obj0).\u0016.TabIndex = 106;
      ((F_LayerList) obj0).\u0016.Text = "1";
      ((F_LayerList) obj0).\u0017.AutoSize = true;
      ((F_LayerList) obj0).\u0017.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerList) obj0).\u0017.Location = new System.Drawing.Point(0, 45);
      ((F_LayerList) obj0).\u0017.Name = "label1";
      ((F_LayerList) obj0).\u0017.Size = new Size(19, 20);
      ((F_LayerList) obj0).\u0017.TabIndex = 107;
      ((F_LayerList) obj0).\u0017.Text = "2";
      ((F_LayerList) obj0).\u0018.AutoSize = true;
      ((F_LayerList) obj0).\u0018.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerList) obj0).\u0018.Location = new System.Drawing.Point(0, 81);
      ((F_LayerList) obj0).\u0018.Name = "label2";
      ((F_LayerList) obj0).\u0018.Size = new Size(19, 20);
      ((F_LayerList) obj0).\u0018.TabIndex = 108;
      ((F_LayerList) obj0).\u0018.Text = "3";
      ((F_LayerConvertToTufting) obj0).\u0019.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u0019.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u0019.Location = new System.Drawing.Point(0, 189);
      ((F_LayerConvertToTufting) obj0).\u0019.Name = "label3";
      ((F_LayerConvertToTufting) obj0).\u0019.Size = new Size(19, 20);
      ((F_LayerConvertToTufting) obj0).\u0019.TabIndex = 111;
      ((F_LayerConvertToTufting) obj0).\u0019.Text = "6";
      ((F_LayerConvertToTufting) obj0).\u001A.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u001A.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u001A.Location = new System.Drawing.Point(0, 153);
      ((F_LayerConvertToTufting) obj0).\u001A.Name = "label4";
      ((F_LayerConvertToTufting) obj0).\u001A.Size = new Size(19, 20);
      ((F_LayerConvertToTufting) obj0).\u001A.TabIndex = 110;
      ((F_LayerConvertToTufting) obj0).\u001A.Text = "5";
      ((F_LayerConvertToTufting) obj0).\u001B.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u001B.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u001B.Location = new System.Drawing.Point(0, 117);
      ((F_LayerConvertToTufting) obj0).\u001B.Name = "label5";
      ((F_LayerConvertToTufting) obj0).\u001B.Size = new Size(19, 20);
      ((F_LayerConvertToTufting) obj0).\u001B.TabIndex = 109;
      ((F_LayerConvertToTufting) obj0).\u001B.Text = "4";
      ((F_LayerConvertToTufting) obj0).\u001C.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u001C.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u001C.Location = new System.Drawing.Point(0, 297);
      ((F_LayerConvertToTufting) obj0).\u001C.Name = "label6";
      ((F_LayerConvertToTufting) obj0).\u001C.Size = new Size(19, 20);
      ((F_LayerConvertToTufting) obj0).\u001C.TabIndex = 114;
      ((F_LayerConvertToTufting) obj0).\u001C.Text = "9";
      ((F_LayerConvertToTufting) obj0).\u001D.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u001D.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u001D.Location = new System.Drawing.Point(0, 261);
      ((F_LayerConvertToTufting) obj0).\u001D.Name = "label7";
      ((F_LayerConvertToTufting) obj0).\u001D.Size = new Size(19, 20);
      ((F_LayerConvertToTufting) obj0).\u001D.TabIndex = 113;
      ((F_LayerConvertToTufting) obj0).\u001D.Text = "8";
      ((F_LayerConvertToTufting) obj0).\u001E.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u001E.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u001E.Location = new System.Drawing.Point(0, 225);
      ((F_LayerConvertToTufting) obj0).\u001E.Name = "label8";
      ((F_LayerConvertToTufting) obj0).\u001E.Size = new Size(19, 20);
      ((F_LayerConvertToTufting) obj0).\u001E.TabIndex = 112 /*0x70*/;
      ((F_LayerConvertToTufting) obj0).\u001E.Text = "7";
      ((F_LayerConvertToTufting) obj0).\u001F.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u001F.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u001F.Location = new System.Drawing.Point(0, 405);
      ((F_LayerConvertToTufting) obj0).\u001F.Name = "label9";
      ((F_LayerConvertToTufting) obj0).\u001F.Size = new Size(29, 20);
      ((F_LayerConvertToTufting) obj0).\u001F.TabIndex = 117;
      ((F_LayerConvertToTufting) obj0).\u001F.Text = "12";
      ((F_LayerConvertToTufting) obj0).\u007F.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u007F.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u007F.Location = new System.Drawing.Point(0, 369);
      ((F_LayerConvertToTufting) obj0).\u007F.Name = "label10";
      ((F_LayerConvertToTufting) obj0).\u007F.Size = new Size(29, 20);
      ((F_LayerConvertToTufting) obj0).\u007F.TabIndex = 116;
      ((F_LayerConvertToTufting) obj0).\u007F.Text = "11";
      ((F_LayerConvertToTufting) obj0).\u0080.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u0080.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u0080.Location = new System.Drawing.Point(0, 333);
      ((F_LayerConvertToTufting) obj0).\u0080.Name = "label11";
      ((F_LayerConvertToTufting) obj0).\u0080.Size = new Size(29, 20);
      ((F_LayerConvertToTufting) obj0).\u0080.TabIndex = 115;
      ((F_LayerConvertToTufting) obj0).\u0080.Text = "10";
      ((F_LayerConvertToTufting) obj0).\u0081.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u0081.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u0081.Location = new System.Drawing.Point(0, 513);
      ((F_LayerConvertToTufting) obj0).\u0081.Name = "label12";
      ((F_LayerConvertToTufting) obj0).\u0081.Size = new Size(29, 20);
      ((F_LayerConvertToTufting) obj0).\u0081.TabIndex = 120;
      ((F_LayerConvertToTufting) obj0).\u0081.Text = "15";
      ((F_LayerConvertToTufting) obj0).\u0082.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u0082.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u0082.Location = new System.Drawing.Point(0, 477);
      ((F_LayerConvertToTufting) obj0).\u0082.Name = "label13";
      ((F_LayerConvertToTufting) obj0).\u0082.Size = new Size(29, 20);
      ((F_LayerConvertToTufting) obj0).\u0082.TabIndex = 119;
      ((F_LayerConvertToTufting) obj0).\u0082.Text = "14";
      ((F_LayerConvertToTufting) obj0).\u0083.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u0083.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u0083.Location = new System.Drawing.Point(0, 441);
      ((F_LayerConvertToTufting) obj0).\u0083.Name = "label14";
      ((F_LayerConvertToTufting) obj0).\u0083.Size = new Size(29, 20);
      ((F_LayerConvertToTufting) obj0).\u0083.TabIndex = 118;
      ((F_LayerConvertToTufting) obj0).\u0083.Text = "13";
      ((F_LayerConvertToTufting) obj0).\u0084.AutoSize = true;
      ((F_LayerConvertToTufting) obj0).\u0084.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      ((F_LayerConvertToTufting) obj0).\u0084.Location = new System.Drawing.Point(0, 549);
      ((F_LayerConvertToTufting) obj0).\u0084.Name = "label15";
      ((F_LayerConvertToTufting) obj0).\u0084.Size = new Size(29, 20);
      ((F_LayerConvertToTufting) obj0).\u0084.TabIndex = 121;
      ((F_LayerConvertToTufting) obj0).\u0084.Text = "16";
      obj0.AutoScaleDimensions = new SizeF(8f, 16f);
      obj0.AutoScaleMode = AutoScaleMode.Font;
      obj0.ClientSize = new Size(257, 620);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u0084);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u0081);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u0082);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u0083);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u001F);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u007F);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u0080);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u001C);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u001D);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u001E);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u0019);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u001A);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerConvertToTufting) obj0).\u001B);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).\u0018);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).\u0017);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).\u0016);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).btn_cancel);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).btn_ok);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u000E);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u000F);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0007);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0010);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0006);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0011);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0005);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0012);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0004);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).\u0013);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0003);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).\u0014);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0002);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerList) obj0).\u0015);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0001);
      obj0.Controls.Add((System.Windows.Forms.Control) ((F_LayerRouter3X) obj0).\u0008);
      obj0.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      obj0.MaximizeBox = false;
      obj0.MinimizeBox = false;
      obj0.Name = "F_ColorList";
      obj0.Text = "Color List";
      obj0.FormClosing += new FormClosingEventHandler(((F_NestOnlineCalc) obj0).\u0001);
      obj0.ResumeLayout(false);
      obj0.PerformLayout();
    }

    static void \u0001([In] F_VShapePocket obj0)
    {
      ((F_ControlUISettings) obj0).Depth = ((F_ControlUISettings) obj0).spn_vcleaningdepth.Value;
      ((F_ControlUISettings) obj0).StartHeight = ((F_ControlUISettings) obj0).spn_vcleaningstartheight.Value;
      ((F_ControlUISettings) obj0).EndHeight = ((F_ControlUISettings) obj0).spn_vcleaningendheight.Value;
      ((F_ControlUISettings) obj0).Width = ((F_ControlUISettings) obj0).spn_vcleaningwidth.Value;
      ((F_ControlUISettings) obj0).XPos = ((F_ControlUISettings) obj0).spn_xpos.Value;
      ((F_ControlUISettings) obj0).ZOffset = ((F_ControlUISettings) obj0).spn_ZOffset.Value;
      ((F_ControlUISettings) obj0).XOffset = ((F_ControlUISettings) obj0).spn_xoffset.Value;
      ((F_ControlUISettings) obj0).SafeDis = ((F_ControlUISettings) obj0).spn_safedis.Value;
      ((F_ControlUISettings) obj0).RapidDis = ((F_ControlUISettings) obj0).spn_rapiddis.Value;
      ((F_ControlUISettings) obj0).PlungeFeed = ((F_ControlUISettings) obj0).spn_plungefeed.Value;
      ((F_ControlUISettings) obj0).CuttingFeed = ((F_ControlUISettings) obj0).spn_cuttingfeed.Value;
      if (((F_ControlUISettings) obj0).chk_vleft.Check)
        ((F_ControlUISettings) obj0).OpLocation = LeftMiddleRightLocationType.Left;
      else if (((F_ControlUISettings) obj0).chk_vright.Check)
        ((F_ControlUISettings) obj0).OpLocation = LeftMiddleRightLocationType.Right;
      else
        ((F_ControlUISettings) obj0).OpLocation = LeftMiddleRightLocationType.Middle;
    }
  }

  internal sealed class \u0006
  {
    public const MarbleCountertopActiveModes None = ; // Unable to render the field
    public const MarbleCountertopActiveModes Sink1 = ; // Unable to render the field
    public const MarbleCountertopActiveModes Sink2 = ; // Unable to render the field
    public const MarbleCountertopActiveModes BuiltIn1 = ; // Unable to render the field
    public const MarbleCountertopActiveModes BuiltIn2 = ; // Unable to render the field
    public const MarbleCountertopActiveModes Socket1 = ; // Unable to render the field

    static void \u0001([In] F_MarbleEditBaseHAndXY obj0)
    {
      ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) obj0).varRuntime).ScaleHeight = ((F_MarbleToolSpindleAndMagazine) obj0).spn_scaleheight.Value;
      ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) obj0).varRuntime).ScaleWidth = ((F_MarbleToolSpindleAndMagazine) obj0).spn_scalewidth.Value;
      ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) obj0).varRuntime).ScaleBaseHeight = ((F_MarbleToolSpindleAndMagazine) obj0).spn_baseheight.Value;
      ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) obj0).varRuntime).ScaleKeepRatio = ((F_MarbleToolSpindleAndMagazine) obj0).chk_keepratio.Check;
    }
  }

  internal sealed class \u0007 : MemoryStream
  {
    static void \u0001([In] F_DoorMat obj0)
    {
      if (!((F_ControlUIDataGridView) obj0).PropertiesForm.Inited)
        return;
      ((F_ControlUIDataGridView) obj0).viewportLayout.Entities.Clear();
      Entity entDoor = (Entity) null;
      ((SewingDevideOptions) buCall.\u0001).CreateDoorEntityFromMaterial(((F_ControlUIDataGridView) obj0).Material, ref entDoor);
      CompositeCurve rectangle = CompositeCurve.CreateRectangle(((SortResult) ((F_ControlUIDataGridView) obj0).Material).Size.Width, ((SortResult) ((F_ControlUIDataGridView) obj0).Material).Size.Height);
      Entity entSurface = (Entity) null;
      buCall.\u0001.surfaceFromOutterInner((ICurve) rectangle, (List<ICurve>) null, ((SortResult) ((F_ControlUIDataGridView) obj0).Material).Size.Depth, ref entSurface);
      if (entDoor == null)
        return;
      entDoor.Color = ((SortOptions) ((F_ControlUIDataGridView) obj0).Material).Display.SkinColor;
      entDoor.ColorMethod = colorMethodType.byEntity;
      ((F_ControlUIDataGridView) obj0).viewportLayout.Entities.Add(entDoor);
      ((F_ControlUIDataGridView) obj0).viewportLayout.ActiveViewport.OriginSymbol.StyleMode = originSymbolStyleType.CoordinateSystem;
      ((F_ControlUIDataGridView) obj0).viewportLayout.SetView(viewType.Isometric, true, false);
      ((F_ControlUIDataGridView) obj0).viewportLayout.Invalidate();
    }
  }
}
