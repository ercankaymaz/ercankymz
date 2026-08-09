using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Holes;
using ns8;

namespace buCadCamResVer5.Drill;

public class F_Holes3D : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public List<DrillItem> Items = new List<DrillItem>();

	public DrillJob Job = new DrillJob();

	public DrillJob tempJob = new DrillJob();

	public DrillRuntimeSettings settingRuntime = new DrillRuntimeSettings();

	public DrillCNCSettings settingCNC = new DrillCNCSettings();

	public static List<string> Captions = new List<string>();

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private drillFocusedData drillFocusedData_0 = drillFocusedData.None;

	private double double_0 = -1.0;

	private double double_1 = 0.0;

	private bool bool_0 = false;

	private F_HolesTemp f_HolesTemp_0 = null;

	[CompilerGenerated]
	private OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Panel panel_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Panel panel_1;

	internal PictureBox pictureBox_0;

	internal Label label_6;

	public Button btn_cornerrightBottom;

	public Button btn_cornerleftTop;

	public Button btn_cornerrightTop;

	public Button btn_cornerleftBottom;

	public Button btn_top;

	public Button btn_bottom;

	public Button btn_left;

	public Button btn_right;

	public Button btn_back;

	public Button btn_front;

	public event OkCommandWithThreeDataEventHandler DataChanged
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Combine(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Remove(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler DataCancel
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

	public F_Holes3D()
	{
		Class5.smethod_10(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void ControlUpdate()
	{
	}

	public void AddControlsFromCommand()
	{
		panel_0.Controls.Clear();
	}

	public void Apply()
	{
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		new Control();
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
