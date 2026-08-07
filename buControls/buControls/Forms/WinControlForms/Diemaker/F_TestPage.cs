// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_TestPage
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_TestPage : Form
{
  public static List<string> Captions = new List<string>();
  public int DigitalInputCount = 32 /*0x20*/;
  public int DigitalInputColumbs = 4;
  public int DigitalOutputCount = 32 /*0x20*/;
  public int DigitalOutputColumbs = 4;
  public int AxisCount = 4;
  public int SelectedTab = 0;
  public bool InvisibleIO = false;
  public List<string> AxisCaptions = new List<string>();
  public List<string> InputCaptions = new List<string>();
  public List<string> OutputCaptions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
  internal Label label_9;
  internal Label label_10;
  internal Label label_11;
  internal Label label_12;
  internal Label label_13;
  internal Label label_14;
  internal Label label_15;
  internal Label label_16;
  internal Label label_17;
  internal Label label_18;
  internal Label label_19;
  internal Label label_20;
  internal Label label_21;
  internal Label label_22;
  internal Label label_23;
  internal Label label_24;
  internal Label label_25;
  internal Label label_26;
  internal Label label_27;
  internal Label label_28;
  internal Label label_29;
  internal Label label_30;
  internal Label label_31;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal Label label_32;
  internal Label label_33;
  internal Label label_34;
  internal Label label_35;
  internal Label label_36;
  internal Label label_37;
  internal Label label_38;
  internal Label label_39;
  internal Label label_40;
  internal Label label_41;
  internal Label label_42;
  internal Label label_43;
  internal Label label_44;
  internal Label label_45;
  internal Label label_46;
  internal Label label_47;
  internal Label label_48;
  internal Label label_49;
  internal Label label_50;
  internal Label label_51;
  internal Label label_52;
  internal Label label_53;
  internal Label label_54;
  internal Label label_55;
  internal Label label_56;
  internal Label label_57;
  internal Label label_58;
  internal Label label_59;
  internal Label label_60;
  internal Label label_61;
  internal Label label_62;
  internal Label label_63;
  internal Label label_64;
  internal Label label_65;
  internal Label label_66;
  internal Label label_67;
  internal Label label_68;
  internal Label label_69;
  internal Label label_70;
  internal Label label_71;
  internal Label label_72;
  internal Label label_73;
  internal Label label_74;
  internal Label label_75;
  internal Label label_76;
  internal Label label_77;
  internal Label label_78;
  internal Label label_79;
  internal Label label_80;
  internal Label label_81;
  internal Label label_82;
  internal Label label_83;
  internal Label label_84;
  internal Label label_85;
  internal Label label_86;
  internal Label label_87;
  internal Label label_88;
  internal Label label_89;
  internal Label label_90;
  internal Label label_91;
  internal Label label_92;
  internal Label label_93;
  internal Label label_94;
  internal Label label_95;
  internal Label label_96;
  internal Label label_97;
  internal Label label_98;
  internal Label label_99;
  internal Label label_100;
  internal Label label_101;
  internal Label label_102;
  internal Label label_103;
  internal Label label_104;
  internal Label label_105;
  internal Label label_106;
  internal Label label_107;
  internal Label label_108;
  internal Label label_109;
  internal Label label_110;
  internal Label label_111;
  internal Label label_112;
  internal Label label_113;
  internal Label label_114;
  internal Label label_115;
  internal Label label_116;
  internal Label label_117;
  internal Label label_118;
  internal Label label_119;
  internal Label label_120;
  internal Label label_121;
  internal Label label_122;
  internal Label label_123;
  internal Label label_124;
  internal Label label_125;
  internal Label label_126;
  internal Label label_127;
  internal Label label_128;
  internal Label label_129;
  internal Label label_130;
  internal PictureBox pictureBox_0;
  public ListBox lst_axis;
  public Label lbl_pos;
  public Button btn_bwd;
  public Button btn_fwd;
  public Button btn_increment;
  public Button btn_stop;
  public Button btn_home;
  public NumericUpDown spn_pos1;
  public Button btn_pos1;
  public Button btn_pos2;
  public NumericUpDown spn_relative;
  public NumericUpDown spn_pos2;
  public Button btn_write;

  public F_TestPage() => Class39.smethod_376(this);

  public event EventHandler PageClosing;

  public event JogAxisChangedEventHandler AxisChanged;

  public event SetOutputEventHandler SetOutput;

  public event JogCommandEventHandler JogCommand;

  public void Init()
  {
    Class39.smethod_487(this);
    try
    {
      if (this.InvisibleIO && this.tabControl_0.TabPages.Count > 1)
      {
        for (int index = 0; index <= this.tabControl_0.TabPages.Count - 1; ++index)
        {
          if (this.tabControl_0.TabPages.Count > 1)
            this.tabControl_0.TabPages.RemoveAt(0);
        }
      }
      this.lst_axis.Items.Clear();
      for (int index = 0; index <= this.AxisCount - 1; ++index)
      {
        if (index <= this.AxisCaptions.Count - 1)
          this.lst_axis.Items.Add((object) this.AxisCaptions[index]);
        else
          this.lst_axis.Items.Add((object) ("Axis " + (index + 1).ToString()));
      }
      for (int index1 = 0; index1 <= 48 /*0x30*/; ++index1)
      {
        for (int index2 = 0; index2 <= this.tabPage_0.Controls.Count - 1; ++index2)
        {
          Control control = new Control();
          if (this.tabPage_0.Controls[index2].Name == "chk_i" + index1.ToString() && this.InputCaptions.Count > 0 & index1 <= this.InputCaptions.Count - 1)
            this.tabPage_0.Controls[index2].Text = this.InputCaptions[index1];
        }
      }
      for (int index3 = 0; index3 <= 48 /*0x30*/; ++index3)
      {
        for (int index4 = 0; index4 <= this.tabPage_1.Controls.Count - 1; ++index4)
        {
          Control control = new Control();
          if (this.tabPage_1.Controls[index4].Name == "chk_o" + index3.ToString() && this.OutputCaptions.Count > 0 & index3 <= this.OutputCaptions.Count - 1)
            this.tabPage_1.Controls[index4].Text = this.OutputCaptions[index3];
        }
      }
      if (AppProcess.SelectedAxis >= 0 & AppProcess.SelectedAxis <= this.lst_axis.Items.Count - 1)
        this.lst_axis.SelectedIndex = AppProcess.SelectedAxis;
      if (this.tabControl_0.SelectedIndex == 0 | this.tabControl_0.SelectedIndex == 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) e, new EventArgs());
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
        {
          Command = JogCommandType.AxisSelected,
          SelectedAxis = this.lst_axis.SelectedIndex
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 == null || this.lst_axis.SelectedIndex < 0)
        return;
      // ISSUE: reference to a compiler-generated field
      this.jogAxisChangedEventHandler_0((object) this, this.lst_axis.SelectedIndex);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void GetInput(int Index, bool State)
  {
    try
    {
      for (int index = 1; index <= this.tabPage_0.Controls.Count - 1; ++index)
      {
        if (this.tabPage_0.Controls[index].Tag != null && int.Parse(this.tabPage_0.Controls[index].Tag.ToString()) == Index)
          ((buCheckBox) this.tabPage_0.Controls[index]).Check = State;
      }
    }
    catch (Exception ex)
    {
      string str = $"Index: {Index.ToString()} - State: {State.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void GetOutput(int Index, bool State)
  {
    try
    {
      for (int index = 1; index <= this.tabPage_1.Controls.Count - 1; ++index)
      {
        if (this.tabPage_1.Controls[index].Tag != null && int.Parse(this.tabPage_1.Controls[index].Tag.ToString()) == Index)
          ((buCheckBox) this.tabPage_1.Controls[index]).Check = State;
      }
    }
    catch (Exception ex)
    {
      string str = $"Index: {Index.ToString()} - State: {State.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void SetAxisInput(bool Homing, bool PosLim, bool NegLim, bool Capture)
  {
  }

  internal void method_2(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.Absolute,
      Position = (double) this.spn_pos1.Value,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_3(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.Absolute,
      Position = (double) this.spn_pos2.Value,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_4(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.Incremental,
      Position = (double) this.spn_relative.Value,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_5(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.Home,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_6(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.Stop,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_7(object sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.VelocityPlus,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_8(object sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.VelocityMinus,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_9(object sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.Stop,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  internal void method_10(object sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.Stop,
      SelectedAxis = this.lst_axis.SelectedIndex
    });
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
