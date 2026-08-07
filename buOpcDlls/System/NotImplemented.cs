// Decompiled with JetBrains decompiler
// Type: System.NotImplemented
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System;

internal static class NotImplemented
{
  internal static Exception ByDesign => (Exception) new NotImplementedException();

  internal static Exception ByDesignWithMessage(string message)
  {
    return (Exception) new NotImplementedException(message);
  }

  internal static Exception ActiveIssue(string issue) => (Exception) new NotImplementedException();
}
