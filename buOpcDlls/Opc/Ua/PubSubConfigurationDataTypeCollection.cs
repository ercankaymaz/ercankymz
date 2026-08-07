// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubConfigurationDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPubSubConfigurationDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubConfigurationDataType")]
[ComVisible(true)]
public class PubSubConfigurationDataTypeCollection : List<PubSubConfigurationDataType>, ICloneable
{
  public PubSubConfigurationDataTypeCollection()
  {
  }

  public PubSubConfigurationDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PubSubConfigurationDataTypeCollection(
    IEnumerable<PubSubConfigurationDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PubSubConfigurationDataTypeCollection(
    PubSubConfigurationDataType[] values)
  {
    return values != null ? new PubSubConfigurationDataTypeCollection((IEnumerable<PubSubConfigurationDataType>) values) : new PubSubConfigurationDataTypeCollection();
  }

  public static explicit operator PubSubConfigurationDataType[](
    PubSubConfigurationDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (PubSubConfigurationDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PubSubConfigurationDataTypeCollection dataTypeCollection = new PubSubConfigurationDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PubSubConfigurationDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
