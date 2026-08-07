// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OverrideValueHandlingCollection
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
[CollectionDataContract(Name = "ListOfOverrideValueHandling", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "OverrideValueHandling")]
[ComVisible(true)]
public class OverrideValueHandlingCollection : List<OverrideValueHandling>, ICloneable
{
  public OverrideValueHandlingCollection()
  {
  }

  public OverrideValueHandlingCollection(int capacity)
    : base(capacity)
  {
  }

  public OverrideValueHandlingCollection(IEnumerable<OverrideValueHandling> collection)
    : base(collection)
  {
  }

  public static implicit operator OverrideValueHandlingCollection(OverrideValueHandling[] values)
  {
    return values != null ? new OverrideValueHandlingCollection((IEnumerable<OverrideValueHandling>) values) : new OverrideValueHandlingCollection();
  }

  public static explicit operator OverrideValueHandling[](OverrideValueHandlingCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (OverrideValueHandlingCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    OverrideValueHandlingCollection handlingCollection = new OverrideValueHandlingCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      handlingCollection.Add((OverrideValueHandling) Utils.Clone((object) this[index]));
    return (object) handlingCollection;
  }
}
