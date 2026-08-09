using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestedResults : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public Design viewport = null;

	[CompilerGenerated]
	private CreatbuNestedResultEventHandler creatbuNestedResultEventHandler_0;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_1;

	[CompilerGenerated]
	private ClickSenderDataEventHandler clickSenderDataEventHandler_0;

	public List<LayerBase5> Layers = new List<LayerBase5>();

	public buNestingResultSettings NestingResultSettings = new buNestingResultSettings();

	public buNestingRuntime RunParameter = new buNestingRuntime();

	public string pathSaveImage = Application.StartupPath;

	public string strSheetName = "Sheet";

	public bool DrawFatBorderAtPreview = false;

	public buNestingVar NestParameters = new buNestingVar();

	private int int_0 = -1;

	internal int int_1 = -1;

	private string string_0 = "";

	private bool bool_0 = false;

	private buNestedResult buNestedResult_0 = null;

	private buNestedSheet buNestedSheet_0 = null;

	private TreeNode treeNode_0 = null;

	internal IContainer icontainer_0 = null;

	public TreeView tree_nest;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripSeparator toolStripSeparator_0;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripSeparator toolStripSeparator_1;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal ToolStripSeparator toolStripSeparator_2;

	internal ToolStripMenuItem toolStripMenuItem_6;

	internal ToolStripMenuItem toolStripMenuItem_7;

	internal Button button_0;

	internal Panel panel_0;

	internal Label label_0;

	internal Button button_1;

	internal Button button_2;

	internal ImageList imageList_0;

	internal Panel panel_1;

	public CheckBox chk_docam;

	internal ToolStripMenuItem toolStripMenuItem_8;

	internal Panel panel_2;

	internal TextBox textBox_0;

	internal Label label_1;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	public CheckBox chk_pdf;

	internal ToolStripSeparator toolStripSeparator_3;

	internal RadioButton radioButton_0;

	internal ComboBox comboBox_0;

	internal RadioButton radioButton_1;

	internal Label label_2;

	public CheckBox chk_csv;

	internal Panel panel_3;

	public CheckBox chk_addentitiestoend;

	public CheckBox chk_clearalldrawing;

	internal Label label_3;

	internal Panel panel_4;

	internal Label label_4;

	internal Button button_8;

	internal Label label_5;

	internal NumericUpDown numericUpDown_0;

	internal Button button_9;

	internal ToolStripSeparator toolStripSeparator_4;

	internal ToolStripMenuItem toolStripMenuItem_9;

	public event CreatbuNestedResultEventHandler Creat
	{
		[CompilerGenerated]
		add
		{
			CreatbuNestedResultEventHandler creatbuNestedResultEventHandler = creatbuNestedResultEventHandler_0;
			CreatbuNestedResultEventHandler creatbuNestedResultEventHandler2;
			do
			{
				creatbuNestedResultEventHandler2 = creatbuNestedResultEventHandler;
				CreatbuNestedResultEventHandler value2 = (CreatbuNestedResultEventHandler)Delegate.Combine(creatbuNestedResultEventHandler2, value);
				creatbuNestedResultEventHandler = Interlocked.CompareExchange(ref creatbuNestedResultEventHandler_0, value2, creatbuNestedResultEventHandler2);
			}
			while ((object)creatbuNestedResultEventHandler != creatbuNestedResultEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CreatbuNestedResultEventHandler creatbuNestedResultEventHandler = creatbuNestedResultEventHandler_0;
			CreatbuNestedResultEventHandler creatbuNestedResultEventHandler2;
			do
			{
				creatbuNestedResultEventHandler2 = creatbuNestedResultEventHandler;
				CreatbuNestedResultEventHandler value2 = (CreatbuNestedResultEventHandler)Delegate.Remove(creatbuNestedResultEventHandler2, value);
				creatbuNestedResultEventHandler = Interlocked.CompareExchange(ref creatbuNestedResultEventHandler_0, value2, creatbuNestedResultEventHandler2);
			}
			while ((object)creatbuNestedResultEventHandler != creatbuNestedResultEventHandler2);
		}
	}

	public event OkCommandWithDataEventHandler DrawResult
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public event OkCommandWithDataEventHandler Updated
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_1;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_1, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_1;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_1, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public event ClickSenderDataEventHandler Command
	{
		[CompilerGenerated]
		add
		{
			ClickSenderDataEventHandler clickSenderDataEventHandler = clickSenderDataEventHandler_0;
			ClickSenderDataEventHandler clickSenderDataEventHandler2;
			do
			{
				clickSenderDataEventHandler2 = clickSenderDataEventHandler;
				ClickSenderDataEventHandler value2 = (ClickSenderDataEventHandler)Delegate.Combine(clickSenderDataEventHandler2, value);
				clickSenderDataEventHandler = Interlocked.CompareExchange(ref clickSenderDataEventHandler_0, value2, clickSenderDataEventHandler2);
			}
			while ((object)clickSenderDataEventHandler != clickSenderDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ClickSenderDataEventHandler clickSenderDataEventHandler = clickSenderDataEventHandler_0;
			ClickSenderDataEventHandler clickSenderDataEventHandler2;
			do
			{
				clickSenderDataEventHandler2 = clickSenderDataEventHandler;
				ClickSenderDataEventHandler value2 = (ClickSenderDataEventHandler)Delegate.Remove(clickSenderDataEventHandler2, value);
				clickSenderDataEventHandler = Interlocked.CompareExchange(ref clickSenderDataEventHandler_0, value2, clickSenderDataEventHandler2);
			}
			while ((object)clickSenderDataEventHandler != clickSenderDataEventHandler2);
		}
	}

	public F_NestedResults()
	{
		Class186.smethod_655(this);
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
		NestingUpdate(ref tree_nest, buNestingCalc.NestedAllResults);
		if (viewport == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref viewport);
			viewport.Dock = DockStyle.Fill;
			if (panel_2.Controls.Count == 0)
			{
				panel_2.Controls.Add(viewport);
			}
		}
		if (comboBox_0.Items.Count == 0)
		{
			List<string> list = new List<string>();
			list = buConversion5.EnumToString(RunParameter.nestedResultCreateType.GetType());
			for (int i = 0; i <= list.Count - 1; i++)
			{
				comboBox_0.Items.Add(list[i]);
			}
		}
		if (RunParameter.nestedResultSheetType != nestedCreateSheetType.All)
		{
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
		}
		chk_docam.Checked = RunParameter.NestingResultDoCam;
		chk_pdf.Checked = RunParameter.NestingResultPdfFile;
		chk_csv.Checked = RunParameter.NestingResultCsv;
		comboBox_0.SelectedIndex = Convert.ToInt32(RunParameter.nestedResultCreateType);
		Class186.smethod_247(this);
		chk_addentitiestoend.Checked = NestParameters.ResultSettings.DrawAddToEnd;
		chk_clearalldrawing.Checked = NestParameters.ResultSettings.DrawAddClearAll;
		numericUpDown_0.Value = (decimal)NestParameters.ResultSettings.DrawAddToEndOffset;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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
		}
	}

	internal void method_1(object sender, KeyEventArgs e)
	{
		bool_0 = e.Control;
	}

	internal void method_2(object sender, KeyEventArgs e)
	{
		bool_0 = false;
	}

	public void NestingUpdate(ref TreeView tree, List<buNestedResult> nestResult)
	{
		tree.Nodes.Clear();
		TreeNode treeNode = null;
		for (int i = 0; i <= nestResult.Count - 1; i++)
		{
			string text = buNestingCalc.ResultItemFormat(nestResult[i]);
			treeNode = new TreeNode(text);
			treeNode.ImageIndex = 0;
			treeNode.SelectedImageIndex = 0;
			if (nestResult[i].NotNestedAll)
			{
				treeNode.ForeColor = Color.Red;
			}
			treeNode.Tag = i;
			for (int j = 0; j <= nestResult[i].NestedResultSheets.Count - 1; j++)
			{
				string text2 = buNestingCalc.SheetItemFormat(nestResult[i], strSheetName, j);
				TreeNode treeNode2 = new TreeNode(text2);
				treeNode2.ImageIndex = 1;
				treeNode2.SelectedImageIndex = 1;
				treeNode2.Tag = j;
				treeNode2.ForeColor = Color.Green;
				treeNode.Nodes.Add(treeNode2);
			}
			if (nestResult[i].NestedResultSheets.Count > 0)
			{
				tree.Nodes.Add(treeNode);
			}
		}
	}

	internal void method_3(object sender, TreeViewEventArgs e)
	{
		if (e.Node != null)
		{
			treeNode_0 = e.Node;
		}
		if (e.Node.Parent == null)
		{
			string_0 = e.Node.Text;
			int num = (int_1 = Convert.ToInt32(e.Node.Tag.ToString()));
			int_0 = -1;
			textBox_0.Text = buNestingCalc.NestedResultInfo(buNestingCalc.NestedAllResults[num], buNestingCalc.NestedAllResults[num].Parameters.ProgramSettings);
			if (buNestingCalc.NestedAllResults[num].Parameters.ProgramSettings.CalculationShowFormat != nestCalculationShowFormat.MultiSheet)
			{
				if (buNestingCalc.NestedAllResults[num].Parameters.ProgramSettings.CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
				{
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					for (int i = 0; i <= buNestingCalc.NestedAllResults.Count - 1; i++)
					{
						for (int j = 0; j <= buNestingCalc.NestedAllResults[i].NestedResultSheets.Count - 1; j++)
						{
							num3 += buNestingCalc.NestedAllResults[i].NestedResultSheets[j].UsingPersentageFromMaxX;
							num4 += buNestingCalc.NestedAllResults[i].NestedResultSheets[j].SheetMaxXPosition;
							num2 += 1.0;
						}
					}
					if (num2 > 0.0)
					{
						textBox_0.Text = textBox_0.Text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Efficiency + " : %" + (num3 / num2).ToString("f2") + Environment.NewLine;
						textBox_0.Text = textBox_0.Text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Pastal + " " + buLangTranslate.preDef.Length + " : " + num4.ToString("f2") + " mm";
					}
				}
			}
			else
			{
				double num5 = 0.0;
				double num6 = 0.0;
				for (int k = 0; k <= buNestingCalc.NestedAllResults.Count - 1; k++)
				{
					for (int l = 0; l <= buNestingCalc.NestedAllResults[k].NestedResultSheets.Count - 1; l++)
					{
						num6 += buNestingCalc.NestedAllResults[k].NestedResultSheets[l].UsingPersentage;
						num5 += 1.0;
					}
				}
				if (num5 > 0.0)
				{
					textBox_0.Text = textBox_0.Text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Efficiency + (num6 / num5).ToString("f2");
				}
			}
			if (okCommandWithDataEventHandler_0 != null)
			{
				buNestedResultSentEventArg buNestedResultSentEventArg2 = new buNestedResultSentEventArg();
				buNestedResultSentEventArg2.IndexPart = -1;
				buNestedResultSentEventArg2.IndexResult = num;
				buNestedResultSentEventArg2.IndexSheet = -1;
				buNestedResultSentEventArg2.NestResult = new buNestedResult(buNestingCalc.NestedAllResults[num]);
				okCommandWithDataEventHandler_0(buNestedResultSentEventArg2);
				viewport.SetView(viewType.Top, fit: true, animate: false);
			}
		}
		else if (e.Node.Tag != null)
		{
			int num7 = Convert.ToInt32(e.Node.Tag.ToString());
			int num8 = Convert.ToInt32(e.Node.Parent.Tag.ToString());
			string_0 = e.Node.Text;
			int_1 = num8;
			int_0 = num7;
			textBox_0.Text = buNestingCalc.NestedSheetInfo(buNestingCalc.NestedAllResults[num8], num7, buNestingCalc.NestedAllResults[num8].Parameters.ProgramSettings);
			if (buNestingCalc.NestedAllResults[num8].Parameters.ProgramSettings.CalculationShowFormat != nestCalculationShowFormat.MultiSheet)
			{
				if (buNestingCalc.NestedAllResults[num8].Parameters.ProgramSettings.CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
				{
					double num9 = 0.0;
					double num10 = 0.0;
					for (int m = 0; m <= buNestingCalc.NestedAllResults.Count - 1; m++)
					{
						for (int n = 0; n <= buNestingCalc.NestedAllResults[m].NestedResultSheets.Count - 1; n++)
						{
							num10 += buNestingCalc.NestedAllResults[m].NestedResultSheets[n].UsingPersentageFromMaxX;
							num9 += 1.0;
						}
					}
					if (num9 > 0.0)
					{
						textBox_0.Text = textBox_0.Text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Efficiency + " : %" + (num10 / num9).ToString("f2");
					}
				}
			}
			else
			{
				double num11 = 0.0;
				double num12 = 0.0;
				for (int num13 = 0; num13 <= buNestingCalc.NestedAllResults.Count - 1; num13++)
				{
					for (int num14 = 0; num14 <= buNestingCalc.NestedAllResults[num13].NestedResultSheets.Count - 1; num14++)
					{
						num12 += buNestingCalc.NestedAllResults[num13].NestedResultSheets[num14].UsingPersentage;
						num11 += 1.0;
					}
				}
				if (num11 > 0.0)
				{
					textBox_0.Text = textBox_0.Text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Efficiency + (num12 / num11).ToString("f2");
				}
			}
			Class186.smethod_74(this);
			if (okCommandWithDataEventHandler_0 != null)
			{
				buNestedResultSentEventArg buNestedResultSentEventArg3 = new buNestedResultSentEventArg();
				buNestedResultSentEventArg3.IndexPart = -1;
				buNestedResultSentEventArg3.IndexResult = num8;
				buNestedResultSentEventArg3.IndexSheet = num7;
				buNestedResultSentEventArg3.NestResult = new buNestedResult(buNestingCalc.NestedAllResults[num8]);
				okCommandWithDataEventHandler_0(buNestedResultSentEventArg3);
				viewport.SetView(viewType.Top, fit: true, animate: false);
			}
		}
		GC.Collect();
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (!((int_1 >= 0) & (int_1 <= buNestingCalc.NestedAllResults.Count - 1)) || !((int_0 >= 0) & (int_0 <= buNestingCalc.NestedAllResults[int_1].NestedResultSheets.Count - 1)))
		{
			return;
		}
		if (bool_0)
		{
			if (buNestingCalc.NestedAllResults[int_1].NestedResultSheets[int_0].DontUse)
			{
				buNestingCalc.NestedAllResults[int_1].NestedResultSheets[int_0].DontUse = false;
			}
			else
			{
				buNestingCalc.NestedAllResults[int_1].NestedResultSheets[int_0].DontUse = true;
			}
		}
		Class186.smethod_74(this);
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (creatbuNestedResultEventHandler_0 == null)
		{
			return;
		}
		buNestedResultEventArg buNestedResultEventArg2 = new buNestedResultEventArg();
		buNestedResultEventArg2.ResultCreateType = (nestedCreateType)comboBox_0.SelectedIndex;
		buNestedResultEventArg2.ResultSheetType = nestedCreateSheetType.All;
		buNestedResultEventArg2.ResultSettings = new buNestingResultSettings(NestParameters.ResultSettings);
		if (radioButton_0.Checked)
		{
			buNestedResultEventArg2.ResultSheetType = nestedCreateSheetType.Selected;
		}
		buNestedResultEventArg2.DoCam = chk_docam.Checked;
		buNestedResultEventArg2.PdfFile = chk_pdf.Checked;
		buNestedResultEventArg2.CsvFile = chk_csv.Checked;
		if ((buNestedResultEventArg2.ResultCreateType == nestedCreateType.SaveFile) & !chk_docam.Checked)
		{
			if (buString.MessageBoxQuestion(buNesting.LangNestingMessage[14]) == DialogResult.No)
			{
				return;
			}
			buNestedResultEventArg2.DoCam = true;
			chk_docam.Checked = true;
		}
		viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), drawBackground: true);
		buNestedResultEventArg2.ImageResult = Clipboard.GetImage();
		buNestedResultEventArg2.ImageWidth = viewport.Width;
		buNestedResultEventArg2.ImageHeight = viewport.Height;
		if ((int_1 >= 0) & (int_1 <= buNestingCalc.NestedAllResults.Count - 1))
		{
			buNestedResultEventArg2.SelectedResult = int_1;
			buNestedResultEventArg2.nestedResult = new buNestedResult(buNestingCalc.NestedAllResults[int_1]);
		}
		if (int_0 >= 0)
		{
			buNestedResultEventArg2.SelectedSheet = int_0;
			buNestedResultEventArg2.nestedSheet = new buNestedSheet(buNestingCalc.NestedAllResults[int_1].NestedResultSheets[int_0]);
		}
		buNestedResultEventArg2.SelectedSheet = int_0;
		RunParameter.nestedResultCreateType = buNestedResultEventArg2.ResultCreateType;
		RunParameter.nestedResultSheetType = buNestedResultEventArg2.ResultSheetType;
		RunParameter.NestingResultDoCam = chk_docam.Checked;
		RunParameter.NestingResultPdfFile = chk_pdf.Checked;
		RunParameter.NestingResultCsv = chk_csv.Checked;
		creatbuNestedResultEventHandler_0(buNestedResultEventArg2);
		base.Visible = false;
	}

	internal void method_6(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == button_0.Name)
		{
			panel_4.Visible = true;
		}
		if (control.Name == button_8.Name)
		{
			panel_4.Visible = false;
		}
		if (control.Name == button_9.Name)
		{
			NestParameters.ResultSettings.DrawAddToEnd = chk_addentitiestoend.Checked;
			NestParameters.ResultSettings.DrawAddClearAll = chk_clearalldrawing.Checked;
			NestParameters.ResultSettings.DrawAddToEndOffset = (double)numericUpDown_0.Value;
			panel_4.Visible = false;
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == button_3.Name)
		{
			viewport.SetView(viewType.Isometric);
			viewport.Invalidate();
		}
		if (control.Name == button_4.Name)
		{
			viewport.SetView(viewType.Top);
			viewport.Invalidate();
		}
		if (control.Name == button_5.Name)
		{
			viewport.ZoomFit(1);
			viewport.Invalidate();
		}
		if (control.Name == button_6.Name)
		{
			if (viewport.ActionMode == actionType.Pan)
			{
				viewport.ActionMode = actionType.None;
			}
			else
			{
				viewport.ActionMode = actionType.Pan;
			}
			viewport.Invalidate();
		}
		if (control.Name == button_7.Name)
		{
			if (viewport.ActionMode == actionType.Rotate)
			{
				viewport.ActionMode = actionType.None;
			}
			else
			{
				viewport.ActionMode = actionType.Rotate;
			}
			viewport.Invalidate();
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		base.Visible = false;
	}

	internal void method_9(object sender, EventArgs e)
	{
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem = (ToolStripMenuItem)sender;
		if (toolStripMenuItem.Name == toolStripMenuItem_0.Name && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[12]) == DialogResult.Yes && ((int_1 >= 0) & (int_1 <= buNestingCalc.NestedAllResults.Count - 1)))
		{
			buNestingCalc.NestedAllResults.RemoveAt(int_1);
			Init();
			if (tree_nest.Nodes.Count <= 0)
			{
				viewport.Entities.Clear();
				viewport.Invalidate();
			}
			else
			{
				tree_nest.SelectedNode = tree_nest.Nodes[0];
			}
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_1.Name && buString5.MessageBoxQuestion(buNesting.LangNestingMessage[13]) == DialogResult.Yes)
		{
			buNestingCalc.NestedAllResults.Clear();
			Init();
			viewport.Entities.Clear();
			viewport.Invalidate();
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_2.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = RunParameter.pathNesting;
			openFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				RunParameter.pathNesting = buFile5.GetPath(openFileDialog.FileName);
				buFile5.bunesting bunesting = new buFile5.bunesting();
				buNestedResult Result = new buNestedResult();
				List<buNestingPart> Parts = new List<buNestingPart>();
				List<buNestingSheet> Sheets = new List<buNestingSheet>();
				buNestingVar Parameters = new buNestingVar();
				bunesting.OpenNesting(openFileDialog.FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
				if (okCommandWithDataEventHandler_1 != null)
				{
					okCommandWithDataEventHandler_1(RunParameter);
					buNestingCalc.NestedAllResults.Add(Result);
					NestingUpdate(ref tree_nest, buNestingCalc.NestedAllResults);
				}
			}
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_3.Name && ((int_1 >= 0) & (int_1 <= buNestingCalc.NestedAllResults.Count - 1)))
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = RunParameter.pathNesting;
			saveFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				RunParameter.pathNesting = buFile5.GetPath(saveFileDialog.FileName);
				buFile5.bunesting bunesting2 = new buFile5.bunesting();
				bunesting2.SaveNesting(saveFileDialog.FileName, buNestingCalc.NestedAllResults[int_1].NestingPartsList, buNestingCalc.NestedAllResults[int_1].NestingSheetList, buNestingCalc.NestedAllResults[int_1], NestParameters);
				if (okCommandWithDataEventHandler_1 != null)
				{
					okCommandWithDataEventHandler_1(RunParameter);
				}
			}
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_5.Name && clickSenderDataEventHandler_0 != null)
		{
			clickSenderDataEventHandler_0("", "ShowSheetPart");
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_4.Name && clickSenderDataEventHandler_0 != null)
		{
			clickSenderDataEventHandler_0("", "ShowFolder");
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_6.Name && clickSenderDataEventHandler_0 != null && ((int_1 >= 0) & (int_1 <= buNestingCalc.NestedAllResults.Count - 1)))
		{
			clickSenderDataEventHandler_0(buNestingCalc.NestedAllResults[int_1].NestingPartsList, "SendParts");
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_7.Name && clickSenderDataEventHandler_0 != null && ((int_1 >= 0) & (int_1 <= buNestingCalc.NestedAllResults.Count - 1)))
		{
			clickSenderDataEventHandler_0(buNestingCalc.NestedAllResults[int_1].NestingSheetList, "SendSheets");
		}
		if (toolStripMenuItem.Name == toolStripMenuItem_9.Name && clickSenderDataEventHandler_0 != null && ((int_1 >= 0) & (int_1 <= buNestingCalc.NestedAllResults.Count - 1)))
		{
			clickSenderDataEventHandler_0(buNestingCalc.NestedAllResults[int_1].NestedResultSheets, "CreateRemnant");
		}
		if (!(toolStripMenuItem.Name == toolStripMenuItem_8.Name) || treeNode_0 == null)
		{
			return;
		}
		if (treeNode_0.Parent != null)
		{
			tree_nest.SelectedNode = treeNode_0.Parent;
			method_9(toolStripMenuItem_8, null);
			return;
		}
		int num = Convert.ToInt32(treeNode_0.Tag.ToString());
		if (!((num >= 0) & (num <= buNestingCalc.NestedAllResults.Count - 1)))
		{
			return;
		}
		_ = buNestingCalc.NestedAllResults[num].JobName;
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.SelectedPath = pathSaveImage;
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			pathSaveImage = folderBrowserDialog.SelectedPath;
			for (int i = 0; i <= tree_nest.Nodes[num].Nodes.Count - 1; i++)
			{
				tree_nest.SelectedNode = tree_nest.Nodes[num].Nodes[i];
				tree_nest.Refresh();
				Application.DoEvents();
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
