// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.IWrappedDictionary
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

internal interface IWrappedDictionary : IDictionary, ICollection, IEnumerable
{
  [Nullable(1)]
  object UnderlyingDictionary { [NullableContext(1)] get; }
}
