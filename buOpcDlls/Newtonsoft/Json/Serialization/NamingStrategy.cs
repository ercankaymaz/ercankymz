// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.NamingStrategy
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public abstract class NamingStrategy
{
  public bool ProcessDictionaryKeys { get; set; }

  public bool ProcessExtensionDataNames { get; set; }

  public bool OverrideSpecifiedNames { get; set; }

  public virtual string GetPropertyName(string name, bool hasSpecifiedName)
  {
    return hasSpecifiedName && !this.OverrideSpecifiedNames ? name : this.ResolvePropertyName(name);
  }

  public virtual string GetExtensionDataName(string name)
  {
    return !this.ProcessExtensionDataNames ? name : this.ResolvePropertyName(name);
  }

  public virtual string GetDictionaryKey(string key)
  {
    return !this.ProcessDictionaryKeys ? key : this.ResolvePropertyName(key);
  }

  protected abstract string ResolvePropertyName(string name);

  public override int GetHashCode()
  {
    return ((this.GetType().GetHashCode() * 397 ^ this.ProcessDictionaryKeys.GetHashCode()) * 397 ^ this.ProcessExtensionDataNames.GetHashCode()) * 397 ^ this.OverrideSpecifiedNames.GetHashCode();
  }

  [NullableContext(2)]
  public override bool Equals(object obj) => this.Equals(obj as NamingStrategy);

  [NullableContext(2)]
  protected bool Equals(NamingStrategy other)
  {
    return other != null && this.GetType() == other.GetType() && this.ProcessDictionaryKeys == other.ProcessDictionaryKeys && this.ProcessExtensionDataNames == other.ProcessExtensionDataNames && this.OverrideSpecifiedNames == other.OverrideSpecifiedNames;
  }
}
