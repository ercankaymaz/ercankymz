#define DEBUG
using System.Diagnostics;

namespace PdfSharp.Pdf.IO;

internal static class StreamHelper
{
	public static int WSize(int[] w)
	{
		Debug.Assert(w.Length == 3);
		return w[0] + w[1] + w[2];
	}

	public static uint ReadBytes(byte[] bytes, int index, int byteCount)
	{
		uint num = 0u;
		for (int i = 0; i < byteCount; i++)
		{
			num *= 256;
			num += bytes[index + i];
		}
		return num;
	}
}
