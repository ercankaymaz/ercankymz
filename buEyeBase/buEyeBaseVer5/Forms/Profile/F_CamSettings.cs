// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_CamSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Sewing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_CamSettings : Form
{
  internal Label \u0098\u0002;
  public CheckBox chk_ChangeCwCCWDirForRightRefProfile;
  public CheckBox chk_ChangeG2G3DirForLeftRefProfile;
  public CheckBox chk_ChangeG2G3DirForRightRefProfile;
  public CheckBox chk_RightProfileActive;
  internal TabPage \u0011;
  public CheckBox chk_NotchHorizontalUseMilling;
  public CheckBox chk_NotchOperationAlwaysFirst;
  internal Label \u0099\u0002;
  internal Label \u009A\u0002;
  public CheckBox chk_OperationEditChangeWithoutOk;
  public CheckBox chk_InsertOperationIfSamePositionAndSmallSize;
  public CheckBox chk_ShowBackReferanceEntity;
  public CheckBox chk_ShowBottomReferanceEntity;
  public CheckBox chk_LeftToRightCopyChangeCamDirection;
  public CheckBox chk_LeftToRightCopyRotateKeyHole;
  public CheckBox chk_NotchAlwaysSafeZ;
  internal Label \u009B\u0002;
  internal Label \u009C\u0002;
  internal Label \u009D\u0002;
  internal Label \u009E\u0002;
  internal Label \u009F\u0002;
  internal Label \u0001\u0003;
  internal Label \u0002\u0003;
  internal Label \u0003\u0003;
  internal Label \u0004\u0003;
  internal Label \u0005\u0003;
  internal Label \u0006\u0003;
  internal Label \u0007\u0003;
  internal Label \u0008\u0003;
  public ComboBox cmb_SortType;
  internal Label \u000E\u0003;
  internal Label \u000F\u0003;
  internal Label \u0010\u0003;
  public CheckBox chk_ParabolicMoveBetweenPlanes;
  public ComboBox cmb_ParabolicAllowedAxes;
  public NumericUpDown spn_ParabolicMoveFeed;
  public NumericUpDown spn_ParabolicSafeDistance;
  public CheckBox chk_AutoSaveWithTimeFileName;
  public CheckBox chk_AutoSave;
  public CheckBox chk_UseDrillToolForDrill;
  public CheckBox chk_SimAddZAxisKinematicAndToolLength;
  public NumericUpDown spn_ProfilePreviewRefDrawingExtraHeight;
  public NumericUpDown spn_ProfilePreviewRefDrawingThickness;
  internal Label \u0011\u0003;
  internal Label \u0012\u0003;
  public NumericUpDown spn_ProfileEndAllowedPositiveDistance;
  public NumericUpDown spn_ProfileStartAllowedNegativeDistance;
  internal Label \u0013\u0003;
  internal Label \u0014\u0003;
  public NumericUpDown spn_ProfileDrawingRefThickness;
  internal Label \u0015\u0003;
  public CheckBox chk_SimulationCanStartFromRightProfile;
  public CheckBox chk_SaveImageFileWhileCreatingCode;
  public CheckBox chk_SaveStlFileWhileCreatingCode;
  public NumericUpDown spn_ImageScaleFactor;
  internal Label \u0016\u0003;
  public NumericUpDown spn_SimulasyonGCodeWindowHeight;
  internal Label \u0017\u0003;
  public NumericUpDown spn_SimulasyonGCodeWindowWidth;
  public NumericUpDown spn_MinSpindleSpeed;
  public NumericUpDown spn_PlaneThickness;
  public TextBox txt_LongBottomProfileMCode;
  public TextBox txt_BottomProfileMCode;
  public TextBox txt_LongProfileMCode;
  internal Label \u0018\u0003;
  internal Label \u0019\u0003;
  public TextBox txt_ClamperChar;
  public TextBox txt_PriorityChar;
  public Label lbl_EachLayerFromArea;
  public NumericUpDown spn_EachLayerConnectGap;
  public NumericUpDown spn_PlaneToPlaneSafeDisance;
  internal Label \u001A\u0003;
  public CheckBox chk_NotchVerticalSafeAtXAxis;
  public CheckBox chk_NotchSideSafeAtXAxis;
  public CheckBox chk_G91Mode;
  internal Label \u001B\u0003;
  public CheckBox chk_NotchVerticalForbiddenAtSide;
  internal TabPage \u0012;
  public CheckBox chk_alarmIfToolDiaDifferentThenHoleDia;
  internal Label \u001C\u0003;
  public static byte f00158D;
  public ProfileClamperSettings varProfileClamperSettings;
  public FormProperties Properties;
  public string strPath;
  public static List<string> Captions;
  private int \u0001;
  public List<ProfileLengthClamperCount> Lengths;
  public List<ProfileClamper> Clampers;

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (((F_Settnigs) this).\u0001 == null || !(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_Settnigs) this).SewingTableList.Count - 1))
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_Settnigs) this).\u0001((object) ((F_Settnigs) this).SewingTableList[obj1.RowIndex], (object) obj1.RowIndex);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Settnigs) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Settnigs) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CamSettings() => F_Settnigs.Captions = new List<string>();

  public F_CamSettings()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).MoveDis = 1.0;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SewingMove) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_MoveCommad(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Settnigs) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Settnigs) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_MoveCommad(OkCommandWithTwoDataEventHandler value)
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
}
