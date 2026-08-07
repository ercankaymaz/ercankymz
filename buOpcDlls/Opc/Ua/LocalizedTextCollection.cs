// Decompiled with JetBrains decompiler
// Type: Opc.Ua.LocalizedTextCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfLocalizedText", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "LocalizedText")]
[ComVisible(true)]
public class LocalizedTextCollection : List<LocalizedText>, ICloneable
{
  public LocalizedTextCollection()
  {
  }

  public LocalizedTextCollection(IEnumerable<LocalizedText> collection)
    : base(collection)
  {
  }

  public LocalizedTextCollection(int capacity)
    : base(capacity)
  {
  }

  public static LocalizedTextCollection ToLocalizedTextCollection(LocalizedText[] values)
  {
    return values != null ? new LocalizedTextCollection((IEnumerable<LocalizedText>) values) : new LocalizedTextCollection();
  }

  public static implicit operator LocalizedTextCollection(LocalizedText[] values)
  {
    return LocalizedTextCollection.ToLocalizedTextCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection(this.Count);
    foreach (LocalizedText localizedText in (List<LocalizedText>) this)
      localizedTextCollection.Add((LocalizedText) Utils.Clone((object) localizedText));
    return (object) localizedTextCollection;
  }
}
