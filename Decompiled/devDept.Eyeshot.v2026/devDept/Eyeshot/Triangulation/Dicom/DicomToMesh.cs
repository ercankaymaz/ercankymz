using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Geometry;

namespace devDept.Eyeshot.Triangulation.Dicom;

public class DicomToMesh : DicomToMeshBase<byte>
{
	private sealed class _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D
	{
		public DicomToMesh _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		internal void _0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			((IodElement)_0023_003DzopRx0_MBcTQs._0023_003DzyBU2Gv8_003D[_0023_003Dz437_00244ak_003D]).BuildHounsfieldValues();
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003DzopRx0_MBcTQs._0023_003DzyBU2Gv8_003D.Count, _0023_003DzopRx0_MBcTQs.ProgressBarTextLoadHounsfieldValues, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	private sealed class _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D
	{
		public DicomToMesh _0023_003DzopRx0_MBcTQs;

		public ScalarField3D _0023_003Dz743TWCo_003D;

		internal void _0023_003Dz_00246uQotdONA_0024NfDrTnA_003D_003D(int _0023_003DzN6G05Lg_003D)
		{
			for (int i = 0; i < _0023_003DzopRx0_MBcTQs.nCellsInY; i++)
			{
				for (int j = 0; j < _0023_003DzopRx0_MBcTQs.nCellsInX; j++)
				{
					_0023_003DzopRx0_MBcTQs.grid[j, i, _0023_003DzN6G05Lg_003D] = _0023_003Dz743TWCo_003D(j, i, _0023_003DzN6G05Lg_003D);
				}
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzyEhs4rIeMtwm3waYaLnvr1qEbIH_nt1rx8wjv7s_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302901891);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IList<DicomElement> _0023_003DzyBU2Gv8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzQE8mGNolLVelVeVMVw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzCNEqtBaIZFtnRAAgxQ_003D_003D;

	public string ProgressBarTextLoadHounsfieldValues
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyEhs4rIeMtwm3waYaLnvr1qEbIH_nt1rx8wjv7s_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzyEhs4rIeMtwm3waYaLnvr1qEbIH_nt1rx8wjv7s_003D = value;
		}
	}

