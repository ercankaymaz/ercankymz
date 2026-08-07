// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.RevocationKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class RevocationKey : SignatureSubpacket
{
  public RevocationKey(bool isCritical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.RevocationKey, isCritical, isLongLength, data)
  {
  }

  public RevocationKey(
    bool isCritical,
    RevocationKeyTag signatureClass,
    PublicKeyAlgorithmTag keyAlgorithm,
    byte[] fingerprint)
    : base(SignatureSubpacketTag.RevocationKey, isCritical, false, RevocationKey.CreateData(signatureClass, keyAlgorithm, fingerprint))
  {
  }

  private static byte[] CreateData(
    RevocationKeyTag signatureClass,
    PublicKeyAlgorithmTag keyAlgorithm,
    byte[] fingerprint)
  {
    byte[] destinationArray = new byte[2 + fingerprint.Length];
    destinationArray[0] = (byte) signatureClass;
    destinationArray[1] = (byte) keyAlgorithm;
    Array.Copy((Array) fingerprint, 0, (Array) destinationArray, 2, fingerprint.Length);
    return destinationArray;
  }

  public virtual RevocationKeyTag SignatureClass => (RevocationKeyTag) this.data[0];

  public virtual PublicKeyAlgorithmTag Algorithm => (PublicKeyAlgorithmTag) this.data[1];

  public virtual byte[] GetFingerprint()
  {
    byte[] destinationArray = new byte[this.data.Length - 2];
    Array.Copy((Array) this.data, 2, (Array) destinationArray, 0, destinationArray.Length);
    return destinationArray;
  }
}
