// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Settings.F_SettingsTreeView
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Settings;

public class F_SettingsTreeView : Form
{
  public static List<string> Captions = new List<string>();
  public List<object> Classes = new List<object>();
  public List<string> CaptionHeader = new List<string>();
  public List<List<string>> CaptionSubHeader = new List<List<string>>();
  public List<List<List<string>>> CaptionVariables = new List<List<List<string>>>();
  public DialogResult Result = DialogResult.Cancel;
  public TouchPadType TouchPadStyle = TouchPadType.buControlStyleBasic;
  public int AccessPasswordLevel = 0;
  public int DecimalPlace = 4;
  private bool bool_0 = false;
  public bool FormTopMost = false;
  public bool ReadOnly = false;
  public bool ScreenCenter = true;
  public bool TouchPad = false;
  public List<object> tempClasses = new List<object>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  internal TreeView treeView_0;
  public Button btn_default;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_apply;
  internal buClassViewer buClassViewer_0;
  public Button btn_saveastext;
  internal ContextMenuStrip contextMenuStrip_0;
  internal ToolStripMenuItem toolStripMenuItem_0;

  public F_SettingsTreeView() => Class39.smethod_721(this);

  internal void method_0(object sender, EventArgs e)
  {
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.method_3((object) this.treeView_0, (TreeViewEventArgs) null);
  }

