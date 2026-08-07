// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonSerializerInternalBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
internal abstract class JsonSerializerInternalBase
{
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  private ErrorContext _currentErrorContext;
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {2, 1, 1})]
  private BidirectionalDictionary<string, object> _mappings;
  internal readonly JsonSerializer Serializer;
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  internal readonly ITraceWriter TraceWriter;
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  protected JsonSerializerProxy InternalSerializer;

  protected JsonSerializerInternalBase(JsonSerializer serializer)
  {
    ValidationUtils.ArgumentNotNull((object) serializer, nameof (serializer));
    this.Serializer = serializer;
    this.TraceWriter = serializer.TraceWriter;
  }

  internal BidirectionalDictionary<string, object> DefaultReferenceMappings
  {
    get
    {
      if (this._mappings == null)
        this._mappings = new BidirectionalDictionary<string, object>((IEqualityComparer<string>) EqualityComparer<string>.Default, (IEqualityComparer<object>) new JsonSerializerInternalBase.ReferenceEqualsEqualityComparer(), "A different value already has the Id '{0}'.", "A different Id has already been assigned for value '{0}'. This error may be caused by an object being reused multiple times during deserialization and can be fixed with the setting ObjectCreationHandling.Replace.");
      return this._mappings;
    }
  }

  protected NullValueHandling ResolvedNullValueHandling(
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonObjectContract containerContract,
    JsonProperty property)
  {
    return property.NullValueHandling ?? (NullValueHandling?) containerContract?.ItemNullValueHandling ?? this.Serializer._nullValueHandling;
  }

  private ErrorContext GetErrorContext(
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] object currentObject,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] object member,
    string path,
    Exception error)
  {
    if (this._currentErrorContext == null)
      this._currentErrorContext = new ErrorContext(currentObject, member, path, error);
    if (this._currentErrorContext.Error != error)
      throw new InvalidOperationException("Current error context error is different to requested error.");
    return this._currentErrorContext;
  }

  protected void ClearErrorContext()
  {
    this._currentErrorContext = this._currentErrorContext != null ? (ErrorContext) null : throw new InvalidOperationException("Could not clear error context. Error context is already null.");
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  protected bool IsErrorHandled(
    object currentObject,
    JsonContract contract,
    object keyValue,
    IJsonLineInfo lineInfo,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(1)] string path,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(1)] Exception ex)
  {
    ErrorContext errorContext = this.GetErrorContext(currentObject, keyValue, path, ex);
    if (this.TraceWriter != null && this.TraceWriter.LevelFilter >= TraceLevel.Error && !errorContext.Traced)
    {
      errorContext.Traced = true;
      string str = this.GetType() == typeof (JsonSerializerInternalWriter) ? "Error serializing" : "Error deserializing";
      if (contract != null)
        str = $"{str} {contract.UnderlyingType?.ToString()}";
      string message = $"{str}. {ex.Message}";
      if (!(ex is JsonException))
        message = JsonPosition.FormatMessage(lineInfo, path, message);
      this.TraceWriter.Trace(TraceLevel.Error, message, ex);
    }
    if (contract != null && currentObject != null)
      contract.InvokeOnError(currentObject, this.Serializer.Context, errorContext);
    if (!errorContext.Handled)
      this.Serializer.OnError(new ErrorEventArgs(currentObject, errorContext));
    return errorContext.Handled;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(0)]
  private class ReferenceEqualsEqualityComparer : IEqualityComparer<object>
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
    bool IEqualityComparer<object>.Equals(object x, object y) => x == y;

    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
    int IEqualityComparer<object>.GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
  }
}
