using System;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchItemSurrogate : SurrogateWithReferenceId<SketchItem>
{
	private Id guid;

	public SketchItemSurrogate(SketchItem sketchItem)
		: base(sketchItem)
	{
	}

	private SketchItemSurrogate(int _0023_003DzN0lAKfo_003D)
		: base(_0023_003DzN0lAKfo_003D)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		return null;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		sketchItem._0023_003DzxWZ7yqG65a6T(guid);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		guid = sketchItem._0023_003DzDQs07gDx7oDr();
	}

	public static implicit operator SketchItem(SketchItemSurrogate surrogate)
	{
		SketchItem sketchItem = Serializer.GetCachedObject(surrogate) as SketchItem;
		if (sketchItem != null)
		{
			return sketchItem;
		}
		if (surrogate != null)
		{
			sketchItem = surrogate.ConvertToObject();
			Serializer.AddToCache(surrogate, sketchItem);
			if (sketchItem == null)
			{
				if (string.IsNullOrEmpty(surrogate.Log))
				{
					surrogate.WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998666) + surrogate.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
				}
				return null;
			}
		}
		return sketchItem;
	}

	public static implicit operator SketchItemSurrogate(SketchItem sketchItem)
	{
		if (sketchItem == null)
		{
			return null;
		}
		SketchItemSurrogate sketchItemSurrogate2;
		if (Serializer.GetCachedObjectWithReferenceId(sketchItem) is SketchItemSurrogate sketchItemSurrogate)
		{
			sketchItemSurrogate2 = new SketchItemSurrogate(sketchItemSurrogate.ReferenceId);
		}
		else
		{
			sketchItemSurrogate2 = sketchItem.ConvertToSurrogate();
			Serializer.AddToCache(sketchItem, sketchItemSurrogate2);
		}
		if (sketchItemSurrogate2 == null)
		{
			Type type = sketchItem.GetType();
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672644), type, type));
		}
		return sketchItemSurrogate2;
	}
}
