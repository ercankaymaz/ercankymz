// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AliasNameDataTypeCollection
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
[CollectionDataContract(Name = "ListOfAliasNameDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AliasNameDataType")]
[ComVisible(true)]
public class AliasNameDataTypeCollection : List<AliasNameDataType>, ICloneable
{
  public AliasNameDataTypeCollection()
  {
  }

  public AliasNameDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public AliasNameDataTypeCollection(IEnumerable<AliasNameDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator AliasNameDataTypeCollection(AliasNameDataType[] values)
  {
    return values != null ? new AliasNameDataTypeCollection((IEnumerable<AliasNameDataType>) values) : new AliasNameDataTypeCollection();
  }

  public static explicit operator AliasNameDataType[](AliasNameDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (AliasNameDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AliasNameDataTypeCollection dataTypeCollection = new AliasNameDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((AliasNameDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
