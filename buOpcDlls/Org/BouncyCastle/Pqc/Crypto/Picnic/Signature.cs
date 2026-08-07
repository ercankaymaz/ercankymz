// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.Signature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class Signature
{
  internal byte[] challengeBits;
  internal byte[] salt;
  internal Signature.Proof[] proofs;

  internal Signature(PicnicEngine engine)
  {
    this.salt = new byte[PicnicEngine.saltSizeBytes];
    this.challengeBits = new byte[PicnicUtilities.NumBytes(engine.numMPCRounds * 2)];
    this.proofs = new Signature.Proof[engine.numMPCRounds];
    for (int index = 0; index < this.proofs.Length; ++index)
      this.proofs[index] = new Signature.Proof(engine);
  }

  internal class Proof
  {
    internal byte[] seed1;
    internal byte[] seed2;
    internal uint[] inputShare;
    internal byte[] communicatedBits;
    internal byte[] view3Commitment;
    internal byte[] view3UnruhG;

    internal Proof(PicnicEngine engine)
    {
      this.seed1 = new byte[engine.seedSizeBytes];
      this.seed2 = new byte[engine.seedSizeBytes];
      this.inputShare = new uint[engine.stateSizeBytes];
      this.communicatedBits = new byte[engine.andSizeBytes];
      this.view3Commitment = new byte[engine.digestSizeBytes];
      if (engine.UnruhGWithInputBytes > 0)
        this.view3UnruhG = new byte[engine.UnruhGWithInputBytes];
      else
        this.view3UnruhG = (byte[]) null;
    }
  }
}
