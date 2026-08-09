using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using devDept.Geometry;

namespace devDept.Eyeshot.Triangulation.Dicom;

public class BitmapsToMesh : DicomToMesh
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IList<Bitmap> _0023_003DzgbGkbyk_003D;

	public BitmapsToMesh(IList<Bitmap> images, Point3D gridOrigin, float cellSizeZ)
		: base(null, gridOrigin, images[0].Width, 1f, images[0].Height, 1f, images.Count, cellSizeZ, null)
	{
		if (images == null || images.Count == 0)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602220));
		}
		_0023_003DzgbGkbyk_003D = images;
	}

	private void _0023_003Dz7Uf_0024UcN_0024FsZs1jXGIQ_003D_003D(IProgress<ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, CancellationToken _0023_003DzkIE5Tx8_003D)
	{
		if (base.Pictures != null || _0023_003DzgbGkbyk_003D == null || _0023_003DzgbGkbyk_003D.Count == 0)
		{
			return;
		}
		int width = _0023_003DzgbGkbyk_003D[0].Width;
		int height = _0023_003DzgbGkbyk_003D[0].Height;
		base.Pictures = new PictureData<byte>[_0023_003DzgbGkbyk_003D.Count];
		for (int i = 0; i < _0023_003DzgbGkbyk_003D.Count; i++)
		{
			LockBitmap lockBitmap = new LockBitmap(_0023_003DzgbGkbyk_003D[i]);
			lockBitmap.LockBits();
			if (lockBitmap.Width != width || lockBitmap.Height != height)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601499));
			}
			PictureData<byte> pictureData = new PictureData<byte>(width, height);
			for (int j = 0; j < lockBitmap.Width; j++)
			{
				for (int k = 0; k < lockBitmap.Height; k++)
				{
					pictureData.Pixels[j, k] = lockBitmap.GetPixel(j, k).R;
				}
			}
			lockBitmap.UnlockBits();
			base.Pictures[i] = pictureData;
			if (!UpdateProgressAndCheckCancelled(i, _0023_003DzgbGkbyk_003D.Count, base.LoadingFilesText, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D))
			{
				base.Pictures = null;
				break;
			}
		}
		UpdateProgressTo100(base.LoadingFilesText, _0023_003DzIIIDz8c_003D);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		if (base.Pictures == null || base.Pictures.Length != 0)
		{
			_0023_003Dz7Uf_0024UcN_0024FsZs1jXGIQ_003D_003D(progress, ct);
			base.DoWork(progress, ct);
		}
	}
}
