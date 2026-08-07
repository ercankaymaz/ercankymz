// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.FieldAttribute
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property)]
public class FieldAttribute : Attribute
{
  private int fieldIndex;
  private int length;

  public FieldAttribute(int fieldIndex, int length)
  {
    this.fieldIndex = fieldIndex;
    this.length = length;
  }

  public int FieldIndex => this.fieldIndex;

  public int Length => this.length;
}
