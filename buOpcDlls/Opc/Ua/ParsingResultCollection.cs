// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ParsingResultCollection
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
[CollectionDataContract(Name = "ListOfParsingResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ParsingResult")]
[ComVisible(true)]
public class ParsingResultCollection : List<ParsingResult>, ICloneable
{
  public ParsingResultCollection()
  {
  }

  public ParsingResultCollection(int capacity)
    : base(capacity)
  {
  }

  public ParsingResultCollection(IEnumerable<ParsingResult> collection)
    : base(collection)
  {
  }

  public static implicit operator ParsingResultCollection(ParsingResult[] values)
  {
    return values != null ? new ParsingResultCollection((IEnumerable<ParsingResult>) values) : new ParsingResultCollection();
  }

  public static explicit operator ParsingResult[](ParsingResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ParsingResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ParsingResultCollection resultCollection = new ParsingResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((ParsingResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
