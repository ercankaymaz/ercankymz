// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransportConfigurationCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfTransportConfiguration", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "TransportConfiguration")]
[ComVisible(true)]
public class TransportConfigurationCollection : List<TransportConfiguration>
{
  public TransportConfigurationCollection()
  {
  }

  public TransportConfigurationCollection(IEnumerable<TransportConfiguration> collection)
    : base(collection)
  {
  }

  public TransportConfigurationCollection(int capacity)
    : base(capacity)
  {
  }
}
