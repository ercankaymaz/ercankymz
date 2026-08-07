// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpSignatureList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpSignatureList : PgpObject
{
  private readonly PgpSignature[] sigs;

  public PgpSignatureList(PgpSignature[] sigs) => this.sigs = (PgpSignature[]) sigs.Clone();

  public PgpSignatureList(PgpSignature sig)
  {
    this.sigs = new PgpSignature[1]{ sig };
  }

  public PgpSignature this[int index] => this.sigs[index];

  public int Count => this.sigs.Length;

  public bool IsEmpty => this.sigs.Length == 0;
}
