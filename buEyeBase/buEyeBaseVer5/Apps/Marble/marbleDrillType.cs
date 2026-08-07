// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleDrillType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleDrillType : buSerilization5
{
  public double OffsetLeadOutAngle;
  public double OffsetInsideOffset;
  public double OffsetOutsideOffset;

  public static void Copy(MarbleItemCam refCam, ref MarbleItemCam copiedCam)
  {
    if (refCam == null)
      return;
    copiedCam = (MarbleItemCam) new marbleMenuType(refCam);
  }

  public static void Copy(List<MarbleItemCam> refCam, ref List<MarbleItemCam> copiedCam)
  {
    if (refCam == null)
      return;
    copiedCam = new List<MarbleItemCam>();
    for (int index = 0; index <= copiedCam.Count - 1; ++index)
      copiedCam.Add((MarbleItemCam) new marbleMenuType(refCam[index]));
  }

  public static ArrayList ToDef(MarbleItemCam refItemCam, int Space)
  {
    ArrayList def = new ArrayList();
    screenInfo.ExceptionalVariables.Clear();
    screenInfo.ExceptionalVariables.Add("EntityList");
    screenInfo.ExceptionalVariables.Add("ToolSelected");
    screenInfo.ExceptionalVariables.Add("setCam");
    def.AddRange((ICollection) refItemCam.ToDefAll("", Space, (SerilizationMode5) 1));
    if (def.Count > 0)
    {
      string str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      if (((MarbleMachineOptionsSettings) refItemCam).EntityList != null)
        ;
      if (((MarbleMachineOptionsSettings) refItemCam).ToolSelected != null)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ToolSelected>"));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((ToolGeometry5) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected).Data)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((ToolGeometry5) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected).Geometry)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((ToolGeometry5) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected).CamData)));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ToolSelected>"));
      }
      if (((MarbleMachineOptionsSettings) refItemCam).setCam != null)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<CamSettings>"));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Offsets)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Distances)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((camOffset5) ((MarbleMachineOptionsSettings) refItemCam).setCam).Drill)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Operations)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Options)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Pockets)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Speeds)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Steps)));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Strategy)));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</CamSettings>"));
      }
      if ((((MarbleMachineOptionsSettings) refItemCam).WireAuxEntities == null ? 0 : (((MarbleMachineOptionsSettings) refItemCam).WireAuxEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<WireAuxEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineOptionsSettings) refItemCam).WireAuxEntities, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</WireAuxEntities>"));
      }
      if ((((MarbleMachineOptionsSettings) refItemCam).WireEntities == null ? 0 : (((MarbleMachineOptionsSettings) refItemCam).WireEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<WireEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineOptionsSettings) refItemCam).WireEntities, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</WireEntities>"));
      }
      if ((((MarbleMachineOptionsSettings) refItemCam).ConcaveEntities == null ? 0 : (((MarbleMachineOptionsSettings) refItemCam).ConcaveEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ConcaveEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineOptionsSettings) refItemCam).ConcaveEntities, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ConcaveEntities>"));
      }
      if ((((MarbleMachineOptionsSettings) refItemCam).ConvexEntities == null ? 0 : (((MarbleMachineOptionsSettings) refItemCam).ConvexEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ConvexEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineOptionsSettings) refItemCam).ConvexEntities, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ConvexEntities>"));
      }
      if ((((MarbleMachineOptionsSettings) refItemCam).DrillEntities == null ? 0 : (((MarbleMachineOptionsSettings) refItemCam).DrillEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<DrillEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineOptionsSettings) refItemCam).DrillEntities, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</DrillEntities>"));
      }
      def.Add((object) str);
    }
    return def;
  }
}
