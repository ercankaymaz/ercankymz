// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkAddressDataTypeCollection
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
[CollectionDataContract(Name = "ListOfNetworkAddressDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NetworkAddressDataType")]
[ComVisible(true)]
public class NetworkAddressDataTypeCollection : List<NetworkAddressDataType>, ICloneable
{
  public NetworkAddressDataTypeCollection()
  {
  }

  public NetworkAddressDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public NetworkAddressDataTypeCollection(IEnumerable<NetworkAddressDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator NetworkAddressDataTypeCollection(NetworkAddressDataType[] values)
  {
    return values != null ? new NetworkAddressDataTypeCollection((IEnumerable<NetworkAddressDataType>) values) : new NetworkAddressDataTypeCollection();
  }

  public static explicit operator NetworkAddressDataType[](NetworkAddressDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (NetworkAddressDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NetworkAddressDataTypeCollection dataTypeCollection = new NetworkAddressDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((NetworkAddressDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
