// Decompiled with JetBrains decompiler
// Type: buComm.FTP.FTPReply
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using \u0003;
using System;
using System.IO;
using System.Runtime.CompilerServices;

#nullable disable
namespace buComm.FTP;

public class FTPReply
{
  internal bool \u0001;
  internal TextWriter \u0001;

  public abstract void m0000CF();

  [SpecialName]
  public int get_ReplyCode() => ((\u0002) this).\u0001;

  public FTPReply(string msg)
  {
    ((\u0002) this).\u0001 = -1;
    // ISSUE: explicit constructor call
    ((Exception) this).\u002Ector(msg);
  }

  public string ReplyCode
  {
    [SpecialName] get => ((\u0002) this).\u0001;
  }

  public string ReplyText
  {
    [SpecialName] get => ((\u0002) this).\u0002;
  }
}
