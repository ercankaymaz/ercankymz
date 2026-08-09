using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buCadCamResVer5;
using buClass;
using buControls.Controls;
using buEyeBaseVer5;

namespace MarbleCNC;

public class F_AdminSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	private IContainer components = null;

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

	public F_AdminSettings()
	{
		InitializeComponent();
	}

	private void btn_ok_Click(object sender, EventArgs e)
	{
	}

	public void InitVisual()
	{
		FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
		if (fileInfo.Exists)
		{
			Control.ControlCollection controlCollection = null;
			controlCollection = buGround1.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
		}
		PropertiesForm.VisualUpdated = true;
	}

	public void LoadLanguage()
	{
		buGround1.Text = buLangTranslate.preDef.Admin + " " + buLangTranslate.preDef.Setting;
		btn_techniciandefine.Text = buLangTranslate.preDef.Technician + " " + buLangTranslate.preDef.Define;
		btn_userdefine.Text = buLangTranslate.preDef.User + " " + buLangTranslate.preDef.Define;
		btn_counters.Text = buLangTranslate.preDef.Counters;
		btn_ioconfig.Text = buLangTranslate.preDef.Input + " " + buLangTranslate.preDef.Output + " " + buLangTranslate.preDef.Configuration;
		btn_loadbackup.Text = buLangTranslate.preDef.BackUp + " " + buLangTranslate.preDef.Open;
		btn_userinterfacesettings.Text = buLangTranslate.preDef.User + " " + buLangTranslate.preDef.Interface + " " + buLangTranslate.preDef.Settings;
		btn_debug.Text = buLangTranslate.preDef.Debug;
		btn_watch.Text = buLangTranslate.preDef.Watch;
		btn_language.Text = buLangTranslate.preDef.Language;
		if (clsVar.varRuntime.Language == 0)
		{
			FileInfo fileInfo = new FileInfo(AppPath.ImageFlag + "\\En.ico");
			if (fileInfo.Exists)
			{
				btn_language.Image = Image.FromFile(fileInfo.FullName);
			}
		}
		if (clsVar.varRuntime.Language == 1)
		{
			FileInfo fileInfo2 = new FileInfo(AppPath.ImageFlag + "\\TR.ico");
			if (fileInfo2.Exists)
			{
				btn_language.Image = Image.FromFile(fileInfo2.FullName);
			}
		}
		if (clsVar.varRuntime.Language == 2)
		{
			FileInfo fileInfo3 = new FileInfo(AppPath.ImageFlag + "\\Ch.ico");
			if (fileInfo3.Exists)
			{
				btn_language.Image = Image.FromFile(fileInfo3.FullName);
			}
		}
	}

	private void btn_cancel_Click(object sender, EventArgs e)
	{
		base.Visible = false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarbleCNC.F_AdminSettings));
		this.buGround1 = new buControls.Controls.buGround();
		this.btn_ioconfig = new buControls.Controls.buButton();
		this.btn_userinterfacesettings = new buControls.Controls.buButton();
		this.btn_loadbackup = new buControls.Controls.buButton();
		this.btn_watch = new buControls.Controls.buButton();
		this.btn_language = new buControls.Controls.buButton();
		this.btn_counters = new buControls.Controls.buButton();
		this.btn_debug = new buControls.Controls.buButton();
		this.btn_techniciandefine = new buControls.Controls.buButton();
		this.btn_userdefine = new buControls.Controls.buButton();
		this.btn_cancel = new buControls.Controls.buButton();
		this.buGround1.SuspendLayout();
		base.SuspendLayout();
		this.buGround1.AuxInfo = null;
		this.buGround1.BackColor = System.Drawing.Color.Transparent;
		this.buGround1.Controls.Add(this.btn_cancel);
		this.buGround1.Controls.Add(this.btn_ioconfig);
		this.buGround1.Controls.Add(this.btn_userinterfacesettings);
		this.buGround1.Controls.Add(this.btn_loadbackup);
		this.buGround1.Controls.Add(this.btn_watch);
		this.buGround1.Controls.Add(this.btn_language);
		this.buGround1.Controls.Add(this.btn_counters);
		this.buGround1.Controls.Add(this.btn_debug);
		this.buGround1.Controls.Add(this.btn_techniciandefine);
		this.buGround1.Controls.Add(this.btn_userdefine);
		this.buGround1.ControlStyle = buControls.Controls.ControlStyle.Base4;
		this.buGround1.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.buGround1.Display.GradientType = buControls.Controls.GradientMode.Lineer;
		this.buGround1.Display.LineerGradient.FirstColor = System.Drawing.Color.Black;
		this.buGround1.DisplayBottom.BackColor = System.Drawing.Color.Gray;
		this.buGround1.DisplayTop.BackColor = System.Drawing.Color.DimGray;
		this.buGround1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.buGround1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.buGround1.Ground.TopHeight = 50;
		this.buGround1.Image = null;
		this.buGround1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.buGround1.Location = new System.Drawing.Point(0, 0);
		this.buGround1.Name = "buGround1";
		this.buGround1.Sizable = true;
		this.buGround1.Size = new System.Drawing.Size(597, 500);
		this.buGround1.SmartBounds = true;
		this.buGround1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.buGround1.TabIndex = 1;
		this.buGround1.Text = "Admin Settings";
		this.btn_ioconfig.BackColor = System.Drawing.Color.Transparent;
		this.btn_ioconfig.ButtonCopy = false;
		this.btn_ioconfig.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_ioconfig.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_ioconfig.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_ioconfig.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_ioconfig.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_ioconfig.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_ioconfig.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_ioconfig.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_ioconfig.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_ioconfig.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_ioconfig.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_ioconfig.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_ioconfig.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_ioconfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_ioconfig.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_ioconfig.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_ioconfig.Image = (System.Drawing.Image)resources.GetObject("btn_ioconfig.Image");
		this.btn_ioconfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_ioconfig.Location = new System.Drawing.Point(304, 407);
		this.btn_ioconfig.Name = "btn_ioconfig";
		this.btn_ioconfig.Size = new System.Drawing.Size(280, 75);
		this.btn_ioconfig.TabIndex = 597;
		this.btn_ioconfig.Text = "IO Config";
		this.btn_ioconfig.UseMnemonic = false;
		this.btn_userinterfacesettings.BackColor = System.Drawing.Color.Transparent;
		this.btn_userinterfacesettings.ButtonCopy = false;
		this.btn_userinterfacesettings.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_userinterfacesettings.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_userinterfacesettings.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_userinterfacesettings.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userinterfacesettings.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_userinterfacesettings.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_userinterfacesettings.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_userinterfacesettings.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userinterfacesettings.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_userinterfacesettings.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_userinterfacesettings.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_userinterfacesettings.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_userinterfacesettings.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userinterfacesettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_userinterfacesettings.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userinterfacesettings.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_userinterfacesettings.Image = (System.Drawing.Image)resources.GetObject("btn_userinterfacesettings.Image");
		this.btn_userinterfacesettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_userinterfacesettings.Location = new System.Drawing.Point(304, 321);
		this.btn_userinterfacesettings.Name = "btn_userinterfacesettings";
		this.btn_userinterfacesettings.Size = new System.Drawing.Size(280, 75);
		this.btn_userinterfacesettings.TabIndex = 596;
		this.btn_userinterfacesettings.Text = "User Interface Settings";
		this.btn_userinterfacesettings.UseMnemonic = false;
		this.btn_loadbackup.BackColor = System.Drawing.Color.Transparent;
		this.btn_loadbackup.ButtonCopy = false;
		this.btn_loadbackup.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_loadbackup.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_loadbackup.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_loadbackup.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_loadbackup.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_loadbackup.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_loadbackup.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_loadbackup.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_loadbackup.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_loadbackup.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_loadbackup.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_loadbackup.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_loadbackup.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_loadbackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_loadbackup.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_loadbackup.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_loadbackup.Image = (System.Drawing.Image)resources.GetObject("btn_loadbackup.Image");
		this.btn_loadbackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_loadbackup.Location = new System.Drawing.Point(12, 321);
		this.btn_loadbackup.Name = "btn_loadbackup";
		this.btn_loadbackup.Size = new System.Drawing.Size(280, 75);
		this.btn_loadbackup.TabIndex = 595;
		this.btn_loadbackup.Text = "Load Backup";
		this.btn_loadbackup.UseMnemonic = false;
		this.btn_watch.BackColor = System.Drawing.Color.Transparent;
		this.btn_watch.ButtonCopy = false;
		this.btn_watch.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_watch.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_watch.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_watch.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_watch.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_watch.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_watch.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_watch.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_watch.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_watch.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_watch.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_watch.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_watch.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_watch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_watch.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_watch.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_watch.Image = (System.Drawing.Image)resources.GetObject("btn_watch.Image");
		this.btn_watch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_watch.Location = new System.Drawing.Point(304, 235);
		this.btn_watch.Name = "btn_watch";
		this.btn_watch.Size = new System.Drawing.Size(280, 75);
		this.btn_watch.TabIndex = 594;
		this.btn_watch.Text = "Watch";
		this.btn_watch.UseMnemonic = false;
		this.btn_language.BackColor = System.Drawing.Color.Transparent;
		this.btn_language.ButtonCopy = false;
		this.btn_language.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_language.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_language.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_language.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_language.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_language.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_language.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_language.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_language.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_language.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_language.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_language.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_language.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_language.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_language.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_language.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_language.Image = (System.Drawing.Image)resources.GetObject("btn_language.Image");
		this.btn_language.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_language.Location = new System.Drawing.Point(12, 235);
		this.btn_language.Name = "btn_language";
		this.btn_language.Size = new System.Drawing.Size(280, 75);
		this.btn_language.TabIndex = 593;
		this.btn_language.Text = "Language";
		this.btn_language.UseMnemonic = false;
		this.btn_counters.BackColor = System.Drawing.Color.Transparent;
		this.btn_counters.ButtonCopy = false;
		this.btn_counters.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_counters.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_counters.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_counters.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_counters.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_counters.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_counters.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_counters.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_counters.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_counters.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_counters.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_counters.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_counters.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_counters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_counters.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_counters.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_counters.Image = (System.Drawing.Image)resources.GetObject("btn_counters.Image");
		this.btn_counters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_counters.Location = new System.Drawing.Point(304, 148);
		this.btn_counters.Name = "btn_counters";
		this.btn_counters.Size = new System.Drawing.Size(280, 75);
		this.btn_counters.TabIndex = 592;
		this.btn_counters.Text = "Counters";
		this.btn_counters.UseMnemonic = false;
		this.btn_debug.BackColor = System.Drawing.Color.Transparent;
		this.btn_debug.ButtonCopy = false;
		this.btn_debug.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_debug.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_debug.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_debug.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_debug.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_debug.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_debug.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_debug.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_debug.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_debug.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_debug.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_debug.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_debug.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_debug.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_debug.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_debug.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_debug.Image = (System.Drawing.Image)resources.GetObject("btn_debug.Image");
		this.btn_debug.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_debug.Location = new System.Drawing.Point(12, 148);
		this.btn_debug.Name = "btn_debug";
		this.btn_debug.Size = new System.Drawing.Size(280, 75);
		this.btn_debug.TabIndex = 580;
		this.btn_debug.Text = "Service";
		this.btn_debug.UseMnemonic = false;
		this.btn_techniciandefine.BackColor = System.Drawing.Color.Transparent;
		this.btn_techniciandefine.ButtonCopy = false;
		this.btn_techniciandefine.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_techniciandefine.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_techniciandefine.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_techniciandefine.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_techniciandefine.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_techniciandefine.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_techniciandefine.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_techniciandefine.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_techniciandefine.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_techniciandefine.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_techniciandefine.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_techniciandefine.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_techniciandefine.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_techniciandefine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_techniciandefine.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_techniciandefine.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_techniciandefine.Image = (System.Drawing.Image)resources.GetObject("btn_techniciandefine.Image");
		this.btn_techniciandefine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_techniciandefine.Location = new System.Drawing.Point(304, 61);
		this.btn_techniciandefine.Name = "btn_techniciandefine";
		this.btn_techniciandefine.Size = new System.Drawing.Size(280, 75);
		this.btn_techniciandefine.TabIndex = 579;
		this.btn_techniciandefine.Text = "Technician Define";
		this.btn_techniciandefine.UseMnemonic = false;
		this.btn_userdefine.BackColor = System.Drawing.Color.Transparent;
		this.btn_userdefine.ButtonCopy = false;
		this.btn_userdefine.ButtonDownDisplay.BackColor = System.Drawing.Color.Gold;
		this.btn_userdefine.ButtonDownDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_userdefine.ButtonDownDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_userdefine.ButtonDownDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userdefine.ButtonOverDisplay.BackColor = System.Drawing.Color.Gainsboro;
		this.btn_userdefine.ButtonOverDisplay.Border.Color = System.Drawing.Color.Black;
		this.btn_userdefine.ButtonOverDisplay.Fonts.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold);
		this.btn_userdefine.ButtonOverDisplay.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userdefine.ControlStyle = buControls.Controls.ControlStyle.Menu4;
		this.btn_userdefine.Display.BackColor = System.Drawing.Color.PeachPuff;
		this.btn_userdefine.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_userdefine.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.btn_userdefine.Display.Fonts.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userdefine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_userdefine.ForeColor = System.Drawing.Color.FromArgb(0, 27, 72);
		this.btn_userdefine.Geometry.ShapeMode = buControls.Controls.ShapeType.Arc;
		this.btn_userdefine.Image = (System.Drawing.Image)resources.GetObject("btn_userdefine.Image");
		this.btn_userdefine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_userdefine.Location = new System.Drawing.Point(12, 61);
		this.btn_userdefine.Name = "btn_userdefine";
		this.btn_userdefine.Size = new System.Drawing.Size(280, 75);
		this.btn_userdefine.TabIndex = 566;
		this.btn_userdefine.Text = "User Define";
		this.btn_userdefine.UseMnemonic = false;
		this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btn_cancel.BackColor = System.Drawing.Color.DimGray;
		this.btn_cancel.ButtonCopy = false;
		this.btn_cancel.ButtonDownDisplay.BackColor = System.Drawing.Color.Silver;
		this.btn_cancel.ButtonOverDisplay.BackColor = System.Drawing.Color.Gray;
		this.btn_cancel.ControlStyle = buControls.Controls.ControlStyle.FormButton;
		this.btn_cancel.Display.BackColor = System.Drawing.Color.DimGray;
		this.btn_cancel.Display.Border.Color = System.Drawing.Color.Black;
		this.btn_cancel.Display.Border.Visible = false;
		this.btn_cancel.Display.Fonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.btn_cancel.Image = (System.Drawing.Image)resources.GetObject("btn_cancel.Image");
		this.btn_cancel.Location = new System.Drawing.Point(543, 0);
		this.btn_cancel.Margin = new System.Windows.Forms.Padding(4);
		this.btn_cancel.Name = "btn_cancel";
		this.btn_cancel.Size = new System.Drawing.Size(54, 50);
		this.btn_cancel.TabIndex = 598;
		this.btn_cancel.UseMnemonic = false;
		this.btn_cancel.Click += new System.EventHandler(btn_cancel_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(597, 500);
		base.Controls.Add(this.buGround1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "F_AdminSettings";
		this.Text = "Menu";
		this.buGround1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
