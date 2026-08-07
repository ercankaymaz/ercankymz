// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.KMatrices
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class KMatrices
{
  private int nmatrices;
  private int rows;
  private int columns;
  private uint[] data;

  internal KMatrices(int nmatrices, int rows, int columns, uint[] data)
  {
    this.nmatrices = nmatrices;
    this.rows = rows;
    this.columns = columns;
    this.data = data;
  }

  internal int GetNmatrices() => this.nmatrices;

  internal int GetSize() => this.rows * this.columns;

  internal int GetRows() => this.rows;

  internal int GetColumns() => this.columns;

  internal uint[] GetData() => this.data;
}
