// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CurveToSurfaceSettingsType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class CurveToSurfaceSettingsType : buSerilization5
{
  public int Priority;
  public double SizeMaterailWidth;
  public double SizeMaterailHeight;
  public double SizeMaterailDepth;
  public double ExtraDepth;
  public double ManuelDepthStart;
  public double IncrementalDistance;
  public double RectangleWidth;
  public double RectangleHeight;

  public CurveToSurfaceSettingsType()
  {
    ((SortbuResult) this).Tool = (ToolBase5) new ToolGeometry5();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CurveToSurfaceSettingsType(SortCamData data)
  {
    ((SortbuResult) this).Tool = (ToolBase5) new ToolGeometry5();
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
    ((SortbuResult) this).Tool = (ToolBase5) new ToolGeometry5(((SortbuResult) data).Tool);
  }

  public CurveToSurfaceSettingsType()
  {
    ((SortbuResult) this).FirstPoint = new Point3D();
    ((SortbuResult) this).LastPoint = new Point3D();
    ((SortbuResult) this).ResultType = SortingResultType.None;
    ((SortbuResult) this).SelectedEntitiesIndex = new List<int>();
    ((SortbuResult) this).LastCalculatedEntities = new List<Entity>();
    ((SortbuAskMe) this).AskMeEntites = new List<Entity>();
    ((SortbuAskMe) this).LastSelectedEntitiesIndex = new List<int>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CurveToSurfaceSettingsType()
  {
    ((SortbuAskMe) this).Return = false;
    ((SortbuAskMe) this).ReturnNextGroup = false;
    ((SortbuAskMe) this).GetBack = false;
    ((SortbuAskMe) this).GetBackFromMultiSelection = false;
    ((SortbuAskMe) this).SelectedIndex = 0;
    ((SortbuAskMe) this).CatchPoint = new Point3D();
    ((SortbuAskMe) this).EntitiesIndex = new List<int>();
    ((SortbuAskMe) this).FoundEntities = new List<Entity>();
    ((SortbuAskMe) this).SortedEntities = new List<Entity>();
    ((SortbuAskMe) this).TempEntities = new List<Entity>();
    ((SortbuAskMe) this).RemovedEntities = new List<List<Entity>>();
    ((SortbuAskMe) this).LastMarkPosition = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
