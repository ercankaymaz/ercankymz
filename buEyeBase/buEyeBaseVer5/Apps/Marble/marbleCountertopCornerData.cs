// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopCornerData
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
public class marbleCountertopCornerData : buSerilization5
{
  public double FinishSurfOffset;
  public double FinishAngleStep;
  public double FinishDevideLen;
  public double FinishVerticalDevideLen;

  public marbleCountertopCornerData(MarbleItem data)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(List<MarbleItem> Items, ref List<MarbleItem> CopyItems)
  {
    CopyItems = new List<MarbleItem>();
    for (int index = 0; index <= Items.Count - 1; ++index)
      CopyItems.Add((MarbleItem) new marbleCountertopCornerData(Items[index]));
  }

  public static ArrayList ToDef(MarbleItem refItem, int Space)
  {
    ArrayList def = new ArrayList();
    screenInfo.ExceptionalVariables.Clear();
    screenInfo.ExceptionalVariables.Add("ErrorMessages");
    screenInfo.ExceptionalVariables.Add("WarningMessages");
    screenInfo.ExceptionalVariables.Add("ItemEntities");
    screenInfo.ExceptionalVariables.Add("OsnapPoints");
    screenInfo.ExceptionalVariables.Add("CamList");
    screenInfo.ExceptionalVariables.Add("EntGroup");
    screenInfo.ExceptionalVariables.Add("ItemEntities");
    screenInfo.ExceptionalVariables.Add("Edges");
    screenInfo.ExceptionalVariables.Add("Collapses");
    screenInfo.ExceptionalVariables.Add("Settings");
    buSerilization5.ClassToString((object) refItem);
    def.AddRange((ICollection) refItem.ToDefAll("", Space, (SerilizationMode5) 1));
    if (def.Count > 0)
    {
      string str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ItemSettings>"));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).MaterialParameter)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).ReadSurfaceParameter)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).SawFeedAnalysisParameter)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingAirDry)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingChamferCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingColoumnsCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingDrillCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingLatheCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingLatheVerticalCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingMarbleCam)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingMaterialClean)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingProfileCurveCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingProfileCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingSliceCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 4) + buSerilization5.ClassToString((object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingSweepCut)));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ItemSettings>"));
      if ((((MarbleScreenCaptureSettings) refItem).Edges == null ? 0 : (((MarbleScreenCaptureSettings) refItem).Edges.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ItemEdges>"));
        for (int index = 0; index <= ((MarbleScreenCaptureSettings) refItem).Edges.Count - 1; ++index)
        {
          def.Add((object) (buImage5.SpaceChar(Space + 4) + "<ItemEdge>"));
          def.AddRange((ICollection) ((MarbleScreenCaptureSettings) refItem).Edges[index].ToDefAll("", Space + 6, (SerilizationMode5) 1));
          if (((MarbleSliceType) ((MarbleScreenCaptureSettings) refItem).Edges[index]).refEntity != null)
          {
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "<ItemEdgeRefEntity>"));
            def.AddRange((ICollection) buText.ToDefEntity(((MarbleSliceType) ((MarbleScreenCaptureSettings) refItem).Edges[index]).refEntity, Space + 8));
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "</ItemEdgeRefEntity>"));
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "<ItemEdgeDrawEntity>"));
            def.AddRange((ICollection) buText.ToDefEntity(((MarbleSliceType) ((MarbleScreenCaptureSettings) refItem).Edges[index]).drawEntity, Space + 8));
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "</ItemEdgeDrawEntity>"));
          }
          def.Add((object) (buImage5.SpaceChar(Space + 4) + "</ItemEdge>"));
        }
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ItemEdges>"));
      }
      if ((((MarbleScreenCaptureSettings) refItem).Collapses == null ? 0 : (((MarbleScreenCaptureSettings) refItem).Collapses.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ItemCollapses>"));
        for (int index = 0; index <= ((MarbleScreenCaptureSettings) refItem).Collapses.Count - 1; ++index)
          def.AddRange((ICollection) ((MarbleScreenCaptureSettings) refItem).Collapses[index].ToDefAll("", Space + 4, (SerilizationMode5) 1));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ItemCollapses>"));
      }
      if (((MarbleScreenCaptureSettings) refItem).EntGroup != null)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ItemEntGroup>"));
        def.AddRange((ICollection) DimensionGroup.ToDefGroup(((MarbleScreenCaptureSettings) refItem).EntGroup, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ItemEntGroup>"));
      }
      if (((MarbleScreenCaptureSettings) refItem).EntGroupBottom != null)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ItemEntGroupBottom>"));
        def.AddRange((ICollection) DimensionGroup.ToDefGroup(((MarbleScreenCaptureSettings) refItem).EntGroupBottom, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ItemEntGroupBottom>"));
      }
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ItemEntities>"));
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrawWireEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrawWireEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<DrawWireEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrawWireEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</DrawWireEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConcaveEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConcaveEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<ConcaveEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConcaveEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</ConcaveEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConvexEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConvexEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<ConvexEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConvexEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</ConvexEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrillEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConcaveEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<DrillEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrillEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</DrillEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EdgeEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EdgeEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<EdgeEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EdgeEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</EdgeEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ExtensionEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ExtensionEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<ExtensionEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ExtensionEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</ExtensionEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).WireEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).WireEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<WireEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).WireEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</WireEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BaseEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BaseEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<BaseEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BaseEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</BaseEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).CamEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).CamEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<CamEntities>"));
        def.AddRange((ICollection) buMultilineText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).CamEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</CamEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BorderEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BorderEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<BorderEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BorderEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</BorderEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EngravingEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EngravingEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<EngravingEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EngravingEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</EngravingEntities>"));
      }
      if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).SawEntities == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).TextEntities.Count > 0 ? 1 : 0)) != 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<TextEntities>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).TextEntities, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</TextEntities>"));
      }
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ItemEntities>"));
      if ((((MarbleScreenCaptureSettings) refItem).CamList == null ? 0 : (((MarbleScreenCaptureSettings) refItem).CamList.Count > 0 ? 1 : 0)) != 0)
        ;
      def.Add((object) str);
    }
    return def;
  }
}
