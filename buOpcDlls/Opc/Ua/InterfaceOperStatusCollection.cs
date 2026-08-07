// Decompiled with JetBrains decompiler
// Type: Opc.Ua.InterfaceOperStatusCollection
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
[CollectionDataContract(Name = "ListOfInterfaceOperStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "InterfaceOperStatus")]
[ComVisible(true)]
public class InterfaceOperStatusCollection : List<InterfaceOperStatus>, ICloneable
{
  public InterfaceOperStatusCollection()
  {
  }

  public InterfaceOperStatusCollection(int capacity)
    : base(capacity)
  {
  }

  public InterfaceOperStatusCollection(IEnumerable<InterfaceOperStatus> collection)
    : base(collection)
  {
  }

  public static implicit operator InterfaceOperStatusCollection(InterfaceOperStatus[] values)
  {
    return values != null ? new InterfaceOperStatusCollection((IEnumerable<InterfaceOperStatus>) values) : new InterfaceOperStatusCollection();
  }

  public static explicit operator InterfaceOperStatus[](InterfaceOperStatusCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (InterfaceOperStatusCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    InterfaceOperStatusCollection statusCollection = new InterfaceOperStatusCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      statusCollection.Add((InterfaceOperStatus) Utils.Clone((object) this[index]));
    return (object) statusCollection;
  }
}
