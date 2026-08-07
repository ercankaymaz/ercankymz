// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.KMatricesWithPointer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class KMatricesWithPointer : KMatrices
{
  private int matrixPointer;

  internal int GetMatrixPointer() => this.matrixPointer;

  internal void SetMatrixPointer(int matrixPointer) => this.matrixPointer = matrixPointer;

  internal KMatricesWithPointer(KMatrices m)
    : base(m.GetNmatrices(), m.GetRows(), m.GetColumns(), m.GetData())
  {
    this.matrixPointer = 0;
  }
}
