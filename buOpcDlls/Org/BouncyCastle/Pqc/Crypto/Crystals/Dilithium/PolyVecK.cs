// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.PolyVecK
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class PolyVecK
{
  public readonly Poly[] Vec;
  private readonly DilithiumEngine Engine;
  private readonly int K;

  public PolyVecK(DilithiumEngine Engine)
  {
    this.Engine = Engine;
    this.K = Engine.K;
    this.Vec = new Poly[this.K];
    for (int index = 0; index < this.K; ++index)
      this.Vec[index] = new Poly(Engine);
  }

  public void UniformEta(byte[] seed, ushort nonce)
  {
    ushort num = nonce;
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].UniformEta(seed, num++);
  }

  public void Reduce()
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].ReducePoly();
  }

  public void Ntt()
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].PolyNtt();
  }

  public void InverseNttToMont()
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].InverseNttToMont();
  }

  public void AddPolyVecK(PolyVecK b)
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].AddPoly(b.Vec[index]);
  }

  public void Subtract(PolyVecK v)
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].Subtract(v.Vec[index]);
  }

  public void ConditionalAddQ()
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].ConditionalAddQ();
  }

  public void Power2Round(PolyVecK v)
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].Power2Round(v.Vec[index]);
  }

  public void Decompose(PolyVecK v)
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].Decompose(v.Vec[index]);
  }

  public void PackW1(byte[] r)
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].PackW1(r, index * this.Engine.PolyW1PackedBytes);
  }

  public void PointwisePolyMontgomery(Poly a, PolyVecK v)
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].PointwiseMontgomery(a, v.Vec[index]);
  }

  public bool CheckNorm(int bound)
  {
    for (int index = 0; index < this.K; ++index)
    {
      if (this.Vec[index].CheckNorm(bound))
        return true;
    }
    return false;
  }

  public int MakeHint(PolyVecK v0, PolyVecK v1)
  {
    int num = 0;
    for (int index = 0; index < this.K; ++index)
      num += this.Vec[index].PolyMakeHint(v0.Vec[index], v1.Vec[index]);
    return num;
  }

  public void UseHint(PolyVecK a, PolyVecK h)
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].PolyUseHint(a.Vec[index], h.Vec[index]);
  }

  public void ShiftLeft()
  {
    for (int index = 0; index < this.K; ++index)
      this.Vec[index].ShiftLeft();
  }
}
