using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.CAM.CamItems;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelWizardForModes : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public JewelVar ParJewel = new JewelVar();

	public List<ToolBase> Tools = new List<ToolBase>();

	public int ToolSelectedIndex = 0;

	public bool FreeFormEnable = false;

	public bool DemoMode = false;

	public bool SpindleEnable = true;

	public bool Dia1Enable = true;

	public bool Dia2Enable = true;

	public bool EngraveEnable = true;

	public bool LaserEnable = true;

	public bool LatheEnable = true;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	internal ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	public string LangMessageDMode = "You Can't Do This Operation in Demo Mode";

	public string LangMessageFreeForm = "Fre From Mode Not Allowed";

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Label label_0;

	internal ImageList imageList_0;

	internal Panel panel_2;

	internal Button button_6;

	internal CheckBox checkBox_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Label label_3;

	internal Panel panel_3;

	internal Button button_7;

	internal Button button_8;

	internal CheckBox checkBox_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal Panel panel_4;

	internal ComboBox comboBox_0;

	internal Label label_5;

	internal Label label_6;

	internal CheckBox checkBox_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal ImageList imageList_1;

	internal CheckBox checkBox_3;

	internal Label label_8;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	internal Label label_9;

	internal Button button_13;

	internal Button button_14;

	internal CheckBox checkBox_4;

	internal Button button_15;

	internal CheckBox checkBox_5;

	internal Label label_10;

	internal NumericUpDown numericUpDown_4;

	internal CheckBox checkBox_6;

	internal Label label_11;

	internal NumericUpDown numericUpDown_5;

	internal CheckBox checkBox_7;

	internal NumericUpDown numericUpDown_6;

	internal Label label_12;

	internal NumericUpDown numericUpDown_7;

	internal Label label_13;

	internal CheckBox checkBox_8;

	internal CheckBox checkBox_9;

	internal CheckBox checkBox_10;

	public event OkCommandWithDataEventHandler OkPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler CancelPressed
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public event ApplyCommandWithDataEventHandler ApplyPressed
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Combine(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Remove(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
	}

	public F_JewelWizardForModes()
	{
		Class76.smethod_444(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			if (base.Owner != null)
			{
				base.Owner.Focus();
			}
		}
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		button_14.BackColor = Color.Silver;
		button_13.BackColor = Color.Silver;
		if (ParJewel.JewelMode.CamOperation == jewelCamOperationType.Contour)
		{
			button_14.BackColor = Color.Red;
		}
		if (ParJewel.JewelMode.CamOperation == jewelCamOperationType.Punch)
		{
			button_13.BackColor = Color.Red;
		}
		checkBox_4.Checked = ParJewel.JewelMode.ConvexMachiningFor3Axis;
		checkBox_5.Checked = ParJewel.JewelMode.SlideEnable;
		textBox_0.Text = ParJewel.ModeName;
		textBox_1.Text = ParJewel.ModePreparedBy;
		button_5.BackColor = Color.Silver;
		button_4.BackColor = Color.Silver;
		button_1.BackColor = Color.Silver;
		button_0.BackColor = Color.Silver;
		button_3.BackColor = Color.Silver;
		button_2.BackColor = Color.Silver;
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Spindle)
		{
			button_5.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Engraving)
		{
			button_4.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut1)
		{
			button_1.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut2)
		{
			button_0.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Lathe)
		{
			button_3.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Laser)
		{
			button_2.BackColor = Color.Gold;
		}
		button_7.BackColor = Color.Silver;
		button_8.BackColor = Color.Silver;
		if (ParJewel.JewelTangentProp.Type == jewelTangentType.Point)
		{
			button_7.BackColor = Color.Cyan;
		}
		if (ParJewel.JewelTangentProp.Type == jewelTangentType.Continous)
		{
			button_8.BackColor = Color.Cyan;
		}
		checkBox_1.Checked = ParJewel.JewelTangentProp.UseContantAngle;
		numericUpDown_2.Value = (decimal)ParJewel.JewelTangentProp.ContantAngle;
		checkBox_0.Checked = ParJewel.JewelSteppingProp.Enable;
		button_5.Enabled = SpindleEnable;
		button_1.Enabled = Dia1Enable;
		button_0.Enabled = Dia2Enable;
		button_4.Enabled = EngraveEnable;
		button_2.Enabled = LaserEnable;
		button_3.Enabled = LatheEnable;
		numericUpDown_7.Value = (decimal)ParJewel.JewelMaterialProp.MajorDiameter;
		numericUpDown_6.Value = (decimal)ParJewel.JewelMaterialProp.MinorDiameter;
		checkBox_8.Checked = false;
		if (ParJewel.JewelMaterialProp.ShapeType == jewelMaterialShapeType.Ellipse)
		{
			checkBox_8.Checked = true;
		}
		numericUpDown_1.Value = (decimal)ParJewel.JewelCamProp.FeedSpeed;
		numericUpDown_0.Value = (decimal)ParJewel.JewelCamProp.PlungeSpeed;
		numericUpDown_3.Value = (decimal)ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
		checkBox_2.Checked = ParJewel.JewelCamProp.PolylineToSpline;
		checkBox_3.Checked = ParJewel.JewelCamProp.AngularMode;
		checkBox_6.Checked = ParJewel.JewelCamProp.FlatSheetMode;
		checkBox_10.Checked = ParJewel.JewelCamProp.SurfaceReadMode;
		numericUpDown_5.Value = (decimal)ParJewel.JewelMode.SyncRatio;
		checkBox_7.Checked = ParJewel.JewelMode.SyncMode;
		checkBox_9.Checked = ParJewel.JewelMode.BAxisFor3Axis;
		numericUpDown_4.Value = (decimal)ParJewel.JewelCamProp.AngluarModeBAngle;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(ParJewel.SortNextGRoupRules, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(ParJewel.SortNextGRoupRules), ref comboBox_0);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_489(this);
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_14.BackColor = Color.Silver;
		button_13.BackColor = Color.Silver;
		if (control.Name == button_14.Name)
		{
			ParJewel.JewelMode.CamOperation = jewelCamOperationType.Contour;
			button_14.BackColor = Color.Red;
		}
		if (control.Name == button_13.Name)
		{
			ParJewel.JewelMode.CamOperation = jewelCamOperationType.Punch;
			button_13.BackColor = Color.Red;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_5.BackColor = Color.Silver;
		button_4.BackColor = Color.Silver;
		button_1.BackColor = Color.Silver;
		button_0.BackColor = Color.Silver;
		button_3.BackColor = Color.Silver;
		button_2.BackColor = Color.Silver;
		if (control.Name == button_5.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Spindle;
			button_5.BackColor = Color.Gold;
		}
		if (control.Name == button_4.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Engraving;
			button_4.BackColor = Color.Gold;
		}
		if (control.Name == button_1.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut1;
			button_1.BackColor = Color.Gold;
		}
		if (control.Name == button_0.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut2;
			button_0.BackColor = Color.Gold;
		}
		if (control.Name == button_3.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Lathe;
			button_3.BackColor = Color.Gold;
		}
		if (control.Name == button_2.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Laser;
			button_2.BackColor = Color.Gold;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_7.BackColor = Color.Silver;
		button_8.BackColor = Color.Silver;
		if (control.Name == button_7.Name)
		{
			ParJewel.JewelTangentProp.Type = jewelTangentType.Point;
			button_7.BackColor = Color.Cyan;
		}
		if (control.Name == button_8.Name)
		{
			ParJewel.JewelTangentProp.Type = jewelTangentType.Continous;
			button_8.BackColor = Color.Cyan;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		F_CamStepAll f_CamStepAll = new F_CamStepAll();
		f_CamStepAll.Data = new camStep(ParJewel.JewelSteppingProp);
		f_CamStepAll.FormCloseMode = FormCloseModeType.Dispose;
		f_CamStepAll.DataEnable = new camStepEnable(startval: false, endvalue: false, distance: false, count: false, step: true, type: false, moveup: false, moveuptype: true, sequence: true);
		f_CamStepAll.Init();
		f_CamStepAll.StartPosition = FormStartPosition.CenterParent;
		f_CamStepAll.ShowDialog(this);
		if (f_CamStepAll.Result == DialogResult.OK)
		{
			ParJewel.JewelSteppingProp = new camStep(f_CamStepAll.Data);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "Position";
		f_ClassViewerDialog.OkCaption = AppLanguage.CadCamDynamic[8];
		f_ClassViewerDialog.CancelCaption = AppLanguage.CadCamDynamic[9];
		f_ClassViewerDialog.Value = ParJewel.PositionProp;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.ParCaptions.AddRange(buGeneral.CopyLists(buJewelary.LangjewelPositioningSettings).ToArray());
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.PositionProp = new jewelPositioningSettings((jewelPositioningSettings)f_ClassViewerDialog.Value);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		F_AdvancedSettings f_AdvancedSettings = new F_AdvancedSettings();
		f_AdvancedSettings.FormCloseMode = FormCloseModeType.Invisible;
		f_AdvancedSettings.ParJewel = new JewelVar(ParJewel);
		f_AdvancedSettings.Init();
		f_AdvancedSettings.StartPosition = FormStartPosition.CenterParent;
		f_AdvancedSettings.ShowDialog(this);
		if (f_AdvancedSettings.Result == DialogResult.OK)
		{
			ParJewel = new JewelVar(f_AdvancedSettings.ParJewel);
			numericUpDown_3.Value = (decimal)ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
			ArrayList EnumItems = new ArrayList();
			buGeneral.GetEnumTypeValues(ParJewel.SortNextGRoupRules, ref EnumItems);
			buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(ParJewel.SortNextGRoupRules), ref comboBox_0);
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		F_ProducerSettings f_ProducerSettings = new F_ProducerSettings();
		f_ProducerSettings.FormCloseMode = FormCloseModeType.Invisible;
		f_ProducerSettings.ParJewel = new JewelVar(ParJewel);
		f_ProducerSettings.Init();
		f_ProducerSettings.StartPosition = FormStartPosition.CenterParent;
		f_ProducerSettings.ShowDialog(this);
		if (f_ProducerSettings.Result == DialogResult.OK)
		{
			ParJewel = new JewelVar(f_ProducerSettings.ParJewel);
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		if (!FreeFormEnable && ParJewel.JewelMode.FormMode == jewelCurveType.FreeDraw)
		{
			buString.MessageBoxError(LangMessageFreeForm);
		}
		if (!DemoMode)
		{
			Class76.smethod_630(this);
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			if (okCommandWithDataEventHandler_0 != null)
			{
				okCommandWithDataEventHandler_0(ParJewel);
			}
		}
		else
		{
			buString.MessageBoxError(LangMessageDMode);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		Properties.Result = DialogResult.Cancel;
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		if (base.Owner != null)
		{
			base.Owner.Focus();
		}
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
