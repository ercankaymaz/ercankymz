// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ArgumentCollection
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
[CollectionDataContract(Name = "ListOfArgument", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Argument")]
[ComVisible(true)]
public class ArgumentCollection : List<Argument>, ICloneable
{
  public ArgumentCollection()
  {
  }

  public ArgumentCollection(int capacity)
    : base(capacity)
  {
  }

  public ArgumentCollection(IEnumerable<Argument> collection)
    : base(collection)
  {
  }

  public static implicit operator ArgumentCollection(Argument[] values)
  {
    return values != null ? new ArgumentCollection((IEnumerable<Argument>) values) : new ArgumentCollection();
  }

  public static explicit operator Argument[](ArgumentCollection values) => values?.ToArray();

  public object Clone() => (object) (ArgumentCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ArgumentCollection argumentCollection = new ArgumentCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      argumentCollection.Add((Argument) Utils.Clone((object) this[index]));
    return (object) argumentCollection;
  }
}
