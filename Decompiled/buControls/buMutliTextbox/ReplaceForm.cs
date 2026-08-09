using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class ReplaceForm : Form
{
	private buMultiTextBox tb;

	internal bool bool_0 = true;

	private Place place_0;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal Label label_0;

	internal CheckBox checkBox_2;

	internal Button button_2;

	internal Button button_3;

	internal Label label_1;

	public TextBox tbFind;

	public TextBox tbReplace;

	public ReplaceForm(buMultiTextBox tb)
	{
		Class76.smethod_269(this);
		this.tb = tb;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Close();
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (!Find(tbFind.Text))
			{
				MessageBox.Show("Not found");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public List<Range> FindAll(string pattern)
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
		Range range = ((!tb.Selection.IsEmpty) ? tb.Selection.Clone() : tb.Range.Clone());
		List<Range> list = new List<Range>();
		foreach (Range rangesByLine in range.GetRangesByLines(pattern, options))
		{
			list.Add(rangesByLine);
		}
		return list;
	}

	public bool Find(string pattern)
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
				tb.Selection.Start = current.Start;
				tb.Selection.End = current.End;
				tb.DoSelectionVisible();
				tb.Invalidate();
				return true;
			}
		}
		if (!(range.Start >= place_0) || !(place_0 > Place.Empty))
		{
			return false;
		}
		tb.Selection.Start = new Place(0, 0);
		return Find(pattern);
	}

	internal void method_2(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			method_1(sender, null);
		}
		if (e.KeyChar == '\u001b')
		{
			Hide();
		}
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

	internal void method_3(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			Hide();
		}
		tb.Focus();
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			if (tb.SelectionLength != 0 && !tb.Selection.ReadOnly)
			{
				tb.InsertText(tbReplace.Text);
			}
			method_1(sender, null);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			tb.Selection.BeginUpdate();
			List<Range> list = FindAll(tbFind.Text);
			bool flag = false;
			foreach (Range item in list)
			{
				if (item.ReadOnly)
				{
					flag = true;
					break;
				}
			}
			if (!flag && list.Count > 0)
			{
				tb.TextSource.Manager.ExecuteCommand(new ReplaceTextCommand(tb.TextSource, list, tbReplace.Text));
				tb.Selection.Start = new Place(0, 0);
			}
			tb.Invalidate();
			MessageBox.Show(list.Count + " occurrence(s) replaced");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		tb.Selection.EndUpdate();
	}

	protected override void OnActivated(EventArgs e)
	{
		tbFind.Focus();
		bool_0 = true;
	}

	internal void method_6(object sender, EventArgs e)
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
