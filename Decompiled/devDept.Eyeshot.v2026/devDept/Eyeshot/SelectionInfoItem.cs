using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectionInfoItem : SelectionInfoItemBase
{
	internal SelectionInfo SelectionInfo;

	public SelectionInfoItem()
	{
	}

	public SelectionInfoItem(SelectionInfoItem another)
		: base(another.Parents, another.Item)
	{
		SelectionInfo = another.SelectionInfo;
	}

	public SelectionInfoItem(ISelectableItem item)
		: base(item)
	{
	}

	public SelectionInfoItem(Stack<BlockReference> parents, ISelectableItem item)
		: base(parents, item)
	{
	}

	internal static bool _0023_003DzAdoyA7k_003D(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, Entity _0023_003Dzs_0024uS8LA_003D, out SelectionInfoItem _0023_003Dzv0Okb82R5LqH)
	{
		return _0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, _0023_003Dzs_0024uS8LA_003D, _0023_003Dzs_0024uS8LA_003D.InstanceSelectionInfo, out _0023_003Dzv0Okb82R5LqH);
	}

	internal static bool _0023_003DzAdoyA7k_003D<T>(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, Entity _0023_003Dzs_0024uS8LA_003D, List<T> _0023_003DzhrgkevI_003D, out T _0023_003Dzv0Okb82R5LqH) where T : SelectionInfoItemBase, new()
	{
		_0023_003Dzv0Okb82R5LqH = null;
		if (_0023_003DzhrgkevI_003D.Count == 0)
		{
			return false;
		}
		T val = new T();
		val.Init(_0023_003Dzq5nwX2I_003D, (_0023_003Dzs_0024uS8LA_003D is NestedEntity) ? ((NestedEntity)_0023_003Dzs_0024uS8LA_003D).entity : _0023_003Dzs_0024uS8LA_003D);
		int num = SelectedItemBase._0023_003DzAdoyA7k_003D(val, _0023_003DzhrgkevI_003D);
		if (num >= 0)
		{
			_0023_003Dzv0Okb82R5LqH = _0023_003DzhrgkevI_003D[num];
			return true;
		}
		return false;
	}

	internal static int _0023_003DzAdoyA7k_003D(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, Entity _0023_003Dzs_0024uS8LA_003D, List<SelectionInfoItem> _0023_003DzhrgkevI_003D)
	{
		return SelectedItemBase._0023_003DzAdoyA7k_003D(new SelectionInfoItem(_0023_003Dzq5nwX2I_003D, _0023_003Dzs_0024uS8LA_003D), _0023_003DzhrgkevI_003D);
	}
}
