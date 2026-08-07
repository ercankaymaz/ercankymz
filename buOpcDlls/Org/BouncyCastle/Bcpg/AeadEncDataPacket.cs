// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.AeadEncDataPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class AeadEncDataPacket : InputStreamPacket
{
  private readonly byte m_version;
  private readonly SymmetricKeyAlgorithmTag m_algorithm;
  private readonly AeadAlgorithmTag m_aeadAlgorithm;
  private readonly byte m_chunkSize;
  private readonly byte[] m_iv;

  public AeadEncDataPacket(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
    this.m_version = (byte) bcpgIn.ReadByte();
    if (this.m_version != (byte) 1)
      throw new ArgumentException("wrong AEAD packet version: " + this.m_version.ToString());
    this.m_algorithm = (SymmetricKeyAlgorithmTag) bcpgIn.ReadByte();
    this.m_aeadAlgorithm = (AeadAlgorithmTag) bcpgIn.ReadByte();
    this.m_chunkSize = (byte) bcpgIn.ReadByte();
    this.m_iv = new byte[AeadEncDataPacket.GetIVLength(this.m_aeadAlgorithm)];
    bcpgIn.ReadFully(this.m_iv);
  }

  public AeadEncDataPacket(
    SymmetricKeyAlgorithmTag algorithm,
    AeadAlgorithmTag aeadAlgorithm,
    int chunkSize,
    byte[] iv)
    : base((BcpgInputStream) null)
  {
    this.m_version = (byte) 1;
    this.m_algorithm = algorithm;
    this.m_aeadAlgorithm = aeadAlgorithm;
    this.m_chunkSize = (byte) chunkSize;
    this.m_iv = Arrays.Clone(iv);
  }

  public byte Version => this.m_version;

  public SymmetricKeyAlgorithmTag Algorithm => this.m_algorithm;

  public AeadAlgorithmTag AeadAlgorithm => this.m_aeadAlgorithm;

  public int ChunkSize => (int) this.m_chunkSize;

  public byte[] GetIV() => this.m_iv;

  public static int GetIVLength(AeadAlgorithmTag aeadAlgorithm)
  {
    switch (aeadAlgorithm)
    {
      case AeadAlgorithmTag.Eax:
        return 16 /*0x10*/;
      case AeadAlgorithmTag.Ocb:
        return 15;
      case AeadAlgorithmTag.Gcm:
        return 12;
      default:
        throw new ArgumentException("unknown mode: " + aeadAlgorithm.ToString());
    }
  }
}
