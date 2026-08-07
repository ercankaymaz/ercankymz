// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Utilities.SecretWithEncapsulationImpl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Utilities;

public class SecretWithEncapsulationImpl : ISecretWithEncapsulation, IDisposable
{
  private volatile bool hasBeenDestroyed;
  private byte[] sessionKey;
  private byte[] cipher_text;

  public SecretWithEncapsulationImpl(byte[] sessionKey, byte[] cipher_text)
  {
    this.sessionKey = sessionKey;
    this.cipher_text = cipher_text;
  }

  public byte[] GetSecret()
  {
    this.CheckDestroyed();
    return Arrays.Clone(this.sessionKey);
  }

  public byte[] GetEncapsulation()
  {
    this.CheckDestroyed();
    return Arrays.Clone(this.cipher_text);
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.hasBeenDestroyed)
      return;
    Arrays.Clear(this.sessionKey);
    Arrays.Clear(this.cipher_text);
    this.hasBeenDestroyed = true;
  }

  public bool IsDestroyed() => this.hasBeenDestroyed;

  private void CheckDestroyed()
  {
    if (this.IsDestroyed())
      throw new Exception("data has been destroyed");
  }
}
