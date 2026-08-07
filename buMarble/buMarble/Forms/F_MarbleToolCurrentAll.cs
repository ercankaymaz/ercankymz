// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleToolCurrentAll
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleToolCurrentAll : Form
{
  internal DataGridView \u0003;
  public static byte f000678;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public List<ToolBase5> Tools;
  public int indexTool;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  internal DataGridView \u0001;
  public buButton btn_remove;
  public buButton btn_add;
  public buButton btn_edit;
  internal ImageList \u0001;
  public Panel pnl_preview;
  public buButton btn_toolsave;
  public buButton btn_toolopen;
  public static byte f00068D;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  public int SelectedTab = 0;
  internal IContainer \u0001 = (IContainer) null;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_opentools;
  public buButton btn_savetools;
  public buTab buTab_tools;
  public TabPage tabPage_saw;
  public TabPage tabPage_mlling;
  internal Panel \u0001;
  public buButton btn_saw_activate;
  public buButton btn_saw_zeroposition;
  public buButton btn_sawgonyele;
  public buButton btn_sawlimitdisable;
  public buButton btn_saw_measure;
  public buSpin spn_sawspeed;
  public buSpin spn_sawthickness;
  public buSpin spn_sawdia;
  public buButton btn_milling_activate;
  public buButton btn_milling_zeroposition;
  public buButton btn_milling_limitdisable;
  public buButton btn_milling_measure;
  public buSpin spn_milling_speed;
  public buSpin spn_milling_length;
  public buSpin spn_milling_diameter;
  internal Panel \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal TabPage \u0001;
  internal Panel \u0003;
  internal PictureBox \u0003;
  public buButton btn_millinghead_activate;
  public buButton btn_millinghead_zeroposition;
  public buButton btn_millinghead_limitdisable;
  public buButton btn_millinghead_measure;
  public buSpin spn_millinghead_speed;
  public buSpin spn_millinghead_length;
  public buSpin spn_millinghead_diameter;
  public buButton btn_toolstop;
  public buButton btn_millingheadtool;
  public buButton btn_millingtool;
  public buButton btn_sawtool;
  public buButton btn_closecross;
  public buButton btn_toollist;
  public buButton btn_saw_settings;
  public buButton btn_milling_edit;
  public buButton btn_milling_settings;
  public buButton btn_millinghead_edit;
  public buButton btn_millinghead_settings;
  public buButton btn_magazine;
  internal TabPage \u0002;
  public buSpin spn_toolmagapeed1;
  public buSpin spn_toolmaglen1;
  public buSpin spn_toolmagdia1;
  internal Panel \u0004;
  public buButton btn_toolmagtake10;
  public buSpin spn_toolmagdia10;
  public buButton btn_toolmagset10;
  public buSpin spn_toolmaglen10;
  public buSpin spn_toolmagapeed10;
  internal Panel \u0005;
  public buButton btn_toolmagtake9;
  public buSpin spn_toolmagdia9;
  public buButton btn_toolmagset9;
  public buSpin spn_toolmaglen9;
  public buSpin spn_toolmagapeed9;
  internal Panel \u0006;
  public buButton btn_toolmagtake8;
  public buSpin spn_toolmagdia8;
  public buButton btn_toolmagset8;
  public buSpin spn_toolmaglen8;
  public buSpin spn_toolmagapeed8;
  internal Panel \u0007;
  public buButton btn_toolmagtake7;
  public buSpin spn_toolmagdia7;
  public buButton btn_toolmagset7;
  public buSpin spn_toolmaglen7;
  public buSpin spn_toolmagapeed7;
  internal Panel \u0008;
  public buButton btn_toolmagtake6;
  public buSpin spn_toolmagdia6;
  public buButton btn_toolmagset6;
  public buSpin spn_toolmaglen6;
  public buSpin spn_toolmagapeed6;
  internal Panel \u000E;
  public buButton btn_toolmagtake5;
  public buSpin spn_toolmagdia5;
  public buButton btn_toolmagset5;
  public buSpin spn_toolmaglen5;
  public buSpin spn_toolmagapeed5;
  internal Panel \u000F;
  public buButton btn_toolmagtake4;
  public buSpin spn_toolmagdia4;
  public buButton btn_toolmagset4;
  public buSpin spn_toolmaglen4;
  public buSpin spn_toolmagapeed4;
  internal Panel \u0010;
  public buButton btn_toolmagtake3;
  public buSpin spn_toolmagdia3;
  public buButton btn_toolmagset3;
  public buSpin spn_toolmaglen3;
  public buSpin spn_toolmagapeed3;
  internal Panel \u0011;
  public buButton btn_toolmagtake2;
  public buSpin spn_toolmagdia2;
  public buButton btn_toolmagset2;
  public buSpin spn_toolmaglen2;
  public buSpin spn_toolmagapeed2;
  internal Panel \u0012;
  internal buLabel \u0001;
  public buButton btn_toolmagtake1;
  public buButton btn_toolmagset1;
  internal buLabel \u0002;
  internal buLabel \u0003;
  internal buLabel \u0004;
  internal buLabel \u0005;
  internal buLabel \u0006;
  internal buLabel \u0007;
  internal buLabel \u0008;
  internal buLabel \u000E;
  internal buLabel \u000F;
  internal ImageList \u0001;
  public buButton btn_toolmag1;
  public buButton btn_toolmag10;
  public buButton btn_toolmag9;

  public void FillTools()
  {
    this.\u0001.Rows.Clear();
    for (int index = 0; index <= this.Tools.Count - 1; ++index)
    {
      string str1 = "";
      string str2 = "";
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      Image image;
      if (this.Tools[index].Purpose == ToolPurpose.Saw)
      {
        image = this.\u0001.Images[1];
        str1 = buLangTranslate.preDef.Saw;
        num1 = this.Tools[index].Geometry.Diameter;
        num3 = this.Tools[index].Geometry.Thickness;
        str2 = this.Tools[index].Data.Name;
      }
      else if (this.Tools[index].Purpose == ToolPurpose.Milling | this.Tools[index].Purpose == ToolPurpose.MillingHead)
      {
        image = this.\u0001.Images[0];
        str1 = buLangTranslate.preDef.Milling;
        if (this.Tools[index].Geometry.GeometryType == ToolType.Flat)
          str1 = buLangTranslate.preDef.FlatMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Sphere)
          str1 = buLangTranslate.preDef.SphereMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Bullnose)
          str1 = buLangTranslate.preDef.BullnoseMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Taper)
          str1 = buLangTranslate.preDef.TaperMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Dove)
          str1 = buLangTranslate.preDef.DoveMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Barrel)
          str1 = buLangTranslate.preDef.BarrelMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Chamfer)
          str1 = buLangTranslate.preDef.ChamferMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Slot)
          str1 = buLangTranslate.preDef.SlotMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Grinding)
          str1 = buLangTranslate.preDef.GrindingMilling;
        else if (this.Tools[index].Geometry.GeometryType == ToolType.Lollipop)
          str1 = buLangTranslate.preDef.LollipopMilling;
        num1 = this.Tools[index].Geometry.Diameter;
        num2 = this.Tools[index].Geometry.Length;
        str2 = this.Tools[index].Data.Name;
      }
      else
        image = (Image) new Bitmap(32 /*0x20*/, 32 /*0x20*/);
      this.\u0001.Rows.Add(\u0005.\u0003.\u0001(str2, num1, index + 1, num3, num2, (F_MarbleToolList) this, image, this.Tools[index].CamData.SpindleSpeed, str1));
      this.\u0001.Rows[this.\u0001.Rows.Count - 1].Height = 40;
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_ok.Name)
      {
        ((F_MarbleToolList) this).Apply();
        this.pnl_preview.Controls.Clear();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_close.Name | control.Name == this.btn_cancel.Name)
      {
        this.pnl_preview.Controls.Clear();
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_toolopen.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathTools;
        openFileDialog.Multiselect = false;
        openFileDialog.Filter = "Marble Tools File (*.butools)|*.butools";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathTools = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(fileInfo.FullName, ref StringList);
          List<List<string>> CalcList = new List<List<string>>();
          buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", true, StringList, ref CalcList);
          List<ToolBase5> toolBase5List = new List<ToolBase5>();
          if (CalcList.Count > 0)
          {
            this.Tools.Clear();
            for (int index = 0; index <= CalcList.Count - 1; ++index)
            {
              ArrayList AL = new ArrayList();
              AL.AddRange((ICollection) CalcList[index].ToArray());
              ToolBase5 toolBase5 = new ToolBase5();
              buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) toolBase5);
              this.Tools.Add(toolBase5);
            }
            this.FillTools();
          }
        }
      }
      if (control.Name == this.btn_toolsave.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathTools;
        saveFileDialog.Filter = "Marble Tools File (*.butools)|*.butools";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathTools = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  Marble Tools ");
          StringList.Add((object) "------------------------------------------------------------------------");
          for (int index = 0; index <= this.Tools.Count - 1; ++index)
            StringList.AddRange((ICollection) this.Tools[index].ToDefAll("", 4, (SerilizationMode5) 1));
          buFile.SaveToFile(StringList, saveFileDialog.FileName);
        }
      }
      if (!(control.Name == this.btn_add.Name) || this.indexTool >= 0)
        ;
      if (control.Name == this.btn_remove.Name && this.indexTool >= 0 && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDeleteTool) == DialogResult.Yes)
      {
        this.Tools.RemoveAt(this.indexTool);
        --this.indexTool;
        if (this.indexTool < 0 && this.Tools.Count > 0)
          this.indexTool = 0;
        this.FillTools();
      }
      if (!(control.Name == this.btn_edit.Name) || this.indexTool < 0)
        return;
      ToolBase5 tool = this.Tools[this.indexTool];
      this.pnl_preview.Controls.Clear();
      this.pnl_preview.Controls.Add((Control) buEyeItems.viewportDialogs);
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    this.indexTool = obj1.RowIndex;
    if (this.indexTool < 0)
      return;
    clsAppMarbleVars.cmdMarble.DrawTool(this.Tools[this.indexTool]);
    this.\u0002.Text = clsAppMarbleVars.cmdMarble.ToolInfo(this.Tools[this.indexTool]);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleToolCurrentAll() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.buTab_tools.ItemSize = new Size(1, 1);
    if (!this.PropertiesForm.VisualUpdated)
      this.InitVisual();
    this.btn_millingtool.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable;
    this.btn_millingheadtool.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable;
    this.btn_magazine.Visible = buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger;
    this.spn_milling_diameter.Value = buMarbleCalc.activeToolMilling.Geometry.Diameter;
    this.spn_milling_length.Value = buMarbleCalc.activeToolMilling.Geometry.Length;
    this.spn_milling_speed.Value = buMarbleCalc.activeToolMilling.CamData.SpindleSpeed;
    ((F_MarbleMachineSettingsV2) this).\u0003.Text = buMarbleCalc.activeToolMilling.Data.Name;
    ((F_MarbleMachineSettingsV2) this).spn_sawshoulderthickness.Value = buMarbleCalc.activeToolSaw.Geometry.ShoulderThickness;
    this.spn_sawdia.Value = buMarbleCalc.activeToolSaw.Geometry.Diameter;
    this.spn_sawthickness.Value = buMarbleCalc.activeToolSaw.Geometry.Thickness;
    this.spn_sawspeed.Value = buMarbleCalc.activeToolSaw.CamData.SpindleSpeed;
    ((F_MarbleMachineSettingsV2) this).spn_sawsocket.Value = buMarbleCalc.activeToolSaw.Geometry.SocketThickness;
    ((F_MarbleMachineSettingsV2) this).\u0001.Text = buMarbleCalc.activeToolSaw.Data.Name;
    this.spn_millinghead_diameter.Value = buMarbleCalc.activeToolMillingHead.Geometry.Diameter;
    this.spn_millinghead_length.Value = buMarbleCalc.activeToolMillingHead.Geometry.Length;
    this.spn_millinghead_speed.Value = buMarbleCalc.activeToolMillingHead.CamData.SpindleSpeed;
    ((F_MarbleMachineSettingsV2) this).\u0002.Text = buMarbleCalc.activeToolMillingHead.Data.Name;
    if (clsAppMarbleVars.varApp.ToolChangeCount > 0 & buMarbleCalc.ToolInMagazine != null)
    {
      this.spn_toolmagdia1.Value = buMarbleCalc.ToolInMagazine[1].Geometry.Diameter;
      this.spn_toolmaglen1.Value = buMarbleCalc.ToolInMagazine[1].Geometry.Length;
      this.spn_toolmagapeed1.Value = buMarbleCalc.ToolInMagazine[1].CamData.SpindleSpeed;
      this.btn_toolmag1.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[1].Geometry.GeometryType)];
      this.\u0001.Text = "1." + buMarbleCalc.ToolInMagazine[1].Data.Name;
      this.spn_toolmagdia2.Value = buMarbleCalc.ToolInMagazine[2].Geometry.Diameter;
      this.spn_toolmaglen2.Value = buMarbleCalc.ToolInMagazine[2].Geometry.Length;
      this.spn_toolmagapeed2.Value = buMarbleCalc.ToolInMagazine[2].CamData.SpindleSpeed;
      ((F_MarbleMachineSettingsV2) this).btn_toolmag2.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[2].Geometry.GeometryType)];
      this.\u000F.Text = "2." + buMarbleCalc.ToolInMagazine[2].Data.Name;
      this.spn_toolmagdia3.Value = buMarbleCalc.ToolInMagazine[3].Geometry.Diameter;
      this.spn_toolmaglen3.Value = buMarbleCalc.ToolInMagazine[3].Geometry.Length;
      this.spn_toolmagapeed3.Value = buMarbleCalc.ToolInMagazine[3].CamData.SpindleSpeed;
      ((F_MarbleMachineSettingsV2) this).btn_toolmag3.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[3].Geometry.GeometryType)];
      this.\u000E.Text = "3." + buMarbleCalc.ToolInMagazine[3].Data.Name;
      this.spn_toolmagdia4.Value = buMarbleCalc.ToolInMagazine[4].Geometry.Diameter;
      this.spn_toolmaglen4.Value = buMarbleCalc.ToolInMagazine[4].Geometry.Length;
      this.spn_toolmagapeed4.Value = buMarbleCalc.ToolInMagazine[4].CamData.SpindleSpeed;
      ((F_MarbleMachineSettingsV2) this).btn_toolmag4.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[4].Geometry.GeometryType)];
      this.\u0008.Text = "4." + buMarbleCalc.ToolInMagazine[4].Data.Name;
      this.spn_toolmagdia5.Value = buMarbleCalc.ToolInMagazine[5].Geometry.Diameter;
      this.spn_toolmaglen5.Value = buMarbleCalc.ToolInMagazine[5].Geometry.Length;
      this.spn_toolmagapeed5.Value = buMarbleCalc.ToolInMagazine[5].CamData.SpindleSpeed;
      ((F_MarbleMachineSettingsV2) this).btn_toolmag5.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[5].Geometry.GeometryType)];
      this.\u0007.Text = "5." + buMarbleCalc.ToolInMagazine[5].Data.Name;
      this.spn_toolmagdia6.Value = buMarbleCalc.ToolInMagazine[6].Geometry.Diameter;
      this.spn_toolmaglen6.Value = buMarbleCalc.ToolInMagazine[6].Geometry.Length;
      this.spn_toolmagapeed6.Value = buMarbleCalc.ToolInMagazine[6].CamData.SpindleSpeed;
      ((F_MarbleMachineSettingsV2) this).btn_toolmag6.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[6].Geometry.GeometryType)];
      this.\u0006.Text = "6." + buMarbleCalc.ToolInMagazine[6].Data.Name;
      this.spn_toolmagdia7.Value = buMarbleCalc.ToolInMagazine[7].Geometry.Diameter;
      this.spn_toolmaglen7.Value = buMarbleCalc.ToolInMagazine[7].Geometry.Length;
      this.spn_toolmagapeed7.Value = buMarbleCalc.ToolInMagazine[7].CamData.SpindleSpeed;
      ((F_MarbleMachineSettingsV2) this).btn_toolmag7.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[7].Geometry.GeometryType)];
      this.\u0005.Text = "7." + buMarbleCalc.ToolInMagazine[7].Data.Name;
      this.spn_toolmagdia8.Value = buMarbleCalc.ToolInMagazine[8].Geometry.Diameter;
      this.spn_toolmaglen8.Value = buMarbleCalc.ToolInMagazine[8].Geometry.Length;
      this.spn_toolmagapeed8.Value = buMarbleCalc.ToolInMagazine[8].CamData.SpindleSpeed;
      ((F_MarbleMachineSettingsV2) this).btn_toolmag8.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[8].Geometry.GeometryType)];
      this.\u0004.Text = "8." + buMarbleCalc.ToolInMagazine[8].Data.Name;
      this.spn_toolmagdia9.Value = buMarbleCalc.ToolInMagazine[9].Geometry.Diameter;
      this.spn_toolmaglen9.Value = buMarbleCalc.ToolInMagazine[9].Geometry.Length;
      this.spn_toolmagapeed9.Value = buMarbleCalc.ToolInMagazine[9].CamData.SpindleSpeed;
      this.btn_toolmag9.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[9].Geometry.GeometryType)];
      this.\u0003.Text = "9." + buMarbleCalc.ToolInMagazine[9].Data.Name;
      this.spn_toolmagdia10.Value = buMarbleCalc.ToolInMagazine[10].Geometry.Diameter;
      this.spn_toolmaglen10.Value = buMarbleCalc.ToolInMagazine[10].Geometry.Length;
      this.spn_toolmagapeed10.Value = buMarbleCalc.ToolInMagazine[10].CamData.SpindleSpeed;
      this.btn_toolmag10.Image = this.\u0001.Images[((F_MarbleMachineSettingsV2) this).ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[10].Geometry.GeometryType)];
      this.\u0002.Text = "10." + buMarbleCalc.ToolInMagazine[10].Data.Name;
      if (clsAppMarbleVars.varApp.ToolChangeCount == 5)
      {
        this.\u0008.Visible = false;
        this.\u0007.Visible = false;
        this.\u0006.Visible = false;
        this.\u0005.Visible = false;
        this.\u0004.Visible = false;
      }
      if (clsAppMarbleVars.varApp.ToolChangeCount == 6)
      {
        this.\u0007.Visible = false;
        this.\u0006.Visible = false;
        this.\u0005.Visible = false;
        this.\u0004.Visible = false;
      }
      if (clsAppMarbleVars.varApp.ToolChangeCount == 7)
      {
        this.\u0006.Visible = false;
        this.\u0005.Visible = false;
        this.\u0004.Visible = false;
      }
      if (clsAppMarbleVars.varApp.ToolChangeCount == 8)
      {
        this.\u0005.Visible = false;
        this.\u0004.Visible = false;
      }
      if (clsAppMarbleVars.varApp.ToolChangeCount == 9)
        this.\u0004.Visible = false;
    }
    \u0005.\u0003.\u0001(this);
    this.LoadLanguage();
    ((F_MarbleMachineSettingsV2) this).btn_millinghead_gozeroposition.Visible = buMarbleCalc.varMarbleSettings.ShowGoToolZeroAtToolPage;
    ((F_MarbleMachineSettingsV2) this).btn_milling_gozeroposition.Visible = buMarbleCalc.varMarbleSettings.ShowGoToolZeroAtToolPage;
    ((F_MarbleMachineSettingsV2) this).btn_saw_gozeroposition.Visible = buMarbleCalc.varMarbleSettings.ShowGoToolZeroAtToolPage;
    if (!buMarbleCalc.varMarbleSettings.ShowOpenSaveButtonAtToolPage | AppSecurity.PasswordLevel == 0)
    {
      this.btn_savetools.Visible = false;
      this.btn_opentools.Visible = false;
    }
    else
    {
      this.btn_savetools.Visible = true;
      this.btn_opentools.Visible = true;
    }
    ((F_MarbleMachineSettingsV2) this).MenuButtonColors(this.SelectedTab);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = hmiUICommands.SetVisualItem(this.\u0001.Controls);
      controlCollection = this.tabPage_saw.Controls;
      controlCollection = hmiUICommands.SetVisualItem(this.tabPage_saw.Controls);
      controlCollection = hmiUICommands.SetVisualItem(this.tabPage_mlling.Controls);
      controlCollection = hmiUICommands.SetVisualItem(this.\u0001.Controls);
      controlCollection = hmiUICommands.SetVisualItem(this.\u0002.Controls);
    }
    this.PropertiesForm.VisualUpdated = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.\u0001.Text = buLangTranslate.preDef.Tools;
      this.btn_ok.Text = buLangTranslate.preDef.Ok;
      this.btn_cancel.Text = buLangTranslate.preDef.Cancel;
      this.btn_sawtool.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}";
      this.btn_millingtool.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}";
      this.btn_millingheadtool.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}";
      this.btn_magazine.Text = $"{buLangTranslate.preDef.Tools} {buLangTranslate.preDef.Magazine}";
      this.btn_toolstop.Text = buLangTranslate.preDef.Stop;
      this.btn_toollist.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.List}";
      this.btn_saw_settings.Text = buLangTranslate.preDef.Settings;
      this.btn_milling_settings.Text = buLangTranslate.preDef.Settings;
      this.btn_milling_edit.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Edit}";
      this.btn_millinghead_settings.Text = buLangTranslate.preDef.Settings;
      this.btn_millinghead_edit.Text = buLangTranslate.preDef.Settings;
      this.tabPage_saw.Text = buLangTranslate.preDef.Saw;
      this.tabPage_mlling.Text = buLangTranslate.preDef.Milling;
      this.\u0001.Text = buLangTranslate.preDef.MillingHead;
      this.btn_sawgonyele.Text = buLangTranslate.preDef.Perpendicular;
      this.btn_sawlimitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      this.btn_saw_activate.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Activate}";
      this.btn_saw_measure.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure}";
      this.btn_saw_zeroposition.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Zero}";
      this.btn_milling_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      this.btn_milling_activate.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Activate}";
      this.btn_milling_measure.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure}";
      this.btn_milling_zeroposition.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Zero}";
      this.btn_millinghead_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      this.btn_millinghead_activate.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Activate}";
      this.btn_millinghead_measure.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Measure}";
      this.btn_millinghead_zeroposition.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Zero}";
      this.btn_savetools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Save}";
      this.btn_opentools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Open}";
      ((F_MarbleMachineSettingsV2) this).spn_sawshoulderthickness.Caption.Caption = $"{buLangTranslate.preDef.Shoulder} {buLangTranslate.preDef.Thickness}";
      this.spn_sawdia.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Diameter}";
      this.spn_sawthickness.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Thickness}";
      this.spn_sawspeed.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Speed}";
      this.spn_milling_diameter.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Diameter}";
      this.spn_milling_length.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Length}";
      this.spn_milling_speed.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Speed}";
      this.spn_millinghead_diameter.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Diameter}";
      this.spn_millinghead_length.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Length}";
      this.spn_millinghead_speed.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Speed}";
      ((F_MarbleMachineSettingsV2) this).\u0001.Caption.Caption = buLangTranslate.preDef.Name;
      ((F_MarbleMachineSettingsV2) this).\u0002.Caption.Caption = buLangTranslate.preDef.Name;
      ((F_MarbleMachineSettingsV2) this).\u0003.Caption.Caption = buLangTranslate.preDef.Name;
      ((F_MarbleMachineSettingsV2) this).spn_sawsocket.Caption.Caption = buLangTranslate.preDef.Socket;
      ((F_MarbleMachineSettingsV2) this).btn_jog.Text = buLangTranslate.preDef.Jog;
      ((F_MarbleMachineSettingsV2) this).btn_mdi.Text = "MDI";
      ((F_MarbleMachineSettingsV2) this).btn_spindledowndown.Text = $"{buLangTranslate.preDef.Spindle} {buLangTranslate.preDef.Down}";
      ((F_MarbleMachineSettingsV2) this).btn_spindledownup.Text = $"{buLangTranslate.preDef.Spindle} {buLangTranslate.preDef.Up}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
      if (!buNumeric5.IsNumeric(fKeyPadNumV1.Value))
        return;
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buTextBox buTextBox = obj0 as buTextBox;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadCharV1 fKeyPadCharV1 = new F_KeyPadCharV1();
      fKeyPadCharV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadCharV1.Caption = buTextBox.Caption.Caption;
      fKeyPadCharV1.ShowDialog(buTextBox.Text.ToString());
      buTextBox.Text = fKeyPadCharV1.Value;
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
    buMarbleCalc.activeToolMilling.Geometry.Diameter = this.spn_milling_diameter.Value;
    buMarbleCalc.activeToolMilling.Geometry.Length = this.spn_milling_length.Value;
    buMarbleCalc.activeToolMilling.CamData.SpindleSpeed = this.spn_milling_speed.Value;
    buMarbleCalc.activeToolMilling.Data.Name = ((F_MarbleMachineSettingsV2) this).\u0003.Text;
    buMarbleCalc.activeToolSaw.Geometry.ShoulderThickness = ((F_MarbleMachineSettingsV2) this).spn_sawshoulderthickness.Value;
    buMarbleCalc.activeToolSaw.Geometry.Diameter = this.spn_sawdia.Value;
    buMarbleCalc.activeToolSaw.Geometry.Thickness = this.spn_sawthickness.Value;
    buMarbleCalc.activeToolSaw.CamData.SpindleSpeed = this.spn_sawspeed.Value;
    buMarbleCalc.activeToolSaw.Geometry.SocketThickness = ((F_MarbleMachineSettingsV2) this).spn_sawsocket.Value;
    buMarbleCalc.activeToolSaw.Data.Name = ((F_MarbleMachineSettingsV2) this).\u0001.Text;
    buMarbleCalc.activeToolMillingHead.Geometry.Diameter = this.spn_millinghead_diameter.Value;
    buMarbleCalc.activeToolMillingHead.Geometry.Length = this.spn_millinghead_length.Value;
    buMarbleCalc.activeToolMillingHead.CamData.SpindleSpeed = this.spn_millinghead_speed.Value;
    buMarbleCalc.activeToolMillingHead.Data.Name = ((F_MarbleMachineSettingsV2) this).\u0002.Text;
    if (clsAppMarbleVars.varApp.ToolChangeCount > 0 & buMarbleCalc.ToolInMagazine != null)
    {
      buMarbleCalc.ToolInMagazine[1].Geometry.Diameter = this.spn_toolmagdia1.Value;
      buMarbleCalc.ToolInMagazine[1].Geometry.Length = this.spn_toolmaglen1.Value;
      buMarbleCalc.ToolInMagazine[1].CamData.SpindleSpeed = this.spn_toolmagapeed1.Value;
      buMarbleCalc.ToolInMagazine[1].Data.No = 1;
      buMarbleCalc.ToolInMagazine[2].Geometry.Diameter = this.spn_toolmagdia2.Value;
      buMarbleCalc.ToolInMagazine[2].Geometry.Length = this.spn_toolmaglen2.Value;
      buMarbleCalc.ToolInMagazine[2].CamData.SpindleSpeed = this.spn_toolmagapeed2.Value;
      buMarbleCalc.ToolInMagazine[2].Data.No = 2;
      buMarbleCalc.ToolInMagazine[3].Geometry.Diameter = this.spn_toolmagdia3.Value;
      buMarbleCalc.ToolInMagazine[3].Geometry.Length = this.spn_toolmaglen3.Value;
      buMarbleCalc.ToolInMagazine[3].CamData.SpindleSpeed = this.spn_toolmagapeed3.Value;
      buMarbleCalc.ToolInMagazine[3].Data.No = 3;
      buMarbleCalc.ToolInMagazine[4].Geometry.Diameter = this.spn_toolmagdia4.Value;
      buMarbleCalc.ToolInMagazine[4].Geometry.Length = this.spn_toolmaglen4.Value;
      buMarbleCalc.ToolInMagazine[4].CamData.SpindleSpeed = this.spn_toolmagapeed4.Value;
      buMarbleCalc.ToolInMagazine[4].Data.No = 4;
      buMarbleCalc.ToolInMagazine[5].Geometry.Diameter = this.spn_toolmagdia5.Value;
      buMarbleCalc.ToolInMagazine[5].Geometry.Length = this.spn_toolmaglen5.Value;
      buMarbleCalc.ToolInMagazine[5].CamData.SpindleSpeed = this.spn_toolmagapeed5.Value;
      buMarbleCalc.ToolInMagazine[5].Data.No = 5;
      buMarbleCalc.ToolInMagazine[6].Geometry.Diameter = this.spn_toolmagdia6.Value;
      buMarbleCalc.ToolInMagazine[6].Geometry.Length = this.spn_toolmaglen6.Value;
      buMarbleCalc.ToolInMagazine[6].CamData.SpindleSpeed = this.spn_toolmagapeed6.Value;
      buMarbleCalc.ToolInMagazine[6].Data.No = 6;
      buMarbleCalc.ToolInMagazine[7].Geometry.Diameter = this.spn_toolmagdia7.Value;
      buMarbleCalc.ToolInMagazine[7].Geometry.Length = this.spn_toolmaglen7.Value;
      buMarbleCalc.ToolInMagazine[7].CamData.SpindleSpeed = this.spn_toolmagapeed7.Value;
      buMarbleCalc.ToolInMagazine[7].Data.No = 7;
      buMarbleCalc.ToolInMagazine[8].Geometry.Diameter = this.spn_toolmagdia8.Value;
      buMarbleCalc.ToolInMagazine[8].Geometry.Length = this.spn_toolmaglen8.Value;
      buMarbleCalc.ToolInMagazine[8].CamData.SpindleSpeed = this.spn_toolmagapeed8.Value;
      buMarbleCalc.ToolInMagazine[8].Data.No = 8;
      buMarbleCalc.ToolInMagazine[9].Geometry.Diameter = this.spn_toolmagdia9.Value;
      buMarbleCalc.ToolInMagazine[9].Geometry.Length = this.spn_toolmaglen9.Value;
      buMarbleCalc.ToolInMagazine[9].CamData.SpindleSpeed = this.spn_toolmagapeed9.Value;
      buMarbleCalc.ToolInMagazine[9].Data.No = 9;
      buMarbleCalc.ToolInMagazine[10].Geometry.Diameter = this.spn_toolmagdia10.Value;
      buMarbleCalc.ToolInMagazine[10].Geometry.Length = this.spn_toolmaglen10.Value;
      buMarbleCalc.ToolInMagazine[10].CamData.SpindleSpeed = this.spn_toolmagapeed10.Value;
      buMarbleCalc.ToolInMagazine[10].Data.No = 10;
    }
    clsAppMarbleVars.cmdMarble.UpdateToolListFromActiveTools();
  }
}
