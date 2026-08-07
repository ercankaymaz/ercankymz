// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.AeadParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class AeadParameters : ICipherParameters
{
  private readonly byte[] associatedText;
  private readonly byte[] nonce;
  private readonly KeyParameter key;
  private readonly int macSize;

  public AeadParameters(KeyParameter key, int macSize, byte[] nonce)
    : this(key, macSize, nonce, (byte[]) null)
  {
  }

  public AeadParameters(KeyParameter key, int macSize, byte[] nonce, byte[] associatedText)
  {
    if (nonce == null)
      throw new ArgumentNullException(nameof (nonce));
    this.key = key;
    this.nonce = nonce;
    this.macSize = macSize;
    this.associatedText = associatedText;
  }

  public virtual KeyParameter Key => this.key;

  public virtual int MacSize => this.macSize;

  public virtual byte[] GetAssociatedText() => this.associatedText;

  public virtual byte[] GetNonce() => (byte[]) this.nonce.Clone();
}
