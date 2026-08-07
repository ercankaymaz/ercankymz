// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.ChannelToken
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ChannelToken
{
  private uint m_channelId;
  private uint m_tokenId;
  private DateTime m_createdAt;
  private int m_lifetime;
  private byte[] m_clientNonce;
  private byte[] m_serverNonce;
  private byte[] m_clientSigningKey;
  private byte[] m_clientEncryptingKey;
  private byte[] m_clientInitializationVector;
  private byte[] m_serverSigningKey;
  private byte[] m_serverEncryptingKey;
  private byte[] m_serverInitializationVector;
  private HMAC m_clientHmac;
  private HMAC m_serverHmac;
  private SymmetricAlgorithm m_clientEncryptor;
  private SymmetricAlgorithm m_serverEncryptor;

  public uint ChannelId
  {
    get => this.m_channelId;
    set => this.m_channelId = value;
  }

  public uint TokenId
  {
    get => this.m_tokenId;
    set => this.m_tokenId = value;
  }

  public DateTime CreatedAt
  {
    get => this.m_createdAt;
    set => this.m_createdAt = value;
  }

  public int Lifetime
  {
    get => this.m_lifetime;
    set => this.m_lifetime = value;
  }

  public bool Expired
  {
    get => DateTime.UtcNow > this.m_createdAt.AddMilliseconds((double) this.m_lifetime);
  }

  public bool ActivationRequired
  {
    get => DateTime.UtcNow > this.m_createdAt.AddMilliseconds((double) this.m_lifetime * 0.95);
  }

  public byte[] ClientNonce
  {
    get => this.m_clientNonce;
    set => this.m_clientNonce = value;
  }

  public byte[] ServerNonce
  {
    get => this.m_serverNonce;
    set => this.m_serverNonce = value;
  }

  public byte[] ClientSigningKey
  {
    get => this.m_clientSigningKey;
    set => this.m_clientSigningKey = value;
  }

  public byte[] ClientEncryptingKey
  {
    get => this.m_clientEncryptingKey;
    set => this.m_clientEncryptingKey = value;
  }

  public byte[] ClientInitializationVector
  {
    get => this.m_clientInitializationVector;
    set => this.m_clientInitializationVector = value;
  }

  public byte[] ServerSigningKey
  {
    get => this.m_serverSigningKey;
    set => this.m_serverSigningKey = value;
  }

  public byte[] ServerEncryptingKey
  {
    get => this.m_serverEncryptingKey;
    set => this.m_serverEncryptingKey = value;
  }

  public byte[] ServerInitializationVector
  {
    get => this.m_serverInitializationVector;
    set => this.m_serverInitializationVector = value;
  }

  public SymmetricAlgorithm ClientEncryptor
  {
    get => this.m_clientEncryptor;
    set => this.m_clientEncryptor = value;
  }

  public SymmetricAlgorithm ServerEncryptor
  {
    get => this.m_serverEncryptor;
    set => this.m_serverEncryptor = value;
  }

  public HMAC ClientHmac
  {
    get => this.m_clientHmac;
    set => this.m_clientHmac = value;
  }

  public HMAC ServerHmac
  {
    get => this.m_serverHmac;
    set => this.m_serverHmac = value;
  }
}
