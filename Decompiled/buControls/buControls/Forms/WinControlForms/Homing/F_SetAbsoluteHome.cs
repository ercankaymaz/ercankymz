using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Homing;

public class F_SetAbsoluteHome : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle_0;

	public int SelectedAxis = 0;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	public NumericUpDown spn_sethome;

	internal Button button_0;

	internal Button button_1;

	public ListBox lst_axis;

	public event AbsoluteHomeSetEventHandle SetAbsoluteHome
	{
		[CompilerGenerated]
		add
		{
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle = absoluteHomeSetEventHandle_0;
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle2;
			do
			{
				absoluteHomeSetEventHandle2 = absoluteHomeSetEventHandle;
				AbsoluteHomeSetEventHandle value2 = (AbsoluteHomeSetEventHandle)Delegate.Combine(absoluteHomeSetEventHandle2, value);
				absoluteHomeSetEventHandle = Interlocked.CompareExchange(ref absoluteHomeSetEventHandle_0, value2, absoluteHomeSetEventHandle2);
			}
			while ((object)absoluteHomeSetEventHandle != absoluteHomeSetEventHandle2);
		}
		[CompilerGenerated]
		remove
		{
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle = absoluteHomeSetEventHandle_0;
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle2;
			do
			{
				absoluteHomeSetEventHandle2 = absoluteHomeSetEventHandle;
				AbsoluteHomeSetEventHandle value2 = (AbsoluteHomeSetEventHandle)Delegate.Remove(absoluteHomeSetEventHandle2, value);
				absoluteHomeSetEventHandle = Interlocked.CompareExchange(ref absoluteHomeSetEventHandle_0, value2, absoluteHomeSetEventHandle2);
			}
			while ((object)absoluteHomeSetEventHandle != absoluteHomeSetEventHandle2);
		}
	}

	public F_SetAbsoluteHome()
	{
		Class76.smethod_73(this);
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
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (absoluteHomeSetEventHandle_0 != null)
		{
			SelectedAxis = lst_axis.SelectedIndex;
			absoluteHomeSetEventHandle_0(SelectedAxis, (double)spn_sethome.Value);
		}
	}

	internal void method_2(object sender, EventArgs e)
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
