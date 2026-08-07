// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedVariableDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPublishedVariableDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedVariableDataType")]
[ComVisible(true)]
public class PublishedVariableDataTypeCollection : List<PublishedVariableDataType>, ICloneable
{
  public PublishedVariableDataTypeCollection()
  {
  }

  public PublishedVariableDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PublishedVariableDataTypeCollection(IEnumerable<PublishedVariableDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PublishedVariableDataTypeCollection(
    PublishedVariableDataType[] values)
  {
    return values != null ? new PublishedVariableDataTypeCollection((IEnumerable<PublishedVariableDataType>) values) : new PublishedVariableDataTypeCollection();
  }

  public static explicit operator PublishedVariableDataType[](
    PublishedVariableDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (PublishedVariableDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedVariableDataTypeCollection dataTypeCollection = new PublishedVariableDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PublishedVariableDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
