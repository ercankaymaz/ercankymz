using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using buCadCamResVer5;
using buCadCamResVer5.Marble;
using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.buEntities;
using buHandler;
using buMarble;
using buMotion;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace MarbleCNC.Machines;

public class clsMachine2_Ozteknik
{
	private Point3D pntActive = new Point3D();

	private bool Inited = false;

	private string sClass = "clsMachine1_5Axis";

	private clsAppMarbleVars cMarbleVars = null;

	public const int indexMainTab = 0;

	public const int indexManuelTab = 1;

	public const int indexSawModeTab = 2;

	public const int indexOpertionTab = 3;

	private Color clrRed = Color.FromArgb(255, 187, 30, 16);

	private Color clrWhite = Color.FromArgb(255, 241, 240, 234);

	private Color clrBlack = Color.FromArgb(255, 14, 14, 16);

	private Color clrGray = Color.FromArgb(255, 56, 62, 66);

	private Color clrGrayLight = Color.FromArgb(255, 100, 110, 120);

	private Color clrFontColorWhite = Color.WhiteSmoke;

	private Color clrBackLabelCaption = Color.FromArgb(255, 241, 240, 234);

	private Color clrForeLabelCaption = Color.Black;

	public void AppMarbleClassInit()
	{
		clsAppMarbleVars.cmdMarble.InitAxesString();
		if (cMarbleVars == null)
		{
			cMarbleVars = new clsAppMarbleVars();
			cMarbleVars.Init();
		}
	}

