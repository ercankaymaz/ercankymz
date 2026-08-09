using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

internal sealed class _0023_003Dzx6HzsKM5jJwBHivt6uyLQh7_hGNbkML2r9jG1Qi7196P
{
	[DllImport("user32.dll", EntryPoint = "OpenClipboard")]
	private static extern bool _0023_003DzoWIbYXCILtCK(IntPtr _0023_003Dz1Xdv6Rx4koBj);

	[DllImport("user32.dll", EntryPoint = "EmptyClipboard")]
	private static extern bool _0023_003Dzbb_5yl_uwWIa();

	[DllImport("user32.dll", EntryPoint = "SetClipboardData")]
	private static extern IntPtr _0023_003Dz1cCGJ7_0024j_uEh(uint _0023_003DzHOIZ4SY_003D, IntPtr _0023_003DzCU0iINc_003D);

	[DllImport("user32.dll", EntryPoint = "CloseClipboard")]
	private static extern bool _0023_003DzPBll9GXRLAgG();

	[DllImport("gdi32.dll", EntryPoint = "CopyEnhMetaFile")]
	private static extern IntPtr _0023_003Dz2QN7j_0024nrv0CJfedrsA_003D_003D(IntPtr _0023_003Dzkx3Y6uHXq8Ai, IntPtr _0023_003DzHeySwdw_003D);

	[DllImport("gdi32.dll", EntryPoint = "DeleteEnhMetaFile")]
	private static extern bool _0023_003DzqC_0024E1FoGubuOJB97Vw_003D_003D(IntPtr _0023_003Dzgqb4qbS4GBxq);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetClipboardData", ExactSpelling = true)]
	private static extern IntPtr _0023_003DzEvqAgla2oVAh(uint _0023_003DzyTdq_VY_003D);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "IsClipboardFormatAvailable", ExactSpelling = true)]
	private static extern bool _0023_003Dz5HB_v0N_0024wopd(uint _0023_003DzyTdq_VY_003D);

	public static bool _0023_003Dzpsu_R_rE40EtpTmxvcjNosUfJq7E(IntPtr _0023_003DzVg1BG_0024g_003D, Metafile _0023_003Dzf4PsOnE_003D)
	{
		bool result = false;
		IntPtr henhmetafile = _0023_003Dzf4PsOnE_003D.GetHenhmetafile();
		if (!henhmetafile.Equals(new IntPtr(0)))
		{
			IntPtr intPtr = _0023_003Dz2QN7j_0024nrv0CJfedrsA_003D_003D(henhmetafile, new IntPtr(0));
			if (!intPtr.Equals(new IntPtr(0)) && _0023_003DzoWIbYXCILtCK(_0023_003DzVg1BG_0024g_003D) && _0023_003Dzbb_5yl_uwWIa())
			{
				result = _0023_003Dz1cCGJ7_0024j_uEh(14u, intPtr).Equals(intPtr);
				_0023_003DzPBll9GXRLAgG();
			}
			_0023_003DzqC_0024E1FoGubuOJB97Vw_003D_003D(henhmetafile);
		}
		return result;
	}

	public static Metafile _0023_003DzKr9il5Xty0LdFzgr0e3QnlY_003D()
	{
		Metafile result = null;
		if (_0023_003DzoWIbYXCILtCK(IntPtr.Zero))
		{
			if (_0023_003Dz5HB_v0N_0024wopd(14u))
			{
				IntPtr henhmetafile = _0023_003DzEvqAgla2oVAh(14u);
				if (!henhmetafile.Equals(IntPtr.Zero))
				{
					result = new Metafile(henhmetafile, deleteEmf: true);
				}
			}
			_0023_003DzPBll9GXRLAgG();
		}
		return result;
	}

	public static Bitmap _0023_003DzSBCp98cJd2fkg_7Rzg_003D_003D()
	{
		Metafile metafile = _0023_003DzKr9il5Xty0LdFzgr0e3QnlY_003D();
		if (metafile == null)
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(metafile.Width, metafile.Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		GraphicsUnit pageUnit = GraphicsUnit.Pixel;
		RectangleF bounds = metafile.GetBounds(ref pageUnit);
		PointF[] destPoints = new PointF[3]
		{
			new PointF(0f, 0f),
			new PointF(bounds.Width, 0f),
			new PointF(0f, bounds.Height)
		};
		graphics.DrawImage(metafile, destPoints, bounds, GraphicsUnit.Pixel);
		return bitmap;
	}
}
