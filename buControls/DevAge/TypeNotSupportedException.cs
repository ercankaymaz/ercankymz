// Decompiled with JetBrains decompiler
// Type: DevAge.TypeNotSupportedException
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge;

[Serializable]
public class TypeNotSupportedException : DevAgeApplicationException
{
  public TypeNotSupportedException(Type pType)
    : base($"Type {pType.ToString()} not supported exception")
  {
  }

  public TypeNotSupportedException(Type pType, Exception p_InnerException)
    : base($"Type {pType.ToString()} not supported exception", p_InnerException)
  {
  }
}
