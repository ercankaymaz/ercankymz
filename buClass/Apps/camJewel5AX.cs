// Decompiled with JetBrains decompiler
// Type: buClass.Apps.camJewel5AX
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass.Apps;

public class camJewel5AX : camBase
{
  public jewelCam Data = new jewelCam();

  public camJewel5AX()
  {
  }

  public camJewel5AX(camJewel5AX camm)
  {
  }

  public camJewel5AX(jewelCam data) => this.Data = new jewelCam(data);

  public override string ToString() => "( Jewel 5AX -> ";
}