	public DicomToMesh(IList<DicomElement> elements, Point3D gridOrigin, int nCellsInX, int nCellsInY, int nCellsInZ, ScalarField3D func = null)
		: base((string[])null, gridOrigin, nCellsInX, 1f, nCellsInY, 1f, nCellsInZ, 1f, func)
	{
		if (elements == null || elements.Count == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902632));
		}
		_0023_003DzyBU2Gv8_003D = elements;
		IodElement iodElement = (IodElement)_0023_003DzyBU2Gv8_003D[0];
		iodElement.GetPixelSpacing(out var rowSpace, out var columnSpace);
		cellSizeX = columnSpace;
		cellSizeY = rowSpace;
		cellSizeZ = iodElement.GetSliceThickness();
		_0023_003DzQE8mGNolLVelVeVMVw_003D_003D = iodElement.SliceInfo.ImageUpperLeftX;
		_0023_003DzCNEqtBaIZFtnRAAgxQ_003D_003D = iodElement.SliceInfo.ImageUpperLeftY;
	}

	internal DicomToMesh(IList<PictureData<byte>> _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D, Point3D _0023_003Dz3ijbSgnOxISJ, int _0023_003DziWDHn0dVy5_0024n, int _0023_003DzqJYD1Vq7IWy5, int _0023_003DzrF0bGvFIf5CP, float _0023_003DzagtSq6MBP1AK, ScalarField3D _0023_003Dz743TWCo_003D = null)
		: base((string[])null, _0023_003Dz3ijbSgnOxISJ, _0023_003DziWDHn0dVy5_0024n, 1f, _0023_003DzqJYD1Vq7IWy5, 1f, _0023_003DzrF0bGvFIf5CP, _0023_003DzagtSq6MBP1AK, _0023_003Dz743TWCo_003D)
	{
		base.Pictures = new PictureData<byte>[_0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D.Count];
		for (int i = 0; i < _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D.Count; i++)
		{
			base.Pictures[i] = _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D[i];
		}
	}

	internal DicomToMesh(string[] _0023_003Dz2qXSinRGaUKs, Point3D _0023_003Dz3ijbSgnOxISJ, int _0023_003DziWDHn0dVy5_0024n, float _0023_003DztuDJZuExk1RK, int _0023_003DzqJYD1Vq7IWy5, float _0023_003DzJuoTBl1_pG4N, int _0023_003DzrF0bGvFIf5CP, float _0023_003DzagtSq6MBP1AK, ScalarField3D _0023_003Dz743TWCo_003D)
		: base(_0023_003Dz2qXSinRGaUKs, _0023_003Dz3ijbSgnOxISJ, _0023_003DziWDHn0dVy5_0024n, _0023_003DztuDJZuExk1RK, _0023_003DzqJYD1Vq7IWy5, _0023_003DzJuoTBl1_pG4N, _0023_003DzrF0bGvFIf5CP, _0023_003DzagtSq6MBP1AK, _0023_003Dz743TWCo_003D)
	{
	}

	protected override void ComputeCoords(int column, int row, int z, double[,] coords)
	{
		if (_0023_003DzyBU2Gv8_003D == null)
		{
			base.ComputeCoords(column, row, z, coords);
			return;
		}
		CtSliceInfo sliceInfo = ((IodElement)_0023_003DzyBU2Gv8_003D[z]).SliceInfo;
		CtSliceInfo sliceInfo2 = ((IodElement)_0023_003DzyBU2Gv8_003D[z + 1]).SliceInfo;
		double x = gridOrigin.X;
		double num = _0023_003DzQE8mGNolLVelVeVMVw_003D_003D + ((double)column + x) * (double)sliceInfo.PixelSpacingColumn;
		double num2 = num + (double)sliceInfo.PixelSpacingColumn;
		double num3 = _0023_003DzQE8mGNolLVelVeVMVw_003D_003D + ((double)column + x) * (double)sliceInfo2.PixelSpacingColumn;
		double num4 = num3 + (double)sliceInfo2.PixelSpacingColumn;
		double y = gridOrigin.Y;
		double num5 = _0023_003DzCNEqtBaIZFtnRAAgxQ_003D_003D - ((double)row + y) * (double)sliceInfo.PixelSpacingRow;
		double num6 = num5 - (double)sliceInfo.PixelSpacingRow;
		double num7 = _0023_003DzCNEqtBaIZFtnRAAgxQ_003D_003D - ((double)row + y) * (double)sliceInfo2.PixelSpacingRow;
		double num8 = num7 - (double)sliceInfo2.PixelSpacingRow;
		double imageUpperLeftZ = sliceInfo.ImageUpperLeftZ;
		double imageUpperLeftZ2 = sliceInfo2.ImageUpperLeftZ;
		coords[0, 0] = num;
		coords[0, 1] = num6;
		coords[0, 2] = imageUpperLeftZ;
		coords[1, 0] = num2;
		coords[1, 1] = num6;
		coords[1, 2] = imageUpperLeftZ;
		coords[2, 0] = num4;
		coords[2, 1] = num5;
		coords[2, 2] = imageUpperLeftZ;
		coords[3, 0] = num3;
		coords[3, 1] = num5;
		coords[3, 2] = imageUpperLeftZ;
		coords[4, 0] = num;
		coords[4, 1] = num8;
		coords[4, 2] = imageUpperLeftZ2;
		coords[5, 0] = num2;
		coords[5, 1] = num8;
		coords[5, 2] = imageUpperLeftZ2;
		coords[6, 0] = num4;
		coords[6, 1] = num7;
		coords[6, 2] = imageUpperLeftZ2;
		coords[7, 0] = num3;
		coords[7, 1] = num7;
		coords[7, 2] = imageUpperLeftZ2;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2 = new _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D();
		_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003DzmHS7frs_003D = progress;
		_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003Dzjvn7P10_003D = ct;
		if ((_0023_003DzyBU2Gv8_003D == null || _0023_003DzyBU2Gv8_003D.Count != 0) && (base.Pictures == null || base.Pictures.Length != 0))
		{
			if (_0023_003DzyBU2Gv8_003D != null)
			{
				int count = _0023_003DzyBU2Gv8_003D.Count;
				maxIndexForConvolution = ((IodElement)_0023_003DzyBU2Gv8_003D[0]).GetColumns();
				ResetProgressParallel();
				Parallel.For(0, count, _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D);
			}
			if (!Cancelled(_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003Dzjvn7P10_003D))
			{
				base.DoWork(_0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003DzmHS7frs_003D, _0023_003Dz8mybn_0024HH6k9Kg_0024V6LvUCctI_003D2._0023_003Dzjvn7P10_003D);
			}
		}
	}

	protected override void FillGrid(ScalarField3D func)
	{
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D CS_0024_003C_003E8__locals6 = new _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D();
		CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals6._0023_003Dz743TWCo_003D = func;
		Parallel.For(0, nCellsInZ, delegate(int _0023_003DzN6G05Lg_003D)
		{
			for (int i = 0; i < CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs.nCellsInY; i++)
			{
				for (int j = 0; j < CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs.nCellsInX; j++)
				{
					CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs.grid[j, i, _0023_003DzN6G05Lg_003D] = CS_0024_003C_003E8__locals6._0023_003Dz743TWCo_003D(j, i, _0023_003DzN6G05Lg_003D);
				}
			}
		});
	}

	protected override float myScalarField(float x1, float y1, float z1)
	{
		if (_0023_003DzyBU2Gv8_003D == null)
		{
			return (int)base.Pictures[(int)(z1 / cellSizeZ)].Pixels[(int)x1, (int)y1];
		}
		IodElement obj = (IodElement)_0023_003DzyBU2Gv8_003D[(int)z1];
		x1 += (float)gridOrigin.X;
		y1 += (float)gridOrigin.Y;
		_ = base.GaussFilter;
		return obj.GetHounsfieldPixelValue((int)y1, (int)x1);
	}
}
