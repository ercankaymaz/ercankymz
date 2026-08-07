// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.HkdfParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class HkdfParameters : IDerivationParameters
{
  private readonly byte[] ikm;
  private readonly bool skipExpand;
  private readonly byte[] salt;
  private readonly byte[] info;

  private HkdfParameters(byte[] ikm, bool skip, byte[] salt, byte[] info)
  {
    this.ikm = ikm != null ? Arrays.Clone(ikm) : throw new ArgumentNullException(nameof (ikm));
    this.skipExpand = skip;
    this.salt = salt == null || salt.Length == 0 ? (byte[]) null : Arrays.Clone(salt);
    if (info == null)
      this.info = new byte[0];
    else
      this.info = Arrays.Clone(info);
  }

  public HkdfParameters(byte[] ikm, byte[] salt, byte[] info)
    : this(ikm, false, salt, info)
  {
  }

  public static HkdfParameters SkipExtractParameters(byte[] ikm, byte[] info)
  {
    return new HkdfParameters(ikm, true, (byte[]) null, info);
  }

  public static HkdfParameters DefaultParameters(byte[] ikm)
  {
    return new HkdfParameters(ikm, false, (byte[]) null, (byte[]) null);
  }

  public virtual byte[] GetIkm() => Arrays.Clone(this.ikm);

  public virtual bool SkipExtract => this.skipExpand;

  public virtual byte[] GetSalt() => Arrays.Clone(this.salt);

  public virtual byte[] GetInfo() => Arrays.Clone(this.info);
}
