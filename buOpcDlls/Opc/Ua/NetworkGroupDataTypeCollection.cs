// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkGroupDataTypeCollection
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
[CollectionDataContract(Name = "ListOfNetworkGroupDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NetworkGroupDataType")]
[ComVisible(true)]
public class NetworkGroupDataTypeCollection : List<NetworkGroupDataType>, ICloneable
{
  public NetworkGroupDataTypeCollection()
  {
  }

  public NetworkGroupDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public NetworkGroupDataTypeCollection(IEnumerable<NetworkGroupDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator NetworkGroupDataTypeCollection(NetworkGroupDataType[] values)
  {
    return values != null ? new NetworkGroupDataTypeCollection((IEnumerable<NetworkGroupDataType>) values) : new NetworkGroupDataTypeCollection();
  }

  public static explicit operator NetworkGroupDataType[](NetworkGroupDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (NetworkGroupDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NetworkGroupDataTypeCollection dataTypeCollection = new NetworkGroupDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((NetworkGroupDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
