// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxesData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class CodesysAxesData
{
  public CodesysAxis AxisPar = new CodesysAxis();

  public CodesysAxesData()
  {
  }

  public CodesysAxesData(CodesysAxesData axis) => this.AxisPar = new CodesysAxis(axis.AxisPar);

  public CodesysAxesData(CodesysAxis axis) => this.AxisPar = new CodesysAxis(axis);
}
