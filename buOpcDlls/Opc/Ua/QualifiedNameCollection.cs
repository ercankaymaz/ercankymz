// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QualifiedNameCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfQualifiedName", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "QualifiedName")]
[ComVisible(true)]
public class QualifiedNameCollection : List<QualifiedName>, ICloneable
{
  public QualifiedNameCollection()
  {
  }

  public QualifiedNameCollection(IEnumerable<QualifiedName> collection)
    : base(collection)
  {
  }

  public QualifiedNameCollection(int capacity)
    : base(capacity)
  {
  }

  public static QualifiedNameCollection ToQualifiedNameCollection(QualifiedName[] values)
  {
    return values != null ? new QualifiedNameCollection((IEnumerable<QualifiedName>) values) : new QualifiedNameCollection();
  }

  public static implicit operator QualifiedNameCollection(QualifiedName[] values)
  {
    return QualifiedNameCollection.ToQualifiedNameCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection(this.Count);
    foreach (QualifiedName qualifiedName in (List<QualifiedName>) this)
      qualifiedNameCollection.Add((QualifiedName) Utils.Clone((object) qualifiedName));
    return (object) qualifiedNameCollection;
  }
}
