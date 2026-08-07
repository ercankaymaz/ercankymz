// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.ECNamedCurveTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Anssi;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.TeleTrust;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class ECNamedCurveTable
{
  public static X9ECParameters GetByName(string name)
  {
    return (((((X962NamedCurves.GetByName(name) ?? SecNamedCurves.GetByName(name)) ?? NistNamedCurves.GetByName(name)) ?? TeleTrusTNamedCurves.GetByName(name)) ?? AnssiNamedCurves.GetByName(name)) ?? ECGost3410NamedCurves.GetByName(name)) ?? GMNamedCurves.GetByName(name);
  }

  public static X9ECParametersHolder GetByNameLazy(string name)
  {
    return (((((X962NamedCurves.GetByNameLazy(name) ?? SecNamedCurves.GetByNameLazy(name)) ?? NistNamedCurves.GetByNameLazy(name)) ?? TeleTrusTNamedCurves.GetByNameLazy(name)) ?? AnssiNamedCurves.GetByNameLazy(name)) ?? ECGost3410NamedCurves.GetByNameLazy(name)) ?? GMNamedCurves.GetByNameLazy(name);
  }

  public static X9ECParameters GetByOid(DerObjectIdentifier oid)
  {
    return ((((X962NamedCurves.GetByOid(oid) ?? SecNamedCurves.GetByOid(oid)) ?? TeleTrusTNamedCurves.GetByOid(oid)) ?? AnssiNamedCurves.GetByOid(oid)) ?? ECGost3410NamedCurves.GetByOid(oid)) ?? GMNamedCurves.GetByOid(oid);
  }

  public static X9ECParametersHolder GetByOidLazy(DerObjectIdentifier oid)
  {
    return ((((X962NamedCurves.GetByOidLazy(oid) ?? SecNamedCurves.GetByOidLazy(oid)) ?? TeleTrusTNamedCurves.GetByOidLazy(oid)) ?? AnssiNamedCurves.GetByOidLazy(oid)) ?? ECGost3410NamedCurves.GetByOidLazy(oid)) ?? GMNamedCurves.GetByOidLazy(oid);
  }

  public static string GetName(DerObjectIdentifier oid)
  {
    return (((((X962NamedCurves.GetName(oid) ?? SecNamedCurves.GetName(oid)) ?? NistNamedCurves.GetName(oid)) ?? TeleTrusTNamedCurves.GetName(oid)) ?? AnssiNamedCurves.GetName(oid)) ?? ECGost3410NamedCurves.GetName(oid)) ?? GMNamedCurves.GetName(oid);
  }

  public static DerObjectIdentifier GetOid(string name)
  {
    return (((((X962NamedCurves.GetOid(name) ?? SecNamedCurves.GetOid(name)) ?? NistNamedCurves.GetOid(name)) ?? TeleTrusTNamedCurves.GetOid(name)) ?? AnssiNamedCurves.GetOid(name)) ?? ECGost3410NamedCurves.GetOid(name)) ?? GMNamedCurves.GetOid(name);
  }

  public static IEnumerable<string> Names
  {
    get
    {
      List<string> names = new List<string>();
      names.AddRange(X962NamedCurves.Names);
      names.AddRange(SecNamedCurves.Names);
      names.AddRange(NistNamedCurves.Names);
      names.AddRange(TeleTrusTNamedCurves.Names);
      names.AddRange(AnssiNamedCurves.Names);
      names.AddRange(ECGost3410NamedCurves.Names);
      names.AddRange(GMNamedCurves.Names);
      return (IEnumerable<string>) names;
    }
  }
}
