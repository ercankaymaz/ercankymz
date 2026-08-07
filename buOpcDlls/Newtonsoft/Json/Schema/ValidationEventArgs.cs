// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Schema.ValidationEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;

#nullable disable
namespace Newtonsoft.Json.Schema;

[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
public class ValidationEventArgs : EventArgs
{
  private readonly JsonSchemaException _ex;

  internal ValidationEventArgs(JsonSchemaException ex)
  {
    ValidationUtils.ArgumentNotNull((object) ex, nameof (ex));
    this._ex = ex;
  }

  public JsonSchemaException Exception => this._ex;

  public string Path => this._ex.Path;

  public string Message => this._ex.Message;
}
