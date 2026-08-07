// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.PolyVecMatrix
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class PolyVecMatrix
{
  private int K;
  private int L;
  public PolyVecL[] Matrix;

  public PolyVecMatrix(DilithiumEngine Engine)
  {
    this.K = Engine.K;
    this.L = Engine.L;
    this.Matrix = new PolyVecL[this.K];
    for (int index = 0; index < this.K; ++index)
      this.Matrix[index] = new PolyVecL(Engine);
  }

  public void ExpandMatrix(byte[] rho)
  {
    for (int index1 = 0; index1 < this.K; ++index1)
    {
      for (int index2 = 0; index2 < this.L; ++index2)
        this.Matrix[index1].Vec[index2].UniformBlocks(rho, (ushort) ((uint) (ushort) (index1 << 8) + (uint) index2));
    }
  }

  public void PointwiseMontgomery(PolyVecK t, PolyVecL v)
  {
    for (int index = 0; index < this.K; ++index)
      t.Vec[index].PointwiseAccountMontgomery(this.Matrix[index], v);
  }
}
