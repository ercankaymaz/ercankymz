// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataSetDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPublishedDataSetDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedDataSetDataType")]
[ComVisible(true)]
public class PublishedDataSetDataTypeCollection : List<PublishedDataSetDataType>, ICloneable
{
  public PublishedDataSetDataTypeCollection()
  {
  }

  public PublishedDataSetDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PublishedDataSetDataTypeCollection(IEnumerable<PublishedDataSetDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PublishedDataSetDataTypeCollection(
    PublishedDataSetDataType[] values)
  {
    return values != null ? new PublishedDataSetDataTypeCollection((IEnumerable<PublishedDataSetDataType>) values) : new PublishedDataSetDataTypeCollection();
  }

  public static explicit operator PublishedDataSetDataType[](
    PublishedDataSetDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (PublishedDataSetDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedDataSetDataTypeCollection dataTypeCollection = new PublishedDataSetDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PublishedDataSetDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
