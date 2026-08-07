// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NamespaceTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class NamespaceTable : StringTable
{
  public NamespaceTable() => this.Append("http://opcfoundation.org/UA/");

  public NamespaceTable(bool shared) => this.Append("http://opcfoundation.org/UA/");

  public NamespaceTable(IEnumerable<string> namespaceUris) => this.Update(namespaceUris);

  public new void Update(IEnumerable<string> namespaceUris)
  {
    if (namespaceUris == null)
      throw new ArgumentNullException(nameof (namespaceUris));
    int num = 0;
    foreach (string namespaceUri in namespaceUris)
    {
      if (num == 0 && namespaceUri != "http://opcfoundation.org/UA/")
        throw new ArgumentException("The first namespace in the table must be the OPC-UA namespace.");
      ++num;
      if (num == 2)
        break;
    }
    base.Update(namespaceUris);
  }
}
