using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectionInfoSubItemsArray : SelectionInfoItemBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SelectionInfo[][] _0023_003DzeW3aY6DmBieiHhtnrdN98_00244_003D;

	internal SelectionInfo[][] SubItems
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeW3aY6DmBieiHhtnrdN98_00244_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzeW3aY6DmBieiHhtnrdN98_00244_003D = value;
		}
	}

	public SelectionInfoSubItemsArray(Stack<BlockReference> parents, ISelectableItem item)
		: base(parents, item)
	{
	}

	public SelectionInfoSubItemsArray()
	{
	}

	public void InitSubItemsArray(object[][] inners)
	{
		if (inners != null)
		{
			SubItems = new SelectionInfo[inners.GetLength(0)][];
			for (int i = 0; i < SubItems.GetLength(0); i++)
			{
				SubItems[i] = new SelectionInfo[inners[i].Length];
			}
		}
	}

	public override void Init(Stack<BlockReference> parents, ISelectableItem item, int subItemIndex = -1, int shellIndex = -1, int nSubItems = -1, object[][] subItemsArray = null)
	{
		base.Init(parents, item, subItemIndex, shellIndex, nSubItems, subItemsArray);
		InitSubItemsArray(subItemsArray);
	}

	internal static void _0023_003DzTaF8sCpHm_00245q(selectionFilterType _0023_003DzxI9fQJQ_003D, int _0023_003DzRLCcpW4_003D, int _0023_003DzBSDzNQmNUKC9, bool _0023_003DzZ5LFmfg_003D, ISelectableSubItems _0023_003DzUBZd570_003D, object[][] _0023_003DzTKaCZH1EUYXa, List<SelectionInfoSubItemsArray> _0023_003DzS3_0024V2GK_0024oosa, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		if (_0023_003DzTKaCZH1EUYXa == null)
		{
			throw new EyeshotException(SelectionInfoSubItems._0023_003DzEBUZAtc_003D(_0023_003DzxI9fQJQ_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997381));
		}
		SelectionInfoSubItemsArray selectionInfoSubItemsArray = SelectionInfoItemBase.FindInstanceOrCreate(_0023_003Dzq5nwX2I_003D, (ISelectableItem)_0023_003DzUBZd570_003D, null, _0023_003DzS3_0024V2GK_0024oosa, -1, _0023_003DzTKaCZH1EUYXa);
		if (_0023_003DzRLCcpW4_003D > _0023_003DzTKaCZH1EUYXa.GetLength(0))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997055));
		}
		if (_0023_003DzBSDzNQmNUKC9 > _0023_003DzTKaCZH1EUYXa[_0023_003DzRLCcpW4_003D - 1].Length)
		{
			throw new EyeshotException(SelectionInfoSubItems._0023_003DzEBUZAtc_003D(_0023_003DzxI9fQJQ_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997100));
		}
		if (selectionInfoSubItemsArray.SubItems[_0023_003DzRLCcpW4_003D - 1][_0023_003DzBSDzNQmNUKC9].Selected != _0023_003DzZ5LFmfg_003D)
		{
			selectionInfoSubItemsArray.SubItems[_0023_003DzRLCcpW4_003D - 1][_0023_003DzBSDzNQmNUKC9].Selected = _0023_003DzZ5LFmfg_003D;
			((Entity)_0023_003DzUBZd570_003D).isDirtyForFlattenTree = true;
		}
		if (_0023_003DzwRqUsQPmazuq(selectionInfoSubItemsArray.SubItems))
		{
			_0023_003DzUBZd570_003D.SelectionMode = _0023_003DzxI9fQJQ_003D;
		}
		else if (_0023_003DzUBZd570_003D.SelectionMode == _0023_003DzxI9fQJQ_003D)
		{
			_0023_003DzUBZd570_003D.SelectionMode = selectionFilterType.Entity;
		}
	}

	private static bool _0023_003DzwRqUsQPmazuq(SelectionInfo[][] _0023_003DzjcmLyLk_003D)
	{
		for (int i = 0; i < _0023_003DzjcmLyLk_003D.Length; i++)
		{
			if (SelectionInfoSubItems.IsAnySelected(_0023_003DzjcmLyLk_003D[i]))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _0023_003DzwRqUsQPmazuq(SelectionInfo[][] _0023_003DzhrgkevI_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		if (_0023_003DzhrgkevI_003D == null)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzhrgkevI_003D.GetLength(0); i++)
		{
			for (int j = 0; j < _0023_003DzhrgkevI_003D[i].Length; j++)
			{
				if (_0023_003DzhrgkevI_003D[i][j].IsFlagSet(_0023_003DzLEq8mIc_003D))
				{
					return true;
				}
			}
		}
		return false;
	}
}
