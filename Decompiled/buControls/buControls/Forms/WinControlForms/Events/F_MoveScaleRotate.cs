using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Events;

public class F_MoveScaleRotate : Form
{
	public MoveScaleRotateStretchVar Data = new MoveScaleRotateStretchVar();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public bool ShowExtent = true;

	[CompilerGenerated]
	private MoveScaleRotateExtentEventHandler moveScaleRotateExtentEventHandler_0;

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public static List<string> Captions = new List<string>();

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_movexminus;

	public Button btn_movexplus;

	public Button btn_moveyplus;

	public Button btn_moveyminus;

	public Button btn_rotateminus;

	public Button btn_scalex;

	public Button btn_rotateplus;

	public Button btn_scaley;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	public Button btn_extentxplus;

	public Button btn_extentxminus;

	internal NumericUpDown numericUpDown_5;

	public Button btn_extentyplus;

	public Button btn_extentyminus;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal NumericUpDown numericUpDown_6;

	public Button btn_movezminus;

	public Button btn_movezplus;

	public event MoveScaleRotateExtentEventHandler EventExecuted
	{
		[CompilerGenerated]
		add
		{
			MoveScaleRotateExtentEventHandler moveScaleRotateExtentEventHandler = moveScaleRotateExtentEventHandler_0;
			MoveScaleRotateExtentEventHandler moveScaleRotateExtentEventHandler2;
			do
			{
				moveScaleRotateExtentEventHandler2 = moveScaleRotateExtentEventHandler;
				MoveScaleRotateExtentEventHandler value2 = (MoveScaleRotateExtentEventHandler)Delegate.Combine(moveScaleRotateExtentEventHandler2, value);
				moveScaleRotateExtentEventHandler = Interlocked.CompareExchange(ref moveScaleRotateExtentEventHandler_0, value2, moveScaleRotateExtentEventHandler2);
			}
			while ((object)moveScaleRotateExtentEventHandler != moveScaleRotateExtentEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MoveScaleRotateExtentEventHandler moveScaleRotateExtentEventHandler = moveScaleRotateExtentEventHandler_0;
			MoveScaleRotateExtentEventHandler moveScaleRotateExtentEventHandler2;
			do
			{
				moveScaleRotateExtentEventHandler2 = moveScaleRotateExtentEventHandler;
				MoveScaleRotateExtentEventHandler value2 = (MoveScaleRotateExtentEventHandler)Delegate.Remove(moveScaleRotateExtentEventHandler2, value);
				moveScaleRotateExtentEventHandler = Interlocked.CompareExchange(ref moveScaleRotateExtentEventHandler_0, value2, moveScaleRotateExtentEventHandler2);
			}
			while ((object)moveScaleRotateExtentEventHandler != moveScaleRotateExtentEventHandler2);
		}
	}

	public event OkCommandEventHandler OkExecuted
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

	public event CancelCommandEventHandler CancelExecuted
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

	public F_MoveScaleRotate()
	{
		Class76.smethod_90(this);
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
		}
	}

	public void Init(MoveScaleRotateStretchVar data)
	{
		Data = new MoveScaleRotateStretchVar(data);
		Init();
	}

	public void Init()
	{
		bool_0 = false;
		numericUpDown_4.Value = (decimal)Data.StretchX;
		numericUpDown_5.Value = (decimal)Data.StretchY;
		numericUpDown_0.Value = (decimal)Data.MoveX;
		numericUpDown_1.Value = (decimal)Data.MoveY;
		numericUpDown_6.Value = (decimal)Data.MoveZ;
		numericUpDown_2.Value = (decimal)Data.Rotate;
		numericUpDown_3.Value = (decimal)Data.Scale;
		numericUpDown_4.Visible = ShowExtent;
		numericUpDown_5.Visible = ShowExtent;
		btn_extentxminus.Visible = ShowExtent;
		btn_extentxplus.Visible = ShowExtent;
		btn_extentyminus.Visible = ShowExtent;
		btn_extentyplus.Visible = ShowExtent;
		if (!ShowExtent)
		{
			base.Width -= 190;
		}
		bool_0 = true;
		Class76.smethod_184(this);
	}

