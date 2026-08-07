// Decompiled with JetBrains decompiler
// Type: Opc.Ua.InterfaceAdminStatusCollection
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
[CollectionDataContract(Name = "ListOfInterfaceAdminStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "InterfaceAdminStatus")]
[ComVisible(true)]
public class InterfaceAdminStatusCollection : List<InterfaceAdminStatus>, ICloneable
{
  public InterfaceAdminStatusCollection()
  {
  }

  public InterfaceAdminStatusCollection(int capacity)
    : base(capacity)
  {
  }

  public InterfaceAdminStatusCollection(IEnumerable<InterfaceAdminStatus> collection)
    : base(collection)
  {
  }

  public static implicit operator InterfaceAdminStatusCollection(InterfaceAdminStatus[] values)
  {
    return values != null ? new InterfaceAdminStatusCollection((IEnumerable<InterfaceAdminStatus>) values) : new InterfaceAdminStatusCollection();
  }

  public static explicit operator InterfaceAdminStatus[](InterfaceAdminStatusCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (InterfaceAdminStatusCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    InterfaceAdminStatusCollection statusCollection = new InterfaceAdminStatusCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      statusCollection.Add((InterfaceAdminStatus) Utils.Clone((object) this[index]));
    return (object) statusCollection;
  }
}
