using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using buControls.Controls;
using buCore;
using buMutliTextbox;
using ns27;

namespace buControls.Forms.buControlForms.Notepad;

public class F_Notepad : Form
{
	public static List<string> Messages = new List<string>();

	public List<string> Captions = new List<string>();

	public string LastSavedDirectory = Application.StartupPath;

	public bool FormTopMost = false;

	public bool ReadOnly = false;

	public bool ScreenCenter = true;

	private string string_0 = "CSharp (custom highlighter)";

	internal TextStyle textStyle_0 = new TextStyle(Brushes.Blue, null, FontStyle.Regular);

	internal TextStyle textStyle_1 = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);

	internal TextStyle textStyle_2 = new TextStyle(Brushes.Gray, null, FontStyle.Regular);

	internal TextStyle textStyle_3 = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);

	internal TextStyle textStyle_4 = new TextStyle(Brushes.Green, null, FontStyle.Italic);

	internal TextStyle textStyle_5 = new TextStyle(Brushes.Brown, null, FontStyle.Italic);

	private TextStyle textStyle_6 = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);

	internal MarkerStyle markerStyle_0 = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

	internal bool bool_0;

	internal string string_1 = "";

	private Random random_0 = new Random();

	internal IContainer icontainer_0 = null;

	internal buMultiTextBox buMultiTextBox_0;

	internal MenuStrip menuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal ToolStripSeparator toolStripSeparator_0;

	internal ToolStripMenuItem toolStripMenuItem_6;

	internal ToolStripMenuItem toolStripMenuItem_7;

	internal ToolStripMenuItem toolStripMenuItem_8;

	internal ToolStripMenuItem toolStripMenuItem_9;

	internal ToolStripMenuItem toolStripMenuItem_10;

	internal ToolStripMenuItem toolStripMenuItem_11;

	internal ToolStripMenuItem toolStripMenuItem_12;

	internal ToolStripMenuItem toolStripMenuItem_13;

	internal ToolStripSeparator toolStripSeparator_1;

	internal ToolStripMenuItem toolStripMenuItem_14;

	internal ToolStripMenuItem toolStripMenuItem_15;

	internal ToolStripMenuItem toolStripMenuItem_16;

	internal ToolStripMenuItem toolStripMenuItem_17;

	internal ToolStripMenuItem toolStripMenuItem_18;

	internal ToolStripMenuItem toolStripMenuItem_19;

	internal ToolStripMenuItem toolStripMenuItem_20;

	internal ToolStripSeparator toolStripSeparator_2;

	internal ToolStripMenuItem toolStripMenuItem_21;

	internal ToolStripSeparator toolStripSeparator_3;

	internal ToolStripMenuItem toolStripMenuItem_22;

	internal ToolStripMenuItem toolStripMenuItem_23;

	internal ToolStripSeparator toolStripSeparator_4;

	internal ToolStripMenuItem toolStripMenuItem_24;

	internal ToolStripMenuItem toolStripMenuItem_25;

	internal ToolStripSeparator toolStripSeparator_5;

	internal ToolStripMenuItem toolStripMenuItem_26;

	internal ToolStripMenuItem toolStripMenuItem_27;

	internal ToolStripMenuItem toolStripMenuItem_28;

	internal ToolStripMenuItem toolStripMenuItem_29;

	internal ToolStripSeparator toolStripSeparator_6;

	internal ToolStripMenuItem toolStripMenuItem_30;

	internal ToolStripMenuItem toolStripMenuItem_31;

	internal ToolStripSeparator toolStripSeparator_7;

	internal ToolStripMenuItem toolStripMenuItem_32;

	internal ToolStripMenuItem toolStripMenuItem_33;

	internal ToolStripSeparator toolStripSeparator_8;

	internal ToolStripMenuItem toolStripMenuItem_34;

	internal ToolStripMenuItem toolStripMenuItem_35;

	internal ToolStripMenuItem toolStripMenuItem_36;

	internal ToolStripMenuItem toolStripMenuItem_37;

	internal ToolStripSeparator toolStripSeparator_9;

	internal ToolStripMenuItem toolStripMenuItem_38;

	internal ToolStripMenuItem toolStripMenuItem_39;

	internal ToolStripMenuItem toolStripMenuItem_40;

	internal ToolStripMenuItem toolStripMenuItem_41;

	internal ToolStripSeparator toolStripSeparator_10;

	internal ToolStripMenuItem toolStripMenuItem_42;

	internal ToolStripMenuItem toolStripMenuItem_43;

	internal ToolStripSeparator toolStripSeparator_11;

	internal ToolStripMenuItem toolStripMenuItem_44;

	internal ToolStripMenuItem toolStripMenuItem_45;

	internal ToolStripSeparator toolStripSeparator_12;

	internal ToolStripMenuItem toolStripMenuItem_46;

	internal ToolStripSeparator toolStripSeparator_13;

	internal ToolStripMenuItem toolStripMenuItem_47;

	internal ToolStripMenuItem toolStripMenuItem_48;

	internal ToolStripSeparator toolStripSeparator_14;

	internal ToolStripSeparator toolStripSeparator_15;

	internal ToolStripMenuItem toolStripMenuItem_49;

	internal buGround buGround_0;

	internal ImageList imageList_0;

	internal ToolStrip toolStrip_0;

	internal ToolStripButton toolStripButton_0;

	internal ToolStripButton toolStripButton_1;

	internal ToolStripButton toolStripButton_2;

	internal ToolStripButton toolStripButton_3;

	internal ToolStripSeparator toolStripSeparator_16;

	internal ToolStripButton toolStripButton_4;

	internal ToolStripButton toolStripButton_5;

	internal ToolStripSeparator toolStripSeparator_17;

	internal ToolStripButton toolStripButton_6;

	internal ToolStripButton toolStripButton_7;

	internal ToolStripButton toolStripButton_8;

	internal ToolStripSeparator toolStripSeparator_18;

	internal ToolStripButton toolStripButton_9;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	public F_Notepad()
	{
		Class76.smethod_122(this);
	}

	internal void method_0(object sender, TextChangedEventArgs e)
	{
		bool_0 = true;
		string text = string_0;
		string text2 = text;
		if (text2 == "CSharp (custom highlighter)")
		{
			Class76.smethod_13(this, e);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		buMultiTextBox_0.ShowFindDialog();
	}

	internal void method_2(object sender, EventArgs e)
	{
		buMultiTextBox_0.ShowReplaceDialog();
	}

	internal void method_3(object sender, EventArgs e)
	{
		foreach (ToolStripMenuItem dropDownItem in toolStripMenuItem_3.DropDownItems)
		{
			dropDownItem.Checked = dropDownItem.Text == string_0;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		string_0 = (sender as ToolStripMenuItem).Text;
		buMultiTextBox_0.ClearStylesBuffer();
		buMultiTextBox_0.Range.ClearStyle(StyleIndex.All);
		Class76.smethod_524(this);
		buMultiTextBox_0.AutoIndentNeeded -= method_17;
		string text = string_0;
		string text2 = text;
		switch (Class76.smethod_599(text2))
		{
		case 3845047600u:
			if (text2 == "CSharp (built-in highlighter)")
			{
				buMultiTextBox_0.Language = Language.CSharp;
			}
			break;
		case 1039209162u:
			if (text2 == "JS")
			{
				buMultiTextBox_0.Language = Language.JS;
			}
			break;
		case 18818719u:
			if (text2 == "SQL")
			{
				buMultiTextBox_0.Language = Language.SQL;
			}
			break;
		case 348642512u:
			if (text2 == "HTML")
			{
				buMultiTextBox_0.Language = Language.HTML;
			}
			break;
		case 1727679921u:
			if (text2 == "VB")
			{
				buMultiTextBox_0.Language = Language.VB;
			}
			break;
		case 2683950351u:
			if (text2 == "PHP")
			{
				buMultiTextBox_0.Language = Language.PHP;
			}
			break;
		case 3223109505u:
			if (text2 == "Lua")
			{
				buMultiTextBox_0.Language = Language.Lua;
			}
			break;
		case 3877699969u:
			if (text2 == "CSharp (custom highlighter)")
			{
				buMultiTextBox_0.Language = Language.Custom;
				buMultiTextBox_0.CommentPrefix = "//";
				buMultiTextBox_0.AutoIndentNeeded += method_17;
				buMultiTextBox_0.OnTextChanged();
			}
			break;
		}
		buMultiTextBox_0.OnSyntaxHighlight(new TextChangedEventArgs(buMultiTextBox_0.Range));
		toolStripMenuItem_12.Enabled = string_0 != "CSharp (custom highlighter)";
	}

	internal void method_5(object sender, EventArgs e)
	{
		buMultiTextBox_0.CollapseBlock(buMultiTextBox_0.Selection.Start.iLine, buMultiTextBox_0.Selection.End.iLine);
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (!string_0.StartsWith("CSharp"))
		{
			return;
		}
		for (int i = 0; i < buMultiTextBox_0.LinesCount; i++)
		{
			if (buMultiTextBox_0[i].FoldingStartMarker == "#region\\b")
			{
				buMultiTextBox_0.CollapseFoldingBlock(i);
			}
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if (!string_0.StartsWith("CSharp"))
		{
			return;
		}
		for (int i = 0; i < buMultiTextBox_0.LinesCount; i++)
		{
			if (buMultiTextBox_0[i].FoldingStartMarker == "#region\\b")
			{
				buMultiTextBox_0.ExpandFoldedBlock(i);
			}
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		buMultiTextBox_0.IncreaseIndent();
	}

	internal void method_9(object sender, EventArgs e)
	{
		buMultiTextBox_0.DecreaseIndent();
	}

	internal void method_10(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "HTML with <PRE> tag|*.html|HTML without <PRE> tag|*.html";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			string contents = "";
			if (saveFileDialog.FilterIndex == 1)
			{
				contents = buMultiTextBox_0.Html;
			}
			if (saveFileDialog.FilterIndex == 2)
			{
				ExportToHTML exportToHTML = new ExportToHTML();
				exportToHTML.UseBr = true;
				exportToHTML.UseNbsp = false;
				exportToHTML.UseForwardNbsp = true;
				exportToHTML.UseStyleTag = true;
				contents = exportToHTML.GetHtml(buMultiTextBox_0);
			}
			File.WriteAllText(saveFileDialog.FileName, contents);
		}
	}

	internal void method_11(object sender, EventArgs e)
	{
		buMultiTextBox_0.VisibleRange.ClearStyle(markerStyle_0);
		if (!buMultiTextBox_0.Selection.IsEmpty)
		{
			return;
		}
		Range fragment = buMultiTextBox_0.Selection.GetFragment("\\w");
		string text = fragment.Text;
		if (text.Length == 0)
		{
			return;
		}
		Range[] array = buMultiTextBox_0.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
		if (array.Length > 1)
		{
			Range[] array2 = array;
			foreach (Range range in array2)
			{
				range.SetStyle(markerStyle_0);
			}
		}
	}

	internal void method_12(object sender, EventArgs e)
	{
		buMultiTextBox_0.NavigateForward();
	}

	internal void method_13(object sender, EventArgs e)
	{
		buMultiTextBox_0.NavigateBackward();
	}

	internal void method_14(object sender, EventArgs e)
	{
		buMultiTextBox_0.DoAutoIndent();
	}

	internal void method_15(object sender, EventArgs e)
	{
		Class76.smethod_158(buMultiTextBox_0, '}', this, '{');
	}

	internal void method_16(object sender, EventArgs e)
	{
		Class76.smethod_229(buMultiTextBox_0, '{', '}', this);
	}

	internal void method_17(object sender, AutoIndentEventArgs e)
	{
		if (Regex.IsMatch(e.LineText, "^[^\"']*\\{.*\\}[^\"']*$"))
		{
			return;
		}
		if (!Regex.IsMatch(e.LineText, "^[^\"']*\\{"))
		{
			if (!Regex.IsMatch(e.LineText, "}[^\"']*$"))
			{
				if (!Regex.IsMatch(e.LineText, "^\\s*\\w+\\s*:\\s*($|//)") || Regex.IsMatch(e.LineText, "^\\s*default\\s*:"))
				{
					if (!Regex.IsMatch(e.LineText, "^\\s*(case|default)\\b.*:\\s*($|//)"))
					{
						if (Regex.IsMatch(e.PrevLineText, "^\\s*(if|for|foreach|while|[\\}\\s]*else)\\b[^{]*$") && !Regex.IsMatch(e.PrevLineText, "(;\\s*$)|(;\\s*//)"))
						{
							e.Shift = e.TabLength;
						}
					}
					else
					{
						e.Shift = -e.TabLength / 2;
					}
				}
				else
				{
					e.Shift = -e.TabLength;
				}
			}
			else
			{
				e.Shift = -e.TabLength;
				e.ShiftNextLines = -e.TabLength;
			}
		}
		else
		{
			e.ShiftNextLines = e.TabLength;
		}
	}

	internal void method_18(object sender, EventArgs e)
	{
		buMultiTextBox_0.Print(new PrintDialogSettings
		{
			ShowPrintPreviewDialog = true
		});
	}

	internal void method_19(object sender, EventArgs e)
	{
		Style[] array = new Style[9]
		{
			buMultiTextBox_0.SyntaxHighlighter.BlueBoldStyle,
			buMultiTextBox_0.SyntaxHighlighter.BlueStyle,
			buMultiTextBox_0.SyntaxHighlighter.BoldStyle,
			buMultiTextBox_0.SyntaxHighlighter.BrownStyle,
			buMultiTextBox_0.SyntaxHighlighter.GrayStyle,
			buMultiTextBox_0.SyntaxHighlighter.GreenStyle,
			buMultiTextBox_0.SyntaxHighlighter.MagentaStyle,
			buMultiTextBox_0.SyntaxHighlighter.MaroonStyle,
			buMultiTextBox_0.SyntaxHighlighter.RedStyle
		};
		buMultiTextBox_0.SyntaxHighlighter.AttributeStyle = array[random_0.Next(9)];
		buMultiTextBox_0.SyntaxHighlighter.ClassNameStyle = array[random_0.Next(9)];
		buMultiTextBox_0.SyntaxHighlighter.CommentStyle = array[random_0.Next(9)];
		buMultiTextBox_0.SyntaxHighlighter.CommentTagStyle = array[random_0.Next(9)];
		buMultiTextBox_0.SyntaxHighlighter.KeywordStyle = array[random_0.Next(9)];
		buMultiTextBox_0.SyntaxHighlighter.NumberStyle = array[random_0.Next(9)];
		buMultiTextBox_0.SyntaxHighlighter.StringStyle = array[random_0.Next(9)];
		buMultiTextBox_0.OnSyntaxHighlight(new TextChangedEventArgs(buMultiTextBox_0.Range));
	}

	internal void method_20(object sender, EventArgs e)
	{
		buMultiTextBox_0.Selection.ReadOnly = true;
	}

	internal void method_21(object sender, EventArgs e)
	{
		buMultiTextBox_0.Selection.ReadOnly = false;
	}

	internal void method_22(object sender, EventArgs e)
	{
		buMultiTextBox_0.MacrosManager.IsRecording = !buMultiTextBox_0.MacrosManager.IsRecording;
	}

	internal void method_23(object sender, EventArgs e)
	{
		buMultiTextBox_0.MacrosManager.ExecuteMacros();
	}

	internal void method_24(object sender, EventArgs e)
	{
		HotkeysEditorForm hotkeysEditorForm = new HotkeysEditorForm(buMultiTextBox_0.HotkeysMapping);
		if (hotkeysEditorForm.ShowDialog() == DialogResult.OK)
		{
			buMultiTextBox_0.HotkeysMapping = hotkeysEditorForm.GetHotkeys();
		}
	}

	internal void method_25(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "RTF|*.rtf";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			string rtf = buMultiTextBox_0.Rtf;
			File.WriteAllText(saveFileDialog.FileName, rtf);
		}
	}

	internal void method_26(object sender, CustomActionEventArgs e)
	{
		MessageBox.Show(e.Action.ToString());
	}

	internal void method_27(object sender, EventArgs e)
	{
		buMultiTextBox_0.InsertLinePrefix(buMultiTextBox_0.CommentPrefix);
	}

	internal void method_28(object sender, EventArgs e)
	{
		buMultiTextBox_0.RemoveLinePrefix(buMultiTextBox_0.CommentPrefix);
	}

	internal void method_29(object sender, EventArgs e)
	{
	}

	public void Init()
	{
		LoadLanguage();
		base.TopMost = FormTopMost;
		if (ScreenCenter)
		{
			base.StartPosition = FormStartPosition.CenterScreen;
		}
	}

	public void Init(string text)
	{
		buMultiTextBox_0.WordWrap = true;
		buMultiTextBox_0.Language = Language.HTML;
		buMultiTextBox_0.Text = text;
		LoadLanguage();
		base.TopMost = FormTopMost;
		if (ScreenCenter)
		{
			base.StartPosition = FormStartPosition.CenterScreen;
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 39)
			{
				Text = Captions[0];
				toolStripMenuItem_19.Text = Captions[1];
				toolStripMenuItem_20.Text = Captions[2];
				toolStripButton_0.ToolTipText = Captions[2];
				toolStripMenuItem_21.Text = Captions[3];
				toolStripButton_1.ToolTipText = Captions[3];
				toolStripMenuItem_22.Text = Captions[4];
				toolStripButton_2.ToolTipText = Captions[4];
				toolStripMenuItem_23.Text = Captions[5];
				toolStripMenuItem_24.Text = Captions[6];
				toolStripButton_3.ToolTipText = Captions[6];
				toolStripMenuItem_25.Text = Captions[7];
				toolStripMenuItem_26.Text = Captions[8];
				toolStripMenuItem_0.Text = Captions[9];
				toolStripMenuItem_37.Text = Captions[10];
				toolStripButton_4.ToolTipText = Captions[10];
				toolStripMenuItem_36.Text = Captions[11];
				toolStripButton_5.ToolTipText = Captions[11];
				toolStripMenuItem_27.Text = Captions[12];
				toolStripButton_6.ToolTipText = Captions[12];
				toolStripMenuItem_28.Text = Captions[13];
				toolStripButton_8.ToolTipText = Captions[13];
				toolStripMenuItem_29.Text = Captions[14];
				toolStripButton_7.ToolTipText = Captions[14];
				toolStripMenuItem_1.Text = Captions[15];
				toolStripMenuItem_2.Text = Captions[16];
				toolStripMenuItem_38.Text = Captions[17];
				toolStripMenuItem_49.Text = Captions[18];
				toolStripMenuItem_39.Text = Captions[19];
				toolStripMenuItem_14.Text = Captions[20];
				toolStripMenuItem_15.Text = Captions[21];
				toolStripMenuItem_40.Text = Captions[22];
				toolStripMenuItem_41.Text = Captions[23];
				toolStripMenuItem_42.Text = Captions[24];
				toolStripMenuItem_43.Text = Captions[25];
				toolStripMenuItem_44.Text = Captions[26];
				toolStripMenuItem_45.Text = Captions[27];
				toolStripMenuItem_46.Text = Captions[28];
				toolStripMenuItem_47.Text = Captions[29];
				toolStripMenuItem_48.Text = Captions[30];
				toolStripMenuItem_30.Text = Captions[31];
				toolStripMenuItem_31.Text = Captions[32];
				toolStripMenuItem_32.Text = Captions[33];
				toolStripButton_9.ToolTipText = Captions[33];
				toolStripMenuItem_33.Text = Captions[34];
				toolStripMenuItem_34.Text = Captions[35];
				toolStripMenuItem_35.Text = Captions[36];
				toolStripMenuItem_3.Text = Captions[37];
				toolStripMenuItem_4.Text = Captions[38];
				toolStripMenuItem_6.Text = Captions[39];
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_30(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
	}

	internal void method_31(object sender, EventArgs e)
	{
		buMultiTextBox_0.Copy();
	}

	internal void method_32(object sender, EventArgs e)
	{
		buMultiTextBox_0.Cut();
	}

	internal void method_33(object sender, EventArgs e)
	{
		buMultiTextBox_0.Paste();
	}

	internal void method_34(object sender, EventArgs e)
	{
		buMultiTextBox_0.SelectAll();
	}

	internal void method_35(object sender, EventArgs e)
	{
		buMultiTextBox_0.Undo();
	}

	internal void method_36(object sender, EventArgs e)
	{
		buMultiTextBox_0.Redo();
	}

	internal void method_37(object sender, EventArgs e)
	{
		if (bool_0)
		{
			string message = "Do You Want to Save File";
			if (Messages.Count > 0)
			{
				message = Messages[0];
			}
			DialogResult dialogResult = buString.MessageBoxQuestionYesNoCancel(message);
			if (dialogResult != DialogResult.Cancel)
			{
				if (dialogResult == DialogResult.No)
				{
					buMultiTextBox_0.Text = "";
					bool_0 = false;
					string_1 = "";
				}
				if (dialogResult == DialogResult.Yes)
				{
					Class76.smethod_389(this);
					buMultiTextBox_0.Text = "";
					bool_0 = false;
					string_1 = "";
				}
			}
		}
		else
		{
			buMultiTextBox_0.Text = "";
			bool_0 = false;
			string_1 = "";
		}
	}

	internal void method_38(object sender, EventArgs e)
	{
		buMultiTextBox_0.ShowGoToDialog();
	}

	internal void method_39(object sender, EventArgs e)
	{
		if (bool_0)
		{
			string message = "Do You Want to Save File";
			if (Messages.Count > 0)
			{
				message = Messages[0];
			}
			DialogResult dialogResult = buString.MessageBoxQuestionYesNoCancel(message);
			if (dialogResult != DialogResult.Cancel)
			{
				if (dialogResult == DialogResult.No)
				{
					Class76.smethod_230(this);
				}
				if (dialogResult == DialogResult.Yes)
				{
					Class76.smethod_389(this);
					Class76.smethod_230(this);
				}
			}
		}
		else
		{
			Class76.smethod_230(this);
		}
	}

	internal void method_40(object sender, EventArgs e)
	{
		Class76.smethod_389(this);
	}

	internal void method_41(object sender, EventArgs e)
	{
		Class76.smethod_66(this);
	}

	internal void method_42(object sender, EventArgs e)
	{
		base.Visible = false;
	}

	internal void method_43(object sender, EventArgs e)
	{
		PrintDocument printDocument = new PrintDocument();
		printDocument.PrintPage += method_44;
		PrintDialog printDialog = new PrintDialog();
		if (printDialog.ShowDialog() == DialogResult.OK)
		{
			printDocument.Print();
		}
	}

	private void method_44(object sender, PrintPageEventArgs e)
	{
		e.Graphics.DrawString(buMultiTextBox_0.Text, buMultiTextBox_0.Font, Brushes.Black, 10f, 10f);
	}

	internal void method_45(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == buButton_2.Name)
		{
			Dispose();
		}
		if (control.Name == buButton_1.Name)
		{
			base.WindowState = FormWindowState.Minimized;
		}
		if (control.Name == buButton_0.Name)
		{
			if (base.WindowState != FormWindowState.Maximized)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			else
			{
				base.WindowState = FormWindowState.Normal;
			}
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
