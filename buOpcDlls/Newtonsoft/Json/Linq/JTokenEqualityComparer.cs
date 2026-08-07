// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JTokenEqualityComparer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq;

public class JTokenEqualityComparer : IEqualityComparer<JToken>
{
  [NullableContext(2)]
  public bool Equals(JToken x, JToken y) => JToken.DeepEquals(x, y);

  [NullableContext(1)]
  public int GetHashCode(JToken obj) => obj == null ? 0 : obj.GetDeepHashCode();
}
