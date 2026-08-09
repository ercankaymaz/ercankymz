using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Toolkit;
using buCadCamResVer5.Sewing;
using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Drawings;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Variables;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Editor;

public class F_Editor : KryptonForm
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<string> OpenFileExtension = new List<string>();

	public List<Entity> entitiesExisting = new List<Entity>();

	public List<string> InitCommands = new List<string>();

	public List<string> OpenCommands = new List<string>();

	public string fileNameSorted = "";

	public string fileName = "";

	public bool isMovedFirstTime = false;

	public bool SortingDone = false;

	public Sketcher2D viewport = null;

	public Image refImage = null;

	public SizeObject refImageSize = new SizeObject();

	private Color color_0 = Color.DarkOrange;

	private Color color_1 = Color.Blue;

	private Color color_2 = Color.Black;

	private Timer timer_0 = new Timer();

	private int int_0 = 0;

	public int ZoomOutValue = 0;

	private ToolTip toolTip_0 = new ToolTip();

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal ImageList imageList_0;

	internal Panel panel_1;

	public CheckBox chk_showcontrraint;

	public TreeView tree_objects;

	public CheckBox chk_showdims;

	internal ImageList imageList_1;

	internal Button button_0;

	internal ImageList imageList_2;

	internal Button button_1;

	public ListBox lst_command;

	internal Panel panel_2;

	internal System.Windows.Forms.Label label_0;

	internal Button button_2;

	internal ComboBox comboBox_0;

	internal Button button_3;

	internal System.Windows.Forms.Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_3;

	public System.Windows.Forms.Label status_message;

	internal PictureBox pictureBox_0;

	public System.Windows.Forms.Label lbl_y;

	public System.Windows.Forms.Label lbl_value;

	public NumericUpDown spn_value;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	public TreeView tree_sewing;

	internal ImageList imageList_3;

	internal KryptonRibbon kryptonRibbon_0;

	internal KryptonRibbonTab kryptonRibbonTab_0;

	internal KryptonRibbonGroup kryptonRibbonGroup_0;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_0;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_0;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_1;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_2;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_1;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_3;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_4;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_5;

	internal KryptonRibbonGroup kryptonRibbonGroup_1;

	internal KryptonManager kryptonManager_0;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_0;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_2;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_6;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_7;

	internal KryptonRibbonTab kryptonRibbonTab_1;

	internal KryptonRibbonGroup kryptonRibbonGroup_2;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_3;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_8;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_9;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_10;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_4;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_11;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_12;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_13;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_5;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_14;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_15;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_16;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_6;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_17;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_18;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_19;

	internal KryptonRibbonGroup kryptonRibbonGroup_3;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_7;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_20;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_21;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_22;

	public KryptonRibbonGroupButton mnu_editshowpoint;

	internal KryptonRibbonRecentDoc kryptonRibbonRecentDoc_0;

	internal KryptonRibbonRecentDoc kryptonRibbonRecentDoc_1;

	internal ButtonSpecAppMenu buttonSpecAppMenu_0;

	internal ButtonSpecAppMenu buttonSpecAppMenu_1;

	internal KryptonRibbonTab kryptonRibbonTab_2;

	internal KryptonRibbonGroup kryptonRibbonGroup_4;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_8;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_23;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_24;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_25;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_9;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_26;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_27;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_28;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_10;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_29;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_30;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_31;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_11;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_32;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_33;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_34;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_12;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_35;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_36;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_37;

	internal KryptonRibbonTab kryptonRibbonTab_3;

	internal KryptonRibbonGroup kryptonRibbonGroup_5;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_13;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_38;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_39;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_40;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_0;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_41;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_42;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_14;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_43;

	public KryptonRibbonGroupButton mnu_libfillet;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_44;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_15;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_45;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_46;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_47;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_16;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_48;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_49;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_50;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_17;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_51;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_52;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_53;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_18;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_54;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_55;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_56;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_19;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_57;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_58;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_59;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_20;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_60;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_61;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_62;

	internal KryptonRibbonTab kryptonRibbonTab_4;

	internal KryptonRibbonGroup kryptonRibbonGroup_6;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_1;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_63;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_64;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_21;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_65;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_66;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_67;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_22;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_23;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_68;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_69;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_70;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_24;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_71;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_72;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_25;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_73;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_74;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_75;

	internal KryptonRibbonGroup kryptonRibbonGroup_7;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_2;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_76;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_77;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_3;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_78;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_79;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_26;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_80;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_81;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_82;

	public System.Windows.Forms.Label lbl_x;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_1;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_2;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_3;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_27;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_83;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_84;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_85;

	internal KryptonRibbonQATButton kryptonRibbonQATButton_0;

	internal KryptonRibbonQATButton kryptonRibbonQATButton_1;

	internal KryptonRibbonContext kryptonRibbonContext_0;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_28;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_86;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_87;

	internal KryptonRibbonTab kryptonRibbonTab_5;

	internal KryptonRibbonGroup kryptonRibbonGroup_8;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_29;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_88;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_89;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_90;

	internal KryptonRibbonGroup kryptonRibbonGroup_9;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_30;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_91;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_92;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_93;

	internal KryptonSeparator kryptonSeparator_0;

	internal KryptonSeparator kryptonSeparator_1;

	internal KryptonCheckButton kryptonCheckButton_0;

	internal KryptonCheckButton kryptonCheckButton_1;

	internal KryptonCheckButton kryptonCheckButton_2;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_4;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_94;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_95;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_5;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_96;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_97;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_4;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_6;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_98;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_99;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_5;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_7;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_100;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_101;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_31;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_102;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_103;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_104;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_6;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_32;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_105;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_106;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_107;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	internal ToolStripMenuItem toolStripMenuItem_1;

	internal ToolStripMenuItem toolStripMenuItem_2;

	internal ContextMenuStrip contextMenuStrip_1;

	internal ToolStripMenuItem toolStripMenuItem_3;

	internal ToolStripMenuItem toolStripMenuItem_4;

	internal KryptonRibbonQATButton kryptonRibbonQATButton_2;

	internal KryptonRibbonGroup kryptonRibbonGroup_10;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_33;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_108;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_109;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_110;

	internal KryptonRibbonGroup kryptonRibbonGroup_11;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_34;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_111;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_112;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_113;

	public CheckBox chk_check;

	internal KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator_7;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_35;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_114;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_115;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_116;

	internal TabPage tabPage_2;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal System.Windows.Forms.Label label_2;

	internal Panel panel_4;

	internal System.Windows.Forms.Label label_3;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	public Panel pnl_foamsort;

	internal KryptonRibbonGroup kryptonRibbonGroup_12;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_36;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_117;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_118;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_119;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_37;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_120;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_121;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_122;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_38;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_123;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_124;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_125;

	internal RadioButton radioButton_7;

	internal ContextMenuStrip contextMenuStrip_2;

	internal ToolStripMenuItem toolStripMenuItem_5;

	internal KryptonRibbonGroupLines kryptonRibbonGroupLines_8;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_126;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_127;

	internal KryptonRibbonGroupTriple kryptonRibbonGroupTriple_39;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_128;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_129;

	internal KryptonRibbonGroupButton kryptonRibbonGroupButton_130;

	public KryptonRibbonGroupButton mnu_sewingrotate;

	public KryptonRibbonGroupButton mnu_sewingscale;

	public KryptonRibbonGroupButton mnu_sewingoffset;

	public KryptonRibbonGroupButton mnu_sewingfootheight;

	public KryptonRibbonGroupButton mnu_sewingstitchtable;

	public F_Editor()
	{
		Class5.smethod_216(this);
		toolStripMenuItem_0.Image = imageList_2.Images[3];
		toolStripMenuItem_1.Image = imageList_2.Images[4];
		toolStripMenuItem_2.Image = imageList_2.Images[5];
		toolStripMenuItem_3.Image = imageList_2.Images[7];
		toolStripMenuItem_4.Image = imageList_2.Images[8];
		spn_value.ValueChanged += clsInit.appEditor.Spn_ValueChanged;
		chk_check.CheckedChanged += clsInit.appEditor.Chk_CheckedChenged;
		timer_0.Interval = 500;
		timer_0.Tick += timer_0_Tick;
	}

	internal void method_0(object sender, EventArgs e)
	{
		tree_objects.AfterSelect += clsInit.appEditor.JobTree_AfterSelect;
		if (clsInit.appSewing != null)
		{
			tree_sewing.AfterSelect += clsInit.appSewing.JobTree_AfterSelect;
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		if (!(timer_0.Enabled | (int_0 == 0)))
		{
			if (PropertiesForm.Result == DialogResult.OK)
			{
				return;
			}
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				if (viewport.CurrentSketch == null || !viewport.CurrentSketch.Editing)
				{
				}
				base.Visible = false;
			}
		}
		else
		{
			e.Cancel = true;
		}
	}

	public void Init()
	{
		Sketcher2D.FirstMove = false;
		Sketcher2D.DrawingPoints.Clear();
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
		LoadLanguage();
		clsInit.appEditor.ClearSortThings();
		clsInit.appEditor.sortedEntities.Clear();
		kryptonRibbonTab_4.Visible = clsVar.varEditorRuntimeSet.isSewingMode;
		kryptonRibbonTab_3.Visible = clsVar.varEditorRuntimeSet.isSketchMode;
		kryptonRibbonTab_5.Visible = clsVar.varEditorRuntimeSet.isFoamMode;
		for (int num = tabControl_0.TabPages.Count - 1; num >= 0; num--)
		{
			Control control = tabControl_0.TabPages[num];
			if ((control.Name == tabPage_1.Name) & !clsVar.varEditorRuntimeSet.isSewingMode)
			{
				tabControl_0.TabPages.RemoveAt(num);
			}
			if ((control.Name == tabPage_0.Name) & !clsVar.varEditorRuntimeSet.isSketchMode)
			{
				tabControl_0.TabPages.RemoveAt(num);
			}
			if ((control.Name == tabPage_2.Name) & !clsVar.varEditorRuntimeSet.isFoamMode)
			{
				tabControl_0.TabPages.RemoveAt(num);
			}
		}
		if (tabControl_0.TabPages.Count == 0)
		{
			tabControl_0.Visible = false;
			panel_0.Left = 2;
			panel_0.Width = base.Width - 25;
			kryptonRibbon_0.SelectedTab = kryptonRibbonTab_1;
		}
		if (clsVar.varEditorRuntimeSet.isSketchMode)
		{
			kryptonRibbon_0.SelectedTab = kryptonRibbonTab_3;
			clsVar.varEditorSet.ShowBoxSize = false;
		}
		if (clsVar.varEditorRuntimeSet.isSewingMode)
		{
			kryptonRibbon_0.SelectedTab = kryptonRibbonTab_4;
		}
		if (clsVar.varEditorRuntimeSet.isFoamMode)
		{
			kryptonRibbon_0.SelectedTab = kryptonRibbonTab_5;
		}
		if (viewport == null)
		{
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.BottomColor = Color.WhiteSmoke;
			Properties.TopColor = Color.Gainsboro;
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = true;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			Properties.OriginSymbolVisible = true;
			Properties.OrigineSize = 5;
			Properties.GridVisible = true;
			clsInit.appEditor.CreateModelControl(ref viewport, clsVar.UnlockKey, Properties);
			clsInit.appEditor.GridUpdate();
			viewport.MouseDoubleClick += Viewport_MouseDoubleClick;
			viewport.WorkCompleted += clsInit.appEditor.Desing_WorkCompleted;
			panel_0.Controls.Add(viewport);
			Entity entity = CompositeCurve.CreateRectangle(100.0, 100.0);
			entity.Selected = true;
			viewport.Entities.Add(entity);
			viewport.ZoomFit(selectedOnly: true);
			viewport.Invalidate();
		}
		viewport.AssemblySelectionMode = Workspace.assemblySelectionType.Branch;
		if (tabControl_0.TabPages.Count > 0)
		{
			panel_0.Width = base.Width - tabControl_0.Width - 25;
		}
		if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.None)
		{
			if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.CCW)
			{
				if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.CW)
				{
					if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.FirstDirectionThenAuto)
					{
						if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.HigherIndex)
						{
							if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.Jump)
							{
								if (clsVar.varEditorSet.SortFirstCatchRule != SortingFirstCatchRulesType.LowerIndex)
								{
									if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.Manuel)
									{
										radioButton_7.Checked = true;
									}
								}
								else
								{
									radioButton_1.Checked = true;
								}
							}
							else
							{
								radioButton_5.Checked = true;
							}
						}
						else
						{
							radioButton_6.Checked = true;
						}
					}
					else
					{
						radioButton_2.Checked = true;
					}
				}
				else
				{
					radioButton_4.Checked = true;
				}
			}
			else
			{
				radioButton_3.Checked = true;
			}
		}
		else
		{
			radioButton_0.Checked = true;
		}
		clsInit.appEditor.action = actionTypeBU.None;
		Sketcher2D.Clicks.Clear();
		viewport.Selection.Color = Color.Red;
		viewport.Selection.LineWeightScaleFactor = 2f;
		chk_showcontrraint.Checked = clsVar.varEditorRuntimeSet.ShowContrraint;
		chk_showdims.Checked = clsVar.varEditorRuntimeSet.ShowDimension;
		kryptonRibbonGroupButton_102.Checked = clsVar.varEditorSet.ShowBoxSize;
		kryptonRibbonGroupButton_103.Checked = clsVar.varEditorSet.ShowPoints;
		kryptonRibbonGroupButton_7.Checked = clsVar.varEditorSet.ShowBoxSize;
		mnu_editshowpoint.Checked = clsVar.varEditorSet.ShowPoints;
		kryptonCheckButton_0.Checked = clsVar.varEditorSet.OsnapEntity;
		kryptonCheckButton_2.Checked = clsVar.varEditorSet.Ortho;
		kryptonCheckButton_1.Checked = clsVar.varEditorSet.OsnapGrid;
		comboBox_0.Items.Add("SecondDrawing");
		comboBox_0.Items.Add("NoCalculationEntity");
		comboBox_0.Items.Add("InvisibleEntity");
		comboBox_0.Items.Add(buLangTranslate.preDef.Depth);
		comboBox_0.SelectedIndex = 0;
		if (clsVar.varEditorRuntimeSet.isSketchMode)
		{
			SketchEntity sketchEntity = new SketchEntity(Plane.XY);
			viewport.Entities.Add(sketchEntity);
			sketchEntity.Edit(viewport);
			viewport.CurrentSketch.ClearHistory();
		}
		viewport.Entities.UpdateBoundingBox();
		viewport.SetView(viewType.Top);
		viewport.Invalidate();
		kryptonRibbonGroupButton_6.Checked = clsVar.varEditorRuntimeSet.GridEnable;
		clsInit.appEditor.JobUpdate();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		timer_0.Enabled = true;
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 10)
			{
			}
		}
		catch (Exception)
		{
		}
	}

	public void RunCommands()
	{
		InitCommands.Clear();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (refImage != null)
		{
			Picture picture = new Picture(Plane.XY, refImageSize.Width, refImageSize.Height, buImage5.ImageToByteArray(refImage));
			picture.Translate(0.0, 0.0, -0.5);
			picture.Selectable = false;
			viewport.Entities.Add(picture);
			viewport.SetView(viewType.Top);
			viewport.ZoomFit(5);
			viewport.Invalidate();
		}
		if (entitiesExisting.Count > 0)
		{
			for (int i = 0; i <= entitiesExisting.Count - 1; i++)
			{
				Entity copiedEntity = null;
				buEntity.Copy(entitiesExisting[i], ref copiedEntity);
				if (copiedEntity != null)
				{
					viewport.Entities.Add(copiedEntity);
				}
			}
			viewport.ZoomFit();
			viewport.Invalidate();
		}
		entitiesExisting.Clear();
		if (clsVar.varEditorRuntimeSet.isSewingMode)
		{
			if (viewport.Layers.Count == 1)
			{
				viewport.Layers.AddOrReplace(new Layer("0", Color.Black));
			}
			clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, viewport.Entities);
			viewport.SetView(viewType.Top);
			viewport.ZoomFit(5);
			viewport.Invalidate();
		}
		if (fileNameSorted.Length > 1)
		{
			FileInfo fileInfo = new FileInfo(fileNameSorted);
			if (fileInfo.Exists)
			{
				Class5.smethod_89(this, fileInfo.FullName);
			}
			fileNameSorted = "";
		}
		if (fileName.Length > 1)
		{
			FileInfo fileInfo2 = new FileInfo(fileName);
			if (fileInfo2.Exists)
			{
				clsInit.appEditor.cmdOpen(fileName);
				viewport.SetView(viewType.Top);
				viewport.ZoomFit(5);
				viewport.Invalidate();
			}
			fileName = "";
		}
		if (InitCommands.Count > 0)
		{
			RunCommands();
		}
		InitCommands.Clear();
		if ((viewport.Entities.Count == 0) & (ZoomOutValue > 0))
		{
			viewport.ZoomOut(ZoomOutValue);
		}
		int_0 = 1;
		timer_0.Enabled = false;
	}

	public void Viewport_MouseMove(object sender, MouseEventArgs e)
	{
		if (!isMovedFirstTime)
		{
			isMovedFirstTime = true;
		}
		if (Sketcher2D.entityMouseUnder == null)
		{
			if (Sketcher2D.indexLabel < 0 || !(viewport.ActiveViewport.Labels[Sketcher2D.indexLabel] is StackedLabel))
			{
				toolTip_0.Active = false;
				toolTip_0.Hide(viewport);
			}
			else
			{
				StackedLabel stackedLabel = (StackedLabel)viewport.ActiveViewport.Labels[Sketcher2D.indexLabel];
				string caption = stackedLabel.GetType().Name.Replace("Label", string.Empty);
				toolTip_0.Active = true;
				toolTip_0.SetToolTip(viewport, caption);
			}
		}
		else
		{
			string name = Sketcher2D.entityMouseUnder.GetType().Name;
			toolTip_0.Active = true;
			toolTip_0.SetToolTip(viewport, name);
		}
		viewport.Invalidate();
		viewport.Refresh();
	}

	public void Viewport_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		SelectedItem itemUnderMouseCursor = viewport.GetItemUnderMouseCursor(e.Location);
		if (itemUnderMouseCursor == null)
		{
			return;
		}
		Entity dimension = itemUnderMouseCursor.Item as Entity;
		if (viewport.CurrentSketch == null)
		{
			return;
		}
		VisualConstraint constraint = viewport.CurrentSketch.GetConstraint(dimension);
		if (!(constraint is ValueVisualConstraint))
		{
			return;
		}
		DialogBoxInput dialogBoxInput = new DialogBoxInput();
		if (!(constraint is AngleVisualConstraint))
		{
			if (!(constraint is LengthVisualConstraint))
			{
				if (!(constraint is DiameterVisualConstraint))
				{
					if (constraint is LinesDistanceVisualConstraint || constraint is PointLineDistanceVisualConstraint || constraint is PointsDistanceVisualConstraint)
					{
						dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[135];
						dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[135];
					}
				}
				else
				{
					dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[19];
					dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[19];
				}
			}
			else
			{
				dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[0];
				dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[0];
			}
			dialogBoxInput.Value = ((ValueVisualConstraint)constraint).Value;
		}
		else
		{
			double value = Utility.RadToDeg(((ValueVisualConstraint)constraint).Value);
			dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[2];
			dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[2];
			dialogBoxInput.Value = Math.Abs(value);
		}
		dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
		dialogBoxInput.Init();
		dialogBoxInput.SelectAll();
		dialogBoxInput.ShowDialog();
		if (dialogBoxInput.Result == DialogResult.OK)
		{
			if (!(constraint is AngleVisualConstraint))
			{
				((ValueVisualConstraint)constraint).Value = dialogBoxInput.Value;
			}
			else
			{
				double value2 = dialogBoxInput.Value;
				value2 = (double)((!(dialogBoxInput.Value <= 0.0)) ? 1 : (-1)) * Math.PI * value2 / 180.0;
				((ValueVisualConstraint)constraint).Value = value2;
			}
		}
		for (int i = 0; i <= viewport.Entities.Count - 1; i++)
		{
			viewport.Entities[i].Selected = false;
		}
		viewport.CurrentSketch.UpdateAndInvalidate();
		viewport.Invalidate();
	}

	public void mnu_cmd_Click(object sender, EventArgs e)
	{
		string text = "";
		if (!(sender is RibbonButton))
		{
			if (!(sender is ToolStripMenuItem))
			{
				if (!(sender is KryptonRibbonGroupButton))
				{
					if (sender is KryptonRibbonQATButton)
					{
						KryptonRibbonQATButton kryptonRibbonQATButton = sender as KryptonRibbonQATButton;
						text = kryptonRibbonQATButton.Tag.ToString();
					}
				}
				else
				{
					KryptonRibbonGroupButton kryptonRibbonGroupButton = sender as KryptonRibbonGroupButton;
					text = kryptonRibbonGroupButton.Tag.ToString();
				}
			}
			else
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			RibbonButton ribbonButton = sender as RibbonButton;
			text = ribbonButton.Name;
		}
		if (text == kryptonRibbonGroupButton_23.Tag.ToString())
		{
			clsInit.appEditor.cmdNew();
		}
		if (text == kryptonRibbonGroupButton_24.Tag.ToString())
		{
			clsInit.appEditor.cmdOpen();
		}
		if (text == kryptonRibbonGroupButton_25.Tag.ToString())
		{
			clsInit.appEditor.cmdSave();
		}
		if (text == kryptonRibbonGroupButton_105.Tag.ToString())
		{
			try
			{
				F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
				f_ClassViewerDialog.FormCaption = "Settings";
				f_ClassViewerDialog.Value = clsVar.varEditorSet;
				f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
				f_ClassViewerDialog.Width = 500;
				f_ClassViewerDialog.Height = 750;
				f_ClassViewerDialog.ValuePersentage = 35.0;
				f_ClassViewerDialog.Init();
				f_ClassViewerDialog.ShowDialog();
				if (f_ClassViewerDialog.Result == DialogResult.OK)
				{
					clsVar.varEditorSet = new EditorSettings((EditorSettings)f_ClassViewerDialog.Value);
					clsInit.appEditor.GridUpdate();
					clsInit.appEditor.SaveEditorFile();
					clsInit.appEditor.JobUpdate();
				}
			}
			catch (Exception)
			{
			}
		}
		if (!(text == kryptonRibbonGroupButton_7.Tag.ToString()))
		{
			if (!(text == mnu_editshowpoint.Tag.ToString()))
			{
				if ((text == kryptonRibbonGroupButton_106.Tag.ToString()) | (text == kryptonRibbonQATButton_2.Tag.ToString()))
				{
					clsInit.appEditor.UndoGetBack();
				}
				if ((text == kryptonRibbonGroupButton_0.Tag.ToString()) | (text == kryptonRibbonQATButton_0.Tag.ToString()))
				{
					viewport.SetView(viewType.Top);
					viewport.Invalidate();
				}
				if ((text == kryptonRibbonGroupButton_3.Tag.ToString()) | (text == kryptonRibbonQATButton_1.Tag.ToString()))
				{
					viewport.ZoomFit(10);
					viewport.Invalidate();
				}
				if (text == kryptonRibbonGroupButton_1.Tag.ToString())
				{
					viewport.ZoomIn(10);
					viewport.Invalidate();
				}
				if (text == kryptonRibbonGroupButton_2.Tag.ToString())
				{
					viewport.ZoomOut(10);
					viewport.Invalidate();
				}
				if (text == kryptonRibbonGroupButton_5.Tag.ToString())
				{
					for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
					{
						if (clsItem.frmEditor.viewport.Entities[i].Selected)
						{
							clsItem.frmEditor.viewport.Entities[i].Visible = false;
							clsItem.frmEditor.viewport.Entities[i].Selected = false;
						}
					}
					clsItem.frmEditor.viewport.Invalidate();
				}
				if (text == kryptonRibbonGroupButton_4.Tag.ToString())
				{
					for (int j = 0; j <= clsItem.frmEditor.viewport.Entities.Count - 1; j++)
					{
						clsItem.frmEditor.viewport.Entities[j].Selected = false;
						clsItem.frmEditor.viewport.Entities[j].Visible = true;
					}
					clsItem.frmEditor.viewport.Invalidate();
				}
				if (text == kryptonRibbonGroupButton_6.Tag.ToString())
				{
					clsVar.varEditorRuntimeSet.GridEnable = !clsVar.varEditorRuntimeSet.GridEnable;
					kryptonRibbonGroupButton_6.Checked = clsVar.varEditorRuntimeSet.GridEnable;
					viewport.ActiveViewport.Grid.Visible = clsVar.varEditorRuntimeSet.GridEnable;
					viewport.Invalidate();
				}
			}
			else
			{
				clsVar.varEditorSet.ShowPoints = mnu_editshowpoint.Checked;
				viewport.Invalidate();
			}
		}
		else
		{
			clsVar.varEditorSet.ShowBoxSize = kryptonRibbonGroupButton_7.Checked;
			viewport.Invalidate();
		}
	}

	public void mnu_draw_Click(object sender, EventArgs e)
	{
		string text = "";
		if (!(sender is RibbonButton))
		{
			if (!(sender is ToolStripMenuItem))
			{
				if (sender is KryptonRibbonGroupButton)
				{
					KryptonRibbonGroupButton kryptonRibbonGroupButton = sender as KryptonRibbonGroupButton;
					text = kryptonRibbonGroupButton.Tag.ToString();
				}
			}
			else
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			RibbonButton ribbonButton = sender as RibbonButton;
			text = ribbonButton.Name;
		}
		Sketcher2D.OrthoPossible = false;
		if (text == kryptonRibbonGroupButton_8.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawPoint;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_9.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawLine;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_10.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawCircle;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_11.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawCircle3Point;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_12.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawArc3PointSEM;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_13.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawRectangle;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_14.Tag.ToString())
		{
			DialogBoxInput dialogBoxInput = new DialogBoxInput();
			dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[70] + " " + AppLanguage.CadCamDynamic[71];
			dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[71];
			dialogBoxInput.Value = clsVar.varEditorRuntimeSet.PolygonSide;
			dialogBoxInput.Decimal(0);
			dialogBoxInput.Init();
			dialogBoxInput.SelectAll();
			dialogBoxInput.ShowDialog();
			if (dialogBoxInput.Result == DialogResult.OK)
			{
				clsVar.varEditorRuntimeSet.PolygonSide = (int)dialogBoxInput.Value;
				Sketcher2D.Clicks.Clear();
				clsInit.appEditor.action = actionTypeBU.drawPolygon;
				Sketcher2D.isDrawing = true;
				Sketcher2D.selectionProcess = false;
			}
		}
		if (text == kryptonRibbonGroupButton_15.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawEllipse;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_18.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawSpline;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_16.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawSlot;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_17.Tag.ToString())
		{
			F_Barrel f_Barrel = new F_Barrel();
			f_Barrel.Barrel.Width = clsVar.varEditorRuntimeSet.KeyHoleLength;
			f_Barrel.Barrel.Height = clsVar.varEditorRuntimeSet.KeyHoleWidth;
			f_Barrel.Barrel.HeadRadius = clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter;
			f_Barrel.Barrel.Rotation = clsVar.varEditorRuntimeSet.KeyHoleAngle;
			f_Barrel.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
			f_Barrel.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
			f_Barrel.Init();
			f_Barrel.ShowDialog();
			if (f_Barrel.PropertiesForm.Result == DialogResult.OK)
			{
				clsVar.varEditorRuntimeSet.KeyHoleLength = f_Barrel.Barrel.Width;
				clsVar.varEditorRuntimeSet.KeyHoleWidth = f_Barrel.Barrel.Height;
				clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter = f_Barrel.Barrel.HeadRadius;
				clsVar.varEditorRuntimeSet.KeyHoleAngle = f_Barrel.Barrel.Rotation;
				Sketcher2D.Clicks.Clear();
				clsInit.appEditor.action = actionTypeBU.drawKeyHole;
				Sketcher2D.isDrawing = true;
				Sketcher2D.selectionProcess = false;
			}
		}
		if (text == kryptonRibbonGroupButton_123.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.eventCopy;
			Sketcher2D.entitiesSelected.Clear();
			clsInit.appEditor.cmdInsert(ref Sketcher2D.entitiesSelected);
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
			Sketcher2D.Clicks.Add(new UClick(new Point2D(MidPoint.X, MidPoint.Y), new Point3D(MidPoint.X, MidPoint.Y)));
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Copy);
			Sketcher2D.selectionProcess = false;
		}
		if ((text == kryptonRibbonGroupButton_20.Tag.ToString()) | (text == kryptonRibbonGroupButton_111.Tag.ToString()))
		{
			clsInit.appEditor.cmdEventsCopy();
		}
		if ((text == kryptonRibbonGroupButton_21.Tag.ToString()) | (text == kryptonRibbonGroupButton_112.Tag.ToString()))
		{
			clsInit.appEditor.cmdEventsMove();
		}
		if (text == kryptonRibbonGroupButton_22.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsMirror();
		}
		if (text == kryptonRibbonGroupButton_30.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsOffset();
		}
		if (text == kryptonRibbonGroupButton_27.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsRotate();
		}
		if (text == kryptonRibbonGroupButton_28.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsBreak();
		}
		if (text == kryptonRibbonGroupButton_29.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsScale();
		}
		if (text == kryptonRibbonGroupButton_31.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsExtend();
		}
		if (text == kryptonRibbonGroupButton_32.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsTrim();
		}
		if (text == kryptonRibbonGroupButton_33.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsFillet();
		}
		if (text == kryptonRibbonGroupButton_34.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsChamfer();
		}
		if (text == kryptonRibbonGroupButton_35.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsDelete();
		}
		if (text == kryptonRibbonGroupButton_94.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Left);
		}
		if (text == kryptonRibbonGroupButton_95.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Right);
		}
		if (text == kryptonRibbonGroupButton_96.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Top);
		}
		if (text == kryptonRibbonGroupButton_97.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Bottom);
		}
		if (text == kryptonRibbonGroupButton_98.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.HorizontalCenter);
		}
		if (text == kryptonRibbonGroupButton_99.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.VerticalCenter);
		}
		if (text == kryptonRibbonGroupButton_100.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsEqualDistance(EqualDistance.Horizontal);
		}
		if (text == kryptonRibbonGroupButton_101.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsEqualDistance(EqualDistance.Vertical);
		}
		if (text == kryptonRibbonGroupButton_113.Tag.ToString())
		{
			clsInit.appEditor.cmdEventsTurnOver();
		}
		if (text == toolStripMenuItem_0.Name.ToString())
		{
			clsInit.appEditor.cmdEventsRotateValue(-90.0);
		}
		if (text == toolStripMenuItem_1.Name.ToString())
		{
			clsInit.appEditor.cmdEventsRotateValue(90.0);
		}
		if (text == toolStripMenuItem_2.Name.ToString())
		{
			clsInit.appEditor.cmdEventsRotateValue(-180.0);
		}
		if (text == toolStripMenuItem_3.Name.ToString())
		{
			clsInit.appEditor.cmdEventsMirrorValue(HorizontalVertical.Horizontal);
		}
		if (text == toolStripMenuItem_4.Name.ToString())
		{
			clsInit.appEditor.cmdEventsMirrorValue(HorizontalVertical.Vertical);
		}
		if (text == kryptonRibbonGroupButton_108.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawMeasure;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
		}
		if (!(text == kryptonRibbonGroupButton_109.Tag.ToString()))
		{
		}
	}

	public void mnu_lib_Click(object sender, EventArgs e)
	{
		string text = "";
		if (!(sender is RibbonButton))
		{
			if (!(sender is ToolStripMenuItem))
			{
				if (sender is KryptonRibbonGroupButton)
				{
					KryptonRibbonGroupButton kryptonRibbonGroupButton = sender as KryptonRibbonGroupButton;
					text = kryptonRibbonGroupButton.Tag.ToString();
				}
			}
			else
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			RibbonButton ribbonButton = sender as RibbonButton;
			text = ribbonButton.Name;
		}
		Sketcher2D.OrthoPossible = false;
		Sketcher2D.selectionProcess = false;
		Sketcher2D.isDrawing = false;
		Sketcher2D.isSelectionDone = false;
		if (Sketcher2D.entitiesSelected != null)
		{
			Sketcher2D.entitiesSelected.Clear();
		}
		Sketcher2D.entitySelected = null;
		if (text == kryptonRibbonGroupButton_38.Tag.ToString())
		{
			if (viewport.CurrentSketch == null)
			{
				if (viewport.Entities.Count > 0 && viewport.Entities[0] is SketchEntity)
				{
					((SketchEntity)viewport.Entities[0]).Exit(keepChanges: false);
				}
			}
			else
			{
				viewport.CurrentSketch.Exit();
			}
			viewport.Entities.Clear();
			SketchEntity sketchEntity = new SketchEntity(Plane.XY);
			viewport.Entities.Add(sketchEntity);
			sketchEntity.Edit(viewport);
			viewport.CurrentSketch.ClearHistory();
			viewport.CurrentSketch.UpdateAndInvalidate();
			viewport.SetView(viewType.Top);
		}
		if (text == kryptonRibbonGroupButton_39.Tag.ToString())
		{
			clsInit.appEditor.cmdOpenLib();
		}
		if (text == kryptonRibbonGroupButton_40.Tag.ToString() && viewport.CurrentSketch != null)
		{
			_ = viewport.CurrentSketch;
			viewport.CurrentSketch.Exit();
			viewport.Entities.Regen();
			viewport.Invalidate();
			clsInit.appEditor.cmdSaveLib(viewport);
			if (viewport.Entities.Count > 0 && viewport.Entities[0] is SketchEntity)
			{
				((SketchEntity)viewport.Entities[0]).Edit(viewport);
			}
			clsInit.appEditor.JobUpdate();
		}
		if (text == kryptonRibbonGroupButton_61.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryVertical;
		}
		if (text == kryptonRibbonGroupButton_60.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryHorizontal;
		}
		if (text == kryptonRibbonGroupButton_46.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryLength;
		}
		if (text == kryptonRibbonGroupButton_52.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryFixPoint;
		}
		if (text == kryptonRibbonGroupButton_58.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryEqualLength;
		}
		if (text == kryptonRibbonGroupButton_59.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryEqualRadius;
		}
		if (text == kryptonRibbonGroupButton_57.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryParalel;
		}
		if (text == kryptonRibbonGroupButton_56.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryPerpendiculat;
		}
		if (text == mnu_libfillet.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor._filletsChamfers = new Tuple<ICurve, ICurve, ICurve>[4];
			clsInit.appEditor.action = actionTypeBU.libraryFillet;
		}
		if (text == kryptonRibbonGroupButton_43.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor._filletsChamfers = new Tuple<ICurve, ICurve, ICurve>[4];
			clsInit.appEditor.action = actionTypeBU.libraryChamfer;
		}
		if (text == kryptonRibbonGroupButton_49.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryLineLine;
		}
		if (text == kryptonRibbonGroupButton_50.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryLinePoint;
		}
		if (text == kryptonRibbonGroupButton_51.Tag.ToString())
		{
			for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
			{
				if (!((clsItem.frmEditor.viewport.Entities[i] is devDept.Eyeshot.Entities.Point) | (clsItem.frmEditor.viewport.Entities[i] is SketchEntity)))
				{
					clsItem.frmEditor.viewport.Entities[i].Selectable = false;
				}
				else
				{
					clsItem.frmEditor.viewport.Entities[i].Selectable = true;
				}
			}
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryPointPoint;
		}
		if (text == kryptonRibbonGroupButton_48.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryAngle;
		}
		if (text == kryptonRibbonGroupButton_47.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryRadius;
		}
		if (text == kryptonRibbonGroupButton_44.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			Sketcher2D.entitySelected = null;
			clsInit.appEditor.action = actionTypeBU.libraryOffet;
		}
		if (text == kryptonRibbonGroupButton_45.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryMirror;
		}
		if (text == kryptonRibbonGroupButton_55.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryCollinear;
		}
		if (text == kryptonRibbonGroupButton_54.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryTangent;
		}
		if (text == kryptonRibbonGroupButton_41.Tag.ToString())
		{
			clsInit.appEditor.cmdUndo();
		}
		if (text == kryptonRibbonGroupButton_42.Tag.ToString())
		{
			clsInit.appEditor.cmdRedo();
		}
		if (text == kryptonRibbonGroupButton_62.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.libraryDeleteEntity;
		}
	}

	public void mnu_sewing_Click(object sender, EventArgs e)
	{
		string text = "";
		if (!(sender is RibbonButton))
		{
			if (!(sender is ToolStripMenuItem))
			{
				if (sender is KryptonRibbonGroupButton)
				{
					KryptonRibbonGroupButton kryptonRibbonGroupButton = sender as KryptonRibbonGroupButton;
					text = kryptonRibbonGroupButton.Tag.ToString();
				}
			}
			else
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			RibbonButton ribbonButton = sender as RibbonButton;
			text = ribbonButton.Name;
		}
		Sketcher2D.OrthoPossible = false;
		if (clsInit.appSewing == null)
		{
			return;
		}
		if (text == kryptonRibbonGroupButton_63.Tag.ToString())
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = clsSewing.varSewingRunSettings.pathTeachFile;
			openFileDialog.Filter = "Sewing File (*.sewing)|*.sewing";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				clsSewing.varSewingRunSettings.pathTeachFile = buFile5.GetPath(openFileDialog.FileName);
				clsInit.appSewing.SaveSewingFile();
				clsInit.appSewing.SewingBase.MainEntityList.Clear();
				clsInit.appSewing.OpenSewingJobFile(openFileDialog.FileName, ref clsInit.appSewing.SewingBase);
				for (int i = 0; i <= clsInit.appSewing.SewingBase.MainEntityList.Count - 1; i++)
				{
					clsInit.appSewing.SewingBase.MainEntityList[i].LayerName = "Default";
				}
				clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
				clsItem.frmEditor.viewport.ZoomFit(10);
			}
		}
		if (text == kryptonRibbonGroupButton_64.Tag.ToString())
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = clsSewing.varSewingRunSettings.pathTeachFile;
			saveFileDialog.Filter = "Sewing File (*.sewing)|*.sewing";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				clsSewing.varSewingRunSettings.pathTeachFile = buFile5.GetPath(saveFileDialog.FileName);
				ArrayList arrayList = new ArrayList();
				for (int j = 0; j <= clsInit.appSewing.SewingBase.MainEntityList.Count - 1; j++)
				{
					arrayList.AddRange(clsInit.appSewing.SewingBase.MainEntityList[j].ToDef(2));
				}
				buFile5.SaveToFile(arrayList, saveFileDialog.FileName);
				clsInit.appSewing.SaveSewingFile();
			}
		}
		if (text == kryptonRibbonGroupButton_126.Tag.ToString())
		{
			clsInit.appSewing.cmdNew();
		}
		if (text == kryptonRibbonGroupButton_127.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.eventCopy;
			Sketcher2D.entitiesSelected.Clear();
			clsInit.appEditor.cmdInsert(ref Sketcher2D.entitiesSelected);
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(Sketcher2D.entitiesSelected, ref MinPoint, ref MidPoint, ref MaxPoint);
			Sketcher2D.Clicks.Add(new UClick(new Point2D(MidPoint.X, MidPoint.Y), new Point3D(MidPoint.X, MidPoint.Y)));
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Copy);
			Sketcher2D.selectionProcess = false;
		}
		if (text == kryptonRibbonGroupButton_83.Tag.ToString())
		{
			clsInit.appSewing.cmdAddCodes();
		}
		if (text == kryptonRibbonGroupButton_75.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawLine;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
			SewingTempVars.DrawCommand = SewingDrawCommand.LineJump;
		}
		if (text == kryptonRibbonGroupButton_73.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawLine;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
			SewingTempVars.DrawCommand = SewingDrawCommand.LineStitched;
		}
		if (text == kryptonRibbonGroupButton_74.Tag.ToString())
		{
			Sketcher2D.Clicks.Clear();
			clsInit.appEditor.action = actionTypeBU.drawArc3PointSEM;
			Sketcher2D.isDrawing = true;
			Sketcher2D.selectionProcess = false;
			SewingTempVars.DrawCommand = SewingDrawCommand.ArcStitched;
		}
		if (text == kryptonRibbonGroupButton_81.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingSorting;
			Sketcher2D.selectionProcess = false;
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[41], buLangTranslate.preDef.Sorting);
		}
		if (text == kryptonRibbonGroupButton_69.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingDelete;
			Sketcher2D.selectionProcess = true;
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[1], buLangTranslate.preDef.Sewing);
		}
		if (text == kryptonRibbonGroupButton_86.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingDeleteVertex;
			Sketcher2D.selectionProcess = false;
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[10], buLangTranslate.preDef.Sewing);
		}
		if (text == kryptonRibbonGroupButton_84.Tag.ToString() && clsInit.appSewing != null)
		{
			clsInit.appSewing.doDeleteAll();
		}
		if (text == kryptonRibbonGroupButton_66.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingLockStitch;
			Sketcher2D.selectionProcess = false;
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[1], buLangTranslate.preDef.Sewing);
		}
		if (text == kryptonRibbonGroupButton_68.Tag.ToString())
		{
			SewingTempVars.DrawType = SewingDrawType.Stitched;
			clsInit.appEditor.action = actionTypeBU.sewingMove;
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[1], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == kryptonRibbonGroupButton_70.Tag.ToString())
		{
			for (int k = 0; k <= clsItem.frmEditor.viewport.Entities.Count - 1; k++)
			{
				if (clsItem.frmEditor.viewport.Entities[k] is Joint)
				{
					clsItem.frmEditor.viewport.Entities[k].Visible = false;
				}
			}
			clsItem.frmEditor.viewport.Invalidate();
			SewingTempVars.DrawType = SewingDrawType.Stitched;
			clsInit.appEditor.action = actionTypeBU.sewingMoveVertex;
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == toolStripMenuItem_5.Name.ToString())
		{
			clsInit.appSewing.doDeleteProperties();
		}
		if (text == mnu_sewingfootheight.Tag.ToString())
		{
			SewingTempVars.DrawType = SewingDrawType.Stitched;
			clsInit.appEditor.action = actionTypeBU.sewingFootHeight;
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == kryptonRibbonGroupButton_128.Tag.ToString())
		{
			SewingTempVars.DrawType = SewingDrawType.Stitched;
			clsInit.appEditor.action = actionTypeBU.sewingSpeed;
			clsInit.appSewing.Selected.Clear();
			for (int l = 0; l <= viewport.Entities.Count - 1; l++)
			{
				if (!viewport.Entities[l].Selected)
				{
					continue;
				}
				for (int m = 0; m <= clsInit.appSewing.SewingBase.MainEntityList.Count - 1; m++)
				{
					if (buCompare5.EQ(clsInit.appSewing.SewingBase.MainEntityList[m].Vertices, viewport.Entities[l].Vertices))
					{
						for (int n = 0; n <= clsInit.appSewing.SewingBase.MainEntityList[m].Sewing.Vertex.Count - 1; n++)
						{
							SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
							sewingSelectedPoint.EntityIndex = m;
							sewingSelectedPoint.VertexIndex = n;
							clsInit.appSewing.Selected.Add(sewingSelectedPoint);
						}
						clsInit.appSewing.SelectVertexCommand("Ok", 0, true);
						return;
					}
				}
			}
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == kryptonRibbonGroupButton_87.Tag.ToString())
		{
			SewingTempVars.DrawType = SewingDrawType.Stitched;
			clsInit.appEditor.action = actionTypeBU.sewingChangeDirection;
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == mnu_sewingoffset.Tag.ToString())
		{
			clsInit.appSewing.cmdOffset();
		}
		if (text == kryptonRibbonGroupButton_65.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingPunteriz;
			Sketcher2D.selectionProcess = false;
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[0], buLangTranslate.preDef.Sewing);
		}
		if (text == mnu_sewingrotate.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingRotate;
			Sketcher2D.selectionProcess = false;
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[2], buLangTranslate.preDef.Sewing);
		}
		if (text == mnu_sewingscale.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingScale;
			Sketcher2D.selectionProcess = false;
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[3], buLangTranslate.preDef.Sewing);
		}
		if (text == kryptonRibbonGroupButton_76.Tag.ToString())
		{
			clsInit.appSewing.cmdSimilationStart();
		}
		if (text == kryptonRibbonGroupButton_77.Tag.ToString())
		{
			clsInit.appSewing.cmdSimilationStop();
		}
		if (text == kryptonRibbonGroupButton_78.Tag.ToString())
		{
			clsInit.appSewing.cmdSimilationPrevius(1);
		}
		if (text == kryptonRibbonGroupButton_79.Tag.ToString())
		{
			clsInit.appSewing.cmdSimilationNext(1);
		}
		if (!(text == kryptonRibbonGroupButton_80.Tag.ToString()))
		{
		}
		if (text == mnu_sewingstitchtable.Tag.ToString())
		{
			clsInit.appSewing.cmdShowTable(ref clsInit.appSewing.SewingBase, ref clsInit.appSewing.SewingTableList);
		}
		if (text == kryptonRibbonGroupButton_71.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingJumpToStitch;
			Sketcher2D.entitiesSelected.Clear();
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appSewing.cmdJumpToStitch();
				clsInit.appEditor.Reset();
				clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, viewport.Entities);
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == kryptonRibbonGroupButton_72.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingStitchToJump;
			Sketcher2D.entitiesSelected.Clear();
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appSewing.cmdStitchToJump();
				clsInit.appEditor.Reset();
				clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, viewport.Entities);
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == kryptonRibbonGroupButton_67.Tag.ToString())
		{
			clsInit.appEditor.action = actionTypeBU.sewingChangeStitchLen;
			Sketcher2D.entitiesSelected.Clear();
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appSewing.cmdChangeStitchLength(Sketcher2D.entitiesSelected, clsSewing.varSewingRunSettings.ShowDialog);
				clsInit.appEditor.Reset();
				clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, viewport.Entities);
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
				Sketcher2D.selectionProcess = true;
			}
		}
		if (text == kryptonRibbonGroupButton_85.Tag.ToString() && clsInit.appSewing != null)
		{
			clsInit.appSewing.UndoGetBack();
		}
	}

	public void mnu_foam_Click(object sender, EventArgs e)
	{
		string text = "";
		if (!(sender is RibbonButton))
		{
			if (!(sender is ToolStripMenuItem))
			{
				if (sender is KryptonRibbonGroupButton)
				{
					KryptonRibbonGroupButton kryptonRibbonGroupButton = sender as KryptonRibbonGroupButton;
					text = kryptonRibbonGroupButton.Tag.ToString();
				}
			}
			else
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			RibbonButton ribbonButton = sender as RibbonButton;
			text = ribbonButton.Name;
		}
		if (!(text == kryptonRibbonGroupButton_102.Tag.ToString()))
		{
			if (!(text == kryptonRibbonGroupButton_103.Tag.ToString()))
			{
				if (!(text == kryptonRibbonGroupButton_91.Tag.ToString()))
				{
					if (text == kryptonRibbonGroupButton_114.Tag.ToString())
					{
						try
						{
							F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
							f_ClassViewerDialog.FormCaption = "Settings";
							f_ClassViewerDialog.Value = buFoamCalc.varFoamEditorSettings;
							f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
							f_ClassViewerDialog.Width = 500;
							f_ClassViewerDialog.Height = 400;
							f_ClassViewerDialog.ValuePersentage = 35.0;
							f_ClassViewerDialog.Init();
							f_ClassViewerDialog.ShowDialog();
							if (f_ClassViewerDialog.Result == DialogResult.OK)
							{
								buFoamCalc.varFoamEditorSettings = new FoamEditorSettings((FoamEditorSettings)f_ClassViewerDialog.Value);
								clsVar.varEditorSet.colorDrawingPoints = buFoamCalc.varFoamEditorSettings.VirtualColor;
								viewport.Invalidate();
								clsInit.appFoamCutting.SaveFoamFile();
							}
							return;
						}
						catch (Exception)
						{
							return;
						}
					}
					if (!(text == kryptonRibbonGroupButton_115.Tag.ToString()))
					{
						if (!(text == kryptonRibbonGroupButton_93.Tag.ToString()))
						{
							if (!(text == kryptonRibbonGroupButton_92.Tag.ToString()))
							{
								Sketcher2D.OrthoPossible = false;
								if (text == kryptonRibbonGroupButton_104.Tag.ToString() && clsInit.appEditor.sortedEntities.Count > 0)
								{
									for (int i = 0; i <= clsInit.appEditor.sortRefEntities.Count - 1; i++)
									{
										if (clsInit.appEditor.sortedEntities[clsInit.appEditor.sortedEntities.Count - 1].Info.ID == clsInit.appEditor.sortRefEntities[i].Info.ID)
										{
											clsInit.appEditor.sortRefEntities[i].Info.CamSelected = false;
											if (clsInit.appEditor.sortRefEntities[i].Info.CamSelectedCount > 0)
											{
												clsInit.appEditor.sortRefEntities[i].Info.CamSelectedCount--;
											}
										}
									}
									clsInit.appEditor.sortedEntities.RemoveAt(clsInit.appEditor.sortedEntities.Count - 1);
									if (clsInit.appEditor.sortedEntities.Count <= 0)
									{
										clsInit.appEditor.ClearSortThings();
									}
									else
									{
										Point3D pntEnd = new Point3D();
										clsInit.cVector5.GetEntityEndPointByCamDirection(clsInit.appEditor.sortedEntities[clsInit.appEditor.sortedEntities.Count - 1], ref pntEnd);
										clsInit.appEditor.ManuelSortClickResult.LastPoint = pntEnd;
										buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(pntEnd);
										buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd);
									}
									clsInit.appFoamCutting.doShowVirtualDrawings();
									viewport.Invalidate();
								}
								if (text == kryptonRibbonGroupButton_89.Tag.ToString() && buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[124]) == DialogResult.Yes)
								{
									clsInit.appEditor.ClearSortThings();
									clsInit.appFoamCutting.doShowVirtualDrawings();
								}
								if (text == kryptonRibbonGroupButton_88.Tag.ToString())
								{
									pnl_foamsort.Visible = true;
									if (clsInit.appEditor.sortRefEntities.Count == 0)
									{
										for (int j = 0; j <= viewport.Entities.Count - 1; j++)
										{
											buEntity copiedEntity = null;
											buEntity.Copy(viewport.Entities[j], ref copiedEntity);
											if (copiedEntity != null)
											{
												copiedEntity.Info.ID = (j + 1).ToString();
												clsInit.appEditor.sortRefEntities.Add(copiedEntity);
											}
										}
									}
									clsInit.appEditor.action = actionTypeBU.miscAutoSort;
									Sketcher2D.selectionProcess = false;
									clsInit.appEditor.ManuelSortSetting.Option.FindUntilToEnd = true;
									clsInit.appEditor.ManuelSortSetting.Option.UseCamSelectedProps = true;
									clsInit.appEditor.ManuelSortSetting.Option.NextGroupRules = SortingNextGroupFindRulesType.AskMe;
									clsInit.appEditor.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.AskMe;
									clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[41], buLangTranslate.preDef.Sorting);
									clsInit.appFoamCutting.doShowVirtualDrawings();
								}
								if (text == kryptonRibbonGroupButton_90.Tag.ToString())
								{
									if (clsInit.appEditor.sortRefEntities.Count == 0)
									{
										for (int k = 0; k <= viewport.Entities.Count - 1; k++)
										{
											buEntity copiedEntity2 = null;
											buEntity.Copy(viewport.Entities[k], ref copiedEntity2);
											if (copiedEntity2 != null)
											{
												clsInit.appEditor.sortRefEntities.Add(copiedEntity2);
											}
										}
									}
									clsInit.appEditor.action = actionTypeBU.miscManuelSort;
									Sketcher2D.selectionProcess = false;
									clsInit.appEditor.ManuelSortSetting.Option.FindUntilToEnd = true;
									clsInit.appEditor.ManuelSortSetting.Option.UseCamSelectedProps = true;
									clsInit.appEditor.ManuelSortSetting.Option.NextGroupRules = SortingNextGroupFindRulesType.AskMe;
									clsInit.appEditor.ManuelSortSetting.Option.IntersectionRules = SortingIntersectionRulesType.AskMe;
									clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[41], buLangTranslate.preDef.Sorting);
									clsInit.appFoamCutting.doShowVirtualDrawings();
								}
								if (text == kryptonRibbonGroupButton_117.Tag.ToString())
								{
									clsInit.appEditor.cmdSimStart();
								}
								if (text == kryptonRibbonGroupButton_118.Tag.ToString())
								{
									clsInit.appEditor.cmdSimStop();
								}
								if (text == kryptonRibbonGroupButton_119.Tag.ToString())
								{
									clsInit.appEditor.cmdSimBwd();
								}
								if (text == kryptonRibbonGroupButton_120.Tag.ToString())
								{
									clsInit.appEditor.cmdSimFwd();
								}
							}
							else
							{
								OpenFileDialog openFileDialog = new OpenFileDialog();
								openFileDialog.Filter = "Foam Pattern File (*.foampattern)|*.foampattern";
								openFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamPattern;
								openFileDialog.FilterIndex = 1;
								if (openFileDialog.ShowDialog() == DialogResult.OK)
								{
									Class5.smethod_89(this, openFileDialog.FileName);
								}
							}
						}
						else
						{
							SaveFileDialog saveFileDialog = new SaveFileDialog();
							saveFileDialog.Filter = "Foam Pattern File (*.foampattern)|*.foampattern";
							saveFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamPattern;
							saveFileDialog.FilterIndex = 1;
							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								buFoamCalc.varFoamRunSettings.pathFoamPattern = buFile5.GetPath(saveFileDialog.FileName);
								clsInit.appEditor.SaveSortedEntities(saveFileDialog.FileName);
								clsInit.appFoamCutting.SaveFoamFile();
							}
						}
					}
					else
					{
						if (buFoamCalc.varFoamRunSettings.ShowVirtualDrawings)
						{
							buFoamCalc.varFoamRunSettings.ShowVirtualDrawings = false;
							kryptonRibbonGroupButton_115.Checked = buFoamCalc.varFoamRunSettings.ShowVirtualDrawings;
							Sketcher2D.DrawingPoints.Clear();
						}
						else
						{
							buFoamCalc.varFoamRunSettings.ShowVirtualDrawings = true;
							clsInit.appFoamCutting.doShowVirtualDrawings();
							kryptonRibbonGroupButton_115.Checked = buFoamCalc.varFoamRunSettings.ShowVirtualDrawings;
						}
						viewport.Invalidate();
					}
				}
				else if (buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[29]) == DialogResult.Yes)
				{
					clsInit.appEditor.ClearSortThings();
				}
			}
			else
			{
				clsVar.varEditorSet.ShowPoints = kryptonRibbonGroupButton_103.Checked;
			}
		}
		else
		{
			clsVar.varEditorSet.ShowBoxSize = kryptonRibbonGroupButton_102.Checked;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == chk_showcontrraint.Name)
		{
			clsInit.appEditor.cmdShowContrraint(chk_showcontrraint.Checked);
		}
		if (control.Name == chk_showdims.Name)
		{
			clsInit.appEditor.cmdShowDimension(chk_showdims.Checked);
		}
	}

	internal void method_3(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			clsInit.appEditor.Reset();
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == button_1.Name)
		{
			panel_2.Visible = true;
		}
		if (control.Name == kryptonCheckButton_0.Name)
		{
			clsVar.varEditorSet.OsnapEntity = kryptonCheckButton_0.Checked;
			clsInit.appEditor.SaveEditorFile();
		}
		if (control.Name == kryptonCheckButton_1.Name)
		{
			clsVar.varEditorSet.OsnapGrid = kryptonCheckButton_1.Checked;
			clsInit.appEditor.SaveEditorFile();
		}
		if (control.Name == kryptonCheckButton_2.Name)
		{
			clsVar.varEditorSet.Ortho = kryptonCheckButton_2.Checked;
			clsInit.appEditor.SaveEditorFile();
		}
		if (control.Name == button_3.Name && ((clsInit.appEditor.SelectedDrawing >= 0) | (viewport.ActionMode == actionType.SelectByBox)) && comboBox_0.Text.Trim().Length > 0)
		{
			string command = comboBox_0.Text.Trim();
			if (comboBox_0.Text.Trim() == buLangTranslate.preDef.Depth)
			{
				command = buLangTranslate.preDef.Depth + " = " + numericUpDown_0.Value.ToString("f2");
			}
			clsInit.appEditor.AddCommandToDrawing(command, clsInit.appEditor.SelectedDrawing);
			panel_2.Visible = false;
		}
		if (control.Name == button_0.Name)
		{
			clsInit.appEditor.RemoveCommandFromDrawing(lst_command.SelectedIndex, clsInit.appEditor.SelectedDrawing);
		}
		if (control.Name == button_2.Name)
		{
			panel_2.Visible = false;
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (!(comboBox_0.Text == buLangTranslate.preDef.Depth))
		{
			label_1.Visible = false;
			numericUpDown_0.Visible = false;
		}
		else
		{
			label_1.Text = buLangTranslate.preDef.Depth;
			label_1.Visible = true;
			numericUpDown_0.Visible = true;
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (!radioButton_3.Checked)
		{
			if (!radioButton_4.Checked)
			{
				if (!radioButton_2.Checked)
				{
					if (!radioButton_6.Checked)
					{
						if (!radioButton_5.Checked)
						{
							if (!radioButton_1.Checked)
							{
								if (!radioButton_0.Checked)
								{
									if (radioButton_7.Checked)
									{
										clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.Manuel;
									}
								}
								else
								{
									clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.None;
								}
							}
							else
							{
								clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.LowerIndex;
							}
						}
						else
						{
							clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.Jump;
						}
					}
					else
					{
						clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.HigherIndex;
					}
				}
				else
				{
					clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.FirstDirectionThenAuto;
				}
			}
			else
			{
				clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.CW;
			}
		}
		else
		{
			clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.CCW;
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
