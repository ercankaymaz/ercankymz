// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillTempVars
{
  public bool StepEnable;
  public double StepValue;
  public double Offset;
  public double FeedPlunge;
  public double FeedCut;
  public double SpindleSpeed;
  public bool SmallContour;
  public int NumberNextHorizontalItem;

  public DrillTempVars(FoamItem data)
  {
    ((DrillCalcItem) this).ItemName = "";
    ((DrillCalcItem) this).FileName = "";
    ((DrillCalcItem) this).FileNameFull = "";
    ((DrillCalcItem) this).isError = false;
    ((DrillCalcItem) this).isGCodeCreated = false;
    ((DrillCalcItem) this).CreatedFromDrawing = false;
    ((DrillCalcItem) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((DrillCalcItem) this).TextureName = "";
    ((DrillCalcItem) this).colorFoam = Color.DarkGray;
    ((DrillCalcItem) this).Transparency = 120;
    ((DrillCalcItem) this).MinPoint = new Point3D();
    ((DrillCalcItem) this).MaxPoint = new Point3D();
    ((DrillCalcItem) this).SolidEntity = (Entity) null;
    ((DrillCalcItem) this).BlockXZ = new List<FoamBlock>();
    ((DrillCalcItem) this).BlockYZ = new List<FoamBlock>();
    ((DrillCalcItem) this).CamXZ = new camTp();
    ((DrillCalcItem) this).CamYZ = new camTp();
    ((DrillCalcItem) this).sortedEntitiesYZ = new List<buEntity>();
    ((DrillCalcItem) this).sortedEntitiesXZ = new List<buEntity>();
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
    for (int index = 0; index <= ((DrillCalcItem) data).BlockXZ.Count - 1; ++index)
      ((DrillCalcItem) this).BlockXZ.Add((FoamBlock) new DrillUpdateArg(((DrillCalcItem) data).BlockXZ[index]));
    for (int index = 0; index <= ((DrillCalcItem) data).BlockYZ.Count - 1; ++index)
      ((DrillCalcItem) this).BlockYZ.Add((FoamBlock) new DrillUpdateArg(((DrillCalcItem) data).BlockYZ[index]));
    if (((DrillCalcItem) data).SolidEntity != null)
      ((DrillCalcItem) this).SolidEntity = buVector5.CopyEntities(((DrillCalcItem) data).SolidEntity);
    ((DrillCalcItem) this).CamXZ = new camTp(((DrillCalcItem) data).CamXZ);
    ((DrillCalcItem) this).CamYZ = new camTp(((DrillCalcItem) data).CamYZ);
    buRadialDim.Copy(((DrillCalcItem) data).sortedEntitiesXZ, ref ((DrillCalcItem) this).sortedEntitiesXZ);
    buRadialDim.Copy(((DrillCalcItem) data).sortedEntitiesYZ, ref ((DrillCalcItem) this).sortedEntitiesYZ);
  }

  public static ArrayList ToDef(FoamItem refItem, int Space)
  {
    ArrayList def = new ArrayList();
    screenInfo.ExceptionalVariables.Add("CamXZ");
    screenInfo.ExceptionalVariables.Add("CamYZ");
    def.AddRange((ICollection) refItem.ToDefAll("", Space, (SerilizationMode5) 1));
    screenInfo.ExceptionalVariables.Clear();
    if (def.Count > 0)
    {
      string str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      if (((DrillCalcItem) refItem).BlockXZ.Count > 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<BlocksXZ>"));
        for (int index = 0; index <= ((DrillCalcItem) refItem).BlockXZ.Count - 1; ++index)
          def.AddRange((ICollection) ClamperInsideCalc.ToDef(((DrillCalcItem) refItem).BlockXZ[index], Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</BlocksXZ>"));
      }
      if (((DrillCalcItem) refItem).BlockYZ.Count > 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<BlocksYZ>"));
        for (int index = 0; index <= ((DrillCalcItem) refItem).BlockYZ.Count - 1; ++index)
          def.AddRange((ICollection) ClamperInsideCalc.ToDef(((DrillCalcItem) refItem).BlockYZ[index], Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</BlocksYZ>"));
      }
      if (((DrillCalcItem) refItem).sortedEntitiesXZ.Count > 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<sortedEntitiesXZ>"));
        def.AddRange((ICollection) buText.ToDefEntity(((DrillCalcItem) refItem).sortedEntitiesXZ, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</sortedEntitiesXZ>"));
      }
      if (((DrillCalcItem) refItem).sortedEntitiesYZ.Count > 0)
      {
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "<sortedEntitiesYZ>"));
        def.AddRange((ICollection) buText.ToDefEntity(((DrillCalcItem) refItem).sortedEntitiesYZ, Space + 4));
        def.Add((object) (buImage5.SpaceChar(Space + 2) + "</sortedEntitiesYZ>"));
      }
      def.Add((object) str);
    }
    return def;
  }
}
