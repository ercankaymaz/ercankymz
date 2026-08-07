// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.F_Editor
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Sewing;
using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Drawings;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Variables;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Toolkit;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
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
  public Sketcher2D viewport = (Sketcher2D) null;
  public Image refImage = (Image) null;
  public SizeObject refImageSize = new SizeObject();
  private Color color_0 = Color.DarkOrange;
  private Color color_1 = Color.Blue;
  private Color color_2 = Color.Black;
  private Timer timer_0 = new Timer();
  private int int_0 = 0;
  public int ZoomOutValue = 0;
  private ToolTip toolTip_0 = new ToolTip();
  internal IContainer icontainer_0 = (IContainer) null;
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
    this.toolStripMenuItem_0.Image = this.imageList_2.Images[3];
    this.toolStripMenuItem_1.Image = this.imageList_2.Images[4];
    this.toolStripMenuItem_2.Image = this.imageList_2.Images[5];
    this.toolStripMenuItem_3.Image = this.imageList_2.Images[7];
    this.toolStripMenuItem_4.Image = this.imageList_2.Images[8];
    this.spn_value.ValueChanged += new EventHandler(clsInit.appEditor.Spn_ValueChanged);
    this.chk_check.CheckedChanged += new EventHandler(clsInit.appEditor.Chk_CheckedChenged);
    this.timer_0.Interval = 500;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.tree_objects.AfterSelect += new TreeViewEventHandler(clsInit.appEditor.JobTree_AfterSelect);
    if (clsInit.appSewing == null)
      return;
    this.tree_sewing.AfterSelect += new TreeViewEventHandler(clsInit.appSewing.JobTree_AfterSelect);
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    if (this.timer_0.Enabled | this.int_0 == 0)
    {
      e.Cancel = true;
    }
    else
    {
      if (this.PropertiesForm.Result == DialogResult.OK)
        return;
      e.Cancel = true;
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      if ((this.viewport.CurrentSketch == null ? 0 : (this.viewport.CurrentSketch.Editing ? 1 : 0)) != 0)
        ;
      this.Visible = false;
    }
  }

  public void Init()
  {
    Sketcher2D.FirstMove = false;
    Sketcher2D.DrawingPoints.Clear();
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.LoadLanguage();
    clsInit.appEditor.ClearSortThings();
    clsInit.appEditor.sortedEntities.Clear();
    this.kryptonRibbonTab_4.Visible = clsVar.varEditorRuntimeSet.isSewingMode;
    this.kryptonRibbonTab_3.Visible = clsVar.varEditorRuntimeSet.isSketchMode;
    this.kryptonRibbonTab_5.Visible = clsVar.varEditorRuntimeSet.isFoamMode;
    for (int index = this.tabControl_0.TabPages.Count - 1; index >= 0; --index)
    {
      System.Windows.Forms.Control tabPage = (System.Windows.Forms.Control) this.tabControl_0.TabPages[index];
      if (tabPage.Name == this.tabPage_1.Name & !clsVar.varEditorRuntimeSet.isSewingMode)
        this.tabControl_0.TabPages.RemoveAt(index);
      if (tabPage.Name == this.tabPage_0.Name & !clsVar.varEditorRuntimeSet.isSketchMode)
        this.tabControl_0.TabPages.RemoveAt(index);
      if (tabPage.Name == this.tabPage_2.Name & !clsVar.varEditorRuntimeSet.isFoamMode)
        this.tabControl_0.TabPages.RemoveAt(index);
    }
    if (this.tabControl_0.TabPages.Count == 0)
    {
      this.tabControl_0.Visible = false;
      this.panel_0.Left = 2;
      this.panel_0.Width = this.Width - 25;
      this.kryptonRibbon_0.SelectedTab = this.kryptonRibbonTab_1;
    }
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      this.kryptonRibbon_0.SelectedTab = this.kryptonRibbonTab_3;
      clsVar.varEditorSet.ShowBoxSize = false;
    }
    if (clsVar.varEditorRuntimeSet.isSewingMode)
      this.kryptonRibbon_0.SelectedTab = this.kryptonRibbonTab_4;
    if (clsVar.varEditorRuntimeSet.isFoamMode)
      this.kryptonRibbon_0.SelectedTab = this.kryptonRibbonTab_5;
    if (this.viewport == null)
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
      clsInit.appEditor.CreateModelControl(ref this.viewport, clsVar.UnlockKey, Properties);
      clsInit.appEditor.GridUpdate();
      this.viewport.MouseDoubleClick += new MouseEventHandler(this.Viewport_MouseDoubleClick);
      this.viewport.WorkCompleted += new WorkUnit.WorkCompletedEventHandler(clsInit.appEditor.Desing_WorkCompleted);
      this.panel_0.Controls.Add((System.Windows.Forms.Control) this.viewport);
      Entity rectangle = (Entity) CompositeCurve.CreateRectangle(100.0, 100.0);
      rectangle.Selected = true;
      this.viewport.Entities.Add(rectangle);
      this.viewport.ZoomFit(true);
      this.viewport.Invalidate();
    }
    this.viewport.AssemblySelectionMode = Workspace.assemblySelectionType.Branch;
    if (this.tabControl_0.TabPages.Count > 0)
      this.panel_0.Width = this.Width - this.tabControl_0.Width - 25;
    if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.None)
      this.radioButton_0.Checked = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.CCW)
      this.radioButton_3.Checked = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.CW)
      this.radioButton_4.Checked = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.FirstDirectionThenAuto)
      this.radioButton_2.Checked = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.HigherIndex)
      this.radioButton_6.Checked = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.Jump)
      this.radioButton_5.Checked = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.LowerIndex)
      this.radioButton_1.Checked = true;
    else if (clsVar.varEditorSet.SortFirstCatchRule == SortingFirstCatchRulesType.Manuel)
      this.radioButton_7.Checked = true;
    clsInit.appEditor.action = actionTypeBU.None;
    Sketcher2D.Clicks.Clear();
    this.viewport.Selection.Color = Color.Red;
    this.viewport.Selection.LineWeightScaleFactor = 2f;
    this.chk_showcontrraint.Checked = clsVar.varEditorRuntimeSet.ShowContrraint;
    this.chk_showdims.Checked = clsVar.varEditorRuntimeSet.ShowDimension;
    this.kryptonRibbonGroupButton_102.Checked = clsVar.varEditorSet.ShowBoxSize;
    this.kryptonRibbonGroupButton_103.Checked = clsVar.varEditorSet.ShowPoints;
    this.kryptonRibbonGroupButton_7.Checked = clsVar.varEditorSet.ShowBoxSize;
    this.mnu_editshowpoint.Checked = clsVar.varEditorSet.ShowPoints;
    this.kryptonCheckButton_0.Checked = clsVar.varEditorSet.OsnapEntity;
    this.kryptonCheckButton_2.Checked = clsVar.varEditorSet.Ortho;
    this.kryptonCheckButton_1.Checked = clsVar.varEditorSet.OsnapGrid;
    this.comboBox_0.Items.Add((object) "SecondDrawing");
    this.comboBox_0.Items.Add((object) "NoCalculationEntity");
    this.comboBox_0.Items.Add((object) "InvisibleEntity");
    this.comboBox_0.Items.Add((object) buLangTranslate.preDef.Depth);
    this.comboBox_0.SelectedIndex = 0;
    if (clsVar.varEditorRuntimeSet.isSketchMode)
    {
      SketchEntity sketchEntity = new SketchEntity(Plane.XY);
      this.viewport.Entities.Add((Entity) sketchEntity);
      sketchEntity.Edit((IDesign) this.viewport);
      this.viewport.CurrentSketch.ClearHistory();
    }
    this.viewport.Entities.UpdateBoundingBox();
    this.viewport.SetView(viewType.Top);
    this.viewport.Invalidate();
    this.kryptonRibbonGroupButton_6.Checked = clsVar.varEditorRuntimeSet.GridEnable;
    clsInit.appEditor.JobUpdate();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    this.timer_0.Enabled = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_Editor.Captions.Count > 10)
        ;
    }
    catch (Exception ex)
    {
    }
  }

  public void RunCommands() => this.InitCommands.Clear();

  private void timer_0_Tick(object sender, EventArgs e)
  {
    if (this.refImage != null)
    {
      Picture picture = new Picture(Plane.XY, this.refImageSize.Width, this.refImageSize.Height, buImage5.ImageToByteArray(this.refImage));
      picture.Translate(0.0, 0.0, -0.5);
      picture.Selectable = false;
      this.viewport.Entities.Add((Entity) picture);
      this.viewport.SetView(viewType.Top);
      this.viewport.ZoomFit(5);
      this.viewport.Invalidate();
    }
    if (this.entitiesExisting.Count > 0)
    {
      for (int index = 0; index <= this.entitiesExisting.Count - 1; ++index)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(this.entitiesExisting[index], ref copiedEntity);
        if (copiedEntity != null)
          this.viewport.Entities.Add(copiedEntity);
      }
      this.viewport.ZoomFit();
      this.viewport.Invalidate();
    }
    this.entitiesExisting.Clear();
    if (clsVar.varEditorRuntimeSet.isSewingMode)
    {
      if (this.viewport.Layers.Count == 1)
        this.viewport.Layers.AddOrReplace(new Layer("0", Color.Black));
      clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.viewport.Entities);
      this.viewport.SetView(viewType.Top);
      this.viewport.ZoomFit(5);
      this.viewport.Invalidate();
    }
    if (this.fileNameSorted.Length > 1)
    {
      FileInfo fileInfo = new FileInfo(this.fileNameSorted);
      if (fileInfo.Exists)
        Class5.smethod_89(this, fileInfo.FullName);
      this.fileNameSorted = "";
    }
    if (this.fileName.Length > 1)
    {
      if (new FileInfo(this.fileName).Exists)
      {
        clsInit.appEditor.cmdOpen(this.fileName);
        this.viewport.SetView(viewType.Top);
        this.viewport.ZoomFit(5);
        this.viewport.Invalidate();
      }
      this.fileName = "";
    }
    if (this.InitCommands.Count > 0)
      this.RunCommands();
    this.InitCommands.Clear();
    if (this.viewport.Entities.Count == 0 & this.ZoomOutValue > 0)
      this.viewport.ZoomOut(this.ZoomOutValue);
    this.int_0 = 1;
    this.timer_0.Enabled = false;
  }

  public void Viewport_MouseMove(object sender, MouseEventArgs e)
  {
    if (!this.isMovedFirstTime)
      this.isMovedFirstTime = true;
    if (Sketcher2D.entityMouseUnder != null)
    {
      string name = Sketcher2D.entityMouseUnder.GetType().Name;
      this.toolTip_0.Active = true;
      this.toolTip_0.SetToolTip((System.Windows.Forms.Control) this.viewport, name);
    }
    else if ((Sketcher2D.indexLabel < 0 ? 0 : (this.viewport.ActiveViewport.Labels[Sketcher2D.indexLabel] is StackedLabel ? 1 : 0)) != 0)
    {
      string caption = ((StackedLabel) this.viewport.ActiveViewport.Labels[Sketcher2D.indexLabel]).GetType().Name.Replace("Label", string.Empty);
      this.toolTip_0.Active = true;
      this.toolTip_0.SetToolTip((System.Windows.Forms.Control) this.viewport, caption);
    }
    else
    {
      this.toolTip_0.Active = false;
      this.toolTip_0.Hide((IWin32Window) this.viewport);
    }
    this.viewport.Invalidate();
    this.viewport.Refresh();
  }

  public void Viewport_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    SelectedItem underMouseCursor = this.viewport.GetItemUnderMouseCursor(e.Location, true);
    if (underMouseCursor == null)
      return;
    Entity dimension = underMouseCursor.Item as Entity;
    if (this.viewport.CurrentSketch == null)
      return;
    VisualConstraint constraint = this.viewport.CurrentSketch.GetConstraint(dimension);
    if (!(constraint is ValueVisualConstraint))
      return;
    DialogBoxInput dialogBoxInput = new DialogBoxInput();
    if (constraint is AngleVisualConstraint)
    {
      double deg = Utility.RadToDeg(((ValueVisualConstraint) constraint).Value);
      dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[2];
      dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[2];
      dialogBoxInput.Value = Math.Abs(deg);
    }
    else
    {
      if (constraint is LengthVisualConstraint)
      {
        dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[0];
        dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[0];
      }
      else if (constraint is DiameterVisualConstraint)
      {
        dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[19];
        dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[19];
      }
      else if (constraint is LinesDistanceVisualConstraint | constraint is PointLineDistanceVisualConstraint | constraint is PointsDistanceVisualConstraint)
      {
        dialogBoxInput.FormCaption = AppLanguage.CadCamDynamic[135];
        dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[135];
      }
      dialogBoxInput.Value = ((ValueVisualConstraint) constraint).Value;
    }
    dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
    dialogBoxInput.Init();
    dialogBoxInput.SelectAll();
    int num1 = (int) dialogBoxInput.ShowDialog();
    if (dialogBoxInput.Result == DialogResult.OK)
    {
      if (constraint is AngleVisualConstraint)
      {
        double num2 = dialogBoxInput.Value;
        double num3 = (dialogBoxInput.Value > 0.0 ? 1.0 : -1.0) * Math.PI * num2 / 180.0;
        ((ValueVisualConstraint) constraint).Value = num3;
      }
      else
        ((ValueVisualConstraint) constraint).Value = dialogBoxInput.Value;
    }
    for (int index = 0; index <= this.viewport.Entities.Count - 1; ++index)
      this.viewport.Entities[index].Selected = false;
    this.viewport.CurrentSketch.UpdateAndInvalidate();
    this.viewport.Invalidate();
  }

  public void mnu_cmd_Click(object sender, EventArgs e)
  {
    string str = "";
    switch (sender)
    {
      case RibbonButton _:
        str = (sender as RibbonButton).Name;
        break;
      case ToolStripMenuItem _:
        str = (sender as ToolStripMenuItem).Name;
        break;
      case KryptonRibbonGroupButton _:
        str = (sender as KryptonRibbonGroupButton).Tag.ToString();
        break;
      case KryptonRibbonQATButton _:
        str = (sender as KryptonRibbonQATButton).Tag.ToString();
        break;
    }
    if (str == this.kryptonRibbonGroupButton_23.Tag.ToString())
      clsInit.appEditor.cmdNew();
    if (str == this.kryptonRibbonGroupButton_24.Tag.ToString())
      clsInit.appEditor.cmdOpen();
    if (str == this.kryptonRibbonGroupButton_25.Tag.ToString())
      clsInit.appEditor.cmdSave();
    if (str == this.kryptonRibbonGroupButton_105.Tag.ToString())
    {
      try
      {
        F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
        classViewerDialog.FormCaption = "Settings";
        classViewerDialog.Value = (object) clsVar.varEditorSet;
        classViewerDialog.StartPosition = FormStartPosition.CenterParent;
        classViewerDialog.Width = 500;
        classViewerDialog.Height = 750;
        classViewerDialog.ValuePersentage = 35.0;
        classViewerDialog.Init();
        int num = (int) classViewerDialog.ShowDialog();
        if (classViewerDialog.Result == DialogResult.OK)
        {
          clsVar.varEditorSet = new EditorSettings((EditorSettings) classViewerDialog.Value);
          clsInit.appEditor.GridUpdate();
          clsInit.appEditor.SaveEditorFile();
          clsInit.appEditor.JobUpdate();
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (str == this.kryptonRibbonGroupButton_7.Tag.ToString())
    {
      clsVar.varEditorSet.ShowBoxSize = this.kryptonRibbonGroupButton_7.Checked;
      this.viewport.Invalidate();
    }
    else if (str == this.mnu_editshowpoint.Tag.ToString())
    {
      clsVar.varEditorSet.ShowPoints = this.mnu_editshowpoint.Checked;
      this.viewport.Invalidate();
    }
    else
    {
      if (str == this.kryptonRibbonGroupButton_106.Tag.ToString() | str == this.kryptonRibbonQATButton_2.Tag.ToString())
        clsInit.appEditor.UndoGetBack();
      if (str == this.kryptonRibbonGroupButton_0.Tag.ToString() | str == this.kryptonRibbonQATButton_0.Tag.ToString())
      {
        this.viewport.SetView(viewType.Top);
        this.viewport.Invalidate();
      }
      if (str == this.kryptonRibbonGroupButton_3.Tag.ToString() | str == this.kryptonRibbonQATButton_1.Tag.ToString())
      {
        this.viewport.ZoomFit(10);
        this.viewport.Invalidate();
      }
      if (str == this.kryptonRibbonGroupButton_1.Tag.ToString())
      {
        this.viewport.ZoomIn(10);
        this.viewport.Invalidate();
      }
      if (str == this.kryptonRibbonGroupButton_2.Tag.ToString())
      {
        this.viewport.ZoomOut(10);
        this.viewport.Invalidate();
      }
      if (str == this.kryptonRibbonGroupButton_5.Tag.ToString())
      {
        for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
        {
          if (clsItem.frmEditor.viewport.Entities[index].Selected)
          {
            clsItem.frmEditor.viewport.Entities[index].Visible = false;
            clsItem.frmEditor.viewport.Entities[index].Selected = false;
          }
        }
        clsItem.frmEditor.viewport.Invalidate();
      }
      if (str == this.kryptonRibbonGroupButton_4.Tag.ToString())
      {
        for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
        {
          clsItem.frmEditor.viewport.Entities[index].Selected = false;
          clsItem.frmEditor.viewport.Entities[index].Visible = true;
        }
        clsItem.frmEditor.viewport.Invalidate();
      }
      if (!(str == this.kryptonRibbonGroupButton_6.Tag.ToString()))
        return;
      clsVar.varEditorRuntimeSet.GridEnable = !clsVar.varEditorRuntimeSet.GridEnable;
      this.kryptonRibbonGroupButton_6.Checked = clsVar.varEditorRuntimeSet.GridEnable;
      this.viewport.ActiveViewport.Grid.Visible = clsVar.varEditorRuntimeSet.GridEnable;
      this.viewport.Invalidate();
    }
  }

  public void mnu_draw_Click(object sender, EventArgs e)
  {
    string str = "";
    switch (sender)
    {
      case RibbonButton _:
        str = (sender as RibbonButton).Name;
        break;
      case ToolStripMenuItem _:
        str = (sender as ToolStripMenuItem).Name;
        break;
      case KryptonRibbonGroupButton _:
        str = (sender as KryptonRibbonGroupButton).Tag.ToString();
        break;
    }
    Sketcher2D.OrthoPossible = false;
    if (str == this.kryptonRibbonGroupButton_8.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawPoint;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_9.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawLine;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_10.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawCircle;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_11.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawCircle3Point;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_12.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawArc3PointSEM;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_13.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawRectangle;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_14.Tag.ToString())
    {
      DialogBoxInput dialogBoxInput = new DialogBoxInput();
      dialogBoxInput.FormCaption = $"{AppLanguage.CadCamDynamic[70]} {AppLanguage.CadCamDynamic[71]}";
      dialogBoxInput.ValueCaption = AppLanguage.CadCamDynamic[71];
      dialogBoxInput.Value = (double) clsVar.varEditorRuntimeSet.PolygonSide;
      dialogBoxInput.Decimal(0);
      dialogBoxInput.Init();
      dialogBoxInput.SelectAll();
      int num = (int) dialogBoxInput.ShowDialog();
      if (dialogBoxInput.Result == DialogResult.OK)
      {
        clsVar.varEditorRuntimeSet.PolygonSide = (int) dialogBoxInput.Value;
        Sketcher2D.Clicks.Clear();
        clsInit.appEditor.action = actionTypeBU.drawPolygon;
        Sketcher2D.isDrawing = true;
        Sketcher2D.selectionProcess = false;
      }
    }
    if (str == this.kryptonRibbonGroupButton_15.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawEllipse;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_18.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawSpline;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_16.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawSlot;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_17.Tag.ToString())
    {
      F_Barrel fBarrel = new F_Barrel();
      fBarrel.Barrel.Width = clsVar.varEditorRuntimeSet.KeyHoleLength;
      fBarrel.Barrel.Height = clsVar.varEditorRuntimeSet.KeyHoleWidth;
      fBarrel.Barrel.HeadRadius = clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter;
      fBarrel.Barrel.Rotation = clsVar.varEditorRuntimeSet.KeyHoleAngle;
      fBarrel.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      fBarrel.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
      fBarrel.Init();
      int num = (int) fBarrel.ShowDialog();
      if (fBarrel.PropertiesForm.Result == DialogResult.OK)
      {
        clsVar.varEditorRuntimeSet.KeyHoleLength = fBarrel.Barrel.Width;
        clsVar.varEditorRuntimeSet.KeyHoleWidth = fBarrel.Barrel.Height;
        clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter = fBarrel.Barrel.HeadRadius;
        clsVar.varEditorRuntimeSet.KeyHoleAngle = fBarrel.Barrel.Rotation;
        Sketcher2D.Clicks.Clear();
        clsInit.appEditor.action = actionTypeBU.drawKeyHole;
        Sketcher2D.isDrawing = true;
        Sketcher2D.selectionProcess = false;
      }
    }
    if (str == this.kryptonRibbonGroupButton_123.Tag.ToString())
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
    if (str == this.kryptonRibbonGroupButton_20.Tag.ToString() | str == this.kryptonRibbonGroupButton_111.Tag.ToString())
      clsInit.appEditor.cmdEventsCopy();
    if (str == this.kryptonRibbonGroupButton_21.Tag.ToString() | str == this.kryptonRibbonGroupButton_112.Tag.ToString())
      clsInit.appEditor.cmdEventsMove();
    if (str == this.kryptonRibbonGroupButton_22.Tag.ToString())
      clsInit.appEditor.cmdEventsMirror();
    if (str == this.kryptonRibbonGroupButton_30.Tag.ToString())
      clsInit.appEditor.cmdEventsOffset();
    if (str == this.kryptonRibbonGroupButton_27.Tag.ToString())
      clsInit.appEditor.cmdEventsRotate();
    if (str == this.kryptonRibbonGroupButton_28.Tag.ToString())
      clsInit.appEditor.cmdEventsBreak();
    if (str == this.kryptonRibbonGroupButton_29.Tag.ToString())
      clsInit.appEditor.cmdEventsScale();
    if (str == this.kryptonRibbonGroupButton_31.Tag.ToString())
      clsInit.appEditor.cmdEventsExtend();
    if (str == this.kryptonRibbonGroupButton_32.Tag.ToString())
      clsInit.appEditor.cmdEventsTrim();
    if (str == this.kryptonRibbonGroupButton_33.Tag.ToString())
      clsInit.appEditor.cmdEventsFillet();
    if (str == this.kryptonRibbonGroupButton_34.Tag.ToString())
      clsInit.appEditor.cmdEventsChamfer();
    if (str == this.kryptonRibbonGroupButton_35.Tag.ToString())
      clsInit.appEditor.cmdEventsDelete();
    if (str == this.kryptonRibbonGroupButton_94.Tag.ToString())
      clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Left);
    if (str == this.kryptonRibbonGroupButton_95.Tag.ToString())
      clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Right);
    if (str == this.kryptonRibbonGroupButton_96.Tag.ToString())
      clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Top);
    if (str == this.kryptonRibbonGroupButton_97.Tag.ToString())
      clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.Bottom);
    if (str == this.kryptonRibbonGroupButton_98.Tag.ToString())
      clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.HorizontalCenter);
    if (str == this.kryptonRibbonGroupButton_99.Tag.ToString())
      clsInit.appEditor.cmdEventsAlingLeft(AlignmentEvent.VerticalCenter);
    if (str == this.kryptonRibbonGroupButton_100.Tag.ToString())
      clsInit.appEditor.cmdEventsEqualDistance(EqualDistance.Horizontal);
    if (str == this.kryptonRibbonGroupButton_101.Tag.ToString())
      clsInit.appEditor.cmdEventsEqualDistance(EqualDistance.Vertical);
    if (str == this.kryptonRibbonGroupButton_113.Tag.ToString())
      clsInit.appEditor.cmdEventsTurnOver();
    if (str == this.toolStripMenuItem_0.Name.ToString())
      clsInit.appEditor.cmdEventsRotateValue(-90.0);
    if (str == this.toolStripMenuItem_1.Name.ToString())
      clsInit.appEditor.cmdEventsRotateValue(90.0);
    if (str == this.toolStripMenuItem_2.Name.ToString())
      clsInit.appEditor.cmdEventsRotateValue(-180.0);
    if (str == this.toolStripMenuItem_3.Name.ToString())
      clsInit.appEditor.cmdEventsMirrorValue(HorizontalVertical.Horizontal);
    if (str == this.toolStripMenuItem_4.Name.ToString())
      clsInit.appEditor.cmdEventsMirrorValue(HorizontalVertical.Vertical);
    if (str == this.kryptonRibbonGroupButton_108.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawMeasure;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
    }
    if (str == this.kryptonRibbonGroupButton_109.Tag.ToString())
      ;
  }

  public void mnu_lib_Click(object sender, EventArgs e)
  {
    string str = "";
    switch (sender)
    {
      case RibbonButton _:
        str = (sender as RibbonButton).Name;
        break;
      case ToolStripMenuItem _:
        str = (sender as ToolStripMenuItem).Name;
        break;
      case KryptonRibbonGroupButton _:
        str = (sender as KryptonRibbonGroupButton).Tag.ToString();
        break;
    }
    Sketcher2D.OrthoPossible = false;
    Sketcher2D.selectionProcess = false;
    Sketcher2D.isDrawing = false;
    Sketcher2D.isSelectionDone = false;
    if (Sketcher2D.entitiesSelected != null)
      Sketcher2D.entitiesSelected.Clear();
    Sketcher2D.entitySelected = (Entity) null;
    if (str == this.kryptonRibbonGroupButton_38.Tag.ToString())
    {
      if (this.viewport.CurrentSketch != null)
        this.viewport.CurrentSketch.Exit();
      else if ((this.viewport.Entities.Count <= 0 ? 0 : (this.viewport.Entities[0] is SketchEntity ? 1 : 0)) != 0)
        ((SketchEntity) this.viewport.Entities[0]).Exit(false);
      this.viewport.Entities.Clear();
      SketchEntity sketchEntity = new SketchEntity(Plane.XY);
      this.viewport.Entities.Add((Entity) sketchEntity);
      sketchEntity.Edit((IDesign) this.viewport);
      this.viewport.CurrentSketch.ClearHistory();
      this.viewport.CurrentSketch.UpdateAndInvalidate();
      this.viewport.SetView(viewType.Top);
    }
    if (str == this.kryptonRibbonGroupButton_39.Tag.ToString())
      clsInit.appEditor.cmdOpenLib();
    if (str == this.kryptonRibbonGroupButton_40.Tag.ToString() && this.viewport.CurrentSketch != null)
    {
      SketchEntity currentSketch = this.viewport.CurrentSketch;
      this.viewport.CurrentSketch.Exit();
      this.viewport.Entities.Regen();
      this.viewport.Invalidate();
      clsInit.appEditor.cmdSaveLib((Design) this.viewport);
      if ((this.viewport.Entities.Count <= 0 ? 0 : (this.viewport.Entities[0] is SketchEntity ? 1 : 0)) != 0)
        ((SketchEntity) this.viewport.Entities[0]).Edit((IDesign) this.viewport);
      clsInit.appEditor.JobUpdate();
    }
    if (str == this.kryptonRibbonGroupButton_61.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryVertical;
    }
    if (str == this.kryptonRibbonGroupButton_60.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryHorizontal;
    }
    if (str == this.kryptonRibbonGroupButton_46.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryLength;
    }
    if (str == this.kryptonRibbonGroupButton_52.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryFixPoint;
    }
    if (str == this.kryptonRibbonGroupButton_58.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryEqualLength;
    }
    if (str == this.kryptonRibbonGroupButton_59.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryEqualRadius;
    }
    if (str == this.kryptonRibbonGroupButton_57.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryParalel;
    }
    if (str == this.kryptonRibbonGroupButton_56.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryPerpendiculat;
    }
    if (str == this.mnu_libfillet.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor._filletsChamfers = new Tuple<ICurve, ICurve, ICurve>[4];
      clsInit.appEditor.action = actionTypeBU.libraryFillet;
    }
    if (str == this.kryptonRibbonGroupButton_43.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor._filletsChamfers = new Tuple<ICurve, ICurve, ICurve>[4];
      clsInit.appEditor.action = actionTypeBU.libraryChamfer;
    }
    if (str == this.kryptonRibbonGroupButton_49.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryLineLine;
    }
    if (str == this.kryptonRibbonGroupButton_50.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryLinePoint;
    }
    if (str == this.kryptonRibbonGroupButton_51.Tag.ToString())
    {
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        if (clsItem.frmEditor.viewport.Entities[index] is devDept.Eyeshot.Entities.Point | clsItem.frmEditor.viewport.Entities[index] is SketchEntity)
          clsItem.frmEditor.viewport.Entities[index].Selectable = true;
        else
          clsItem.frmEditor.viewport.Entities[index].Selectable = false;
      }
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryPointPoint;
    }
    if (str == this.kryptonRibbonGroupButton_48.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryAngle;
    }
    if (str == this.kryptonRibbonGroupButton_47.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryRadius;
    }
    if (str == this.kryptonRibbonGroupButton_44.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      Sketcher2D.entitySelected = (Entity) null;
      clsInit.appEditor.action = actionTypeBU.libraryOffet;
    }
    if (str == this.kryptonRibbonGroupButton_45.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryMirror;
    }
    if (str == this.kryptonRibbonGroupButton_55.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryCollinear;
    }
    if (str == this.kryptonRibbonGroupButton_54.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.libraryTangent;
    }
    if (str == this.kryptonRibbonGroupButton_41.Tag.ToString())
      clsInit.appEditor.cmdUndo();
    if (str == this.kryptonRibbonGroupButton_42.Tag.ToString())
      clsInit.appEditor.cmdRedo();
    if (!(str == this.kryptonRibbonGroupButton_62.Tag.ToString()))
      return;
    Sketcher2D.Clicks.Clear();
    clsInit.appEditor.action = actionTypeBU.libraryDeleteEntity;
  }

  public void mnu_sewing_Click(object sender, EventArgs e)
  {
    string str = "";
    switch (sender)
    {
      case RibbonButton _:
        str = (sender as RibbonButton).Name;
        break;
      case ToolStripMenuItem _:
        str = (sender as ToolStripMenuItem).Name;
        break;
      case KryptonRibbonGroupButton _:
        str = (sender as KryptonRibbonGroupButton).Tag.ToString();
        break;
    }
    Sketcher2D.OrthoPossible = false;
    if (clsInit.appSewing == null)
      return;
    if (str == this.kryptonRibbonGroupButton_63.Tag.ToString())
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
        for (int index = 0; index <= clsInit.appSewing.SewingBase.MainEntityList.Count - 1; ++index)
          clsInit.appSewing.SewingBase.MainEntityList[index].LayerName = "Default";
        clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, clsItem.frmEditor.viewport.Entities);
        clsItem.frmEditor.viewport.ZoomFit(10);
      }
    }
    if (str == this.kryptonRibbonGroupButton_64.Tag.ToString())
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsSewing.varSewingRunSettings.pathTeachFile;
      saveFileDialog.Filter = "Sewing File (*.sewing)|*.sewing";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        clsSewing.varSewingRunSettings.pathTeachFile = buFile5.GetPath(saveFileDialog.FileName);
        ArrayList StringList = new ArrayList();
        for (int index = 0; index <= clsInit.appSewing.SewingBase.MainEntityList.Count - 1; ++index)
          StringList.AddRange((ICollection) clsInit.appSewing.SewingBase.MainEntityList[index].ToDef(2));
        buFile5.SaveToFile(StringList, saveFileDialog.FileName);
        clsInit.appSewing.SaveSewingFile();
      }
    }
    if (str == this.kryptonRibbonGroupButton_126.Tag.ToString())
      clsInit.appSewing.cmdNew();
    if (str == this.kryptonRibbonGroupButton_127.Tag.ToString())
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
    if (str == this.kryptonRibbonGroupButton_83.Tag.ToString())
      clsInit.appSewing.cmdAddCodes();
    if (str == this.kryptonRibbonGroupButton_75.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawLine;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
      SewingTempVars.DrawCommand = SewingDrawCommand.LineJump;
    }
    if (str == this.kryptonRibbonGroupButton_73.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawLine;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
      SewingTempVars.DrawCommand = SewingDrawCommand.LineStitched;
    }
    if (str == this.kryptonRibbonGroupButton_74.Tag.ToString())
    {
      Sketcher2D.Clicks.Clear();
      clsInit.appEditor.action = actionTypeBU.drawArc3PointSEM;
      Sketcher2D.isDrawing = true;
      Sketcher2D.selectionProcess = false;
      SewingTempVars.DrawCommand = SewingDrawCommand.ArcStitched;
    }
    if (str == this.kryptonRibbonGroupButton_81.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingSorting;
      Sketcher2D.selectionProcess = false;
      clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[41], buLangTranslate.preDef.Sorting);
    }
    if (str == this.kryptonRibbonGroupButton_69.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingDelete;
      Sketcher2D.selectionProcess = true;
      clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[1], buLangTranslate.preDef.Sewing);
    }
    if (str == this.kryptonRibbonGroupButton_86.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingDeleteVertex;
      Sketcher2D.selectionProcess = false;
      clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[10], buLangTranslate.preDef.Sewing);
    }
    if (str == this.kryptonRibbonGroupButton_84.Tag.ToString() && clsInit.appSewing != null)
      clsInit.appSewing.doDeleteAll();
    if (str == this.kryptonRibbonGroupButton_66.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingLockStitch;
      Sketcher2D.selectionProcess = false;
      clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[1], buLangTranslate.preDef.Sewing);
    }
    if (str == this.kryptonRibbonGroupButton_68.Tag.ToString())
    {
      SewingTempVars.DrawType = SewingDrawType.Stitched;
      clsInit.appEditor.action = actionTypeBU.sewingMove;
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[1], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = false;
      }
    }
    if (str == this.kryptonRibbonGroupButton_70.Tag.ToString())
    {
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        if (clsItem.frmEditor.viewport.Entities[index] is Joint)
          clsItem.frmEditor.viewport.Entities[index].Visible = false;
      }
      clsItem.frmEditor.viewport.Invalidate();
      SewingTempVars.DrawType = SewingDrawType.Stitched;
      clsInit.appEditor.action = actionTypeBU.sewingMoveVertex;
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = false;
      }
    }
    if (str == this.toolStripMenuItem_5.Name.ToString())
      clsInit.appSewing.doDeleteProperties();
    if (str == this.mnu_sewingfootheight.Tag.ToString())
    {
      SewingTempVars.DrawType = SewingDrawType.Stitched;
      clsInit.appEditor.action = actionTypeBU.sewingFootHeight;
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = false;
      }
    }
    if (str == this.kryptonRibbonGroupButton_128.Tag.ToString())
    {
      SewingTempVars.DrawType = SewingDrawType.Stitched;
      clsInit.appEditor.action = actionTypeBU.sewingSpeed;
      clsInit.appSewing.Selected.Clear();
      for (int index1 = 0; index1 <= this.viewport.Entities.Count - 1; ++index1)
      {
        if (this.viewport.Entities[index1].Selected)
        {
          for (int index2 = 0; index2 <= clsInit.appSewing.SewingBase.MainEntityList.Count - 1; ++index2)
          {
            if (buCompare5.EQ(clsInit.appSewing.SewingBase.MainEntityList[index2].Vertices, this.viewport.Entities[index1].Vertices))
            {
              for (int index3 = 0; index3 <= clsInit.appSewing.SewingBase.MainEntityList[index2].Sewing.Vertex.Count - 1; ++index3)
                clsInit.appSewing.Selected.Add(new SewingSelectedPoint()
                {
                  EntityIndex = index2,
                  VertexIndex = index3
                });
              clsInit.appSewing.SelectVertexCommand((object) "Ok", (object) 0, (object) true);
              return;
            }
          }
        }
      }
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = false;
      }
    }
    if (str == this.kryptonRibbonGroupButton_87.Tag.ToString())
    {
      SewingTempVars.DrawType = SewingDrawType.Stitched;
      clsInit.appEditor.action = actionTypeBU.sewingChangeDirection;
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[8], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
        Sketcher2D.selectionProcess = false;
      }
    }
    if (str == this.mnu_sewingoffset.Tag.ToString())
      clsInit.appSewing.cmdOffset();
    if (str == this.kryptonRibbonGroupButton_65.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingPunteriz;
      Sketcher2D.selectionProcess = false;
      clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[0], buLangTranslate.preDef.Sewing);
    }
    if (str == this.mnu_sewingrotate.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingRotate;
      Sketcher2D.selectionProcess = false;
      clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[2], buLangTranslate.preDef.Sewing);
    }
    if (str == this.mnu_sewingscale.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingScale;
      Sketcher2D.selectionProcess = false;
      clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[3], buLangTranslate.preDef.Sewing);
    }
    if (str == this.kryptonRibbonGroupButton_76.Tag.ToString())
      clsInit.appSewing.cmdSimilationStart();
    if (str == this.kryptonRibbonGroupButton_77.Tag.ToString())
      clsInit.appSewing.cmdSimilationStop();
    if (str == this.kryptonRibbonGroupButton_78.Tag.ToString())
      clsInit.appSewing.cmdSimilationPrevius(1);
    if (str == this.kryptonRibbonGroupButton_79.Tag.ToString())
      clsInit.appSewing.cmdSimilationNext(1);
    if (str == this.kryptonRibbonGroupButton_80.Tag.ToString())
      ;
    if (str == this.mnu_sewingstitchtable.Tag.ToString())
      clsInit.appSewing.cmdShowTable(ref clsInit.appSewing.SewingBase, ref clsInit.appSewing.SewingTableList);
    if (str == this.kryptonRibbonGroupButton_71.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingJumpToStitch;
      Sketcher2D.entitiesSelected.Clear();
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appSewing.cmdJumpToStitch();
        clsInit.appEditor.Reset();
        clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.viewport.Entities);
      }
    }
    if (str == this.kryptonRibbonGroupButton_72.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingStitchToJump;
      Sketcher2D.entitiesSelected.Clear();
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appSewing.cmdStitchToJump();
        clsInit.appEditor.Reset();
        clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.viewport.Entities);
      }
    }
    if (str == this.kryptonRibbonGroupButton_67.Tag.ToString())
    {
      clsInit.appEditor.action = actionTypeBU.sewingChangeStitchLen;
      Sketcher2D.entitiesSelected.Clear();
      clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, false, ref Sketcher2D.entitiesSelected);
      if (Sketcher2D.entitiesSelected.Count == 0)
      {
        clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Move);
        Sketcher2D.selectionProcess = true;
      }
      else
      {
        clsInit.appSewing.cmdChangeStitchLength(Sketcher2D.entitiesSelected, clsSewing.varSewingRunSettings.ShowDialog);
        clsInit.appEditor.Reset();
        clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, this.viewport.Entities);
      }
    }
    if (!(str == this.kryptonRibbonGroupButton_85.Tag.ToString()) || clsInit.appSewing == null)
      return;
    clsInit.appSewing.UndoGetBack();
  }

  public void mnu_foam_Click(object sender, EventArgs e)
  {
    string str = "";
    switch (sender)
    {
      case RibbonButton _:
        str = (sender as RibbonButton).Name;
        break;
      case ToolStripMenuItem _:
        str = (sender as ToolStripMenuItem).Name;
        break;
      case KryptonRibbonGroupButton _:
        str = (sender as KryptonRibbonGroupButton).Tag.ToString();
        break;
    }
    if (str == this.kryptonRibbonGroupButton_102.Tag.ToString())
      clsVar.varEditorSet.ShowBoxSize = this.kryptonRibbonGroupButton_102.Checked;
    else if (str == this.kryptonRibbonGroupButton_103.Tag.ToString())
      clsVar.varEditorSet.ShowPoints = this.kryptonRibbonGroupButton_103.Checked;
    else if (str == this.kryptonRibbonGroupButton_91.Tag.ToString())
    {
      if (buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[29]) != DialogResult.Yes)
        return;
      clsInit.appEditor.ClearSortThings();
    }
    else if (str == this.kryptonRibbonGroupButton_114.Tag.ToString())
    {
      try
      {
        F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
        classViewerDialog.FormCaption = "Settings";
        classViewerDialog.Value = (object) buFoamCalc.varFoamEditorSettings;
        classViewerDialog.StartPosition = FormStartPosition.CenterParent;
        classViewerDialog.Width = 500;
        classViewerDialog.Height = 400;
        classViewerDialog.ValuePersentage = 35.0;
        classViewerDialog.Init();
        int num = (int) classViewerDialog.ShowDialog();
        if (classViewerDialog.Result != DialogResult.OK)
          return;
        buFoamCalc.varFoamEditorSettings = new FoamEditorSettings((FoamEditorSettings) classViewerDialog.Value);
        clsVar.varEditorSet.colorDrawingPoints = buFoamCalc.varFoamEditorSettings.VirtualColor;
        this.viewport.Invalidate();
        clsInit.appFoamCutting.SaveFoamFile();
      }
      catch (Exception ex)
      {
      }
    }
    else if (str == this.kryptonRibbonGroupButton_115.Tag.ToString())
    {
      if (!buFoamCalc.varFoamRunSettings.ShowVirtualDrawings)
      {
        buFoamCalc.varFoamRunSettings.ShowVirtualDrawings = true;
        clsInit.appFoamCutting.doShowVirtualDrawings();
        this.kryptonRibbonGroupButton_115.Checked = buFoamCalc.varFoamRunSettings.ShowVirtualDrawings;
      }
      else
      {
        buFoamCalc.varFoamRunSettings.ShowVirtualDrawings = false;
        this.kryptonRibbonGroupButton_115.Checked = buFoamCalc.varFoamRunSettings.ShowVirtualDrawings;
        Sketcher2D.DrawingPoints.Clear();
      }
      this.viewport.Invalidate();
    }
    else if (str == this.kryptonRibbonGroupButton_93.Tag.ToString())
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Foam Pattern File (*.foampattern)|*.foampattern";
      saveFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamPattern;
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      buFoamCalc.varFoamRunSettings.pathFoamPattern = buFile5.GetPath(saveFileDialog.FileName);
      clsInit.appEditor.SaveSortedEntities(saveFileDialog.FileName);
      clsInit.appFoamCutting.SaveFoamFile();
    }
    else if (str == this.kryptonRibbonGroupButton_92.Tag.ToString())
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Foam Pattern File (*.foampattern)|*.foampattern";
      openFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamPattern;
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      Class5.smethod_89(this, openFileDialog.FileName);
    }
    else
    {
      Sketcher2D.OrthoPossible = false;
      if (str == this.kryptonRibbonGroupButton_104.Tag.ToString() && clsInit.appEditor.sortedEntities.Count > 0)
      {
        for (int index = 0; index <= clsInit.appEditor.sortRefEntities.Count - 1; ++index)
        {
          if (clsInit.appEditor.sortedEntities[clsInit.appEditor.sortedEntities.Count - 1].Info.ID == clsInit.appEditor.sortRefEntities[index].Info.ID)
          {
            clsInit.appEditor.sortRefEntities[index].Info.CamSelected = false;
            if (clsInit.appEditor.sortRefEntities[index].Info.CamSelectedCount > 0)
              --clsInit.appEditor.sortRefEntities[index].Info.CamSelectedCount;
          }
        }
        clsInit.appEditor.sortedEntities.RemoveAt(clsInit.appEditor.sortedEntities.Count - 1);
        if (clsInit.appEditor.sortedEntities.Count > 0)
        {
          Point3D pntEnd = new Point3D();
          clsInit.cVector5.GetEntityEndPointByCamDirection(clsInit.appEditor.sortedEntities[clsInit.appEditor.sortedEntities.Count - 1], ref pntEnd);
          clsInit.appEditor.ManuelSortClickResult.LastPoint = pntEnd;
          buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(pntEnd);
          buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd);
        }
        else
          clsInit.appEditor.ClearSortThings();
        clsInit.appFoamCutting.doShowVirtualDrawings();
        this.viewport.Invalidate();
      }
      if (str == this.kryptonRibbonGroupButton_89.Tag.ToString() && buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[124]) == DialogResult.Yes)
      {
        clsInit.appEditor.ClearSortThings();
        clsInit.appFoamCutting.doShowVirtualDrawings();
      }
      if (str == this.kryptonRibbonGroupButton_88.Tag.ToString())
      {
        this.pnl_foamsort.Visible = true;
        if (clsInit.appEditor.sortRefEntities.Count == 0)
        {
          for (int index = 0; index <= this.viewport.Entities.Count - 1; ++index)
          {
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(this.viewport.Entities[index], ref copiedEntity);
            if (copiedEntity != null)
            {
              copiedEntity.Info.ID = (index + 1).ToString();
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
      if (str == this.kryptonRibbonGroupButton_90.Tag.ToString())
      {
        if (clsInit.appEditor.sortRefEntities.Count == 0)
        {
          for (int index = 0; index <= this.viewport.Entities.Count - 1; ++index)
          {
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(this.viewport.Entities[index], ref copiedEntity);
            if (copiedEntity != null)
              clsInit.appEditor.sortRefEntities.Add(copiedEntity);
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
      if (str == this.kryptonRibbonGroupButton_117.Tag.ToString())
        clsInit.appEditor.cmdSimStart();
      if (str == this.kryptonRibbonGroupButton_118.Tag.ToString())
        clsInit.appEditor.cmdSimStop();
      if (str == this.kryptonRibbonGroupButton_119.Tag.ToString())
        clsInit.appEditor.cmdSimBwd();
      if (!(str == this.kryptonRibbonGroupButton_120.Tag.ToString()))
        return;
      clsInit.appEditor.cmdSimFwd();
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control.Name == this.chk_showcontrraint.Name)
      clsInit.appEditor.cmdShowContrraint(this.chk_showcontrraint.Checked);
    if (!(control.Name == this.chk_showdims.Name))
      return;
    clsInit.appEditor.cmdShowDimension(this.chk_showdims.Checked);
  }

  internal void method_3(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Escape)
      return;
    clsInit.appEditor.Reset();
  }

  internal void method_4(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control.Name == this.button_1.Name)
      this.panel_2.Visible = true;
    if (control.Name == this.kryptonCheckButton_0.Name)
    {
      clsVar.varEditorSet.OsnapEntity = this.kryptonCheckButton_0.Checked;
      clsInit.appEditor.SaveEditorFile();
    }
    if (control.Name == this.kryptonCheckButton_1.Name)
    {
      clsVar.varEditorSet.OsnapGrid = this.kryptonCheckButton_1.Checked;
      clsInit.appEditor.SaveEditorFile();
    }
    if (control.Name == this.kryptonCheckButton_2.Name)
    {
      clsVar.varEditorSet.Ortho = this.kryptonCheckButton_2.Checked;
      clsInit.appEditor.SaveEditorFile();
    }
    if (control.Name == this.button_3.Name && clsInit.appEditor.SelectedDrawing >= 0 | this.viewport.ActionMode == devDept.Eyeshot.actionType.SelectByBox && this.comboBox_0.Text.Trim().Length > 0)
    {
      string Command = this.comboBox_0.Text.Trim();
      if (this.comboBox_0.Text.Trim() == buLangTranslate.preDef.Depth)
        Command = $"{buLangTranslate.preDef.Depth} = {this.numericUpDown_0.Value.ToString("f2")}";
      clsInit.appEditor.AddCommandToDrawing(Command, clsInit.appEditor.SelectedDrawing);
      this.panel_2.Visible = false;
    }
    if (control.Name == this.button_0.Name)
      clsInit.appEditor.RemoveCommandFromDrawing(this.lst_command.SelectedIndex, clsInit.appEditor.SelectedDrawing);
    if (!(control.Name == this.button_2.Name))
      return;
    this.panel_2.Visible = false;
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (this.comboBox_0.Text == buLangTranslate.preDef.Depth)
    {
      this.label_1.Text = buLangTranslate.preDef.Depth;
      this.label_1.Visible = true;
      this.numericUpDown_0.Visible = true;
    }
    else
    {
      this.label_1.Visible = false;
      this.numericUpDown_0.Visible = false;
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (this.radioButton_3.Checked)
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.CCW;
    else if (this.radioButton_4.Checked)
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.CW;
    else if (this.radioButton_2.Checked)
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.FirstDirectionThenAuto;
    else if (this.radioButton_6.Checked)
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.HigherIndex;
    else if (this.radioButton_5.Checked)
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.Jump;
    else if (this.radioButton_1.Checked)
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.LowerIndex;
    else if (this.radioButton_0.Checked)
    {
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.None;
    }
    else
    {
      if (!this.radioButton_7.Checked)
        return;
      clsVar.varEditorSet.SortFirstCatchRule = SortingFirstCatchRulesType.Manuel;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
