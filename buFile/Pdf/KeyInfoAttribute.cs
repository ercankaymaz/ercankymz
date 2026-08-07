// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.KeyInfoAttribute
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf;

internal class KeyInfoAttribute : Attribute
{
  private string _version = "1.0";
  private KeyType _entryType;
  private Type _objectType;
  private string _fixedValue;

  public KeyInfoAttribute()
  {
  }

  public KeyInfoAttribute(KeyType keyType) => this.KeyType = keyType;

  public KeyInfoAttribute(string version, KeyType keyType)
  {
    this._version = version;
    this.KeyType = keyType;
  }

  public KeyInfoAttribute(KeyType keyType, Type objectType)
  {
    this.KeyType = keyType;
    this._objectType = objectType;
  }

  public KeyInfoAttribute(string version, KeyType keyType, Type objectType)
  {
    this.KeyType = keyType;
    this._objectType = objectType;
  }

  public string Version
  {
    get => this._version;
    set => this._version = value;
  }

  public KeyType KeyType
  {
    get => this._entryType;
    set => this._entryType = value;
  }

  public Type ObjectType
  {
    get => this._objectType;
    set => this._objectType = value;
  }

  public string FixedValue
  {
    get => this._fixedValue;
    set => this._fixedValue = value;
  }
}
