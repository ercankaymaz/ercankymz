// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.IBoundList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;

#nullable disable
namespace DevAge.ComponentModel;

public interface IBoundList
{
  bool AllowDelete { get; set; }

  bool AllowEdit { get; set; }

  bool AllowNew { get; set; }

  bool AllowSort { get; set; }

  void ApplySort(ListSortDescriptionCollection sorts);

  int BeginAddNew();

  void BeginEdit(int index);

  int Count { get; }

  object EditedObject { get; }

  void EndEdit(bool cancel);

  PropertyDescriptorCollection GetItemProperties();

  PropertyDescriptor GetItemProperty(string name, StringComparison comparison);

  object GetItemValue(int index, PropertyDescriptor property);

  int IndexOf(object item);

  event ListChangedEventHandler ListChanged;

  void RemoveAt(int index);

  void SetEditValue(PropertyDescriptor property, object value);

  object this[int index] { get; }

  event EventHandler ListCleared;

  event ItemDeletedEventHandler ItemDeleted;
}
