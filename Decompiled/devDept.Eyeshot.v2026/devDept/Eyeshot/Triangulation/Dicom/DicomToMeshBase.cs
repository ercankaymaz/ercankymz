using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Geometry;

namespace devDept.Eyeshot.Triangulation.Dicom;

public abstract class DicomToMeshBase<T> : MarchingCubes where T : struct
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzvxCiAvJ2CTXmUF6o1BH4dEs_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902581);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string[] _0023_003Dz0lzR6lOfhKpix4OBIQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PictureData<T>[] _0023_003DzR5viFmsJKML5MExt3etP9Srd2kUC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ScalarField3D _0023_003DzZ_T9BER4MiTU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzvw6quDX90_0024wr_0024zAk34Jt5m4_003D;

	protected float[] filter = new float[9] { 0.0625f, 0.125f, 0.0625f, 0.125f, 0.25f, 0.125f, 0.0625f, 0.125f, 0.0625f };

	protected int maxIndexForConvolution;

	public string LoadingFilesText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvxCiAvJ2CTXmUF6o1BH4dEs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvxCiAvJ2CTXmUF6o1BH4dEs_003D = value;
		}
	}

	protected string[] FilePaths
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0lzR6lOfhKpix4OBIQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0lzR6lOfhKpix4OBIQ_003D_003D = value;
		}
	}

	public PictureData<T>[] Pictures
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzR5viFmsJKML5MExt3etP9Srd2kUC;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzR5viFmsJKML5MExt3etP9Srd2kUC = value;
		}
	}

	public bool GaussFilter
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzvw6quDX90_0024wr_0024zAk34Jt5m4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzvw6quDX90_0024wr_0024zAk34Jt5m4_003D = value;
		}
	}

	protected DicomToMeshBase(string[] filePaths, int nCellsInX, float cellSizeX, int nCellsInY, float cellSizeY, int nCellsInZ, float cellSizeZ, ScalarField3D func)
		: this(filePaths, Point3D.Origin, nCellsInX, cellSizeX, nCellsInY, cellSizeY, nCellsInZ, cellSizeZ, func)
	{
	}

	protected DicomToMeshBase(string[] filePaths, Point3D gridOrigin, int nCellsInX, float cellSizeX, int nCellsInY, float cellSizeY, int nCellsInZ, float cellSizeZ, ScalarField3D func)
		: base(gridOrigin, nCellsInX, cellSizeX, nCellsInY, cellSizeY, nCellsInZ, cellSizeZ, null)
	{
		_0023_003DzZ_T9BER4MiTU = func;
		FilePaths = filePaths;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		if (Pictures != null)
		{
			maxIndexForConvolution = Pictures[0].Rows - 1;
		}
		if (_0023_003DzZ_T9BER4MiTU == null)
		{
			FillGrid(myScalarField);
		}
		base.DoWork(progress, ct);
	}

	protected virtual float myScalarField(float x1, float y1, float z1)
	{
		PictureData<T> pictureData = Pictures[(int)(z1 / cellSizeZ)];
		x1 /= cellSizeX;
		y1 /= cellSizeY;
		if (GaussFilter && x1 > 0f && x1 < (float)maxIndexForConvolution && y1 > 0f && y1 < (float)maxIndexForConvolution)
		{
			float num = 0f;
			int num2 = (int)(x1 + 2f);
			int num3 = (int)(y1 + 2f);
			int num4 = 0;
			for (int i = (int)(x1 - 1f); i < num2; i++)
			{
				for (int j = (int)(y1 - 1f); j < num3; j++)
				{
					object value = pictureData.Pixels[i, j];
					num += Convert.ToSingle(value) * filter[num4++];
				}
			}
			return num;
		}
		return Convert.ToSingle(pictureData.Pixels[(int)x1, (int)y1]);
	}
}
