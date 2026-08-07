// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace \u001F;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
internal class \u0002 : Attribute
{
  static void \u0001([In] F_MarbleContourAdvancedSettings obj0)
  {
    ((marbleProfileCurveCutPars) MarbleRuntimeSettings.varMarbleSettings).OutsideEntityIsReferance = ((F_SketchLibrary) obj0).chk_outsideentityreferance.Check;
  }
}
