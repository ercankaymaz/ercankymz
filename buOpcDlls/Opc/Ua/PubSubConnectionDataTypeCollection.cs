// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubConnectionDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPubSubConnectionDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubConnectionDataType")]
[ComVisible(true)]
public class PubSubConnectionDataTypeCollection : List<PubSubConnectionDataType>, ICloneable
{
  public PubSubConnectionDataTypeCollection()
  {
  }

  public PubSubConnectionDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PubSubConnectionDataTypeCollection(IEnumerable<PubSubConnectionDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PubSubConnectionDataTypeCollection(
    PubSubConnectionDataType[] values)
  {
    return values != null ? new PubSubConnectionDataTypeCollection((IEnumerable<PubSubConnectionDataType>) values) : new PubSubConnectionDataTypeCollection();
  }

  public static explicit operator PubSubConnectionDataType[](
    PubSubConnectionDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (PubSubConnectionDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PubSubConnectionDataTypeCollection dataTypeCollection = new PubSubConnectionDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PubSubConnectionDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
