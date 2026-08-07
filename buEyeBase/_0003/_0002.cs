// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u0003;

internal class \u0002
{
  static void \u0001([In] F_LaserStartOrder obj0)
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_LaserStartOrder));
    ((F_NestPartAdd) obj0).\u0001 = new ImageList();
    ((F_NestPartAdd) obj0).btn_cancel = new Button();
    ((F_NestPartAdd) obj0).btn_ok = new Button();
    ((F_NestPartAdd) obj0).btn_down = new Button();
    ((F_NestPartAdd) obj0).btn_up = new Button();
    ((F_NestPartAdd) obj0).\u0002 = new ImageList();
    ((F_NestPartAdd) obj0).\u0001 = new CheckedListBox();
    obj0.SuspendLayout();
    ((F_NestPartAdd) obj0).\u0001.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC32.ImageStream");
    ((F_NestPartAdd) obj0).\u0001.TransparentColor = Color.Transparent;
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(0, "cancel.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(1, "ok.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(2, "remove5.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(3, "add5.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(4, "1492561718_icon-arrow-up-c - Kopya (2).ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(5, "1492561718_icon-arrow-up-c - Kopya.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(6, "Copy.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(7, "open4.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(8, "save.ico");
    ((F_NestPartAdd) obj0).\u0001.Images.SetKeyName(9, "update7.ico");
    ((F_NestPartAdd) obj0).btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    ((F_NestPartAdd) obj0).btn_cancel.DialogResult = DialogResult.Cancel;
    ((F_NestPartAdd) obj0).btn_cancel.ImageAlign = ContentAlignment.MiddleLeft;
    ((F_NestPartAdd) obj0).btn_cancel.ImageIndex = 0;
    ((F_NestPartAdd) obj0).btn_cancel.ImageList = ((F_NestPartAdd) obj0).\u0001;
    ((F_NestPartAdd) obj0).btn_cancel.Location = new Point(231, 221);
    ((F_NestPartAdd) obj0).btn_cancel.Margin = new Padding(4);
    ((F_NestPartAdd) obj0).btn_cancel.Name = "btn_cancel";
    ((F_NestPartAdd) obj0).btn_cancel.Size = new Size(107, 38);
    ((F_NestPartAdd) obj0).btn_cancel.TabIndex = 93;
    ((F_NestPartAdd) obj0).btn_cancel.Text = "Cancel";
    ((F_NestPartAdd) obj0).btn_cancel.TextAlign = ContentAlignment.MiddleRight;
    ((F_NestPartAdd) obj0).btn_cancel.Click += new EventHandler(((F_RoboticSurfacePoints) obj0).\u0001);
    ((F_NestPartAdd) obj0).btn_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    ((F_NestPartAdd) obj0).btn_ok.ImageAlign = ContentAlignment.MiddleLeft;
    ((F_NestPartAdd) obj0).btn_ok.ImageIndex = 1;
    ((F_NestPartAdd) obj0).btn_ok.ImageList = ((F_NestPartAdd) obj0).\u0001;
    ((F_NestPartAdd) obj0).btn_ok.Location = new Point(124, 222);
    ((F_NestPartAdd) obj0).btn_ok.Margin = new Padding(4);
    ((F_NestPartAdd) obj0).btn_ok.Name = "btn_ok";
    ((F_NestPartAdd) obj0).btn_ok.Size = new Size(96 /*0x60*/, 38);
    ((F_NestPartAdd) obj0).btn_ok.TabIndex = 94;
    ((F_NestPartAdd) obj0).btn_ok.Text = "Ok";
    ((F_NestPartAdd) obj0).btn_ok.TextAlign = ContentAlignment.MiddleRight;
    ((F_NestPartAdd) obj0).btn_ok.Click += new EventHandler(((F_RoboticSurfacePoints) obj0).\u0001);
    ((F_NestPartAdd) obj0).btn_down.ImageAlign = ContentAlignment.MiddleLeft;
    ((F_NestPartAdd) obj0).btn_down.ImageIndex = 5;
    ((F_NestPartAdd) obj0).btn_down.ImageList = ((F_NestPartAdd) obj0).\u0001;
    ((F_NestPartAdd) obj0).btn_down.Location = new Point(231, 170);
    ((F_NestPartAdd) obj0).btn_down.Margin = new Padding(4);
    ((F_NestPartAdd) obj0).btn_down.Name = "btn_down";
    ((F_NestPartAdd) obj0).btn_down.Size = new Size(107, 38);
    ((F_NestPartAdd) obj0).btn_down.TabIndex = 97;
    ((F_NestPartAdd) obj0).btn_down.Text = "Down";
    ((F_NestPartAdd) obj0).btn_down.TextAlign = ContentAlignment.MiddleRight;
    ((F_NestPartAdd) obj0).btn_down.Click += new EventHandler(((F_RoboticSurfacePoints) obj0).\u0001);
    ((F_NestPartAdd) obj0).btn_up.ImageAlign = ContentAlignment.MiddleLeft;
    ((F_NestPartAdd) obj0).btn_up.ImageIndex = 4;
    ((F_NestPartAdd) obj0).btn_up.ImageList = ((F_NestPartAdd) obj0).\u0001;
    ((F_NestPartAdd) obj0).btn_up.Location = new Point(231, 124);
    ((F_NestPartAdd) obj0).btn_up.Margin = new Padding(4);
    ((F_NestPartAdd) obj0).btn_up.Name = "btn_up";
    ((F_NestPartAdd) obj0).btn_up.Size = new Size(107, 38);
    ((F_NestPartAdd) obj0).btn_up.TabIndex = 98;
    ((F_NestPartAdd) obj0).btn_up.Text = "Up";
    ((F_NestPartAdd) obj0).btn_up.TextAlign = ContentAlignment.MiddleRight;
    ((F_NestPartAdd) obj0).btn_up.Click += new EventHandler(((F_RoboticSurfacePoints) obj0).\u0001);
    ((F_NestPartAdd) obj0).\u0002.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC16.ImageStream");
    ((F_NestPartAdd) obj0).\u0002.TransparentColor = Color.Transparent;
    ((F_NestPartAdd) obj0).\u0002.Images.SetKeyName(0, "update7.ico");
    ((F_NestPartAdd) obj0).\u0001.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_NestPartAdd) obj0).\u0001.FormattingEnabled = true;
    ((F_NestPartAdd) obj0).\u0001.Location = new Point(8, 7);
    ((F_NestPartAdd) obj0).\u0001.Name = "lst_order";
    ((F_NestPartAdd) obj0).\u0001.Size = new Size(212, 208 /*0xD0*/);
    ((F_NestPartAdd) obj0).\u0001.TabIndex = 107;
    obj0.AutoScaleMode = AutoScaleMode.None;
    obj0.ClientSize = new Size(343, 261);
    obj0.Controls.Add((Control) ((F_NestPartAdd) obj0).\u0001);
    obj0.Controls.Add((Control) ((F_NestPartAdd) obj0).btn_up);
    obj0.Controls.Add((Control) ((F_NestPartAdd) obj0).btn_down);
    obj0.Controls.Add((Control) ((F_NestPartAdd) obj0).btn_cancel);
    obj0.Controls.Add((Control) ((F_NestPartAdd) obj0).btn_ok);
    obj0.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    obj0.MaximizeBox = false;
    obj0.Name = "F_LaserStartOrder";
    obj0.Text = "Job Order";
    obj0.FormClosing += new FormClosingEventHandler(((F_RoboticSurfacePoints) obj0).\u0001);
    obj0.ResumeLayout(false);
  }
}
