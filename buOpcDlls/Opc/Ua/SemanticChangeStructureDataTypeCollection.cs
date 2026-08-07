// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SemanticChangeStructureDataTypeCollection
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
[CollectionDataContract(Name = "ListOfSemanticChangeStructureDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SemanticChangeStructureDataType")]
[ComVisible(true)]
public class SemanticChangeStructureDataTypeCollection : 
  List<SemanticChangeStructureDataType>,
  ICloneable
{
  public SemanticChangeStructureDataTypeCollection()
  {
  }

  public SemanticChangeStructureDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public SemanticChangeStructureDataTypeCollection(
    IEnumerable<SemanticChangeStructureDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator SemanticChangeStructureDataTypeCollection(
    SemanticChangeStructureDataType[] values)
  {
    return values != null ? new SemanticChangeStructureDataTypeCollection((IEnumerable<SemanticChangeStructureDataType>) values) : new SemanticChangeStructureDataTypeCollection();
  }

  public static explicit operator SemanticChangeStructureDataType[](
    SemanticChangeStructureDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (SemanticChangeStructureDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SemanticChangeStructureDataTypeCollection dataTypeCollection = new SemanticChangeStructureDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((SemanticChangeStructureDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
