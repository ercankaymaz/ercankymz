// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.Msg
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class Msg
{
  internal byte[][] msgs;
  internal int pos;
  internal int unopened;

  internal Msg(PicnicEngine engine)
  {
    this.msgs = new byte[engine.numMPCParties][];
    for (int index = 0; index < engine.numMPCParties; ++index)
      this.msgs[index] = new byte[engine.andSizeBytes];
    this.pos = 0;
    this.unopened = -1;
  }
}
