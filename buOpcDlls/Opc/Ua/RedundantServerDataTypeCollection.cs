// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RedundantServerDataTypeCollection
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
[CollectionDataContract(Name = "ListOfRedundantServerDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RedundantServerDataType")]
[ComVisible(true)]
public class RedundantServerDataTypeCollection : List<RedundantServerDataType>, ICloneable
{
  public RedundantServerDataTypeCollection()
  {
  }

  public RedundantServerDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public RedundantServerDataTypeCollection(IEnumerable<RedundantServerDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator RedundantServerDataTypeCollection(RedundantServerDataType[] values)
  {
    return values != null ? new RedundantServerDataTypeCollection((IEnumerable<RedundantServerDataType>) values) : new RedundantServerDataTypeCollection();
  }

  public static explicit operator RedundantServerDataType[](RedundantServerDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (RedundantServerDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RedundantServerDataTypeCollection dataTypeCollection = new RedundantServerDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((RedundantServerDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
