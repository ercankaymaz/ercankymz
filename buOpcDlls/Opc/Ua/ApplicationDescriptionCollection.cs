// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ApplicationDescriptionCollection
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
[CollectionDataContract(Name = "ListOfApplicationDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ApplicationDescription")]
[ComVisible(true)]
public class ApplicationDescriptionCollection : List<ApplicationDescription>, ICloneable
{
  public ApplicationDescriptionCollection()
  {
  }

  public ApplicationDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public ApplicationDescriptionCollection(IEnumerable<ApplicationDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator ApplicationDescriptionCollection(ApplicationDescription[] values)
  {
    return values != null ? new ApplicationDescriptionCollection((IEnumerable<ApplicationDescription>) values) : new ApplicationDescriptionCollection();
  }

  public static explicit operator ApplicationDescription[](ApplicationDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (ApplicationDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ApplicationDescriptionCollection descriptionCollection = new ApplicationDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((ApplicationDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
