// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.KeyDescriptor
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

internal sealed class KeyDescriptor
{
  private string _version;
  private KeyType _keyType;
  private string _keyValue;
  private readonly string _fixedValue;
  private Type _objectType;

  public KeyDescriptor(KeyInfoAttribute attribute)
  {
    this._version = attribute.Version;
    this._keyType = attribute.KeyType;
    this._fixedValue = attribute.FixedValue;
    this._objectType = attribute.ObjectType;
    if (!(this._version == ""))
      return;
    this._version = "1.0";
  }

  public string Version
  {
    get => this._version;
    set => this._version = value;
  }

  public KeyType KeyType
  {
    get => this._keyType;
    set => this._keyType = value;
  }

  public string KeyValue
  {
    get => this._keyValue;
    set => this._keyValue = value;
  }

  public string FixedValue => this._fixedValue;

  public Type ObjectType
  {
    get => this._objectType;
    set => this._objectType = value;
  }

  public bool CanBeIndirect => (this._keyType & KeyType.MustNotBeIndirect) == (KeyType) 0;

  public Type GetValueType()
  {
    Type type = this._objectType;
    Type valueType;
    if (type == (Type) null)
    {
      switch (this._keyType & KeyType.TypeMask)
      {
        case KeyType.Name:
          type = typeof (PdfName);
          break;
        case KeyType.String:
          type = typeof (PdfString);
          break;
        case KeyType.Boolean:
          type = typeof (PdfBoolean);
          break;
        case KeyType.Integer:
          type = typeof (PdfInteger);
          break;
        case KeyType.Real:
          type = typeof (PdfReal);
          break;
        case KeyType.Date:
          type = typeof (PdfDate);
          break;
        case KeyType.Rectangle:
          type = typeof (PdfRectangle);
          break;
        case KeyType.Array:
          type = typeof (PdfArray);
          break;
        case KeyType.Dictionary:
          type = typeof (PdfDictionary);
          break;
        case KeyType.Stream:
          type = typeof (PdfDictionary);
          break;
        case KeyType.NumberTree:
          throw new NotImplementedException("KeyType.NumberTree");
        case KeyType.NameOrArray:
          throw new NotImplementedException("KeyType.NameOrArray");
        case KeyType.ArrayOrDictionary:
          throw new NotImplementedException("KeyType.ArrayOrDictionary");
        case KeyType.StreamOrArray:
          throw new NotImplementedException("KeyType.StreamOrArray");
        case KeyType.ArrayOrNameOrString:
          valueType = (Type) null;
          goto label_19;
        default:
          Debug.Assert(false, "Invalid KeyType: " + this._keyType.ToString());
          break;
      }
    }
    valueType = type;
label_19:
    return valueType;
  }
}
