// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryDataDescriptionCollection
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
[CollectionDataContract(Name = "ListOfQueryDataDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "QueryDataDescription")]
[ComVisible(true)]
public class QueryDataDescriptionCollection : List<QueryDataDescription>, ICloneable
{
  public QueryDataDescriptionCollection()
  {
  }

  public QueryDataDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public QueryDataDescriptionCollection(IEnumerable<QueryDataDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator QueryDataDescriptionCollection(QueryDataDescription[] values)
  {
    return values != null ? new QueryDataDescriptionCollection((IEnumerable<QueryDataDescription>) values) : new QueryDataDescriptionCollection();
  }

  public static explicit operator QueryDataDescription[](QueryDataDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (QueryDataDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryDataDescriptionCollection descriptionCollection = new QueryDataDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((QueryDataDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
