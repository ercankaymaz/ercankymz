// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ITranslationManager
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface ITranslationManager
{
  LocalizedText Translate(
    IList<string> preferredLocales,
    string key,
    string text,
    params object[] args);

  LocalizedText Translate(IList<string> preferredLocales, LocalizedText text);

  ServiceResult Translate(IList<string> preferredLocales, ServiceResult result);
}
