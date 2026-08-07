// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.FileLoad.F_LoadWithPreview
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.Notepad;
using buControls.Viewer;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.FileLoad;

public class F_LoadWithPreview : Form
{
  private F_Notepad f_Notepad_0 = new F_Notepad();
  private bool bool_0 = false;
  internal List<string> list_0 = new List<string>();
  public string[] FileStrings = (string[]) null;
  private Timer timer_0 = new Timer();
  public List<string> Captions = new List<string>();
  public List<string> FileExtension = new List<string>();
  public bool FormTopMost = false;
  public bool ScreenCenter = true;
  public string PathJob = Application.StartupPath;
  public bool ClosePageAfterLoad = true;
  public bool ShowCountData = true;
  public bool DisablePreview = false;
  public bool ShowG0Draw = true;
  public bool SendFile = false;
  private string string_0 = Application.StartupPath;
  private string string_1 = Application.StartupPath;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buListBox buListBox_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal buButton buButton_4;
  internal buTextBox buTextBox_0;
  internal buButton buButton_5;
  internal buPanel buPanel_0;
  internal buButton buButton_6;
  internal buButton buButton_7;
  internal buButton buButton_8;
  internal buButton buButton_9;
  internal buButton buButton_10;
  internal buButton buButton_11;
  internal buSpin buSpin_0;
  internal buButton buButton_12;
  internal buCheckBox buCheckBox_0;
  internal buButton buButton_13;
  internal buLabel buLabel_0;
  public buViewer viewer_preview;
  public buCheckBox chk_option3;
  public buCheckBox chk_option2;
  public buCheckBox chk_option1;
  public buSpin spn_data1;

  public F_LoadWithPreview() => Class39.smethod_123(this);

  public event LoadFileEventHandler FileLoad;

