// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransferResultCollection
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
[CollectionDataContract(Name = "ListOfTransferResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TransferResult")]
[ComVisible(true)]
public class TransferResultCollection : List<TransferResult>, ICloneable
{
  public TransferResultCollection()
  {
  }

  public TransferResultCollection(int capacity)
    : base(capacity)
  {
  }

  public TransferResultCollection(IEnumerable<TransferResult> collection)
    : base(collection)
  {
  }

  public static implicit operator TransferResultCollection(TransferResult[] values)
  {
    return values != null ? new TransferResultCollection((IEnumerable<TransferResult>) values) : new TransferResultCollection();
  }

  public static explicit operator TransferResult[](TransferResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TransferResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TransferResultCollection resultCollection = new TransferResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((TransferResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
