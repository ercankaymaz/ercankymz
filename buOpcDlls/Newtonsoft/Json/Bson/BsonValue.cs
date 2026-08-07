// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Newtonsoft.Json.Bson;

internal class BsonValue : BsonToken
{
  private readonly object _value;
  private readonly BsonType _type;

  public BsonValue(object value, BsonType type)
  {
    this._value = value;
    this._type = type;
  }

  public object Value => this._value;

  public override BsonType Type => this._type;
}
