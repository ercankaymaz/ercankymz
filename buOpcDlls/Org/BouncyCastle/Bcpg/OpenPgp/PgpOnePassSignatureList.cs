// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpOnePassSignatureList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpOnePassSignatureList : PgpObject
{
  private readonly PgpOnePassSignature[] sigs;

  public PgpOnePassSignatureList(PgpOnePassSignature[] sigs)
  {
    this.sigs = (PgpOnePassSignature[]) sigs.Clone();
  }

  public PgpOnePassSignatureList(PgpOnePassSignature sig)
  {
    this.sigs = new PgpOnePassSignature[1]{ sig };
  }

  public PgpOnePassSignature this[int index] => this.sigs[index];

  public int Count => this.sigs.Length;

  public bool IsEmpty => this.sigs.Length == 0;
}
