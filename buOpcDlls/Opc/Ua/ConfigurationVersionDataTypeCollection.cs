// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConfigurationVersionDataTypeCollection
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
[CollectionDataContract(Name = "ListOfConfigurationVersionDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ConfigurationVersionDataType")]
[ComVisible(true)]
public class ConfigurationVersionDataTypeCollection : List<ConfigurationVersionDataType>, ICloneable
{
  public ConfigurationVersionDataTypeCollection()
  {
  }

  public ConfigurationVersionDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public ConfigurationVersionDataTypeCollection(
    IEnumerable<ConfigurationVersionDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator ConfigurationVersionDataTypeCollection(
    ConfigurationVersionDataType[] values)
  {
    return values != null ? new ConfigurationVersionDataTypeCollection((IEnumerable<ConfigurationVersionDataType>) values) : new ConfigurationVersionDataTypeCollection();
  }

  public static explicit operator ConfigurationVersionDataType[](
    ConfigurationVersionDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ConfigurationVersionDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ConfigurationVersionDataTypeCollection dataTypeCollection = new ConfigurationVersionDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((ConfigurationVersionDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
