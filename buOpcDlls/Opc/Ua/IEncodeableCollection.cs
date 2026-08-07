// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IEncodeableCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfEncodeable", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Encodeable")]
[ComVisible(true)]
public class IEncodeableCollection : List<IEncodeable>
{
  public IEncodeableCollection()
  {
  }

  public IEncodeableCollection(IEnumerable<IEncodeable> collection)
    : base(collection)
  {
  }

  public IEncodeableCollection(int capacity)
    : base(capacity)
  {
  }

  public static IEncodeableCollection ToIEncodeableCollection(IEncodeable[] values)
  {
    return values != null ? new IEncodeableCollection((IEnumerable<IEncodeable>) values) : new IEncodeableCollection();
  }

  public static implicit operator IEncodeableCollection(IEncodeable[] values)
  {
    return IEncodeableCollection.ToIEncodeableCollection(values);
  }
}
