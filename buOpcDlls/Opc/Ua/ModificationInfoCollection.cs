// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModificationInfoCollection
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
[CollectionDataContract(Name = "ListOfModificationInfo", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ModificationInfo")]
[ComVisible(true)]
public class ModificationInfoCollection : List<ModificationInfo>, ICloneable
{
  public ModificationInfoCollection()
  {
  }

  public ModificationInfoCollection(int capacity)
    : base(capacity)
  {
  }

  public ModificationInfoCollection(IEnumerable<ModificationInfo> collection)
    : base(collection)
  {
  }

  public static implicit operator ModificationInfoCollection(ModificationInfo[] values)
  {
    return values != null ? new ModificationInfoCollection((IEnumerable<ModificationInfo>) values) : new ModificationInfoCollection();
  }

  public static explicit operator ModificationInfo[](ModificationInfoCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ModificationInfoCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ModificationInfoCollection modificationInfoCollection = new ModificationInfoCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      modificationInfoCollection.Add((ModificationInfo) Utils.Clone((object) this[index]));
    return (object) modificationInfoCollection;
  }
}
