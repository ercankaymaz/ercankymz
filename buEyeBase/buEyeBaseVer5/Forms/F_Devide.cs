// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Devide
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_Devide : Form
{
  public static List<string> Captions;
  public static List<string> CaptionGrid;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ContextMenuStrip \u0001;
  internal ToolStripMenuItem \u0001;
  internal ToolStripMenuItem \u0002;
  internal ToolStripSeparator \u0001;
  internal ToolStripMenuItem \u0003;
  internal ContextMenuStrip \u0002;
  internal ToolStripMenuItem \u0004;
  internal ToolStripMenuItem \u0005;
  internal ToolStripSeparator \u0002;
  internal ToolStripMenuItem \u0006;
  internal ToolStripMenuItem \u0007;
  internal ToolStripMenuItem \u0008;
  internal ToolStripMenuItem \u000E;
  internal ToolStripSeparator \u0003;
  internal ToolStripMenuItem \u000F;
  internal ToolStripSeparator \u0004;
  internal ToolStripMenuItem \u0010;
  internal ToolStripMenuItem \u0011;
  internal Button \u0001;
  internal Button \u0002;
  internal ToolStripSeparator \u0005;
  internal ToolStripMenuItem \u0012;

  public F_Devide(MachineAxisInfo data)
  {
    ((F_CutterOffsetEntities) this).AxisName = "X";
    ((F_CutterOffsetEntities) this).MaxSpeed = 3000.0;
    ((F_CutterOffsetEntities) this).Acceleration = 10000.0;
    ((F_CutterOffsetEntities) this).Deceleration = 10000.0;
    ((F_CutterOffsetEntities) this).Jerk = 4000.0;
    ((F_CutterOffsetEntities) this).AxisExplanation = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static string AxisToString(MachineAxisInfo AxisInfo)
  {
    return $"{buLangTranslate.preDef.Axes} {((F_CutterOffsetEntities) AxisInfo).AxisName} - {buLangTranslate.preDef.Speed} {((F_CutterOffsetEntities) AxisInfo).MaxSpeed.ToString()} - {buLangTranslate.preDef.Acceleration} {((F_CutterOffsetEntities) AxisInfo).Acceleration.ToString()} - {buLangTranslate.preDef.Deceleration} {((F_CutterOffsetEntities) AxisInfo).Deceleration.ToString()} - {buLangTranslate.preDef.Jerk} {((F_CutterOffsetEntities) AxisInfo).Jerk.ToString()} - {buLangTranslate.preDef.Explanation} {((F_CutterOffsetEntities) AxisInfo).AxisExplanation}";
  }

  public override string ToString()
  {
    return $"{((F_CutterOffsetEntities) this).AxisName} - Speed: {((F_CutterOffsetEntities) this).MaxSpeed.ToString("f3")} - Acc: {((F_CutterOffsetEntities) this).Acceleration.ToString("f3")} - Dec: {((F_CutterOffsetEntities) this).Deceleration.ToString("f3")} - Jerk: {((F_CutterOffsetEntities) this).Jerk.ToString("f3")} - Exp:{((F_CutterOffsetEntities) this).AxisExplanation}";
  }

  public abstract void m000959();

  public F_Devide()
  {
    ((F_CutterOffsetEntities) this).MCode = "M6";
    ((F_CutterOffsetEntities) this).ExtraCode = "";
    ((F_CutterOffsetEntities) this).TimeAsSec = 1.0;
    ((F_CutterOffsetEntities) this).MCodeExplanation = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public F_Devide(MachineMCodeInfo data)
  {
    ((F_CutterOffsetEntities) this).MCode = "M6";
    ((F_CutterOffsetEntities) this).ExtraCode = "";
    ((F_CutterOffsetEntities) this).TimeAsSec = 1.0;
    ((F_CutterOffsetEntities) this).MCodeExplanation = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static string MCodeToString(MachineMCodeInfo MCodeInfo)
  {
    return $"M {buLangTranslate.preDef.Code} {((F_CutterOffsetEntities) MCodeInfo).MCode} - {buLangTranslate.preDef.Time} {((F_CutterOffsetEntities) MCodeInfo).TimeAsSec.ToString()} - {buLangTranslate.preDef.Extra} {((F_CutterOffsetEntities) MCodeInfo).ExtraCode} - {buLangTranslate.preDef.Explanation} {((F_CutterOffsetEntities) MCodeInfo).MCodeExplanation}";
  }

  public override string ToString()
  {
    return $"{((F_CutterOffsetEntities) this).MCode} - TimeAsSec: {((F_CutterOffsetEntities) this).TimeAsSec.ToString("f3")} - ExtraCode: {((F_CutterOffsetEntities) this).ExtraCode}";
  }

  public abstract void m00095E();

  public F_Devide()
  {
    ((F_CutterOffsetEntities) this).OtherCode = "";
    ((F_CutterOffsetEntities) this).TimeAsSec = 1.0;
    ((F_CutterOffsetEntities) this).ExtraCode = "";
    ((F_CutterOffsetEntities) this).OtherCodeExplanation = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public F_Devide(MachineOtherCodeInfo data)
  {
    ((F_CutterOffsetEntities) this).OtherCode = "";
    ((F_CutterOffsetEntities) this).TimeAsSec = 1.0;
    ((F_CutterOffsetEntities) this).ExtraCode = "";
    ((F_CutterOffsetEntities) this).OtherCodeExplanation = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static string OtherCodeToString(MachineOtherCodeInfo OtherCodeInfo)
  {
    return $"{buLangTranslate.preDef.Other} {buLangTranslate.preDef.Code} {((F_CutterOffsetEntities) OtherCodeInfo).OtherCode} - {buLangTranslate.preDef.Time} {((F_CutterOffsetEntities) OtherCodeInfo).TimeAsSec.ToString()} - {buLangTranslate.preDef.Extra} {((F_CutterOffsetEntities) OtherCodeInfo).ExtraCode} - {buLangTranslate.preDef.Explanation} {((F_CutterOffsetEntities) OtherCodeInfo).OtherCodeExplanation}";
  }

  public override string ToString()
  {
    return $"{((F_CutterOffsetEntities) this).OtherCode} - TimeAsSec: {((F_CutterOffsetEntities) this).TimeAsSec.ToString("f3")} - ExtraCode: {((F_CutterOffsetEntities) this).ExtraCode}";
  }

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;
}
