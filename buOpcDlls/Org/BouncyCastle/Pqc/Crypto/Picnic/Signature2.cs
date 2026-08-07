// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.Signature2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class Signature2
{
  internal byte[] salt;
  internal byte[] iSeedInfo;
  internal int iSeedInfoLen;
  internal byte[] cvInfo;
  internal int cvInfoLen;
  internal byte[] challengeHash;
  internal uint[] challengeC;
  internal uint[] challengeP;
  internal Signature2.Proof2[] proofs;

  internal Signature2(PicnicEngine engine)
  {
    this.challengeHash = new byte[engine.digestSizeBytes];
    this.salt = new byte[PicnicEngine.saltSizeBytes];
    this.challengeC = new uint[engine.numOpenedRounds];
    this.challengeP = new uint[engine.numOpenedRounds];
    this.proofs = new Signature2.Proof2[engine.numMPCRounds];
  }

  internal class Proof2
  {
    internal byte[] seedInfo;
    internal int seedInfoLen;
    internal byte[] aux;
    internal byte[] C;
    internal byte[] input;
    internal byte[] msgs;

    internal Proof2(PicnicEngine engine)
    {
      this.seedInfo = (byte[]) null;
      this.seedInfoLen = 0;
      this.C = new byte[engine.digestSizeBytes];
      this.input = new byte[engine.stateSizeBytes];
      this.aux = new byte[engine.andSizeBytes];
      this.msgs = new byte[engine.andSizeBytes];
    }
  }
}
