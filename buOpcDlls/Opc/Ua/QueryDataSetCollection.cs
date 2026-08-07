// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryDataSetCollection
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
[CollectionDataContract(Name = "ListOfQueryDataSet", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "QueryDataSet")]
[ComVisible(true)]
public class QueryDataSetCollection : List<QueryDataSet>, ICloneable
{
  public QueryDataSetCollection()
  {
  }

  public QueryDataSetCollection(int capacity)
    : base(capacity)
  {
  }

  public QueryDataSetCollection(IEnumerable<QueryDataSet> collection)
    : base(collection)
  {
  }

  public static implicit operator QueryDataSetCollection(QueryDataSet[] values)
  {
    return values != null ? new QueryDataSetCollection((IEnumerable<QueryDataSet>) values) : new QueryDataSetCollection();
  }

  public static explicit operator QueryDataSet[](QueryDataSetCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (QueryDataSetCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryDataSetCollection dataSetCollection = new QueryDataSetCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataSetCollection.Add((QueryDataSet) Utils.Clone((object) this[index]));
    return (object) dataSetCollection;
  }
}
