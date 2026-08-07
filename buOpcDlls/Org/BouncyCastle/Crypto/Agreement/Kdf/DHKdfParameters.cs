// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.Kdf.DHKdfParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.Kdf;

public class DHKdfParameters : IDerivationParameters
{
  private readonly DerObjectIdentifier algorithm;
  private readonly int keySize;
  private readonly byte[] z;
  private readonly byte[] extraInfo;

  public DHKdfParameters(DerObjectIdentifier algorithm, int keySize, byte[] z)
    : this(algorithm, keySize, z, (byte[]) null)
  {
  }

  public DHKdfParameters(DerObjectIdentifier algorithm, int keySize, byte[] z, byte[] extraInfo)
  {
    this.algorithm = algorithm;
    this.keySize = keySize;
    this.z = z;
    this.extraInfo = extraInfo;
  }

  public DerObjectIdentifier Algorithm => this.algorithm;

  public int KeySize => this.keySize;

  public byte[] GetZ() => this.z;

  public byte[] GetExtraInfo() => this.extraInfo;
}
