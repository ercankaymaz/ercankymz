// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_CutMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Library;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_CutMenu : Form
{
  internal TextBox \u0005;
  internal TextBox \u0006;
  internal TextBox \u0007;
  internal TextBox \u0008;
  internal TextBox \u000E;
  internal TextBox \u000F;
  internal TextBox \u0010;
  internal TextBox \u0011;
  internal TextBox \u0012;
  internal TextBox \u0013;
  internal TextBox \u0014;

  public void FileOpened()
  {
    ((F_RotatePanel) this).selectedEntity = (Entity) null;
    if (((F_RotatePanel) this).viewport.Entities.Count > 0)
    {
      if (((F_RotatePanel) this).viewport.Entities[0] is SketchEntity)
      {
        SketchEntity entity = ((F_RotatePanel) this).viewport.Entities[0] as SketchEntity;
        if (((F_RotatePanel) this).OpenCustomData.Count > 0)
        {
          for (int index = 0; index <= ((F_RotatePanel) this).OpenCustomData.Count - 1; ++index)
          {
            if (((MarbleInfo) ((F_RotatePanel) this).OpenCustomData[index]).EntityIndex >= 0 & ((MarbleInfo) ((F_RotatePanel) this).OpenCustomData[index]).EntityIndex <= entity.CurveList.Count - 1)
              ((Entity) entity.CurveList[((MarbleInfo) ((F_RotatePanel) this).OpenCustomData[index]).EntityIndex]).EntityData = (object) ((F_RotatePanel) this).OpenCustomData[index];
          }
        }
        entity.Edit((IDesign) ((F_RotatePanel) this).viewport);
        ((F_RotatePanel) this).viewport.CurrentSketch.UpdateAndInvalidate();
      }
      foreach (devDept.Eyeshot.Control.Labels.Label label in (EyeshotCollection<devDept.Eyeshot.Control.Labels.Label>) ((F_RotatePanel) this).viewport.ActiveViewport.Labels)
      {
        if (label is StackedLabel)
          (label as StackedLabel).Visible = false;
      }
      int index1 = 0;
      ((F_MirrorOP) this).\u0001.Rows.Clear();
      foreach (Entity entity in (EyeshotCollection<Entity>) ((F_RotatePanel) this).viewport.Entities)
      {
        if (entity is Dimension)
        {
          double result = 0.0;
          double.TryParse(((devDept.Eyeshot.Entities.Text) entity).TextString, out result);
          ((F_MirrorOP) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(result, buImage5.GetAlfabetLetter(index1), 0.0, (F_SketchLibrary) this));
          ++index1;
        }
      }
    }
    DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\L");
    if (directoryInfo.Exists)
      directoryInfo.Delete(true);
    ((F_RotatePanel) this).\u0002.Enabled = true;
  }

  public void cmdSaveLib(Design Viewport, string FileName)
  {
    for (int index = 0; index <= Viewport.Entities.Count - 1; ++index)
    {
      if (Viewport.Entities[index] is SketchEntity)
      {
        (Viewport.Entities[index] as SketchEntity).Exit();
        Viewport.Entities.Regen();
        Viewport.Invalidate();
        FileInfo fileInfo1 = new FileInfo(FileName);
        string withoutExtension = buFile5.bunesting.getFileNameWithoutExtension(FileName);
        DirectoryInfo directoryInfo = new DirectoryInfo($"{fileInfo1.DirectoryName}\\{withoutExtension}");
        if (directoryInfo.Exists)
          directoryInfo.Delete(true);
        Directory.CreateDirectory(directoryInfo.FullName);
        FileInfo fileInfo2 = new FileInfo($"{directoryInfo.FullName}\\{withoutExtension}.buLibEye");
        FileInfo fileInfo3 = new FileInfo($"{directoryInfo.FullName}\\{withoutExtension}.buLibSet");
        FileInfo fileInfo4 = new FileInfo(FileName);
        this.SaveEditorCustomDataToFile(Viewport, fileInfo3.FullName);
        WriteFile writeFile = new WriteFile(new WriteFileParams(Viewport.Document), fileInfo2.FullName);
        Viewport.StartWork((WorkUnit) writeFile);
      }
    }
  }

  public void SaveEditorCustomDataToFile(Design Viewport, string filename)
  {
    List<string> StringList = new List<string>();
    for (int index1 = 0; index1 <= Viewport.Entities.Count - 1; ++index1)
    {
      if (Viewport.Entities[index1] is SketchEntity)
      {
        SketchEntity entity = Viewport.Entities[index1] as SketchEntity;
        for (int index2 = 0; index2 <= entity.CurveList.Count - 1; ++index2)
        {
          if (((Entity) entity.CurveList[index2]).EntityData is EditorCustomData)
          {
            EditorCustomData entityData = ((Entity) entity.CurveList[index2]).EntityData as EditorCustomData;
            ((MarbleInfo) entityData).EntityIndex = index2;
            if (((MarbleInfo) entityData).EntityIndex >= 0 && ((MarbleInfo) entityData).Commands.Count > 0)
            {
              string str1 = ((MarbleInfo) entityData).EntityIndex.ToString() + " | ";
              string str2 = "";
              for (int index3 = 0; index3 <= ((MarbleInfo) entityData).Commands.Count - 1; ++index3)
              {
                if (index3 > 0)
                  str2 = ";";
                str1 = str1 + str2 + ((MarbleInfo) entityData).Commands[index3];
              }
              StringList.Add(str1);
            }
          }
        }
      }
    }
    buVector5.SaveToFile(StringList, filename);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
    if (control.Name == ((F_MirrorOP) this).btn_folder.Name)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = ((F_MirrorOP) this).varLib.pathLibrary;
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        ((F_MirrorOP) this).varLib.pathLibrary = folderBrowserDialog.SelectedPath;
        ((F_DrawingMenu) this).Init();
      }
    }
    if (control.Name == ((F_MirrorOP) this).btn_zoomfit.Name)
    {
      ((F_RotatePanel) this).viewport.Focus();
      ((F_RotatePanel) this).viewport.ZoomFit();
      ((F_RotatePanel) this).viewport.Invalidate();
    }
    if (control.Name == ((F_MirrorOP) this).btn_zoomin.Name)
    {
      ((F_RotatePanel) this).viewport.ZoomIn(10);
      ((F_RotatePanel) this).viewport.Invalidate();
    }
    if (control.Name == ((F_MirrorOP) this).btn_zoomout.Name)
    {
      ((F_RotatePanel) this).viewport.ZoomOut(10);
      ((F_RotatePanel) this).viewport.Invalidate();
    }
    if (control.Name == ((F_MirrorOP) this).btn_topview.Name)
    {
      ((F_RotatePanel) this).viewport.SetView(viewType.Top);
      ((F_RotatePanel) this).viewport.Invalidate();
    }
    if (control.Name == ((F_MirrorOP) this).btn_cancel.Name | control.Name == ((F_MirrorOP) this).btn_close.Name)
    {
      ((F_RotatePanel) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_RotatePanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RotatePanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_MirrorOP) this).btn_ok.Name) || !((F_RotatePanel) this).PropertiesForm.Inited)
      return;
    ((F_RotatePanel) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_RotatePanel) this).viewport.Entities.Count > 0 && ((F_RotatePanel) this).viewport.Entities[0] is SketchEntity)
    {
      SketchEntity entity = ((F_RotatePanel) this).viewport.Entities[0] as SketchEntity;
      entity.Exit();
      ((F_RotatePanel) this).LibraryEntities = new List<buEntity>();
      for (int index = 0; index <= entity.CurveList.Count - 1; ++index)
      {
        buEntity buEntity = buDiametricDim.Copy((Entity) entity.CurveList[index]);
        if (((Entity) entity.CurveList[index]).EntityData != null && ((Entity) entity.CurveList[index]).EntityData is EditorCustomData)
        {
          EditorCustomData entityData = ((Entity) entity.CurveList[index]).EntityData as EditorCustomData;
          ((EntityDataSet) ((CustomData) buEntity).Info).Commands = new List<string>();
          ((EntityDataSet) ((CustomData) buEntity).Info).Commands.AddRange((IEnumerable<string>) ((MarbleInfo) entityData).Commands);
        }
        if (buEntity != null)
          ((F_RotatePanel) this).LibraryEntities.Add(buEntity);
      }
    }
    if (((F_RotatePanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_RotatePanel) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
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

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_RotatePanel) this).PropertiesForm.Inited || !(((F_MirrorOP) this).\u0001.Items.Count > 0 & ((F_MirrorOP) this).\u0001.SelectedIndex >= 0) || !(((F_MirrorOP) this).\u0001.Items[((F_MirrorOP) this).\u0001.SelectedIndex].GetType() == typeof (FileItem)))
      return;
    FileItem fileItem = new FileItem(((FileItem) ((F_MirrorOP) this).\u0001.Items[((F_MirrorOP) this).\u0001.SelectedIndex]).FileFullName);
    ((F_RotatePanel) this).viewport.Clear();
    \u0001.\u0002.\u0001(fileItem.FileFullName, (F_SketchLibrary) this);
    ((F_MirrorOP) this).lbl_name.Text = $"{AppLanguage.CadCamDynamic[32 /*0x20*/]} {AppLanguage.CadCamDynamic[40]} : {buFile.getFileNameWithoutExtension(fileItem.FileFullName)}";
    ((F_MirrorOP) this).\u0001.Text = buFile.getFileNameWithoutExtension(fileItem.FileFullName);
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_RotatePanel) this).\u0001 = obj1.RowIndex;
    ((F_RotatePanel) this).\u0002 = obj1.ColumnIndex;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SketchLibrary) this);
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = ((F_MirrorOP) this).\u0001.Rows[((F_RotatePanel) this).\u0001].Cells[0].Value.ToString();
    if (((F_RotatePanel) this).\u0002 == 1)
    {
      fKeyPadNumV1.ShowDialog(((F_MirrorOP) this).\u0001.Rows[((F_RotatePanel) this).\u0001].Cells[1].Value.ToString());
      if (buNumeric.IsNumeric(fKeyPadNumV1.Value))
        ((F_MirrorOP) this).\u0001.Rows[((F_RotatePanel) this).\u0001].Cells[1].Value = (object) double.Parse(fKeyPadNumV1.Value);
    }
    if (((F_RotatePanel) this).\u0002 != 2)
      return;
    fKeyPadNumV1.ShowDialog(((F_MirrorOP) this).\u0001.Rows[((F_RotatePanel) this).\u0001].Cells[2].Value.ToString());
    if (!buNumeric.IsNumeric(fKeyPadNumV1.Value))
      return;
    ((F_MirrorOP) this).\u0001.Rows[((F_RotatePanel) this).\u0001].Cells[2].Value = (object) double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_RotatePanel) this).PropertiesForm.Inited)
      return;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SketchLibrary) this);
    string s = ((F_MirrorOP) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString();
    double result = 0.0;
    double.TryParse(s, out result);
    if (((F_RotatePanel) this).selectedEntity == null)
      return;
    ((ValueVisualConstraint) ((F_RotatePanel) this).viewport.CurrentSketch.GetConstraint(((F_RotatePanel) this).selectedEntity)).Value = result;
    ((F_RotatePanel) this).viewport.CurrentSketch.UpdateAndInvalidate();
  }

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_RotatePanel) this).\u0001 = obj1.RowIndex;
    ((F_RotatePanel) this).\u0002 = obj1.ColumnIndex;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SketchLibrary) this);
  }
}
