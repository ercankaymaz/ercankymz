using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class FindSimilar : WorkUnit
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<List<_0023_003Dzhmln0G0_003D>> _0023_003DzHakk9KKVJNaTquf_0024Bg_003D_003D;

		public static Comparison<_0023_003Dzhmln0G0_003D> _0023_003Dz9psv4fOfrMf_WAYtLg_003D_003D;

		internal List<_0023_003Dzhmln0G0_003D> _0023_003DzdrPZyg1eUQwOwknubZpL2Y0_003D()
		{
			return new List<_0023_003Dzhmln0G0_003D>();
		}

		internal int _0023_003DzETAjO915pnjCj9krCglFxC0_003D(_0023_003Dzhmln0G0_003D _0023_003DzjbqS1qE_003D, _0023_003Dzhmln0G0_003D _0023_003Dz1v6oPQk_003D)
		{
			return _0023_003DzjbqS1qE_003D._0023_003DzPNMPkgk_003D().CompareTo(_0023_003Dz1v6oPQk_003D._0023_003DzPNMPkgk_003D());
		}
	}

	private sealed class _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D
	{
		public List<IFace> _0023_003DzInZGHXrRxrKU;

		public FindSimilar _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dz9JZgoew_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public List<_0023_003Dzhmln0G0_003D> _0023_003DzI6xkegk_003D;

		internal List<_0023_003Dzhmln0G0_003D> _0023_003DzImyailaPCZRVSZ9_lg_003D_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D, List<_0023_003Dzhmln0G0_003D> _0023_003DzO_ApCZa03h_0024O)
		{
			IFace face = _0023_003DzInZGHXrRxrKU[_0023_003Dz437_00244ak_003D];
			((Entity)face).Regen(new RegenParams(0.0, Math.PI / 3.0));
			Mesh[] tessellation = face.GetTessellation();
			Point3D refPoint = AreaAndVolume._0023_003Dz2_00247Z08V0cR3eZU8MKTsyQao_003D(tessellation);
			if (tessellation.Length != 0 && tessellation[0].Vertices.Length != 0)
			{
				AreaProperties areaProperties = new AreaProperties(refPoint);
				VolumeProperties volumeProperties = new VolumeProperties(refPoint);
				areaProperties.Add(tessellation);
				volumeProperties.Add(tessellation);
				if (volumeProperties.Centroid != null)
				{
					volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out var axisX, out var axisY, out var _, out var ix, out var iy, out var iz);
					_0023_003DzO_ApCZa03h_0024O.Add(new _0023_003Dzhmln0G0_003D(areaProperties.Area, volumeProperties.Volume, ix, iy, iz, face, new Plane(volumeProperties.Centroid, axisX, axisY), _0023_003Dz437_00244ak_003D));
				}
				else
				{
					_0023_003DzO_ApCZa03h_0024O.Add(new _0023_003Dzhmln0G0_003D(areaProperties.Area, 0.0, 0.0, 0.0, 0.0, face, new Plane(areaProperties.Centroid, tessellation[0].Normals[0]), _0023_003Dz437_00244ak_003D));
				}
			}
			_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs.TessellatingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			return _0023_003DzO_ApCZa03h_0024O;
		}

		internal void _0023_003DzKWjLAL76_0024Xb8wu9w4g_003D_003D(List<_0023_003Dzhmln0G0_003D> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzI6xkegk_003D)
			{
				_0023_003DzI6xkegk_003D.AddRange(_0023_003DzBJFJHwk_003D);
			}
		}
	}

	private readonly struct _0023_003Dzhmln0G0_003D(double _0023_003DzXWCF4rA_003D, double _0023_003DzhKcriekaIolc, double _0023_003Dz5Ex_zZ0_003D, double _0023_003DzHAesDUo_003D, double _0023_003DzQUNQSuY_003D, IFace _0023_003DznkPLPRg_003D, Plane _0023_003DzvoL_0024vmE_003D, int _0023_003DzyzK8swU_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzR8jIJ9z1fTpRicgZ5A_003D_003D = _0023_003DzXWCF4rA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzkD7J92U9tOkf5SaY3dyAXuI_003D = _0023_003DzhKcriekaIolc;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzgL02qLtD4waRZTcOjQ_003D_003D = _0023_003Dz5Ex_zZ0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzM_A3T7VgD3tvmT1i6g_003D_003D = _0023_003DzHAesDUo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double _0023_003DzOSZvv2fpe1R5cbzT5w_003D_003D = _0023_003DzQUNQSuY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly IFace _0023_003DzuNYwPxv6eW_t55BqOQ_003D_003D = _0023_003DznkPLPRg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Plane _0023_003DzgQMUNTe5_gb1_JEUaQ_003D_003D = _0023_003DzvoL_0024vmE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzU1CozGG3RwnyADLWgA_003D_003D = _0023_003DzyzK8swU_003D;

		public bool _0023_003DztRzbL4c_003D(_0023_003Dzhmln0G0_003D _0023_003DzjbqS1qE_003D, double _0023_003Dzm0CYiiE_003D)
		{
			if (Math.Abs(_0023_003DzjbqS1qE_003D._0023_003DzksHLs9UhMsNB() - _0023_003DzksHLs9UhMsNB()) > _0023_003Dzm0CYiiE_003D * Math.Abs(_0023_003DzksHLs9UhMsNB()))
			{
				return false;
			}
			if (Math.Abs(_0023_003DzjbqS1qE_003D._0023_003DzDr_8xkWkF_s05UKcBg_003D_003D() - _0023_003DzDr_8xkWkF_s05UKcBg_003D_003D()) > _0023_003Dzm0CYiiE_003D * Math.Abs(_0023_003DzDr_8xkWkF_s05UKcBg_003D_003D()))
			{
				return false;
			}
			if (Math.Abs(_0023_003DzjbqS1qE_003D._0023_003Dzml7bqbvyR93b() - _0023_003Dzml7bqbvyR93b()) > _0023_003Dzm0CYiiE_003D * Math.Abs(_0023_003Dzml7bqbvyR93b()))
			{
				return false;
			}
			if (Math.Abs(_0023_003DzjbqS1qE_003D._0023_003DzOK7pPvHLU1gg() - _0023_003DzOK7pPvHLU1gg()) > _0023_003Dzm0CYiiE_003D * Math.Abs(_0023_003DzOK7pPvHLU1gg()))
			{
				return false;
			}
			if (Math.Abs(_0023_003DzjbqS1qE_003D._0023_003DzHChXtNpBGose() - _0023_003DzHChXtNpBGose()) > _0023_003Dzm0CYiiE_003D * Math.Abs(_0023_003DzHChXtNpBGose()))
			{
				return false;
			}
			return true;
		}

		private double _0023_003DzksHLs9UhMsNB()
		{
			return _0023_003DzR8jIJ9z1fTpRicgZ5A_003D_003D;
		}

		private double _0023_003DzDr_8xkWkF_s05UKcBg_003D_003D()
		{
			return _0023_003DzkD7J92U9tOkf5SaY3dyAXuI_003D;
		}

		private double _0023_003Dzml7bqbvyR93b()
		{
			return _0023_003DzgL02qLtD4waRZTcOjQ_003D_003D;
		}

		private double _0023_003DzOK7pPvHLU1gg()
		{
			return _0023_003DzM_A3T7VgD3tvmT1i6g_003D_003D;
		}

		private double _0023_003DzHChXtNpBGose()
		{
			return _0023_003DzOSZvv2fpe1R5cbzT5w_003D_003D;
		}

		public IFace _0023_003DzhI4GfEqgBFkL()
		{
			return _0023_003DzuNYwPxv6eW_t55BqOQ_003D_003D;
		}

		public Plane _0023_003DzkLi1exYxb484()
		{
			return _0023_003DzgQMUNTe5_gb1_JEUaQ_003D_003D;
		}

		public int _0023_003DzPNMPkgk_003D()
		{
			return _0023_003DzU1CozGG3RwnyADLWgA_003D_003D;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz4nI07T8VdBPX9l8XKm0j5fMZ4WchG0WxLg_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985993);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzCeaf5HhWXcLnAAMLJOfwsFOocSpl = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986239);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz2T3CNzUHGWX87f1VEXIROJP219p9 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986196);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private (Entity[], Block[], IFace[][], Dictionary<IFace, Transformation>) _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzzFtHFMBITLhdT0ySbQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly EntityList _0023_003Dzr5aJ_0024sMkorzi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IFace _0023_003DziPwo0GU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dz0_0024oFP_0024Rtz5fqXZ1DXwtnRPQ_003D;

	public string TessellatingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz4nI07T8VdBPX9l8XKm0j5fMZ4WchG0WxLg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz4nI07T8VdBPX9l8XKm0j5fMZ4WchG0WxLg_003D_003D = value;
		}
	}

	public string ComparingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCeaf5HhWXcLnAAMLJOfwsFOocSpl;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCeaf5HhWXcLnAAMLJOfwsFOocSpl = value;
		}
	}

	public string RebuildingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2T3CNzUHGWX87f1VEXIROJP219p9;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz2T3CNzUHGWX87f1VEXIROJP219p9 = value;
		}
	}

	public (Entity[] Entities, Block[] Blocks, IFace[][] GroupedObjects, Dictionary<IFace, Transformation> OriginalEntityToTransformation) Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
		private set
		{
			_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = value;
		}
	}

	public FindSimilar(EntityList entityList, double tolerance, bool detectReflections = false)
	{
		_0023_003Dzr5aJ_0024sMkorzi = entityList;
		_0023_003DzzFtHFMBITLhdT0ySbQ_003D_003D = tolerance;
		_0023_003Dz0_0024oFP_0024Rtz5fqXZ1DXwtnRPQ_003D = detectReflections;
	}

	public FindSimilar(IFace reference, EntityList entityList, double tolerance, bool detectReflections = false)
	{
		_0023_003DziPwo0GU_003D = reference;
		_0023_003Dzr5aJ_0024sMkorzi = entityList;
		_0023_003DzzFtHFMBITLhdT0ySbQ_003D_003D = tolerance;
		_0023_003Dz0_0024oFP_0024Rtz5fqXZ1DXwtnRPQ_003D = detectReflections;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D CS_0024_003C_003E8__locals34 = new _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D();
		CS_0024_003C_003E8__locals34._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals34._0023_003DzmHS7frs_003D = progress;
		CS_0024_003C_003E8__locals34._0023_003Dzjvn7P10_003D = ct;
		bool flag = _0023_003DziPwo0GU_003D != null;
		CS_0024_003C_003E8__locals34._0023_003DzInZGHXrRxrKU = new List<IFace>(_0023_003Dzr5aJ_0024sMkorzi.Count);
		Dictionary<IFace, IFace> dictionary = new Dictionary<IFace, IFace>();
		foreach (Entity item2 in _0023_003Dzr5aJ_0024sMkorzi)
		{
			if (item2 is IFace face)
			{
				IFace face2 = (IFace)face.Clone();
				CS_0024_003C_003E8__locals34._0023_003DzInZGHXrRxrKU.Add(face2);
				dictionary[face2] = face;
			}
		}
		CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D = new List<_0023_003Dzhmln0G0_003D>(_0023_003Dzr5aJ_0024sMkorzi.Count);
		if (flag)
		{
			IFace face3 = (IFace)_0023_003DziPwo0GU_003D.Clone();
			dictionary[face3] = _0023_003DziPwo0GU_003D;
			((Entity)face3).Regen(new RegenParams(0.0, Math.PI / 3.0));
			Mesh[] tessellation = face3.GetTessellation();
			Point3D refPoint = AreaAndVolume._0023_003Dz2_00247Z08V0cR3eZU8MKTsyQao_003D(tessellation);
			if (tessellation.Length != 0 && tessellation[0].Vertices.Length != 0)
			{
				AreaProperties areaProperties = new AreaProperties(refPoint);
				VolumeProperties volumeProperties = new VolumeProperties(refPoint);
				areaProperties.Add(tessellation);
				volumeProperties.Add(tessellation);
				if (volumeProperties.Centroid != null)
				{
					volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out var axisX, out var axisY, out var _, out var ix, out var iy, out var iz);
					CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D.Add(new _0023_003Dzhmln0G0_003D(areaProperties.Area, volumeProperties.Volume, ix, iy, iz, face3, new Plane(volumeProperties.Centroid, axisX, axisY), 0));
				}
				else
				{
					CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D.Add(new _0023_003Dzhmln0G0_003D(areaProperties.Area, 0.0, 0.0, 0.0, 0.0, face3, new Plane(areaProperties.Centroid, tessellation[0].Normals[0]), 0));
				}
			}
		}
		CS_0024_003C_003E8__locals34._0023_003Dz9JZgoew_003D = CS_0024_003C_003E8__locals34._0023_003DzInZGHXrRxrKU.Count;
		Parallel.For(0, CS_0024_003C_003E8__locals34._0023_003Dz9JZgoew_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzdrPZyg1eUQwOwknubZpL2Y0_003D, CS_0024_003C_003E8__locals34._0023_003DzImyailaPCZRVSZ9_lg_003D_003D, delegate(List<_0023_003Dzhmln0G0_003D> _0023_003DzBJFJHwk_003D)
		{
			lock (CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D)
			{
				CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D.AddRange(_0023_003DzBJFJHwk_003D);
			}
		});
		CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D.Sort(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzETAjO915pnjCj9krCglFxC0_003D);
		CS_0024_003C_003E8__locals34._0023_003Dz9JZgoew_003D = (flag ? 1 : CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D.Count);
		bool[] array = new bool[CS_0024_003C_003E8__locals34._0023_003Dz9JZgoew_003D];
		List<(List<IFace>, List<Transformation>)> list = new List<(List<IFace>, List<Transformation>)>();
		for (int num = 0; num < CS_0024_003C_003E8__locals34._0023_003Dz9JZgoew_003D; num++)
		{
			if (array[num])
			{
				continue;
			}
			array[num] = true;
			List<IFace> list2 = new List<IFace>();
			List<Transformation> list3 = new List<Transformation>();
			if (!flag)
			{
				list2.Add(CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num]._0023_003DzhI4GfEqgBFkL());
				list3.Add(Transformation.CreateAlignment(CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num]._0023_003DzkLi1exYxb484(), Plane.XY));
			}
			for (int num2 = num + 1; num2 < CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D.Count; num2++)
			{
				if ((!flag && array[num2]) || !CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num2]._0023_003DztRzbL4c_003D(CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num], _0023_003DzzFtHFMBITLhdT0ySbQ_003D_003D))
				{
					continue;
				}
				double _0023_003DzwlDnrC3hQeOe;
				Transformation item = _0023_003DzSG1F4hiMZj5CpHh69uaiJOoii1PG(CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num]._0023_003DzhI4GfEqgBFkL(), CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num]._0023_003DzkLi1exYxb484(), CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num2]._0023_003DzhI4GfEqgBFkL(), CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num2]._0023_003DzkLi1exYxb484(), _0023_003Dz0_0024oFP_0024Rtz5fqXZ1DXwtnRPQ_003D, out _0023_003DzwlDnrC3hQeOe);
				if (_0023_003DzwlDnrC3hQeOe < _0023_003DzzFtHFMBITLhdT0ySbQ_003D_003D)
				{
					list2.Add(CS_0024_003C_003E8__locals34._0023_003DzI6xkegk_003D[num2]._0023_003DzhI4GfEqgBFkL());
					list3.Add(item);
					if (!flag)
					{
						array[num2] = true;
					}
				}
			}
			if (list2.Count > 0)
			{
				list.Add((list2, list3));
			}
			if (!UpdateProgressAndCheckCancelled(num, CS_0024_003C_003E8__locals34._0023_003Dz9JZgoew_003D, ComparingText, CS_0024_003C_003E8__locals34._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals34._0023_003Dzjvn7P10_003D))
			{
				return;
			}
		}
		IFace[][] array2 = new IFace[list.Count][];
		List<Block> list4 = new List<Block>();
		List<Entity> list5 = new List<Entity>();
		Dictionary<IFace, Transformation> dictionary2 = new Dictionary<IFace, Transformation>();
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			array2[num3] = list[num3].Item1.ToArray();
			IFace face4 = (IFace)list[num3].Item1[0].Clone();
			Transformation transformation = list[num3].Item2[0];
			((Entity)face4).TransformBy(list[num3].Item2[0]);
			transformation.Invert();
			Block block = new Block(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986184) + num3);
			block.Entities.Add((Entity)face4);
			list4.Add(block);
			BlockReference blockReference = new BlockReference(block.Name);
			blockReference.Transformation = transformation;
			list5.Add(blockReference);
			dictionary2[dictionary[list[num3].Item1[0]]] = Transformation.CreateIdentity();
			for (int num4 = 1; num4 < list[num3].Item1.Count; num4++)
			{
				BlockReference blockReference2 = new BlockReference(block.Name);
				blockReference2.Transformation = list[num3].Item2[num4] * transformation;
				list5.Add(blockReference2);
				Transformation transformation2 = list[num3].Item2[num4];
				transformation2.Invert();
				dictionary2[dictionary[list[num3].Item1[num4]]] = transformation2;
			}
			if (!UpdateProgressAndCheckCancelled(num3, list.Count, RebuildingText, CS_0024_003C_003E8__locals34._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals34._0023_003Dzjvn7P10_003D))
			{
				return;
			}
		}
		Result = (list5.ToArray(), list4.ToArray(), array2, dictionary2);
	}

	private static Transformation _0023_003DzSG1F4hiMZj5CpHh69uaiJOoii1PG(IFace _0023_003DzP_0024uVfv6jlIju, Plane _0023_003DzGXulVTYtJ1yP, IFace _0023_003Dz_00248SqoBPTgPYq, Plane _0023_003DzR9AUADpuUeni, bool _0023_003DzG1YYGbIUKLkyBWTPbm9UiLQ_003D, out double _0023_003DzwlDnrC3hQeOe)
	{
		_0023_003Dz_00248SqoBPTgPYq.GetTightBBox(out var boxMin, out var boxMax);
		Point3D origin = _0023_003DzR9AUADpuUeni.Origin;
		Vector3D axisX = _0023_003DzR9AUADpuUeni.AxisX;
		Vector3D axisY = _0023_003DzR9AUADpuUeni.AxisY;
		List<Transformation> list = new List<Transformation>
		{
			Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, axisX, axisY)),
			Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, -1.0 * axisX, axisY)),
			Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, axisX, -1.0 * axisY)),
			Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, -1.0 * axisX, -1.0 * axisY))
		};
		if (_0023_003DzG1YYGbIUKLkyBWTPbm9UiLQ_003D)
		{
			list.AddRange(new Transformation[4]
			{
				Transformation.CreateReflection(new Plane(origin, axisX, axisY)) * Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, axisX, axisY)),
				Transformation.CreateReflection(new Plane(origin, axisX, axisY)) * Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, -1.0 * axisX, axisY)),
				Transformation.CreateReflection(new Plane(origin, axisX, axisY)) * Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, axisX, -1.0 * axisY)),
				Transformation.CreateReflection(new Plane(origin, axisX, axisY)) * Transformation.CreateAlignment(_0023_003DzGXulVTYtJ1yP, new Plane(origin, -1.0 * axisX, -1.0 * axisY))
			});
		}
		double diagonal = new Size3D(boxMin, boxMax).Diagonal;
		_0023_003DzwlDnrC3hQeOe = double.MaxValue;
		Transformation result = Transformation.CreateIdentity();
		foreach (Transformation item in list)
		{
			IFace obj = (IFace)_0023_003DzP_0024uVfv6jlIju.Clone();
			((Entity)obj).TransformBy(item);
			obj.GetTightBBox(out var boxMin2, out var boxMax2);
			double num = (Point3D.Distance(boxMin, boxMin2) + Point3D.Distance(boxMax, boxMax2)) / diagonal;
			if (num < _0023_003DzwlDnrC3hQeOe)
			{
				_0023_003DzwlDnrC3hQeOe = num;
				result = item;
			}
		}
		return result;
	}
}