	internal void method_1(object sender, EventArgs e)
	{
		Apply();
		Result = DialogResult.OK;
		if (okCommandEventHandler_0 != null)
		{
			okCommandEventHandler_0();
		}
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	public void Apply()
	{
		if (bool_0)
		{
			Data.StretchX = (double)numericUpDown_4.Value;
			Data.StretchY = (double)numericUpDown_5.Value;
			Data.MoveX = (double)numericUpDown_0.Value;
			Data.MoveY = (double)numericUpDown_1.Value;
			Data.MoveZ = (double)numericUpDown_6.Value;
			Data.Rotate = (double)numericUpDown_2.Value;
			Data.Scale = (double)numericUpDown_3.Value;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		Apply();
		if (control.Name == btn_movexplus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg.Type = MoveScaleRotateStretchType.MoveXPlus;
			moveScaleRotateExtentEventArg.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg);
		}
		if (control.Name == btn_movexminus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg2 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg2.Type = MoveScaleRotateStretchType.MoveXMinus;
			moveScaleRotateExtentEventArg2.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg2);
		}
		if (control.Name == btn_moveyplus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg3 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg3.Type = MoveScaleRotateStretchType.MoveYPlus;
			moveScaleRotateExtentEventArg3.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg3);
		}
		if (control.Name == btn_moveyminus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg4 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg4.Type = MoveScaleRotateStretchType.MoveYMinus;
			moveScaleRotateExtentEventArg4.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg4);
		}
		if (control.Name == btn_movezplus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg5 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg5.Type = MoveScaleRotateStretchType.MoveZPlus;
			moveScaleRotateExtentEventArg5.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg5);
		}
		if (control.Name == btn_movezminus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg6 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg6.Type = MoveScaleRotateStretchType.MoveZMinus;
			moveScaleRotateExtentEventArg6.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg6);
		}
		if (control.Name == btn_scalex.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg7 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg7.Type = MoveScaleRotateStretchType.ScaleX;
			moveScaleRotateExtentEventArg7.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg7);
		}
		if (control.Name == btn_scaley.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg8 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg8.Type = MoveScaleRotateStretchType.ScaleY;
			moveScaleRotateExtentEventArg8.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg8);
		}
		if (control.Name == btn_rotateminus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg9 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg9.Type = MoveScaleRotateStretchType.RotateMinus;
			moveScaleRotateExtentEventArg9.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg9);
		}
		if (control.Name == btn_rotateplus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg10 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg10.Type = MoveScaleRotateStretchType.RotatePlus;
			moveScaleRotateExtentEventArg10.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg10);
		}
		if (control.Name == btn_extentxminus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg11 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg11.Type = MoveScaleRotateStretchType.StretchXMinus;
			moveScaleRotateExtentEventArg11.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg11);
		}
		if (control.Name == btn_extentxplus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg12 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg12.Type = MoveScaleRotateStretchType.StretchXPlus;
			moveScaleRotateExtentEventArg12.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg12);
		}
		if (control.Name == btn_extentyminus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg13 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg13.Type = MoveScaleRotateStretchType.StretchYMinus;
			moveScaleRotateExtentEventArg13.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg13);
		}
		if (control.Name == btn_extentyplus.Name && moveScaleRotateExtentEventHandler_0 != null)
		{
			MoveScaleRotateExtentEventArg moveScaleRotateExtentEventArg14 = new MoveScaleRotateExtentEventArg();
			moveScaleRotateExtentEventArg14.Type = MoveScaleRotateStretchType.StretchYPlus;
			moveScaleRotateExtentEventArg14.Data = new MoveScaleRotateStretchVar(Data);
			moveScaleRotateExtentEventHandler_0(moveScaleRotateExtentEventArg14);
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
