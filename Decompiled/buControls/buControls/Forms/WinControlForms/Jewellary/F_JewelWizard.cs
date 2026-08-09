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

public class F_JewelWizard : Form
{
	public static List<string> Captions = new List<string>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public JewelVar ParJewel = new JewelVar();

	public List<ToolBase> Tools = new List<ToolBase>();

	public int ToolSelectedIndex = 0;

	public bool FreeFormEnable = false;

	public bool DemoMode = false;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	public string LangMessageDMode = "You Can't Do This Operation in Demo Mode";

	public string LangMessageFreeForm = "Fre From Mode Not Allowed";

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Panel panel_1;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Label label_0;

	internal Panel panel_2;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Button button_12;

	internal Button button_13;

	internal Button button_14;

	internal Button button_15;

	internal Label label_3;

	internal ImageList imageList_0;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal Panel panel_3;

	internal Label label_5;

	internal Button button_16;

	internal ComboBox comboBox_0;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal NumericUpDown numericUpDown_3;

	internal Label label_6;

	internal NumericUpDown numericUpDown_4;

	internal Label label_7;

	internal NumericUpDown numericUpDown_5;

	internal Label label_8;

	internal Label label_9;

	internal Panel panel_4;

	internal Button button_17;

	internal Button button_18;

	internal CheckBox checkBox_2;

	internal NumericUpDown numericUpDown_6;

	internal Label label_10;

	internal Panel panel_5;

	internal Label label_11;

	internal NumericUpDown numericUpDown_7;

	internal Label label_12;

	internal Button button_19;

	internal CheckBox checkBox_3;

	internal NumericUpDown numericUpDown_8;

	internal Label label_13;

	internal Panel panel_6;

	internal ComboBox comboBox_1;

	internal Label label_14;

	internal Label label_15;

	internal CheckBox checkBox_4;

	internal NumericUpDown numericUpDown_9;

	internal Label label_16;

	internal Button button_20;

	internal Button button_21;

	internal Button button_22;

	internal Button button_23;

	internal Button button_24;

	internal ImageList imageList_1;

	internal CheckBox checkBox_5;

	internal CheckBox checkBox_6;

	internal NumericUpDown numericUpDown_10;

	internal Label label_17;

	internal NumericUpDown numericUpDown_11;

	internal Label label_18;

	internal CheckBox checkBox_7;

	internal Panel panel_7;

	internal Label label_19;

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

