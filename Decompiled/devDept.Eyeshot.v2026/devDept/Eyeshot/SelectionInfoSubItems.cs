using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectionInfoSubItems : SelectionInfoItemBase
{
	public SelectionInfo[] SubItems;

	public SelectionInfoSubItems()
	{
	}

	public SelectionInfoSubItems(Entity entity)
		: base(entity)
	{
	}

	public SelectionInfoSubItems(Stack<BlockReference> parents, Entity entity)
		: base(parents, entity)
	{
	}

	public void InitSubItems(int nSubItems)
	{
		if (nSubItems > 0)
		{
			SubItems = new SelectionInfo[nSubItems];
		}
	}

	public override void Init(Stack<BlockReference> parents, ISelectableItem item, int subItemIndex = -1, int shellIndex = -1, int nSubItems = -1, object[][] subItemsArray = null)
	{
		base.Init(parents, item, subItemIndex, shellIndex, nSubItems, subItemsArray);
		InitSubItems(nSubItems);
	}

	internal static void _0023_003DzTaF8sCpHm_00245q<T>(selectionFilterType _0023_003DzxI9fQJQ_003D, int _0023_003DzBSDzNQmNUKC9, bool _0023_003DzZ5LFmfg_003D, ISelectableSubItems _0023_003DzUBZd570_003D, IList<T> _0023_003DzpCBhWntJQT8t, List<SelectionInfoSubItems> _0023_003DzS3_0024V2GK_0024oosa, Stack<BlockReference> _0023_003Dzq5nwX2I_003D) where T : class
	{
		if (_0023_003DzpCBhWntJQT8t == null)
		{
			throw new EyeshotException(_0023_003DzEBUZAtc_003D(_0023_003DzxI9fQJQ_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997381));
		}
		_0023_003DzTaF8sCpHm_00245q(_0023_003DzxI9fQJQ_003D, _0023_003DzBSDzNQmNUKC9, _0023_003DzZ5LFmfg_003D, _0023_003DzUBZd570_003D, _0023_003DzpCBhWntJQT8t.Count, _0023_003DzS3_0024V2GK_0024oosa, _0023_003Dzq5nwX2I_003D);
	}

	internal static void _0023_003DzTaF8sCpHm_00245q(selectionFilterType _0023_003DzxI9fQJQ_003D, int _0023_003DzBSDzNQmNUKC9, bool _0023_003DzZ5LFmfg_003D, ISelectableSubItems _0023_003DzUBZd570_003D, int _0023_003Dz413AECo_dhC7, List<SelectionInfoSubItems> _0023_003DzS3_0024V2GK_0024oosa, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstanceOrCreate(_0023_003Dzq5nwX2I_003D, (ISelectableItem)_0023_003DzUBZd570_003D, null, _0023_003DzS3_0024V2GK_0024oosa, _0023_003Dz413AECo_dhC7);
		if (_0023_003DzBSDzNQmNUKC9 > _0023_003Dz413AECo_dhC7)
		{
			throw new EyeshotException(_0023_003DzEBUZAtc_003D(_0023_003DzxI9fQJQ_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997100));
		}
		if (selectionInfoSubItems.SubItems[_0023_003DzBSDzNQmNUKC9].Selected != _0023_003DzZ5LFmfg_003D)
		{
			selectionInfoSubItems.SubItems[_0023_003DzBSDzNQmNUKC9].Selected = _0023_003DzZ5LFmfg_003D;
			((Entity)_0023_003DzUBZd570_003D).isDirtyForFlattenTree = true;
		}
		if (IsAnySelected(selectionInfoSubItems.SubItems))
		{
			_0023_003DzUBZd570_003D.SelectionMode = _0023_003DzxI9fQJQ_003D;
		}
		else if (_0023_003DzUBZd570_003D.SelectionMode == _0023_003DzxI9fQJQ_003D)
		{
			_0023_003DzUBZd570_003D.SelectionMode = selectionFilterType.Entity;
		}
	}

	internal static string _0023_003DzEBUZAtc_003D(selectionFilterType _0023_003DzxI9fQJQ_003D)
	{
		string result = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997044);
		switch (_0023_003DzxI9fQJQ_003D)
		{
		case selectionFilterType.Edge:
			result = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958913);
			break;
		case selectionFilterType.Face:
			result = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987071);
			break;
		case selectionFilterType.Vertex:
			result = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988087);
			break;
		}
		return result;
	}

	internal static bool IsAnySelected<T>(List<T> _0023_003DzhrgkevI_003D) where T : SelectionInfoSubItems
	{
		if (_0023_003DzhrgkevI_003D == null)
		{
			return false;
		}
		foreach (T item in _0023_003DzhrgkevI_003D)
		{
			if (IsAnySelected(item.SubItems))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool IsAnySelected(SelectionInfo[] _0023_003DzhrgkevI_003D)
	{
		if (_0023_003DzhrgkevI_003D == null)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzhrgkevI_003D.Length; i++)
		{
			if (_0023_003DzhrgkevI_003D[i]._selectionStatus != selectionStatusType.None)
			{
				return true;
			}
		}
		return false;
	}

	internal static bool IsAnySelected(SelectionInfo[] _0023_003DzhrgkevI_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		if (_0023_003DzhrgkevI_003D == null)
		{
			return false;
		}
		foreach (SelectionInfo selectionInfo in _0023_003DzhrgkevI_003D)
		{
			if (selectionInfo.IsFlagSet(_0023_003DzLEq8mIc_003D))
			{
				return true;
			}
		}
		return false;
	}

	internal static void _0023_003DzpeLpar2z_0024ejG(selectionStatusType _0023_003DzCYtX6jC7ppkE, ISelectableSubItems _0023_003Dzs_0024uS8LA_003D, List<SelectionInfoSubItems> _0023_003DzueDrsJk_003D)
	{
		if (_0023_003DzCYtX6jC7ppkE == selectionStatusType.Temporary)
		{
			foreach (SelectionInfoSubItems item in _0023_003DzueDrsJk_003D)
			{
				for (int i = 0; i < item.SubItems.Length; i++)
				{
					item.SubItems[i].UnsetFlag(_0023_003DzCYtX6jC7ppkE);
				}
			}
		}
		else
		{
			if (IsAnySelected(_0023_003DzueDrsJk_003D))
			{
				((Entity)_0023_003Dzs_0024uS8LA_003D).isDirtyForFlattenTree = true;
			}
			_0023_003DzueDrsJk_003D.Clear();
		}
		_0023_003Dzs_0024uS8LA_003D.SelectionMode = selectionFilterType.Entity;
	}
}
