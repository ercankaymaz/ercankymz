using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_ToolTest : Form
{
	public List<string> Tools = new List<string>();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_0;

	private IContainer icontainer_0 = null;

	internal ListBox listBox_0;

	internal Button button_0;

	internal Button button_1;

	public event ValueChangedEventHandler ToolTest
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	public F_ToolTest()
	{
		Class76.smethod_786(this);
	}

	public void Init()
	{
		listBox_0.Items.Clear();
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			listBox_0.Items.Add(Tools[i]);
		}
		listBox_0.SelectedIndex = 0;
		Class76.smethod_100(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		base.Visible = false;
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (valueChangedEventHandler_0 != null)
		{
			valueChangedEventHandler_0(listBox_0.SelectedIndex);
		}
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
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
