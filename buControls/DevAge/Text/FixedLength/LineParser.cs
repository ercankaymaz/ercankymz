// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.LineParser
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

#nullable disable
namespace DevAge.Text.FixedLength;

public class LineParser
{
  internal FieldList fieldList_0;
  private Regex regex_0;
  private char char_0 = char.MinValue;
  private Match match_0;

  public LineParser() => this.fieldList_0 = new FieldList();

  public LineParser(Type lineClassType)
  {
    this.fieldList_0 = Utilities.ExtractFieldListFromType(lineClassType);
  }

  public FieldList Fields => this.fieldList_0;

  public char Separator
  {
    get => this.char_0;
    set => this.char_0 = value;
  }

  public void Reset()
  {
    this.regex_0 = (Regex) null;
    this.match_0 = (Match) null;
  }

  public void LoadLine(string line)
  {
    if (this.regex_0 == null)
      this.regex_0 = Class39.smethod_370(this);
    this.match_0 = this.regex_0.Match(line);
  }

  public object GetValue(string fieldName)
  {
    if (this.match_0 == null)
      throw new ArgumentNullException("mRegExMatch");
    Group group = this.match_0.Groups[fieldName];
    if (!group.Success)
      throw new RegExException(fieldName);
    return this.fieldList_0[fieldName].StringToValue(group.Value);
  }

  public object FillLineClass(object schemaClass)
  {
    if (this.match_0 == null)
      throw new ArgumentNullException("mRegExMatch", "LoadLine not called");
    foreach (PropertyInfo property in schemaClass.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty))
    {
      if (property.GetCustomAttributes(typeof (FieldAttribute), true).Length != 0)
        property.SetValue(schemaClass, this.GetValue(property.Name), (object[]) null);
    }
    return schemaClass;
  }
}
