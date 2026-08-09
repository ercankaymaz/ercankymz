using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using devDept.Eyeshot.Control;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_ToolListDetail : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<ToolBase5> Tools = new List<ToolBase5>();

	public ToolBase5 SelectedTool = new ToolBase5();

	public Design Viewport = null;

	public int SelectedIndex = 0;

	public bool ShowCommand = true;

	public Timer timInit = new Timer();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_add;

	public Button btn_remove;

	public Button btn_edit;

	public Button btn_toolsort;

	public Button btn_tooldown;

	public Button btn_toolup;

	internal ImageList imageList_1;

	public TreeView tree_tools;

	public Panel pnl_viewport;

	public TextBox txt_detail;

	public Button btn_toolsave;

	public Button btn_toolsopen;

	internal Panel panel_0;

	internal Panel panel_1;

	public F_ToolListDetail()
	{
		Class5.smethod_27(this);
		timInit.Interval = 10;
		timInit.Tick += timInit_Tick;
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
		if (ShowCommand)
		{
			panel_0.Visible = true;
			panel_1.Left = panel_0.Left + panel_0.Width + 1;
			panel_1.Width = base.Width - panel_0.Width - pnl_viewport.Width - 4;
		}
		else
		{
			panel_0.Visible = false;
			panel_1.Left = panel_0.Left;
			panel_1.Width = base.Width - pnl_viewport.Width - 20;
		}
		Class5.smethod_129(this);
		if ((SelectedIndex >= 0) & (SelectedIndex <= tree_tools.Nodes.Count - 1))
		{
			tree_tools.SelectedNode = tree_tools.Nodes[SelectedIndex];
			tree_tools.Focus();
		}
		timInit.Enabled = true;
		PropertiesForm.Inited = true;
	}

	private void timInit_Tick(object sender, EventArgs e)
	{
		if ((SelectedIndex >= 0) & (SelectedIndex <= tree_tools.Nodes.Count - 1))
		{
			tree_tools.SelectedNode = tree_tools.Nodes[SelectedIndex];
			tree_tools.Focus();
		}
		timInit.Enabled = false;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			btn_ok.Focus();
			Class5.smethod_114(this);
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
		{
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
		if (control.Name == btn_toolup.Name)
		{
			clsInit.appCommand.cmdToolMoveUp();
		}
		if (control.Name == btn_tooldown.Name)
		{
			clsInit.appCommand.cmdToolMoveDown();
		}
		if (control.Name == btn_toolsort.Name)
		{
			clsInit.appCommand.cmdToolSort();
		}
		if (control.Name == btn_toolsopen.Name)
		{
			clsInit.appFiles.OpenToolFile(ref ccVars.Tools);
			clsInit.appCommand.ToolUpdate(FillTool: true, ccVars.ToolGroupIndex, ccVars.ToolIndex, ref tree_tools);
		}
		if (control.Name == btn_toolsave.Name)
		{
			clsInit.appFiles.SaveToolFile(ccVars.Tools);
		}
		if (control.Name == btn_edit.Name)
		{
			ToolBase5 tool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[ccVars.ToolIndex]);
			F_Tool f_Tool = new F_Tool();
			CreateModelProperties createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
			createModelProperties.ViewCubeIconVisible = false;
			createModelProperties.OrigineCaptionVisible = false;
			createModelProperties.ToolBorVisible = false;
			clsInit.cVector5.CreateModelControl(ref f_Tool.viewportLayout, clsVar.UnlockKey, createModelProperties);
			f_Tool.viewportLayout.Entities.Clear();
			f_Tool.Properties.FormCloseMode = FormCloseModeType.Invisible;
			f_Tool.Tool = new ToolBase5(tool);
			f_Tool.Init();
			f_Tool.StartPosition = FormStartPosition.CenterParent;
			f_Tool.ShowDialog();
			if (f_Tool.Properties.Result == DialogResult.OK)
			{
				ccVars.Tools[ccVars.ToolGroupIndex].Tools[ccVars.ToolIndex] = new ToolBase5(f_Tool.Tool);
				clsInit.appCommand.ToolUpdate(FillTool: false, ccVars.ToolGroupIndex, ccVars.ToolIndex, ref tree_tools);
				clsInit.appCommand.DrawTool(f_Tool.Tool, clsVar.varDisplay.ToolPreviewDrawArbor, clsVar.varDisplay.ToolPreviewDrawHolder, ref clsItem.FrmToolList.Viewport);
				clsItem.FrmToolList.txt_detail.Text = clsInit.appCommand.ToolInfo(f_Tool.Tool, clsVar.varProgram.ToolPanelSettings);
				clsVar.varInterface.pathTool = AppPath.Tool;
				clsVar.varInterface.pathToolHolder = AppPath.ToolHolder;
				clsFiles.SaveParameter();
			}
		}
		if (control.Name == btn_add.Name)
		{
			ToolBase5 tool2 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[ccVars.ToolIndex]);
			F_Tool f_Tool2 = new F_Tool();
			CreateModelProperties createModelProperties2 = new CreateModelProperties();
			createModelProperties2.CoordinateSystemIconVisible = false;
			createModelProperties2.ViewCubeIconVisible = false;
			createModelProperties2.OrigineCaptionVisible = false;
			createModelProperties2.ToolBorVisible = false;
			clsInit.cVector5.CreateModelControl(ref f_Tool2.viewportLayout, clsVar.UnlockKey, createModelProperties2);
			f_Tool2.viewportLayout.Entities.Clear();
			f_Tool2.Properties.FormCloseMode = FormCloseModeType.Invisible;
			f_Tool2.Tool = new ToolBase5(tool2);
			f_Tool2.Init();
			f_Tool2.StartPosition = FormStartPosition.CenterParent;
			f_Tool2.ShowDialog();
			if (f_Tool2.Properties.Result == DialogResult.OK)
			{
				ccVars.Tools[ccVars.ToolGroupIndex].Tools.Add(new ToolBase5(f_Tool2.Tool));
				clsInit.appCommand.ToolUpdate(FillTool: true, 0, ccVars.ToolIndex, ref tree_tools);
				clsVar.varInterface.pathTool = AppPath.Tool;
				clsVar.varInterface.pathToolHolder = AppPath.ToolHolder;
				clsFiles.SaveParameter();
			}
		}
		if (control.Name == btn_remove.Name && SelectedIndex >= 0 && buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[10]) == DialogResult.Yes)
		{
			ccVars.Tools[ccVars.ToolGroupIndex].Tools.RemoveAt(SelectedIndex);
			clsInit.appCommand.ToolUpdate(FillTool: true, 0, ccVars.ToolIndex, ref tree_tools);
			clsFiles.SaveParameter();
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		method_0(btn_edit, e);
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
