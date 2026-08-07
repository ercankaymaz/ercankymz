// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.AsymmetricKeyEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class AsymmetricKeyEntry : Pkcs12Entry
{
  private readonly AsymmetricKeyParameter key;

  public AsymmetricKeyEntry(AsymmetricKeyParameter key)
    : base((IDictionary<DerObjectIdentifier, Asn1Encodable>) new Dictionary<DerObjectIdentifier, Asn1Encodable>())
  {
    this.key = key;
  }

  public AsymmetricKeyEntry(
    AsymmetricKeyParameter key,
    IDictionary<DerObjectIdentifier, Asn1Encodable> attributes)
    : base(attributes)
  {
    this.key = key;
  }

  public AsymmetricKeyParameter Key => this.key;

  public override bool Equals(object obj)
  {
    return obj is AsymmetricKeyEntry asymmetricKeyEntry && this.key.Equals((object) asymmetricKeyEntry.key);
  }

  public override int GetHashCode() => ~this.key.GetHashCode();
}
