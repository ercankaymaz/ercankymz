// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OpenFileModeCollection
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
[CollectionDataContract(Name = "ListOfOpenFileMode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "OpenFileMode")]
[ComVisible(true)]
public class OpenFileModeCollection : List<OpenFileMode>, ICloneable
{
  public OpenFileModeCollection()
  {
  }

  public OpenFileModeCollection(int capacity)
    : base(capacity)
  {
  }

  public OpenFileModeCollection(IEnumerable<OpenFileMode> collection)
    : base(collection)
  {
  }

  public static implicit operator OpenFileModeCollection(OpenFileMode[] values)
  {
    return values != null ? new OpenFileModeCollection((IEnumerable<OpenFileMode>) values) : new OpenFileModeCollection();
  }

  public static explicit operator OpenFileMode[](OpenFileModeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (OpenFileModeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    OpenFileModeCollection fileModeCollection = new OpenFileModeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      fileModeCollection.Add((OpenFileMode) Utils.Clone((object) this[index]));
    return (object) fileModeCollection;
  }
}
