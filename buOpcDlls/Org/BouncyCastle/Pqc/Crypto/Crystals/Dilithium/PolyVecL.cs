// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.PolyVecL
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class PolyVecL
{
  public readonly Poly[] Vec;
  private readonly int L;
  private readonly int K;

  public PolyVecL(DilithiumEngine Engine)
  {
    this.L = Engine.L;
    this.K = Engine.K;
    this.Vec = new Poly[this.L];
    for (int index = 0; index < this.L; ++index)
      this.Vec[index] = new Poly(Engine);
  }

  public void UniformEta(byte[] seed, ushort nonce)
  {
    for (int index = 0; index < this.L; ++index)
      this.Vec[index].UniformEta(seed, nonce++);
  }

  public void CopyPolyVecL(PolyVecL OutPoly)
  {
    for (int index1 = 0; index1 < this.L; ++index1)
    {
      for (int index2 = 0; index2 < 256 /*0x0100*/; ++index2)
        OutPoly.Vec[index1].Coeffs[index2] = this.Vec[index1].Coeffs[index2];
    }
  }

  public void InverseNttToMont()
  {
    for (int index = 0; index < this.L; ++index)
      this.Vec[index].InverseNttToMont();
  }

  public void Ntt()
  {
    for (int index = 0; index < this.L; ++index)
      this.Vec[index].PolyNtt();
  }

  public void UniformGamma1(byte[] seed, ushort nonce)
  {
    for (int index = 0; index < this.L; ++index)
      this.Vec[index].UniformGamma1(seed, (ushort) (this.L * (int) nonce + index));
  }

  public void PointwisePolyMontgomery(Poly a, PolyVecL v)
  {
    for (int index = 0; index < this.L; ++index)
      this.Vec[index].PointwiseMontgomery(a, v.Vec[index]);
  }

  public void AddPolyVecL(PolyVecL b)
  {
    for (int index = 0; index < this.L; ++index)
      this.Vec[index].AddPoly(b.Vec[index]);
  }

  public void Reduce()
  {
    for (int index = 0; index < this.L; ++index)
      this.Vec[index].ReducePoly();
  }

  public bool CheckNorm(int bound)
  {
    for (int index = 0; index < this.L; ++index)
    {
      if (this.Vec[index].CheckNorm(bound))
        return true;
    }
    return false;
  }
}
