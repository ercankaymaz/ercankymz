using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_BendingRotaryDisk : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public int SelectedIndex = -1;

	public int DiskIndex = -1;

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_importsolid;

	public TreeView tree_jobs;

	public buSpin buSpin2;

	public buSpin buSpin1;

	public buSpin buSpin4;

	public buSpin buSpin3;

	internal buGroup buGroup_0;

	public buSpin buSpin5;

	public buSpin buSpin7;

	public buSpin buSpin9;

	internal buGroup buGroup_1;

	internal buGround buGround_1;

	public buSpin spn_pipediameter;

	internal buGroup buGroup_2;

	public buSpin spn_blockwidth;

	public buSpin spn_blcokheight;

	public buSpin spn_blockdepth;

	internal buGroup buGroup_3;

	public buSpin spn_diskdiameter;

	public buSpin spn_diskblockwidth;

	public buSpin spn_diskHeight;

	public buSpin spn_diskblocklength;

	public buSpin spn_diskthickness;

	public TreeView treeView_bend;

	public buButton btn_open;

	public buButton btn_cancel;

	public buButton btn_ok;

	public buButton btnn_remove;

	public buButton btn_add;

	public buButton btn_save;

	public Panel pnl_viewport;

	internal ImageList imageList_0;

	public F_BendingRotaryDisk()
	{
		Class186.smethod_72(this);
		timer_0.Tick += Tick_Timer;
		timer_0.Interval = 10;
	}

	public void Init()
	{
		string text = "Init";
		try
		{
			PropertiesForm.Inited = false;
			PropertiesForm.sClassName = "F_BendingRotaryDisk";
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
			if (buEyeItems.viewportDialogs == null)
			{
				CreateModelProperties createModelProperties = new CreateModelProperties();
				createModelProperties.DisplayType = displayType.Rendered;
				createModelProperties.ProjetionType = projectionType.Orthographic;
				createModelProperties.CoordinateSystemIconVisible = false;
				createModelProperties.OriginSymbolVisible = false;
				createModelProperties.ViewCubeIconVisible = false;
				createModelProperties.OrigineCaptionVisible = false;
				createModelProperties.ToolBorVisible = false;
				createModelProperties.BottomColor = Color.LightGray;
				createModelProperties.MiddleColor = Color.WhiteSmoke;
				createModelProperties.TopColor = Color.LightGray;
				createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
				createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
				createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
				buEyeItems.viewportDialogs = buCall.buVector5_0.CreateModelControl(createModelProperties);
				buEyeItems.viewportDialogs.ActiveViewport.DisplayMode = displayType.Rendered;
			}
			buEyeItems.viewportDialogs.ActiveViewport.CoordinateSystemIcon.Visible = true;
			buEyeItems.viewportDialogs.ActiveViewport.OriginSymbol.Visible = true;
			if (buPipeBendCalc.DiskBlocks.Count > 0)
			{
				SelectedIndex = 0;
			}
			treeView_bend = buCall.buPipeBendCalc_0.UpdateItems(treeView_bend);
			treeView_bend.CheckBoxes = false;
			treeView_bend.ExpandAll();
			ControlUpdate();
			LoadLanguage();
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
			if (buPipeBendCalc.DiskBlocks.Count > 0)
			{
				timer_0.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(PropertiesForm.sClassName, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: true, PropertiesForm.sClassName);
		}
	}

	public void LoadLanguage()
	{
		string text = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(PropertiesForm.sClassName, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: true, PropertiesForm.sClassName);
		}
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

	public void Tick_Timer(object sender, EventArgs e)
	{
		string text = "Tick_Timer";
		try
		{
			if (buEyeItems.viewportDialogs.IsHandleCreated)
			{
				timer_0.Enabled = false;
				if ((SelectedIndex >= 0) & (SelectedIndex <= buPipeBendCalc.DiskBlocks.Count - 1))
				{
					ItemToControls(buPipeBendCalc.DiskBlocks[SelectedIndex]);
					DrawDiskBlock(0, -1);
				}
				buEyeItems.viewportDialogs.SetView(viewType.Trimetric);
				buEyeItems.viewportDialogs.ZoomFit(5);
				buEyeItems.viewportDialogs.Invalidate();
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(PropertiesForm.sClassName, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: false, PropertiesForm.sClassName);
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
	}

	public void ItemToControls(PipeBendDiskBlocks DiskData)
	{
		PropertiesForm.Inited = false;
		spn_blockdepth.Value = DiskData.BlockDepth;
		spn_blcokheight.Value = DiskData.BlockHeight;
		spn_blockwidth.Value = DiskData.BlockWidth;
		spn_diskblocklength.Value = DiskData.DiskBlockLength;
		spn_diskblockwidth.Value = DiskData.DiskBlockWidth;
		spn_diskdiameter.Value = DiskData.DiskDiameter;
		spn_diskHeight.Value = DiskData.DiskHeight;
		spn_diskthickness.Value = DiskData.DiskThickness;
		spn_pipediameter.Value = DiskData.BlockPipeDiameter;
		PropertiesForm.Inited = true;
	}

	public void ControlsToItem()
	{
		if ((SelectedIndex >= 0) & (SelectedIndex <= buPipeBendCalc.DiskBlocks.Count - 1))
		{
			PipeBendDiskBlocks pipeBendDiskBlocks = buPipeBendCalc.DiskBlocks[SelectedIndex];
			pipeBendDiskBlocks.BlockDepth = spn_blockdepth.Value;
			pipeBendDiskBlocks.BlockHeight = spn_blcokheight.Value;
			pipeBendDiskBlocks.BlockWidth = spn_blockwidth.Value;
			pipeBendDiskBlocks.DiskBlockLength = spn_diskblocklength.Value;
			pipeBendDiskBlocks.DiskBlockWidth = spn_diskblockwidth.Value;
			pipeBendDiskBlocks.DiskDiameter = spn_diskdiameter.Value;
			pipeBendDiskBlocks.DiskHeight = spn_diskHeight.Value;
			pipeBendDiskBlocks.DiskThickness = spn_diskthickness.Value;
			pipeBendDiskBlocks.BlockPipeDiameter = spn_pipediameter.Value;
		}
	}

	public void DrawDiskBlock(int Index, int DiskIndex)
	{
		buEyeItems.viewportDialogs.Entities.Clear();
		if (!((Index >= 0) & (Index <= buPipeBendCalc.DiskBlocks.Count - 1)))
		{
			for (int i = 0; i <= buPipeBendCalc.DiskBlocks.Count - 1; i++)
			{
				Entity entDisk = null;
				Entity entBlock = null;
				buCall.buPipeBendCalc_0.CreateDiskBlocks(buPipeBendCalc.DiskBlocks[i], ref entDisk, ref entBlock);
				bool flag = true;
				bool flag2 = true;
				if (DiskIndex == 0)
				{
					flag2 = false;
				}
				if (DiskIndex == 1)
				{
					flag = false;
				}
				if (entDisk != null && flag)
				{
					entDisk.Rotate(Utility.DegToRad(-90.0), Vector3D.AxisZ, Point3D.Origin);
					entDisk.Translate(0.0, 0.0, (double)i * buPipeBendCalc.DiskBlocks[i].DiskHeight);
					buEyeItems.viewportDialogs.Entities.Add(entDisk);
				}
				if (entBlock != null && flag2)
				{
					entBlock.Translate(0.0 - buPipeBendCalc.DiskBlocks[i].BlockWidth, buPipeBendCalc.DiskBlocks[i].BlockDepth, (double)i * buPipeBendCalc.DiskBlocks[i].DiskHeight);
					buEyeItems.viewportDialogs.Entities.Add(entBlock);
				}
			}
		}
		else
		{
			Entity entDisk2 = null;
			Entity entBlock2 = null;
			buCall.buPipeBendCalc_0.CreateDiskBlocks(buPipeBendCalc.DiskBlocks[Index], ref entDisk2, ref entBlock2);
			bool flag3 = true;
			bool flag4 = true;
			if (DiskIndex == 0)
			{
				flag4 = false;
			}
			if (DiskIndex == 1)
			{
				flag3 = false;
			}
			if (entDisk2 != null && flag3)
			{
				entDisk2.Rotate(Utility.DegToRad(-90.0), Vector3D.AxisZ, Point3D.Origin);
				buEyeItems.viewportDialogs.Entities.Add(entDisk2);
			}
			if (entBlock2 != null && flag4)
			{
				entBlock2.Translate(0.0 - buPipeBendCalc.DiskBlocks[Index].BlockWidth + buPipeBendCalc.DiskBlocks[Index].DiskDiameter / 2.0, buPipeBendCalc.DiskBlocks[Index].BlockDepth);
				buEyeItems.viewportDialogs.Entities.Add(entBlock2);
			}
		}
		buEyeItems.viewportDialogs.Invalidate();
	}

	internal void method_1(object sender, EventArgs e)
	{
		string text = "btn_Click";
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
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
			if (control.Name == btn_add.Name && ((SelectedIndex >= 0) & (SelectedIndex <= buPipeBendCalc.DiskBlocks.Count - 1)))
			{
				PipeBendDiskBlocks item = new PipeBendDiskBlocks(buPipeBendCalc.DiskBlocks[SelectedIndex]);
				buPipeBendCalc.DiskBlocks.Add(item);
				treeView_bend = buCall.buPipeBendCalc_0.UpdateItems(treeView_bend);
			}
			if (control.Name == btnn_remove.Name && ((SelectedIndex >= 0) & (SelectedIndex <= buPipeBendCalc.DiskBlocks.Count - 1)) && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
			{
				buPipeBendCalc.DiskBlocks.RemoveAt(SelectedIndex);
				if (SelectedIndex > 0)
				{
					SelectedIndex--;
				}
				if (buPipeBendCalc.DiskBlocks.Count == 0)
				{
					SelectedIndex = -1;
					DiskIndex = -1;
				}
				treeView_bend = buCall.buPipeBendCalc_0.UpdateItems(treeView_bend);
			}
			if (!(control.Name == btn_save.Name))
			{
			}
			if (!(control.Name == btn_open.Name))
			{
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(PropertiesForm.sClassName, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: false, PropertiesForm.sClassName);
		}
	}

	internal void method_2(object sender, KeyEventArgs e)
	{
		string text = "spn_ValueChanged";
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (PropertiesForm.Inited && ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab)))
			{
				int result = 0;
				int.TryParse(control.Tag.ToString(), out result);
			}
		}
		catch (Exception ex)
		{
			PropertiesForm.Inited = true;
			buLogVer5.addToLog(PropertiesForm.sClassName, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: false, PropertiesForm.sClassName);
		}
	}

	internal void method_3(object object_0, double double_0)
	{
		string text = "spn_ValueChanged";
		try
		{
			if (PropertiesForm.Inited)
			{
				ControlsToItem();
				DrawDiskBlock(SelectedIndex, DiskIndex);
			}
		}
		catch (Exception ex)
		{
			PropertiesForm.Inited = true;
			buLogVer5.addToLog(PropertiesForm.sClassName, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: false, PropertiesForm.sClassName);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		string text = "spn_Click";
		try
		{
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(PropertiesForm.sClassName, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: false, PropertiesForm.sClassName);
		}
	}

	internal void method_5(object sender, TreeViewEventArgs e)
	{
		buTreeNode buTreeNode2 = (buTreeNode)treeView_bend.SelectedNode;
		switch (buTreeNode2.Command)
		{
		case "bendbase":
			SelectedIndex = -1;
			DiskIndex = -1;
			DrawDiskBlock(SelectedIndex, DiskIndex);
			break;
		case "benddisk":
			SelectedIndex = buTreeNode2.ClassSubIndex;
			DiskIndex = buTreeNode2.ClassSubSubIndex;
			ItemToControls(buPipeBendCalc.DiskBlocks[SelectedIndex]);
			DrawDiskBlock(SelectedIndex, DiskIndex);
			break;
		case "disk":
			SelectedIndex = buTreeNode2.ClassSubIndex;
			DiskIndex = buTreeNode2.ClassSubSubIndex;
			ItemToControls(buPipeBendCalc.DiskBlocks[SelectedIndex]);
			DrawDiskBlock(SelectedIndex, DiskIndex);
			break;
		case "block":
			SelectedIndex = buTreeNode2.ClassSubIndex;
			DiskIndex = buTreeNode2.ClassSubSubIndex;
			ItemToControls(buPipeBendCalc.DiskBlocks[SelectedIndex]);
			DrawDiskBlock(SelectedIndex, DiskIndex);
			break;
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
