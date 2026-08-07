// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruEncapsulation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

internal sealed class NtruEncapsulation : ISecretWithEncapsulation, IDisposable
{
  private readonly byte[] _sharedKey;
  private readonly byte[] _ciphertext;
  private bool _hasBeenDestroyed;

  internal NtruEncapsulation(byte[] sharedKey, byte[] ciphertext)
  {
    this._sharedKey = sharedKey;
    this._ciphertext = ciphertext;
  }

  public void Dispose()
  {
    if (!this._hasBeenDestroyed)
    {
      Array.Clear((Array) this._sharedKey, 0, this._sharedKey.Length);
      Array.Clear((Array) this._ciphertext, 0, this._ciphertext.Length);
      this._hasBeenDestroyed = true;
    }
    GC.SuppressFinalize((object) this);
  }

  public byte[] GetSecret()
  {
    this.CheckDestroyed();
    return this._sharedKey;
  }

  public byte[] GetEncapsulation()
  {
    this.CheckDestroyed();
    return this._ciphertext;
  }

  private void CheckDestroyed()
  {
    if (this.IsDestroyed())
      throw new InvalidOperationException("Object has been destroyed");
  }

  public bool IsDestroyed() => this._hasBeenDestroyed;
}
