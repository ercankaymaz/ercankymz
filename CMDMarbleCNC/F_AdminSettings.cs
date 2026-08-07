// Decompiled with JetBrains decompiler
// Type: MarbleCNC.F_AdminSettings
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using buCadCamResVer5;
using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace MarbleCNC;

public class F_AdminSettings : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer components = (IContainer) null;
  private buGround buGround1;
  public buButton btn_userdefine;
  public buButton btn_techniciandefine;
  public buButton btn_debug;
  public buButton btn_counters;
  public buButton btn_language;
  public buButton btn_watch;
  public buButton btn_loadbackup;
  public buButton btn_userinterfacesettings;
  public buButton btn_ioconfig;
  public buButton btn_cancel;

  public F_AdminSettings() => this.InitializeComponent();

  private void btn_ok_Click(object sender, EventArgs e)
  {
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = hmiUICommands.SetVisualItem(this.buGround1.Controls);
    }
    this.PropertiesForm.VisualUpdated = true;
  }

  public void LoadLanguage()
  {
    this.buGround1.Text = $"{buLangTranslate.preDef.Admin} {buLangTranslate.preDef.Setting}";
    this.btn_techniciandefine.Text = $"{buLangTranslate.preDef.Technician} {buLangTranslate.preDef.Define}";
    this.btn_userdefine.Text = $"{buLangTranslate.preDef.User} {buLangTranslate.preDef.Define}";
    this.btn_counters.Text = buLangTranslate.preDef.Counters;
    this.btn_ioconfig.Text = $"{buLangTranslate.preDef.Input} {buLangTranslate.preDef.Output} {buLangTranslate.preDef.Configuration}";
    this.btn_loadbackup.Text = $"{buLangTranslate.preDef.BackUp} {buLangTranslate.preDef.Open}";
    this.btn_userinterfacesettings.Text = $"{buLangTranslate.preDef.User} {buLangTranslate.preDef.Interface} {buLangTranslate.preDef.Settings}";
    this.btn_debug.Text = buLangTranslate.preDef.Debug;
    this.btn_watch.Text = buLangTranslate.preDef.Watch;
    this.btn_language.Text = buLangTranslate.preDef.Language;
    if (clsVar.varRuntime.Language == 0)
    {
      FileInfo fileInfo = new FileInfo(AppPath.ImageFlag + "\\En.ico");
      if (fileInfo.Exists)
        this.btn_language.Image = Image.FromFile(fileInfo.FullName);
    }
    if (clsVar.varRuntime.Language == 1)
    {
      FileInfo fileInfo = new FileInfo(AppPath.ImageFlag + "\\TR.ico");
      if (fileInfo.Exists)
        this.btn_language.Image = Image.FromFile(fileInfo.FullName);
    }
    if (clsVar.varRuntime.Language != 2)
      return;
    FileInfo fileInfo1 = new FileInfo(AppPath.ImageFlag + "\\Ch.ico");
    if (fileInfo1.Exists)
      this.btn_language.Image = Image.FromFile(fileInfo1.FullName);
  }

  private void btn_cancel_Click(object sender, EventArgs e) => this.Visible = false;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_AdminSettings));
    this.buGround1 = new buGround();
    this.btn_ioconfig = new buButton();
    this.btn_userinterfacesettings = new buButton();
    this.btn_loadbackup = new buButton();
    this.btn_watch = new buButton();
    this.btn_language = new buButton();
    this.btn_counters = new buButton();
    this.btn_debug = new buButton();
    this.btn_techniciandefine = new buButton();
    this.btn_userdefine = new buButton();
    this.btn_cancel = new buButton();
    this.buGround1.SuspendLayout();
    this.SuspendLayout();
    this.buGround1.AuxInfo = (string) null;
    this.buGround1.BackColor = Color.Transparent;
    this.buGround1.Controls.Add((Control) this.btn_cancel);
    this.buGround1.Controls.Add((Control) this.btn_ioconfig);
    this.buGround1.Controls.Add((Control) this.btn_userinterfacesettings);
    this.buGround1.Controls.Add((Control) this.btn_loadbackup);
    this.buGround1.Controls.Add((Control) this.btn_watch);
    this.buGround1.Controls.Add((Control) this.btn_language);
    this.buGround1.Controls.Add((Control) this.btn_counters);
    this.buGround1.Controls.Add((Control) this.btn_debug);
    this.buGround1.Controls.Add((Control) this.btn_techniciandefine);
    this.buGround1.Controls.Add((Control) this.btn_userdefine);
    this.buGround1.ControlStyle = ControlStyle.Base4;
    this.buGround1.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10f);
    this.buGround1.Display.GradientType = GradientMode.Lineer;
    this.buGround1.Display.LineerGradient.FirstColor = Color.Black;
    this.buGround1.DisplayBottom.BackColor = Color.Gray;
    this.buGround1.DisplayTop.BackColor = Color.DimGray;
    this.buGround1.Dock = DockStyle.Fill;
    this.buGround1.Font = new Font("Microsoft Sans Serif", 10f);
    this.buGround1.Ground.TopHeight = 50;
    this.buGround1.Image = (Image) null;
    this.buGround1.ImageAlign = ContentAlignment.MiddleLeft;
    this.buGround1.Location = new Point(0, 0);
    this.buGround1.Name = "buGround1";
    this.buGround1.Sizable = true;
    this.buGround1.Size = new Size(597, 500);
    this.buGround1.SmartBounds = true;
    this.buGround1.StartPosition = FormStartPosition.Manual;
    this.buGround1.TabIndex = 1;
    this.buGround1.Text = "Admin Settings";
    this.btn_ioconfig.BackColor = Color.Transparent;
    this.btn_ioconfig.ButtonCopy = false;
    this.btn_ioconfig.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_ioconfig.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_ioconfig.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_ioconfig.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_ioconfig.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_ioconfig.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_ioconfig.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_ioconfig.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_ioconfig.ControlStyle = ControlStyle.Menu4;
    this.btn_ioconfig.Display.BackColor = Color.PeachPuff;
    this.btn_ioconfig.Display.Border.Color = Color.Black;
    this.btn_ioconfig.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_ioconfig.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_ioconfig.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_ioconfig.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_ioconfig.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_ioconfig.Image = (Image) componentResourceManager.GetObject("btn_ioconfig.Image");
    this.btn_ioconfig.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_ioconfig.Location = new Point(304, 407);
    this.btn_ioconfig.Name = "btn_ioconfig";
    this.btn_ioconfig.Size = new Size(280, 75);
    this.btn_ioconfig.TabIndex = 597;
    this.btn_ioconfig.Text = "IO Config";
    this.btn_ioconfig.UseMnemonic = false;
    this.btn_userinterfacesettings.BackColor = Color.Transparent;
    this.btn_userinterfacesettings.ButtonCopy = false;
    this.btn_userinterfacesettings.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_userinterfacesettings.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_userinterfacesettings.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_userinterfacesettings.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userinterfacesettings.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_userinterfacesettings.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_userinterfacesettings.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_userinterfacesettings.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userinterfacesettings.ControlStyle = ControlStyle.Menu4;
    this.btn_userinterfacesettings.Display.BackColor = Color.PeachPuff;
    this.btn_userinterfacesettings.Display.Border.Color = Color.Black;
    this.btn_userinterfacesettings.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_userinterfacesettings.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userinterfacesettings.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_userinterfacesettings.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userinterfacesettings.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_userinterfacesettings.Image = (Image) componentResourceManager.GetObject("btn_userinterfacesettings.Image");
    this.btn_userinterfacesettings.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_userinterfacesettings.Location = new Point(304, 321);
    this.btn_userinterfacesettings.Name = "btn_userinterfacesettings";
    this.btn_userinterfacesettings.Size = new Size(280, 75);
    this.btn_userinterfacesettings.TabIndex = 596;
    this.btn_userinterfacesettings.Text = "User Interface Settings";
    this.btn_userinterfacesettings.UseMnemonic = false;
    this.btn_loadbackup.BackColor = Color.Transparent;
    this.btn_loadbackup.ButtonCopy = false;
    this.btn_loadbackup.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_loadbackup.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_loadbackup.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_loadbackup.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_loadbackup.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_loadbackup.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_loadbackup.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_loadbackup.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_loadbackup.ControlStyle = ControlStyle.Menu4;
    this.btn_loadbackup.Display.BackColor = Color.PeachPuff;
    this.btn_loadbackup.Display.Border.Color = Color.Black;
    this.btn_loadbackup.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_loadbackup.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_loadbackup.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_loadbackup.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_loadbackup.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_loadbackup.Image = (Image) componentResourceManager.GetObject("btn_loadbackup.Image");
    this.btn_loadbackup.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_loadbackup.Location = new Point(12, 321);
    this.btn_loadbackup.Name = "btn_loadbackup";
    this.btn_loadbackup.Size = new Size(280, 75);
    this.btn_loadbackup.TabIndex = 595;
    this.btn_loadbackup.Text = "Load Backup";
    this.btn_loadbackup.UseMnemonic = false;
    this.btn_watch.BackColor = Color.Transparent;
    this.btn_watch.ButtonCopy = false;
    this.btn_watch.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_watch.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_watch.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_watch.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_watch.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_watch.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_watch.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_watch.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_watch.ControlStyle = ControlStyle.Menu4;
    this.btn_watch.Display.BackColor = Color.PeachPuff;
    this.btn_watch.Display.Border.Color = Color.Black;
    this.btn_watch.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_watch.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_watch.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_watch.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_watch.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_watch.Image = (Image) componentResourceManager.GetObject("btn_watch.Image");
    this.btn_watch.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_watch.Location = new Point(304, 235);
    this.btn_watch.Name = "btn_watch";
    this.btn_watch.Size = new Size(280, 75);
    this.btn_watch.TabIndex = 594;
    this.btn_watch.Text = "Watch";
    this.btn_watch.UseMnemonic = false;
    this.btn_language.BackColor = Color.Transparent;
    this.btn_language.ButtonCopy = false;
    this.btn_language.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_language.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_language.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_language.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_language.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_language.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_language.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_language.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_language.ControlStyle = ControlStyle.Menu4;
    this.btn_language.Display.BackColor = Color.PeachPuff;
    this.btn_language.Display.Border.Color = Color.Black;
    this.btn_language.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_language.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_language.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_language.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_language.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_language.Image = (Image) componentResourceManager.GetObject("btn_language.Image");
    this.btn_language.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_language.Location = new Point(12, 235);
    this.btn_language.Name = "btn_language";
    this.btn_language.Size = new Size(280, 75);
    this.btn_language.TabIndex = 593;
    this.btn_language.Text = "Language";
    this.btn_language.UseMnemonic = false;
    this.btn_counters.BackColor = Color.Transparent;
    this.btn_counters.ButtonCopy = false;
    this.btn_counters.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_counters.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_counters.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_counters.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_counters.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_counters.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_counters.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_counters.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_counters.ControlStyle = ControlStyle.Menu4;
    this.btn_counters.Display.BackColor = Color.PeachPuff;
    this.btn_counters.Display.Border.Color = Color.Black;
    this.btn_counters.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_counters.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_counters.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_counters.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_counters.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_counters.Image = (Image) componentResourceManager.GetObject("btn_counters.Image");
    this.btn_counters.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_counters.Location = new Point(304, 148);
    this.btn_counters.Name = "btn_counters";
    this.btn_counters.Size = new Size(280, 75);
    this.btn_counters.TabIndex = 592;
    this.btn_counters.Text = "Counters";
    this.btn_counters.UseMnemonic = false;
    this.btn_debug.BackColor = Color.Transparent;
    this.btn_debug.ButtonCopy = false;
    this.btn_debug.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_debug.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_debug.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_debug.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_debug.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_debug.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_debug.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_debug.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_debug.ControlStyle = ControlStyle.Menu4;
    this.btn_debug.Display.BackColor = Color.PeachPuff;
    this.btn_debug.Display.Border.Color = Color.Black;
    this.btn_debug.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_debug.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_debug.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_debug.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_debug.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_debug.Image = (Image) componentResourceManager.GetObject("btn_debug.Image");
    this.btn_debug.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_debug.Location = new Point(12, 148);
    this.btn_debug.Name = "btn_debug";
    this.btn_debug.Size = new Size(280, 75);
    this.btn_debug.TabIndex = 580;
    this.btn_debug.Text = "Service";
    this.btn_debug.UseMnemonic = false;
    this.btn_techniciandefine.BackColor = Color.Transparent;
    this.btn_techniciandefine.ButtonCopy = false;
    this.btn_techniciandefine.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_techniciandefine.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_techniciandefine.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_techniciandefine.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_techniciandefine.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_techniciandefine.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_techniciandefine.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_techniciandefine.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_techniciandefine.ControlStyle = ControlStyle.Menu4;
    this.btn_techniciandefine.Display.BackColor = Color.PeachPuff;
    this.btn_techniciandefine.Display.Border.Color = Color.Black;
    this.btn_techniciandefine.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_techniciandefine.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_techniciandefine.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_techniciandefine.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_techniciandefine.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_techniciandefine.Image = (Image) componentResourceManager.GetObject("btn_techniciandefine.Image");
    this.btn_techniciandefine.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_techniciandefine.Location = new Point(304, 61);
    this.btn_techniciandefine.Name = "btn_techniciandefine";
    this.btn_techniciandefine.Size = new Size(280, 75);
    this.btn_techniciandefine.TabIndex = 579;
    this.btn_techniciandefine.Text = "Technician Define";
    this.btn_techniciandefine.UseMnemonic = false;
    this.btn_userdefine.BackColor = Color.Transparent;
    this.btn_userdefine.ButtonCopy = false;
    this.btn_userdefine.ButtonDownDisplay.BackColor = Color.Gold;
    this.btn_userdefine.ButtonDownDisplay.Border.Color = Color.Black;
    this.btn_userdefine.ButtonDownDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_userdefine.ButtonDownDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userdefine.ButtonOverDisplay.BackColor = Color.Gainsboro;
    this.btn_userdefine.ButtonOverDisplay.Border.Color = Color.Black;
    this.btn_userdefine.ButtonOverDisplay.Fonts.Font = new Font("Arial", 11.25f, FontStyle.Bold);
    this.btn_userdefine.ButtonOverDisplay.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userdefine.ControlStyle = ControlStyle.Menu4;
    this.btn_userdefine.Display.BackColor = Color.PeachPuff;
    this.btn_userdefine.Display.Border.Color = Color.Black;
    this.btn_userdefine.Display.Fonts.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.btn_userdefine.Display.Fonts.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userdefine.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_userdefine.ForeColor = Color.FromArgb(0, 27, 72);
    this.btn_userdefine.Geometry.ShapeMode = ShapeType.Arc;
    this.btn_userdefine.Image = (Image) componentResourceManager.GetObject("btn_userdefine.Image");
    this.btn_userdefine.ImageAlign = ContentAlignment.MiddleLeft;
    this.btn_userdefine.Location = new Point(12, 61);
    this.btn_userdefine.Name = "btn_userdefine";
    this.btn_userdefine.Size = new Size(280, 75);
    this.btn_userdefine.TabIndex = 566;
    this.btn_userdefine.Text = "User Define";
    this.btn_userdefine.UseMnemonic = false;
    this.btn_cancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btn_cancel.BackColor = Color.DimGray;
    this.btn_cancel.ButtonCopy = false;
    this.btn_cancel.ButtonDownDisplay.BackColor = Color.Silver;
    this.btn_cancel.ButtonOverDisplay.BackColor = Color.Gray;
    this.btn_cancel.ControlStyle = ControlStyle.FormButton;
    this.btn_cancel.Display.BackColor = Color.DimGray;
    this.btn_cancel.Display.Border.Color = Color.Black;
    this.btn_cancel.Display.Border.Visible = false;
    this.btn_cancel.Display.Fonts.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_cancel.Font = new Font("Microsoft Sans Serif", 10f);
    this.btn_cancel.Image = (Image) componentResourceManager.GetObject("btn_cancel.Image");
    this.btn_cancel.Location = new Point(543, 0);
    this.btn_cancel.Margin = new Padding(4);
    this.btn_cancel.Name = "btn_cancel";
    this.btn_cancel.Size = new Size(54, 50);
    this.btn_cancel.TabIndex = 598;
    this.btn_cancel.UseMnemonic = false;
    this.btn_cancel.Click += new EventHandler(this.btn_cancel_Click);
    this.AutoScaleMode = AutoScaleMode.None;
    this.ClientSize = new Size(597, 500);
    this.Controls.Add((Control) this.buGround1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (F_AdminSettings);
    this.Text = "Menu";
    this.buGround1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
