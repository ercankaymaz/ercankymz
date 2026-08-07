// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataSetSourceDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPublishedDataSetSourceDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedDataSetSourceDataType")]
[ComVisible(true)]
public class PublishedDataSetSourceDataTypeCollection : 
  List<PublishedDataSetSourceDataType>,
  ICloneable
{
  public PublishedDataSetSourceDataTypeCollection()
  {
  }

  public PublishedDataSetSourceDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PublishedDataSetSourceDataTypeCollection(
    IEnumerable<PublishedDataSetSourceDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PublishedDataSetSourceDataTypeCollection(
    PublishedDataSetSourceDataType[] values)
  {
    return values != null ? new PublishedDataSetSourceDataTypeCollection((IEnumerable<PublishedDataSetSourceDataType>) values) : new PublishedDataSetSourceDataTypeCollection();
  }

  public static explicit operator PublishedDataSetSourceDataType[](
    PublishedDataSetSourceDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (PublishedDataSetSourceDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    PublishedDataSetSourceDataTypeCollection dataTypeCollection = new PublishedDataSetSourceDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PublishedDataSetSourceDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
