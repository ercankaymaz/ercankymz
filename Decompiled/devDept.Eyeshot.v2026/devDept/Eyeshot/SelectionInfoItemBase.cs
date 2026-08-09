using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public abstract class SelectionInfoItemBase : SelectedItemBase
{
	public SelectionInfoItemBase()
	{
	}

	public SelectionInfoItemBase(ISelectableItem item)
		: base(item)
	{
	}

	public SelectionInfoItemBase(Stack<BlockReference> parents, ISelectableItem item)
		: base(parents, item)
	{
	}

	internal static T FindInstanceOrCreate<T>(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, ISelectableItem _0023_003Dzs_0024uS8LA_003D, T _0023_003DzRJxZWFc_003D, List<T> _0023_003Dzini8EBrjd836, int _0023_003Dz7i3FGtJB1xLt = -1, object[][] _0023_003DzjcmLyLk_003D = null) where T : SelectionInfoItemBase, new()
	{
		if ((_0023_003Dzq5nwX2I_003D == null || _0023_003Dzq5nwX2I_003D.Count == 0) && _0023_003DzRJxZWFc_003D != null)
		{
			return _0023_003DzRJxZWFc_003D;
		}
		T val = new T();
		val.Init(_0023_003Dzq5nwX2I_003D, _0023_003Dzs_0024uS8LA_003D, -1, -1, _0023_003Dz7i3FGtJB1xLt, _0023_003DzjcmLyLk_003D);
		foreach (T item in _0023_003Dzini8EBrjd836)
		{
			if (val.Equals(item))
			{
				return item;
			}
		}
		_0023_003Dzini8EBrjd836.Add(val);
		return val;
	}

	internal static bool _0023_003DzKr4WJ_0024k_003D<T>(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, ISelectableItem _0023_003Dzs_0024uS8LA_003D, T _0023_003DzRJxZWFc_003D, List<T> _0023_003Dzini8EBrjd836, int _0023_003Dz7i3FGtJB1xLt, object[][] _0023_003DzjcmLyLk_003D) where T : SelectionInfoItemBase, new()
	{
		if ((_0023_003Dzq5nwX2I_003D == null || _0023_003Dzq5nwX2I_003D.Count == 0) && _0023_003DzRJxZWFc_003D != null)
		{
			return false;
		}
		T val = new T();
		val.Init(_0023_003Dzq5nwX2I_003D, _0023_003Dzs_0024uS8LA_003D, -1, -1, _0023_003Dz7i3FGtJB1xLt, _0023_003DzjcmLyLk_003D);
		for (int i = 0; i < _0023_003Dzini8EBrjd836.Count; i++)
		{
			T obj = _0023_003Dzini8EBrjd836[i];
			if (val.Equals(obj))
			{
				_0023_003Dzini8EBrjd836.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public static T FindInstance<T>(Stack<BlockReference> parents, ISelectableItem ent, T selectionItem, List<T> selectionItemsInstances) where T : SelectionInfoItemBase, new()
	{
		if ((parents == null || parents.Count == 0) && selectionItem != null)
		{
			return selectionItem;
		}
		T val = new T();
		val.Init(parents, ent);
		foreach (T selectionItemsInstance in selectionItemsInstances)
		{
			if (val.Equals(selectionItemsInstance))
			{
				return selectionItemsInstance;
			}
		}
		return null;
	}

	internal static bool _0023_003Dz4SMVPY0ZDXX8<T>(ISelectableItem _0023_003Dzs_0024uS8LA_003D, IList<T> _0023_003DzhrgkevI_003D, List<SelectionInfoSubItems> _0023_003DzufNP6tZU4oDJ, int _0023_003DzdP_0xZs_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D) where T : class
	{
		if (_0023_003DzhrgkevI_003D == null)
		{
			return false;
		}
		if (_0023_003DzdP_0xZs_003D >= _0023_003DzhrgkevI_003D.Count)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997420));
		}
		return FindInstanceOrCreate(_0023_003Dzq5nwX2I_003D, _0023_003Dzs_0024uS8LA_003D, null, _0023_003DzufNP6tZU4oDJ, _0023_003DzhrgkevI_003D.Count).SubItems[_0023_003DzdP_0xZs_003D].Selected;
	}
}
