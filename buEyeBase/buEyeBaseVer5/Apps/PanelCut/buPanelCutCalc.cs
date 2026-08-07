// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.buPanelCutCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

public class buPanelCutCalc
{
  internal int \u0001([In] ProfileOperation obj0, [In] ProfileOperation obj1)
  {
    return ((ProfileRuntimeSettings) obj0).MinPoint.X.CompareTo(((ProfileRuntimeSettings) obj1).MinPoint.X);
  }

  internal int \u0001([In] GProfileOperation obj0, [In] GProfileOperation obj1)
  {
    return ((FlatViewSettings) ((ProfileRuntimeSettings) obj0).SizePoint).MinPoint.X.CompareTo(((FlatViewSettings) ((ProfileRuntimeSettings) obj1).SizePoint).MinPoint.X);
  }

  internal int \u0002([In] GProfileOperation obj0, [In] GProfileOperation obj1)
  {
    return ((FlatViewSettings) ((ProfileRuntimeSettings) obj0).SizePoint).MinPoint.X.CompareTo(((FlatViewSettings) ((ProfileRuntimeSettings) obj1).SizePoint).MinPoint.X);
  }

  internal int \u0003([In] GProfileOperation obj0, [In] GProfileOperation obj1)
  {
    return ((ProfileVisualSettings) obj0).Priority.CompareTo(((ProfileVisualSettings) obj1).Priority);
  }

  internal int \u0001([In] ProfileOperationSortItem obj0, [In] ProfileOperationSortItem obj1)
  {
    return ((FlatViewSettings) ((PanelCutMoveCommand) obj0).SizePoint).MinPoint.X.CompareTo(((FlatViewSettings) ((PanelCutMoveCommand) obj1).SizePoint).MinPoint.X);
  }

  public buPanelCutCalc()
  {
    ((ProfileSettings) this).Name = "Job";
    ((ProfileSettings) this).Operation = new List<ProfileOperation>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buPanelCutCalc(ProfileJob data)
  {
    ((ProfileSettings) this).Name = "Job";
    ((ProfileSettings) this).Operation = new List<ProfileOperation>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }
}
