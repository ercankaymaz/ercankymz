// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointDescriptionCollection
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
[CollectionDataContract(Name = "ListOfEndpointDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointDescription")]
[ComVisible(true)]
public class EndpointDescriptionCollection : List<EndpointDescription>, ICloneable
{
  public EndpointDescriptionCollection()
  {
  }

  public EndpointDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public EndpointDescriptionCollection(IEnumerable<EndpointDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator EndpointDescriptionCollection(EndpointDescription[] values)
  {
    return values != null ? new EndpointDescriptionCollection((IEnumerable<EndpointDescription>) values) : new EndpointDescriptionCollection();
  }

  public static explicit operator EndpointDescription[](EndpointDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EndpointDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointDescriptionCollection descriptionCollection = new EndpointDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((EndpointDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
