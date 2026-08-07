// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubGroupDataTypeCollection
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
[CollectionDataContract(Name = "ListOfPubSubGroupDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubGroupDataType")]
[ComVisible(true)]
public class PubSubGroupDataTypeCollection : List<PubSubGroupDataType>, ICloneable
{
  public PubSubGroupDataTypeCollection()
  {
  }

  public PubSubGroupDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public PubSubGroupDataTypeCollection(IEnumerable<PubSubGroupDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator PubSubGroupDataTypeCollection(PubSubGroupDataType[] values)
  {
    return values != null ? new PubSubGroupDataTypeCollection((IEnumerable<PubSubGroupDataType>) values) : new PubSubGroupDataTypeCollection();
  }

  public static explicit operator PubSubGroupDataType[](PubSubGroupDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (PubSubGroupDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PubSubGroupDataTypeCollection dataTypeCollection = new PubSubGroupDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((PubSubGroupDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
