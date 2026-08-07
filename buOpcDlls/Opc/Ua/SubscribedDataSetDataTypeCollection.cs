// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscribedDataSetDataTypeCollection
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
[CollectionDataContract(Name = "ListOfSubscribedDataSetDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SubscribedDataSetDataType")]
[ComVisible(true)]
public class SubscribedDataSetDataTypeCollection : List<SubscribedDataSetDataType>, ICloneable
{
  public SubscribedDataSetDataTypeCollection()
  {
  }

  public SubscribedDataSetDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public SubscribedDataSetDataTypeCollection(IEnumerable<SubscribedDataSetDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator SubscribedDataSetDataTypeCollection(
    SubscribedDataSetDataType[] values)
  {
    return values != null ? new SubscribedDataSetDataTypeCollection((IEnumerable<SubscribedDataSetDataType>) values) : new SubscribedDataSetDataTypeCollection();
  }

  public static explicit operator SubscribedDataSetDataType[](
    SubscribedDataSetDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (SubscribedDataSetDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SubscribedDataSetDataTypeCollection dataTypeCollection = new SubscribedDataSetDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((SubscribedDataSetDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
