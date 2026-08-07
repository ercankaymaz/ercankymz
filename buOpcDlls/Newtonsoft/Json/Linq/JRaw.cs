// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JRaw
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Linq;

[NullableContext(1)]
[Nullable(0)]
public class JRaw : JValue
{
  public static async Task<JRaw> CreateAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken))
  {
    JRaw async;
    using (StringWriter sw = new StringWriter((IFormatProvider) CultureInfo.InvariantCulture))
    {
      using (JsonTextWriter jsonWriter = new JsonTextWriter((TextWriter) sw))
      {
        await jsonWriter.WriteTokenSyncReadingAsync(reader, cancellationToken).ConfigureAwait(false);
        async = new JRaw((object) sw.ToString());
      }
    }
    return async;
  }

  public JRaw(JRaw other)
    : base((JValue) other, (JsonCloneSettings) null)
  {
  }

  internal JRaw(JRaw other, [Nullable(2)] JsonCloneSettings settings)
    : base((JValue) other, settings)
  {
  }

  [NullableContext(2)]
  public JRaw(object rawJson)
    : base(rawJson, JTokenType.Raw)
  {
  }

  public static JRaw Create(JsonReader reader)
  {
    using (StringWriter stringWriter = new StringWriter((IFormatProvider) CultureInfo.InvariantCulture))
    {
      using (JsonTextWriter jsonTextWriter = new JsonTextWriter((TextWriter) stringWriter))
      {
        jsonTextWriter.WriteToken(reader);
        return new JRaw((object) stringWriter.ToString());
      }
    }
  }

  internal override JToken CloneToken([Nullable(2)] JsonCloneSettings settings)
  {
    return (JToken) new JRaw(this, settings);
  }
}
