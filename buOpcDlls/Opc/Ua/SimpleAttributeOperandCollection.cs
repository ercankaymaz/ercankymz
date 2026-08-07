// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SimpleAttributeOperandCollection
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
[CollectionDataContract(Name = "ListOfSimpleAttributeOperand", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SimpleAttributeOperand")]
[ComVisible(true)]
public class SimpleAttributeOperandCollection : List<SimpleAttributeOperand>, ICloneable
{
  public SimpleAttributeOperandCollection()
  {
  }

  public SimpleAttributeOperandCollection(int capacity)
    : base(capacity)
  {
  }

  public SimpleAttributeOperandCollection(IEnumerable<SimpleAttributeOperand> collection)
    : base(collection)
  {
  }

  public static implicit operator SimpleAttributeOperandCollection(SimpleAttributeOperand[] values)
  {
    return values != null ? new SimpleAttributeOperandCollection((IEnumerable<SimpleAttributeOperand>) values) : new SimpleAttributeOperandCollection();
  }

  public static explicit operator SimpleAttributeOperand[](SimpleAttributeOperandCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (SimpleAttributeOperandCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SimpleAttributeOperandCollection operandCollection = new SimpleAttributeOperandCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      operandCollection.Add((SimpleAttributeOperand) Utils.Clone((object) this[index]));
    return (object) operandCollection;
  }
}
