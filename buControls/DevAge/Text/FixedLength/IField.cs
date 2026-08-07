// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.IField
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace DevAge.Text.FixedLength;

public interface IField
{
  string RegularExpressionPattern { get; }

  int Index { get; }

  string Name { get; }

  string ValueToString(object val);

  object StringToValue(string str);
}
