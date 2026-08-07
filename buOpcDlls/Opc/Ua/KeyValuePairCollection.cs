// Decompiled with JetBrains decompiler
// Type: Opc.Ua.KeyValuePairCollection
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
[CollectionDataContract(Name = "ListOfKeyValuePair", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "KeyValuePair")]
[ComVisible(true)]
public class KeyValuePairCollection : List<KeyValuePair>, ICloneable
{
  public KeyValuePairCollection()
  {
  }

  public KeyValuePairCollection(int capacity)
    : base(capacity)
  {
  }

  public KeyValuePairCollection(IEnumerable<KeyValuePair> collection)
    : base(collection)
  {
  }

  public static implicit operator KeyValuePairCollection(KeyValuePair[] values)
  {
    return values != null ? new KeyValuePairCollection((IEnumerable<KeyValuePair>) values) : new KeyValuePairCollection();
  }

  public static explicit operator KeyValuePair[](KeyValuePairCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (KeyValuePairCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    KeyValuePairCollection valuePairCollection = new KeyValuePairCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      valuePairCollection.Add((KeyValuePair) Utils.Clone((object) this[index]));
    return (object) valuePairCollection;
  }
}
