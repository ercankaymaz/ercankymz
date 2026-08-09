using System;
using System.ComponentModel;

namespace DevAge.ComponentModel;

public interface IBoundList
{
	bool AllowDelete { get; set; }

	bool AllowEdit { get; set; }

	bool AllowNew { get; set; }

	bool AllowSort { get; set; }

	int Count { get; }

	object EditedObject { get; }

	object this[int index] { get; }

	event ListChangedEventHandler ListChanged;

	event EventHandler ListCleared;

	event ItemDeletedEventHandler ItemDeleted;

	void ApplySort(ListSortDescriptionCollection sorts);

	int BeginAddNew();

	void BeginEdit(int index);

	void EndEdit(bool cancel);

	PropertyDescriptorCollection GetItemProperties();

	PropertyDescriptor GetItemProperty(string name, StringComparison comparison);

	object GetItemValue(int index, PropertyDescriptor property);

	int IndexOf(object item);

	void RemoveAt(int index);

	void SetEditValue(PropertyDescriptor property, object value);
}
