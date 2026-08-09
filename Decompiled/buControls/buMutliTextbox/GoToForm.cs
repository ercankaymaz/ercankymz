using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class GoToForm : Form
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal TextBox textBox_0;

	internal Button button_0;

	internal Button button_1;

	public int SelectedLineNumber
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int TotalLineCount
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public GoToForm()
	{
		Class76.smethod_404(this);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		textBox_0.Text = SelectedLineNumber.ToString();
		label_0.Text = $"Line number (1 - {TotalLineCount}):";
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		textBox_0.Focus();
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (int.TryParse(textBox_0.Text, out var result))
		{
			result = Math.Min(result, TotalLineCount);
			result = Math.Max(1, result);
			SelectedLineNumber = result;
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	internal void method_1(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
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
