// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonArray
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Newtonsoft.Json.Bson;

internal class BsonArray : BsonToken, IEnumerable<BsonToken>, IEnumerable
{
  private readonly List<BsonToken> _children = new List<BsonToken>();

  public void Add(BsonToken token)
  {
    this._children.Add(token);
    token.Parent = (BsonToken) this;
  }

  public override BsonType Type => BsonType.Array;

  public IEnumerator<BsonToken> GetEnumerator()
  {
    return (IEnumerator<BsonToken>) this._children.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
