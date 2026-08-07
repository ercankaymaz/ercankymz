// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExtensionObjectCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfExtensionObject", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ExtensionObject")]
[ComVisible(true)]
public class ExtensionObjectCollection : List<ExtensionObject>, ICloneable
{
  public ExtensionObjectCollection()
  {
  }

  public ExtensionObjectCollection(IEnumerable<ExtensionObject> collection)
    : base(collection)
  {
  }

  public ExtensionObjectCollection(int capacity)
    : base(capacity)
  {
  }

  public static implicit operator ExtensionObjectCollection(ExtensionObject[] values)
  {
    return values != null ? new ExtensionObjectCollection((IEnumerable<ExtensionObject>) values) : new ExtensionObjectCollection();
  }

  public static ExtensionObjectCollection ToExtensionObjects(IEnumerable<IEncodeable> encodeables)
  {
    if (encodeables == null)
      return (ExtensionObjectCollection) null;
    ExtensionObjectCollection extensionObjects = new ExtensionObjectCollection();
    if (encodeables != null)
    {
      foreach (IEncodeable encodeable in encodeables)
      {
        if (encodeable is ExtensionObject extensionObject)
          extensionObjects.Add(extensionObject);
        else
          extensionObjects.Add(new ExtensionObject((object) encodeable));
      }
    }
    return extensionObjects;
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ExtensionObjectCollection objectCollection = new ExtensionObjectCollection(this.Count);
    foreach (ExtensionObject extensionObject in (List<ExtensionObject>) this)
      objectCollection.Add((ExtensionObject) Utils.Clone((object) extensionObject));
    return (object) objectCollection;
  }
}
