// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.SnakeCaseNamingStrategy
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

public class SnakeCaseNamingStrategy : NamingStrategy
{
  public SnakeCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
  {
    this.ProcessDictionaryKeys = processDictionaryKeys;
    this.OverrideSpecifiedNames = overrideSpecifiedNames;
  }

  public SnakeCaseNamingStrategy(
    bool processDictionaryKeys,
    bool overrideSpecifiedNames,
    bool processExtensionDataNames)
    : this(processDictionaryKeys, overrideSpecifiedNames)
  {
    this.ProcessExtensionDataNames = processExtensionDataNames;
  }

  public SnakeCaseNamingStrategy()
  {
  }

  [NullableContext(1)]
  protected override string ResolvePropertyName(string name) => StringUtils.ToSnakeCase(name);
}
