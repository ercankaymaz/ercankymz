// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509CRLCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[CollectionDataContract(Name = "ListOfX509CRL", ItemName = "X509CRL")]
[ComVisible(true)]
public class X509CRLCollection : List<X509CRL>
{
  public new X509CRL this[int index]
  {
    get => base[index];
    set
    {
      int index1 = index;
      base[index1] = value ?? throw new ArgumentNullException(nameof (value));
    }
  }

  public X509CRLCollection()
  {
  }

  public X509CRLCollection(X509CRL crl) => this.Add(crl);

  public X509CRLCollection(X509CRLCollection crls) => this.AddRange((IEnumerable<X509CRL>) crls);

  public X509CRLCollection(X509CRL[] crls) => this.AddRange((IEnumerable<X509CRL>) crls);

  public static X509CRLCollection ToX509CRLCollection(X509CRL[] crls)
  {
    return crls != null ? new X509CRLCollection(crls) : new X509CRLCollection();
  }

  public static implicit operator X509CRLCollection(X509CRL[] crls)
  {
    return X509CRLCollection.ToX509CRLCollection(crls);
  }
}
