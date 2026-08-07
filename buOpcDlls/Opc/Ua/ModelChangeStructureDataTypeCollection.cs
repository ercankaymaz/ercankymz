// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModelChangeStructureDataTypeCollection
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
[CollectionDataContract(Name = "ListOfModelChangeStructureDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ModelChangeStructureDataType")]
[ComVisible(true)]
public class ModelChangeStructureDataTypeCollection : List<ModelChangeStructureDataType>, ICloneable
{
  public ModelChangeStructureDataTypeCollection()
  {
  }

  public ModelChangeStructureDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public ModelChangeStructureDataTypeCollection(
    IEnumerable<ModelChangeStructureDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator ModelChangeStructureDataTypeCollection(
    ModelChangeStructureDataType[] values)
  {
    return values != null ? new ModelChangeStructureDataTypeCollection((IEnumerable<ModelChangeStructureDataType>) values) : new ModelChangeStructureDataTypeCollection();
  }

  public static explicit operator ModelChangeStructureDataType[](
    ModelChangeStructureDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ModelChangeStructureDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ModelChangeStructureDataTypeCollection dataTypeCollection = new ModelChangeStructureDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((ModelChangeStructureDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
