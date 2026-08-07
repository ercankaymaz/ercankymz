// Decompiled with JetBrains decompiler
// Type: DevAge.UnrecognizedCommandLineParametersException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge;

[Serializable]
public class UnrecognizedCommandLineParametersException : DevAgeApplicationException
{
  public UnrecognizedCommandLineParametersException(string parameter)
    : base($"Unrecognized command line parameter {parameter}.")
  {
  }

  public UnrecognizedCommandLineParametersException(string parameter, Exception p_InnerException)
    : base($"Unrecognized command line parameter {parameter}.", p_InnerException)
  {
  }
}