  public event FileSelectedEventHandler FileSelected;

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    try
    {
      e.Cancel = true;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      if (!this.Visible)
        return;
      this.Init();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void Init()
  {
    try
    {
      this.TopMost = this.FormTopMost;
      this.buSpin_0.Visible = this.ShowCountData;
      if (!new DirectoryInfo(this.PathJob).Exists)
      {
        this.PathJob = Application.StartupPath;
        Directory.CreateDirectory(this.PathJob);
      }
      this.buListBox_0.Font = new Font("Arial", 14f);
      this.bool_0 = false;
      this.buCheckBox_0.Visible = this.ShowG0Draw;
      if (!this.ShowG0Draw)
        this.buCheckBox_0.Check = false;
      Class39.smethod_558(this);
      this.LoadLanguage();
      if (!this.ScreenCenter)
        return;
      this.StartPosition = FormStartPosition.CenterScreen;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void Init(string Path)
  {
    this.PathJob = Path;
    this.Init();
  }

  public void Init(string Path, List<string> Extensions)
  {
    this.PathJob = Path;
    this.FileExtension.Clear();
    this.FileExtension.AddRange((IEnumerable<string>) Extensions);
    this.Init();
  }

  public void LoadLanguage()
  {
    try
    {
      if (this.Captions.Count > 35)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void Lst_SelectedIndexChanged(object sender, EventArgs e)
  {
    try
    {
      if (this.bool_0)
        return;
      this.SendFile = false;
      this.buLabel_0.Visible = false;
      FileInfo fileInfo = new FileInfo($"{this.PathJob}\\{this.buListBox_0.Text}");
      if (fileInfo.Exists & this.f_Notepad_0.Visible)
      {
        string Str = "";
        buFile.OpenFromFile(fileInfo.FullName, ref Str);
        this.f_Notepad_0.Init(Str);
        this.f_Notepad_0.Location = new Point(2, 5);
      }
      this.string_0 = fileInfo.FullName;
      this.string_1 = buFile.GetPath(fileInfo.FullName);
      if (this.DisablePreview)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.fileSelectedEventHandler_0 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.fileSelectedEventHandler_0(new FileEventArg(fileInfo.FullName));
      }
      else
      {
        List<eEntities> eEntitiesList = new List<eEntities>();
        this.viewer_preview.Entities.Clear();
        for (int index = 0; index <= eEntitiesList.Count - 1; ++index)
        {
          eEntities copiedEnt = new eEntities();
          eEntities.CopyEntity(eEntitiesList[index], ref copiedEnt);
          this.viewer_preview.Entities.Add(copiedEnt);
        }
        this.viewer_preview.setView(ViewportViewType.Top);
        this.viewer_preview.ZoomFit();
        this.viewer_preview.ZoomOut();
        // ISSUE: reference to a compiler-generated field
        if (this.fileSelectedEventHandler_0 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.fileSelectedEventHandler_0(new FileEventArg(fileInfo.FullName));
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void DrawEntities(List<eEntities> Entities)
  {
    try
    {
      this.viewer_preview.Entities.Clear();
      for (int index = 0; index <= Entities.Count - 1; ++index)
      {
        eEntities copiedEnt = new eEntities();
        eEntities.CopyEntity(Entities[index], ref copiedEnt);
        this.viewer_preview.Entities.Add(copiedEnt);
      }
      this.viewer_preview.setView(ViewportViewType.Top);
      this.viewer_preview.ZoomFit();
      this.viewer_preview.ZoomOut();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_9.Name)
        Process.Start(this.PathJob);
      if (control2.Name == this.buButton_4.Name && this.buListBox_0.Items.Count > 0)
      {
        if (this.buListBox_0.SelectedIndex < 0)
          this.buListBox_0.SelectedIndex = 0;
        if (this.buListBox_0.SelectedIndex < this.buListBox_0.Items.Count - 1)
          ++this.buListBox_0.SelectedIndex;
      }
      if (control2.Name == this.buButton_3.Name && this.buListBox_0.Items.Count > 0)
      {
        if (this.buListBox_0.SelectedIndex < 0)
          this.buListBox_0.SelectedIndex = 0;
        if (this.buListBox_0.SelectedIndex > 0)
          --this.buListBox_0.SelectedIndex;
      }
      if (control2.Name == this.buButton_11.Name)
      {
        string fileName = $"{this.PathJob}\\{this.buListBox_0.Text}";
        FileInfo fileInfo = new FileInfo(fileName);
        if (fileInfo.Exists)
        {
          string str = "Do You Want To Delete This File ";
          if (AppLanguage.SystemMessages.Count > 1)
            str = AppLanguage.SystemMessages[1];
          if (buString.MessageBoxQuestion(fileName + str) == DialogResult.Yes)
          {
            buLog.addLog(this.buListBox_0.Text + "  -  File Deleted", "Delete", MethodBase.GetCurrentMethod().Name);
            fileInfo.Delete();
            Class39.smethod_558(this);
          }
        }
      }
      if (control2.Name == this.buButton_10.Name)
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.SelectedPath = this.PathJob;
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
          this.PathJob = folderBrowserDialog.SelectedPath;
          buLog.addLog("Folder Changed  = " + this.PathJob, "Folder Changed", MethodBase.GetCurrentMethod().Name);
        }
        this.Init();
      }
      if (control2.Name == this.buButton_8.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = this.PathJob;
        for (int index = 0; index <= this.FileExtension.Count - 1; ++index)
        {
          string str1 = this.FileExtension[index].Trim();
          string str2 = "";
          if (str1.IndexOf("*.") <= 0)
            str1 = "*." + str1;
          if (index > 0)
            str2 = "|";
          openFileDialog.Filter = $"{openFileDialog.Filter}{str2}{this.FileExtension[index]} Files (*.{this.FileExtension[index]})|{str1}";
        }
        openFileDialog.FilterIndex = 1;
        openFileDialog.FileName = "";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          this.SendFile = false;
          AppProcess.LastLoadedFileName = openFileDialog.FileName;
          AppProcess.LastLoadedFolder = buFile.GetPath(openFileDialog.FileName);
          this.method_3((object) this.buButton_12, (EventArgs) null);
        }
      }
      if (!(control2.Name == this.buButton_7.Name))
        return;
      FileInfo fileInfo1 = new FileInfo($"{this.PathJob}\\{this.buListBox_0.Text}");
      if (!fileInfo1.Exists)
        return;
      string Str = "";
      buFile.OpenFromFile(fileInfo1.FullName, ref Str);
      this.f_Notepad_0 = new F_Notepad();
      this.f_Notepad_0.Init(Str);
      int num = (int) this.f_Notepad_0.ShowDialog((IWin32Window) this);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      FileEventArg e1 = new FileEventArg();
      e1.FileName = this.string_0;
      e1.FilePath = this.string_1;
      AppProcess.LastLoadedFolder = this.string_1;
      AppProcess.LastLoadedFileName = this.string_0;
      e1.Count = Convert.ToInt32(this.buSpin_0.Value);
      e1.JustFileName = buFile.getFileName(e1.FileName);
      // ISSUE: reference to a compiler-generated field
      if (this.loadFileEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.loadFileEventHandler_0(e1);
      }
      if (!this.ClosePageAfterLoad)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    this.method_3((object) this.buButton_12, (EventArgs) null);
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_2.Name | control2.Name == this.buButton_0.Name)
        this.Visible = false;
      if (control2.Name == this.buButton_1.Name)
        this.WindowState = FormWindowState.Minimized;
      if (!(control2.Name == this.buButton_13.Name))
        return;
      if (this.WindowState == FormWindowState.Maximized)
        this.WindowState = FormWindowState.Normal;
      else
        this.WindowState = FormWindowState.Maximized;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_6.Name)
        this.buPanel_0.Visible = false;
      if (!(control2.Name == this.buButton_5.Name))
        return;
      if (!this.buPanel_0.Visible)
        this.buPanel_0.Visible = true;
      else
        this.buPanel_0.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
    try
    {
      this.bool_0 = true;
      if (this.buTextBox_0.Text.Length == 0)
      {
        Class39.smethod_558(this);
      }
      else
      {
        this.buListBox_0.Items.Clear();
        for (int index = 0; index <= this.list_0.Count - 1; ++index)
        {
          if (this.list_0[index].ToLower().IndexOf(this.buTextBox_0.Text.ToLower()) == 0)
            this.buListBox_0.Items.Add((object) this.list_0[index]);
        }
      }
      this.bool_0 = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
