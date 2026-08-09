using System;
using System.ComponentModel;
using ns27;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class SortIndicator : Icon, ICloneable, IVisualElement, ISortIndicator
{
	private HeaderSortStyle mHeaderSortStyle = HeaderSortStyle.None;

	[DefaultValue(HeaderSortStyle.None)]
	public virtual HeaderSortStyle SortStyle
	{
		get
		{
			return mHeaderSortStyle;
		}
		set
		{
			mHeaderSortStyle = value;
			if (mHeaderSortStyle != HeaderSortStyle.Ascending)
			{
				if (mHeaderSortStyle != HeaderSortStyle.Descending)
				{
					base.Value = null;
				}
				else
				{
					base.Value = Class76.smethod_726();
				}
			}
			else
			{
				base.Value = Class76.smethod_748();
			}
		}
	}

	public SortIndicator()
	{
		AnchorArea = new AnchorArea(float.NaN, float.NaN, 0f, float.NaN, center: false, middle: true);
	}

	public SortIndicator(SortIndicator other)
		: base(other)
	{
		SortStyle = other.SortStyle;
	}

	public override object Clone()
	{
		return new SortIndicator(this);
	}
}
