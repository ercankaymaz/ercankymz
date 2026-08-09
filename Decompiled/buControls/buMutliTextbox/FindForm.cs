using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class FindForm : Form
{
	internal bool bool_0 = true;

	private Place place_0;

	private buMultiTextBox tb;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal Label label_0;

	internal CheckBox checkBox_2;

	public TextBox tbFind;

	public FindForm(buMultiTextBox tb)
	{
		Class76.smethod_541(this);
		this.tb = tb;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Close();
	}

	internal void method_1(object sender, EventArgs e)
	{
		FindNext(tbFind.Text);
	}

	public virtual void FindNext(string pattern)
	{
		try
		{
			RegexOptions options = ((!checkBox_1.Checked) ? RegexOptions.IgnoreCase : RegexOptions.None);
			if (!checkBox_0.Checked)
			{
				pattern = Regex.Escape(pattern);
			}
			if (checkBox_2.Checked)
			{
				pattern = "\\b" + pattern + "\\b";
			}
			Range range = tb.Selection.Clone();
			range.Normalize();
			if (bool_0)
			{
				place_0 = range.Start;
				bool_0 = false;
			}
			range.Start = range.End;
			if (!(range.Start >= place_0))
			{
				range.End = place_0;
			}
			else
			{
				range.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
			}
			using (IEnumerator<Range> enumerator = range.GetRangesByLines(pattern, options).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Range current = enumerator.Current;
					tb.Selection = current;
					tb.DoSelectionVisible();
					tb.Invalidate();
					return;
				}
			}
			if (!(range.Start >= place_0) || !(place_0 > Place.Empty))
			{
				MessageBox.Show("Not found");
				return;
			}
			tb.Selection.Start = new Place(0, 0);
			FindNext(pattern);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	internal void method_2(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			if (e.KeyChar == '\u001b')
			{
				Hide();
				e.Handled = true;
			}
		}
		else
		{
			button_1.PerformClick();
			e.Handled = true;
		}
	}

	internal void method_3(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			Hide();
		}
		tb.Focus();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (keyData != Keys.Escape)
		{
			return base.ProcessCmdKey(ref msg, keyData);
		}
		Close();
		return true;
	}

	protected override void OnActivated(EventArgs e)
	{
		tbFind.Focus();
		bool_0 = true;
	}

	internal void method_4(object sender, EventArgs e)
	{
		bool_0 = true;
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
