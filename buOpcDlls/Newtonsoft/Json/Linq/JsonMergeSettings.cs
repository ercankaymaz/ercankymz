// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JsonMergeSettings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Newtonsoft.Json.Linq;

public class JsonMergeSettings
{
  private MergeArrayHandling _mergeArrayHandling;
  private MergeNullValueHandling _mergeNullValueHandling;
  private StringComparison _propertyNameComparison;

  public JsonMergeSettings() => this._propertyNameComparison = StringComparison.Ordinal;

  public MergeArrayHandling MergeArrayHandling
  {
    get => this._mergeArrayHandling;
    set
    {
      this._mergeArrayHandling = value >= MergeArrayHandling.Concat && value <= MergeArrayHandling.Merge ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }

  public MergeNullValueHandling MergeNullValueHandling
  {
    get => this._mergeNullValueHandling;
    set
    {
      this._mergeNullValueHandling = value >= MergeNullValueHandling.Ignore && value <= MergeNullValueHandling.Merge ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }

  public StringComparison PropertyNameComparison
  {
    get => this._propertyNameComparison;
    set
    {
      this._propertyNameComparison = value >= StringComparison.CurrentCulture && value <= StringComparison.OrdinalIgnoreCase ? value : throw new ArgumentOutOfRangeException(nameof (value));
    }
  }
}
