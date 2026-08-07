// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Newtonsoft.Json.Bson;

internal class BsonObject : BsonToken, IEnumerable<BsonProperty>, IEnumerable
{
  private readonly List<BsonProperty> _children = new List<BsonProperty>();

  public void Add(string name, BsonToken token)
  {
    this._children.Add(new BsonProperty()
    {
      Name = new BsonString((object) name, false),
      Value = token
    });
    token.Parent = (BsonToken) this;
  }

  public override BsonType Type => BsonType.Object;

  public IEnumerator<BsonProperty> GetEnumerator()
  {
    return (IEnumerator<BsonProperty>) this._children.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