	public F_JewelWizard()
	{
		Class76.smethod_40(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
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
		button_2.BackColor = Color.Silver;
		button_1.BackColor = Color.Silver;
		button_0.BackColor = Color.Silver;
		button_5.BackColor = Color.Silver;
		button_4.BackColor = Color.Silver;
		button_3.BackColor = Color.Silver;
		button_14.Enabled = FreeFormEnable;
		if (ParJewel.JewelMode.CamMode == jewelCamModeType.Contour3AX)
		{
			button_2.BackColor = Color.Red;
		}
		if (ParJewel.JewelMode.CamMode == jewelCamModeType.Pocket3AX)
		{
			button_1.BackColor = Color.Red;
		}
		if (ParJewel.JewelMode.CamMode == jewelCamModeType.Punch3AX)
		{
			button_0.BackColor = Color.Red;
		}
		if (ParJewel.JewelMode.CamMode == jewelCamModeType.Contour5AX)
		{
			button_5.BackColor = Color.Red;
		}
		if (ParJewel.JewelMode.CamMode == jewelCamModeType.Pocket5AX)
		{
			button_4.BackColor = Color.Red;
		}
		if (ParJewel.JewelMode.CamMode == jewelCamModeType.Punch5AX)
		{
			button_3.BackColor = Color.Red;
		}
		button_11.BackColor = Color.Silver;
		button_10.BackColor = Color.Silver;
		button_7.BackColor = Color.Silver;
		button_6.BackColor = Color.Silver;
		button_9.BackColor = Color.Silver;
		button_8.BackColor = Color.Silver;
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Spindle)
		{
			button_11.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Engraving)
		{
			button_10.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut1)
		{
			button_7.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut2)
		{
			button_6.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Lathe)
		{
			button_9.BackColor = Color.Gold;
		}
		if (ParJewel.JewelMode.OperationMode == jewelOperationModeType.Laser)
		{
			button_8.BackColor = Color.Gold;
		}
		button_12.BackColor = Color.Silver;
		button_13.BackColor = Color.Silver;
		button_14.BackColor = Color.Silver;
		button_15.BackColor = Color.Silver;
		if (ParJewel.JewelMode.FormMode == jewelCurveType.Flat)
		{
			button_15.BackColor = Color.Lime;
		}
		if (ParJewel.JewelMode.FormMode == jewelCurveType.Convex)
		{
			button_13.BackColor = Color.Lime;
		}
		if (ParJewel.JewelMode.FormMode == jewelCurveType.Concave)
		{
			button_12.BackColor = Color.Lime;
		}
		if (ParJewel.JewelMode.FormMode == jewelCurveType.FreeDraw)
		{
			button_14.BackColor = Color.Lime;
		}
		button_17.BackColor = Color.Silver;
		button_18.BackColor = Color.Silver;
		if (ParJewel.JewelTangentProp.Type == jewelTangentType.Point)
		{
			button_17.BackColor = Color.Cyan;
		}
		if (ParJewel.JewelTangentProp.Type == jewelTangentType.Continous)
		{
			button_18.BackColor = Color.Cyan;
		}
		checkBox_2.Checked = ParJewel.JewelTangentProp.UseContantAngle;
		numericUpDown_6.Value = (decimal)ParJewel.JewelTangentProp.ContantAngle;
		numericUpDown_11.Value = (decimal)ParJewel.JewelMaterialProp.MajorDiameter;
		numericUpDown_10.Value = (decimal)ParJewel.JewelMaterialProp.MinorDiameter;
		numericUpDown_1.Value = (decimal)ParJewel.JewelMaterialProp.Diameter;
		numericUpDown_0.Value = (decimal)ParJewel.JewelMaterialProp.Width;
		numericUpDown_2.Value = (decimal)ParJewel.JewelMaterialProp.CurveRadius;
		numericUpDown_8.Value = (decimal)ParJewel.JewelScaleProp.ConstantX;
		numericUpDown_7.Value = (decimal)ParJewel.JewelScaleProp.ConstantY;
		checkBox_3.Checked = ParJewel.JewelMode.SlideEnable;
		checkBox_0.Checked = ParJewel.OilEnable;
		checkBox_1.Checked = ParJewel.JewelSteppingProp.Enable;
		checkBox_7.Checked = false;
		if (ParJewel.JewelMaterialProp.ShapeType == jewelMaterialShapeType.Ellipse)
		{
			checkBox_7.Checked = true;
		}
		numericUpDown_4.Value = (decimal)ParJewel.JewelCamProp.FeedSpeed;
		numericUpDown_3.Value = (decimal)ParJewel.JewelCamProp.PlungeSpeed;
		numericUpDown_5.Value = (decimal)ParJewel.JewelCamProp.Depth;
		numericUpDown_9.Value = (decimal)ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
		checkBox_4.Checked = ParJewel.JewelCamProp.PolylineToSpline;
		checkBox_6.Checked = ParJewel.JewelCamProp.AngularMode;
		checkBox_5.Checked = ParJewel.JewelCamProp.TriangularCut;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(ParJewel.SortNextGRoupRules, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(ParJewel.SortNextGRoupRules), ref comboBox_1);
		comboBox_0.Items.Clear();
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			comboBox_0.Items.Add("T" + Tools[i].Data.No + " - " + Tools[i].Data.Name);
		}
		if ((ToolSelectedIndex >= 0) & (ToolSelectedIndex <= Tools.Count - 1))
		{
			comboBox_0.SelectedIndex = ToolSelectedIndex;
		}
		Result = DialogResult.None;
		Class76.smethod_826(this);
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_2.BackColor = Color.Silver;
		button_1.BackColor = Color.Silver;
		button_0.BackColor = Color.Silver;
		button_5.BackColor = Color.Silver;
		button_4.BackColor = Color.Silver;
		button_3.BackColor = Color.Silver;
		if (control.Name == button_2.Name)
		{
			ParJewel.JewelMode.CamMode = jewelCamModeType.Contour3AX;
			button_2.BackColor = Color.Red;
		}
		if (control.Name == button_1.Name)
		{
			ParJewel.JewelMode.CamMode = jewelCamModeType.Pocket3AX;
			button_1.BackColor = Color.Red;
		}
		if (control.Name == button_0.Name)
		{
			ParJewel.JewelMode.CamMode = jewelCamModeType.Punch3AX;
			button_0.BackColor = Color.Red;
		}
		if (control.Name == button_5.Name)
		{
			ParJewel.JewelMode.CamMode = jewelCamModeType.Contour5AX;
			button_5.BackColor = Color.Red;
		}
		if (control.Name == button_4.Name)
		{
			ParJewel.JewelMode.CamMode = jewelCamModeType.Pocket5AX;
			button_4.BackColor = Color.Red;
		}
		if (control.Name == button_3.Name)
		{
			ParJewel.JewelMode.CamMode = jewelCamModeType.Punch5AX;
			button_3.BackColor = Color.Red;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_11.BackColor = Color.Silver;
		button_10.BackColor = Color.Silver;
		button_7.BackColor = Color.Silver;
		button_6.BackColor = Color.Silver;
		button_9.BackColor = Color.Silver;
		button_8.BackColor = Color.Silver;
		if (control.Name == button_11.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Spindle;
			button_11.BackColor = Color.Gold;
		}
		if (control.Name == button_10.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Engraving;
			button_10.BackColor = Color.Gold;
		}
		if (control.Name == button_7.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut1;
			button_7.BackColor = Color.Gold;
		}
		if (control.Name == button_6.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut2;
			button_6.BackColor = Color.Gold;
		}
		if (control.Name == button_9.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Lathe;
			button_9.BackColor = Color.Gold;
		}
		if (control.Name == button_8.Name)
		{
			ParJewel.JewelMode.OperationMode = jewelOperationModeType.Laser;
			button_8.BackColor = Color.Gold;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_12.BackColor = Color.Silver;
		button_13.BackColor = Color.Silver;
		button_14.BackColor = Color.Silver;
		button_15.BackColor = Color.Silver;
		if (control.Name == button_15.Name)
		{
			ParJewel.JewelMode.FormMode = jewelCurveType.Flat;
			ParJewel.JewelMaterialProp.CurveType = jewelCurveType.Flat;
			button_15.BackColor = Color.Lime;
		}
		if (control.Name == button_13.Name)
		{
			ParJewel.JewelMode.FormMode = jewelCurveType.Convex;
			ParJewel.JewelMaterialProp.CurveType = jewelCurveType.Convex;
			button_13.BackColor = Color.Lime;
		}
		if (control.Name == button_12.Name)
		{
			ParJewel.JewelMode.FormMode = jewelCurveType.Concave;
			ParJewel.JewelMaterialProp.CurveType = jewelCurveType.Concave;
			button_12.BackColor = Color.Lime;
		}
		if (control.Name == button_14.Name)
		{
			ParJewel.JewelMode.FormMode = jewelCurveType.FreeDraw;
			ParJewel.JewelMaterialProp.CurveType = jewelCurveType.FreeDraw;
			button_14.BackColor = Color.Lime;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_17.BackColor = Color.Silver;
		button_18.BackColor = Color.Silver;
		if (control.Name == button_17.Name)
		{
			ParJewel.JewelTangentProp.Type = jewelTangentType.Point;
			button_17.BackColor = Color.Cyan;
		}
		if (control.Name == button_18.Name)
		{
			ParJewel.JewelTangentProp.Type = jewelTangentType.Continous;
			button_18.BackColor = Color.Cyan;
		}
	}

	internal void method_5(object sender, EventArgs e)
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

	internal void method_6(object sender, EventArgs e)
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

	internal void method_7(object sender, EventArgs e)
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
			numericUpDown_9.Value = (decimal)ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
			ArrayList EnumItems = new ArrayList();
			buGeneral.GetEnumTypeValues(ParJewel.SortNextGRoupRules, ref EnumItems);
			buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(ParJewel.SortNextGRoupRules), ref comboBox_1);
		}
	}

	internal void method_8(object sender, EventArgs e)
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

	internal void method_9(object sender, EventArgs e)
	{
		if (!FreeFormEnable && ParJewel.JewelMode.FormMode == jewelCurveType.FreeDraw)
		{
			buString.MessageBoxError(LangMessageFreeForm);
		}
		if (!DemoMode)
		{
			method_10(button_23, e);
			Result = DialogResult.OK;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
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

	internal void method_10(object sender, EventArgs e)
	{
		ParJewel.JewelTangentProp.ContantAngle = (double)numericUpDown_6.Value;
		ParJewel.JewelMaterialProp.Diameter = (double)numericUpDown_1.Value;
		ParJewel.JewelMaterialProp.Width = (double)numericUpDown_0.Value;
		ParJewel.JewelMaterialProp.CurveRadius = (double)numericUpDown_2.Value;
		ParJewel.JewelScaleProp.ConstantX = (double)numericUpDown_8.Value;
		ParJewel.JewelScaleProp.ConstantY = (double)numericUpDown_7.Value;
		ParJewel.JewelMaterialProp.MajorDiameter = (double)numericUpDown_11.Value;
		ParJewel.JewelMaterialProp.MinorDiameter = (double)numericUpDown_10.Value;
		ParJewel.JewelMaterialProp.ShapeType = jewelMaterialShapeType.Circle;
		if (checkBox_7.Checked)
		{
			ParJewel.JewelMaterialProp.ShapeType = jewelMaterialShapeType.Ellipse;
		}
		ParJewel.JewelTangentProp.UseContantAngle = checkBox_2.Checked;
		ParJewel.JewelMode.SlideEnable = checkBox_3.Checked;
		ParJewel.OilEnable = checkBox_0.Checked;
		ParJewel.JewelSteppingProp.Enable = checkBox_1.Checked;
		ParJewel.JewelCamProp.FeedSpeed = (double)numericUpDown_4.Value;
		ParJewel.JewelCamProp.PlungeSpeed = (double)numericUpDown_3.Value;
		ParJewel.JewelCamProp.Depth = (double)numericUpDown_5.Value;
		ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset = (double)numericUpDown_9.Value;
		ParJewel.JewelCamProp.PolylineToSpline = checkBox_4.Checked;
		ParJewel.JewelCamProp.AngularMode = checkBox_6.Checked;
		ParJewel.JewelCamProp.TriangularCut = checkBox_5.Checked;
		ParJewel.SortNextGRoupRules = (SortingNextGroupFindRulesType)buGeneral.EnumValueFromInt(ParJewel.SortNextGRoupRules, comboBox_1.SelectedIndex);
		if ((comboBox_0.SelectedIndex >= 0) & (comboBox_0.SelectedIndex <= Tools.Count - 1))
		{
			ToolSelectedIndex = comboBox_0.SelectedIndex;
		}
		if (ParJewel.JewelMode.SlideEnable)
		{
			ParJewel.JewelMaterialProp.EndSpaceX = ParJewel.PositionProp.XStartSpace;
			ParJewel.JewelMaterialProp.StartSpaceX = ParJewel.PositionProp.XEndSpace;
			ParJewel.JewelMaterialProp.SpaceY = ParJewel.PositionProp.YSpace;
		}
		else
		{
			ParJewel.JewelMaterialProp.EndSpaceX = 0.0;
			ParJewel.JewelMaterialProp.StartSpaceX = 0.0;
			ParJewel.JewelMaterialProp.SpaceY = 0.0;
		}
		if (applyCommandWithDataEventHandler_0 != null)
		{
			applyCommandWithDataEventHandler_0(ParJewel);
		}
	}

	internal void method_11(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
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
