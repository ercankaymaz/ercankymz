// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.PanelWaitAssembly
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelWaitAssembly : buSerilization5
{
  public double CutAngle;
  public Color CutColor;
  public double CutThickness;
  public static byte f00453D;

  public static ArrayList ToDef(List<ProfileJob> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) PanelWaitAssembly.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) c);
    }
    return def;
  }

  public static ArrayList ToDef(ProfileJob Item, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Item.ToDefAll("", 2, (SerilizationMode5) 1).ToArray());
    def.RemoveAt(def.Count - 1);
    def.AddRange((ICollection) PanelCutTempVars.ToDef(((ProfileSettings) Item).Items, Space + 2));
    def.Add((object) (str + "</ProfileJob>"));
    return def;
  }
}
