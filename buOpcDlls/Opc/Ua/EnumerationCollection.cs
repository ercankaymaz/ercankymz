// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EnumerationCollection
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
[CollectionDataContract(Name = "ListOfEnumeration", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Enumeration")]
[ComVisible(true)]
public class EnumerationCollection : List<Enumeration>, ICloneable
{
  public EnumerationCollection()
  {
  }

  public EnumerationCollection(int capacity)
    : base(capacity)
  {
  }

  public EnumerationCollection(IEnumerable<Enumeration> collection)
    : base(collection)
  {
  }

  public static implicit operator EnumerationCollection(Enumeration[] values)
  {
    return values != null ? new EnumerationCollection((IEnumerable<Enumeration>) values) : new EnumerationCollection();
  }

  public static explicit operator Enumeration[](EnumerationCollection values) => values?.ToArray();

  public object Clone() => (object) (EnumerationCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EnumerationCollection enumerationCollection = new EnumerationCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      enumerationCollection.Add((Enumeration) Utils.Clone((object) this[index]));
    return (object) enumerationCollection;
  }
}
