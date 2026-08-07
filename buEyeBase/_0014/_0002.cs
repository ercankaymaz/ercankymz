// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Controls;
using buEyeBaseVer5.Forms.Customer.DincMak;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0014;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal sealed class \u0002 : Attribute
{
  static void \u0001([In] F_SlotShape obj0)
  {
    ((F_ControlUIButton) obj0).SafeDis = ((F_ControlUISettings) obj0).spn_safedis.Value;
    ((F_ControlUIButton) obj0).RapidDis = ((F_ControlUISettings) obj0).spn_rapiddis.Value;
    ((F_ControlUIButton) obj0).PlungeFeed = ((F_ControlUISettings) obj0).spn_plungefeed.Value;
    ((F_ControlUIButton) obj0).CuttingFeed = ((F_ControlUISettings) obj0).spn_cuttingfeed.Value;
    ((F_ControlUIButton) obj0).Depth = ((F_ControlUISettings) obj0).spn_slotdepth.Value;
    ((F_ControlUIButton) obj0).Diameter = ((F_ControlUISettings) obj0).spn_slotheight.Value;
    ((F_ControlUIButton) obj0).Width = ((F_ControlUISettings) obj0).spn_slotwidth.Value;
    ((F_ControlUIButton) obj0).XPos = ((F_ControlUISettings) obj0).spn_XPos.Value;
    ((F_ControlUIButton) obj0).YPos = ((F_ControlUISettings) obj0).spn_ZPos.Value;
    ((F_ControlUIButton) obj0).Step = ((F_ControlUISettings) obj0).spn_step.Value;
    if (((F_ControlUISettings) obj0).chk_contourcenter.Check)
      ((F_ControlUIButton) obj0).CamType = CamClosedContourType.Center;
    else if (((F_ControlUISettings) obj0).chk_contourinside.Check)
      ((F_ControlUIButton) obj0).CamType = CamClosedContourType.Inner;
    else
      ((F_ControlUIButton) obj0).CamType = CamClosedContourType.Outter;
    if (((F_ControlUISettings) obj0).chk_tool1.Check)
      ((F_ControlUIButton) obj0).ToolNo = 1;
    else if (((F_ControlUISettings) obj0).chk_tool2.Check)
      ((F_ControlUIButton) obj0).ToolNo = 2;
    else
      ((F_ControlUIButton) obj0).ToolNo = 3;
  }
}
