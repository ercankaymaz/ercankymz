// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataItemsDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPublishedDataItemsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedDataItemsDataType")]
[ComVisible(true)]
public class PublishedDataItemsDataTypeCollection : List<PublishedDataItemsDataType>, ICloneable
{
  public PublishedDataItemsDataTypeCollection()
  {
  }

  public PublishedDataItemsDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PublishedDataItemsDataTypeCollection(IEnumerable<PublishedDataItemsDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PublishedDataItemsDataTypeCollection(
    PublishedDataItemsDataType[] values)
  {
    return values != null ? new PublishedDataItemsDataTypeCollection((IEnumerable<PublishedDataItemsDataType>) values) : new PublishedDataItemsDataTypeCollection();
  }

  public static explicit operator PublishedDataItemsDataType[](
    PublishedDataItemsDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (PublishedDataItemsDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedDataItemsDataTypeCollection dataTypeCollection = new PublishedDataItemsDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PublishedDataItemsDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
