// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypeDefinitionCollection
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
[CollectionDataContract(Name = "ListOfDataTypeDefinition", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataTypeDefinition")]
[ComVisible(true)]
public class DataTypeDefinitionCollection : List<DataTypeDefinition>, ICloneable
{
  public DataTypeDefinitionCollection()
  {
  }

  public DataTypeDefinitionCollection(int capacity)
    : base(capacity)
  {
  }

  public DataTypeDefinitionCollection(IEnumerable<DataTypeDefinition> collection)
    : base(collection)
  {
  }

  public static implicit operator DataTypeDefinitionCollection(DataTypeDefinition[] values)
  {
    return values != null ? new DataTypeDefinitionCollection((IEnumerable<DataTypeDefinition>) values) : new DataTypeDefinitionCollection();
  }

  public static explicit operator DataTypeDefinition[](DataTypeDefinitionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataTypeDefinitionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataTypeDefinitionCollection definitionCollection = new DataTypeDefinitionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      definitionCollection.Add((DataTypeDefinition) Utils.Clone((object) this[index]));
    return (object) definitionCollection;
  }
}
