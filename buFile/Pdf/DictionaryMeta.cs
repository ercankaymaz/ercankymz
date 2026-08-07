// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.DictionaryMeta
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace PdfSharp.Pdf;

internal class DictionaryMeta
{
  private readonly Dictionary<string, KeyDescriptor> _keyDescriptors = new Dictionary<string, KeyDescriptor>();

  public DictionaryMeta(Type type)
  {
    foreach (FieldInfo field in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy))
    {
      object[] customAttributes = field.GetCustomAttributes(typeof (KeyInfoAttribute), false);
      if (customAttributes.Length == 1)
      {
        KeyDescriptor keyDescriptor = new KeyDescriptor((KeyInfoAttribute) customAttributes[0])
        {
          KeyValue = (string) field.GetValue((object) null)
        };
        this._keyDescriptors[keyDescriptor.KeyValue] = keyDescriptor;
      }
    }
  }

  public KeyDescriptor this[string key]
  {
    get
    {
      KeyDescriptor keyDescriptor;
      this._keyDescriptors.TryGetValue(key, out keyDescriptor);
      return keyDescriptor;
    }
  }
}
