// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ValidationUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

internal static class ValidationUtils
{
  [NullableContext(1)]
  public static void ArgumentNotNull([Nullable(2), NotNull] object value, string parameterName)
  {
    if (value == null)
      throw new ArgumentNullException(parameterName);
  }
}
