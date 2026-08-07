// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OptionSetCollection
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
[CollectionDataContract(Name = "ListOfOptionSet", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "OptionSet")]
[ComVisible(true)]
public class OptionSetCollection : List<OptionSet>, ICloneable
{
  public OptionSetCollection()
  {
  }

  public OptionSetCollection(int capacity)
    : base(capacity)
  {
  }

  public OptionSetCollection(IEnumerable<OptionSet> collection)
    : base(collection)
  {
  }

  public static implicit operator OptionSetCollection(OptionSet[] values)
  {
    return values != null ? new OptionSetCollection((IEnumerable<OptionSet>) values) : new OptionSetCollection();
  }

  public static explicit operator OptionSet[](OptionSetCollection values) => values?.ToArray();

  public object Clone() => (object) (OptionSetCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    OptionSetCollection optionSetCollection = new OptionSetCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      optionSetCollection.Add((OptionSet) Utils.Clone((object) this[index]));
    return (object) optionSetCollection;
  }
}