	public void SystemInit()
	{
		string text = "SystemInit";
		try
		{
			AppMarbleClassInit();
			CodesysMachine.CommType = CommunicationType.PlcHandler;
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "SystemInit");
			clsInit.appMarble.Init();
			clsAppMarbleVars.cmdMarble.Init();
			clsAppMarbleVars.cmdMarble.InitSystem();
			AssingControls();
			AddControls();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "AddControls");
			UpdateVisualThings();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "UpdateVisualThings");
			clsAppMarbleVars.cmdMarble.CommandHMI += CommandHMI;
			clsInit.appMarble.SimUpdated += clsAppMarbleVars.cmdMarble.SimUpdated;
			clsInit.appMarble.MarbleCoreHMICommand += MarbleCoreCommends;
			clsInit.cMwCalc.Settings.ShowMwDialogBox = false;
			clsItem.FrmMach2.KeyPreview = true;
			clsItem.FrmMach2.KeyDown += FormKeyDown;
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "Move Controls");
			buMarbleForms.frmHorizontalV4.pnl_data.Height = clsItem.FrmMach2.pnl_hordata.Height;
			clsItem.FrmMach2.pnl_hordata.Controls.Add(buMarbleForms.frmHorizontalV4.pnl_data);
			buMarbleForms.frmVerticalV4.pnl_data.Height = clsItem.FrmMach2.pnl_verdata.Height;
			clsItem.FrmMach2.pnl_verdata.Controls.Add(buMarbleForms.frmVerticalV4.pnl_data);
			buMarbleForms.frmHorVerHorV4.pnl_data.Height = clsItem.FrmMach2.tabPage_Hor.Height;
			clsItem.FrmMach2.tabPage_Hor.Controls.Add(buMarbleForms.frmHorVerHorV4.pnl_data);
			buMarbleForms.frmHorVerVerV4.pnl_data.Height = clsItem.FrmMach2.tabPage_Ver.Height;
			clsItem.FrmMach2.tabPage_Ver.Controls.Add(buMarbleForms.frmHorVerVerV4.pnl_data);
			buMarbleForms.frmSingleV2.pnl_data.Height = clsItem.FrmMach2.pnl_singledata.Height;
			clsItem.FrmMach2.pnl_singledata.Controls.Add(buMarbleForms.frmSingleV2.pnl_data);
			clsItem.FrmMach2.pnl_drawviewport.Width = 1450;
			clsItem.FrmMach2.pnl_drawingjob.Visible = false;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "Move Controls");
			clsItem.FrmMach2.btn_menu.Click += showMenuPage;
			clsItem.FrmMenu.btn_settings.Click += showSettingsPage;
			clsItem.FrmMenu.btn_adminsettings.Click += showAdminSettingsPage;
			clsItem.FrmMenu.btn_simulationpanel.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_selectmaterial.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_closepc.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_test.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_password.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_tools.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_g54offset.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_report.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_calculations.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_maintanance.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_warmup.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenu.btn_materialmeasurement.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_settingsaxes.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_millingsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_marblecamsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_servoconnection.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_G54Offset.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_calibration.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_toolsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_vagoonsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_camerasettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuSettings.btn_cameracalibration.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_language.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_debug.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_watch.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_counters.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_techniciandefine.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_userdefine.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_loadbackup.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMenuAdminSettings.btn_userinterfacesettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_operationsettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_contoursettings.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewback.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewfront.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewiso.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewleft.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewrgiht.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewtop.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewzoomwindow.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewzoomfit.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewzoomin.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewzoomout.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewpandown.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewpanleft.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewpanright.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_viewpanup.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_information.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.btn_main.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_manuel.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_drawing.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_sawmode.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_viewmenu.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_single.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_horizontal.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_vertical.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_horver.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_semiAuto.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_photo.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_pointer.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_2DCad.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_3DCad.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_Functions.Click += clickCommandMainMenuButton;
			clsItem.FrmMach2.btn_misc.Click += clickCommandMainMenuButton;
			buMarbleForms.frmHorizontalV4.DGV_items.Tag = "Hor";
			buMarbleForms.frmHorizontalV4.chk_leftbottom.Name = buMarbleForms.frmHorizontalV4.chk_leftbottom.Name + "Hor";
			buMarbleForms.frmHorizontalV4.chk_lefttop.Name = buMarbleForms.frmHorizontalV4.chk_lefttop.Name + "Hor";
			buMarbleForms.frmHorizontalV4.chk_cutstart.Name = buMarbleForms.frmHorizontalV4.chk_cutstart.Name + "Hor";
			buMarbleForms.frmHorizontalV4.chk_cutend.Name = buMarbleForms.frmHorizontalV4.chk_cutend.Name + "Hor";
			for (int i = 0; i <= buMarbleForms.frmHorizontalV4.pnl_data.Controls.Count - 1; i++)
			{
				if (buMarbleForms.frmHorizontalV4.pnl_data.Controls[i] is buSpin)
				{
					buSpin buSpin2 = buMarbleForms.frmHorizontalV4.pnl_data.Controls[i] as buSpin;
					if (buSpin2.Aux.AuxInfo == "HorVer")
					{
						buSpin2.Aux.AuxInfo = "Hor";
						buSpin2.KeyDown += clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown;
					}
					buSpin2.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin2.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin2.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorizontalV4.pnl_data.Controls[i] is buButton)
				{
					buButton buButton2 = buMarbleForms.frmHorizontalV4.pnl_data.Controls[i] as buButton;
					buButton2.Aux.AuxInfo = "Hor";
					buButton2.Name += "Hor";
					buButton2.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
				if (buMarbleForms.frmHorizontalV4.pnl_data.Controls[i] is buCheckBox)
				{
					buCheckBox buCheckBox2 = buMarbleForms.frmHorizontalV4.pnl_data.Controls[i] as buCheckBox;
					buCheckBox2.Aux.AuxInfo = "Hor";
					buCheckBox2.Name += "Hor";
					buCheckBox2.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
			}
			buMarbleForms.frmVerticalV4.DGV_items.Tag = "Ver";
			buMarbleForms.frmVerticalV4.chk_leftbottom.Name = buMarbleForms.frmVerticalV4.chk_leftbottom.Name + "Ver";
			buMarbleForms.frmVerticalV4.chk_lefttop.Name = buMarbleForms.frmVerticalV4.chk_lefttop.Name + "Ver";
			buMarbleForms.frmVerticalV4.chk_cutstart.Name = buMarbleForms.frmVerticalV4.chk_cutstart.Name + "Ver";
			buMarbleForms.frmVerticalV4.chk_cutend.Name = buMarbleForms.frmVerticalV4.chk_cutend.Name + "Ver";
			for (int j = 0; j <= buMarbleForms.frmVerticalV4.pnl_data.Controls.Count - 1; j++)
			{
				if (buMarbleForms.frmVerticalV4.pnl_data.Controls[j] is buSpin)
				{
					buSpin buSpin3 = buMarbleForms.frmVerticalV4.pnl_data.Controls[j] as buSpin;
					if (buSpin3.Aux.AuxInfo == "HorVer")
					{
						buSpin3.Aux.AuxInfo = "Ver";
						buSpin3.KeyDown += clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown;
					}
					buSpin3.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin3.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin3.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmVerticalV4.pnl_data.Controls[j] is buButton)
				{
					buButton buButton3 = buMarbleForms.frmVerticalV4.pnl_data.Controls[j] as buButton;
					buButton3.Aux.AuxInfo = "Ver";
					buButton3.Name += "Ver";
					buButton3.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
				if (buMarbleForms.frmVerticalV4.pnl_data.Controls[j] is buCheckBox)
				{
					buCheckBox buCheckBox3 = buMarbleForms.frmVerticalV4.pnl_data.Controls[j] as buCheckBox;
					buCheckBox3.Aux.AuxInfo = "Ver";
					buCheckBox3.Name += "Ver";
					buCheckBox3.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
			}
			buMarbleForms.frmHorVerHorV4.DGV_items.Tag = "HorVerHor";
			buMarbleForms.frmHorVerHorV4.chk_leftbottom.Name = buMarbleForms.frmHorVerHorV4.chk_leftbottom.Name + "HorVerHor";
			buMarbleForms.frmHorVerHorV4.chk_lefttop.Name = buMarbleForms.frmHorVerHorV4.chk_lefttop.Name + "HorVerHor";
			buMarbleForms.frmHorVerHorV4.chk_cutstart.Name = buMarbleForms.frmHorVerHorV4.chk_cutstart.Name + "HorVerHor";
			buMarbleForms.frmHorVerHorV4.chk_cutend.Name = buMarbleForms.frmHorVerHorV4.chk_cutend.Name + "HorVerHor";
			for (int k = 0; k <= buMarbleForms.frmHorVerHorV4.pnl_data.Controls.Count - 1; k++)
			{
				if (buMarbleForms.frmHorVerHorV4.pnl_data.Controls[k] is buSpin)
				{
					buSpin buSpin4 = buMarbleForms.frmHorVerHorV4.pnl_data.Controls[k] as buSpin;
					if (buSpin4.Aux.AuxInfo == "HorVer")
					{
						buSpin4.Aux.AuxInfo = "HorVerHor";
						buSpin4.KeyDown += clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown;
					}
					buSpin4.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin4.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin4.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVerHorV4.pnl_data.Controls[k] is buButton)
				{
					buButton buButton4 = buMarbleForms.frmHorVerHorV4.pnl_data.Controls[k] as buButton;
					buButton4.Aux.AuxInfo = "HorVerHor";
					buButton4.Name += "HorVerHor";
					buButton4.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
				if (buMarbleForms.frmHorVerHorV4.pnl_data.Controls[k] is buCheckBox)
				{
					buCheckBox buCheckBox4 = buMarbleForms.frmHorVerHorV4.pnl_data.Controls[k] as buCheckBox;
					buCheckBox4.Aux.AuxInfo = "HorVerHor";
					buCheckBox4.Name += "HorVerHor";
					buCheckBox4.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
			}
			buMarbleForms.frmHorVerVerV4.DGV_items.Tag = "HorVerVer";
			buMarbleForms.frmHorVerVerV4.chk_leftbottom.Name = buMarbleForms.frmHorVerVerV4.chk_leftbottom.Name + "HorVerVer";
			buMarbleForms.frmHorVerVerV4.chk_lefttop.Name = buMarbleForms.frmHorVerVerV4.chk_lefttop.Name + "HorVerVer";
			buMarbleForms.frmHorVerVerV4.chk_cutstart.Name = buMarbleForms.frmHorVerVerV4.chk_cutstart.Name + "HorVerVer";
			buMarbleForms.frmHorVerVerV4.chk_cutend.Name = buMarbleForms.frmHorVerVerV4.chk_cutend.Name + "HorVerVer";
			for (int l = 0; l <= buMarbleForms.frmHorVerVerV4.pnl_data.Controls.Count - 1; l++)
			{
				if (buMarbleForms.frmHorVerVerV4.pnl_data.Controls[l] is buSpin)
				{
					buSpin buSpin5 = buMarbleForms.frmHorVerVerV4.pnl_data.Controls[l] as buSpin;
					if (buSpin5.Aux.AuxInfo == "HorVer")
					{
						buSpin5.Aux.AuxInfo = "HorVerVer";
						buSpin5.KeyDown += clsAppMarbleVars.cmdMarble.spn_Horitem_KeyDown;
					}
					buSpin5.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin5.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin5.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVerVerV4.pnl_data.Controls[l] is buButton)
				{
					buButton buButton5 = buMarbleForms.frmHorVerVerV4.pnl_data.Controls[l] as buButton;
					buButton5.Aux.AuxInfo = "HorVerVer";
					buButton5.Name += "HorVerVer";
					buButton5.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
				if (buMarbleForms.frmHorVerVerV4.pnl_data.Controls[l] is buCheckBox)
				{
					buCheckBox buCheckBox5 = buMarbleForms.frmHorVerVerV4.pnl_data.Controls[l] as buCheckBox;
					buCheckBox5.Aux.AuxInfo = "HorVerVer";
					buCheckBox5.Name += "HorVerVer";
					buCheckBox5.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
				}
			}
			for (int m = 0; m <= buMarbleForms.frmHorOrVerDialog.pnl_data.Controls.Count - 1; m++)
			{
				if (buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] is buSpin)
				{
					buSpin buSpin6 = buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] as buSpin;
					if (buSpin6.Aux.AuxInfo == "HorVer")
					{
						buSpin6.Aux.AuxInfo = "Hor";
						buSpin6.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorOrVerDialogValueChanged;
						buSpin6.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorOrVeritem_KeyDown;
					}
					buSpin6.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin6.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin6.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] is buButton)
				{
					buButton buButton6 = buMarbleForms.frmHorOrVerDialog.pnl_data.Controls[m] as buButton;
					buButton6.Aux.AuxInfo = "Hor";
					buButton6.Name += "Hor";
					buButton6.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click;
				}
			}
			buMarbleForms.frmHorOrVerDialog.chk_horleftbottom.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click;
			buMarbleForms.frmHorOrVerDialog.chk_horlefttop.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandHorOrVerDialog_Click;
			buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Name = buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Name + "Dialog";
			buMarbleForms.frmHorVerDialog.chk_horverlefttop.Name = buMarbleForms.frmHorVerDialog.chk_horverlefttop.Name + "Dialog";
			buMarbleForms.frmHorVerDialog.btn_itemhorverok.Name = buMarbleForms.frmHorVerDialog.btn_itemhorverok.Name + "Dialog";
			for (int n = 0; n <= buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls.Count - 1; n++)
			{
				if (buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] is buSpin)
				{
					buSpin buSpin7 = buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] as buSpin;
					if (buSpin7.Aux.AuxInfo == "Hor")
					{
						buSpin7.Aux.AuxInfo = "Hor";
						buSpin7.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorVerHorDialogValueChanged;
						buSpin7.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorVerHorDialogitem_KeyDown;
					}
					buSpin7.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin7.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin7.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] is buButton)
				{
					buButton buButton7 = buMarbleForms.frmHorVerDialog.tabPage_Hor.Controls[n] as buButton;
					buButton7.Aux.AuxInfo = "Hor";
					buButton7.Name += "Hor";
					buButton7.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			for (int num = 0; num <= buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls.Count - 1; num++)
			{
				if (buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] is buSpin)
				{
					buSpin buSpin8 = buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] as buSpin;
					if (buSpin8.Aux.AuxInfo == "Ver")
					{
						buSpin8.Aux.AuxInfo = "Ver";
						buSpin8.ValueChanged += clsAppMarbleVars.cmdMarble.spn_item_HorVerVerDialogValueChanged;
						buSpin8.KeyDown += clsAppMarbleVars.cmdMarble.spn_HorVerVerDialogitem_KeyDown;
					}
					buSpin8.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
					buSpin8.Enter += clsAppMarbleVars.cmdMarble.spn_item_Enter;
					buSpin8.Leave += clsAppMarbleVars.cmdMarble.spn_item_Leave;
				}
				if (buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] is buButton)
				{
					buButton buButton8 = buMarbleForms.frmHorVerDialog.tabPage_Ver.Controls[num] as buButton;
					buButton8.Aux.AuxInfo = "Ver";
					buButton8.Name += "Ver";
					buButton8.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
				}
			}
			buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVerDialog.chk_horverlefttop.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommand_Click;
			buMarbleForms.frmHorVerDialog.buTab1.SelectedIndexChanged += clsAppMarbleVars.cmdMarble.Tab_HorVerDialogSelectedIndexChanged;
			buMarbleForms.frmSingleV2.spn_signlecutAAngle.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
			buMarbleForms.frmSingleV2.spn_signlecutlength.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
			buMarbleForms.frmSingleV2.spn_signlecutCAngle.ValueClicked += clsAppMarbleVars.cmdMarble.spn_item_Click;
			buMarbleForms.frmSingleV2.btn_itemsinglecutok.Click += clsAppMarbleVars.cmdMarble.btn_ItemCommandV2_Click;
			clsItem.FrmMach2.btn_pointerpartpoints.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_pointersave.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_pointerslabborders.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_pointercreatematerial.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_pointercreatepart.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_pointereditdrawing.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_pointerrectmaterial.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_photodelete.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_photoget.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_photoimport.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_photodrawpart.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_photoslabborders.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_photosave.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_shape.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_library.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_contour.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_engraving.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_slices.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_profiling.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_profilecurve.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_oplist.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_text.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_sweep.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_cavity.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_tap.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_materialclean.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_saveOP.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_openOP.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_menuOP.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_move.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_rotate.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_mirror.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_scale.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_alignments.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_copy.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_copymulti.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_offset.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_slatadd.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_collopseadd.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_extend.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_break.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_vacuum.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_undo.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_eventdelete.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_eventdeleteall.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_eventdeleteall2.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_eventsetangle.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_dimensionaligned.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_dimensionlinear.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_dimensionmenu.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_dimensiondelete.Click += clickCommandsDrawing;
			clsItem.FrmMach2.btn_dimensiondeleteall.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmRotate.btn_eventRotateminus.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmRotate.btn_eventrotateplus.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmovedown.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveleft.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveright.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmMove.btn_eventmoveup.Click += clickCommandsDrawing;
			clsAppMarbleItems.frmBottomPanelV1.btn_parkpos.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_g54list.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_laser.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_parklist.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolpage.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_water.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_partzero.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_gcodemaximize.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_mdi.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_material.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_GCodeUp.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_GCodeDown.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_OPDown.Click += clickCommands;
			clsAppMarbleItems.frmBottomPanelV1.btn_OPUp.Click += clickCommands;
			clsAppMarbleItems.frmCoordsV2.btn_start.Click += clickCommands;
			clsAppMarbleItems.frmCoordsV2.btn_pause.Click += clickCommands;
			clsAppMarbleItems.frmCoordsV2.btn_reset.Click += clickCommands;
			if (clsAppMarbleItems.frmMachineSettingsV2 != null)
			{
				clsAppMarbleItems.frmMachineSettingsV2.btn_laserOnOff.Click += clickCommands;
				clsAppMarbleItems.frmMachineSettingsV2.btn_rocketdown.Click += clickCommands;
				clsAppMarbleItems.frmMachineSettingsV2.btn_rocketup.Click += clickCommands;
				clsAppMarbleItems.frmMachineSettingsV2.btn_materialmeasureUpDown.Click += clickCommands;
			}
			clsAppMarbleItems.frmCoordsV2.track_spidle.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmCoordsV2.track_operationspeed.ValueChanged += trackValueChanged;
			clsAppMarbleItems.frmCoordsV2.track_quickspeed.ValueChanged += trackValueChanged;
			clsItem.FrmMach2.btn_cancel.Click += clickCommands;
			clsItem.FrmMach2.btn_codecreate.Click += clickCommands;
			clsItem.FrmMach2.btn_codecreate2.Click += clickCommands;
			clsItem.FrmMach2.btn_A0.Click += clickCommands;
			clsItem.FrmMach2.btn_A45.Click += clickCommands;
			clsItem.FrmMach2.btn_A46.Click += clickCommands;
			clsItem.FrmMach2.btn_A90.Click += clickCommands;
			clsItem.FrmMach2.btn_c180.Click += clickCommands;
			clsItem.FrmMach2.btn_c270.Click += clickCommands;
			clsItem.FrmMach2.btn_c90.Click += clickCommands;
			clsItem.FrmMach2.btn_c0.Click += clickCommands;
			clsItem.FrmMach2.btn_a0_2.Click += clickCommands;
			clsItem.FrmMach2.btn_a45_2.Click += clickCommands;
			clsItem.FrmMach2.btn_a46_2.Click += clickCommands;
			clsItem.FrmMach2.btn_c180_2.Click += clickCommands;
			clsItem.FrmMach2.btn_c_90_2.Click += clickCommands;
			clsItem.FrmMach2.btn_c90_2.Click += clickCommands;
			clsItem.FrmMach2.btn_c0_2.Click += clickCommands;
			clsItem.FrmMach2.btn_go.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_tcp.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_gozero.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_park.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_vagonpark.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_materialmeasure.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_light.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlewarm.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_sawwarm.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_sawpark.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepark.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_spindleheadpark.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_cameraclose.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_cameraopen.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_camera.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_photopos.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_vacuumair.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_vacuumdown.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_vacuumup.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_vacuumleftpad.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_vacuumrightpad.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_stop.Click += clickCommands;
			clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmKinematic.btn_openkinematic.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsAppMarbleItems.frmKinematic.btn_savekinemtic.Click += clsAppMarbleVars.cmdMarble.clickCommandToolsKinematic;
			clsItem.FrmMenuSettings.btn_kinematic.Click += clickCommandsMenuAndSettings;
			clsItem.FrmMach2.chk_absolute.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach2.chk_incremental.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach2.chk_machinezero.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach2.chk_partzero.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach2.chk_addsawthickness.CheckedChanged += checkCheckedChanged;
			clsItem.FrmMach2.spn_xpos.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_ypos.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_zpos.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_apos.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_cpos.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.btn_xplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_yplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_zplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_aplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_cplus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_xminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_yminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_zminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_aminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_cminus.MouseDownWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseDown;
			clsItem.FrmMach2.btn_xplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_yplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_zplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_aplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_cplus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_xminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_yminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_zminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_aminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_cminus.MouseUpWithWndProc += clsAppMarbleVars.cmdMarble.Jog_MouseUp;
			clsItem.FrmMach2.btn_xplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_yplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_zplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_aplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_cplus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_xminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_yminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_zminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_aminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.btn_cminus.Click += clsAppMarbleVars.cmdMarble.Jog_Click;
			clsItem.FrmMach2.spn_camcuttingspped.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_camcuttingstep.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_cammarblethickness.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_camoperationZ.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_camplungespeed.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_camsafedis.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_camspindlespeed.ValueClicked += spinClick;
			SemiAutoParameterChange(FromControlToValues: false);
			clsItem.FrmMach2.btn_xplus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach2.btn_yplus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach2.btn_zplus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach2.btn_xminus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach2.btn_yminus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach2.btn_zminus_2.Click += clsAppMarbleVars.cmdMarble.JogSemiAuto_Click;
			clsItem.FrmMach2.btn_stopsemiauto.Click += clickCommands;
			clsItem.FrmMach2.btn_semiautoenable.Click += clickCommands;
			clsItem.FrmMach2.spn_semiautohorizontallen.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_semiautomaterialheight.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_semiautomaterialwidth.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_semiautoverticallen.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.spn_semiautohorizontallen.Leave += spinLeave;
			clsItem.FrmMach2.spn_semiautomaterialheight.Leave += spinLeave;
			clsItem.FrmMach2.spn_semiautomaterialwidth.Leave += spinLeave;
			clsItem.FrmMach2.spn_semiautoverticallen.Leave += spinLeave;
			clsItem.FrmMach2.spn_semiautohorizontallen.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_semiautomaterialheight.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_semiautomaterialwidth.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_semiautoverticallen.ValueClicked += spinClick;
			clsItem.FrmMach2.spn_semiautohorizontallen.KeyDown += spinKeyDown;
			clsItem.FrmMach2.spn_semiautomaterialheight.KeyDown += spinKeyDown;
			clsItem.FrmMach2.spn_semiautomaterialwidth.KeyDown += spinKeyDown;
			clsItem.FrmMach2.spn_semiautoverticallen.KeyDown += spinKeyDown;
			clsItem.FrmCameraLive.btn_camerastart.Click += clickCommands;
			clsItem.FrmCameraLive.btn_camerastop.Click += clickCommands;
			clsItem.FrmCameraLive.btn_cameratakeshot.Click += clickCommands;
			clsAppMarbleItems.frmMove.spn_eventmovevalue.ValueChanged += spinValueChanged;
			clsAppMarbleItems.frmRotate.spn_eventrotatevalue.ValueChanged += spinValueChanged;
			clsItem.FrmMach2.buTab_Main.SelectedIndexChanged += buTabSelectedIndexChanged;
			clsItem.FrmMach2.buTab_sawmode.SelectedIndexChanged += buTabSelectedIndexChanged;
			clsInit.appCommand.MainFormUpdate += MainFormUpdate;
			clsInit.appCommand.MainFormStatusUpdate += MainFormStatusUpdate;
			clsInit.appCommand.MainFormXYZUpdate += MainFormXYZUpdate;
			clsInit.appCommand.EntityAddToPage += PageEntityAdd;
			clsInit.appCommand.RunCommand += RunCommands;
			clsInit.appCommand.GeneralCommand += RunGeneralCommand;
			buMarbleCalc.varMarbleRunSettings.fileWood = AppPath.Base + "\\Images\\Wood\\BaseMaterial.png";
			buMarbleCalc.varMarbleRunSettings.fileMarble = AppPath.Base + "\\Images\\Marble\\MarbleBlackAndWhile.png";
			clsInit.appMarble.ViewportDialogsInit();
			clsInit.appMarble.ViewportCNCInit();
			buEyeItems.viewportCNC.MouseMove += mouseMoveViewport;
			buEyeItems.viewportCNC.MouseDown += mouseDownViewport;
			buEyeItems.viewportCNC.MouseUp += mouseUpViewport;
			clsItem.FrmMach2.pnl_mainviewport.Controls.Add(buEyeItems.viewportCNC);
			clsInit.appMarble.ViewportCadCamInit();
			clsItem.FrmMach2.pnl_horviewport.Controls.Add(buEyeItems.viewportCadCam);
			buEyeItems.viewportCadCam.ActiveViewport.Rotate.Enabled = buMarbleCalc.varMarbleRunSettings.RotateCameraCadCam;
			buVector5.baseModel = buEyeItems.viewportCadCam;
			clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelRotate;
			clsAppMarbleItems.frmMove.spn_eventmovevalue.Value = buMarbleCalc.varMarbleRunSettings.ManuelMove;
			clsItem.FrmMach2.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
			clsItem.FrmMach2.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
			clsItem.FrmMach2.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
			clsItem.FrmMach2.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
			clsItem.FrmMach2.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
			clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
			clsItem.FrmMach2.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
			clsItem.FrmMach2.chk_incremental.Check = clsAppMarbleVars.varInterface.IncrementalMode;
			clsItem.FrmMach2.chk_absolute.Check = clsAppMarbleVars.varInterface.AbsoluteMode;
			if (!clsAppMarbleVars.varInterface.PartZeroMode)
			{
				clsItem.FrmMach2.chk_machinezero.Check = true;
				clsItem.FrmMach2.chk_partzero.Check = false;
			}
			else
			{
				clsItem.FrmMach2.chk_machinezero.Check = false;
				clsItem.FrmMach2.chk_partzero.Check = true;
			}
			clsItem.FrmMach2.chk_addsawthickness.Check = clsAppMarbleVars.varInterface.AddSawThicknessToMove;
			clsItem.FrmMach2.spn_xpos.Value = clsAppMarbleVars.varInterface.JogMoveXValue;
			clsItem.FrmMach2.spn_ypos.Value = clsAppMarbleVars.varInterface.JogMoveYValue;
			clsItem.FrmMach2.spn_zpos.Value = clsAppMarbleVars.varInterface.JogMoveZValue;
			clsItem.FrmMach2.spn_apos.Value = clsAppMarbleVars.varInterface.JogMoveAValue;
			clsItem.FrmMach2.spn_cpos.Value = clsAppMarbleVars.varInterface.JogMoveCValue;
			clsAppMarbleItems.frmBottomPanelV1.lbl_material.Text = buLangTranslate.preDef.Thickness + ": " + buMarbleCalc.varOperation.MaterialParameter.MaterialThickness.ToString("f1") + Environment.NewLine + buLangTranslate.preChar.Width + ": " + buMarbleCalc.varOperation.MaterialParameter.MaterialWidth.ToString("f1") + " - " + buLangTranslate.preChar.Height + ": " + buMarbleCalc.varOperation.MaterialParameter.MaterialHeight.ToString("f1");
			buMarbleForms.frmHorizontalV4.chk_cutstart.Check = buMarbleCalc.varMarbleRunSettings.SliceHorStartCut;
			buMarbleForms.frmHorizontalV4.chk_cutend.Check = buMarbleCalc.varMarbleRunSettings.SliceHorEndCut;
			buMarbleForms.frmHorizontalV4.spn_itemlen1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalWidth;
			buMarbleForms.frmHorizontalV4.spn_itemcount1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalCount;
			buMarbleForms.frmHorizontalV4.spn_itemSA1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalStartAngle;
			buMarbleForms.frmHorizontalV4.spn_itemEA1.Value = buMarbleCalc.varMarbleRunSettings.HorizontalEndAngle;
			buMarbleForms.frmHorizontalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
			if (buMarbleCalc.varMarbleRunSettings.HorCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmHorizontalV4.chk_lefttop.Check = true;
				buMarbleForms.frmHorizontalV4.chk_leftbottom.Check = false;
			}
			else
			{
				buMarbleForms.frmHorizontalV4.chk_lefttop.Check = false;
				buMarbleForms.frmHorizontalV4.chk_leftbottom.Check = true;
			}
			buMarbleForms.frmVerticalV4.chk_cutstart.Check = buMarbleCalc.varMarbleRunSettings.SliceVerStartCut;
			buMarbleForms.frmVerticalV4.chk_cutend.Check = buMarbleCalc.varMarbleRunSettings.SliceVerEndCut;
			buMarbleForms.frmVerticalV4.spn_itemlen1.Value = buMarbleCalc.varMarbleRunSettings.VerticalWidth;
			buMarbleForms.frmVerticalV4.spn_itemcount1.Value = buMarbleCalc.varMarbleRunSettings.VerticalCount;
			buMarbleForms.frmVerticalV4.spn_itemSA1.Value = buMarbleCalc.varMarbleRunSettings.VerticalStartAngle;
			buMarbleForms.frmVerticalV4.spn_itemEA1.Value = buMarbleCalc.varMarbleRunSettings.VerticalEndAngle;
			buMarbleForms.frmVerticalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
			if (buMarbleCalc.varMarbleRunSettings.VerCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmVerticalV4.chk_lefttop.Check = true;
				buMarbleForms.frmVerticalV4.chk_leftbottom.Check = false;
			}
			else
			{
				buMarbleForms.frmVerticalV4.chk_lefttop.Check = false;
				buMarbleForms.frmVerticalV4.chk_leftbottom.Check = true;
			}
			buMarbleForms.frmHorVerHorV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
			buMarbleForms.frmHorVerVerV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
			buMarbleForms.frmHorVerDialog.spn_itemhorlength.Value = buMarbleCalc.varMarbleRunSettings.HorizontalLenght;
			buMarbleForms.frmHorVerDialog.spn_itemverlength.Value = buMarbleCalc.varMarbleRunSettings.VerticalLenght;
			if (buMarbleCalc.varMarbleRunSettings.HorVerHorCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmHorVerHorV4.chk_lefttop.Check = true;
				buMarbleForms.frmHorVerHorV4.chk_leftbottom.Check = false;
			}
			else
			{
				buMarbleForms.frmHorVerHorV4.chk_lefttop.Check = false;
				buMarbleForms.frmHorVerHorV4.chk_leftbottom.Check = true;
			}
			if (buMarbleCalc.varMarbleRunSettings.HorVerVerCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmHorVerVerV4.chk_lefttop.Check = true;
				buMarbleForms.frmHorVerVerV4.chk_leftbottom.Check = false;
			}
			else
			{
				buMarbleForms.frmHorVerVerV4.chk_lefttop.Check = false;
				buMarbleForms.frmHorVerVerV4.chk_leftbottom.Check = true;
			}
			buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = true;
			buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = false;
			if (buMarbleForms.frmHorVerDialog.buTab1.SelectedIndex == 0)
			{
				if (buMarbleCalc.varMarbleRunSettings.HorVerHorCornerType == MarbleCorners.LeftTop)
				{
					buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = true;
					buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = false;
				}
				else
				{
					buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = false;
					buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = true;
				}
			}
			else if (buMarbleCalc.varMarbleRunSettings.HorVerVerCornerType == MarbleCorners.LeftTop)
			{
				buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = true;
				buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = false;
			}
			else
			{
				buMarbleForms.frmHorVerDialog.chk_horverlefttop.Check = false;
				buMarbleForms.frmHorVerDialog.chk_horverleftbottom.Check = true;
			}
			buMarbleForms.frmSingleV2.spn_signlecutAAngle.Value = buMarbleCalc.varMarbleRunSettings.SingleCutAAngle;
			buMarbleForms.frmSingleV2.spn_signlecutlength.Value = buMarbleCalc.varMarbleRunSettings.SingleCutLength;
			clsItem.FrmMach2.spn_xpos.Value = clsAppMarbleVars.varInterface.JogMoveXValue;
			clsItem.FrmMach2.spn_ypos.Value = clsAppMarbleVars.varInterface.JogMoveYValue;
			clsItem.FrmMach2.spn_zpos.Value = clsAppMarbleVars.varInterface.JogMoveZValue;
			clsItem.FrmMach2.spn_apos.Value = clsAppMarbleVars.varInterface.JogMoveCValue;
			clsItem.FrmMach2.spn_cpos.Value = clsAppMarbleVars.varInterface.JogMoveAValue;
			clsItem.FrmMach2.btn_xplus.Aux.ValDouble = clsItem.FrmMach2.spn_xpos.Value;
			clsItem.FrmMach2.btn_xminus.Aux.ValDouble = clsItem.FrmMach2.spn_xpos.Value;
			clsItem.FrmMach2.btn_yplus.Aux.ValDouble = clsItem.FrmMach2.spn_ypos.Value;
			clsItem.FrmMach2.btn_yminus.Aux.ValDouble = clsItem.FrmMach2.spn_ypos.Value;
			clsItem.FrmMach2.btn_zplus.Aux.ValDouble = clsItem.FrmMach2.spn_zpos.Value;
			clsItem.FrmMach2.btn_zminus.Aux.ValDouble = clsItem.FrmMach2.spn_zpos.Value;
			clsItem.FrmMach2.btn_aplus.Aux.ValDouble = clsItem.FrmMach2.spn_apos.Value;
			clsItem.FrmMach2.btn_aminus.Aux.ValDouble = clsItem.FrmMach2.spn_apos.Value;
			clsItem.FrmMach2.btn_cplus.Aux.ValDouble = clsItem.FrmMach2.spn_cpos.Value;
			clsItem.FrmMach2.btn_cminus.Aux.ValDouble = clsItem.FrmMach2.spn_cpos.Value;
			if ((CodesysMachine.CommType == CommunicationType.PlcHandler) | (CodesysMachine.CommType == CommunicationType.OPCUA))
			{
				clsAppMarbleVars.cmdMarble.CommunicationVariableInit();
			}
			MenuButtonColors(0);
			MenuDrawButtonColors(0);
			MenuButtonSawModeColors(0);
			clsAppMarbleVars.cmdMarble.ToolUpdateOnScreen();
			ccVars.Pages[0].Form.UpdateForm();
			clsItem.timGeneral.Interval = 300;
			clsItem.timGeneral.Tick += GeneralTick;
			clsItem.timGeneral.Enabled = true;
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent = 0.0;
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent = 0.0;
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent = 0.0;
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent = 0.0;
			clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent = 0.0;
			if (AppBool.Connected)
			{
				ReadBOOLValues();
				ReadDINTValues();
				ReadLRealValues();
				clsAppMarbleVars.cMachine.bWriteIOParameter = true;
				clsAppMarbleVars.cMachine.bWriteSettingsParameter = true;
				clsAppMarbleVars.cMachine.bWriteAppParameter = true;
				clsAppMarbleVars.cMachine.bWriteToolParameter = true;
				clsAppMarbleVars.cMachine.bWriteG54Parameter = true;
				clsAppMarbleVars.cMachine.bWriteParkParameters = true;
				clsAppMarbleVars.cMachine.bWriteAlarmActionParameters = true;
				KinematicBase copyKinematic = new KinematicBase();
				KinematicBase5.Copy(clsMarble.activeKinematic, ref copyKinematic);
				clsAppMarbleVars.cMachine.Commands.WriteKinematicData(CodesysMachine.RootPersistentString + "Kinematic.", copyKinematic);
			}
			clsInit.appCommand.cmdViewZoomFit();
			clsItem.FrmMach2.WindowState = FormWindowState.Maximized;
			clsAppMarbleItems.frmMain = clsItem.FrmMach2;
			buCadCamResVer5.clsItem.FrmMain = clsItem.FrmMach2;
			AppTask.taskResult1 = Task.Run(delegate
			{
				DoInitWork();
			});
			AppBool.Inited = true;
			Inited = true;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
			buLogMarbleVer5.saveLogList();
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, ex.Message, "Exception", "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void DoInitWork()
	{
		clsInit.appMarble.InitCadCamSimulation();
		Inited = true;
	}

	public void AssingControls()
	{
		string text = "AssingControls";
		try
		{
			buLogMarbleVer5.addToLogList(sClass, text, "Started");
			clsAppMarbleItems.frmCoordsV2 = new F_MarbleCoordinatesV2();
			clsAppMarbleControls.lblMachine = clsAppMarbleItems.frmCoordsV2.lbl_machine;
			clsAppMarbleControls.lblMachineX = clsAppMarbleItems.frmCoordsV2.lbl_machinex;
			clsAppMarbleControls.lblMachineY = clsAppMarbleItems.frmCoordsV2.lbl_machiney;
			clsAppMarbleControls.lblMachineZ = clsAppMarbleItems.frmCoordsV2.lbl_machinez;
			clsAppMarbleControls.lblMachineA = clsAppMarbleItems.frmCoordsV2.lbl_machinea;
			clsAppMarbleControls.lblMachineC = clsAppMarbleItems.frmCoordsV2.lbl_machinec;
			clsAppMarbleControls.lblPart = clsAppMarbleItems.frmCoordsV2.lbl_part;
			clsAppMarbleControls.lblPartX = clsAppMarbleItems.frmCoordsV2.lbl_partx;
			clsAppMarbleControls.lblPartY = clsAppMarbleItems.frmCoordsV2.lbl_party;
			clsAppMarbleControls.lblPartZ = clsAppMarbleItems.frmCoordsV2.lbl_partz;
			clsAppMarbleControls.lblPartA = clsAppMarbleItems.frmCoordsV2.lbl_parta;
			clsAppMarbleControls.lblPartC = clsAppMarbleItems.frmCoordsV2.lbl_partc;
			clsAppMarbleControls.lblStatus = clsItem.FrmMach2.lbl_status;
			clsAppMarbleControls.lblWarning = clsItem.FrmMach2.lbl_warning;
			clsAppMarbleControls.btnInformation = clsItem.FrmMach2.btn_information;
			clsAppMarbleControls.IC32 = clsItem.FrmMach2.IC32;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void AddControls()
	{
		string text = "AddControls";
		try
		{
			buLogMarbleVer5.addToLogList(sClass, text, "Started");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCoordsV1");
			clsAppMarbleItems.frmCoordsV2.pnl_base.Left = 4;
			clsAppMarbleItems.frmCoordsV2.pnl_base.Top = 54;
			clsAppMarbleItems.frmCoordsV2.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmCoordsV2.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach2.pnl_coords.Controls.Add(clsAppMarbleItems.frmCoordsV2.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCoordinates");
			clsAppMarbleItems.frmBottomPanelV1 = new F_MarbleBottomPanelV1();
			clsAppMarbleItems.frmBottomPanelV1.Init();
			clsAppMarbleItems.frmBottomPanelV1.buTab_Main.ItemSize = new Size(1, 1);
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCoordsV1");
			clsAppMarbleItems.frmBottomPanelV1.pnl_base.Left = -1;
			clsAppMarbleItems.frmBottomPanelV1.pnl_base.Top = -1;
			clsAppMarbleItems.frmBottomPanelV1.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmBottomPanelV1.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach2.pnl_down.Controls.Add(clsAppMarbleItems.frmBottomPanelV1.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCoordinates");
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmJobOPListV2");
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Left = 0;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Top = 42;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Height = 670;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.BackColor = Color.Transparent;
			clsAppMarbleItems.frmJobOPListV2.pnl_base.Display.Border.Visible = false;
			clsItem.FrmMach2.pnl_drawingjob.Controls.Add(clsAppMarbleItems.frmJobOPListV2.pnl_base);
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmJobOPListV2");
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void GeneralTick(object sender, EventArgs e)
	{
		clsItem.FrmMach2.lbl_datetime.Text = " " + DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2") + ":" + DateTime.Now.Second.ToString("D2") + "   ";
		if (!Inited)
		{
			return;
		}
		if (!AppBool.IsFirstRun)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_water = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmBottomPanelV1.btn_laser = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmBottomPanelV1.btn_sawstart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_sawstart, clsAppMarbleVars.cMachine.runSystem.Saw, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart, clsAppMarbleVars.cMachine.runSystem.Spindle, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmCoordsV2.btn_start = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmCoordsV2.btn_pause = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsItem.FrmMach2.btn_semiautoenable = hmiUICommands.ColorButtonLinearFromOnOff(clsItem.FrmMach2.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmBottomPanelV1.btn_rtcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmMDIPageV1.btn_tcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_tcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmMDIPageV1.btn_light = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_light, clsAppMarbleVars.cMachine.runSystem.MachineLight, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			clsAppMarbleItems.frmCoordsV2.lbl_machine.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode);
			clsAppMarbleItems.frmCoordsV2.lbl_part.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode);
			if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0)
			{
				clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, State: true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
				clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
				clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			}
			else if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1)
			{
				clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
				clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, State: true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
				clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			}
			else if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2)
			{
				clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
				clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
				clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, State: true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
			}
			AppBool.IsFirstRun = true;
		}
		clsAppMarbleVars.cmdMarble.GeneralTick();
		if (clsAppMarbleVars.cMachine.miscVar.WarningAvailable & (clsAppMarbleVars.cMachine.miscVar.cntWarning >= 10))
		{
			clsAppMarbleVars.cMachine.miscVar.WarningAvailable = false;
			clsAppMarbleVars.cMachine.miscVar.cntWarning = 0;
			clsItem.FrmMach2.lbl_status.Display.BackColor = Color.LightSteelBlue;
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 0) & (clsAppMarbleVars.cMachine.runSystem.Status < 100) & (clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach2.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
			}
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 100) & (clsAppMarbleVars.cMachine.runSystem.Status < 200) & (clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach2.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
			}
			clsItem.FrmMach2.lbl_warning.Visible = false;
		}
		if (clsAppMarbleItems.frmMachineSettingsV2 != null && (clsAppMarbleItems.frmMachineSettingsV2.Visible & clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible & !clsItem.FrmMach2.lbl_warning.Visible))
		{
			clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Text = "";
			clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible = false;
		}
		clsItem.timGeneral.Enabled = false;
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Water)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_water = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Water)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_water.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_water = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_water, clsAppMarbleVars.cMachine.runSystem.Water, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Laser)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_laser = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Laser)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_laser.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_laser = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_laser, clsAppMarbleVars.cMachine.runSystem.Laser, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Saw)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_sawstart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_sawstart, clsAppMarbleVars.cMachine.runSystem.Saw, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Saw)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_sawstart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_sawstart, clsAppMarbleVars.cMachine.runSystem.Saw, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Spindle)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart, clsAppMarbleVars.cMachine.runSystem.Spindle, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Spindle)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart, clsAppMarbleVars.cMachine.runSystem.Spindle, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected & clsAppMarbleVars.cMachine.runSystem.Run)
		{
			clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected = true;
			clsAppMarbleItems.frmCoordsV2.btn_start = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Run)
		{
			clsAppMarbleItems.frmCoordsV2.btn_start.ForceSelected = false;
			clsAppMarbleItems.frmCoordsV2.btn_start = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_start, clsAppMarbleVars.cMachine.runSystem.Run, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
		{
			clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected = true;
			clsAppMarbleItems.frmCoordsV2.btn_pause = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.Pause)
		{
			clsAppMarbleItems.frmCoordsV2.btn_pause.ForceSelected = false;
			clsAppMarbleItems.frmCoordsV2.btn_pause = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.btn_pause, clsAppMarbleVars.cMachine.runSystem.Pause, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsItem.FrmMach2.btn_semiautoenable.ForceSelected & clsAppMarbleVars.cMachine.runSystem.SemiAuto)
		{
			clsItem.FrmMach2.btn_semiautoenable.ForceSelected = true;
			clsItem.FrmMach2.btn_semiautoenable = hmiUICommands.ColorButtonLinearFromOnOff(clsItem.FrmMach2.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsItem.FrmMach2.btn_semiautoenable.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.SemiAuto)
		{
			clsItem.FrmMach2.btn_semiautoenable.ForceSelected = false;
			clsItem.FrmMach2.btn_semiautoenable = hmiUICommands.ColorButtonLinearFromOnOff(clsItem.FrmMach2.btn_semiautoenable, clsAppMarbleVars.cMachine.runSystem.SemiAuto, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected & clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected & clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected = true;
			clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.CruiseControl)
		{
			clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.ForceSelected = false;
			clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol, clsAppMarbleVars.cMachine.runSystem.CruiseControl, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected & clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_rtcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_rtcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_rtcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected & clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
		{
			clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected = true;
			clsAppMarbleItems.frmMDIPageV1.btn_tcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_tcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.RtcpActivated)
		{
			clsAppMarbleItems.frmMDIPageV1.btn_tcp.ForceSelected = false;
			clsAppMarbleItems.frmMDIPageV1.btn_tcp = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_tcp, clsAppMarbleVars.cMachine.runSystem.RtcpActivated, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected & clsAppMarbleVars.cMachine.runSystem.MachineLight)
		{
			clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected = true;
			clsAppMarbleItems.frmMDIPageV1.btn_light = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_light, clsAppMarbleVars.cMachine.runSystem.MachineLight, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected & !clsAppMarbleVars.cMachine.runSystem.MachineLight)
		{
			clsAppMarbleItems.frmMDIPageV1.btn_light.ForceSelected = false;
			clsAppMarbleItems.frmMDIPageV1.btn_light = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmMDIPageV1.btn_light, clsAppMarbleVars.cMachine.runSystem.MachineLight, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0))
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, State: true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 0))
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1))
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, State: true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 1))
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if (!clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2))
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected = true;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, State: true, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != 2))
		{
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.ForceSelected = false;
			clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset = hmiUICommands.ColorButtonLinearFromOnOff(clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset, State: false, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		clsAppMarbleItems.frmBottomPanelV1.progress_X.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent));
		clsAppMarbleItems.frmBottomPanelV1.progress_Y.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent));
		clsAppMarbleItems.frmBottomPanelV1.progress_Z.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent));
		clsAppMarbleItems.frmBottomPanelV1.progress_A.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent));
		clsAppMarbleItems.frmBottomPanelV1.progress_C.Value = Math.Abs(Convert.ToInt32(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent));
		if (MarbleTempVars.MachineCoordShowModeChanged)
		{
			MarbleTempVars.MachineCoordShowModeChanged = false;
			int num = Convert.ToInt32(clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode);
			num++;
			if (num > 4)
			{
				num = 0;
			}
			if (num < 0)
			{
				num = 0;
			}
			clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode = (CoordinateShowMode)num;
			clsAppMarbleItems.frmCoordsV2.lbl_machine.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode);
			AppBool.SaveByTick = true;
		}
		if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.DistanceToGo)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Speed)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Current)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.FollowingError)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Part)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			}
		}
		else
		{
			clsAppMarbleItems.frmCoordsV2.lbl_machinex.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machiney.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinez.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_machinec.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_machinea.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			}
		}
		if (MarbleTempVars.PartCoordShowModeChanged)
		{
			MarbleTempVars.PartCoordShowModeChanged = false;
			int num2 = Convert.ToInt32(clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode);
			num2++;
			if (num2 > 4)
			{
				num2 = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode = (CoordinateShowMode)num2;
			clsAppMarbleItems.frmCoordsV2.lbl_part.Text = clsAppMarbleVars.cMachine.Commands.CoordinateReadModeToString(clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode);
			AppBool.SaveByTick = true;
		}
		if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.DistanceToGo)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.distanceToGo.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Speed)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualVelocity.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Current)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualCurrent.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.FollowingError)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualFollowError.ToString("f2");
			}
		}
		else if (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Machine)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition.ToString("f2");
			}
		}
		else
		{
			clsAppMarbleItems.frmCoordsV2.lbl_partx.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_party.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partz.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			clsAppMarbleItems.frmCoordsV2.lbl_partc.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				clsAppMarbleItems.frmCoordsV2.lbl_parta.Text = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualOffsetedPosition.ToString("f2");
			}
		}
		clsAppMarbleItems.frmCoordsV2.lbl_machinex.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
		clsAppMarbleItems.frmCoordsV2.lbl_machiney.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
		clsAppMarbleItems.frmCoordsV2.lbl_machinez.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
		clsAppMarbleItems.frmCoordsV2.lbl_machinec.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
		if (clsAppMarbleVars.varRuntime.AxA >= 0)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_machinea.Display.Fonts.ForeColor = buImage5.ColorFromBool(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bEnabled, buMarbleCalc.varMarbleControlColorSettings.colorCoordinateColor, buMarbleCalc.varMarbleControlColorSettings.colorAxesDisable);
		}
		if (clsAppMarbleVars.cMachine.runSystem.Saw)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_spindlespeed.Text = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Speed + " : " + clsAppMarbleVars.cMachine.runSystem.SawSpeed.ToString("f0") + " Rpm";
		}
		else
		{
			clsAppMarbleItems.frmCoordsV2.lbl_spindlespeed.Text = buLangTranslate.preDef.Spindle + " " + buLangTranslate.preDef.Speed + " : " + clsAppMarbleVars.cMachine.runSystem.SpindleSpeed.ToString("f0") + " Rpm";
		}
		clsAppMarbleItems.frmCoordsV2.lbl_operationspeed.Text = buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Speed + " : " + clsAppMarbleVars.cMachine.runCNC.FeedVelocity.ToString("f0");
		clsAppMarbleItems.frmCoordsV2.lbl_quickspeed.Text = buLangTranslate.preDef.Quick + " " + buLangTranslate.preDef.Speed + " : " + clsAppMarbleVars.cMachine.runCNC.FeedVelocity.ToString("f0");
		if (AppBool.Offline)
		{
			clsAppMarbleItems.frmCoordsV2.track_quickspeed.Value = 100;
			clsAppMarbleItems.frmCoordsV2.track_operationspeed.Value = 100;
			clsAppMarbleItems.frmCoordsV2.track_spidle.Value = 100;
			clsAppMarbleItems.frmCoordsV2.progress_spindleCurrent.Value = 0;
		}
		else
		{
			clsAppMarbleItems.frmCoordsV2.track_quickspeed.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.FeedOverrideG0);
			clsAppMarbleItems.frmCoordsV2.track_operationspeed.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.FeedOverrideG1);
			clsAppMarbleItems.frmCoordsV2.track_spidle.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.SpindleOverride);
			clsAppMarbleItems.frmCoordsV2.progress_spindleCurrent.Value = Convert.ToInt32(clsAppMarbleVars.cMachine.runSystem.SpindleActualCurrent);
		}
		if (AppBool.ToolUpdated | AppBool.ToolChanged)
		{
			AppBool.ToolChanged = false;
			AppBool.ToolUpdated = false;
			if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0)
			{
				clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = 1.0;
				clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolSaw.Geometry.Diameter;
				clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolSaw.Geometry.Thickness;
			}
			if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1)
			{
				clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = buMarbleCalc.activeToolMilling.Data.No;
				clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMilling.Geometry.Diameter;
				clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMilling.Geometry.Length;
			}
			if (clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2)
			{
				clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = buMarbleCalc.activeToolMillingHead.Data.No;
				clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMillingHead.Geometry.Diameter;
				clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMillingHead.Geometry.Length;
			}
		}
		if ((clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 0) & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre))
		{
			clsAppMarbleItems.frmCoordsV2.lbl_toolname.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Saw;
			clsAppMarbleItems.frmCoordsV2.pic_tool.Image = clsAppMarbleItems.frmCoordsV2.IC48Tool.Images[0];
			clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = 1.0;
			clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolSaw.Geometry.Diameter;
			clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolSaw.Geometry.Thickness;
			clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Caption.Caption = buLangTranslate.preDef.Thickness;
		}
		if ((clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 1) & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre))
		{
			clsAppMarbleItems.frmCoordsV2.lbl_toolname.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.Milling;
			clsAppMarbleItems.frmCoordsV2.pic_tool.Image = clsAppMarbleItems.frmCoordsV2.IC48Tool.Images[1];
			clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = buMarbleCalc.activeToolMilling.Data.No;
			clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMilling.Geometry.Diameter;
			clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMilling.Geometry.Length;
			clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Caption.Caption = buLangTranslate.preDef.Length;
		}
		if ((clsAppMarbleVars.cMachine.runSystem.ActiveToolType == 2) & (clsAppMarbleVars.cMachine.runSystem.ActiveToolType != clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre))
		{
			clsAppMarbleItems.frmCoordsV2.lbl_toolname.Text = buLangTranslate.preDef.Tool + " " + buLangTranslate.preDef.MillingHead;
			clsAppMarbleItems.frmCoordsV2.pic_tool.Image = clsAppMarbleItems.frmCoordsV2.IC48Tool.Images[2];
			clsAppMarbleItems.frmCoordsV2.spn_toolno.Value = buMarbleCalc.activeToolMillingHead.Data.No;
			clsAppMarbleItems.frmCoordsV2.spn_tooldiameter.Value = buMarbleCalc.activeToolMillingHead.Geometry.Diameter;
			clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Value = buMarbleCalc.activeToolMillingHead.Geometry.Length;
			clsAppMarbleItems.frmCoordsV2.spn_toolthickness.Caption.Caption = buLangTranslate.preDef.Length;
		}
		clsAppMarbleVars.cMachine.tempVars.ActiveToolTypePre = clsAppMarbleVars.cMachine.runSystem.ActiveToolType;
		bool flag = clsAppMarbleVars.cMachine.runSystem.Spindle | clsAppMarbleVars.cMachine.runSystem.Saw;
		if (!clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected && flag)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected = true;
			clsAppMarbleItems.frmCoordsV2.lbl_toolname = hmiUICommands.ColorLabelLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.lbl_toolname, flag, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		else if (clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected && !flag)
		{
			clsAppMarbleItems.frmCoordsV2.lbl_toolname.ForceSelected = false;
			clsAppMarbleItems.frmCoordsV2.lbl_toolname = hmiUICommands.ColorLabelLinearFromOnOff(clsAppMarbleItems.frmCoordsV2.lbl_toolname, flag, buEyeVars.parVisual.hmiOn1, buEyeVars.parVisual.hmiOff1);
		}
		if ((clsAppMarbleVars.cMachine.runSystem.AlarmCount == 0) & !clsAppMarbleVars.cMachine.miscVar.WarningAvailable)
		{
			clsItem.FrmMach2.lbl_status.Display.Fonts.ForeColor = Color.WhiteSmoke;
			clsItem.FrmMach2.lbl_status.Display.BackColor = Color.DimGray;
			clsItem.FrmMach2.lbl_status.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(Color.DimGray, 0.6);
			clsItem.FrmMach2.lbl_status.Display.LineerGradient.SecondColor = Color.DimGray;
			if (clsAppMarbleVars.cMachine.runSystem.Pause)
			{
				clsItem.FrmMach2.lbl_status.Display.BackColor = Color.DarkOrange;
				clsItem.FrmMach2.lbl_status.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(Color.DarkOrange, 0.6);
				clsItem.FrmMach2.lbl_status.Display.LineerGradient.SecondColor = Color.DarkOrange;
			}
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 0) & (clsAppMarbleVars.cMachine.runSystem.Status < 100) & (clsAppMarbleVars.cMachine.runSystem.Status <= AppLanguage.SystemStatus.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach2.lbl_status.Text = AppLanguage.SystemStatus[clsAppMarbleVars.cMachine.runSystem.Status];
			}
			if ((clsAppMarbleVars.cMachine.runSystem.Status >= 100) & (clsAppMarbleVars.cMachine.runSystem.Status < 200) & (clsAppMarbleVars.cMachine.runSystem.Status - 100 <= AppLanguage.Status.Count - 1) & !AppBool.FileLoading)
			{
				clsItem.FrmMach2.lbl_status.Text = AppLanguage.Status[clsAppMarbleVars.cMachine.runSystem.Status - 100];
			}
		}
		if (clsAppMarbleVars.cMachine.InfoList.Count > 0)
		{
			if (clsAppMarbleVars.cMachine.miscVar.cntGeneralTick % 10 == 0)
			{
				clsAppMarbleVars.cMachine.miscVar.indexInfo++;
				clsAppMarbleVars.cMachine.miscVar.InfoFlash = !clsAppMarbleVars.cMachine.miscVar.InfoFlash;
			}
			if (clsAppMarbleVars.cMachine.miscVar.indexInfo > clsAppMarbleVars.cMachine.InfoList.Count - 1)
			{
				clsAppMarbleVars.cMachine.miscVar.indexInfo = 0;
			}
			if (clsAppMarbleVars.cMachine.miscVar.indexInfo < 0)
			{
				clsAppMarbleVars.cMachine.miscVar.indexInfo = 0;
			}
			clsItem.FrmMach2.lbl_status.Display.Fonts.ForeColor = Color.Black;
			clsItem.FrmMach2.lbl_status.Display.BackColor = clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].ColorInfo;
			clsItem.FrmMach2.lbl_status.Display.LineerGradient.FirstColor = clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].ColorInfo;
			clsItem.FrmMach2.lbl_status.Display.LineerGradient.SecondColor = buImage5.ColorToneChange(clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].ColorInfo, 0.8);
			clsItem.FrmMach2.lbl_status.Text = clsAppMarbleVars.cMachine.InfoList[clsAppMarbleVars.cMachine.miscVar.indexInfo].Message;
			if (clsAppMarbleVars.cMachine.miscVar.InfoFlash)
			{
				clsItem.FrmMach2.btn_information.Display.LineerGradient.FirstColor = Color.Salmon;
				clsItem.FrmMach2.btn_information.Display.LineerGradient.SecondColor = Color.LightSalmon;
			}
			else
			{
				clsItem.FrmMach2.btn_information.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(Color.Salmon, 1.3);
				clsItem.FrmMach2.btn_information.Display.LineerGradient.SecondColor = buImage5.ColorToneChange(Color.LightSalmon, 1.3);
			}
			clsItem.FrmMach2.btn_information.Visible = true;
			string text = clsAppMarbleVars.cMachine.InfoList[0].Message;
			if (text.Length > 50)
			{
				text = text.Substring(0, 50);
			}
			if (clsAppMarbleVars.cMachine.runSystem.AlarmCount > 0)
			{
				clsItem.FrmMach2.btn_information.Image = clsItem.FrmMach2.IC32.Images[1];
				clsItem.FrmMach2.btn_information.Text = buLangTranslate.preDef.Error + ": " + text;
			}
			else if ((clsAppMarbleVars.cMachine.runSystem.WarningCount > 0) | (clsAppMarbleVars.cMachine.runSystem.WarningLocalCount > 0))
			{
				clsItem.FrmMach2.btn_information.Image = clsItem.FrmMach2.IC32.Images[0];
				clsItem.FrmMach2.btn_information.Text = buLangTranslate.preDef.Warning + ": " + text;
			}
			else if (clsAppMarbleVars.cMachine.runSystem.MessageCount > 0)
			{
				clsItem.FrmMach2.btn_information.Image = clsItem.FrmMach2.IC32.Images[2];
				clsItem.FrmMach2.btn_information.Text = buLangTranslate.preDef.Message + ": " + text;
			}
		}
		else
		{
			clsAppMarbleVars.cMachine.miscVar.indexInfo = -1;
			clsItem.FrmMach2.btn_information.Visible = false;
		}
		clsItem.timGeneral.Enabled = true;
	}

	private void CommandHMI(object Data1, object Data2, object Data3, object Data4, object Data5)
	{
		MarbleHMICommands marbleHMICommands = MarbleHMICommands.None;
		if (Data1 is MarbleHMICommands)
		{
			marbleHMICommands = (MarbleHMICommands)Data1;
		}
		if (marbleHMICommands == MarbleHMICommands.ShowWarning)
		{
			ShowWarning((string)Data2, Color.Gold);
		}
		if (marbleHMICommands == MarbleHMICommands.HideWarning)
		{
			clsItem.FrmMach2.lbl_warning.Text = "";
			clsItem.FrmMach2.lbl_warning.Visible = false;
			if (clsAppMarbleItems.frmMachineSettingsV2 != null && clsAppMarbleItems.frmMachineSettingsV2.Visible)
			{
				clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Text = "";
				clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible = false;
			}
		}
		if (marbleHMICommands == MarbleHMICommands.StatusUpdate)
		{
			clsItem.FrmMach2.lbl_status.Text = (string)Data2;
			clsItem.FrmMach2.lbl_status.Display.BackColor = (Color)Data3;
		}
		if (marbleHMICommands == MarbleHMICommands.MaterialUpdate)
		{
			clsItem.FrmMach2.spn_cammarblethickness.Value = (double)Data2;
			buMarbleCalc.varOperation.MaterialParameter.MaterialThickness = (double)Data2;
			clsAppMarbleVars.varApp.MaterialThickness = (double)Data2;
			clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Persistent, clsAppMarbleVars.varApp.MaterialThickness, "appSet.MaterialThickness");
		}
		if (marbleHMICommands == MarbleHMICommands.SaveCNCParameter)
		{
			Task.Run(delegate
			{
				SaveParameter();
			});
		}
		if (marbleHMICommands == MarbleHMICommands.SaveCamParameter && !MarbleTempVars.SavingMarble)
		{
			Task.Run(delegate
			{
				clsInit.appMarble.SaveMarbleFile(AppPath.MachineSettings);
			});
		}
		if (marbleHMICommands == MarbleHMICommands.UpdateMarbleCamParametersFromControls)
		{
			MainControlsToParameter(FromControlToValues: true);
		}
	}

	public void clickCommands(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			string text = control.Name.ToString();
			string text2 = "";
			if (control is buControl && ((buControl)control).Aux.Command != null)
			{
				text2 = ((buControl)control).Aux.Command;
			}
			if (control.Name == clsItem.FrmMach2.btn_cancel.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Cancel);
			}
			if (control.Name == clsItem.FrmMach2.btn_go.Name)
			{
				clsInit.appMarble.viewportMouseDown(new Point3D(clsItem.FrmMach2.spn_x.Value, clsItem.FrmMach2.spn_y.Value, 0.0), ccVars.Pages[ccVars.PageIndex].Form.viewportcad, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_spindlestart.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleStart);
			}
			if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTools(1);
				clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
				return;
			}
			if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolmillinheadset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTools(2);
				clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
				return;
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_sawstart.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawStart);
			}
			if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolsawset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTools(0);
				clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
				return;
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_gozero.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.GoPartZero);
			}
			if ((control.Name == clsAppMarbleItems.frmMDIPageV1.btn_crousecontrol.Name) | (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_crousecontrol.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CrouseControl);
			}
			if ((control.Name == clsAppMarbleItems.frmMDIPageV1.btn_tcp.Name) | (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_rtcp.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.RTCP);
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_partzero.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.PartZero);
			}
			if ((control.Name == clsItem.FrmMach2.btn_codecreate.Name) | (control.Name == clsItem.FrmMach2.btn_codecreate2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CodeCreate);
				FillOperations();
			}
			if ((control.Name == clsItem.FrmMach2.btn_c0.Name) | (control.Name == clsItem.FrmMach2.btn_c0_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C0);
			}
			if ((control.Name == clsItem.FrmMach2.btn_c90.Name) | (control.Name == clsItem.FrmMach2.btn_c90_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90);
			}
			if ((control.Name == clsItem.FrmMach2.btn_c180.Name) | (control.Name == clsItem.FrmMach2.btn_c180_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C180);
			}
			if (control.Name == clsItem.FrmMach2.btn_c270.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90Minus);
			}
			if (control.Name == clsItem.FrmMach2.btn_c_90_2.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.C90Minus);
			}
			if ((control.Name == clsItem.FrmMach2.btn_A0.Name) | (control.Name == clsItem.FrmMach2.btn_a0_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A0);
			}
			if ((control.Name == clsItem.FrmMach2.btn_A45.Name) | (control.Name == clsItem.FrmMach2.btn_a45_2.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A45);
			}
			if (control.Name == clsItem.FrmMach2.btn_A90.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A90);
			}
			if (control.Name == clsItem.FrmMach2.btn_a46_2.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.A46);
			}
			if ((control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Name) | ((text2.Length > 0) & (text2 == MarbleMotionCommands.SpindlePistonDown.ToString())))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonDown);
			}
			if ((control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Name) | ((text2.Length > 0) & (text2 == MarbleMotionCommands.SpindlePistonUp.ToString())))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePistonUp);
			}
			if (control.Name == clsItem.FrmMach2.btn_semiautoenable.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SemiAutoSwitch);
				if (clsAppMarbleVars.cMachine.runSystem.SemiAuto)
				{
					clsAppMarbleVars.cMachine.bWriteAppParameter = true;
				}
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_water.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Water);
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_laser.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Laser);
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_parkpos.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Park);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_park.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Park);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vagonpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.WagonPark);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlepark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindlePark);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_sawpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawPark);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindleheadpark.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleHeadPark);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_photopos.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraPark);
			}
			if ((control.Name == clsAppMarbleItems.frmCoordsV2.btn_reset.Name) | (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_stop.Name))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Reset);
			}
			if (control.Name == clsAppMarbleItems.frmCoordsV2.btn_start.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Start);
			}
			if (control.Name == clsAppMarbleItems.frmCoordsV2.btn_pause.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Pause);
			}
			if (control.Name == clsItem.FrmMach2.btn_stopsemiauto.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumair.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumBlow);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumdown.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumDown);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumup.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumUp);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumleftpad.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumLeftPad);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_vacuumrightpad.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.VacuumRightPad);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_light.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.MachineLight);
			}
			if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_material.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMaterialPage();
			}
			if (clsAppMarbleItems.frmBottomPanelV1 != null && control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_mdi.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMDIPage();
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_materialmeasure.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.MaterialMeasureWithXYPos);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_sawwarm.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SawWarmUp);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_spindlewarm.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.SpindleWarmUp);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Pens);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.AtcClose);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.AtcOpen);
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_parklist.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.ParkList);
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_g54list.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.G54List);
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_toolpage.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTools(-1);
				clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_gcodemaximize.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowGCodePage(1);
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_OPUp.Name && clsAppMarbleVars.varRuntime.OperationIndex > 0)
			{
				clsAppMarbleVars.varRuntime.OperationIndex--;
				if (clsAppMarbleVars.varRuntime.OperationIndex <= clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count - 1)
				{
					clsAppMarbleItems.frmBottomPanelV1.tree_operation.SelectedNode = clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes[clsAppMarbleVars.varRuntime.OperationIndex];
				}
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_OPDown.Name && clsAppMarbleVars.varRuntime.OperationIndex < clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count - 1)
			{
				clsAppMarbleVars.varRuntime.OperationIndex++;
				if ((clsAppMarbleVars.varRuntime.OperationIndex >= 0) & (clsAppMarbleVars.varRuntime.OperationIndex <= clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count - 1))
				{
					clsAppMarbleItems.frmBottomPanelV1.tree_operation.SelectedNode = clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes[clsAppMarbleVars.varRuntime.OperationIndex];
					clsAppMarbleItems.frmBottomPanelV1.tree_operation.Update();
				}
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_GCodeUp.Name && ((clsAppMarbleVars.cMachine.runCNC.ActiveLine > 0) & (clsAppMarbleVars.cMachine.runCNC.ActiveLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1)))
			{
				clsAppMarbleVars.cMachine.runCNC.ActiveLine--;
				Place start = new Place
				{
					iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine
				};
				clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.Start = start;
				Place end = new Place
				{
					iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine + 1
				};
				clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.End = end;
				clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Refresh();
				if (end.iLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1)
				{
					clsAppMarbleItems.frmBottomPanelV1.txt_gcode.DoSelectionVisible();
				}
			}
			if (control.Name == clsAppMarbleItems.frmBottomPanelV1.btn_GCodeDown.Name)
			{
				clsAppMarbleVars.cMachine.runCNC.ActiveLine++;
				if ((clsAppMarbleVars.cMachine.runCNC.ActiveLine > 0) & (clsAppMarbleVars.cMachine.runCNC.ActiveLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1))
				{
					Place start2 = new Place
					{
						iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine
					};
					clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.Start = start2;
					Place end2 = new Place
					{
						iLine = clsAppMarbleVars.cMachine.runCNC.ActiveLine + clsAppMarbleVars.cMachine.miscVar.StartLine + 1
					};
					clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Selection.End = end2;
					clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Refresh();
					if (end2.iLine <= clsAppMarbleItems.frmBottomPanelV1.txt_gcode.Lines.Count - 1)
					{
						clsAppMarbleItems.frmBottomPanelV1.txt_gcode.DoSelectionVisible();
					}
				}
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_cameraopen.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverOpen);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_cameraclose.Name)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraCoverClose);
			}
			if (control.Name == clsAppMarbleItems.frmMDIPageV1.btn_camera.Name && (!AppBool.CameraCapturing & !AppBool.CameraMakeItReady & buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable))
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraReady);
			}
		}
		catch (Exception)
		{
		}
	}

	public void clickCommandMainMenuButton(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			MainControlsToParameter(FromControlToValues: true);
			clsItem.FrmMach2.buTab_drawing.Left = 0;
			clsItem.FrmMach2.buTab_drawing.Top = 0;
			clsItem.FrmMach2.buTab_drawing.Width = 155;
			clsItem.FrmMach2.buTab_drawing.Height = 600;
			clsAppMarbleVars.varRuntime.isHorizontalTab = false;
			clsAppMarbleVars.varRuntime.isVerticalTab = false;
			clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
			if (control.Name == clsItem.FrmMach2.btn_main.Name)
			{
				clsAppMarbleVars.varRuntime.OnlineSimulationAllow = true;
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsItem.FrmMach2.pnl_view.Visible = false;
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach2.buTab_Main.SelectedIndex = 0;
				MenuButtonColors(0);
			}
			if (control.Name == clsItem.FrmMach2.btn_manuel.Name)
			{
				clsAppMarbleVars.varRuntime.OnlineSimulationAllow = true;
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsItem.FrmMach2.pnl_view.Visible = false;
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach2.buTab_Main.SelectedIndex = 1;
				MenuButtonColors(1);
			}
			if (control.Name == clsItem.FrmMach2.btn_sawmode.Name)
			{
				clsAppMarbleVars.varRuntime.OnlineSimulationAllow = false;
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsItem.FrmMach2.pnl_view.Visible = false;
				clsAppMarbleVars.varRuntime.isMainTab = true;
				clsItem.FrmMach2.buTab_Main.SelectedIndex = 2;
				MenuButtonColors(2);
			}
			if (control.Name == clsItem.FrmMach2.btn_drawing.Name)
			{
				clsAppMarbleVars.varRuntime.OnlineSimulationAllow = false;
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsItem.FrmMach2.pnl_view.Visible = false;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach2.buTab_Main.SelectedIndex = 3;
				MenuButtonColors(3);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewmenu.Name)
			{
				if (clsItem.FrmMach2.pnl_view.Visible)
				{
					clsItem.FrmMach2.pnl_view.Visible = false;
				}
				else
				{
					if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 0)
					{
						int num = 0;
						if (!MarbleTempVars.DockRightEnable)
						{
							num = 170;
						}
						clsItem.FrmMach2.pnl_view.Left = 360 + num;
						clsItem.FrmMach2.pnl_view.Top = 120;
					}
					else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 1)
					{
						int num2 = 0;
						if (!MarbleTempVars.DockRightEnable)
						{
							num2 = 170;
						}
						clsItem.FrmMach2.pnl_view.Left = 580 + num2;
						clsItem.FrmMach2.pnl_view.Top = 120;
					}
					else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 2)
					{
						clsItem.FrmMach2.pnl_view.Left = 360;
						clsItem.FrmMach2.pnl_view.Top = -5;
					}
					else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 3)
					{
						int num3 = 0;
						if (!MarbleTempVars.DockRightEnable)
						{
							num3 = 170;
						}
						clsItem.FrmMach2.pnl_view.Left = 170 + num3;
						clsItem.FrmMach2.pnl_view.Top = 170;
					}
					else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 4)
					{
						int num4 = 0;
						if (!MarbleTempVars.DockRightEnable)
						{
							num4 = 170;
						}
						clsItem.FrmMach2.pnl_view.Left = 290 + num4;
						clsItem.FrmMach2.pnl_view.Top = 190;
					}
					clsItem.FrmMach2.pnl_view.Visible = true;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_horizontal.Name)
			{
				clsAppMarbleVars.varRuntime.isSingleTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalTab = true;
				clsAppMarbleVars.varRuntime.isVerticalTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 0;
				MenuButtonSawModeColors(0);
			}
			if (control.Name == clsItem.FrmMach2.btn_vertical.Name)
			{
				clsAppMarbleVars.varRuntime.isSingleTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalTab = false;
				clsAppMarbleVars.varRuntime.isVerticalTab = true;
				clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 1;
				MenuButtonSawModeColors(1);
			}
			if (control.Name == clsItem.FrmMach2.btn_horver.Name)
			{
				clsAppMarbleVars.varRuntime.isSingleTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalTab = false;
				clsAppMarbleVars.varRuntime.isVerticalTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = true;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 2;
				MenuButtonSawModeColors(2);
			}
			if (control.Name == clsItem.FrmMach2.btn_single.Name)
			{
				clsAppMarbleVars.varRuntime.isSingleTab = true;
				clsAppMarbleVars.varRuntime.isHorizontalTab = false;
				clsAppMarbleVars.varRuntime.isVerticalTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 3;
				MenuButtonSawModeColors(3);
			}
			if (control.Name == clsItem.FrmMach2.btn_semiAuto.Name)
			{
				clsAppMarbleVars.varRuntime.isSingleTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalTab = false;
				clsAppMarbleVars.varRuntime.isVerticalTab = false;
				clsAppMarbleVars.varRuntime.isHorizontalVerticalTab = false;
				clsAppMarbleVars.varRuntime.isMainTab = false;
				clsItem.FrmMach2.buTab_sawmode.SelectedIndex = 4;
				MenuButtonSawModeColors(4);
			}
			if (control.Name == clsItem.FrmMach2.btn_photo.Name)
			{
				if (!clsItem.FrmMach2.buTab_drawing.Visible)
				{
					clsItem.FrmMach2.buTab_drawing.Visible = true;
				}
				else
				{
					clsItem.FrmMach2.buTab_drawing.Visible = false;
				}
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Photo;
				clsItem.FrmMach2.buTab_drawing.SelectedIndex = 0;
				MenuDrawButtonColors(0);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach2.btn_pointer.Name)
			{
				if (!clsItem.FrmMach2.buTab_drawing.Visible)
				{
					clsItem.FrmMach2.buTab_drawing.Visible = true;
				}
				else
				{
					clsItem.FrmMach2.buTab_drawing.Visible = false;
				}
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Pointer;
				clsItem.FrmMach2.buTab_drawing.SelectedIndex = 1;
				MenuDrawButtonColors(1);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach2.btn_2DCad.Name)
			{
				if (!clsItem.FrmMach2.buTab_drawing.Visible)
				{
					clsItem.FrmMach2.buTab_drawing.Visible = true;
				}
				else
				{
					clsItem.FrmMach2.buTab_drawing.Visible = false;
				}
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Operation;
				clsItem.FrmMach2.buTab_drawing.SelectedIndex = 2;
				MenuDrawButtonColors(2);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach2.btn_3DCad.Name)
			{
				if (!clsItem.FrmMach2.buTab_drawing.Visible)
				{
					clsItem.FrmMach2.buTab_drawing.Visible = true;
				}
				else
				{
					clsItem.FrmMach2.buTab_drawing.Visible = false;
				}
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Operation;
				clsItem.FrmMach2.buTab_drawing.SelectedIndex = 3;
				MenuDrawButtonColors(3);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach2.btn_Functions.Name)
			{
				if (!clsItem.FrmMach2.buTab_drawing.Visible)
				{
					clsItem.FrmMach2.buTab_drawing.Visible = true;
				}
				else
				{
					clsItem.FrmMach2.buTab_drawing.Visible = false;
				}
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Function;
				clsItem.FrmMach2.buTab_drawing.SelectedIndex = 4;
				MenuDrawButtonColors(4);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: true, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
			if (control.Name == clsItem.FrmMach2.btn_misc.Name)
			{
				if (!clsItem.FrmMach2.buTab_drawing.Visible)
				{
					clsItem.FrmMach2.buTab_drawing.Visible = true;
				}
				else
				{
					clsItem.FrmMach2.buTab_drawing.Visible = false;
				}
				MarbleTempVars.OperationageMode = MarbleOperationPageMode.Misc;
				clsItem.FrmMach2.buTab_drawing.SelectedIndex = 5;
				MenuDrawButtonColors(5);
				clsInit.appMarble.EntitiesSelectableStates(EdgeSelectable: false, OperationSelectable: false, CollapseSelectable: false, SlatSelectable: false, VacuumSelectable: false);
			}
		}
		catch (Exception)
		{
		}
	}

	public void clickCommandsDrawing(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			MainControlsToParameter(FromControlToValues: true);
			if (control.Name == clsItem.FrmMach2.btn_menuOP.Name)
			{
				clsMarble.frmOPCommands.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				clsMarble.frmOPCommands.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsMarble.frmOPCommands.Init();
				clsMarble.frmOPCommands.ShowDialog();
				if (clsMarble.frmOPCommands.CommandType == MarbleItemType.HorizontalCut)
				{
					clsInit.appMarble.cmdHorVerCut(isHorizontal: true);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.VerticalCut)
				{
					clsInit.appMarble.cmdHorVerCut(isHorizontal: false);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SingleCut)
				{
					clsInit.appMarble.cmdSingleCut();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Contour)
				{
					clickCommandsDrawing(clsItem.FrmMach1.btn_contour, null);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Shape)
				{
					clickCommandsDrawing(clsItem.FrmMach1.btn_shape, null);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Slices)
				{
					clsInit.appMarble.cmdSlicing();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Profiling)
				{
					clsInit.appMarble.cmdProfileMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.ProfileCurve)
				{
					clsInit.appMarble.cmdProfileCurveMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Text)
				{
					clsInit.appMarble.cmdTextMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Library)
				{
					clsInit.appMarble.cmdLibraryMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Engraving)
				{
					clsInit.appMarble.cmd3DFileAdd();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.GCode)
				{
					clsInit.appMarble.cmdExternalGCode();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Columns)
				{
					clsInit.appMarble.cmdColumnsMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Sweep)
				{
					clsInit.appMarble.cmdSweepMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.LatheHorizontal)
				{
					clsInit.appMarble.cmdLatheMenu(isHorizontal: true);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.LatheVertical)
				{
					clsInit.appMarble.cmdLatheMenu(isHorizontal: false);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Drill)
				{
					clsInit.appMarble.cmdDrillMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Editor)
				{
					clsInit.appMarble.cmdContourMenu(EditorMode: true);
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.MaterialClean)
				{
					clsInit.appMarble.cmdCleanMaterail();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.AirDry)
				{
					clsInit.appMarble.cmdAirDryMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SawHorizontalMillingRough)
				{
					clsInit.appMarble.cmdSawHorizontalMillingRoughMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.SawVerticalMillingRough)
				{
					clsInit.appMarble.cmdSawVerticalMillingRoughMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.EasyDraw)
				{
					clsInit.appMarble.cmdEasyDrawing();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.PocketByDrill)
				{
					clsInit.appMarble.cmdPocketByDrillMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Milling5AxisRotary)
				{
					clsInit.appMarble.cmdMilling5AxisRotaryMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.Milling5AxisFlat)
				{
					clsInit.appMarble.cmdMilling5AxisFlatMenu();
				}
				else if (clsMarble.frmOPCommands.CommandType == MarbleItemType.HorizontalVerticalCut)
				{
					clsInit.appMarble.cmdHorVerBothCut();
				}
				return;
			}
			if (control.Name == clsItem.FrmMach2.btn_shape.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdShapeMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_contour.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdContourMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_profiling.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdProfileMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_profilecurve.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdProfileCurveMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_engraving.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmd3DFileAdd();
			}
			if (control.Name == clsItem.FrmMach2.btn_library.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdLibraryMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_text.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdTextMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_slices.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdSlicing();
			}
			if (control.Name == clsItem.FrmMach2.btn_materialclean.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdCleanMaterail();
			}
			if (control.Name == clsItem.FrmMach2.btn_sweep.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdSweepMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_cavity.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdCavityMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_tap.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdTapMenu();
			}
			if (control.Name == clsItem.FrmMach2.btn_oplist.Name)
			{
				if (!clsItem.FrmMach2.pnl_drawingjob.Visible)
				{
					int num = 1410;
					if (!MarbleTempVars.DockRightEnable)
					{
						num += 340;
					}
					clsItem.FrmMach2.pnl_drawviewport.Width = num - clsItem.FrmMach2.pnl_drawingjob.Width;
					clsItem.FrmMach2.pnl_drawingjob.Visible = true;
				}
				else
				{
					int num2 = 1090;
					if (!MarbleTempVars.DockRightEnable)
					{
						num2 += 340;
					}
					clsItem.FrmMach2.pnl_drawingjob.Visible = false;
					clsItem.FrmMach2.pnl_drawviewport.Width = num2 + clsItem.FrmMach2.pnl_drawingjob.Width;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_pointerpartpoints.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdPointerSlabBorder();
			}
			if (control.Name == clsItem.FrmMach2.btn_pointersave.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdPointerSave();
			}
			if (control.Name == clsItem.FrmMach2.btn_pointereditdrawing.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdPointerDrawEdit();
			}
			if (control.Name == clsItem.FrmMach2.btn_pointercreatematerial.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doMaterialCreateFromTempDrawings();
			}
			if (control.Name == clsItem.FrmMach2.btn_pointercreatepart.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doPartCreateFromTempDrawings();
			}
			if (control.Name == clsItem.FrmMach2.btn_pointerslabborders.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdPointerSlabBorder();
			}
			if (control.Name == clsItem.FrmMach2.btn_pointerrectmaterial.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsAppMarbleVars.cmdMarble.ShowMaterialPage();
			}
			if (control.Name == clsItem.FrmMach2.btn_photodelete.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doDeleteCameraImage();
			}
			if (control.Name == clsItem.FrmMach2.btn_photodrawpart.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsAppMarbleVars.cmdMarble.ShowDrawingMenu(180, 165);
			}
			if (control.Name == clsItem.FrmMach2.btn_photoget.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				if (!AppBool.CameraCapturing & !AppBool.CameraMakeItReady & buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable)
				{
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.CameraReady);
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_photoimport.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				Image image = null;
				clsInit.appMarble.cmdImportImage(ref image);
				AppBool.SaveByTick = true;
				if (image != null)
				{
					clsInit.appMarble.doDeleteMaterialImage();
					clsInit.appMarble.cmdTakePhoto(image);
					clsInit.appMarble.activeJob.Material.matImage = null;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_photosave.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdPointerSave();
			}
			if (control.Name == clsItem.FrmMach2.btn_photoeditdrawing.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdPointerDrawEdit();
			}
			if (control.Name == clsItem.FrmMach2.btn_photoslabborders.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdPointerSlabBorder();
			}
			if (control.Name == clsItem.FrmMach2.btn_move.Name && clsAppMarbleItems.frmMove != null)
			{
				if (!clsAppMarbleItems.frmMove.Visible)
				{
					clsAppMarbleItems.frmMove.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmMove.PropertiesForm.FormPosition = FormStartPosition.Manual;
					clsAppMarbleItems.frmMove.PropertiesForm.TopMost = true;
					clsAppMarbleItems.frmMove.TopMost = true;
					clsAppMarbleItems.frmMove.Left = 450;
					clsAppMarbleItems.frmMove.Top = 55;
					clsAppMarbleItems.frmMove.Init();
					clsAppMarbleItems.frmMove.Visible = true;
				}
				else
				{
					clsAppMarbleItems.frmMove.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_rotate.Name)
			{
				if (!clsAppMarbleItems.frmRotate.Visible)
				{
					clsAppMarbleItems.frmRotate.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmRotate.PropertiesForm.FormPosition = FormStartPosition.Manual;
					clsAppMarbleItems.frmRotate.PropertiesForm.TopMost = true;
					clsAppMarbleItems.frmRotate.TopMost = true;
					clsAppMarbleItems.frmRotate.Left = 450;
					clsAppMarbleItems.frmRotate.Top = 55;
					clsAppMarbleItems.frmRotate.Init();
					clsAppMarbleItems.frmRotate.Visible = true;
				}
				else
				{
					clsAppMarbleItems.frmRotate.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_mirror.Name)
			{
				if (clsAppMarbleItems.frmMirror == null)
				{
					clsAppMarbleItems.frmMirror = new F_MarbleEventMirror();
				}
				clsAppMarbleItems.frmMirror.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmMirror.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmMirror.TopMost = false;
				clsAppMarbleItems.frmMirror.Left = 450;
				clsAppMarbleItems.frmMirror.Top = 55;
				clsAppMarbleItems.frmMirror.Init();
				clsAppMarbleItems.frmMirror.ShowDialog();
				if (clsAppMarbleItems.frmMirror.PropertiesForm.Result == DialogResult.OK)
				{
					clsInit.appMarble.doMirrorSelectedItem();
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_scale.Name)
			{
				if (clsAppMarbleItems.frmScale == null)
				{
					clsAppMarbleItems.frmScale = new F_MarbleEventScale();
				}
				clsAppMarbleItems.frmScale.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmScale.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmScale.TopMost = false;
				clsAppMarbleItems.frmScale.Left = 450;
				clsAppMarbleItems.frmScale.Top = 55;
				List<Entity> list = new List<Entity>();
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
					if (entity.Selected && ((entity.EntityData != null) & (entity.EntityData is CustomData)))
					{
						list.Add(entity);
					}
				}
				if (list.Count > 0)
				{
					Point3D MinPoint = new Point3D();
					Point3D MidPoint = new Point3D();
					Point3D MaxPoint = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(list, ref MinPoint, ref MidPoint, ref MaxPoint);
					buMarbleCalc.varMarbleRunSettings.ScaleWidth = Math.Round(MaxPoint.X - MinPoint.X, 3);
					buMarbleCalc.varMarbleRunSettings.ScaleHeight = Math.Round(MaxPoint.Y - MinPoint.Y, 3);
					clsAppMarbleItems.frmScale.Init();
					clsAppMarbleItems.frmScale.ShowDialog();
					if (clsAppMarbleItems.frmScale.PropertiesForm.Result == DialogResult.OK)
					{
						clsInit.appMarble.doScaleSelectedItem();
					}
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_copy.Name)
			{
				if (clsAppMarbleItems.frmCopy == null)
				{
					clsAppMarbleItems.frmCopy = new F_MarbleEventCopy();
				}
				clsAppMarbleItems.frmCopy.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmCopy.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmCopy.Left = 450;
				clsAppMarbleItems.frmCopy.Top = 55;
				clsAppMarbleItems.frmCopy.Init();
				clsAppMarbleItems.frmCopy.ShowDialog();
				if (clsAppMarbleItems.frmCopy.PropertiesForm.Result == DialogResult.OK)
				{
					clsInit.appMarble.doCopySelectedItem(buMarbleCalc.varMarbleRunSettings.CopyXDistance, buMarbleCalc.varMarbleRunSettings.CopyYDistance);
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_copymulti.Name)
			{
				if (clsAppMarbleItems.frmCopyMulti == null)
				{
					clsAppMarbleItems.frmCopyMulti = new F_MarbleEventCopyMulti();
				}
				clsAppMarbleItems.frmCopyMulti.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsAppMarbleItems.frmCopyMulti.PropertiesForm.FormPosition = FormStartPosition.Manual;
				clsAppMarbleItems.frmCopyMulti.Left = 450;
				clsAppMarbleItems.frmCopyMulti.Top = 55;
				clsAppMarbleItems.frmCopyMulti.Init();
				clsAppMarbleItems.frmCopyMulti.ShowDialog();
				if (clsAppMarbleItems.frmCopyMulti.PropertiesForm.Result == DialogResult.OK)
				{
					clsInit.appMarble.doCopySelectedItem(buMarbleCalc.varMarbleRunSettings.CopyXDistance, buMarbleCalc.varMarbleRunSettings.CopyYDistance, buMarbleCalc.varMarbleRunSettings.CopyXCount, buMarbleCalc.varMarbleRunSettings.CopyYCount);
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_alignments.Name && buMarbleForms.frmEventAling != null)
			{
				if (!buMarbleForms.frmEventAling.Visible)
				{
					buMarbleForms.frmEventAling.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					buMarbleForms.frmEventAling.PropertiesForm.FormPosition = FormStartPosition.Manual;
					buMarbleForms.frmEventAling.PropertiesForm.TopMost = true;
					buMarbleForms.frmEventAling.TopMost = true;
					buMarbleForms.frmEventAling.Left = 450;
					buMarbleForms.frmEventAling.Top = 55;
					buMarbleForms.frmEventAling.Init();
					buMarbleForms.frmEventAling.Visible = true;
				}
				else
				{
					buMarbleForms.frmEventAling.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_eventsetangle.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doSetAngle();
			}
			if (control.Name == clsItem.FrmMach2.btn_slatadd.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doSlatAdd(null);
			}
			if (control.Name == clsItem.FrmMach2.btn_collopseadd.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doCollopseAdd(null);
			}
			if (control.Name == clsItem.FrmMach2.btn_extend.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doExtend();
			}
			if (control.Name == clsItem.FrmMach2.btn_break.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doBreak();
			}
			if (control.Name == clsItem.FrmMach2.btn_offset.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.doOffset();
			}
			if (control.Name == clsAppMarbleItems.frmRotate.btn_eventrotateplus.Name)
			{
				clsInit.appMarble.doRotateSelectedItem(0.0 - clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmRotate.btn_eventRotateminus.Name)
			{
				clsInit.appMarble.doRotateSelectedItem(clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmoveleft.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(0.0 - clsAppMarbleItems.frmMove.spn_eventmovevalue.Value, 0.0);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmoveright.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(clsAppMarbleItems.frmMove.spn_eventmovevalue.Value, 0.0);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmoveup.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(0.0, clsAppMarbleItems.frmMove.spn_eventmovevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsAppMarbleItems.frmMove.btn_eventmovedown.Name)
			{
				clsInit.appMarble.doMoveSelectedItem(0.0, 0.0 - clsAppMarbleItems.frmMove.spn_eventmovevalue.Value);
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
			}
			if (control.Name == clsItem.FrmMach2.btn_eventdelete.Name && !clsInit.appMarble.MoveCreatedEntity)
			{
				clsInit.appMarble.doDeleteItems(All: false, -1);
			}
			if (((control.Name == clsItem.FrmMach2.btn_eventdeleteall.Name) | (control.Name == clsItem.FrmMach2.btn_eventdeleteall2.Name)) && !clsInit.appMarble.MoveCreatedEntity)
			{
				clsInit.appMarble.doDeleteItems(All: true, -1);
			}
			if (control.Name == clsItem.FrmMach2.btn_vacuum.Name)
			{
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsInit.appMarble.cmdVacuum();
			}
			if (control.Name == clsItem.FrmMach2.btn_dimensionaligned.Name)
			{
				clsItem.FrmMach2.buTab_Options.Visible = false;
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsVar.varEntities.DimensionTextHeight = 40.0;
				clsInit.appCommand.cmdDrawDimensionAligned();
			}
			if (control.Name == clsItem.FrmMach2.btn_dimensionlinear.Name)
			{
				clsItem.FrmMach2.buTab_Options.Visible = false;
				clsItem.FrmMach2.buTab_drawing.Visible = false;
				clsVar.varEntities.DimensionTextHeight = 40.0;
				clsInit.appCommand.cmdDrawDimensionLinear();
			}
			if (control.Name == clsItem.FrmMach2.btn_dimensionmenu.Name)
			{
				if (!clsItem.FrmMach2.buTab_Options.Visible)
				{
					clsItem.FrmMach2.buTab_Options.Visible = true;
				}
				else
				{
					clsItem.FrmMach2.buTab_Options.Visible = false;
				}
				clsItem.FrmMach2.lst_dimensions.Items.Clear();
				int num3 = 1;
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData == null)
					{
						continue;
					}
					CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData as CustomData;
					if ((customData.typeDefination == entityTypeDefination.Dimension) & (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] is Dimension))
					{
						string text = num3 + " - ";
						if (customData.infoString != null)
						{
							text = text + customData.infoString + " ";
						}
						Dimension dimension = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] as Dimension;
						text = text + " L: " + dimension.TextString;
						clsItem.FrmMach2.lst_dimensions.Items.Add(text);
						num3++;
					}
				}
				clsItem.FrmMach2.buTab_Options.SelectedIndex = 0;
			}
			if (control.Name == clsItem.FrmMach2.btn_dimensiondeleteall.Name)
			{
				clsInit.appMarble.DeleteAllDimension();
			}
			if (control.Name == clsItem.FrmMach2.btn_dimensiondelete.Name && clsItem.FrmMach2.lst_dimensions.SelectedIndex >= 0)
			{
				clsInit.appMarble.DeleteDimension(clsItem.FrmMach2.lst_dimensions.SelectedIndex);
				clsItem.FrmMach2.lst_dimensions.Items.RemoveAt(clsItem.FrmMach2.lst_dimensions.SelectedIndex);
			}
			if (control.Name == clsItem.FrmMach2.btn_saveOP.Name)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathJob;
				saveFileDialog.Filter = "buMarble Job File (*.bumarble)|*.bumarble";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					buMarbleCalc.varMarbleRunSettings.pathJob = buFile.GetPath(saveFileDialog.FileName);
					clsInit.appMarble.SaveMarbleJob(saveFileDialog.FileName, clsInit.appMarble.activeJob);
					AppBool.SaveByTick = true;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_openOP.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathJob;
				openFileDialog.Filter = "buMarble Job File (*.bumarble)|*.bumarble";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					buMarbleCalc.varMarbleRunSettings.pathJob = buFile.GetPath(openFileDialog.FileName);
					clsInit.appMarble.OpenMarbleJob(openFileDialog.FileName, ref clsInit.appMarble.activeJob);
					AppBool.SaveByTick = true;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_undo.Name)
			{
				clsInit.appMarble.UndoGetback();
			}
		}
		catch (Exception)
		{
		}
	}

	public void clickCommandsMenuAndSettings(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (control.Name == clsItem.FrmMenu.btn_selectmaterial.Name)
			{
				clsInit.cMarble.ShowMaterialPage();
				clsInit.appMarble.SaveMarbleFile();
			}
			if (control.Name == clsItem.FrmMenu.btn_tools.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowToolsList(buMarbleCalc.varMarbleSettings.ToolListMode, MarbleToolType.Saw);
			}
			if (control.Name == clsItem.FrmMenu.btn_g54offset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowG54List();
			}
			if (control.Name == clsItem.FrmMenu.btn_password.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowPassword();
			}
			if (control.Name == clsItem.FrmMenu.btn_calculations.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCalculations();
			}
			if (control.Name == clsItem.FrmMenu.btn_report.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowReport();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_test.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTest();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_simulationpanel.Name)
			{
				clsInit.appMarble.doSimulationCalculate(ref clsInit.appMarble.activeJob);
				clsInit.appMarble.cmdShowSimulationPanel();
				if (!ccVars.Pages[ccVars.PageIndex].Form.viewportcad.IsAnimationRunning)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartAnimation();
				}
				clsInit.appMarble.DeleteSimulationEntities();
				clsInit.appMarble.DrawSimulationEntities(cam: false, machine: true, DrawAllTool: true, MarbleToolType.Saw);
				clsInit.appMarble.MoveSimPart(new Pnt6DSimMove(-290.0, -200.0, 500.0, 0.0, 0.0, 0.0), SpindleDown: false, buMarbleCalc.activeToolSaw);
				clsItem.FrmMenu.Visible = false;
			}
			if (control.Name == clsItem.FrmMenu.btn_maintanance.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMaintanance();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_warmup.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowWarmUp();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_materialmeasurement.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMaterialMeasure();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenu.btn_closepc.Name && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWanttoClosePC) == DialogResult.Yes)
			{
				clsAppMarbleVars.cmdMarble.cmdClosePC();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_marblecamsettings.Name)
			{
				clsInit.appMarble.cmdCamSettingsPage();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_millingsettings.Name)
			{
				clsInit.appMarble.cmdSettingsMilling2D(MarbleCamType.MillingContour2D);
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_settingsaxes.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMachineSettings();
				SaveParameter();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_servoconnection.Name)
			{
				clsAppMarbleVars.cmdMarble.cmdCMZSBDBridge();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_toolsettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowMachineSettingsV2(0);
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_vagoonsettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowWagonSettings();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_camerasettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCameraSettings();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_calibration.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCalibration();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_cameracalibration.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCameraCalibration();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_AbsoluteHomeSet.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowAbsoluteSet();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_G54Offset.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowG54Set();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_kinematic.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowKinematic();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_axesgain.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowAxesGain();
			}
			if (control.Name == clsItem.FrmMenuSettings.btn_GantryPage.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowGantySettings();
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_techniciandefine.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowTechnicianDefine();
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_userdefine.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowUserDefine();
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_language.Name)
			{
				if (AppSecurity.PasswordLevel < 2)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordLevelNotEnough);
					return;
				}
				clsAppMarbleVars.cmdMarble.ShowLanguageMenu();
				clsItem.FrmMach2.LoadLanguage();
				clsItem.FrmMenu.LoadLanguage();
				clsItem.FrmMenuSettings.LoadLanguage();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_debug.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowDebug();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_counters.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowCounters();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_watch.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowWatch();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMenuAdminSettings.btn_userinterfacesettings.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowUserInterfaceSettings();
				AppBool.VisualUpdateForce = true;
				UpdateVisualThings();
				if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
				{
					clsItem.FrmMenu.Visible = false;
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_contoursettings.Name)
			{
				if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 4)
				{
					MainControlsToParameter(FromControlToValues: true);
					clsInit.appMarble.cmdContourUserSettingsPage();
					MainControlsToParameter(FromControlToValues: false);
				}
				else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 3)
				{
					MainControlsToParameter(FromControlToValues: true);
					clsInit.appMarble.cmdContourSettingsPageAsLessData();
					MainControlsToParameter(FromControlToValues: false);
				}
			}
			if (control.Name == clsItem.FrmMach2.btn_information.Name)
			{
				clsAppMarbleVars.cmdMarble.ShowInformation();
			}
			if (control.Name == clsItem.FrmMach2.btn_viewback.Name)
			{
				clsAppMarbleVars.cmdMarble.SetView(viewType.Rear);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewfront.Name)
			{
				clsAppMarbleVars.cmdMarble.SetView(viewType.Front);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewleft.Name)
			{
				clsAppMarbleVars.cmdMarble.SetView(viewType.Left);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewrgiht.Name)
			{
				clsAppMarbleVars.cmdMarble.SetView(viewType.Right);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewtop.Name)
			{
				clsAppMarbleVars.cmdMarble.SetView(viewType.Top);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewiso.Name)
			{
				clsAppMarbleVars.cmdMarble.SetView(viewType.Trimetric);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewzoomfit.Name)
			{
				clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomFit);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewzoomin.Name)
			{
				clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomIn);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewzoomout.Name)
			{
				clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomOut);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewzoomwindow.Name)
			{
				clsAppMarbleVars.cmdMarble.SetZoom(ZoomType.ZoomWindow);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewpandown.Name)
			{
				clsAppMarbleVars.cmdMarble.SetPan(PanType.panDown);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewpanleft.Name)
			{
				clsAppMarbleVars.cmdMarble.SetPan(PanType.panLeft);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewpanright.Name)
			{
				clsAppMarbleVars.cmdMarble.SetPan(PanType.PanRight);
			}
			if (control.Name == clsItem.FrmMach2.btn_viewpanup.Name)
			{
				clsAppMarbleVars.cmdMarble.SetPan(PanType.panUp);
			}
			if (buMarbleCalc.varMarbleSettings.CloseMenuPageAfterCommand)
			{
				clsItem.FrmMenuSettings.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private void mouseMoveViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (!(control.Name == buEyeItems.viewportCNC.Name))
		{
			return;
		}
		buEyeItems.viewportCNC.ScreenToPlane(e.Location, ccVars.planeActive, out pntActive);
		if (pntActive != null)
		{
			string text = "X: " + pntActive.X.ToString("f2") + " , Y: " + pntActive.Y.ToString("f2") + " , Z: " + pntActive.Z.ToString("f2");
			if (ccVars.planeActive != null && buVector5.isPlaneXYorYX(ccVars.planeActive))
			{
				text = "X: " + pntActive.X.ToString("f2") + " , Y: " + pntActive.Y.ToString("f2");
			}
			if (ccVars.planeActive != null && buVector5.isPlaneXZorZX(ccVars.planeActive))
			{
				text = "X: " + pntActive.X.ToString("f2") + " , Z: " + pntActive.Z.ToString("f2");
			}
			if (ccVars.planeActive != null && buVector5.isPlaneYZorZY(ccVars.planeActive))
			{
				text = "Y: " + pntActive.Y.ToString("f2") + " , Z: " + pntActive.Z.ToString("f2");
			}
			clsItem.FrmMach2.lbl_coord.Text = text;
		}
	}

	private void mouseDownViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (!(control.Name == buEyeItems.viewportCNC.Name))
		{
		}
	}

	private void mouseUpViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (e.Button == MouseButtons.Left && !(control.Name == buEyeItems.viewportCNC.Name))
		{
		}
	}

	private void checkCheckedChanged(object sender, bool CheckStatus)
	{
		Control control = sender as Control;
		if (AppBool.Inited)
		{
			if (control.Name == clsItem.FrmMach2.chk_incremental.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.IncrementalMode = clsItem.FrmMach2.chk_incremental.Check;
				clsItem.FrmMach2.chk_absolute.Check = false;
				clsAppMarbleVars.varInterface.AbsoluteMode = false;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach2.chk_absolute.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.AbsoluteMode = clsItem.FrmMach2.chk_absolute.Check;
				clsItem.FrmMach2.chk_incremental.Check = false;
				clsAppMarbleVars.varInterface.IncrementalMode = false;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach2.chk_machinezero.Name)
			{
				AppBool.Inited = false;
				clsItem.FrmMach2.chk_partzero.Check = false;
				clsAppMarbleVars.varInterface.PartZeroMode = false;
				AppBool.Inited = true;
				AppBool.SaveByTick = true;
			}
			if (control.Name == clsItem.FrmMach2.chk_partzero.Name)
			{
				AppBool.Inited = false;
				clsItem.FrmMach2.chk_machinezero.Check = false;
				clsAppMarbleVars.varInterface.PartZeroMode = true;
				AppBool.Inited = true;
				AppBool.SaveByTick = true;
			}
			if (control.Name == clsItem.FrmMach2.chk_addsawthickness.Name)
			{
				AppBool.Inited = false;
				clsAppMarbleVars.varInterface.AddSawThicknessToMove = clsItem.FrmMach2.chk_addsawthickness.Check;
				AppBool.Inited = true;
			}
		}
	}

	private void trackValueChanged(object sender, double Val)
	{
		Control control = sender as Control;
		if (AppBool.Connected)
		{
			if (control.Name == clsAppMarbleItems.frmCoordsV2.track_spidle.Name && !clsAppMarbleVars.varApp.SpindlePersentageFromPLC)
			{
				clsAppMarbleItems.frmCoordsV2.track_spidle.Value = Convert.ToInt32(Val);
				clsAppMarbleVars.varInterface.SpindleSpeedOverride = Val;
				buPLCHandler.WriteVariableLREAL(CodesysMachine.RootGlobalString + "AppRun.SpindleOverride", clsAppMarbleVars.varInterface.SpindleSpeedOverride);
				buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "AppRun.SpindleSpeedUpdate", true);
				clsAppMarbleVars.varInterface.SawSpeedOverride = Val;
				buPLCHandler.WriteVariableLREAL(CodesysMachine.RootGlobalString + "AppRun.SawOverride", clsAppMarbleVars.varInterface.SawSpeedOverride);
				buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "AppRun.SawSpeedUpdate", true);
			}
			if (clsAppMarbleVars.cMachine.runSystem.SimulatedIO)
			{
				if (control.Name == clsAppMarbleItems.frmCoordsV2.track_operationspeed.Name)
				{
					clsAppMarbleItems.frmSpeedsV1.track_operationspeed.Value = Convert.ToInt32(Val);
					clsAppMarbleVars.varInterface.OperationSpeed = Val;
					buPLCHandler.WriteVariableLREAL(CodesysMachine.RootPersistentString + "sysSet.Feed.FeedOverrideG1", clsAppMarbleVars.varInterface.OperationSpeed);
				}
				if (control.Name == clsAppMarbleItems.frmCoordsV2.track_quickspeed.Name)
				{
					clsAppMarbleItems.frmSpeedsV1.track_quickspeed.Value = Convert.ToInt32(Val);
					clsAppMarbleVars.varInterface.QuickSpeed = Val;
					buPLCHandler.WriteVariableLREAL(CodesysMachine.RootPersistentString + "sysSet.Feed.FeedOverrideG0", clsAppMarbleVars.varInterface.QuickSpeed);
				}
			}
		}
		else
		{
			if (!(control.Name == clsAppMarbleItems.frmCoordsV2.track_operationspeed.Name))
			{
				return;
			}
			clsMarble.SimStep = Convert.ToInt32(Val / 10.0);
			clsInit.appMarble.timSim.Interval = 20;
			if (clsMarble.SimStep <= 0)
			{
				clsMarble.SimStep = 1;
				clsInit.appMarble.timSim.Interval = 50;
				if (Val == 2.0)
				{
					clsInit.appMarble.timSim.Interval = 100;
				}
				if (Val == 1.0)
				{
					clsInit.appMarble.timSim.Interval = 200;
				}
			}
		}
	}

	private void spinValueChanged(object sender, double Val)
	{
		Control control = sender as Control;
		if (AppBool.Inited)
		{
			if (control.Name == clsItem.FrmMach2.spn_xpos.Name)
			{
				AppBool.Inited = false;
				clsItem.FrmMach2.btn_xplus.Aux.ValDouble = clsItem.FrmMach2.spn_xpos.Value;
				clsItem.FrmMach2.btn_xminus.Aux.ValDouble = clsItem.FrmMach2.spn_xpos.Value;
				clsAppMarbleVars.varInterface.JogMoveXValue = clsItem.FrmMach2.spn_xpos.Value;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach2.spn_ypos.Name)
			{
				AppBool.Inited = false;
				clsItem.FrmMach2.btn_yplus.Aux.ValDouble = clsItem.FrmMach2.spn_ypos.Value;
				clsItem.FrmMach2.btn_yminus.Aux.ValDouble = clsItem.FrmMach2.spn_ypos.Value;
				clsAppMarbleVars.varInterface.JogMoveYValue = clsItem.FrmMach2.spn_ypos.Value;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach2.spn_zpos.Name)
			{
				AppBool.Inited = false;
				clsItem.FrmMach2.btn_zplus.Aux.ValDouble = clsItem.FrmMach2.spn_zpos.Value;
				clsItem.FrmMach2.btn_zminus.Aux.ValDouble = clsItem.FrmMach2.spn_zpos.Value;
				clsAppMarbleVars.varInterface.JogMoveZValue = clsItem.FrmMach2.spn_zpos.Value;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach2.spn_apos.Name)
			{
				AppBool.Inited = false;
				clsItem.FrmMach2.btn_aplus.Aux.ValDouble = clsItem.FrmMach2.spn_apos.Value;
				clsItem.FrmMach2.btn_aminus.Aux.ValDouble = clsItem.FrmMach2.spn_apos.Value;
				clsAppMarbleVars.varInterface.JogMoveAValue = clsItem.FrmMach2.spn_apos.Value;
				AppBool.Inited = true;
			}
			if (control.Name == clsItem.FrmMach2.spn_cpos.Name)
			{
				AppBool.Inited = false;
				clsItem.FrmMach2.btn_cplus.Aux.ValDouble = clsItem.FrmMach2.spn_cpos.Value;
				clsItem.FrmMach2.btn_cminus.Aux.ValDouble = clsItem.FrmMach2.spn_cpos.Value;
				clsAppMarbleVars.varInterface.JogMoveCValue = clsItem.FrmMach2.spn_cpos.Value;
				AppBool.Inited = true;
			}
			if (control.Name == clsAppMarbleItems.frmMove.spn_eventmovevalue.Name)
			{
				buMarbleCalc.varMarbleRunSettings.ManuelMove = clsAppMarbleItems.frmMove.spn_eventmovevalue.Value;
				AppBool.SaveByTick = true;
			}
			if (control.Name == clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Name)
			{
				buMarbleCalc.varMarbleRunSettings.ManuelRotate = clsAppMarbleItems.frmRotate.spn_eventrotatevalue.Value;
				AppBool.SaveByTick = true;
			}
			clsAppMarbleVars.varApp.MaterialWidth = clsItem.FrmMach2.spn_semiautomaterialheight.Value;
			clsAppMarbleVars.varApp.MaterialHeight = clsItem.FrmMach2.spn_semiautomaterialwidth.Value;
			clsAppMarbleVars.varApp.MaterialThickness = clsItem.FrmMach2.spn_cammarblethickness.Value;
			clsAppMarbleVars.varApp.SemiAutoSafeZ = clsItem.FrmMach2.spn_camsafedis.Value;
		}
	}

	private void spinClick(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (!AppBool.TouchPad)
		{
			return;
		}
		F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
		f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
		f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
		f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
		if (!buNumeric5.IsNumeric(f_KeyPadNumV.Value))
		{
			return;
		}
		buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
		if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 2 && clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 4)
		{
			SemiAutoParameterChange(FromControlToValues: true);
			if (AppBool.Connected)
			{
				clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
			}
		}
	}

	private void spinLeave(object sender, EventArgs e)
	{
		if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 2)
		{
			SemiAutoParameterChange(FromControlToValues: true);
			if (AppBool.Connected)
			{
				clsAppMarbleVars.cmdMarble.WriteSemiAutoParameters();
			}
		}
	}

	private void spinKeyDown(object sender, KeyEventArgs e)
	{
	}

	private void controlEnter(object sender, EventArgs e)
	{
		Control control = sender as Control;
	}

	private void buTabSelectedIndexChanged(object sender, EventArgs e)
	{
		if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 0)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
			{
				buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", false);
			}
			if (clsItem.FrmMach2.pnl_mainviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach2.pnl_manuelviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_mainviewport.Controls.Add(clsItem.FrmMach2.pnl_manuelviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_semiautoviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_mainviewport.Controls.Add(clsItem.FrmMach2.pnl_semiautoviewport.Controls[0]);
				}
				buEyeItems.viewportCNC.ZoomFit();
				buEyeItems.viewportCNC.ZoomOut(10);
			}
			AppBool.EditMode = false;
		}
		else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 1)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
			{
				buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", false);
			}
			if (clsItem.FrmMach2.pnl_manuelviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach2.pnl_mainviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_manuelviewport.Controls.Add(clsItem.FrmMach2.pnl_mainviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_semiautoviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_manuelviewport.Controls.Add(clsItem.FrmMach2.pnl_semiautoviewport.Controls[0]);
				}
				buEyeItems.viewportCNC.ZoomFit();
				buEyeItems.viewportCNC.ZoomOut(10);
			}
			AppBool.EditMode = false;
		}
		else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 2)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
			{
				buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", false);
			}
			if (clsItem.FrmMach2.pnl_semiautoviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach2.pnl_mainviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_semiautoviewport.Controls.Add(clsItem.FrmMach2.pnl_mainviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_manuelviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_semiautoviewport.Controls.Add(clsItem.FrmMach2.pnl_manuelviewport.Controls[0]);
				}
				buEyeItems.viewportCNC.ZoomFit();
				buEyeItems.viewportCNC.ZoomOut(10);
			}
			if (clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 0)
			{
				if (clsItem.FrmMach2.pnl_horviewport.Controls.Count == 0)
				{
					if (clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_horviewport.Controls.Add(clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_horviewport.Controls.Add(clsItem.FrmMach2.pnl_verviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_horviewport.Controls.Add(clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
					{
						if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
						{
							clsItem.FrmMach2.pnl_horviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
						}
						else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
						{
							clsItem.FrmMach2.pnl_horviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
						}
						else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
						{
							clsItem.FrmMach2.pnl_horviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
						}
					}
				}
			}
			else if (clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 1)
			{
				if (clsItem.FrmMach2.pnl_verviewport.Controls.Count == 0)
				{
					if (clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_verviewport.Controls.Add(clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_verviewport.Controls.Add(clsItem.FrmMach2.pnl_horviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_verviewport.Controls.Add(clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
					{
						if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
						{
							clsItem.FrmMach2.pnl_verviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
						}
						else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
						{
							clsItem.FrmMach2.pnl_verviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
						}
						else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
						{
							clsItem.FrmMach2.pnl_verviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
						}
					}
				}
			}
			else if (clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 2)
			{
				if (clsItem.FrmMach2.pnl_horverviewport.Controls.Count == 0)
				{
					if (clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_horverviewport.Controls.Add(clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_horverviewport.Controls.Add(clsItem.FrmMach2.pnl_horviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_horverviewport.Controls.Add(clsItem.FrmMach2.pnl_verviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
					{
						if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
						{
							clsItem.FrmMach2.pnl_horverviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
						}
						else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
						{
							clsItem.FrmMach2.pnl_horverviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
						}
						else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
						{
							clsItem.FrmMach2.pnl_horverviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
						}
					}
				}
			}
			else if (clsItem.FrmMach2.buTab_sawmode.SelectedIndex == 3 && clsItem.FrmMach2.pnl_singleviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_singleviewport.Controls.Add(clsItem.FrmMach2.pnl_horviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_singleviewport.Controls.Add(clsItem.FrmMach2.pnl_verviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_singleviewport.Controls.Add(clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count > 0)
				{
					if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
					{
						clsItem.FrmMach2.pnl_singleviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2)
					{
						clsItem.FrmMach2.pnl_singleviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[1]);
					}
					else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 3)
					{
						clsItem.FrmMach2.pnl_singleviewport.Controls.Add(clsItem.FrmMach2.pnl_drawviewport.Controls[2]);
					}
				}
			}
			clsInit.appMarble.DeleteSimulationEntities();
			AppBool.EditMode = true;
		}
		else if (clsItem.FrmMach2.buTab_Main.SelectedIndex == 3)
		{
			if (clsAppMarbleVars.cMachine.runSystem.SemiAuto && AppBool.Connected)
			{
				buPLCHandler.WriteVariableBOOL(CodesysMachine.RootGlobalString + "appRun.SemiAutoEnable", false);
			}
			if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 0)
			{
				if (clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_horviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_verviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 1)
			{
				if (clsItem.FrmMach2.pnl_drawviewport.Controls[0] is buTab)
				{
					if (clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_horviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_verviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
					}
					else if (clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
					{
						clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
					}
					buEyeItems.viewportCadCam.ZoomFit();
					buEyeItems.viewportCadCam.ZoomOut(10);
				}
			}
			else if (clsItem.FrmMach2.pnl_drawviewport.Controls.Count == 2 && ((clsItem.FrmMach2.pnl_drawviewport.Controls[0] is buTab) & (clsItem.FrmMach2.pnl_drawviewport.Controls[1] is buTab)))
			{
				if (clsItem.FrmMach2.pnl_horviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_horviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_verviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_verviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_horverviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_horverviewport.Controls[0]);
				}
				else if (clsItem.FrmMach2.pnl_singleviewport.Controls.Count > 0)
				{
					clsItem.FrmMach2.pnl_drawviewport.Controls.Add(clsItem.FrmMach2.pnl_singleviewport.Controls[0]);
				}
				buEyeItems.viewportCadCam.ZoomFit();
				buEyeItems.viewportCadCam.ZoomOut(10);
			}
			clsInit.appMarble.DeleteSimulationEntities();
			AppBool.EditMode = true;
		}
		MarbleTempVars.LastSelectedTabPage = clsItem.FrmMach2.buTab_Main.SelectedIndex;
	}

	public void FormKeyDown(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == clsItem.FrmMach2.Name)
		{
			if (e.KeyCode == Keys.Escape)
			{
				clickCommands(clsItem.FrmMach2.btn_cancel, new EventArgs());
			}
			clsAppMarbleVars.cmdMarble.FormKeyDownCommon(sender, e);
		}
	}

	public void UpdateVisualThings()
	{
		string text = "UpdateVisualThings";
		try
		{
			buLogMarbleVer5.addToLogList(sClass, text, "Started");
			if (buEyeVars.parVisual == null)
			{
				buEyeVars.parVisual = new clsVisualVars();
			}
			clsItem.FrmMach2.buTab_Main.ItemSize = new Size(1, 1);
			clsItem.FrmMach2.buTab_drawing.ItemSize = new Size(1, 1);
			clsItem.FrmMach2.buTab_sawmode.ItemSize = new Size(1, 1);
			clsItem.FrmMach2.buTab_Options.ItemSize = new Size(1, 1);
			clsItem.FrmMach2.tabPage_photo.Text = "";
			clsItem.FrmMach2.tabPage_pointer.Text = "";
			clsItem.FrmMach2.tabPage_cad2D.Text = "";
			clsItem.FrmMach2.tabPage_function.Text = "";
			clsItem.FrmMach2.tabPage_cad3d.Text = "";
			clsItem.FrmMach2.tabPage_DimensionOptions.Text = "";
			clsItem.FrmMach2.tabPage_Misc.Text = "";
			buLogMarbleVer5.addToLogList(sClass, text, "Started", "frmCoordsV1");
			clsAppMarbleItems.frmCoordsV2.UpdateVisuals();
			clsAppMarbleItems.frmBottomPanelV1.UpdateVisuals();
			buLogMarbleVer5.addToLogList(sClass, text, "Finished", "frmCoordsV1");
			Control.ControlCollection controlCollection = null;
			controlCollection = clsItem.FrmMach2.tabPage_manuel.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.pnl_commnadtop.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.buGround1.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.pnl_cadcamevents.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.pnl_drawing.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.tabPage_photo.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.tabPage_pointer.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.tabPage_cad2D.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.tabPage_cad3d.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.tabPage_function.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.tabPage_SawMode.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			controlCollection = clsItem.FrmMach2.pnl_mainmenu.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
			clsAppMarbleItems.frmMDIPageV1.btn_vagonpark.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.TableEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_photopos.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepark.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepistondown.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_spindlepistonup.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_spindleheadpark.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineClose.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger;
			clsAppMarbleItems.frmMDIPageV1.btn_toolmagazineopen.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger;
			clsAppMarbleItems.frmMDIPageV1.btn_pensopenclose.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_cameraclose.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
			clsAppMarbleItems.frmMDIPageV1.btn_cameraopen.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.CameraEnable;
			clsItem.FrmMach2.btn_contour.Visible = clsVar.UserMode.MarbleMode.FileImport;
			clsItem.FrmMach2.btn_library.Visible = clsVar.UserMode.MarbleMode.Library;
			clsItem.FrmMach2.btn_profiling.Visible = clsVar.UserMode.MarbleMode.Profile;
			clsItem.FrmMach2.btn_profilecurve.Visible = clsVar.UserMode.MarbleMode.Profile;
			clsItem.FrmMach2.btn_engraving.Visible = clsVar.UserMode.MarbleMode.Engraving3Axis;
			clsItem.FrmMach2.btn_text.Visible = clsVar.UserMode.MarbleMode.Text;
			clsItem.FrmMach2.btn_slices.Visible = clsVar.UserMode.MarbleMode.FileImport;
			buLogMarbleVer5.addToLogList(sClass, text, "Finished");
			buLogMarbleVer5.saveLogList();
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, "", 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = clsItem.FrmMach2.pnl_mainmenu.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			clsItem.FrmMach2.btn_main.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_main.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 1)
		{
			clsItem.FrmMach2.btn_manuel.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_manuel.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 2)
		{
			clsItem.FrmMach2.btn_sawmode.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_sawmode.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 3)
		{
			clsItem.FrmMach2.btn_drawing.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.ButtonDownDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.ButtonOverDisplay.BackColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
			clsItem.FrmMach2.btn_drawing.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal.SelectionColor;
		}
	}

	public void MenuButtonSawModeColors(int PageIndex)
	{
		Control.ControlCollection controls = clsItem.FrmMach2.tabPage_SawMode.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			clsItem.FrmMach2.btn_horizontal = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_horizontal, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 1)
		{
			clsItem.FrmMach2.btn_vertical = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_vertical, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 2)
		{
			clsItem.FrmMach2.btn_horver = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_horver, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 3)
		{
			clsItem.FrmMach2.btn_single = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_single, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 4)
		{
			clsItem.FrmMach2.btn_semiAuto = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_semiAuto, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor);
		}
	}

	public void MenuDrawButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = clsItem.FrmMach2.pnl_drawing.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			clsItem.FrmMach2.btn_photo = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_photo, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 1)
		{
			clsItem.FrmMach2.btn_pointer = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_pointer, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 2)
		{
			clsItem.FrmMach2.btn_2DCad = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_2DCad, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 3)
		{
			clsItem.FrmMach2.btn_3DCad = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_3DCad, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 4)
		{
			clsItem.FrmMach2.btn_Functions = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_Functions, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
		if (PageIndex == 5)
		{
			clsItem.FrmMach2.btn_misc = buControlCommands.SetButtonColorAll(clsItem.FrmMach2.btn_misc, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
		}
	}

	public void OpenParameter()
	{
		try
		{
			if (cMarbleVars == null)
			{
				cMarbleVars = new clsAppMarbleVars();
			}
			cMarbleVars.Init();
			clsAppMarbleVars.cmdMarble.OpenParameter();
			Task.Run(delegate
			{
				clsAppMarbleVars.cmdMarble.OpenReport();
			});
		}
		catch (Exception)
		{
		}
	}

	public void SaveParameter()
	{
		try
		{
			clsAppMarbleVars.cmdMarble.SaveParameter();
		}
		catch (Exception)
		{
		}
	}

	public void SemiAutoParameterChange(bool FromControlToValues)
	{
		if (FromControlToValues)
		{
			clsAppMarbleVars.varApp.SemiAutoWidth = clsItem.FrmMach2.spn_semiautohorizontallen.Value;
			clsAppMarbleVars.varApp.SemiAutoHeight = clsItem.FrmMach2.spn_semiautoverticallen.Value;
			clsAppMarbleVars.varApp.SemiAutoCutFeed = clsItem.FrmMach2.spn_camcuttingspped.Value;
			clsAppMarbleVars.varApp.SemiAutoPlungeFeed = clsItem.FrmMach2.spn_camplungespeed.Value;
			clsAppMarbleVars.varApp.SemiAutoTargetZ = clsItem.FrmMach2.spn_camoperationZ.Value;
			clsAppMarbleVars.varApp.SemiAutoSafeZ = clsItem.FrmMach2.spn_camsafedis.Value;
			clsAppMarbleVars.varApp.MaterialHeight = clsItem.FrmMach2.spn_semiautomaterialheight.Value;
			clsAppMarbleVars.varApp.MaterialWidth = clsItem.FrmMach2.spn_semiautomaterialwidth.Value;
			clsAppMarbleVars.varApp.MaterialThickness = clsItem.FrmMach2.spn_cammarblethickness.Value;
		}
		else
		{
			clsItem.FrmMach2.spn_semiautohorizontallen.Value = clsAppMarbleVars.varApp.SemiAutoWidth;
			clsItem.FrmMach2.spn_semiautoverticallen.Value = clsAppMarbleVars.varApp.SemiAutoHeight;
			clsItem.FrmMach2.spn_camcuttingspped.Value = clsAppMarbleVars.varApp.SemiAutoCutFeed;
			clsItem.FrmMach2.spn_camplungespeed.Value = clsAppMarbleVars.varApp.SemiAutoPlungeFeed;
			clsItem.FrmMach2.spn_camoperationZ.Value = clsAppMarbleVars.varApp.SemiAutoTargetZ;
			clsItem.FrmMach2.spn_camsafedis.Value = clsAppMarbleVars.varApp.SemiAutoSafeZ;
			clsItem.FrmMach2.spn_semiautomaterialheight.Value = clsAppMarbleVars.varApp.MaterialHeight;
			clsItem.FrmMach2.spn_semiautomaterialwidth.Value = clsAppMarbleVars.varApp.MaterialWidth;
			clsItem.FrmMach2.spn_cammarblethickness.Value = clsAppMarbleVars.varApp.MaterialThickness;
		}
	}

	public void MainControlsToParameter(bool FromControlToValues)
	{
		if (FromControlToValues)
		{
			buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity = clsItem.FrmMach2.spn_camcuttingspped.Value;
			buMarbleCalc.varOperation.MaterialParameter.MaterialThickness = clsItem.FrmMach2.spn_cammarblethickness.Value;
			buMarbleCalc.varOperation.settingMarbleCam.TargetZ = clsItem.FrmMach2.spn_camoperationZ.Value;
			buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity = clsItem.FrmMach2.spn_camplungespeed.Value;
			buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance = clsItem.FrmMach2.spn_camcuttingstep.Value;
			buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance = clsItem.FrmMach2.spn_camsafedis.Value;
			buMarbleCalc.varMarbleRunSettings.CutLengthVertical = buMarbleForms.frmVerticalV4.spn_length.Value;
			buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal = buMarbleForms.frmHorizontalV4.spn_length.Value;
			buMarbleCalc.activeToolSaw.CamData.SpindleSpeed = clsItem.FrmMach2.spn_camspindlespeed.Value;
		}
		else
		{
			clsItem.FrmMach2.spn_camcuttingspped.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardCuttingVelocity;
			clsItem.FrmMach2.spn_cammarblethickness.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
			clsItem.FrmMach2.spn_camoperationZ.Value = buMarbleCalc.varOperation.settingMarbleCam.TargetZ;
			clsItem.FrmMach2.spn_camplungespeed.Value = buMarbleCalc.varOperation.settingMarbleCam.SawPlungeVelocity;
			clsItem.FrmMach2.spn_camcuttingstep.Value = buMarbleCalc.varOperation.settingMarbleCam.SawForwardStepDownDistance;
			clsItem.FrmMach2.spn_camsafedis.Value = buMarbleCalc.varOperation.settingMarbleCam.SawSafeDistance;
			buMarbleForms.frmVerticalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.CutLengthVertical;
			buMarbleForms.frmHorizontalV4.spn_length.Value = buMarbleCalc.varMarbleRunSettings.CutLengthHorizontal;
			clsItem.FrmMach2.spn_camspindlespeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
		}
	}

	public void MarbleCoreCommends(MarbleEventCommands Cmd, MarbleCommandArgs Data)
	{
		switch (Cmd)
		{
		case MarbleEventCommands.JobUpdate:
		{
			for (int i = 0; i <= clsInit.appMarble.activeJob.Items.Count - 1; i++)
			{
				clsAppMarbleVars.cmdMarble.SetJobOperationItemByJobIndex(i);
			}
			break;
		}
		case MarbleEventCommands.SelectionUpdate:
			clsAppMarbleVars.cmdMarble.JopItemUpdateAll();
			break;
		case MarbleEventCommands.MoveMouse:
			if (Data != null)
			{
				string text = "X: " + Data.pntMove.X.ToString("f2") + " , Y: " + Data.pntMove.Y.ToString("f2") + " , Z: " + Data.pntMove.Z.ToString("f2");
				if (Data.refPlane != null && buVector5.isPlaneXYorYX(Data.refPlane))
				{
					text = "X: " + Data.pntMove.X.ToString("f2") + " , Y: " + Data.pntMove.Y.ToString("f2");
				}
				if (Data.refPlane != null && buVector5.isPlaneXZorZX(Data.refPlane))
				{
					text = "X: " + Data.pntMove.X.ToString("f2") + " , Z: " + Data.pntMove.Z.ToString("f2");
				}
				if (Data.refPlane != null && buVector5.isPlaneYZorZY(Data.refPlane))
				{
					text = "Y: " + Data.pntMove.Y.ToString("f2") + " , Z: " + Data.pntMove.Z.ToString("f2");
				}
				clsItem.FrmMach2.lbl_coord.Text = text;
			}
			break;
		}
	}

	public void MarbleCoreCommends(object Data1, object Data2, object Data3, object Data4, object Data5)
	{
		MarbleHMICommands marbleHMICommands = MarbleHMICommands.None;
		if (Data1 is MarbleHMICommands)
		{
			marbleHMICommands = (MarbleHMICommands)Data1;
		}
		if (marbleHMICommands == MarbleHMICommands.MoveMouse && Data2 != null && Data2 is MarbleCommandArgs)
		{
			MarbleCommandArgs marbleCommandArgs = Data2 as MarbleCommandArgs;
			string text = "X: " + marbleCommandArgs.pntMove.X.ToString("f2") + " , Y: " + marbleCommandArgs.pntMove.Y.ToString("f2") + " , Z: " + marbleCommandArgs.pntMove.Z.ToString("f2");
			if (marbleCommandArgs.refPlane != null && buVector5.isPlaneXYorYX(marbleCommandArgs.refPlane))
			{
				text = "X: " + marbleCommandArgs.pntMove.X.ToString("f2") + " , Y: " + marbleCommandArgs.pntMove.Y.ToString("f2");
			}
			if (marbleCommandArgs.refPlane != null && buVector5.isPlaneXZorZX(marbleCommandArgs.refPlane))
			{
				text = "X: " + marbleCommandArgs.pntMove.X.ToString("f2") + " , Z: " + marbleCommandArgs.pntMove.Z.ToString("f2");
			}
			if (marbleCommandArgs.refPlane != null && buVector5.isPlaneYZorZY(marbleCommandArgs.refPlane))
			{
				text = "Y: " + marbleCommandArgs.pntMove.Y.ToString("f2") + " , Z: " + marbleCommandArgs.pntMove.Z.ToString("f2");
			}
			clsItem.FrmMach2.lbl_coord.Text = text;
		}
	}

	public void ShowWarning(string Message, Color clr)
	{
		clsItem.FrmMach2.lbl_warning.Visible = true;
		clsItem.FrmMach2.lbl_warning.Text = Message;
		clsItem.FrmMach2.lbl_warning.BackColor = clr;
		clsAppMarbleVars.cMachine.miscVar.cntWarning = 0;
		clsAppMarbleVars.cMachine.miscVar.WarningAvailable = true;
		if (clsAppMarbleItems.frmMachineSettingsV2 != null && clsAppMarbleItems.frmMachineSettingsV2.Visible)
		{
			clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Text = Message;
			clsAppMarbleItems.frmMachineSettingsV2.lbl_warning.Visible = true;
		}
	}

	public void FillOperations()
	{
		clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Clear();
		if (clsInit.appMarble.activeJob != null)
		{
			TreeNodeSettings treeNodeSettings = null;
			for (int i = 0; i <= clsInit.appMarble.activeJob.Operations.Count - 1; i++)
			{
				MarbleItemOperations marbleItemOperations = clsInit.appMarble.activeJob.Operations[i];
				int num = clsInit.appMarble.JobImageIndex(marbleItemOperations.ItemType, marbleItemOperations.ShapeType);
				treeNodeSettings = new TreeNodeSettings(marbleItemOperations.OperationName)
				{
					ImageIndex = num,
					SelectedImageIndex = num,
					Tag = i.ToString(),
					ClassIndex = i,
					ClassSubIndex = -1,
					ClassSubSubIndex = -1,
					Command = "",
					Checked = true
				};
				clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Add(treeNodeSettings);
			}
			if (clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes.Count > 0)
			{
				clsAppMarbleItems.frmBottomPanelV1.tree_operation.Nodes[0].Expand();
			}
		}
	}

	public void MainFormUpdate(bool MenuUpdate, bool SettinsUpdate, bool ControlUpdate)
	{
	}

	public void MainFormStatusUpdate(string status)
	{
	}

	public void MainFormXYZUpdate(string X, string Y, string Z)
	{
	}

	public void PageEntityAdd(object Entity, int EntityIndex)
	{
	}

	public bool RunCommands(string Command, ArrayList Args)
	{
		try
		{
			return false;
		}
		catch (Exception mSException)
		{
			string command = "";
			if (Args.Count > 0)
			{
				command = Args[0].ToString();
			}
			buLog.addLog(command, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public void RunGeneralCommand(GeneralCommandEventArg e)
	{
	}

	public void showMenuPage(object sender, EventArgs e)
	{
		clsItem.FrmMenu.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmMenu.LoadLanguage();
		clsItem.FrmMenu.ShowDialog(clsItem.FrmMach2);
	}

	public void showSettingsPage(object sender, EventArgs e)
	{
		clsItem.FrmMenuSettings.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmMenuSettings.LoadLanguage();
		clsItem.FrmMenuSettings.ShowDialog(clsItem.FrmMach2);
	}

	public void showAdminSettingsPage(object sender, EventArgs e)
	{
		clsItem.FrmMenuAdminSettings.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmMenuAdminSettings.LoadLanguage();
		clsItem.FrmMenuAdminSettings.ShowDialog(clsItem.FrmMach2);
	}

	public void ThreadLoop()
	{
		while (buPLCHandler.ThreadEnable)
		{
			bool flag = true;
			if (clsAppMarbleVars.cMachine.PLCSettings.ThreadWaitCount > 0)
			{
				if (clsAppMarbleVars.cMachine.miscVar.ThreadCount < clsAppMarbleVars.cMachine.PLCSettings.ThreadWaitCount)
				{
					flag = false;
				}
				else
				{
					clsAppMarbleVars.cMachine.miscVar.ThreadCount = 0;
					flag = true;
				}
			}
			clsAppMarbleVars.cMachine.miscVar.ThreadCount++;
			if (!((AppBool.Inited & AppBool.Connected) && flag))
			{
				continue;
			}
			if (AppBool.Inited)
			{
				if ((clsAppMarbleVars.cMachine.miscVar.cntCommunication % 2 == 0) & AppBool.Inited)
				{
					ReadAxisDataBits readAxisDataBits = new ReadAxisDataBits(position: true, offsetedPosition: true, enabled: true, !buMarbleCalc.varMarbleMachineSettings.OptionSettings.AllAbsoluteEncoder);
					if ((clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.DistanceToGo) | (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.DistanceToGo))
					{
						readAxisDataBits.DistanceToGo = true;
					}
					if ((clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.Speed) | (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.Speed))
					{
						readAxisDataBits.Velocity = true;
					}
					if ((clsAppMarbleVars.cMachine.ProgramSettings.MachineCoordinateShowMode == CoordinateShowMode.FollowingError) | (clsAppMarbleVars.cMachine.ProgramSettings.PartCoordinateShowMode == CoordinateShowMode.FollowingError))
					{
						readAxisDataBits.FollowingError = true;
					}
					clsAppMarbleVars.cMachine.Commands.ReadAxisGroup(readAxisDataBits, ref clsAppMarbleVars.cMachine.AppAxis);
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualOffsetedPosition = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition;
					clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualOffsetedPosition = clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition;
				}
				ReadLRealValues();
				ReadBOOLValues();
				ReadDINTValues();
				clsAppMarbleVars.cMachine.runSystem.FirstPLCRead = true;
			}
			clsAppMarbleVars.cmdMarble.ThreadLoopExtension();
			if (clsAppMarbleItems.frmDigitalInputOutput.Visible | (clsAppMarbleItems.frmMachineSettingsV2 != null && clsAppMarbleItems.frmMachineSettingsV2.Visible))
			{
				clsAppMarbleVars.cmdMarble.ReadIOBOOLValues();
			}
			if (clsAppMarbleItems.frmIOConfig != null && clsAppMarbleItems.frmIOConfig.Visible)
			{
				clsAppMarbleVars.cmdMarble.ReadIOBOOLValues();
			}
			if (!AppBool.DontWriteParameters)
			{
				if (clsAppMarbleVars.cMachine.bWriteIOParameter)
				{
					clsAppMarbleVars.cMachine.bParameterWriting = true;
					clsAppMarbleVars.cmdMarble.WriteIO();
					clsAppMarbleVars.cMachine.bWriteIOParameter = false;
				}
				if (clsAppMarbleVars.cMachine.bWriteSettingsParameter)
				{
					clsAppMarbleVars.cMachine.bParameterWriting = true;
					clsAppMarbleVars.cmdMarble.WriteSettingsParameter();
					clsAppMarbleVars.cMachine.bWriteSettingsParameter = false;
				}
				if (clsAppMarbleVars.cMachine.bWriteG54Parameter)
				{
					clsAppMarbleVars.cMachine.bParameterWriting = true;
					clsAppMarbleVars.cmdMarble.WriteG54();
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
					clsAppMarbleVars.cMachine.bWriteG54Parameter = false;
				}
				if (clsAppMarbleVars.cMachine.bWriteAlarmActionParameters)
				{
					clsAppMarbleVars.cMachine.bParameterWriting = true;
					clsAppMarbleVars.cmdMarble.WriteAlarmAction();
					clsAppMarbleVars.cMachine.bWriteAlarmActionParameters = false;
				}
				if (clsAppMarbleVars.cMachine.bWriteToolParameter)
				{
					clsAppMarbleVars.cMachine.bParameterWriting = true;
					clsAppMarbleVars.cmdMarble.WriteToolParameter(MillingHead: true);
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
					clsAppMarbleVars.cMachine.bWriteToolParameter = false;
				}
				if (clsAppMarbleVars.cMachine.bWriteAppParameter)
				{
					clsAppMarbleVars.cMachine.bParameterWriting = true;
					clsAppMarbleVars.cmdMarble.WriteAppParameter();
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 10, "sysRun.stpSteps.ParameterCNCUpdate");
					clsAppMarbleVars.cMachine.bWriteAppParameter = false;
				}
				if (clsAppMarbleVars.cMachine.bWriteParkParameters)
				{
					clsAppMarbleVars.cMachine.bParameterWriting = true;
					clsAppMarbleVars.cMachine.bWriteParkParameters = false;
				}
			}
			clsAppMarbleVars.cMachine.bParameterWriting = false;
		}
	}

	public void ReadLRealValues()
	{
		clsAppMarbleVars.cmdMarble.ReadLRealValues();
	}

	public void ReadRealValues()
	{
		clsAppMarbleVars.cmdMarble.ReadRealValues();
	}

	public void ReadDINTValues()
	{
		clsAppMarbleVars.cmdMarble.ReadDINTValues();
	}

	public void ReadBOOLValues()
	{
		clsAppMarbleVars.cmdMarble.ReadBOOLValues();
	}
}
