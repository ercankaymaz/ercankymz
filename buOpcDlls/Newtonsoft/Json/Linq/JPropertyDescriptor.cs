// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JPropertyDescriptor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq;

[NullableContext(1)]
[Nullable(0)]
public class JPropertyDescriptor(string name) : PropertyDescriptor(name, (Attribute[]) null)
{
  private static JObject CastInstance(object instance) => (JObject) instance;

  public override bool CanResetValue(object component) => false;

  [NullableContext(2)]
  public override object GetValue(object component)
  {
    // ISSUE: explicit non-virtual call
    return !(component is JObject jobject) ? (object) null : (object) __nonvirtual (jobject[this.Name]);
  }

  public override void ResetValue(object component)
  {
  }

  [NullableContext(2)]
  public override void SetValue(object component, object value)
  {
    if (!(component is JObject jobject))
      return;
    if (!(value is JToken jtoken1))
      jtoken1 = (JToken) new JValue(value);
    JToken jtoken2 = jtoken1;
    jobject[this.Name] = jtoken2;
  }

  public override bool ShouldSerializeValue(object component) => false;

  public override Type ComponentType => typeof (JObject);

  public override bool IsReadOnly => false;

  public override Type PropertyType => typeof (object);

  protected override int NameHashCode => base.NameHashCode;
}
