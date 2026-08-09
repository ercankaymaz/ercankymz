using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevAge.Drawing;

public class BrushsCache : IDisposable
{
	private SolidBrush[] solidBrush_0;

	private Color[] color_0;

	private List<SolidBrush> list_0 = new List<SolidBrush>();

	public BrushsCache(int maxCapacity)
	{
		solidBrush_0 = new SolidBrush[maxCapacity];
		color_0 = new Color[maxCapacity];
	}

	public SolidBrush GetBrush(Color color)
	{
		for (int i = 0; i < solidBrush_0.Length; i++)
		{
			if (solidBrush_0[i] != null)
			{
				if (color_0[i].Equals(color))
				{
					return solidBrush_0[i];
				}
				continue;
			}
			SolidBrush solidBrush = new SolidBrush(color);
			solidBrush_0[i] = solidBrush;
			color_0[i] = color;
			return solidBrush;
		}
		SolidBrush solidBrush2 = new SolidBrush(color);
		list_0.Add(solidBrush2);
		return solidBrush2;
	}

	public void Dispose()
	{
		for (int i = 0; i < solidBrush_0.Length; i++)
		{
			if (solidBrush_0[i] != null)
			{
				solidBrush_0[i].Dispose();
				solidBrush_0[i] = null;
			}
		}
		foreach (SolidBrush item in list_0)
		{
			item.Dispose();
		}
	}
}
