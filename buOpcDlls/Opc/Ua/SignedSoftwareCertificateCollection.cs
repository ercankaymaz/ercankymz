// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SignedSoftwareCertificateCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSignedSoftwareCertificate", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SignedSoftwareCertificate")]
[ComVisible(true)]
public class SignedSoftwareCertificateCollection : List<SignedSoftwareCertificate>, ICloneable
{
  public SignedSoftwareCertificateCollection()
  {
  }

  public SignedSoftwareCertificateCollection(int capacity)
    : base(capacity)
  {
  }

  public SignedSoftwareCertificateCollection(IEnumerable<SignedSoftwareCertificate> collection)
    : base(collection)
  {
  }

  public static implicit operator SignedSoftwareCertificateCollection(
    SignedSoftwareCertificate[] values)
  {
    return values != null ? new SignedSoftwareCertificateCollection((IEnumerable<SignedSoftwareCertificate>) values) : new SignedSoftwareCertificateCollection();
  }

  public static explicit operator SignedSoftwareCertificate[](
    SignedSoftwareCertificateCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (SignedSoftwareCertificateCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SignedSoftwareCertificateCollection certificateCollection = new SignedSoftwareCertificateCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      certificateCollection.Add((SignedSoftwareCertificate) Utils.Clone((object) this[index]));
    return (object) certificateCollection;
  }
}
