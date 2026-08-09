using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Content;

internal static class PageSizeExtensions
{
	private readonly struct WidthHeight
	{
		public double Width { get; }

		public double Height { get; }

		public WidthHeight(double width, double height)
		{
			Width = width;
			Height = height;
		}

		public override bool Equals(object? obj)
		{
			if (obj is WidthHeight widthHeight && Math.Round(Width) == Math.Round(widthHeight.Width))
			{
				return Math.Round(Height) == Math.Round(widthHeight.Height);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (859600377 * -1521134295 + Math.Round(Width).GetHashCode()) * -1521134295 + Math.Round(Height).GetHashCode();
		}
	}

	private static readonly Dictionary<WidthHeight, PageSize> Lookup = new Dictionary<WidthHeight, PageSize>
	{
		{
			new WidthHeight(2384.0, 3370.0),
			PageSize.A0
		},
		{
			new WidthHeight(1684.0, 2384.0),
			PageSize.A1
		},
		{
			new WidthHeight(1190.0, 1684.0),
			PageSize.A2
		},
		{
			new WidthHeight(1191.0, 1684.0),
			PageSize.A2
		},
		{
			new WidthHeight(842.0, 1190.0),
			PageSize.A3
		},
		{
			new WidthHeight(842.0, 1191.0),
			PageSize.A3
		},
		{
			new WidthHeight(595.0, 842.0),
			PageSize.A4
		},
		{
			new WidthHeight(595.0, 841.0),
			PageSize.A4
		},
		{
			new WidthHeight(420.0, 595.0),
			PageSize.A5
		},
		{
			new WidthHeight(298.0, 420.0),
			PageSize.A6
		},
		{
			new WidthHeight(210.0, 298.0),
			PageSize.A7
		},
		{
			new WidthHeight(147.0, 210.0),
			PageSize.A8
		},
		{
			new WidthHeight(105.0, 147.0),
			PageSize.A9
		},
		{
			new WidthHeight(74.0, 105.0),
			PageSize.A10
		},
		{
			new WidthHeight(612.0, 792.0),
			PageSize.Letter
		},
		{
			new WidthHeight(612.0, 1008.0),
			PageSize.Legal
		},
		{
			new WidthHeight(1224.0, 792.0),
			PageSize.Ledger
		},
		{
			new WidthHeight(792.0, 1224.0),
			PageSize.Tabloid
		},
		{
			new WidthHeight(540.0, 720.0),
			PageSize.Executive
		},
		{
			new WidthHeight(522.0, 756.0),
			PageSize.Executive
		}
	};

	public static PageSize GetPageSize(this PdfRectangle rectangle)
	{
		if (!Lookup.TryGetValue(new WidthHeight(rectangle.Width, rectangle.Height), out var value) && !Lookup.TryGetValue(new WidthHeight(rectangle.Height, rectangle.Width), out value))
		{
			return PageSize.Custom;
		}
		return value;
	}

	public static bool TryGetPdfRectangle(this PageSize size, out PdfRectangle rectangle)
	{
		rectangle = default(PdfRectangle);
		KeyValuePair<WidthHeight, PageSize> keyValuePair = Lookup.FirstOrDefault((KeyValuePair<WidthHeight, PageSize> x) => x.Value == size);
		if (keyValuePair.Key.Width > 0.0)
		{
			rectangle = new PdfRectangle(0.0, 0.0, keyValuePair.Key.Width, keyValuePair.Key.Height);
		}
		return keyValuePair.Key.Width > 0.0;
	}
}
