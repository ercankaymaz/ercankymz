// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0006;
using buMarble;
using System;

#nullable disable
namespace \u000E;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
internal class \u0001 : Attribute
{
  public void Apply()
  {
    clsAppMarbleVars.varApp.WagonHidroStopSec = ((\u0004) this).spn_WagonHidroStopSec.Value;
    clsAppMarbleVars.varApp.WagonPosTimeOutSec = ((\u0004) this).spn_WagonPosTimeOutSec.Value;
    clsAppMarbleVars.varApp.WagonUpPositionA = ((\u0004) this).spn_WagonUpPositionA.Value;
    clsAppMarbleVars.varApp.WagonUpPositionC = ((\u0004) this).spn_WagonUpPositionC.Value;
    clsAppMarbleVars.varApp.WagonUpPositionX = ((\u0005.\u0001) this).spn_WagonUpPositionX.Value;
    clsAppMarbleVars.varApp.WagonUpPositionY = ((\u0005.\u0001) this).spn_WagonUpPositionY.Value;
    clsAppMarbleVars.varApp.WagonUpPositionZ = ((\u0005.\u0001) this).spn_WagonUpPositionZ.Value;
  }
}
