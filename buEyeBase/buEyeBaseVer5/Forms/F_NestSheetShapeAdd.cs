// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestSheetShapeAdd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NestSheetShapeAdd : Form
{
  internal ImageList \u0001;
  public static byte f000E33;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<BendingLRAMaterialData> BendingList;
  public string strRemoveCaption;
  public string pathLRA;
  public int RowIndex;
  public int ColIndex;
  public Design viewportPart;
  private Timer \u0001;
  public PipeBendJob Job;
  internal IContainer \u0001;
  internal DataGridView \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0001;
  public Button btn_remove;
  public Button btn_add;
  internal Panel \u0001;
  internal Label \u0001;
  public Button btn_canceldata;
  public Button btn_adddata;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal Label \u0003;

  public void NestingUpdate(ref TreeView tree, List<buNestedResult> nestResult)
  {
    tree.Nodes.Clear();
    for (int index = 0; index <= nestResult.Count - 1; ++index)
    {
      TreeNode node = new TreeNode(buEyeBaseVer5.Apps.ProfileItem.ResultItemFormat(nestResult[index]));
      node.ImageIndex = 0;
      node.SelectedImageIndex = 0;
      if (((buEyeBaseVer5.Apps.ProfileOperationData) nestResult[index]).NotNestedAll)
        node.ForeColor = Color.Red;
      node.Tag = (object) index;
      for (int Index = 0; Index <= ((buEyeBaseVer5.Apps.ProfileOperationData) nestResult[index]).NestedResultSheets.Count - 1; ++Index)
        node.Nodes.Add(new TreeNode(buEyeBaseVer5.Apps.ProfileItem.SheetItemFormat(nestResult[index], ((F_NestPartAddV2) this).strSheetName, Index))
        {
          ImageIndex = 1,
          SelectedImageIndex = 1,
          Tag = (object) Index,
          ForeColor = Color.Green
        });
      if (((buEyeBaseVer5.Apps.ProfileOperationData) nestResult[index]).NestedResultSheets.Count > 0)
        tree.Nodes.Add(node);
    }
  }

  internal void \u0001([In] object obj0, [In] TreeViewEventArgs obj1)
  {
    if (obj1.Node != null)
      ((F_PanelCutNestSheetPartList) this).\u0001 = obj1.Node;
    if (obj1.Node.Parent != null)
    {
      if (obj1.Node.Tag != null)
      {
        int int32_1 = Convert.ToInt32(obj1.Node.Tag.ToString());
        int int32_2 = Convert.ToInt32(obj1.Node.Parent.Tag.ToString());
        ((F_PanelCutNestSheetPartList) this).\u0001 = obj1.Node.Text;
        ((F_PanelCutNestSheetPartList) this).\u0002 = int32_2;
        ((F_PanelCutNestSheetPartList) this).\u0001 = int32_1;
        ((F_PanelCutNestSheetPartList) this).\u0001.Text = buEyeBaseVer5.Apps.ProfileItem.NestedSheetInfo(buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32_2], int32_1, ((ProfileSupportBlock) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32_2]).Parameters).ProgramSettings);
        if (((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileSupportBlock) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32_2]).Parameters).ProgramSettings).CalculationShowFormat == nestCalculationShowFormat.MultiSheet)
        {
          double num1 = 0.0;
          double num2 = 0.0;
          for (int index1 = 0; index1 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1; ++index1)
          {
            for (int index2 = 0; index2 <= ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index1]).NestedResultSheets.Count - 1; ++index2)
            {
              num2 += ((buEyeBaseVer5.Apps.ProfileOperationDataCut) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index1]).NestedResultSheets[index2]).UsingPersentage;
              ++num1;
            }
          }
          if (num1 > 0.0)
            ((F_PanelCutNestSheetPartList) this).\u0001.Text = $"{((F_PanelCutNestSheetPartList) this).\u0001.Text}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Efficiency}{(num2 / num1).ToString("f2")}";
        }
        else if (((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileSupportBlock) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32_2]).Parameters).ProgramSettings).CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
        {
          double num3 = 0.0;
          double num4 = 0.0;
          for (int index3 = 0; index3 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1; ++index3)
          {
            for (int index4 = 0; index4 <= ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index3]).NestedResultSheets.Count - 1; ++index4)
            {
              num4 += ((buEyeBaseVer5.Apps.ProfileOperationDataCut) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index3]).NestedResultSheets[index4]).UsingPersentageFromMaxX;
              ++num3;
            }
          }
          if (num3 > 0.0)
            ((F_PanelCutNestSheetPartList) this).\u0001.Text = $"{((F_PanelCutNestSheetPartList) this).\u0001.Text}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Efficiency} : %{(num4 / num3).ToString("f2")}";
        }
        \u0007.\u0001.\u0001((F_NestedResults) this);
        // ISSUE: reference to a compiler-generated field
        if (((F_NestPartAddV2) this).\u0001 != null)
        {
          buNestedResultSentEventArg Data = (buNestedResultSentEventArg) new buEyeBaseVer5.Apps.ProfileOperationDataCut();
          ((ProfileTempVars) Data).IndexPart = -1;
          ((ProfileTempVars) Data).IndexResult = int32_2;
          ((ProfileTempVars) Data).IndexSheet = int32_1;
          ((ProfileTempVars) Data).NestResult = (buNestedResult) new buEyeBaseVer5.Apps.ProfileOperationData(buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32_2]);
          // ISSUE: reference to a compiler-generated field
          ((F_NestPartAddV2) this).\u0001((object) Data);
          ((F_NestPartAddV2) this).viewport.SetView(viewType.Top, true, false);
        }
      }
    }
    else
    {
      ((F_PanelCutNestSheetPartList) this).\u0001 = obj1.Node.Text;
      int int32 = Convert.ToInt32(obj1.Node.Tag.ToString());
      ((F_PanelCutNestSheetPartList) this).\u0002 = int32;
      ((F_PanelCutNestSheetPartList) this).\u0001 = -1;
      ((F_PanelCutNestSheetPartList) this).\u0001.Text = ProfileItemCalc.NestedResultInfo(buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32], ((ProfileSupportBlock) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32]).Parameters).ProgramSettings);
      if (((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileSupportBlock) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32]).Parameters).ProgramSettings).CalculationShowFormat == nestCalculationShowFormat.MultiSheet)
      {
        double num5 = 0.0;
        double num6 = 0.0;
        for (int index5 = 0; index5 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1; ++index5)
        {
          for (int index6 = 0; index6 <= ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index5]).NestedResultSheets.Count - 1; ++index6)
          {
            num6 += ((buEyeBaseVer5.Apps.ProfileOperationDataCut) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index5]).NestedResultSheets[index6]).UsingPersentage;
            ++num5;
          }
        }
        if (num5 > 0.0)
          ((F_PanelCutNestSheetPartList) this).\u0001.Text = $"{((F_PanelCutNestSheetPartList) this).\u0001.Text}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Efficiency}{(num6 / num5).ToString("f2")}";
      }
      else if (((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileSupportBlock) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32]).Parameters).ProgramSettings).CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
      {
        double num7 = 0.0;
        double num8 = 0.0;
        double num9 = 0.0;
        for (int index7 = 0; index7 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1; ++index7)
        {
          for (int index8 = 0; index8 <= ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index7]).NestedResultSheets.Count - 1; ++index8)
          {
            num8 += ((buEyeBaseVer5.Apps.ProfileOperationDataCut) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index7]).NestedResultSheets[index8]).UsingPersentageFromMaxX;
            num9 += ((buEyeBaseVer5.Apps.ProfileOperationDataNotch) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[index7]).NestedResultSheets[index8]).SheetMaxXPosition;
            ++num7;
          }
        }
        if (num7 > 0.0)
        {
          ((F_PanelCutNestSheetPartList) this).\u0001.Text = $"{((F_PanelCutNestSheetPartList) this).\u0001.Text}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Efficiency} : %{(num8 / num7).ToString("f2")}{Environment.NewLine}";
          ((F_PanelCutNestSheetPartList) this).\u0001.Text = $"{((F_PanelCutNestSheetPartList) this).\u0001.Text}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Pastal} {buLangTranslate.preDef.Length} : {num9.ToString("f2")} mm";
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_NestPartAddV2) this).\u0001 != null)
      {
        buNestedResultSentEventArg Data = (buNestedResultSentEventArg) new buEyeBaseVer5.Apps.ProfileOperationDataCut();
        ((ProfileTempVars) Data).IndexPart = -1;
        ((ProfileTempVars) Data).IndexResult = int32;
        ((ProfileTempVars) Data).IndexSheet = -1;
        ((ProfileTempVars) Data).NestResult = (buNestedResult) new buEyeBaseVer5.Apps.ProfileOperationData(buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32]);
        // ISSUE: reference to a compiler-generated field
        ((F_NestPartAddV2) this).\u0001((object) Data);
        ((F_NestPartAddV2) this).viewport.SetView(viewType.Top, true, false);
      }
    }
    GC.Collect();
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_PanelCutNestSheetPartList) this).\u0002 >= 0 & ((F_PanelCutNestSheetPartList) this).\u0002 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1) || !(((F_PanelCutNestSheetPartList) this).\u0001 >= 0 & ((F_PanelCutNestSheetPartList) this).\u0001 <= ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestedResultSheets.Count - 1))
      return;
    if (((F_PanelCutNestSheetPartList) this).\u0001)
    {
      if (!((buEyeBaseVer5.Apps.ProfileOperationDataEllipse) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestedResultSheets[((F_PanelCutNestSheetPartList) this).\u0001]).DontUse)
        ((buEyeBaseVer5.Apps.ProfileOperationDataEllipse) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestedResultSheets[((F_PanelCutNestSheetPartList) this).\u0001]).DontUse = true;
      else
        ((buEyeBaseVer5.Apps.ProfileOperationDataEllipse) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestedResultSheets[((F_PanelCutNestSheetPartList) this).\u0001]).DontUse = false;
    }
    \u0007.\u0001.\u0001((F_NestedResults) this);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (control.Name == ((F_PanelCutNestSheetPartList) this).\u0001.Name)
      ((F_PanelCutNestSheetPartList) this).\u0005.Visible = true;
    if (control.Name == ((F_PanelCutNestSheetPartList) this).\u000E.Name)
      ((F_PanelCutNestSheetPartList) this).\u0005.Visible = false;
    if (!(control.Name == ((F_PanelCutNestSheetPartList) this).\u000F.Name))
      return;
    ((ProfileOperationCamData) ((ProfileMultiply) ((F_NestPartAddV2) this).NestParameters).ResultSettings).DrawAddToEnd = ((F_PanelCutNestSheetPartList) this).chk_addentitiestoend.Checked;
    ((ProfileOperationCamData) ((ProfileMultiply) ((F_NestPartAddV2) this).NestParameters).ResultSettings).DrawAddClearAll = ((F_PanelCutNestSheetPartList) this).chk_clearalldrawing.Checked;
    ((ProfileOperationCamData) ((ProfileMultiply) ((F_NestPartAddV2) this).NestParameters).ResultSettings).DrawAddToEndOffset = (double) ((F_PanelCutNestSheetPartList) this).\u0001.Value;
    ((F_PanelCutNestSheetPartList) this).\u0005.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (control.Name == ((F_PanelCutNestSheetPartList) this).\u0004.Name)
    {
      ((F_NestPartAddV2) this).viewport.SetView(viewType.Isometric);
      ((F_NestPartAddV2) this).viewport.Invalidate();
    }
    if (control.Name == ((F_PanelCutNestSheetPartList) this).\u0005.Name)
    {
      ((F_NestPartAddV2) this).viewport.SetView(viewType.Top);
      ((F_NestPartAddV2) this).viewport.Invalidate();
    }
    if (control.Name == ((F_PanelCutNestSheetPartList) this).\u0006.Name)
    {
      ((F_NestPartAddV2) this).viewport.ZoomFit(1);
      ((F_NestPartAddV2) this).viewport.Invalidate();
    }
    if (control.Name == ((F_PanelCutNestSheetPartList) this).\u0007.Name)
    {
      if (((F_NestPartAddV2) this).viewport.ActionMode != devDept.Eyeshot.actionType.Pan)
        ((F_NestPartAddV2) this).viewport.ActionMode = devDept.Eyeshot.actionType.Pan;
      else
        ((F_NestPartAddV2) this).viewport.ActionMode = devDept.Eyeshot.actionType.None;
      ((F_NestPartAddV2) this).viewport.Invalidate();
    }
    if (!(control.Name == ((F_PanelCutNestSheetPartList) this).\u0008.Name))
      return;
    if (((F_NestPartAddV2) this).viewport.ActionMode != devDept.Eyeshot.actionType.Rotate)
      ((F_NestPartAddV2) this).viewport.ActionMode = devDept.Eyeshot.actionType.Rotate;
    else
      ((F_NestPartAddV2) this).viewport.ActionMode = devDept.Eyeshot.actionType.None;
    ((F_NestPartAddV2) this).viewport.Invalidate();
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1) => this.Visible = false;

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
    ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem) obj0;
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0001.Name && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[12]) == DialogResult.Yes && ((F_PanelCutNestSheetPartList) this).\u0002 >= 0 & ((F_PanelCutNestSheetPartList) this).\u0002 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1)
    {
      buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.RemoveAt(((F_PanelCutNestSheetPartList) this).\u0002);
      ((F_NestExecute) this).Init();
      if (((F_PanelCutNestSheetPartList) this).tree_nest.Nodes.Count > 0)
      {
        ((F_PanelCutNestSheetPartList) this).tree_nest.SelectedNode = ((F_PanelCutNestSheetPartList) this).tree_nest.Nodes[0];
      }
      else
      {
        ((F_NestPartAddV2) this).viewport.Entities.Clear();
        ((F_NestPartAddV2) this).viewport.Invalidate();
      }
    }
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0002.Name && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[13]) == DialogResult.Yes)
    {
      buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Clear();
      ((F_NestExecute) this).Init();
      ((F_NestPartAddV2) this).viewport.Entities.Clear();
      ((F_NestPartAddV2) this).viewport.Invalidate();
    }
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0003.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = ((ProfileTempVars) ((F_NestPartAddV2) this).RunParameter).pathNesting;
      openFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        ((ProfileTempVars) ((F_NestPartAddV2) this).RunParameter).pathNesting = buFile5.bunesting.GetPath(openFileDialog.FileName);
        buFile5.bunesting bunesting = (buFile5.bunesting) new buVector5();
        buNestedResult Result = (buNestedResult) new ProfileOperationPolygon();
        List<buNestingPart> Parts = new List<buNestingPart>();
        List<buNestingSheet> Sheets = new List<buNestingSheet>();
        buNestingVar Parameters = (buNestingVar) new buEyeBaseVer5.Apps.ProfileOperationDataBarel();
        ((buVector5) bunesting).OpenNesting(openFileDialog.FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
        // ISSUE: reference to a compiler-generated field
        if (((F_NestPartAddV2) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_NestPartAddV2) this).\u0002((object) ((F_NestPartAddV2) this).RunParameter);
          buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Add(Result);
          this.NestingUpdate(ref ((F_PanelCutNestSheetPartList) this).tree_nest, buEyeBaseVer5.Apps.ProfileItem.NestedAllResults);
        }
      }
    }
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0004.Name && ((F_PanelCutNestSheetPartList) this).\u0002 >= 0 & ((F_PanelCutNestSheetPartList) this).\u0002 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = ((ProfileTempVars) ((F_NestPartAddV2) this).RunParameter).pathNesting;
      saveFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        ((ProfileTempVars) ((F_NestPartAddV2) this).RunParameter).pathNesting = buFile5.bunesting.GetPath(saveFileDialog.FileName);
        new buVector5().SaveNesting(saveFileDialog.FileName, ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestingPartsList, ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestingSheetList, buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002], ((F_NestPartAddV2) this).NestParameters);
        // ISSUE: reference to a compiler-generated field
        if (((F_NestPartAddV2) this).\u0002 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_NestPartAddV2) this).\u0002((object) ((F_NestPartAddV2) this).RunParameter);
        }
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0006.Name && ((F_NestPartAddV2) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_NestPartAddV2) this).\u0001((object) "", (object) "ShowSheetPart");
    }
    // ISSUE: reference to a compiler-generated field
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0005.Name && ((F_NestPartAddV2) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_NestPartAddV2) this).\u0001((object) "", (object) "ShowFolder");
    }
    // ISSUE: reference to a compiler-generated field
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0007.Name && ((F_NestPartAddV2) this).\u0001 != null && ((F_PanelCutNestSheetPartList) this).\u0002 >= 0 & ((F_PanelCutNestSheetPartList) this).\u0002 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_NestPartAddV2) this).\u0001((object) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestingPartsList, (object) "SendParts");
    }
    // ISSUE: reference to a compiler-generated field
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u0008.Name && ((F_NestPartAddV2) this).\u0001 != null && ((F_PanelCutNestSheetPartList) this).\u0002 >= 0 & ((F_PanelCutNestSheetPartList) this).\u0002 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_NestPartAddV2) this).\u0001((object) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestingSheetList, (object) "SendSheets");
    }
    // ISSUE: reference to a compiler-generated field
    if (toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u000F.Name && ((F_NestPartAddV2) this).\u0001 != null && ((F_PanelCutNestSheetPartList) this).\u0002 >= 0 & ((F_PanelCutNestSheetPartList) this).\u0002 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_NestPartAddV2) this).\u0001((object) ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[((F_PanelCutNestSheetPartList) this).\u0002]).NestedResultSheets, (object) "CreateRemnant");
    }
    if (!(toolStripMenuItem2.Name == ((F_PanelCutNestSheetPartList) this).\u000E.Name) || ((F_PanelCutNestSheetPartList) this).\u0001 == null)
      return;
    if (((F_PanelCutNestSheetPartList) this).\u0001.Parent == null)
    {
      int int32 = Convert.ToInt32(((F_PanelCutNestSheetPartList) this).\u0001.Tag.ToString());
      if (!(int32 >= 0 & int32 <= buEyeBaseVer5.Apps.ProfileItem.NestedAllResults.Count - 1))
        return;
      string jobName = ((buEyeBaseVer5.Apps.ProfileOperationData) buEyeBaseVer5.Apps.ProfileItem.NestedAllResults[int32]).JobName;
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = ((F_NestPartAddV2) this).pathSaveImage;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      ((F_NestPartAddV2) this).pathSaveImage = folderBrowserDialog.SelectedPath;
      for (int index = 0; index <= ((F_PanelCutNestSheetPartList) this).tree_nest.Nodes[int32].Nodes.Count - 1; ++index)
      {
        ((F_PanelCutNestSheetPartList) this).tree_nest.SelectedNode = ((F_PanelCutNestSheetPartList) this).tree_nest.Nodes[int32].Nodes[index];
        ((F_PanelCutNestSheetPartList) this).tree_nest.Refresh();
        Application.DoEvents();
      }
    }
    else
    {
      ((F_PanelCutNestSheetPartList) this).tree_nest.SelectedNode = ((F_PanelCutNestSheetPartList) this).\u0001.Parent;
      this.\u0006((object) ((F_PanelCutNestSheetPartList) this).\u000E, (EventArgs) null);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_PanelCutNestSheetPartList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_PanelCutNestSheetPartList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_NestSheetShapeAdd() => F_NestPartAddV2.Captions = new List<string>();
}
