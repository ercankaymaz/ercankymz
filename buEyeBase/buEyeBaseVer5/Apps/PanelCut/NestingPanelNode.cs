// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.NestingPanelNode
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class NestingPanelNode : buSerilization5
{
  public double TappingDiameter;
  public double TappingDepth;
  public double TappingPitch;
  public double TappingAddition;
  public static byte f004559;
  public double FreeDrawWidth;
  public double FreeDrawHeight;
  public double FreeDrawAngle;
  public ProfileScaleCenterType FreeDrawScaleCenter;
  public Color FreeDrawColor;
  public double FreeDrawThickness;
  public static byte f004560;
  public double TextWidth;
  public double TextHeight;
  public double TextAngle;
  public string TextString;
  public double CharSpace;
  public double SpaceValue;
  public bool isWire;
  public Font TextFont;

  public NestingPanelNode(ProfileBase data)
  {
    ((ProfileSettings) this).Name = "Job";
    ((ProfileSettings) this).isSimulationDone = false;
    ((ProfileSettings) this).FirstItem = (ProfileItem) null;
    ((ProfileSettings) this).SecondItem = (ProfileItem) null;
    ((ProfileSettings) this).ThirdItem = (ProfileItem) null;
    ((ProfileSettings) this).FourthItem = (ProfileItem) null;
    ((ProfileSettings) this).GCodes = (ArrayList) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    if (((ProfileSettings) data).FirstItem != null)
      ((ProfileSettings) this).FirstItem = (ProfileItem) new PanelCutRuntimeSettings(((ProfileSettings) data).FirstItem);
    if (((ProfileSettings) data).SecondItem == null)
      return;
    ((ProfileSettings) this).SecondItem = (ProfileItem) new PanelCutRuntimeSettings(((ProfileSettings) data).SecondItem);
  }

  public static ArrayList ToDef(ProfileBase Item, int Space)
  {
    string str1 = new string(' ', Space);
    string str2 = new string(' ', Space + 2);
    ArrayList def = new ArrayList();
    def.Add((object) (str1 + "<ProfileBase>"));
    if (((ProfileSettings) Item).FirstItem != null)
    {
      def.Add((object) (str2 + "<FirstItem>"));
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) PanelCutTempVars.ToDef(((ProfileSettings) Item).FirstItem, Space + 4));
      def.AddRange((ICollection) c);
      def.Add((object) (str2 + "</FirstItem>"));
    }
    if (((ProfileSettings) Item).SecondItem != null)
    {
      def.Add((object) (str2 + "<SecondItem>"));
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) PanelCutTempVars.ToDef(((ProfileSettings) Item).SecondItem, Space + 4));
      def.AddRange((ICollection) c);
      def.Add((object) (str2 + "<SecondItem>"));
    }
    def.Add((object) (str1 + "</ProfileBase>"));
    return def;
  }

  public static void Decode(List<string> AL, ref ProfileBase Job)
  {
    Job = (ProfileBase) new NestingPanel();
    List<string> CalcList1 = new List<string>();
    buStatics.ListToSpecificList("<ProfileBase>", "</ProfileBase>", true, AL, ref CalcList1);
    if (CalcList1.Count <= 0)
      return;
    ArrayList CalcList2 = new ArrayList();
    buStatics.ListToSpecificList("<FirstItem>", "</FirstItem>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      ((ProfileSettings) Job).FirstItem = (ProfileItem) new PanelCutRuntimeSettings();
      buMarbleCalc.Decode(CalcList2, ref ((ProfileSettings) Job).FirstItem);
    }
    ArrayList CalcList3 = new ArrayList();
    buStatics.ListToSpecificList("<SecondItem>", "</SecondItem>", false, CalcList1, ref CalcList3);
    if (CalcList3.Count <= 0)
      return;
    ((ProfileSettings) Job).SecondItem = (ProfileItem) new PanelCutRuntimeSettings();
    buMarbleCalc.Decode(CalcList3, ref ((ProfileSettings) Job).SecondItem);
  }
}
