// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleToolListTab
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleToolListTab : Form
{
  public buButton btn_millingparkgo;
  public buButton btn_millingheadparkgo;
  public buButton btn_generalparkgo;
  public buButton btn_sawparkgo;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public List<Pnt9DS> G54s;
  public int indexG54;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal DataGridView \u0001;
  internal ImageList \u0001;
  public buButton btn_g54save;
  public buButton btn_g54open;
  public buButton btn_G54getpos;
  public buButton btn_goposition;
  public buButton btn_stop;
  public static byte f000658;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<ToolBase5> ToolsMilling;
  public List<ToolBase5> ToolsMillingHead;
  public List<ToolBase5> ToolsSaw;
  public MarbleToolType SelectedToolType;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;

  public void FillG54()
  {
    this.\u0001.Rows.Clear();
    for (int index = 0; index <= this.G54s.Count - 1; ++index)
    {
      Image image = this.\u0001.Images[0];
      string str = this.G54s[index].S;
      if (index == 0)
        str = $"{buLangTranslate.preDef.Activate} G54 {buLangTranslate.preDef.Offset}";
      DataGridViewRowCollection rows = this.\u0001.Rows;
      double x = this.G54s[index].X;
      double y = this.G54s[index].Y;
      double z = this.G54s[index].Z;
      double c = this.G54s[index].C;
      double a = this.G54s[index].A;
      object[] objArray = \u0005.\u0003.\u0001(index, x, image, y, z, a, c, (F_MarbleG54List) this, str);
      rows.Add(objArray);
      this.\u0001.Rows[this.\u0001.Rows.Count - 1].Height = 40;
      this.\u0001.Rows[this.\u0001.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      if (index > 0 & index == clsAppMarbleVars.varInterface.IndexG54)
      {
        if (Pnt9DS.Equal(this.G54s[index], this.G54s[0], 0.1))
          this.\u0001.Rows[this.\u0001.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
        else
          clsAppMarbleVars.varInterface.IndexG54 = -1;
      }
      if (index == 0)
      {
        this.\u0001.Rows[this.\u0001.Rows.Count - 1].ReadOnly = true;
        this.\u0001.Rows[this.\u0001.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
      }
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_stop.Name && clsAppMarbleVars.cmdMarble != null)
        clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 2);
      if (control.Name == this.btn_ok.Name)
      {
        clsAppMarbleVars.varInterface.IndexG54 = this.indexG54;
        ((F_MarbleG54List) this).Apply();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_close.Name | control.Name == this.btn_cancel.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_g54open.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathG54;
        openFileDialog.Multiselect = false;
        openFileDialog.Filter = "Marble G54 File (*.bug54)|*.bug54";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathG54 = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(fileInfo.FullName, ref StringList);
          List<string> CalcList = new List<string>();
          buString.ListToSpecificList("<G54Ofset>", "</G54Ofset>", false, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            this.G54s.Clear();
            for (int index = 0; index <= CalcList.Count - 1; ++index)
              this.G54s.Add(Pnt9DS.DecodeFromString(CalcList[index]));
            this.FillG54();
          }
        }
      }
      if (control.Name == this.btn_g54save.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathG54;
        saveFileDialog.Filter = "Marble G54 File (*.bug54)|*.bug54";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathG54 = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  Marble G54 ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "<G54Ofset>");
          for (int index = 0; index <= this.G54s.Count - 1; ++index)
            StringList.Add((object) this.G54s[index].ToDef(2));
          StringList.Add((object) "</G54Ofset>");
          buFile.SaveToFile(StringList, saveFileDialog.FileName);
        }
      }
      if (control.Name == this.btn_goposition.Name && AppBool.Connected & this.indexG54 >= 0)
      {
        if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove)
        {
          double Position = double.Parse(this.\u0001.Rows[this.indexG54].Cells[5].Value.ToString());
          clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, Position, true);
        }
        Thread.Sleep(500);
        if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove)
        {
          double Position = double.Parse(this.\u0001.Rows[this.indexG54].Cells[6].Value.ToString());
          clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar, 0.0, Position, true);
        }
        if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
        {
          double Position = double.Parse(this.\u0001.Rows[this.indexG54].Cells[7].Value.ToString());
          clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar, 0.0, Position, true);
        }
        Thread.Sleep(500);
        if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove)
        {
          double Position = double.Parse(this.\u0001.Rows[this.indexG54].Cells[4].Value.ToString());
          clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar, 0.0, Position, true);
        }
        if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove)
        {
          double Position = double.Parse(this.\u0001.Rows[this.indexG54].Cells[3].Value.ToString());
          clsAppMarbleVars.cMachine.Commands.moveAbsolute(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar, 0.0, Position, true);
        }
      }
      if (!(control.Name == this.btn_G54getpos.Name) || !(AppBool.Connected & this.indexG54 >= 1))
        return;
      if (clsAppMarbleVars.varRuntime.AxX >= 0)
        this.\u0001.Rows[this.indexG54].Cells[2].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxY >= 0)
        this.\u0001.Rows[this.indexG54].Cells[3].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxZ >= 0)
        this.\u0001.Rows[this.indexG54].Cells[4].Value = this.\u0001.Rows[0].Cells[4].Value;
      if (clsAppMarbleVars.varRuntime.AxC >= 0)
        this.\u0001.Rows[this.indexG54].Cells[5].Value = this.\u0001.Rows[0].Cells[5].Value;
      if (clsAppMarbleVars.varRuntime.AxA < 0)
        return;
      this.\u0001.Rows[this.indexG54].Cells[6].Value = this.\u0001.Rows[0].Cells[6].Value;
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
    this.indexG54 = obj1.RowIndex;
    if (this.indexG54 >= 0)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleToolListTab()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = hmiUICommands.SetVisualItem(this.buGround1.Controls);
      controlCollection = ((F_MarbleToolList) this).\u0001.Controls;
      controlCollection = hmiUICommands.SetVisualItem(((F_MarbleToolList) this).\u0001.Controls);
      controlCollection = hmiUICommands.SetVisualItem(((F_MarbleToolList) this).tabPage_mlling.Controls);
    }
    this.PropertiesForm.VisualUpdated = true;
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

  public void Apply()
  {
  }

  public void FillTools()
  {
    ((F_MarbleToolList) this).\u0002.Rows.Clear();
    for (int index = 0; index <= this.ToolsSaw.Count - 1; ++index)
    {
      string str = "";
      double num1 = 0.0;
      double num2 = 0.0;
      Image image;
      if (this.ToolsSaw[index].Purpose == ToolPurpose.Saw)
      {
        image = ((F_MarbleToolList) this).\u0001.Images[10];
        num1 = this.ToolsSaw[index].Geometry.Diameter;
        num2 = this.ToolsSaw[index].Geometry.Thickness;
        str = this.ToolsSaw[index].Data.Name;
      }
      else
        image = (Image) new Bitmap(32 /*0x20*/, 32 /*0x20*/);
      DataGridViewRowCollection rows = ((F_MarbleToolList) this).\u0002.Rows;
      double socketThickness = this.ToolsSaw[index].Geometry.SocketThickness;
      double spindleSpeed = this.ToolsSaw[index].CamData.SpindleSpeed;
      object[] objArray = \u0005.\u0003.\u0001(num1, num2, image, this, str, spindleSpeed, socketThickness, index + 1);
      rows.Add(objArray);
      ((F_MarbleToolList) this).\u0002.Rows[((F_MarbleToolList) this).\u0002.Rows.Count - 1].Height = 40;
      ((F_MarbleToolList) this).\u0002.Rows[((F_MarbleToolList) this).\u0002.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      if (index >= 0 & index == clsAppMarbleVars.varInterface.IndexToolSaw)
      {
        if (buCompare5.EQ(this.ToolsSaw[index].Geometry.Diameter, buMarbleCalc.activeToolSaw.Geometry.Diameter, 0.1))
          ((F_MarbleToolList) this).\u0002.Rows[((F_MarbleToolList) this).\u0002.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
        else
          clsAppMarbleVars.varInterface.IndexToolSaw = -1;
      }
    }
    ((F_MarbleToolList) this).\u0001.Rows.Clear();
    for (int index = 0; index <= this.ToolsMilling.Count - 1; ++index)
    {
      string str1 = "";
      string str2 = "";
      double num3 = 0.0;
      double num4 = 0.0;
      Image image;
      if (this.ToolsMilling[index].Purpose == ToolPurpose.Milling | this.ToolsMilling[index].Purpose == ToolPurpose.MillingHead)
      {
        image = ((F_MarbleToolList) this).\u0001.Images[0];
        str1 = buLangTranslate.preDef.Milling;
        if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Flat)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[0];
          str1 = buLangTranslate.preDef.FlatMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Sphere)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[1];
          str1 = buLangTranslate.preDef.SphereMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Bullnose)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[3];
          str1 = buLangTranslate.preDef.BullnoseMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Taper)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[2];
          str1 = buLangTranslate.preDef.TaperMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Dove)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[5];
          str1 = buLangTranslate.preDef.DoveMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Barrel)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[6];
          str1 = buLangTranslate.preDef.BarrelMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Chamfer)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[7];
          str1 = buLangTranslate.preDef.ChamferMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Slot)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[8];
          str1 = buLangTranslate.preDef.SlotMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Grinding)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[9];
          str1 = buLangTranslate.preDef.GrindingMilling;
        }
        else if (this.ToolsMilling[index].Geometry.GeometryType == ToolType.Lollipop)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[4];
          str1 = buLangTranslate.preDef.LollipopMilling;
        }
        num3 = this.ToolsMilling[index].Geometry.Diameter;
        num4 = this.ToolsMilling[index].Geometry.Length;
        str2 = this.ToolsMilling[index].Data.Name;
      }
      else
        image = (Image) new Bitmap(32 /*0x20*/, 32 /*0x20*/);
      ((F_MarbleToolList) this).\u0001.Rows.Add(\u0005.\u0003.\u0001(index + 1, str2, num4, image, num3, this.ToolsMilling[index].CamData.SpindleSpeed, this, str1));
      ((F_MarbleToolList) this).\u0001.Rows[((F_MarbleToolList) this).\u0001.Rows.Count - 1].Height = 40;
      ((F_MarbleToolList) this).\u0001.Rows[((F_MarbleToolList) this).\u0001.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      if (index >= 0 & index == clsAppMarbleVars.varInterface.IndexToolMilling)
      {
        if (buCompare5.EQ(this.ToolsMilling[index].Geometry.Diameter, buMarbleCalc.activeToolMilling.Geometry.Diameter, 0.1) & buCompare5.EQ(this.ToolsMilling[index].Geometry.Length, buMarbleCalc.activeToolMilling.Geometry.Length, 0.1))
          ((F_MarbleToolList) this).\u0001.Rows[((F_MarbleToolList) this).\u0001.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
        else
          clsAppMarbleVars.varInterface.IndexToolMilling = -1;
      }
    }
    ((F_MarbleToolCurrentAll) this).\u0003.Rows.Clear();
    for (int index = 0; index <= this.ToolsMillingHead.Count - 1; ++index)
    {
      string str3 = "";
      string str4 = "";
      double num5 = 0.0;
      double num6 = 0.0;
      Image image;
      if (this.ToolsMillingHead[index].Purpose == ToolPurpose.Milling | this.ToolsMillingHead[index].Purpose == ToolPurpose.MillingHead)
      {
        image = ((F_MarbleToolList) this).\u0001.Images[0];
        str3 = buLangTranslate.preDef.Milling;
        if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Flat)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[0];
          str3 = buLangTranslate.preDef.FlatMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Sphere)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[1];
          str3 = buLangTranslate.preDef.SphereMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Bullnose)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[3];
          str3 = buLangTranslate.preDef.BullnoseMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Taper)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[2];
          str3 = buLangTranslate.preDef.TaperMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Dove)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[5];
          str3 = buLangTranslate.preDef.DoveMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Barrel)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[6];
          str3 = buLangTranslate.preDef.BarrelMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Chamfer)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[7];
          str3 = buLangTranslate.preDef.ChamferMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Slot)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[8];
          str3 = buLangTranslate.preDef.SlotMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Grinding)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[9];
          str3 = buLangTranslate.preDef.GrindingMilling;
        }
        else if (this.ToolsMillingHead[index].Geometry.GeometryType == ToolType.Lollipop)
        {
          image = ((F_MarbleToolList) this).\u0001.Images[4];
          str3 = buLangTranslate.preDef.LollipopMilling;
        }
        num5 = this.ToolsMillingHead[index].Geometry.Diameter;
        num6 = this.ToolsMillingHead[index].Geometry.Length;
        str4 = this.ToolsMillingHead[index].Data.Name;
      }
      else
        image = (Image) new Bitmap(32 /*0x20*/, 32 /*0x20*/);
      ((F_MarbleToolCurrentAll) this).\u0003.Rows.Add(\u0005.\u0003.\u0001(str3, this, str4, num5, image, index + 1, num6, this.ToolsMillingHead[index].CamData.SpindleSpeed));
      ((F_MarbleToolCurrentAll) this).\u0003.Rows[((F_MarbleToolCurrentAll) this).\u0003.Rows.Count - 1].Height = 40;
      ((F_MarbleToolCurrentAll) this).\u0003.Rows[((F_MarbleToolCurrentAll) this).\u0003.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      if (index >= 0 & index == clsAppMarbleVars.varInterface.IndexToolMillingHead)
      {
        if (buCompare5.EQ(this.ToolsMillingHead[index].Geometry.Diameter, buMarbleCalc.activeToolMillingHead.Geometry.Diameter, 0.1) & buCompare5.EQ(this.ToolsMillingHead[index].Geometry.Length, buMarbleCalc.activeToolMillingHead.Geometry.Length, 0.1))
          ((F_MarbleToolCurrentAll) this).\u0003.Rows[((F_MarbleToolCurrentAll) this).\u0003.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
        else
          clsAppMarbleVars.varInterface.IndexToolMillingHead = -1;
      }
    }
  }
}
