// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.LineWriter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Reflection;
using System.Text;

#nullable disable
namespace DevAge.Text.FixedLength;

public class LineWriter
{
  private FieldList fields;
  private IField[] ifield_0;
  private char char_0 = char.MinValue;
  private object[] object_0;

  public LineWriter(FieldList fields) => this.fields = fields;

  public LineWriter(Type lineClassType)
  {
    this.fields = Utilities.ExtractFieldListFromType(lineClassType);
  }

  public FieldList Fields => this.fields;

  public char Separator
  {
    get => this.char_0;
    set => this.char_0 = value;
  }

  public void Reset() => this.object_0 = (object[]) null;

  public void SetValue(string fieldName, object val)
  {
    if (this.object_0 == null)
      this.object_0 = new object[this.fields.Count];
    if (this.ifield_0 == null)
      this.ifield_0 = this.fields.GetSortedList();
    this.object_0[this.fields[fieldName].Index] = val;
  }

  public string CreateLine()
  {
    if (this.object_0 == null)
      throw new ArgumentNullException("mLineValues", "SetValue not called");
    if (this.ifield_0 == null)
      this.ifield_0 = this.fields.GetSortedList();
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < this.ifield_0.Length; ++index)
    {
      stringBuilder.Append(this.ifield_0[index].ValueToString(this.object_0[index]));
      if (this.Separator > char.MinValue)
        stringBuilder.Append(this.Separator);
    }
    return stringBuilder.ToString();
  }

  public string CreateLineFromClass(object schemaClass)
  {
    foreach (PropertyInfo property in schemaClass.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty))
    {
      if (property.GetCustomAttributes(typeof (FieldAttribute), true).Length != 0)
        this.SetValue(property.Name, property.GetValue(schemaClass, (object[]) null));
    }
    return this.CreateLine();
  }
}
