// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IdentityCriteriaTypeCollection
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
[CollectionDataContract(Name = "ListOfIdentityCriteriaType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "IdentityCriteriaType")]
[ComVisible(true)]
public class IdentityCriteriaTypeCollection : List<IdentityCriteriaType>, ICloneable
{
  public IdentityCriteriaTypeCollection()
  {
  }

  public IdentityCriteriaTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public IdentityCriteriaTypeCollection(IEnumerable<IdentityCriteriaType> collection)
    : base(collection)
  {
  }

  public static implicit operator IdentityCriteriaTypeCollection(IdentityCriteriaType[] values)
  {
    return values != null ? new IdentityCriteriaTypeCollection((IEnumerable<IdentityCriteriaType>) values) : new IdentityCriteriaTypeCollection();
  }

  public static explicit operator IdentityCriteriaType[](IdentityCriteriaTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (IdentityCriteriaTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    IdentityCriteriaTypeCollection criteriaTypeCollection = new IdentityCriteriaTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      criteriaTypeCollection.Add((IdentityCriteriaType) Utils.Clone((object) this[index]));
    return (object) criteriaTypeCollection;
  }
}
