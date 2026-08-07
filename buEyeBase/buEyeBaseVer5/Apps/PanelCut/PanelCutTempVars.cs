// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.PanelCutTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelCutTempVars
{
  public int stepCount;
  public double NotchCutPersentage;
  public double NotchSafeDistance;
  public double offsetFinish;
  public bool LeadIn;
  public bool LeadOut;
  public bool enableAreaClearanceOperation;
  public bool enableFinishOperation;

  public static ArrayList ToDef(List<ProfileItem> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) PanelCutTempVars.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) arrayList.ToArray());
    }
    return def;
  }

  public static ArrayList ToDef(ProfileItem refItem, int Space)
  {
    screenInfo.ExceptionalVariables.Add("GCodeList");
    screenInfo.ExceptionalVariables.Add("ClamperSettings");
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) refItem.ToDefAll("", Space, (SerilizationMode5) 1));
    if (def.Count > 0)
    {
      string str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      for (int index1 = 0; index1 <= ((ProfileSettings) refItem).Drawings.Count - 1; ++index1)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<Drawings>"));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<OutterEntitites>"));
        def.AddRange((ICollection) buText.ToDefEntity(((MarbleJob) ((ProfileSettings) refItem).Drawings[index1]).OutterEntitites, Space + 6));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</OutterEntitites>"));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<InnerEntitites>"));
        for (int index2 = 0; index2 <= ((MarbleJob) ((ProfileSettings) refItem).Drawings[index1]).InnerEntities.Count - 1; ++index2)
        {
          def.Add((object) (buImage5.SpaceChar(Space + 6) + "<InnerEntititesSub>"));
          def.AddRange((ICollection) buText.ToDefEntity(((MarbleJob) ((ProfileSettings) refItem).Drawings[index1]).InnerEntities[index2], Space + 8));
          def.Add((object) (buImage5.SpaceChar(Space + 6) + "</InnerEntititesSub>"));
        }
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</InnerEntitites>"));
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<SolidProfileEntities>"));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity == null ? 0 : (((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity is Mesh ? 1 : 0)) != 0)
        {
          // ISSUE: reference to a compiler-generated field
          buMesh refEntity = (buMesh) new buShapeFreeLines((Mesh) ((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity);
          def.AddRange((ICollection) buText.ToDefEntity((buEntity) refEntity, Space + 6));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity == null ? 0 : (((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity is Brep ? 1 : 0)) != 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity.BoxMin == (Point3D) null)
          {
            // ISSUE: reference to a compiler-generated field
            ((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity.Regen(0.2);
          }
          // ISSUE: reference to a compiler-generated field
          Mesh mesh = ((Brep) ((buMarbleCalc.\u0001) ((ProfileSettings) refItem).Drawings[index1]).SolidEntity).ConvertToMesh();
          if (mesh != null)
          {
            buMesh refEntity = (buMesh) new buShapeFreeLines(mesh);
            def.AddRange((ICollection) buText.ToDefEntity((buEntity) refEntity, Space + 6));
          }
        }
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</SolidProfileEntities>"));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</Drawings>"));
      }
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<ProfileOperation>"));
      for (int index3 = 0; index3 <= ((ProfileSettings) refItem).Operations.Count - 1; ++index3)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "<PrfOperation>"));
        def.AddRange((ICollection) buMarbleCalc.ToDef(((ProfileSettings) refItem).Operations[index3], "", Space + 6));
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
        {
          if ((((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiXYPlane == null ? 0 : (((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiXYPlane.Count > 0 ? 1 : 0)) != 0)
          {
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "<ContourEntititesXY>"));
            def.AddRange((ICollection) buText.ToDefEntity(((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiXYPlane, Space + 8));
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "</ContourEntititesXY>"));
          }
          else if ((((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiContour == null ? 0 : (((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiContour.Count > 0 ? 1 : 0)) != 0)
          {
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "<ContourEntitites>"));
            def.AddRange((ICollection) buText.ToDefEntity(((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiContour, Space + 8));
            def.Add((object) (buImage5.SpaceChar(Space + 6) + "</ContourEntitites>"));
          }
        }
        if (((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiSolidDepth != null)
        {
          for (int index4 = 0; index4 <= ((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiSolidDepth.Count - 1; ++index4)
          {
            if ((((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiSolidDepth[index4] == null ? 0 : (((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiSolidDepth[index4] is Mesh ? 1 : 0)) != 0)
            {
              def.Add((object) (buImage5.SpaceChar(Space + 6) + "<SolidOperationEntities>"));
              buMesh refEntity = (buMesh) new buShapeFreeLines((Mesh) ((ProfileRuntimeSettings) ((ProfileSettings) refItem).Operations[index3]).EntityMultiSolidDepth[index4]);
              def.AddRange((ICollection) buText.ToDefEntity((buEntity) refEntity, Space + 6));
              def.Add((object) (buImage5.SpaceChar(Space + 6) + "</SolidOperationEntities>"));
            }
          }
        }
        def.Add((object) (buImage5.SpaceChar(Space + 4) + "</PrfOperation>"));
      }
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</ProfileOperations>"));
      def.Add((object) str);
    }
    screenInfo.ExceptionalVariables.Clear();
    return def;
  }
}
