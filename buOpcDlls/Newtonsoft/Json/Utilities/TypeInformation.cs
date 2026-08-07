// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.TypeInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class TypeInformation
{
  public Type Type { get; }

  public PrimitiveTypeCode TypeCode { get; }

  public TypeInformation(Type type, PrimitiveTypeCode typeCode)
  {
    this.Type = type;
    this.TypeCode = typeCode;
  }
}
