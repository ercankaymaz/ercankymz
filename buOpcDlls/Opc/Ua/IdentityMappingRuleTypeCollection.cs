// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IdentityMappingRuleTypeCollection
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
[CollectionDataContract(Name = "ListOfIdentityMappingRuleType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "IdentityMappingRuleType")]
[ComVisible(true)]
public class IdentityMappingRuleTypeCollection : List<IdentityMappingRuleType>, ICloneable
{
  public IdentityMappingRuleTypeCollection()
  {
  }

  public IdentityMappingRuleTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public IdentityMappingRuleTypeCollection(IEnumerable<IdentityMappingRuleType> collection)
    : base(collection)
  {
  }

  public static implicit operator IdentityMappingRuleTypeCollection(IdentityMappingRuleType[] values)
  {
    return values != null ? new IdentityMappingRuleTypeCollection((IEnumerable<IdentityMappingRuleType>) values) : new IdentityMappingRuleTypeCollection();
  }

  public static explicit operator IdentityMappingRuleType[](IdentityMappingRuleTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (IdentityMappingRuleTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    IdentityMappingRuleTypeCollection ruleTypeCollection = new IdentityMappingRuleTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      ruleTypeCollection.Add((IdentityMappingRuleType) Utils.Clone((object) this[index]));
    return (object) ruleTypeCollection;
  }
}
