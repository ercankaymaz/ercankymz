// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PipeBendData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendData : buSerilization5
{
  internal \u0012.\u0002 \u0002;
  internal PolyNode \u0001;

  public static List<List<IntPoint>> ClosedPathsFromPolyTree(PolyTree polytree)
  {
    List<List<IntPoint>> intPointListList = new List<List<IntPoint>>();
    intPointListList.Capacity = ((Router3AXSettings) polytree).get_Total();
    PipeBendSimulationMove.\u0001((PolyNode) polytree, (buClipper.\u0001) 2, intPointListList);
    return intPointListList;
  }

  static PipeBendData()
  {
    PipeBendRuntimeSettings.\u0001 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
    PipeBendRuntimeSettings.\u0002 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  }

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern PipeBendData(object @object, IntPtr method);
}
