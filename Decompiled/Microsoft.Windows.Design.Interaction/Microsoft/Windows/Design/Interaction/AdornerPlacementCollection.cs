using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MS.Internal.Interaction;

namespace Microsoft.Windows.Design.Interaction;

public class AdornerPlacementCollection : ObservableCollection<IAdornerPlacement>
{
	private Vector _topLeft;

	private Vector _size;

	internal Vector TopLeft
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _topLeft;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_topLeft = value;
		}
	}

	internal Vector Size
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _size;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_size = value;
		}
	}

	internal virtual void ComputePlacement(AdornerCoordinateSpace space, UIElement adorner, ViewItem adornedElement, Vector zoom, Size finalSize)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		using (IEnumerator<IAdornerPlacement> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IAdornerPlacement current = enumerator.Current;
				foreach (AdornerPlacementValue sizeTerm in current.GetSizeTerms(space, adorner, adornedElement, zoom, finalSize))
				{
					switch (sizeTerm.Term)
					{
					case AdornerPlacementDimension.Top:
						num += sizeTerm.Contribution;
						flag = true;
						break;
					case AdornerPlacementDimension.Bottom:
						num2 += sizeTerm.Contribution;
						flag2 = true;
						break;
					case AdornerPlacementDimension.Height:
						num3 += sizeTerm.Contribution;
						break;
					case AdornerPlacementDimension.Left:
						num4 += sizeTerm.Contribution;
						flag3 = true;
						break;
					case AdornerPlacementDimension.Right:
						num5 += sizeTerm.Contribution;
						flag3 = true;
						break;
					case AdornerPlacementDimension.Width:
						num6 += sizeTerm.Contribution;
						break;
					}
				}
			}
		}
		if (num6 < 0.0)
		{
			num6 = 0.0;
		}
		if (num3 < 0.0)
		{
			num3 = 0.0;
		}
		Size computedAdornerSize = default(Size);
		((Size)(ref computedAdornerSize))._002Ector(num6, num3);
		using (IEnumerator<IAdornerPlacement> enumerator3 = GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				IAdornerPlacement current3 = enumerator3.Current;
				foreach (AdornerPlacementValue positionTerm in current3.GetPositionTerms(space, adorner, adornedElement, zoom, computedAdornerSize))
				{
					switch (positionTerm.Term)
					{
					case AdornerPlacementDimension.Top:
						num += positionTerm.Contribution;
						flag = true;
						break;
					case AdornerPlacementDimension.Bottom:
						num2 += positionTerm.Contribution;
						flag2 = true;
						break;
					case AdornerPlacementDimension.Height:
						num3 += positionTerm.Contribution;
						break;
					case AdornerPlacementDimension.Left:
						num4 += positionTerm.Contribution;
						flag3 = true;
						break;
					case AdornerPlacementDimension.Right:
						num5 += positionTerm.Contribution;
						flag3 = true;
						break;
					case AdornerPlacementDimension.Width:
						num6 += positionTerm.Contribution;
						break;
					}
				}
			}
		}
		double num7 = 0.0;
		if (flag3 && flag4)
		{
			num7 = num5 - num4;
		}
		double num8 = 0.0;
		if (flag && flag2)
		{
			num8 = num2 - num;
		}
		double num9 = num7 + num6;
		double num10 = num8 + num3;
		if (flag4 && !flag3)
		{
			((Vector)(ref _topLeft)).X = num5 - num9;
		}
		else
		{
			((Vector)(ref _topLeft)).X = num4;
		}
		((Vector)(ref _size)).X = num9;
		if (flag2 && !flag)
		{
			((Vector)(ref _topLeft)).Y = num2 - num10;
		}
		else
		{
			((Vector)(ref _topLeft)).Y = num;
		}
		((Vector)(ref _size)).Y = num10;
	}

	public void PositionRelativeToAdornerHeight(double factor, double offset)
	{
		Add(new PositionRelativeToAdornerHeight(factor, offset, null));
	}

	public void PositionRelativeToAdornerHeight(double factor, double offset, DependencyObject relativeTo)
	{
		Add(new PositionRelativeToAdornerHeight(factor, offset, relativeTo));
	}

	public void PositionRelativeToAdornerWidth(double factor, double offset)
	{
		Add(new PositionRelativeToAdornerWidth(factor, offset, null));
	}

	public void PositionRelativeToAdornerWidth(double factor, double offset, DependencyObject relativeTo)
	{
		Add(new PositionRelativeToAdornerWidth(factor, offset, relativeTo));
	}

	public void PositionRelativeToContentHeight(double factor, double offset)
	{
		Add(new PositionRelativeToContentHeight(factor, offset, null));
	}

	public void PositionRelativeToContentHeight(double factor, double offset, ViewItem relativeTo)
	{
		Add(new PositionRelativeToContentHeight(factor, offset, relativeTo));
	}

	public void PositionRelativeToContentWidth(double factor, double offset)
	{
		Add(new PositionRelativeToContentWidth(factor, offset, null));
	}

	public void PositionRelativeToContentWidth(double factor, double offset, ViewItem relativeTo)
	{
		Add(new PositionRelativeToContentWidth(factor, offset, relativeTo));
	}

	public void SizeRelativeToAdornerDesiredHeight(double factor, double offset)
	{
		Add(new SizeRelativeToAdornerDesiredHeight(factor, offset, null));
	}

	public void SizeRelativeToAdornerDesiredHeight(double factor, double offset, DependencyObject relativeTo)
	{
		Add(new SizeRelativeToAdornerDesiredHeight(factor, offset, relativeTo));
	}

	public void SizeRelativeToAdornerDesiredWidth(double factor, double offset)
	{
		Add(new SizeRelativeToAdornerDesiredWidth(factor, offset, null));
	}

	public void SizeRelativeToAdornerDesiredWidth(double factor, double offset, DependencyObject relativeTo)
	{
		Add(new SizeRelativeToAdornerDesiredWidth(factor, offset, relativeTo));
	}

	public void SizeRelativeToContentHeight(double factor, double offset)
	{
		Add(new SizeRelativeToContentHeight(factor, offset, null));
	}

	public void SizeRelativeToContentHeight(double factor, double offset, ViewItem relativeTo)
	{
		Add(new SizeRelativeToContentHeight(factor, offset, relativeTo));
	}

	public void SizeRelativeToContentWidth(double factor, double offset)
	{
		Add(new SizeRelativeToContentWidth(factor, offset, null));
	}

	public void SizeRelativeToContentWidth(double factor, double offset, ViewItem relativeTo)
	{
		Add(new SizeRelativeToContentWidth(factor, offset, relativeTo));
	}
}
