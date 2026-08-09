namespace UglyToad.PdfPig.Images.Png;

internal static class Adam7
{
	private static readonly int[][] PassToScanlineGridIndex = new int[7][]
	{
		new int[1],
		new int[1],
		new int[1] { 4 },
		new int[2] { 0, 4 },
		new int[2] { 2, 6 },
		new int[4] { 0, 2, 4, 6 },
		new int[4] { 1, 3, 5, 7 }
	};

	private static readonly int[][] PassToScanlineColumnIndex = new int[7][]
	{
		new int[1],
		new int[1] { 4 },
		new int[2] { 0, 4 },
		new int[2] { 2, 6 },
		new int[4] { 0, 2, 4, 6 },
		new int[4] { 1, 3, 5, 7 },
		new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }
	};

	public static int GetNumberOfScanlinesInPass(ImageHeader header, int pass)
	{
		int[] array = PassToScanlineGridIndex[pass];
		int num = header.Height % 8;
		if (num == 0)
		{
			return array.Length * (header.Height / 8);
		}
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] < num)
			{
				num2++;
			}
		}
		return array.Length * (header.Height / 8) + num2;
	}

	public static int GetPixelsPerScanlineInPass(ImageHeader header, int pass)
	{
		int[] array = PassToScanlineColumnIndex[pass];
		int num = header.Width % 8;
		if (num == 0)
		{
			return array.Length * (header.Width / 8);
		}
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] < num)
			{
				num2++;
			}
		}
		return array.Length * (header.Width / 8) + num2;
	}

	public static (int x, int y) GetPixelIndexForScanlineInPass(ImageHeader header, int pass, int scanlineIndex, int indexInScanline)
	{
		int[] array = PassToScanlineColumnIndex[pass];
		int[] array2 = PassToScanlineGridIndex[pass];
		int num = scanlineIndex % array2.Length;
		int num2 = indexInScanline % array.Length;
		int num3 = 8 * (scanlineIndex / array2.Length);
		return (x: 8 * (indexInScanline / array.Length) + array[num2], y: num3 + array2[num]);
	}
}
