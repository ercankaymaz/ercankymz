// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceDescriptionCollection
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
[CollectionDataContract(Name = "ListOfReferenceDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReferenceDescription")]
[ComVisible(true)]
public class ReferenceDescriptionCollection : List<ReferenceDescription>, ICloneable
{
  public ReferenceDescriptionCollection()
  {
  }

  public ReferenceDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public ReferenceDescriptionCollection(IEnumerable<ReferenceDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator ReferenceDescriptionCollection(ReferenceDescription[] values)
  {
    return values != null ? new ReferenceDescriptionCollection((IEnumerable<ReferenceDescription>) values) : new ReferenceDescriptionCollection();
  }

  public static explicit operator ReferenceDescription[](ReferenceDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ReferenceDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReferenceDescriptionCollection descriptionCollection = new ReferenceDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((ReferenceDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
