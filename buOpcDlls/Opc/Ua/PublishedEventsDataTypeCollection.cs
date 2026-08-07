// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedEventsDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPublishedEventsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedEventsDataType")]
[ComVisible(true)]
public class PublishedEventsDataTypeCollection : List<PublishedEventsDataType>, ICloneable
{
  public PublishedEventsDataTypeCollection()
  {
  }

  public PublishedEventsDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PublishedEventsDataTypeCollection(IEnumerable<PublishedEventsDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PublishedEventsDataTypeCollection(PublishedEventsDataType[] values)
  {
    return values != null ? new PublishedEventsDataTypeCollection((IEnumerable<PublishedEventsDataType>) values) : new PublishedEventsDataTypeCollection();
  }

  public static explicit operator PublishedEventsDataType[](PublishedEventsDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (PublishedEventsDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedEventsDataTypeCollection dataTypeCollection = new PublishedEventsDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PublishedEventsDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
