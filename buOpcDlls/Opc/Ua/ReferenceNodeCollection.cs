// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceNodeCollection
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
[CollectionDataContract(Name = "ListOfReferenceNode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReferenceNode")]
[ComVisible(true)]
public class ReferenceNodeCollection : List<ReferenceNode>, ICloneable
{
  public ReferenceNodeCollection()
  {
  }

  public ReferenceNodeCollection(int capacity)
    : base(capacity)
  {
  }

  public ReferenceNodeCollection(IEnumerable<ReferenceNode> collection)
    : base(collection)
  {
  }

  public static implicit operator ReferenceNodeCollection(ReferenceNode[] values)
  {
    return values != null ? new ReferenceNodeCollection((IEnumerable<ReferenceNode>) values) : new ReferenceNodeCollection();
  }

  public static explicit operator ReferenceNode[](ReferenceNodeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ReferenceNodeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReferenceNodeCollection referenceNodeCollection = new ReferenceNodeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      referenceNodeCollection.Add((ReferenceNode) Utils.Clone((object) this[index]));
    return (object) referenceNodeCollection;
  }
}
