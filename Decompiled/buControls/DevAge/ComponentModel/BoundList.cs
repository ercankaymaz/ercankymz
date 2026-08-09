using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DevAge.ComponentModel;

[Serializable]
public class BoundList<T> : BoundListBase<T>
{
	[CompilerGenerated]
	private sealed class Class77
	{
		public ListSortDescriptionCollection listSortDescriptionCollection_0;

		internal int method_0(T gparam_0, T gparam_1)
		{
			foreach (ListSortDescription item in (IEnumerable)listSortDescriptionCollection_0)
			{
				IComparable comparable = item.PropertyDescriptor.GetValue(gparam_0) as IComparable;
				IComparable comparable2 = item.PropertyDescriptor.GetValue(gparam_1) as IComparable;
				if (item.SortDirection == ListSortDirection.Descending)
				{
					IComparable comparable3 = comparable;
					comparable = comparable2;
					comparable2 = comparable3;
				}
				if (comparable == null || comparable2 == null)
				{
					if (comparable == null)
					{
						return -1;
					}
					return 1;
				}
				int num = comparable.CompareTo(comparable2);
				if (num != 0)
				{
					return num;
				}
			}
			return 0;
		}
	}

	private IList<T> mList;

	public override object this[int index] => mList[index];

	public override int Count => mList.Count;

	public BoundList(IList<T> list)
	{
		mList = list;
		base.AllowNew = true;
		base.AllowDelete = true;
		base.AllowEdit = true;
		base.AllowSort = mList is List<T>;
	}

	protected override T OnAddNew()
	{
		T val = Activator.CreateInstance<T>();
		mList.Add(val);
		return val;
	}

	public override int IndexOf(object item)
	{
		return mList.IndexOf((T)item);
	}

	protected override void OnRemoveAt(int index)
	{
		mList.RemoveAt(index);
	}

	protected override void OnClear()
	{
		mList.Clear();
	}

	public override void ApplySort(ListSortDescriptionCollection sorts)
	{
		if (!(mList is List<T> list))
		{
			throw new DevAgeApplicationException("Sort not supported, the list must be an instance of List<T>.");
		}
		list.Sort(delegate(T gparam_0, T gparam_1)
		{
			foreach (ListSortDescription item in (IEnumerable)sorts)
			{
				IComparable comparable = item.PropertyDescriptor.GetValue(gparam_0) as IComparable;
				IComparable comparable2 = item.PropertyDescriptor.GetValue(gparam_1) as IComparable;
				if (item.SortDirection == ListSortDirection.Descending)
				{
					IComparable comparable3 = comparable;
					comparable = comparable2;
					comparable2 = comparable3;
				}
				if (comparable == null || comparable2 == null)
				{
					if (comparable == null)
					{
						return -1;
					}
					return 1;
				}
				int num = comparable.CompareTo(comparable2);
				if (num != 0)
				{
					return num;
				}
			}
			return 0;
		});
		OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
	}
}
