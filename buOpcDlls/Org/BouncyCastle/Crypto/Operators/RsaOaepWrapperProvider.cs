// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.RsaOaepWrapperProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

internal class RsaOaepWrapperProvider : WrapperProvider
{
  private readonly DerObjectIdentifier digestOid;
  private readonly DerObjectIdentifier mgfOid;

  internal RsaOaepWrapperProvider(DerObjectIdentifier digestOid)
  {
    this.digestOid = digestOid;
    this.mgfOid = digestOid;
  }

  internal RsaOaepWrapperProvider(DerObjectIdentifier digestOid, DerObjectIdentifier mgfOid)
  {
    this.digestOid = digestOid;
    this.mgfOid = mgfOid;
  }

  object WrapperProvider.CreateWrapper(bool forWrapping, ICipherParameters parameters)
  {
    return (object) new RsaOaepWrapper(forWrapping, parameters, this.digestOid, this.mgfOid);
  }
}
