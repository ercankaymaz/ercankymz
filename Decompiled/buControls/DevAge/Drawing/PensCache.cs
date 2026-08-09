using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DevAge.Drawing;

public class PensCache : IDisposable
{
	private struct Struct31 : IEquatable<Struct31>
	{
		public Color color_0;

		public DashStyle dashStyle_0;

		public float float_0;

		bool IEquatable<Struct31>.Equals(Struct31 other)
		{
			return other.color_0 == color_0 && other.dashStyle_0 == dashStyle_0 && other.float_0 == float_0;
		}
	}

	private Pen[] pen_0;

	private Struct31[] struct31_0;

	private List<Pen> list_0 = new List<Pen>();

	public PensCache(int maxCapacity)
	{
		pen_0 = new Pen[maxCapacity];
		struct31_0 = new Struct31[maxCapacity];
	}

	public Pen GetPen(Color color, float width, DashStyle style)
	{
		Struct31 @struct = default(Struct31);
		@struct.color_0 = color;
		@struct.float_0 = width;
		@struct.dashStyle_0 = style;
		for (int i = 0; i < pen_0.Length; i++)
		{
			if (pen_0[i] != null)
			{
				if (struct31_0[i].System_002EIEquatable_003CDevAge_002EDrawing_002EPensCache_002EStruct31_003E_002EEquals(@struct))
				{
					return pen_0[i];
				}
				continue;
			}
			Pen pen = new Pen(color, width);
			if (pen.DashStyle != style)
			{
				pen.DashStyle = style;
			}
			pen_0[i] = pen;
			struct31_0[i] = @struct;
			return pen;
		}
		Pen pen2 = new Pen(color, width);
		if (pen2.DashStyle != style)
		{
			pen2.DashStyle = style;
		}
		list_0.Add(pen2);
		return pen2;
	}

	public void Dispose()
	{
		for (int i = 0; i < pen_0.Length; i++)
		{
			if (pen_0[i] != null)
			{
				pen_0[i].Dispose();
				pen_0[i] = null;
			}
		}
		foreach (Pen item in list_0)
		{
			item.Dispose();
		}
	}
}
