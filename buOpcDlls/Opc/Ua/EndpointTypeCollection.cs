// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointTypeCollection
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
[CollectionDataContract(Name = "ListOfEndpointType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointType")]
[ComVisible(true)]
public class EndpointTypeCollection : List<EndpointType>, ICloneable
{
  public EndpointTypeCollection()
  {
  }

  public EndpointTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public EndpointTypeCollection(IEnumerable<EndpointType> collection)
    : base(collection)
  {
  }

  public static implicit operator EndpointTypeCollection(EndpointType[] values)
  {
    return values != null ? new EndpointTypeCollection((IEnumerable<EndpointType>) values) : new EndpointTypeCollection();
  }

  public static explicit operator EndpointType[](EndpointTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EndpointTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointTypeCollection endpointTypeCollection = new EndpointTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      endpointTypeCollection.Add((EndpointType) Utils.Clone((object) this[index]));
    return (object) endpointTypeCollection;
  }
}
