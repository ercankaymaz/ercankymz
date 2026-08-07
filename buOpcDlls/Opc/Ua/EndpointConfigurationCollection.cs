// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointConfigurationCollection
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
[CollectionDataContract(Name = "ListOfEndpointConfiguration", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointConfiguration")]
[ComVisible(true)]
public class EndpointConfigurationCollection : List<EndpointConfiguration>, ICloneable
{
  public EndpointConfigurationCollection()
  {
  }

  public EndpointConfigurationCollection(int capacity)
    : base(capacity)
  {
  }

  public EndpointConfigurationCollection(IEnumerable<EndpointConfiguration> collection)
    : base(collection)
  {
  }

  public static implicit operator EndpointConfigurationCollection(EndpointConfiguration[] values)
  {
    return values != null ? new EndpointConfigurationCollection((IEnumerable<EndpointConfiguration>) values) : new EndpointConfigurationCollection();
  }

  public static explicit operator EndpointConfiguration[](EndpointConfigurationCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EndpointConfigurationCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointConfigurationCollection configurationCollection = new EndpointConfigurationCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      configurationCollection.Add((EndpointConfiguration) Utils.Clone((object) this[index]));
    return (object) configurationCollection;
  }
}
