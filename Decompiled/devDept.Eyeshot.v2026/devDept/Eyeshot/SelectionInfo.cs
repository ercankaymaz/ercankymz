using devDept.Geometry;

namespace devDept.Eyeshot;

public struct SelectionInfo
{
	internal selectionStatusType _selectionStatus;

	public bool Selected
	{
		get
		{
			return IsSelected();
		}
		set
		{
			SetSelection(value);
		}
	}

	public void SetFlag(selectionStatusType flag)
	{
		FlagsHelper.Set(ref _selectionStatus, flag);
	}

	public void InvertFlag(selectionStatusType flag)
	{
		FlagsHelper.Invert(ref _selectionStatus, flag);
	}

	public bool IsFlagSet(selectionStatusType flag)
	{
		return FlagsHelper.IsSet(_selectionStatus, flag);
	}

	public void UnsetFlag(selectionStatusType flag)
	{
		FlagsHelper.Unset(ref _selectionStatus, flag);
	}

	public bool IsSelected()
	{
		return _selectionStatus != selectionStatusType.None;
	}

	internal void SetSelection(bool _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D)
		{
			FlagsHelper.Set(ref _selectionStatus, selectionStatusType.Permanent);
		}
		else
		{
			_selectionStatus = selectionStatusType.None;
		}
	}

	internal static selectionStatusType GetSelectionFlag(bool _0023_003DztZ8cUOvTIMcH)
	{
		if (!_0023_003DztZ8cUOvTIMcH)
		{
			return selectionStatusType.Permanent;
		}
		return selectionStatusType.Temporary;
	}
}
