using System;
using DSTV.Net.Contracts;

namespace DSTV.Net.Implementations;

internal class DotSplitter : ISplitter
{
	internal static Lazy<DotSplitter> Instance = new Lazy<DotSplitter>(() => new DotSplitter());

	public string[] Split(string input)
	{
		int[] array = new int[3];
		for (int i = 0; i < 3; i++)
		{
			int num = 0;
			if (i > 0)
			{
				num = array[i - 1];
			}
			array[i] = input.IndexOf('.', num + 1);
		}
		string[] array2 = new string[3];
		for (int j = 0; j < 3; j++)
		{
			array2[j] = input.Substring(array[j] - 4, array[j] + 2);
		}
		return array2;
	}
}
