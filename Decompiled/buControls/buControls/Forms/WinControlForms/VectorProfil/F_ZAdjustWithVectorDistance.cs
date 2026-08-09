using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using ns27;

namespace buControls.Forms.WinControlForms.VectorProfil;

public class F_ZAdjustWithVectorDistance : Form
{
	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandEventHandler applyCommandEventHandler_0;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;

	public DialogResult Result = DialogResult.None;

	public ZHeightAdjustmentByDistance ZHeightData = new ZHeightAdjustmentByDistance();

	public Pnt3D LevelPoint = new Pnt3D();

	public List<Pnt3D> RefPoints = new List<Pnt3D>();

	public List<Pnt3D> CalcPoints = new List<Pnt3D>();

	public bool DrawSpline = false;

	public entityBSplineType SplineType = entityBSplineType.BSplineQuadratic;

	private bool bool_0 = false;

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal Panel panel_0;

	internal Label label_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_1;

	internal Panel panel_1;

	internal Label label_2;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal buViewer buViewer_0;

	internal Label label_3;

	public Button btn_apply;

	public NumericUpDown spn_levelcenter;

	public NumericUpDown spn_height;

	internal Label label_4;

	public NumericUpDown spn_levelmin;

	internal Label label_5;

	public NumericUpDown spn_levelmax;

	internal RadioButton radioButton_4;

	public event OkCommandEventHandler OkCommand
	{
		[CompilerGenerated]
		add
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Combine(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Remove(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
	}

	public event CancelCommandEventHandler CancelCommand
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

	public event ApplyCommandEventHandler ApplyCommand
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandEventHandler applyCommandEventHandler = applyCommandEventHandler_0;
			ApplyCommandEventHandler applyCommandEventHandler2;
			do
			{
				applyCommandEventHandler2 = applyCommandEventHandler;
				ApplyCommandEventHandler value2 = (ApplyCommandEventHandler)Delegate.Combine(applyCommandEventHandler2, value);
				applyCommandEventHandler = Interlocked.CompareExchange(ref applyCommandEventHandler_0, value2, applyCommandEventHandler2);
			}
			while ((object)applyCommandEventHandler != applyCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandEventHandler applyCommandEventHandler = applyCommandEventHandler_0;
			ApplyCommandEventHandler applyCommandEventHandler2;
			do
			{
				applyCommandEventHandler2 = applyCommandEventHandler;
				ApplyCommandEventHandler value2 = (ApplyCommandEventHandler)Delegate.Remove(applyCommandEventHandler2, value);
				applyCommandEventHandler = Interlocked.CompareExchange(ref applyCommandEventHandler_0, value2, applyCommandEventHandler2);
			}
			while ((object)applyCommandEventHandler != applyCommandEventHandler2);
		}
	}

	public F_ZAdjustWithVectorDistance()
	{
		Class76.smethod_702(this);
	}

	public void Init()
	{
		spn_levelcenter.Value = (decimal)ZHeightData.LevelCenter;
		spn_levelmin.Value = (decimal)ZHeightData.LevelMin;
		spn_levelmax.Value = (decimal)ZHeightData.LevelMax;
		spn_height.Value = (decimal)ZHeightData.ZHeightValue;
		if (ZHeightData.ZType == ZHeightProfileType.Linear)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
			radioButton_4.Checked = false;
		}
		if (ZHeightData.ZType == ZHeightProfileType.Circular)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
			radioButton_4.Checked = false;
		}
		if (ZHeightData.ZType == ZHeightProfileType.Constant)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = false;
			radioButton_4.Checked = true;
		}
		if (ZHeightData.Direction == VectorXYType.XVector)
		{
			radioButton_2.Checked = true;
			radioButton_3.Checked = false;
		}
		if (ZHeightData.Direction == VectorXYType.YVector)
		{
			radioButton_2.Checked = false;
			radioButton_3.Checked = true;
		}
		Class76.smethod_234(this, RefPoints, RefPoints);
		bool_0 = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (bool_0 && Result != DialogResult.OK)
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
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Apply();
		Result = DialogResult.OK;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		if (okCommandEventHandler_0 != null)
		{
			okCommandEventHandler_0();
		}
	}

	internal void method_2(object sender, EventArgs e)
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
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Apply();
	}

	public void Apply()
	{
		ZHeightData.LevelCenter = (double)spn_levelcenter.Value;
		ZHeightData.LevelMin = (double)spn_levelmin.Value;
		ZHeightData.LevelMax = (double)spn_levelmax.Value;
		ZHeightData.ZHeightValue = (double)spn_height.Value;
		if (radioButton_0.Checked)
		{
			ZHeightData.ZType = ZHeightProfileType.Linear;
		}
		if (radioButton_1.Checked)
		{
			ZHeightData.ZType = ZHeightProfileType.Circular;
		}
		if (radioButton_4.Checked)
		{
			ZHeightData.ZType = ZHeightProfileType.Constant;
		}
		if (radioButton_2.Checked)
		{
			ZHeightData.Direction = VectorXYType.XVector;
		}
		if (radioButton_3.Checked)
		{
			ZHeightData.Direction = VectorXYType.YVector;
		}
		CalcPoints = new List<Pnt3D>();
		List<Pnt3D> SortedOriginalPoints = new List<Pnt3D>();
		buControlCoreClass.cVector.ProfileZHeightFromDistance(ZHeightData, LevelPoint, RefPoints, ref SortedOriginalPoints, ref CalcPoints);
		Class76.smethod_234(this, SortedOriginalPoints, CalcPoints);
		if (applyCommandEventHandler_0 != null)
		{
			applyCommandEventHandler_0();
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
