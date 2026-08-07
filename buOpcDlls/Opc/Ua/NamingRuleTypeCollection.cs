// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NamingRuleTypeCollection
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
[CollectionDataContract(Name = "ListOfNamingRuleType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NamingRuleType")]
[ComVisible(true)]
public class NamingRuleTypeCollection : List<NamingRuleType>, ICloneable
{
  public NamingRuleTypeCollection()
  {
  }

  public NamingRuleTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public NamingRuleTypeCollection(IEnumerable<NamingRuleType> collection)
    : base(collection)
  {
  }

  public static implicit operator NamingRuleTypeCollection(NamingRuleType[] values)
  {
    return values != null ? new NamingRuleTypeCollection((IEnumerable<NamingRuleType>) values) : new NamingRuleTypeCollection();
  }

  public static explicit operator NamingRuleType[](NamingRuleTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (NamingRuleTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NamingRuleTypeCollection ruleTypeCollection = new NamingRuleTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      ruleTypeCollection.Add((NamingRuleType) Utils.Clone((object) this[index]));
    return (object) ruleTypeCollection;
  }
}
