// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.ReflectionAttributeProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public class ReflectionAttributeProvider : IAttributeProvider
{
  private readonly object _attributeProvider;

  public ReflectionAttributeProvider(object attributeProvider)
  {
    ValidationUtils.ArgumentNotNull(attributeProvider, nameof (attributeProvider));
    this._attributeProvider = attributeProvider;
  }

  public IList<Attribute> GetAttributes(bool inherit)
  {
    return (IList<Attribute>) ReflectionUtils.GetAttributes(this._attributeProvider, (Type) null, inherit);
  }

  public IList<Attribute> GetAttributes(Type attributeType, bool inherit)
  {
    return (IList<Attribute>) ReflectionUtils.GetAttributes(this._attributeProvider, attributeType, inherit);
  }
}
