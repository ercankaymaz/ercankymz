// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buPipeBendCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buPipeBendCalc
{
  public const PolyType ptSubject = ; // Unable to render the field
  public const PolyType ptClip = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const PolyFillType pftEvenOdd = ; // Unable to render the field
  public const PolyFillType pftNonZero = ; // Unable to render the field
  public const PolyFillType pftPositive = ; // Unable to render the field
  public const PolyFillType pftNegative = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const JoinType jtSquare = ; // Unable to render the field
  public const JoinType jtRound = ; // Unable to render the field
  public const JoinType jtMiter = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const EndType etClosedPolygon = ; // Unable to render the field
  public const EndType etClosedLine = ; // Unable to render the field
  public const EndType etOpenButt = ; // Unable to render the field
  public const EndType etOpenSquare = ; // Unable to render the field
  public const EndType etOpenRound = ; // Unable to render the field

  public int Compare(IntersectNode node1, IntersectNode node2)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    long num = (^(DoorRuntimeSettings&) ref ((PipeBendSimulationMove) node2).\u0001).Y - (^(DoorRuntimeSettings&) ref ((PipeBendSimulationMove) node1).\u0001).Y;
    return num <= 0L ? (num >= 0L ? 0 : -1) : 1;
  }

  public buPipeBendCalc()
  {
  }

  public buPipeBendCalc()
  {
  }

  public buPipeBendCalc()
  {
  }

  public buPipeBendCalc()
  {
  }

  public buPipeBendCalc()
  {
  }

  public buPipeBendCalc()
  {
  }

  public buPipeBendCalc()
  {
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_PreserveCollinear() => ((PipeBendSettings) this).\u0003;

  [CompilerGenerated]
  [SpecialName]
  public void set_PreserveCollinear(bool value) => ((PipeBendSettings) this).\u0003 = value;

  public void Swap(ref long val1, ref long val2)
  {
    long num = val1;
    val1 = val2;
    val2 = num;
  }

  internal buPipeBendCalc()
  {
    ((PipeBendingProgramSettings) this).\u0001 = new List<List<\u0084.\u0001>>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((PipeBendDiskBlocks) this).\u0001 = (\u0008.\u0001) null;
    ((PipeBendDiskBlocks) this).\u0002 = (\u0008.\u0001) null;
    ((PipeBendSettings) this).\u0001 = false;
    ((PipeBendSettings) this).\u0002 = false;
  }

  public virtual void Clear()
  {
    \u0007.\u0001.\u0001((buClipperBase) this);
    for (int index1 = 0; index1 < ((PipeBendingProgramSettings) this).\u0001.Count; ++index1)
    {
      for (int index2 = 0; index2 < ((PipeBendingProgramSettings) this).\u0001[index1].Count; ++index2)
        ((PipeBendingProgramSettings) this).\u0001[index1][index2] = (\u0084.\u0001) null;
      ((PipeBendingProgramSettings) this).\u0001[index1].Clear();
    }
    ((PipeBendingProgramSettings) this).\u0001.Clear();
    ((PipeBendSettings) this).\u0001 = false;
    ((PipeBendSettings) this).\u0002 = false;
  }

  public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
  {
    // ISSUE: unable to decompile the method.
  }

  internal virtual void \u0001()
  {
    ((PipeBendDiskBlocks) this).\u0002 = ((PipeBendDiskBlocks) this).\u0001;
    if (((PipeBendDiskBlocks) this).\u0002 == null)
      return;
    ((PipeBendingProgramSettings) this).\u0001 = (\u0018.\u0001) null;
    for (\u0008.\u0001 obj1 = ((PipeBendDiskBlocks) this).\u0001; obj1 != null; obj1 = ((PipeBendSimulationMove) obj1).\u0001)
    {
      \u0007.\u0001.\u0001((buClipperBase) this, ((PipeBendSimulationMove) obj1).\u0001);
      \u0084.\u0001 obj2 = ((PipeBendSimulationMove) obj1).\u0001;
      if (obj2 != null)
      {
        ((PipeBendJob) obj2).\u0002 = ((PipeBendJob) obj2).\u0001;
        ((PipeBendMove) obj2).\u0004 = -1;
      }
      \u0084.\u0001 obj3 = ((PipeBendSimulationMove) obj1).\u0002;
      if (obj3 != null)
      {
        ((PipeBendJob) obj3).\u0002 = ((PipeBendJob) obj3).\u0001;
        ((PipeBendMove) obj3).\u0004 = -1;
      }
    }
    ((PipeBendingProgramSettings) this).\u0001 = (\u0084.\u0001) null;
  }

  public static IntRect GetBounds(List<List<IntPoint>> paths)
  {
    int index1 = 0;
    int count = paths.Count;
    while ((index1 >= count ? 0 : (paths[index1].Count == 0 ? 1 : 0)) != 0)
      ++index1;
    IntRect bounds;
    if (index1 == count)
    {
      bounds = (IntRect) new DoorRuntimeSettings(0L, 0L, 0L, 0L);
    }
    else
    {
      IntRect intRect = new IntRect();
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      (^(DoorTempVars&) ref intRect).left = paths[index1][0].X;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      (^(DoorTempVars&) ref intRect).right = intRect.left;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      (^(DoorTempVars&) ref intRect).top = paths[index1][0].Y;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      (^(DoorTempVars&) ref intRect).bottom = intRect.top;
      for (; index1 < count; ++index1)
      {
        for (int index2 = 0; index2 < paths[index1].Count; ++index2)
        {
          if (paths[index1][index2].X < intRect.left)
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            (^(DoorTempVars&) ref intRect).left = paths[index1][index2].X;
          }
          else if (paths[index1][index2].X > intRect.right)
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            (^(DoorTempVars&) ref intRect).right = paths[index1][index2].X;
          }
          if (paths[index1][index2].Y < intRect.top)
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            (^(DoorTempVars&) ref intRect).top = paths[index1][index2].Y;
          }
          else if (paths[index1][index2].Y > intRect.bottom)
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            (^(DoorTempVars&) ref intRect).bottom = paths[index1][index2].Y;
          }
        }
      }
      bounds = intRect;
    }
    return bounds;
  }

  public abstract void m001A3C();

  [CompilerGenerated]
  [SpecialName]
  public buClipper.ZFillCallback get_ZFillFunction() => ((PipeBendTempVars) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_ZFillFunction(buClipper.ZFillCallback value)
  {
    // ISSUE: reference to a compiler-generated field
    ((PipeBendTempVars) this).\u0001 = value;
  }
}
