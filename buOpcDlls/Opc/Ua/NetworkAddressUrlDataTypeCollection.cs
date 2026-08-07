// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkAddressUrlDataTypeCollection
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
[CollectionDataContract(Name = "ListOfNetworkAddressUrlDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NetworkAddressUrlDataType")]
[ComVisible(true)]
public class NetworkAddressUrlDataTypeCollection : List<NetworkAddressUrlDataType>, ICloneable
{
  public NetworkAddressUrlDataTypeCollection()
  {
  }

  public NetworkAddressUrlDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public NetworkAddressUrlDataTypeCollection(IEnumerable<NetworkAddressUrlDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator NetworkAddressUrlDataTypeCollection(
    NetworkAddressUrlDataType[] values)
  {
    return values != null ? new NetworkAddressUrlDataTypeCollection((IEnumerable<NetworkAddressUrlDataType>) values) : new NetworkAddressUrlDataTypeCollection();
  }

  public static explicit operator NetworkAddressUrlDataType[](
    NetworkAddressUrlDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (NetworkAddressUrlDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NetworkAddressUrlDataTypeCollection dataTypeCollection = new NetworkAddressUrlDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((NetworkAddressUrlDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
