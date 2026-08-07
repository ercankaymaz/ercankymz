// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buMW;
using ModuleWorks;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0002;

internal class \u0001 : DummyParamInteractor
{
  public \u0001(MWIterationOption data)
  {
    ((MWIterationOption) this).getContour = false;
    ((MWIterationOption) this).StartPoint = new Pnt6D();
    ((MWCalculationResultEventArg) this).EndPoint = new Pnt6D();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((MWIterationOption) this).getContour = data.getContour;
    ((MWIterationOption) this).StartPoint = new Pnt6D(data.StartPoint);
    ((MWCalculationResultEventArg) this).EndPoint = new Pnt6D(((MWCalculationResultEventArg) data).EndPoint);
  }

  public \u0001([In] Unit obj0)
    : base(obj0)
  {
  }
}
