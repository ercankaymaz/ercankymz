// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointUrlListDataTypeCollection
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
[CollectionDataContract(Name = "ListOfEndpointUrlListDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointUrlListDataType")]
[ComVisible(true)]
public class EndpointUrlListDataTypeCollection : List<EndpointUrlListDataType>, ICloneable
{
  public EndpointUrlListDataTypeCollection()
  {
  }

  public EndpointUrlListDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public EndpointUrlListDataTypeCollection(IEnumerable<EndpointUrlListDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator EndpointUrlListDataTypeCollection(EndpointUrlListDataType[] values)
  {
    return values != null ? new EndpointUrlListDataTypeCollection((IEnumerable<EndpointUrlListDataType>) values) : new EndpointUrlListDataTypeCollection();
  }

  public static explicit operator EndpointUrlListDataType[](EndpointUrlListDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EndpointUrlListDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointUrlListDataTypeCollection dataTypeCollection = new EndpointUrlListDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((EndpointUrlListDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