  internal void method_2(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  public void Init()
  {
    this.buClassViewer_0.TouchPayStyle = this.TouchPadStyle;
    this.buClassViewer_0.OwnerForm = (Form) this;
    this.buClassViewer_0.DecimalPlace = this.DecimalPlace;
    this.tempClasses.Clear();
    this.tempClasses = new List<object>();
    for (int index = 0; index <= this.Classes.Count - 1; ++index)
    {
      object obj = new object();
      object instance = Activator.CreateInstance(this.Classes[index].GetType());
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassVariables(this.Classes[index], ref Vars);
      buSerilization.SetClassVariables(ref instance, Vars);
      this.tempClasses.Add(instance);
    }
    this.treeView_0.Nodes.Clear();
    if (AppSecurity.PasswordLevel < this.AccessPasswordLevel)
    {
      this.buClassViewer_0.Enabled = false;
      this.btn_apply.Enabled = false;
      this.btn_ok.Enabled = false;
      this.btn_default.Enabled = false;
    }
    else
    {
      this.buClassViewer_0.Enabled = true;
      this.btn_apply.Enabled = true;
      this.btn_ok.Enabled = true;
      this.btn_default.Enabled = true;
    }
    this.treeView_0.SelectedNode = (TreeNode) null;
    List<string> stringList = new List<string>();
    for (int index1 = 0; index1 <= this.tempClasses.Count - 1; ++index1)
    {
      if (this.tempClasses[index1] != null)
      {
        List<cParameter> Vars1 = new List<cParameter>();
        string name = this.tempClasses[index1].GetType().Name;
        if (this.CaptionHeader.Count > 0 & index1 <= this.CaptionHeader.Count - 1)
          name = this.CaptionHeader[index1];
        TreeNodeSettings node1 = new TreeNodeSettings();
        buSerilization.GetClassVariables(this.tempClasses[index1], ref Vars1);
        for (int index2 = 0; index2 <= Vars1.Count - 1; ++index2)
        {
          System.Type type1 = Vars1[index2].Value.GetType();
          if (type1.IsClass)
          {
            bool flag1 = false;
            if (type1.Name.ToLower() == "SolidItemDisplay")
              flag1 = true;
            if (type1.Name.ToLower() == "drawpropertiestype")
              flag1 = true;
            if (type1.Name == "MouseKeyboardConfigration" | type1.Name == "EntityResolution")
              flag1 = true;
            bool flag2 = false;
            if (type1.BaseType.Namespace == "buClass" | type1.BaseType.FullName.IndexOf("buSerilization") >= 0)
              flag2 = true;
            if (flag2 & !flag1)
            {
              List<cParameter> Vars2 = new List<cParameter>();
              buSerilization.GetClassVariables(Vars1[index2].Value, ref Vars2);
              TreeNodeSettings node2 = new TreeNodeSettings();
              for (int index3 = 0; index3 <= Vars2.Count - 1; ++index3)
              {
                System.Type type2 = Vars2[index3].Value.GetType();
                if (type2.IsClass && type2.BaseType.Namespace == "buClass")
                {
                  TreeNodeSettings node3 = new TreeNodeSettings();
                  node3.Text = Vars2[index3].Name;
                  node3.Tag = Vars2[index3].Value;
                  node3.ImageIndex = 1;
                  node3.SelectedImageIndex = 1;
                  node3.ClassIndex = index1;
                  node3.ClassSubIndex = index2;
                  node2.Nodes.Add((TreeNode) node3);
                }
              }
              node2.Text = Vars1[index2].Name;
              node2.Tag = Vars1[index2].Value;
              node2.ImageIndex = 1;
              node2.SelectedImageIndex = 1;
              node2.ClassIndex = index1;
              node2.ClassSubIndex = index2;
              node1.Nodes.Add((TreeNode) node2);
            }
          }
        }
        node1.Text = name;
        node1.Tag = this.tempClasses[index1];
        node1.ImageIndex = 2;
        node1.SelectedImageIndex = 2;
        node1.ClassIndex = index1;
        node1.ClassSubIndex = 0;
        this.treeView_0.Nodes.Add((TreeNode) node1);
      }
    }
    if (this.tempClasses.Count > 0)
      this.treeView_0.SelectedNode = this.treeView_0.Nodes[0];
    this.TopMost = this.FormTopMost;
    if (this.ScreenCenter)
      this.StartPosition = FormStartPosition.CenterScreen;
    this.bool_0 = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "SettingsTreeView LoadLanguage";
    try
    {
      if (F_SettingsTreeView.Captions.Count < 7)
        return;
      this.Text = F_SettingsTreeView.Captions[0];
      this.btn_default.Text = F_SettingsTreeView.Captions[1];
      this.btn_saveastext.Text = F_SettingsTreeView.Captions[2];
      this.btn_apply.Text = F_SettingsTreeView.Captions[3];
      this.btn_ok.Text = F_SettingsTreeView.Captions[4];
      this.btn_cancel.Text = F_SettingsTreeView.Captions[5];
      this.toolStripMenuItem_0.Text = F_SettingsTreeView.Captions[6];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_3(object sender, TreeViewEventArgs e)
  {
    if (!this.bool_0 || e == null || this.treeView_0.SelectedNode.Tag == null || this.treeView_0.SelectedNode.Nodes == null)
      return;
    this.buClassViewer_0.ClassObject = this.treeView_0.SelectedNode.Tag;
    this.buClassViewer_0.Init();
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (this.treeView_0.SelectedNode == null)
    {
      this.Visible = false;
    }
    else
    {
      this.method_6(sender, e);
      this.tempClasses = new List<object>();
      object tag = this.treeView_0.SelectedNode.Tag;
      this.Result = DialogResult.OK;
      this.Visible = false;
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    this.tempClasses = new List<object>();
    this.Result = DialogResult.Cancel;
    this.Visible = false;
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (this.treeView_0.SelectedNode == null)
    {
      this.Visible = false;
    }
    else
    {
      this.btn_apply.Focus();
      for (int index1 = 0; index1 <= this.treeView_0.Nodes.Count - 1; ++index1)
      {
        object tempClass = this.tempClasses[index1];
        if (this.treeView_0.Nodes[index1].Nodes != null)
        {
          for (int index2 = 0; index2 <= this.treeView_0.Nodes[index1].Nodes.Count - 1; ++index2)
          {
            List<cParameter> Vars = new List<cParameter>();
            object tag = this.treeView_0.Nodes[index1].Nodes[index2].Tag;
            buSerilization.GetClassVariables(tag, ref Vars);
            buSerilization.SetClassVariables(ref tag, Vars);
          }
        }
        object tag1 = this.treeView_0.Nodes[index1].Tag;
        this.tempClasses[index1] = tempClass;
      }
      for (int index = 0; index <= this.tempClasses.Count - 1; ++index)
      {
        object CopiedClass = new object();
        CopiedClass = Activator.CreateInstance(this.tempClasses[index].GetType());
        buSerilization.CopyClass(this.tempClasses[index], ref CopiedClass);
        this.Classes[index] = CopiedClass;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.applyClickEvent_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.applyClickEvent_0();
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.defaultClickEvent_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.defaultClickEvent_0();
    }
    this.Visible = false;
  }

  internal void method_8(object sender, EventArgs e)
  {
    List<string> StringList = new List<string>();
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = Application.StartupPath;
    saveFileDialog.Filter = "Settings CSV Files (*.csv)|*.csv";
    saveFileDialog.FilterIndex = 1;
    saveFileDialog.FileName = "";
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    for (int index1 = 0; index1 <= this.treeView_0.Nodes.Count - 1; ++index1)
    {
      object tempClass = this.tempClasses[index1];
      if (this.treeView_0.Nodes[index1].Nodes != null)
      {
        if (this.treeView_0.Nodes[index1].Nodes.Count > 0)
        {
          for (int index2 = 0; index2 <= this.treeView_0.Nodes[index1].Nodes.Count - 1; ++index2)
          {
            List<cParameter> Vars = new List<cParameter>();
            buSerilization.GetClassVariables(this.treeView_0.Nodes[index1].Nodes[index2].Tag, ref Vars);
            for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
            {
              string str = $"{this.treeView_0.Nodes[index1].Text} ; {this.treeView_0.Nodes[index1].Nodes[index2].Text}; {Vars[index3].Name} ; {Vars[index3].ValueAsString.ToString()}";
              StringList.Add(str);
            }
          }
        }
        else
        {
          List<cParameter> Vars = new List<cParameter>();
          buSerilization.GetClassVariables(this.treeView_0.Nodes[index1].Tag, ref Vars);
          for (int index4 = 0; index4 <= Vars.Count - 1; ++index4)
          {
            string str = $"{this.treeView_0.Nodes[index1].Text} ;  - ; {Vars[index4].Name} ; {Vars[index4].ValueAsString.ToString()}";
            StringList.Add(str);
          }
        }
      }
      object tag = this.treeView_0.Nodes[index1].Tag;
      this.tempClasses[index1] = tempClass;
    }
    buFile.SaveToFile(StringList, saveFileDialog.FileName);
  }

  internal void method_9(object sender, EventArgs e)
  {
    DialogBoxList dialogBoxList = new DialogBoxList();
    CodesysAxis data = (CodesysAxis) null;
    if (this.treeView_0.SelectedNode.Parent == null && this.treeView_0.SelectedNode.Tag.GetType() == typeof (CodesysAxis))
      data = new CodesysAxis((CodesysAxis) this.treeView_0.SelectedNode.Tag);
    if (data == null)
      return;
    for (int index = 0; index <= this.Classes.Count - 1; ++index)
    {
      if (this.Classes[index].GetType() == typeof (CodesysAxis))
        dialogBoxList.Items.Add(((CodesysAxis) this.Classes[index]).Base.baseChar);
    }
    dialogBoxList.Init();
    int num = (int) dialogBoxList.ShowDialog();
    if (dialogBoxList.Result != DialogResult.OK)
      return;
    if (this.Classes[dialogBoxList.SelectedIndex].GetType() == typeof (CodesysAxis))
      this.Classes[dialogBoxList.SelectedIndex] = (object) new CodesysAxis(data);
    this.Init();
  }

  public event F_SettingsTreeView.ApplyClickEvent ApplyClick;

  public event F_SettingsTreeView.DefaultClickEvent DefaultClick;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }

  public delegate void ApplyClickEvent();

  public delegate void DefaultClickEvent();
}
