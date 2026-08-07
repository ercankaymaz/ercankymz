// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.RollerBend.F_RollerCircle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Profile;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.RollerBend;

public class F_RollerCircle : Form
{
  public Button btn_bottom;
  internal PictureBox \u0001;
  internal Button \u0001;
  public Button btn_camsettings;
  public Button btn_toolsettings;
  public ComboBox cmb_tools;
  internal Button \u0002;
  internal ImageList \u0003;
  internal ImageList \u0004;
  internal Button \u0003;
  internal ImageList \u0005;
  internal ImageList \u0006;
  internal Button \u0004;
  internal CheckBox \u0001;
  public ListBox lst_info;

  [CompilerGenerated]
  [SpecialName]
  public void remove_RotateCommad(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Settnigs) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Settnigs) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CancelCommad(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_Settnigs) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_Settnigs) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CancelCommad(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_Settnigs) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_Settnigs) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_Settnigs) this).Properties.Inited = false;
    if (((F_Settnigs) this).Properties.Height > 10)
      this.Height = ((F_Settnigs) this).Properties.Height;
    if (((F_Settnigs) this).Properties.Width > 10)
      this.Width = ((F_Settnigs) this).Properties.Width;
    this.TopMost = ((F_Settnigs) this).Properties.TopMost;
    this.StartPosition = ((F_Settnigs) this).Properties.FormPosition;
    ((F_Settnigs) this).\u0002.Items.Clear();
    for (int index = 0; index <= ((F_Settnigs) this).CodesDefined.Count - 1; ++index)
    {
      string str1 = ((DimensionInfo) ((F_Settnigs) this).CodesDefined[index]).Codes.ToString();
      int int32 = Convert.ToInt32((object) ((DimensionInfo) ((F_Settnigs) this).CodesDefined[index]).Codes);
      string str2 = int32.ToString();
      string str3 = $"{str1} = {str2}";
      if (((DimensionInfo) ((F_Settnigs) this).CodesDefined[index]).Explanation.Trim().Length > 0)
      {
        string explanation = ((DimensionInfo) ((F_Settnigs) this).CodesDefined[index]).Explanation;
        int32 = Convert.ToInt32((object) ((DimensionInfo) ((F_Settnigs) this).CodesDefined[index]).Codes);
        string str4 = int32.ToString();
        str3 = $"{explanation} = {str4}";
      }
      ((F_Settnigs) this).\u0002.Items.Add((object) str3);
    }
    this.FillCodes();
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void FillCodes()
  {
    ((F_Settnigs) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((F_Settnigs) this).Codes.Count - 1; ++index)
    {
      string str1 = ((DimensionInfo) ((F_Settnigs) this).Codes[index]).Codes.ToString();
      int int32 = Convert.ToInt32((object) ((DimensionInfo) ((F_Settnigs) this).Codes[index]).Codes);
      string str2 = int32.ToString();
      string str3 = $"{str1} = {str2}";
      if (((DimensionInfo) ((F_Settnigs) this).Codes[index]).Explanation.Trim().Length > 0)
      {
        string explanation = ((DimensionInfo) ((F_Settnigs) this).Codes[index]).Explanation;
        int32 = Convert.ToInt32((object) ((DimensionInfo) ((F_Settnigs) this).Codes[index]).Codes);
        string str4 = int32.ToString();
        str3 = $"{explanation} = {str4}";
      }
      ((F_Settnigs) this).\u0001.Items.Add((object) str3);
    }
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_Settnigs.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Settnigs) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
    // ISSUE: reference to a compiler-generated field
    if (((F_Settnigs) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_Settnigs) this).\u0001();
    }
    if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Settnigs) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
