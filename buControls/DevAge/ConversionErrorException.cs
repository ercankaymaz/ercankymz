// Decompiled with JetBrains decompiler
// Type: DevAge.ConversionErrorException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge;

[Serializable]
public class ConversionErrorException : DevAgeApplicationException
{
  public ConversionErrorException(string destinationType, string value, string extendedMessage)
    : base($"{extendedMessage}, cannot convert {value} to {destinationType}.")
  {
  }

  public ConversionErrorException(string destinationType, string value)
    : base($"Cannot convert {value} to {destinationType}.")
  {
  }

  public ConversionErrorException(string destinationType, string value, Exception p_InnerException)
    : base($"Cannot convert {value} to {destinationType}.", p_InnerException)
  {
  }
}
