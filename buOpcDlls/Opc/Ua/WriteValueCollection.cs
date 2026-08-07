// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriteValueCollection
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
[CollectionDataContract(Name = "ListOfWriteValue", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "WriteValue")]
[ComVisible(true)]
public class WriteValueCollection : List<WriteValue>, ICloneable
{
  public WriteValueCollection()
  {
  }

  public WriteValueCollection(int capacity)
    : base(capacity)
  {
  }

  public WriteValueCollection(IEnumerable<WriteValue> collection)
    : base(collection)
  {
  }

  public static implicit operator WriteValueCollection(WriteValue[] values)
  {
    return values != null ? new WriteValueCollection((IEnumerable<WriteValue>) values) : new WriteValueCollection();
  }

  public static explicit operator WriteValue[](WriteValueCollection values) => values?.ToArray();

  public object Clone() => (object) (WriteValueCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    WriteValueCollection writeValueCollection = new WriteValueCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      writeValueCollection.Add((WriteValue) Utils.Clone((object) this[index]));
    return (object) writeValueCollection;
  }
}
