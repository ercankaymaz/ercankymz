// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RolePermissionTypeCollection
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
[CollectionDataContract(Name = "ListOfRolePermissionType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RolePermissionType")]
[ComVisible(true)]
public class RolePermissionTypeCollection : List<RolePermissionType>, ICloneable
{
  public RolePermissionTypeCollection()
  {
  }

  public RolePermissionTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public RolePermissionTypeCollection(IEnumerable<RolePermissionType> collection)
    : base(collection)
  {
  }

  public static implicit operator RolePermissionTypeCollection(RolePermissionType[] values)
  {
    return values != null ? new RolePermissionTypeCollection((IEnumerable<RolePermissionType>) values) : new RolePermissionTypeCollection();
  }

  public static explicit operator RolePermissionType[](RolePermissionTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (RolePermissionTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RolePermissionTypeCollection permissionTypeCollection = new RolePermissionTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      permissionTypeCollection.Add((RolePermissionType) Utils.Clone((object) this[index]));
    return (object) permissionTypeCollection;
  }
}
