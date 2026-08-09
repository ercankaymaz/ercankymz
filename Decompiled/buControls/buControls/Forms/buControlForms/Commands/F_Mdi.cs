using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.Commands;

public class F_Mdi : Form
{
	[CompilerGenerated]
	private MdiClickEventHandler mdiClickEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buTextBox buTextBox_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	public event MdiClickEventHandler MdiClick
	{
		[CompilerGenerated]
		add
		{
			MdiClickEventHandler mdiClickEventHandler = mdiClickEventHandler_0;
			MdiClickEventHandler mdiClickEventHandler2;
			do
			{
				mdiClickEventHandler2 = mdiClickEventHandler;
				MdiClickEventHandler value2 = (MdiClickEventHandler)Delegate.Combine(mdiClickEventHandler2, value);
				mdiClickEventHandler = Interlocked.CompareExchange(ref mdiClickEventHandler_0, value2, mdiClickEventHandler2);
			}
			while ((object)mdiClickEventHandler != mdiClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MdiClickEventHandler mdiClickEventHandler = mdiClickEventHandler_0;
			MdiClickEventHandler mdiClickEventHandler2;
			do
			{
				mdiClickEventHandler2 = mdiClickEventHandler;
				MdiClickEventHandler value2 = (MdiClickEventHandler)Delegate.Remove(mdiClickEventHandler2, value);
				mdiClickEventHandler = Interlocked.CompareExchange(ref mdiClickEventHandler_0, value2, mdiClickEventHandler2);
			}
			while ((object)mdiClickEventHandler != mdiClickEventHandler2);
		}
	}

	public F_Mdi()
	{
		Class76.smethod_63(this);
	}

	public void Init()
	{
	}

	internal void method_0(object sender, EventArgs e)
	{
		try
		{
			if (mdiClickEventHandler_0 != null)
			{
				mdiClickEventHandler_0(this, buTextBox_0.Text);
			}
			base.Visible = false;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_2.Name) | (control.Name == buButton_0.Name))
			{
				base.Visible = false;
			}
			if (control.Name == buButton_1.Name)
			{
				base.WindowState = FormWindowState.Minimized;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
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
