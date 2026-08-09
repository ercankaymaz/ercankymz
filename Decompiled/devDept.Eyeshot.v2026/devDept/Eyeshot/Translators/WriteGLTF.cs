using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json.Nodes;
using System.Threading;
using SharpGLTF.Geometry;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Materials;
using SharpGLTF.Memory;
using SharpGLTF.Scenes;
using SharpGLTF.Schema2;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Translators;

public class WriteGLTF : WriteFileAsyncWithUnits
{
	private delegate Vector3D[] _0023_003Dz2C_LeDy_0024YzSi(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, int _0023_003Dzrhrpp5YOKlnr);

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003DzUrowvzdsMUWC, string> _0023_003DzoXG_AO364p8d02ObVg_003D_003D;

		public static Func<List<int>, int[]> _0023_003DzeMeLyZIMA0_00242QQx15w_003D_003D;

		public static Func<byte, string> _0023_003DzCfr64VVAgICMYkoJJA_003D_003D;

		internal string _0023_003DzCV0ivOD49m_0024yUNMfYCKiNmE_003D(_0023_003DzUrowvzdsMUWC _0023_003DzUDlFc7k_003D)
		{
			return _0023_003DzUDlFc7k_003D._0023_003DzwKyKajk_003D();
		}

		internal int[] _0023_003DzdV5jcl4UvRaUvXweHoxmnQcW852_0024(List<int> _0023_003DztO_TXZ4_003D)
		{
			return _0023_003DztO_TXZ4_003D.ToArray();
		}

		internal string _0023_003Dz_d16JRdC3VVwGYUzHKJaqdA_003D(byte _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011905));
		}
	}

	private delegate IVertexGeometry[] _0023_003Dz3vyKs0dVw_X6(devDept.Eyeshot.Entities.Mesh _0023_003DzkKfJheA_003D, int _0023_003Dzl1pVl_00248_003D, _0023_003Dz2C_LeDy_0024YzSi _0023_003Dzxz9kXR937k5W);

	private delegate IVertexMaterial[] _0023_003DzA5RjDOcSOxQE(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, int _0023_003Dzrhrpp5YOKlnr);

	private delegate IVertexBuilder _0023_003DzIZCctKal0Le_bEwr_Q_003D_003D<_0023_003DzVuU4VVN5QJuZ>(IVertexGeometry _0023_003DzxhF5NTpGP9fih8fOBQ_003D_003D, _0023_003DzVuU4VVN5QJuZ _0023_003DzLgjfUxU_003D);

	private delegate devDept.Eyeshot.Entities.Mesh _0023_003DzL_j2dOZbK06e(Entity _0023_003DzVzokukk_003D);

	private static class _0023_003DzQm9ltrs_003D
	{
		public static _0023_003Dzw7hEUK_0024iS_0024DrcFbA_0024HWoWbs_003D _0023_003Dzo4ZEhkh1rzrATALzUMLDhNg_003D;

		public static _0023_003Dz2C_LeDy_0024YzSi _0023_003Dz3F1vJgj7u59Xx26yox87xKg_003D;

		public static _0023_003Dzw7hEUK_0024iS_0024DrcFbA_0024HWoWbs_003D _0023_003DzJRa3iXOJAEGPBNCbo8wahcU_003D;

		public static _0023_003Dz2C_LeDy_0024YzSi _0023_003DzDTXO3YWXQkPMYWk3IJ2zLF6ECKXPhABTug_003D_003D;
	}

	private struct _0023_003DzUrowvzdsMUWC
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003Dztp4Ps1G34YhULwwl1w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MaterialBuilder _0023_003DzLTTCOl68EoLY_rSiVw_003D_003D;

		public _0023_003DzUrowvzdsMUWC(string _0023_003DzS_00246o7tc_003D, MaterialBuilder _0023_003Dz9mQJfIk_003D)
		{
			_0023_003DzyZFnD3E_003D(_0023_003DzS_00246o7tc_003D);
			_0023_003DzZ_hvPWXg4AQG(_0023_003Dz9mQJfIk_003D);
		}

		public readonly string _0023_003DzwKyKajk_003D()
		{
			return _0023_003Dztp4Ps1G34YhULwwl1w_003D_003D;
		}

		public void _0023_003DzyZFnD3E_003D(string _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dztp4Ps1G34YhULwwl1w_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly MaterialBuilder _0023_003Dzm4_LMmM9K7Ev()
		{
			return _0023_003DzLTTCOl68EoLY_rSiVw_003D_003D;
		}

		public void _0023_003DzZ_hvPWXg4AQG(MaterialBuilder _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzLTTCOl68EoLY_rSiVw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}
	}

	private struct _0023_003DzhlzU2HC7VAhe
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color _0023_003DzjJYX40llENIzsmSbbA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Material _0023_003DzArORARoFzVQZB6K3Cw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private NodeBuilder _0023_003DzxNo5S3niYfQMYBRb_0024Q_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DztTd1rqTSplYsfoZ0Sw_003D_003D;

		public readonly Color _0023_003DzXiRgY5w_003D()
		{
			return _0023_003DzjJYX40llENIzsmSbbA_003D_003D;
		}

		public void _0023_003DzCVoJr14_003D(Color _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzjJYX40llENIzsmSbbA_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly Material _0023_003DzOu5uxdtY0kLm()
		{
			return _0023_003DzArORARoFzVQZB6K3Cw_003D_003D;
		}

		public void _0023_003DzNpqQmmwn2qu7(Material _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzArORARoFzVQZB6K3Cw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly NodeBuilder _0023_003Dzm_0024gatfg_003D()
		{
			return _0023_003DzxNo5S3niYfQMYBRb_0024Q_003D_003D;
		}

		public void _0023_003DzqEjCJIE_003D(NodeBuilder _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzxNo5S3niYfQMYBRb_0024Q_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly string _0023_003DzRcuz4cVtApX8()
		{
			return _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;
		}

		public void _0023_003DzIuJk2adNf7FQ(string _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly int _0023_003DzyGGtjaUlI5Ie()
		{
			return _0023_003DztTd1rqTSplYsfoZ0Sw_003D_003D;
		}

		public void _0023_003DzadNZQpFYKn_0024a(int _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DztTd1rqTSplYsfoZ0Sw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}
	}

	private struct _0023_003DzmfMxh0e4cDiJKzZXgQ_003D_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Color _0023_003DzjJYX40llENIzsmSbbA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Material _0023_003DzArORARoFzVQZB6K3Cw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzUrowvzdsMUWC[] _0023_003DzSXzRRP8HX0XzzSczCQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzUrowvzdsMUWC _0023_003DzZ9RYi2Inn215oRyQRajMUUk_003D;

		public readonly Color _0023_003DzXiRgY5w_003D()
		{
			return _0023_003DzjJYX40llENIzsmSbbA_003D_003D;
		}

		public void _0023_003DzCVoJr14_003D(Color _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzjJYX40llENIzsmSbbA_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly Material _0023_003DzOu5uxdtY0kLm()
		{
			return _0023_003DzArORARoFzVQZB6K3Cw_003D_003D;
		}

		public void _0023_003DzNpqQmmwn2qu7(Material _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzArORARoFzVQZB6K3Cw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly _0023_003DzUrowvzdsMUWC[] _0023_003DzbhgEWwHU_Mqh()
		{
			return _0023_003DzSXzRRP8HX0XzzSczCQ_003D_003D;
		}

		private void _0023_003DzBTFXwPhPUOsG(_0023_003DzUrowvzdsMUWC[] _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzSXzRRP8HX0XzzSczCQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public readonly _0023_003DzUrowvzdsMUWC _0023_003DzI1nmdW9KyX1U()
		{
			return _0023_003DzZ9RYi2Inn215oRyQRajMUUk_003D;
		}

		public void _0023_003DzaGbnuhXKsVXf(_0023_003DzUrowvzdsMUWC _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzZ9RYi2Inn215oRyQRajMUUk_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public void _0023_003Dzz5iLh7j_0024x7Q4(int _0023_003DzkL1pGo7T40hP1O4bLQ_003D_003D)
		{
			_0023_003DzBTFXwPhPUOsG(new _0023_003DzUrowvzdsMUWC[_0023_003DzkL1pGo7T40hP1O4bLQ_003D_003D]);
		}
	}

	[Serializable]
	private sealed class _0023_003DzppngE0coqaymG8WU7g_003D_003D<_0023_003DzcR_livAfyNz8evdJgQ_003D_003D> where _0023_003DzcR_livAfyNz8evdJgQ_003D_003D : struct, IVertexMaterial
	{
		public static readonly _0023_003DzppngE0coqaymG8WU7g_003D_003D<_0023_003DzcR_livAfyNz8evdJgQ_003D_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzppngE0coqaymG8WU7g_003D_003D<_0023_003DzcR_livAfyNz8evdJgQ_003D_003D>();

		public static _0023_003DzIZCctKal0Le_bEwr_Q_003D_003D<_0023_003DzcR_livAfyNz8evdJgQ_003D_003D> _0023_003DzaVsxLbaONs0U4dCHpw_003D_003D;

		public static _0023_003DzIZCctKal0Le_bEwr_Q_003D_003D<_0023_003DzcR_livAfyNz8evdJgQ_003D_003D> _0023_003DzujeuHAOF6HAPPscFbQ_003D_003D;

		internal IVertexBuilder _0023_003DzLLqCoTeHIrrYHkVwa_tCRG4_003D(IVertexGeometry _0023_003Dz0y8dHgRbs7n3, _0023_003DzcR_livAfyNz8evdJgQ_003D_003D _0023_003Dzmby5UeA_003D)
		{
			return new VertexBuilder<VertexPosition, _0023_003DzcR_livAfyNz8evdJgQ_003D_003D, VertexEmpty>((VertexPosition)(object)_0023_003Dz0y8dHgRbs7n3, in _0023_003Dzmby5UeA_003D);
		}

		internal IVertexBuilder _0023_003DzlnhOCUltHe8Ugd9Nz5aJPyY_003D(IVertexGeometry _0023_003Dz0y8dHgRbs7n3, _0023_003DzcR_livAfyNz8evdJgQ_003D_003D _0023_003Dzmby5UeA_003D)
		{
			return new VertexBuilder<VertexPositionNormal, _0023_003DzcR_livAfyNz8evdJgQ_003D_003D, VertexEmpty>((VertexPositionNormal)(object)_0023_003Dz0y8dHgRbs7n3, in _0023_003Dzmby5UeA_003D);
		}
	}

	private sealed class _0023_003DzsN_nEjUorwlthw4Jbg_003D_003D : IEqualityComparer<string[]>
	{
		[Serializable]
		private sealed class _0023_003Dz2IEmqow_003D
		{
			public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

			public static Func<int, string, int> _0023_003DzMZhMJpobUKPB_0024vgkIg_003D_003D;

			internal int _0023_003DzCO10JgCKV75DqETPKlED1vg_003D(int _0023_003Dzi6_5x7g_003D, string _0023_003DzPzO_0024GUk_003D)
			{
				return _0023_003Dzi6_5x7g_003D * 31 + _0023_003DzPzO_0024GUk_003D.GetHashCode();
			}
		}

		public bool Equals(string[] _0023_003DzBJFJHwk_003D, string[] _0023_003Dz40R7bAU_003D)
		{
			return _0023_003DzBJFJHwk_003D.SequenceEqual(_0023_003Dz40R7bAU_003D);
		}

		public int GetHashCode(string[] _0023_003DzCX9Hbao_003D)
		{
			return _0023_003DzCX9Hbao_003D.Aggregate(17, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzCO10JgCKV75DqETPKlED1vg_003D);
		}
	}

	private delegate(MaterialBuilder[], int[][]) _0023_003Dzw7hEUK_0024iS_0024DrcFbA_0024HWoWbs_003D(IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D);

	private sealed class _0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D
	{
		public WriteGLTF _0023_003DzopRx0_MBcTQs;

		public _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ;

		internal devDept.Eyeshot.Entities.Mesh _0023_003DzJovbRSERigl2gQ9okA_003D_003D(Entity _0023_003DzGb8kdyZ1x5nj)
		{
			return ((Brep)_0023_003DzGb8kdyZ1x5nj).ConvertToMesh(_0023_003DzopRx0_MBcTQs.Deviation, _0023_003DzopRx0_MBcTQs.Angle, devDept.Eyeshot.Entities.Mesh.natureType.RichSmooth, weldNow: true, 0.0, _0023_003DzopRx0_MBcTQs._0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D, _0023_003DzopRx0_MBcTQs.units);
		}

		internal devDept.Eyeshot.Entities.Mesh _0023_003Dz8CgIYLh6GEfnhVpu5g_003D_003D(Entity _0023_003DzGb8kdyZ1x5nj)
		{
			return ((Brep)_0023_003DzGb8kdyZ1x5nj).ConvertToMesh(_0023_003DzopRx0_MBcTQs.Deviation, _0023_003DzopRx0_MBcTQs.Angle);
		}

		internal devDept.Eyeshot.Entities.Mesh _0023_003DzTSCQJ6o_J01E90lQVA_003D_003D(Entity _0023_003DzGb8kdyZ1x5nj)
		{
			return ((Brep)_0023_003DzGb8kdyZ1x5nj).ConvertToMesh(_0023_003DzopRx0_MBcTQs.Deviation, _0023_003DzopRx0_MBcTQs.Angle, devDept.Eyeshot.Entities.Mesh.natureType.ColorSmooth, weldNow: true, 0.0, null, linearUnitsType.Unitless, _0023_003DzGb8kdyZ1x5nj.GetColor(_0023_003DzopRx0_MBcTQs.layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D()));
		}

		internal devDept.Eyeshot.Entities.Mesh _0023_003DzEmQsG00SfAvrazCLLQ_003D_003D(Entity _0023_003DzKBncRpw_003D)
		{
			return ((Surface)_0023_003DzKBncRpw_003D).ConvertToMesh(_0023_003DzopRx0_MBcTQs.Deviation, _0023_003DzopRx0_MBcTQs.Angle, devDept.Eyeshot.Entities.Mesh.natureType.RichSmooth, skipEdges: true);
		}

		internal devDept.Eyeshot.Entities.Mesh _0023_003Dzy6lFCq7kyBLV_0024VDc_A_003D_003D(Entity _0023_003DzKBncRpw_003D)
		{
			return ((Surface)_0023_003DzKBncRpw_003D).ConvertToMesh(_0023_003DzopRx0_MBcTQs.Deviation, _0023_003DzopRx0_MBcTQs.Angle);
		}

		internal devDept.Eyeshot.Entities.Mesh _0023_003DzLf4OiOwSmrQbXn_0024pTg_003D_003D(Entity _0023_003DzKBncRpw_003D)
		{
			return ((Surface)_0023_003DzKBncRpw_003D)._0023_003Dz5dGcIxd3bgq7(_0023_003DzopRx0_MBcTQs.Deviation, _0023_003DzopRx0_MBcTQs.Angle, devDept.Eyeshot.Entities.Mesh.natureType.ColorSmooth, _0023_003DzTJ4ZjnpzOkzX: false, _0023_003DzKBncRpw_003D.GetColor(_0023_003DzopRx0_MBcTQs.layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D()));
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private edgeColorMethodType? _0023_003DzvxcEeqDXAITAIk_0024Nk6wAKIo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color? _0023_003DzzX5tT_VmvelesHUIqQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzbaGG9So_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SceneBuilder _0023_003DzZKE2D9_mY7b5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationToken _0023_003DzEBehidw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzN0vDvhm_0024kanu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DznUCOO0w5pQz3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzKwHEm1JCYReB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzpuglt4GLehBSDx15lLfhQFOqq6ll = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011916);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, Dictionary<string[], IMeshBuilder<MaterialBuilder>>[]> _0023_003DzGMJ4w6zkHuIO = new Dictionary<string, Dictionary<string[], IMeshBuilder<MaterialBuilder>>[]>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, MaterialBuilder> _0023_003Dzpj_0024d4QqV_bCo36UM3A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Color _0023_003Dzf73gtRvDKK46 = Color.Black;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public edgeColorMethodType? EdgeColorMethodType
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvxcEeqDXAITAIk_0024Nk6wAKIo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvxcEeqDXAITAIk_0024Nk6wAKIo_003D = value;
		}
	}

	public Color? EdgeColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzzX5tT_VmvelesHUIqQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzzX5tT_VmvelesHUIqQ_003D_003D = value;
		}
	}

	public string WritingMaterials
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzpuglt4GLehBSDx15lLfhQFOqq6ll;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzpuglt4GLehBSDx15lLfhQFOqq6ll = value;
		}
	}

	public WriteGLTF(Document document, string filePath, bool selectedOnly = false, bool binary = true, double deviation = 0.0)
		: base(document, filePath, selectedOnly)
	{
		_0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(document);
		_0023_003DzbaGG9So_003D = binary;
		base.Deviation = deviation;
	}

	public WriteGLTF(Document document, Stream stream, bool selectedOnly = false, double deviation = 0.0)
		: base(document, stream, selectedOnly)
	{
		_0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(document);
		_0023_003DzbaGG9So_003D = true;
		base.Deviation = deviation;
	}

	public WriteGLTF(IWorkspace workspace, string filePath, bool selectedOnly = false, bool binary = true, double deviation = 0.0)
		: this(workspace.Document, filePath, selectedOnly, binary, deviation)
	{
	}

	public WriteGLTF(IWorkspace workspace, Stream stream, bool selectedOnly = false, double deviation = 0.0)
		: this(workspace.Document, stream, selectedOnly, deviation)
	{
	}

	public WriteGLTF(WriteParamsWithMaterials writeParams, string filePath, bool binary = true, double deviation = 0.0)
		: base(writeParams, filePath)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
		_0023_003DzbaGG9So_003D = binary;
		base.Deviation = deviation;
	}

	public WriteGLTF(WriteParamsWithMaterials writeParams, Stream stream, double deviation = 0.0)
		: base(writeParams, stream)
	{
		_0023_003DzFbxKPRlUPcpd(writeParams);
		_0023_003DzbaGG9So_003D = true;
		base.Deviation = deviation;
	}

	private void _0023_003DzY0NfqR_0024ntDrYAcwHmw_003D_003D(Document _0023_003DzoPlwCJA_003D)
	{
		if (_0023_003DzoPlwCJA_003D is DesignDocument designDocument)
		{
			_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D = designDocument.Materials;
		}
	}

	private void _0023_003DzFbxKPRlUPcpd(WriteParamsWithMaterials _0023_003DzX6XgSWkagNXc)
	{
		_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D = _0023_003DzX6XgSWkagNXc.Materials;
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D(ref _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzvkMwsvrYFLKc(progress, ct);
	}

	private void _0023_003DzvkMwsvrYFLKc(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzN0vDvhm_0024kanu = Color.Empty;
		if (EdgeColorMethodType.HasValue && EdgeColor.HasValue)
		{
			edgeColorMethodType? edgeColorMethodType2 = EdgeColorMethodType;
			if ((edgeColorMethodType2.GetValueOrDefault() == edgeColorMethodType.SingleColor) & edgeColorMethodType2.HasValue)
			{
				_0023_003DzN0vDvhm_0024kanu = EdgeColor.Value;
			}
		}
		_0023_003DzZKE2D9_mY7b5 = new SceneBuilder();
		_0023_003DzsWnj47U_003D = _0023_003DzmHS7frs_003D;
		_0023_003DzEBehidw_003D = _0023_003Dzjvn7P10_003D;
		if (!_0023_003DzVl7tXIsdDYzvHnFo2w_003D_003D() || !_0023_003Dz7_ykq_0024M_003D())
		{
			return;
		}
		StartContinuousAnimation(base.WritingText, _0023_003DzmHS7frs_003D);
		SceneBuilderSchema2Settings settings = new SceneBuilderSchema2Settings
		{
			CompactVertexWeights = true,
			UseStridedBuffers = true,
			GpuMeshInstancingMinCount = 2
		};
		ModelRoot modelRoot = _0023_003DzZKE2D9_mY7b5.ToGltf2(settings);
		if (_0023_003DzbaGG9So_003D)
		{
			if (base.Stream != null)
			{
				modelRoot.WriteGLB(base.Stream);
			}
			else
			{
				modelRoot.SaveGLB(base.FilePath);
			}
		}
		else
		{
			modelRoot.SaveGLTF(base.FilePath);
		}
		StopContinuousAnimation(_0023_003DzmHS7frs_003D);
		CloseStream();
	}

	private void _0023_003Dzn_328qi_ojwq(Block _0023_003DzSXqTc_00245giMaP)
	{
		foreach (Entity entity in _0023_003DzSXqTc_00245giMaP.Entities)
		{
			_0023_003DzKwHEm1JCYReB++;
			if (entity is BlockReference blockReference)
			{
				_0023_003Dzn_328qi_ojwq(blocks[blockReference.BlockName]);
			}
		}
	}

	private JsonNode _0023_003DzXbewlysMNQ5ZykuLlA_003D_003D(object _0023_003DzXywfrJw_003D)
	{
		if (_0023_003DzXywfrJw_003D != null)
		{
			try
			{
				return JsonNode.Parse(_0023_003DzXywfrJw_003D.ToString());
			}
			catch (Exception)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011877));
			}
		}
		return null;
	}

	private void _0023_003DzTeTjKNmal_0024uo(Entity _0023_003Dz9j7EUB0_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ, out _0023_003DzmfMxh0e4cDiJKzZXgQ_003D_003D _0023_003Dz_CCvZ_00247gWIj3)
	{
		_0023_003Dz_CCvZ_00247gWIj3 = default(_0023_003DzmfMxh0e4cDiJKzZXgQ_003D_003D);
		_0023_003Dz_CCvZ_00247gWIj3._0023_003DzCVoJr14_003D(_0023_003Dz9j7EUB0_003D.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D()));
		Material material = _0023_003Dz9j7EUB0_003D.GetMaterial(_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D, layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzOu5uxdtY0kLm());
		if (!(_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Mesh { MeshNature: var meshNature } mesh))
		{
			if (_0023_003Dz9j7EUB0_003D is FastPointCloud || _0023_003Dz9j7EUB0_003D is Hatch || _0023_003Dz9j7EUB0_003D is Picture || _0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Point || _0023_003Dz9j7EUB0_003D is PointCloud || _0023_003Dz9j7EUB0_003D is SketchEntity || _0023_003Dz9j7EUB0_003D is ICurve)
			{
				_0023_003Dz_CCvZ_00247gWIj3._0023_003Dzz5iLh7j_0024x7Q4(1);
				MaterialBuilder _0023_003Dz9mQJfIk_003D;
				string _0023_003DzS_00246o7tc_003D;
				if (material == null)
				{
					(_0023_003Dz9mQJfIk_003D, _0023_003DzS_00246o7tc_003D) = _0023_003DzV_mGEKk_003D(_0023_003Dz_CCvZ_00247gWIj3._0023_003DzXiRgY5w_003D());
				}
				else
				{
					_0023_003Dz9mQJfIk_003D = _0023_003DzV_mGEKk_003D(material);
					_0023_003DzS_00246o7tc_003D = material.Name;
				}
				_0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh()[0] = new _0023_003DzUrowvzdsMUWC(_0023_003DzS_00246o7tc_003D, _0023_003Dz9mQJfIk_003D);
			}
			else
			{
				_0023_003Dz_CCvZ_00247gWIj3._0023_003Dzz5iLh7j_0024x7Q4(1);
				var (_0023_003Dz9mQJfIk_003D, _0023_003DzS_00246o7tc_003D) = _0023_003DzV_mGEKk_003D(ControlData.DefaultMaterialShaded.Diffuse);
				_0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh()[0] = new _0023_003DzUrowvzdsMUWC(_0023_003DzS_00246o7tc_003D, _0023_003Dz9mQJfIk_003D);
			}
			return;
		}
		Color[] array;
		if (meshNature == devDept.Eyeshot.Entities.Mesh.natureType.ColorPlain || meshNature == devDept.Eyeshot.Entities.Mesh.natureType.ColorSmooth)
		{
			_0023_003Dz_CCvZ_00247gWIj3._0023_003Dzz5iLh7j_0024x7Q4(mesh.Triangles.Length);
			array = new Color[mesh.Triangles.Length];
			for (int i = 0; i < mesh.Triangles.Length; i++)
			{
				ITriangleSupportsColor triangleSupportsColor = (ITriangleSupportsColor)mesh.Triangles[i];
				array[i] = Color.FromArgb(triangleSupportsColor.R, triangleSupportsColor.G, triangleSupportsColor.B);
			}
		}
		else
		{
			_0023_003Dz_CCvZ_00247gWIj3._0023_003Dzz5iLh7j_0024x7Q4(1);
			array = new Color[1] { _0023_003Dz_CCvZ_00247gWIj3._0023_003DzXiRgY5w_003D() };
		}
		if (material == null)
		{
			for (int j = 0; j < array.Length; j++)
			{
				var (_0023_003Dz9mQJfIk_003D, _0023_003DzS_00246o7tc_003D) = _0023_003DzV_mGEKk_003D(array[j]);
				_0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh()[j] = new _0023_003DzUrowvzdsMUWC(_0023_003DzS_00246o7tc_003D, _0023_003Dz9mQJfIk_003D);
			}
		}
		else
		{
			MaterialBuilder _0023_003Dz9mQJfIk_003D = _0023_003DzV_mGEKk_003D(material);
			string _0023_003DzS_00246o7tc_003D = material.Name;
			_0023_003Dz_CCvZ_00247gWIj3._0023_003DzNpqQmmwn2qu7(material);
			_0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh()[0] = new _0023_003DzUrowvzdsMUWC(_0023_003DzS_00246o7tc_003D, _0023_003Dz9mQJfIk_003D);
		}
		if (!_0023_003DzN0vDvhm_0024kanu.IsEmpty && mesh.Edges != null)
		{
			var (_0023_003Dz9mQJfIk_003D2, _0023_003DzS_00246o7tc_003D2) = _0023_003DzV_mGEKk_003D(_0023_003DzN0vDvhm_0024kanu);
			_0023_003Dz_CCvZ_00247gWIj3._0023_003DzaGbnuhXKsVXf(new _0023_003DzUrowvzdsMUWC(_0023_003DzS_00246o7tc_003D2, _0023_003Dz9mQJfIk_003D2));
		}
	}

	private bool _0023_003DzVl7tXIsdDYzvHnFo2w_003D_003D()
	{
		_0023_003Dzpj_0024d4QqV_bCo36UM3A_003D_003D = new Dictionary<string, MaterialBuilder>();
		for (int i = 0; i < _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D.Count; i++)
		{
			_0023_003DzV_mGEKk_003D(_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D[i]);
			if (!UpdateProgressAndCheckCancelled(i, _0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D.Count, WritingMaterials, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
			{
				return false;
			}
		}
		return true;
	}

	internal (MaterialBuilder, string) _0023_003DzV_mGEKk_003D(Color _0023_003Dz1MMYB1g_003D)
	{
		string text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011973), _0023_003Dz1MMYB1g_003D.A, _0023_003Dz1MMYB1g_003D.R, _0023_003Dz1MMYB1g_003D.G, _0023_003Dz1MMYB1g_003D.B);
		if (_0023_003Dzpj_0024d4QqV_bCo36UM3A_003D_003D.TryGetValue(text, out var value))
		{
			return (value, text);
		}
		float x = (float)(int)_0023_003Dz1MMYB1g_003D.R / 255f;
		float y = (float)(int)_0023_003Dz1MMYB1g_003D.G / 255f;
		float z = (float)(int)_0023_003Dz1MMYB1g_003D.B / 255f;
		float num = (float)(int)_0023_003Dz1MMYB1g_003D.A / 255f;
		value = new MaterialBuilder(text).WithMetallicRoughness(1f, 0.8f).WithBaseColor(new Vector4(x, y, z, num)).WithDoubleSide(enabled: true);
		if ((double)Math.Abs(num - 1f) > Utility._0023_003Dzjyaz_Vfaky9X)
		{
			value = value.WithAlpha(SharpGLTF.Materials.AlphaMode.BLEND, num);
		}
		return (value, text);
	}

	internal MaterialBuilder _0023_003DzV_mGEKk_003D(Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D)
	{
		if (_0023_003Dzpj_0024d4QqV_bCo36UM3A_003D_003D.TryGetValue(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Name, out var value))
		{
			return value;
		}
		Utility.ColorToFloatArray(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Ambient);
		float[] array = Utility.ColorToFloatArray(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Diffuse);
		Utility.ColorToFloatArray(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Specular);
		float value2 = ((_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Environment > 0.5f) ? 1f : 0f);
		float value3 = (float)(1.66 * Math.Log10(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Shininess + 1f));
		value = new MaterialBuilder(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Name).WithMetallicRoughness(value2, value3).WithBaseColor(new Vector4(array[0], array[1], array[2], array[3])).WithDoubleSide(enabled: true);
		if ((double)Math.Abs(array[3] - 1f) > Utility._0023_003Dzjyaz_Vfaky9X)
		{
			value = value.WithAlpha(SharpGLTF.Materials.AlphaMode.BLEND, array[3]);
		}
		if (_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.TextureImage != null)
		{
			value = value.WithChannelImage(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004683), new MemoryImage(Utility._0023_003DzhcaSq4WPuiVgYw2C0Q_003D_003D(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.TextureImage)));
		}
		return value;
	}

	private bool _0023_003Dz7_ykq_0024M_003D()
	{
		Block block = null;
		if (entities.Count == 0 && blocks != null && blocks.hasRootBlock)
		{
			block = blocks.RootBlock;
		}
		else
		{
			block = new Block(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012694));
			block.Entities.AddRange(GetEntities());
		}
		_0023_003Dzn_328qi_ojwq(block);
		NodeBuilder _0023_003DzPzO_0024GUk_003D = new NodeBuilder(block.Name)
		{
			WorldMatrix = new Matrix4x4(1f, 0f, 0f, 0f, 0f, 0f, -1f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 1f)
		};
		_0023_003DzhlzU2HC7VAhe _0023_003DzhlzU2HC7VAhe2 = default(_0023_003DzhlzU2HC7VAhe);
		_0023_003DzhlzU2HC7VAhe2._0023_003DzCVoJr14_003D(_0023_003Dzf73gtRvDKK46);
		_0023_003DzhlzU2HC7VAhe2._0023_003DzNpqQmmwn2qu7(ControlData.DefaultMaterialShaded);
		_0023_003DzhlzU2HC7VAhe2._0023_003DzqEjCJIE_003D(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ = _0023_003DzhlzU2HC7VAhe2;
		return _0023_003Dzn6LzguI_003D(block, _0023_003DzG5DrMVi4EvFJ);
	}

	private bool _0023_003Dzn6LzguI_003D(Block _0023_003DzSXqTc_00245giMaP, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		_0023_003DzG5DrMVi4EvFJ._0023_003DzadNZQpFYKn_0024a(0);
		while (_0023_003DzG5DrMVi4EvFJ._0023_003DzyGGtjaUlI5Ie() < _0023_003DzSXqTc_00245giMaP.Entities.Count)
		{
			Entity entity = _0023_003DzSXqTc_00245giMaP.Entities[_0023_003DzG5DrMVi4EvFJ._0023_003DzyGGtjaUlI5Ie()];
			if (!_0023_003Dz5v26jTE_003D(entity, _0023_003DzG5DrMVi4EvFJ, entity.EntityData))
			{
				return false;
			}
			int num = _0023_003DzG5DrMVi4EvFJ._0023_003DzyGGtjaUlI5Ie();
			_0023_003DzG5DrMVi4EvFJ._0023_003DzadNZQpFYKn_0024a(num + 1);
		}
		return true;
	}

	private bool _0023_003DzEHGkIgIG5GjR(Entity _0023_003Dz9j7EUB0_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ, out IMeshBuilder<MaterialBuilder> _0023_003DzkLlgFX_0024C8yiB, out _0023_003DzmfMxh0e4cDiJKzZXgQ_003D_003D _0023_003Dz_CCvZ_00247gWIj3)
	{
		_0023_003DzkLlgFX_0024C8yiB = null;
		_0023_003DzTeTjKNmal_0024uo(_0023_003Dz9j7EUB0_003D, _0023_003DzG5DrMVi4EvFJ, out _0023_003Dz_CCvZ_00247gWIj3);
		if (_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8() != null && _0023_003DzGMJ4w6zkHuIO.TryGetValue(_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8(), out var value) && _0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh() != null && _0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh().Length != 0)
		{
			string[] key = (from _0023_003DzUDlFc7k_003D in _0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh()
				select _0023_003DzUDlFc7k_003D._0023_003DzwKyKajk_003D()).ToArray();
			if (value[_0023_003DzG5DrMVi4EvFJ._0023_003DzyGGtjaUlI5Ie()].TryGetValue(key, out _0023_003DzkLlgFX_0024C8yiB))
			{
				return true;
			}
		}
		return false;
	}

	private void _0023_003DzuskKQkc1Gz_w(_0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ, IMeshBuilder<MaterialBuilder> _0023_003DzkLlgFX_0024C8yiB, _0023_003DzmfMxh0e4cDiJKzZXgQ_003D_003D _0023_003Dz_CCvZ_00247gWIj3)
	{
		if (_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8() == null)
		{
			return;
		}
		if (!_0023_003DzGMJ4w6zkHuIO.ContainsKey(_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8()))
		{
			_0023_003DzGMJ4w6zkHuIO[_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8()] = new Dictionary<string[], IMeshBuilder<MaterialBuilder>>[blocks[_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8()].Entities.Count];
			for (int i = 0; i < _0023_003DzGMJ4w6zkHuIO[_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8()].Length; i++)
			{
				_0023_003DzGMJ4w6zkHuIO[_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8()][i] = new Dictionary<string[], IMeshBuilder<MaterialBuilder>>(new _0023_003DzsN_nEjUorwlthw4Jbg_003D_003D());
			}
		}
		if (_0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh() != null)
		{
			string[] array = new string[_0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh().Length];
			for (int j = 0; j < _0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh().Length; j++)
			{
				array[j] = _0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh()[j]._0023_003DzwKyKajk_003D();
				_0023_003Dzpj_0024d4QqV_bCo36UM3A_003D_003D[array[j]] = _0023_003Dz_CCvZ_00247gWIj3._0023_003DzbhgEWwHU_Mqh()[j]._0023_003Dzm4_LMmM9K7Ev();
			}
			_0023_003DzGMJ4w6zkHuIO[_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8()][_0023_003DzG5DrMVi4EvFJ._0023_003DzyGGtjaUlI5Ie()][array] = _0023_003DzkLlgFX_0024C8yiB;
		}
	}

	private bool _0023_003Dz5v26jTE_003D(Entity _0023_003Dz9j7EUB0_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ, object _0023_003DzUpNcQcY_003D)
	{
		_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D CS_0024_003C_003E8__locals28 = new _0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D();
		CS_0024_003C_003E8__locals28._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ = _0023_003DzG5DrMVi4EvFJ;
		if (!_0023_003DzEHGkIgIG5GjR(_0023_003Dz9j7EUB0_003D, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ, out var _0023_003DzkLlgFX_0024C8yiB, out var _0023_003Dz_CCvZ_00247gWIj))
		{
			if (!(_0023_003Dz9j7EUB0_003D is BlockReference _0023_003Dzcoe2_tewkWc))
			{
				if (!(_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D))
				{
					if (!(_0023_003Dz9j7EUB0_003D is SimulationStock) && !(_0023_003Dz9j7EUB0_003D is FastMesh) && !(_0023_003Dz9j7EUB0_003D is Quad) && !(_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Region) && !(_0023_003Dz9j7EUB0_003D is Solid) && !(_0023_003Dz9j7EUB0_003D is Triangle))
					{
						if (!(_0023_003Dz9j7EUB0_003D is Bar) && !(_0023_003Dz9j7EUB0_003D is Joint))
						{
							if (!(_0023_003Dz9j7EUB0_003D is FemMesh _0023_003DzQEO9PnHahyH))
							{
								if (!(_0023_003Dz9j7EUB0_003D is Brep))
								{
									if (!(_0023_003Dz9j7EUB0_003D is Surface))
									{
										if (!(_0023_003Dz9j7EUB0_003D is FastPointCloud _0023_003DzbYcdR1c_003D))
										{
											if (!(_0023_003Dz9j7EUB0_003D is Hatch _0023_003Dz1L3TZOcNA99t))
											{
												if (!(_0023_003Dz9j7EUB0_003D is Picture _0023_003DzKvpyqV4_003D))
												{
													if (!(_0023_003Dz9j7EUB0_003D is devDept.Eyeshot.Entities.Point _0023_003DzMlCq3wk_003D))
													{
														if (!(_0023_003Dz9j7EUB0_003D is PointCloud _0023_003Dzifq_QG8_003D))
														{
															if (!(_0023_003Dz9j7EUB0_003D is SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D))
															{
																if (_0023_003Dz9j7EUB0_003D is ICurve)
																{
																	_0023_003DzkLlgFX_0024C8yiB = _0023_003DzPFJt9Ij8Nt_0024U(_0023_003Dz9j7EUB0_003D, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
																}
																else
																{
																	log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012703) + _0023_003Dz9j7EUB0_003D.GetType().Name);
																}
															}
															else
															{
																_0023_003DzkLlgFX_0024C8yiB = _0023_003Dz0N5el4sM8Z8X3oHJ6A_003D_003D(_0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
															}
														}
														else
														{
															_0023_003DzkLlgFX_0024C8yiB = _0023_003DzKmKa_0wwPyT3(_0023_003Dzifq_QG8_003D, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
														}
													}
													else
													{
														_0023_003DzkLlgFX_0024C8yiB = _0023_003DzkahHEnc_003D(_0023_003DzMlCq3wk_003D, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
													}
												}
												else
												{
													_0023_003DzkLlgFX_0024C8yiB = _0023_003Dz9tJ7VyU_003D(_0023_003DzKvpyqV4_003D, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
												}
											}
											else
											{
												_0023_003DzkLlgFX_0024C8yiB = _0023_003DzuCNxjOQ_003D(_0023_003Dz1L3TZOcNA99t, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
											}
										}
										else
										{
											_0023_003DzkLlgFX_0024C8yiB = _0023_003DzYndQWHnEFUCn(_0023_003DzbYcdR1c_003D, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
										}
									}
									else
									{
										_0023_003DzS1B26tMvoaUN(_0023_003Dz9j7EUB0_003D, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ, CS_0024_003C_003E8__locals28._0023_003DzEmQsG00SfAvrazCLLQ_003D_003D, (Entity _0023_003DzKBncRpw_003D) => ((Surface)_0023_003DzKBncRpw_003D).ConvertToMesh(CS_0024_003C_003E8__locals28._0023_003DzopRx0_MBcTQs.Deviation, CS_0024_003C_003E8__locals28._0023_003DzopRx0_MBcTQs.Angle), (Entity _0023_003DzKBncRpw_003D) => ((Surface)_0023_003DzKBncRpw_003D)._0023_003Dz5dGcIxd3bgq7(CS_0024_003C_003E8__locals28._0023_003DzopRx0_MBcTQs.Deviation, CS_0024_003C_003E8__locals28._0023_003DzopRx0_MBcTQs.Angle, devDept.Eyeshot.Entities.Mesh.natureType.ColorSmooth, _0023_003DzTJ4ZjnpzOkzX: false, _0023_003DzKBncRpw_003D.GetColor(CS_0024_003C_003E8__locals28._0023_003DzopRx0_MBcTQs.layers, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D())));
									}
								}
								else
								{
									_0023_003DzS1B26tMvoaUN(_0023_003Dz9j7EUB0_003D, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ, CS_0024_003C_003E8__locals28._0023_003DzJovbRSERigl2gQ9okA_003D_003D, CS_0024_003C_003E8__locals28._0023_003Dz8CgIYLh6GEfnhVpu5g_003D_003D, CS_0024_003C_003E8__locals28._0023_003DzTSCQJ6o_J01E90lQVA_003D_003D);
								}
							}
							else
							{
								_0023_003DzDdHflxP7053E(_0023_003DzQEO9PnHahyH, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
							}
						}
						else
						{
							devDept.Eyeshot.Entities.Mesh mesh = ((IFace)_0023_003Dz9j7EUB0_003D).ConvertToMesh(base.Deviation, base.Angle, devDept.Eyeshot.Entities.Mesh.natureType.Plain, weld: false);
							mesh.EdgeStyle = devDept.Eyeshot.Entities.Mesh.edgeStyleType.None;
							_0023_003Dz5v26jTE_003D(mesh, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ, _0023_003Dz9j7EUB0_003D.EntityData);
						}
					}
					else
					{
						devDept.Eyeshot.Entities.Mesh _0023_003Dz9j7EUB0_003D2 = ((IFace)_0023_003Dz9j7EUB0_003D).ConvertToMesh(base.Deviation, base.Angle, devDept.Eyeshot.Entities.Mesh.natureType.Plain, weld: false);
						_0023_003Dz5v26jTE_003D(_0023_003Dz9j7EUB0_003D2, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ, _0023_003Dz9j7EUB0_003D.EntityData);
					}
				}
				else
				{
					_0023_003DzkLlgFX_0024C8yiB = _0023_003DzWVBcT8U_003D(_0023_003DzGGJSiQk_003D, _0023_003Dz_CCvZ_00247gWIj._0023_003DzbhgEWwHU_Mqh(), _0023_003Dz_CCvZ_00247gWIj._0023_003DzI1nmdW9KyX1U(), _0023_003Dz_CCvZ_00247gWIj);
				}
			}
			else
			{
				_0023_003DzGTfiW9ud4IIY(_0023_003Dzcoe2_tewkWc, CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ);
			}
		}
		if (_0023_003DzkLlgFX_0024C8yiB != null)
		{
			JsonNode jsonNode = _0023_003DzXbewlysMNQ5ZykuLlA_003D_003D(_0023_003DzUpNcQcY_003D);
			if (jsonNode != null)
			{
				_0023_003DzkLlgFX_0024C8yiB.Extras = jsonNode;
			}
			NodeBuilder nodeBuilder = new NodeBuilder();
			if (_0023_003Dz9j7EUB0_003D.TranslationID != null && !string.IsNullOrEmpty(_0023_003Dz9j7EUB0_003D.TranslationID.Name))
			{
				nodeBuilder.Name = _0023_003Dz9j7EUB0_003D.TranslationID.Name;
				_0023_003DzkLlgFX_0024C8yiB.Name = _0023_003Dz9j7EUB0_003D.TranslationID.Name;
			}
			_0023_003DzZKE2D9_mY7b5.AddRigidMesh(_0023_003DzkLlgFX_0024C8yiB, nodeBuilder);
			CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ._0023_003Dzm_0024gatfg_003D().AddNode(nodeBuilder);
			_0023_003DzuskKQkc1Gz_w(CS_0024_003C_003E8__locals28._0023_003DzG5DrMVi4EvFJ, _0023_003DzkLlgFX_0024C8yiB, _0023_003Dz_CCvZ_00247gWIj);
		}
		if (!UpdateProgressAndCheckCancelled(++_0023_003DznUCOO0w5pQz3, _0023_003DzKwHEm1JCYReB, base.ComposingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
		{
			return false;
		}
		return true;
	}

	private void _0023_003DzGTfiW9ud4IIY(BlockReference _0023_003Dzcoe2_tewkWc6, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		_ = base.Deviation;
		NodeBuilder nodeBuilder = new NodeBuilder(_0023_003Dzcoe2_tewkWc6.BlockName);
		JsonNode jsonNode = _0023_003DzXbewlysMNQ5ZykuLlA_003D_003D(_0023_003Dzcoe2_tewkWc6.EntityData);
		if (jsonNode != null)
		{
			nodeBuilder.Extras = jsonNode;
		}
		float[] matrixAsVectorFloatByColumn = _0023_003Dzcoe2_tewkWc6.GetFullTransformation(blocks).MatrixAsVectorFloatByColumn;
		nodeBuilder.WorldMatrix = new Matrix4x4(matrixAsVectorFloatByColumn[0], matrixAsVectorFloatByColumn[1], matrixAsVectorFloatByColumn[2], matrixAsVectorFloatByColumn[3], matrixAsVectorFloatByColumn[4], matrixAsVectorFloatByColumn[5], matrixAsVectorFloatByColumn[6], matrixAsVectorFloatByColumn[7], matrixAsVectorFloatByColumn[8], matrixAsVectorFloatByColumn[9], matrixAsVectorFloatByColumn[10], matrixAsVectorFloatByColumn[11], matrixAsVectorFloatByColumn[12], matrixAsVectorFloatByColumn[13], matrixAsVectorFloatByColumn[14], matrixAsVectorFloatByColumn[15]);
		_0023_003DzG5DrMVi4EvFJ._0023_003Dzm_0024gatfg_003D().AddNode(nodeBuilder);
		Material material = _0023_003Dzcoe2_tewkWc6.GetMaterial(_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D, layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzOu5uxdtY0kLm());
		Color color = _0023_003Dzcoe2_tewkWc6.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D());
		_0023_003DzhlzU2HC7VAhe _0023_003DzhlzU2HC7VAhe2 = default(_0023_003DzhlzU2HC7VAhe);
		_0023_003DzhlzU2HC7VAhe2._0023_003DzIuJk2adNf7FQ(_0023_003Dzcoe2_tewkWc6.BlockName);
		_0023_003DzhlzU2HC7VAhe2._0023_003DzCVoJr14_003D(color);
		_0023_003DzhlzU2HC7VAhe2._0023_003DzNpqQmmwn2qu7(material);
		_0023_003DzhlzU2HC7VAhe2._0023_003DzqEjCJIE_003D(nodeBuilder);
		_0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ2 = _0023_003DzhlzU2HC7VAhe2;
		_0023_003Dzn6LzguI_003D(blocks[_0023_003Dzcoe2_tewkWc6.BlockName], _0023_003DzG5DrMVi4EvFJ2);
	}

	private static (MaterialBuilder[], int[][]) _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D(IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D)
	{
		return (new MaterialBuilder[1] { _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev() }, new int[1][] { Enumerable.Range(0, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Length).ToArray() });
	}

	private static (MaterialBuilder[], int[][]) _0023_003DzmOvYCsqz8OYgr061BA_003D_003D(IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D)
	{
		List<MaterialBuilder> list = new List<MaterialBuilder>(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D.Length);
		Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();
		for (int i = 0; i < _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D.Length; i++)
		{
			_0023_003DzUrowvzdsMUWC _0023_003DzUrowvzdsMUWC2 = _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[i];
			if (!dictionary.ContainsKey(_0023_003DzUrowvzdsMUWC2._0023_003DzwKyKajk_003D()))
			{
				dictionary[_0023_003DzUrowvzdsMUWC2._0023_003DzwKyKajk_003D()] = new List<int>(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Length);
				list.Add(_0023_003DzUrowvzdsMUWC2._0023_003Dzm4_LMmM9K7Ev());
			}
			dictionary[_0023_003DzUrowvzdsMUWC2._0023_003DzwKyKajk_003D()].Add(i);
		}
		return (list.ToArray(), dictionary.Values.Select((List<int> _0023_003DztO_TXZ4_003D) => _0023_003DztO_TXZ4_003D.ToArray()).ToArray());
	}

	private static Vector3D[] _0023_003DzPocP_0024A_0024TRyV341hrbA_003D_003D(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, int _0023_003Dzrhrpp5YOKlnr)
	{
		Vector3D vector3D = _0023_003DzGGJSiQk_003D.Normals[_0023_003Dzrhrpp5YOKlnr];
		return new Vector3D[3] { vector3D, vector3D, vector3D };
	}

	private static Vector3D[] _0023_003DziWphL_mX5aiZWTUtCR_ZWzLBP5QK(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, int _0023_003Dzrhrpp5YOKlnr)
	{
		SmoothTriangle smoothTriangle = (SmoothTriangle)_0023_003DzGGJSiQk_003D.Triangles[_0023_003Dzrhrpp5YOKlnr];
		return new Vector3D[3]
		{
			_0023_003DzGGJSiQk_003D.Normals[smoothTriangle.N1],
			_0023_003DzGGJSiQk_003D.Normals[smoothTriangle.N2],
			_0023_003DzGGJSiQk_003D.Normals[smoothTriangle.N3]
		};
	}

	private IVertexMaterial[] _0023_003Dzl2A7PibSqGZr(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, int _0023_003Dzrhrpp5YOKlnr)
	{
		return new IVertexMaterial[3]
		{
			default(VertexEmpty),
			default(VertexEmpty),
			default(VertexEmpty)
		};
	}

	private IVertexMaterial[] _0023_003DzxD9S5_00246oo8qd(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, int _0023_003Dzrhrpp5YOKlnr)
	{
		IndexTriangle indexTriangle = _0023_003DzGGJSiQk_003D.Triangles[_0023_003Dzrhrpp5YOKlnr];
		return new IVertexMaterial[3]
		{
			((PointRGB)_0023_003DzGGJSiQk_003D.Vertices[indexTriangle.V1])._0023_003DzNwR9U5Yv1PP0(255),
			((PointRGB)_0023_003DzGGJSiQk_003D.Vertices[indexTriangle.V2])._0023_003DzNwR9U5Yv1PP0(255),
			((PointRGB)_0023_003DzGGJSiQk_003D.Vertices[indexTriangle.V3])._0023_003DzNwR9U5Yv1PP0(255)
		};
	}

	private IVertexMaterial[] _0023_003DzRTYoCkPTpSu2(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, int _0023_003Dzrhrpp5YOKlnr)
	{
		ITriangleSupportsTextureCoords triangleSupportsTextureCoords = (ITriangleSupportsTextureCoords)_0023_003DzGGJSiQk_003D.Triangles[_0023_003Dzrhrpp5YOKlnr];
		return new IVertexMaterial[3]
		{
			_0023_003DzGGJSiQk_003D.TextureCoords[triangleSupportsTextureCoords.T1]._0023_003Dztt1WuDlHUD9N(),
			_0023_003DzGGJSiQk_003D.TextureCoords[triangleSupportsTextureCoords.T2]._0023_003Dztt1WuDlHUD9N(),
			_0023_003DzGGJSiQk_003D.TextureCoords[triangleSupportsTextureCoords.T3]._0023_003Dztt1WuDlHUD9N()
		};
	}

	private IVertexGeometry[] _0023_003DzEYKkNb6AxEhR9jfE4A_003D_003D(devDept.Eyeshot.Entities.Mesh _0023_003DzkKfJheA_003D, int _0023_003Dzl1pVl_00248_003D, _0023_003Dz2C_LeDy_0024YzSi _0023_003Dzxz9kXR937k5W)
	{
		return new IVertexGeometry[3]
		{
			_0023_003DzkKfJheA_003D.Vertices[_0023_003DzkKfJheA_003D.Triangles[_0023_003Dzl1pVl_00248_003D].V1]._0023_003DzM1r5Ziv2v6WP(),
			_0023_003DzkKfJheA_003D.Vertices[_0023_003DzkKfJheA_003D.Triangles[_0023_003Dzl1pVl_00248_003D].V2]._0023_003DzM1r5Ziv2v6WP(),
			_0023_003DzkKfJheA_003D.Vertices[_0023_003DzkKfJheA_003D.Triangles[_0023_003Dzl1pVl_00248_003D].V3]._0023_003DzM1r5Ziv2v6WP()
		};
	}

	private IVertexGeometry[] _0023_003DzSk6RZyXRxgSWMjyo8g_003D_003D(devDept.Eyeshot.Entities.Mesh _0023_003DzkKfJheA_003D, int _0023_003Dzl1pVl_00248_003D, _0023_003Dz2C_LeDy_0024YzSi _0023_003Dzxz9kXR937k5W)
	{
		Vector3D[] array = _0023_003Dzxz9kXR937k5W(_0023_003DzkKfJheA_003D, _0023_003Dzl1pVl_00248_003D);
		return new IVertexGeometry[3]
		{
			_0023_003DzkKfJheA_003D.Vertices[_0023_003DzkKfJheA_003D.Triangles[_0023_003Dzl1pVl_00248_003D].V1]._0023_003DzyOFoEJrAxZfT(array[0]),
			_0023_003DzkKfJheA_003D.Vertices[_0023_003DzkKfJheA_003D.Triangles[_0023_003Dzl1pVl_00248_003D].V2]._0023_003DzyOFoEJrAxZfT(array[1]),
			_0023_003DzkKfJheA_003D.Vertices[_0023_003DzkKfJheA_003D.Triangles[_0023_003Dzl1pVl_00248_003D].V3]._0023_003DzyOFoEJrAxZfT(array[2])
		};
	}

	private IVertexBuilder[] _0023_003Dzf1woadqY_0024IaTOOnDeA_003D_003D<TVertexColorUv>(devDept.Eyeshot.Entities.Mesh _0023_003DzkKfJheA_003D, int _0023_003Dzl1pVl_00248_003D, _0023_003Dz3vyKs0dVw_X6 _0023_003DzjiwabP1bwE1s, _0023_003Dz2C_LeDy_0024YzSi _0023_003Dzxz9kXR937k5W, _0023_003DzA5RjDOcSOxQE _0023_003DzlGlvnPS2MxqH, _0023_003DzIZCctKal0Le_bEwr_Q_003D_003D<TVertexColorUv> _0023_003Dz2bVgAZECIfVDnpJHuQ_003D_003D) where TVertexColorUv : struct, IVertexMaterial
	{
		_ = _0023_003DzkKfJheA_003D.Triangles[_0023_003Dzl1pVl_00248_003D];
		IVertexMaterial[] array = _0023_003DzlGlvnPS2MxqH(_0023_003DzkKfJheA_003D, _0023_003Dzl1pVl_00248_003D);
		IVertexGeometry[] array2 = _0023_003DzjiwabP1bwE1s(_0023_003DzkKfJheA_003D, _0023_003Dzl1pVl_00248_003D, _0023_003Dzxz9kXR937k5W);
		IVertexBuilder[] array3 = new IVertexBuilder[3];
		for (int i = 0; i < array3.Length; i++)
		{
			array3[i] = _0023_003Dz2bVgAZECIfVDnpJHuQ_003D_003D(array2[i], (TVertexColorUv)array[i]);
		}
		return array3;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003DzFXb0cTg_003D<TVertexColoUv>(devDept.Eyeshot.Entities.Mesh _0023_003DzkKfJheA_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003Dzw7hEUK_0024iS_0024DrcFbA_0024HWoWbs_003D _0023_003DzQNaMGYREWOjOEx7ncJ7YsR_Qkwj8, _0023_003Dz2C_LeDy_0024YzSi _0023_003Dzxz9kXR937k5W, _0023_003DzA5RjDOcSOxQE _0023_003DzlGlvnPS2MxqH) where TVertexColoUv : struct, IVertexMaterial
	{
		IMeshBuilder<MaterialBuilder> meshBuilder;
		_0023_003Dz3vyKs0dVw_X6 _0023_003DzjiwabP1bwE1s;
		_0023_003DzIZCctKal0Le_bEwr_Q_003D_003D<TVertexColoUv> _0023_003Dz2bVgAZECIfVDnpJHuQ_003D_003D;
		if (_0023_003DzkKfJheA_003D.Normals == null)
		{
			meshBuilder = new MeshBuilder<VertexPosition, TVertexColoUv, VertexEmpty>();
			_0023_003DzjiwabP1bwE1s = _0023_003DzEYKkNb6AxEhR9jfE4A_003D_003D;
			_0023_003Dz2bVgAZECIfVDnpJHuQ_003D_003D = _0023_003DzppngE0coqaymG8WU7g_003D_003D<TVertexColoUv>._0023_003DzJ5g3Rwo_003D._0023_003DzLLqCoTeHIrrYHkVwa_tCRG4_003D;
		}
		else
		{
			meshBuilder = new MeshBuilder<VertexPositionNormal, TVertexColoUv, VertexEmpty>();
			_0023_003DzjiwabP1bwE1s = _0023_003DzSk6RZyXRxgSWMjyo8g_003D_003D;
			_0023_003Dz2bVgAZECIfVDnpJHuQ_003D_003D = _0023_003DzppngE0coqaymG8WU7g_003D_003D<TVertexColoUv>._0023_003DzJ5g3Rwo_003D._0023_003DzlnhOCUltHe8Ugd9Nz5aJPyY_003D;
		}
		(MaterialBuilder[], int[][]) tuple = _0023_003DzQNaMGYREWOjOEx7ncJ7YsR_Qkwj8(_0023_003DzkKfJheA_003D.Triangles, _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D);
		MaterialBuilder[] item = tuple.Item1;
		int[][] item2 = tuple.Item2;
		for (int i = 0; i < item.Length; i++)
		{
			IPrimitiveBuilder primitiveBuilder = meshBuilder.UsePrimitive(item[i]);
			int[] array = item2[i];
			foreach (int _0023_003Dzl1pVl_00248_003D in array)
			{
				IVertexBuilder[] array2 = _0023_003Dzf1woadqY_0024IaTOOnDeA_003D_003D(_0023_003DzkKfJheA_003D, _0023_003Dzl1pVl_00248_003D, _0023_003DzjiwabP1bwE1s, _0023_003Dzxz9kXR937k5W, _0023_003DzlGlvnPS2MxqH, _0023_003Dz2bVgAZECIfVDnpJHuQ_003D_003D);
				primitiveBuilder.AddTriangle(array2[0], array2[1], array2[2]);
			}
		}
		return meshBuilder;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003DzWVBcT8U_003D(devDept.Eyeshot.Entities.Mesh _0023_003DzGGJSiQk_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzUrowvzdsMUWC _0023_003DzbIl9la2I3Q24, _0023_003DzmfMxh0e4cDiJKzZXgQ_003D_003D _0023_003Dz_CCvZ_00247gWIj3)
	{
		if (_0023_003DzGGJSiQk_003D.Vertices == null || _0023_003DzGGJSiQk_003D.Vertices.Length == 0)
		{
			return null;
		}
		IMeshBuilder<MaterialBuilder> meshBuilder = null;
		_0023_003Dz_CCvZ_00247gWIj3._0023_003DzXiRgY5w_003D();
		Material material = _0023_003Dz_CCvZ_00247gWIj3._0023_003DzOu5uxdtY0kLm();
		switch (_0023_003DzGGJSiQk_003D.MeshNature)
		{
		case devDept.Eyeshot.Entities.Mesh.natureType.Plain:
			meshBuilder = _0023_003DzFXb0cTg_003D<VertexEmpty>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, delegate(devDept.Eyeshot.Entities.Mesh mesh, int _0023_003Dzrhrpp5YOKlnr)
			{
				Vector3D vector3D = mesh.Normals[_0023_003Dzrhrpp5YOKlnr];
				return new Vector3D[3] { vector3D, vector3D, vector3D };
			}, _0023_003Dzl2A7PibSqGZr);
			break;
		case devDept.Eyeshot.Entities.Mesh.natureType.ColorPlain:
			meshBuilder = _0023_003DzFXb0cTg_003D<VertexEmpty>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzmOvYCsqz8OYgr061BA_003D_003D, delegate(devDept.Eyeshot.Entities.Mesh mesh, int _0023_003Dzrhrpp5YOKlnr)
			{
				Vector3D vector3D = mesh.Normals[_0023_003Dzrhrpp5YOKlnr];
				return new Vector3D[3] { vector3D, vector3D, vector3D };
			}, _0023_003Dzl2A7PibSqGZr);
			break;
		case devDept.Eyeshot.Entities.Mesh.natureType.MulticolorPlain:
			meshBuilder = _0023_003DzFXb0cTg_003D<VertexColor1>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, delegate(devDept.Eyeshot.Entities.Mesh mesh, int _0023_003Dzrhrpp5YOKlnr)
			{
				Vector3D vector3D = mesh.Normals[_0023_003Dzrhrpp5YOKlnr];
				return new Vector3D[3] { vector3D, vector3D, vector3D };
			}, delegate(devDept.Eyeshot.Entities.Mesh mesh, int _0023_003Dzrhrpp5YOKlnr)
			{
				IndexTriangle indexTriangle = mesh.Triangles[_0023_003Dzrhrpp5YOKlnr];
				return new IVertexMaterial[3]
				{
					((PointRGB)mesh.Vertices[indexTriangle.V1])._0023_003DzNwR9U5Yv1PP0(255),
					((PointRGB)mesh.Vertices[indexTriangle.V2])._0023_003DzNwR9U5Yv1PP0(255),
					((PointRGB)mesh.Vertices[indexTriangle.V3])._0023_003DzNwR9U5Yv1PP0(255)
				};
			});
			break;
		case devDept.Eyeshot.Entities.Mesh.natureType.RichPlain:
			meshBuilder = ((material?.TextureImage == null) ? _0023_003DzFXb0cTg_003D<VertexEmpty>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, delegate(devDept.Eyeshot.Entities.Mesh mesh, int _0023_003Dzrhrpp5YOKlnr)
			{
				Vector3D vector3D = mesh.Normals[_0023_003Dzrhrpp5YOKlnr];
				return new Vector3D[3] { vector3D, vector3D, vector3D };
			}, _0023_003Dzl2A7PibSqGZr) : _0023_003DzFXb0cTg_003D<VertexTexture1>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, delegate(devDept.Eyeshot.Entities.Mesh mesh, int _0023_003Dzrhrpp5YOKlnr)
			{
				Vector3D vector3D = mesh.Normals[_0023_003Dzrhrpp5YOKlnr];
				return new Vector3D[3] { vector3D, vector3D, vector3D };
			}, _0023_003DzRTYoCkPTpSu2));
			break;
		case devDept.Eyeshot.Entities.Mesh.natureType.Smooth:
			meshBuilder = _0023_003DzFXb0cTg_003D<VertexEmpty>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, _0023_003DziWphL_mX5aiZWTUtCR_ZWzLBP5QK, _0023_003Dzl2A7PibSqGZr);
			break;
		case devDept.Eyeshot.Entities.Mesh.natureType.ColorSmooth:
			meshBuilder = _0023_003DzFXb0cTg_003D<VertexEmpty>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzmOvYCsqz8OYgr061BA_003D_003D, _0023_003DziWphL_mX5aiZWTUtCR_ZWzLBP5QK, _0023_003Dzl2A7PibSqGZr);
			break;
		case devDept.Eyeshot.Entities.Mesh.natureType.MulticolorSmooth:
			meshBuilder = _0023_003DzFXb0cTg_003D<VertexColor1>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, _0023_003DziWphL_mX5aiZWTUtCR_ZWzLBP5QK, delegate(devDept.Eyeshot.Entities.Mesh mesh, int _0023_003Dzrhrpp5YOKlnr)
			{
				IndexTriangle indexTriangle = mesh.Triangles[_0023_003Dzrhrpp5YOKlnr];
				return new IVertexMaterial[3]
				{
					((PointRGB)mesh.Vertices[indexTriangle.V1])._0023_003DzNwR9U5Yv1PP0(255),
					((PointRGB)mesh.Vertices[indexTriangle.V2])._0023_003DzNwR9U5Yv1PP0(255),
					((PointRGB)mesh.Vertices[indexTriangle.V3])._0023_003DzNwR9U5Yv1PP0(255)
				};
			});
			break;
		case devDept.Eyeshot.Entities.Mesh.natureType.RichSmooth:
			meshBuilder = ((material?.TextureImage == null) ? _0023_003DzFXb0cTg_003D<VertexEmpty>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, _0023_003DziWphL_mX5aiZWTUtCR_ZWzLBP5QK, _0023_003Dzl2A7PibSqGZr) : _0023_003DzFXb0cTg_003D<VertexTexture1>(_0023_003DzGGJSiQk_003D, _0023_003DzQbUgygS5KRuatO_olA_003D_003D, _0023_003DzcOs5D6vUlPvuSXFB9w_003D_003D, _0023_003DziWphL_mX5aiZWTUtCR_ZWzLBP5QK, _0023_003DzRTYoCkPTpSu2));
			break;
		}
		if (meshBuilder != null && _0023_003DzbIl9la2I3Q24._0023_003Dzm4_LMmM9K7Ev() != null)
		{
			IPrimitiveBuilder primitiveBuilder = meshBuilder.UsePrimitive(_0023_003DzbIl9la2I3Q24._0023_003Dzm4_LMmM9K7Ev(), 2);
			VertexColor1 m = _0023_003DzN0vDvhm_0024kanu._0023_003DzNwR9U5Yv1PP0();
			IndexLine[] edges = _0023_003DzGGJSiQk_003D.Edges;
			foreach (IndexLine indexLine in edges)
			{
				IVertexBuilder a;
				IVertexBuilder b;
				if (_0023_003DzGGJSiQk_003D.Normals == null)
				{
					a = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(_0023_003DzGGJSiQk_003D.Vertices[indexLine.V1]._0023_003DzM1r5Ziv2v6WP(), in m);
					b = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(_0023_003DzGGJSiQk_003D.Vertices[indexLine.V2]._0023_003DzM1r5Ziv2v6WP(), in m);
				}
				else
				{
					a = new VertexBuilder<VertexPositionNormal, VertexColor1, VertexEmpty>(_0023_003DzGGJSiQk_003D.Vertices[indexLine.V1]._0023_003DzyOFoEJrAxZfT(new Vector3D(0.0, 0.0, 1.0)), in m);
					b = new VertexBuilder<VertexPositionNormal, VertexColor1, VertexEmpty>(_0023_003DzGGJSiQk_003D.Vertices[indexLine.V2]._0023_003DzyOFoEJrAxZfT(new Vector3D(0.0, 0.0, 1.0)), in m);
				}
				primitiveBuilder.AddLine(a, b);
			}
		}
		return meshBuilder;
	}

	private void _0023_003DzDdHflxP7053E(FemMesh _0023_003DzQEO9PnHahyH4, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		if (_0023_003DzQEO9PnHahyH4.skin == null)
		{
			_0023_003DzQEO9PnHahyH4.Regen(0.0);
		}
		if (_0023_003DzQEO9PnHahyH4.skin == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012671) + _0023_003DzQEO9PnHahyH4.GetType().Name);
		}
		_0023_003Dz5v26jTE_003D(_0023_003DzQEO9PnHahyH4.ConvertToMesh(), _0023_003DzG5DrMVi4EvFJ, _0023_003DzQEO9PnHahyH4.EntityData);
	}

	private void _0023_003DzS1B26tMvoaUN(Entity _0023_003Dz9j7EUB0_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ, _0023_003DzL_j2dOZbK06e _0023_003Dzkuutc1Dm3MqdGro0c9nOhUs_003D, _0023_003DzL_j2dOZbK06e _0023_003Dz4nX2nimYy3Jx, _0023_003DzL_j2dOZbK06e _0023_003Dz5GjvxlAsEP67)
	{
		Material material = _0023_003Dz9j7EUB0_003D.GetMaterial(_0023_003Dz5It_dZQgzd0N6YWY9w_003D_003D, layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzOu5uxdtY0kLm());
		devDept.Eyeshot.Entities.Mesh mesh = ((material == null) ? _0023_003Dz5GjvxlAsEP67(_0023_003Dz9j7EUB0_003D) : ((material.Texture != null) ? _0023_003Dzkuutc1Dm3MqdGro0c9nOhUs_003D(_0023_003Dz9j7EUB0_003D) : _0023_003Dz4nX2nimYy3Jx(_0023_003Dz9j7EUB0_003D)));
		mesh.NormalAveragingMode = devDept.Eyeshot.Entities.Mesh.normalAveragingType.AveragedByAngle;
		mesh.UpdateNormals();
		mesh.CopyAttributes(_0023_003Dz9j7EUB0_003D);
		if (!_0023_003DzN0vDvhm_0024kanu.IsEmpty)
		{
			mesh.ComputeEdges();
		}
		_0023_003Dz5v26jTE_003D(mesh, _0023_003DzG5DrMVi4EvFJ, _0023_003Dz9j7EUB0_003D.EntityData);
	}

	private IMeshBuilder<MaterialBuilder> _0023_003DzYndQWHnEFUCn(FastPointCloud _0023_003DzbYcdR1c_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		MeshBuilder<VertexPosition, VertexColor1, VertexEmpty> meshBuilder = new MeshBuilder<VertexPosition, VertexColor1, VertexEmpty>();
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 1);
		Color color = _0023_003DzbYcdR1c_003D.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D());
		for (int i = 0; i < _0023_003DzbYcdR1c_003D.PointArray.Length; i += 3)
		{
			Color _0023_003Dz1MMYB1g_003D = Color.White;
			if (_0023_003DzbYcdR1c_003D._0023_003DzcPAo3gzQ86BL() == FastPointCloud._0023_003DzAtKz90KWkOZN.None)
			{
				_0023_003Dz1MMYB1g_003D = color;
			}
			else if (_0023_003DzbYcdR1c_003D._0023_003DzcPAo3gzQ86BL() == FastPointCloud._0023_003DzAtKz90KWkOZN.RGB)
			{
				_0023_003Dz1MMYB1g_003D = Color.FromArgb(_0023_003DzbYcdR1c_003D.ColorArray[i], _0023_003DzbYcdR1c_003D.ColorArray[i + 1], _0023_003DzbYcdR1c_003D.ColorArray[i + 2]);
			}
			else if (_0023_003DzbYcdR1c_003D._0023_003DzcPAo3gzQ86BL() == FastPointCloud._0023_003DzAtKz90KWkOZN.RGBA)
			{
				_0023_003Dz1MMYB1g_003D = Color.FromArgb(_0023_003DzbYcdR1c_003D.ColorArray[i / 3 * 4 + 3], _0023_003DzbYcdR1c_003D.ColorArray[i / 3 * 4], _0023_003DzbYcdR1c_003D.ColorArray[i / 3 * 4 + 1], _0023_003DzbYcdR1c_003D.ColorArray[i / 3 * 4 + 2]);
			}
			else if (_0023_003DzbYcdR1c_003D._0023_003DzcPAo3gzQ86BL() == FastPointCloud._0023_003DzAtKz90KWkOZN.Indeterminate)
			{
				float num = (float)(int)_0023_003DzbYcdR1c_003D.ColorArray[i / 3] / 255f;
				_0023_003Dz1MMYB1g_003D = Color.FromArgb((int)((float)(int)color.R * num), (int)((float)(int)color.G * num), (int)((float)(int)color.B * num));
			}
			VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(new VertexPosition(_0023_003DzbYcdR1c_003D.PointArray[i], _0023_003DzbYcdR1c_003D.PointArray[i + 1], _0023_003DzbYcdR1c_003D.PointArray[i + 2]), _0023_003Dz1MMYB1g_003D._0023_003DzNwR9U5Yv1PP0());
			primitiveBuilder.AddPoint(a);
		}
		return meshBuilder;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003DzuCNxjOQ_003D(Hatch _0023_003Dz1L3TZOcNA99t, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		if (_0023_003Dz1L3TZOcNA99t.IsSolid())
		{
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(_0023_003Dz1L3TZOcNA99t.ContourList);
			region.CopyAttributes(_0023_003Dz1L3TZOcNA99t);
			region.Regen(base.Deviation);
			_0023_003Dz5v26jTE_003D(region, _0023_003DzG5DrMVi4EvFJ, _0023_003Dz1L3TZOcNA99t.EntityData);
			return null;
		}
		MeshBuilder<VertexPosition, VertexColor1, VertexEmpty> meshBuilder = new MeshBuilder<VertexPosition, VertexColor1, VertexEmpty>();
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 2);
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder2 = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 1);
		VertexColor1 m = _0023_003Dz1L3TZOcNA99t.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D())._0023_003DzNwR9U5Yv1PP0();
		int num;
		for (num = 0; num < _0023_003Dz1L3TZOcNA99t.patternLines.Length - 1; num++)
		{
			VertexPosition g = _0023_003Dz1L3TZOcNA99t.patternLines[num]._0023_003DzM1r5Ziv2v6WP();
			VertexPosition g2 = _0023_003Dz1L3TZOcNA99t.patternLines[++num]._0023_003DzM1r5Ziv2v6WP();
			VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(in g, in m);
			VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> b = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(in g2, in m);
			primitiveBuilder.AddLine(a, b);
		}
		for (int i = 0; i < _0023_003Dz1L3TZOcNA99t.patternPoints.Length; i++)
		{
			VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a2 = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(_0023_003Dz1L3TZOcNA99t.patternPoints[i]._0023_003DzM1r5Ziv2v6WP(), in m);
			primitiveBuilder2.AddPoint(a2);
		}
		return meshBuilder;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003Dz9tJ7VyU_003D(Picture _0023_003DzKvpyqV4_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		devDept.Eyeshot.Entities.Mesh mesh = _0023_003DzKvpyqV4_003D.ConvertToMesh();
		Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012617) + ((!string.IsNullOrEmpty(_0023_003DzKvpyqV4_003D.FilePath)) ? Path.GetFileNameWithoutExtension(_0023_003DzKvpyqV4_003D.FilePath) : string.Concat(SHA1.Create().ComputeHash(_0023_003DzKvpyqV4_003D.Image).Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz_d16JRdC3VVwGYUzHKJaqdA_003D))), _0023_003DzKvpyqV4_003D.Image);
		MaterialBuilder material = _0023_003DzV_mGEKk_003D(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D);
		IMeshBuilder<MaterialBuilder> meshBuilder = new MeshBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty>();
		IPrimitiveBuilder primitiveBuilder = meshBuilder.UsePrimitive(material);
		for (int i = 0; i < mesh.Triangles.Length; i++)
		{
			RichTriangle richTriangle = (RichTriangle)mesh.Triangles[i];
			IVertexBuilder a = new VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty>(_0023_003DzKvpyqV4_003D.Vertices[richTriangle.V1]._0023_003DzyOFoEJrAxZfT(mesh.Normals[i]), mesh.TextureCoords[richTriangle.T1]._0023_003Dztt1WuDlHUD9N());
			IVertexBuilder b = new VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty>(_0023_003DzKvpyqV4_003D.Vertices[richTriangle.V2]._0023_003DzyOFoEJrAxZfT(mesh.Normals[i]), mesh.TextureCoords[richTriangle.T2]._0023_003Dztt1WuDlHUD9N());
			IVertexBuilder c = new VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty>(_0023_003DzKvpyqV4_003D.Vertices[richTriangle.V3]._0023_003DzyOFoEJrAxZfT(mesh.Normals[i]), mesh.TextureCoords[richTriangle.T3]._0023_003Dztt1WuDlHUD9N());
			primitiveBuilder.AddTriangle(a, b, c);
		}
		return meshBuilder;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003DzkahHEnc_003D(devDept.Eyeshot.Entities.Point _0023_003DzMlCq3wk_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		Point3D point3D = ((_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8() != null) ? blocks[_0023_003DzG5DrMVi4EvFJ._0023_003DzRcuz4cVtApX8()].BasePoint : Point3D.Origin);
		MeshBuilder<VertexPosition, VertexColor1, VertexEmpty> meshBuilder = new MeshBuilder<VertexPosition, VertexColor1, VertexEmpty>();
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 1);
		VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>((_0023_003DzMlCq3wk_003D.Position - point3D)._0023_003DzM1r5Ziv2v6WP(), _0023_003DzMlCq3wk_003D.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D())._0023_003DzNwR9U5Yv1PP0());
		primitiveBuilder.AddPoint(a);
		return meshBuilder;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003DzKmKa_0wwPyT3(PointCloud _0023_003Dzifq_QG8_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		MeshBuilder<VertexPosition, VertexColor1, VertexEmpty> meshBuilder = new MeshBuilder<VertexPosition, VertexColor1, VertexEmpty>();
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 1);
		bool flag = _0023_003Dzifq_QG8_003D.Vertices[0] is PointRGB;
		Color color = _0023_003Dzifq_QG8_003D.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D());
		Point3D[] vertices = _0023_003Dzifq_QG8_003D.Vertices;
		foreach (Point3D point3D in vertices)
		{
			VertexColor1 m = (flag ? (point3D as PointRGB)._0023_003DzNwR9U5Yv1PP0(color.A) : color._0023_003DzNwR9U5Yv1PP0());
			VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(point3D._0023_003DzM1r5Ziv2v6WP(), in m);
			primitiveBuilder.AddPoint(a);
		}
		return meshBuilder;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003Dz0N5el4sM8Z8X3oHJ6A_003D_003D(SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		MeshBuilder<VertexPosition, VertexColor1, VertexEmpty> meshBuilder = new MeshBuilder<VertexPosition, VertexColor1, VertexEmpty>();
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 2);
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder2 = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 1);
		VertexColor1 m = _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D())._0023_003DzNwR9U5Yv1PP0();
		foreach (ICurve curve in _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.CurveList)
		{
			if (curve is devDept.Eyeshot.Entities.Point point)
			{
				VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(new Point3D(point.Position.ToArray())._0023_003DzM1r5Ziv2v6WP(), in m);
				primitiveBuilder2.AddPoint(a);
				continue;
			}
			LinearPath linearPath = curve.ConvertToLinearPath(base.Deviation, base.Angle);
			for (int i = 0; i < linearPath.Vertices.Length - 1; i++)
			{
				VertexPosition g = linearPath.Vertices[i]._0023_003DzM1r5Ziv2v6WP();
				VertexPosition g2 = linearPath.Vertices[i + 1]._0023_003DzM1r5Ziv2v6WP();
				VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a2 = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(in g, in m);
				VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> b = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(in g2, in m);
				primitiveBuilder.AddLine(a2, b);
			}
		}
		return meshBuilder;
	}

	private IMeshBuilder<MaterialBuilder> _0023_003DzPFJt9Ij8Nt_0024U(Entity _0023_003DzEZ_0024X0WU_003D, _0023_003DzUrowvzdsMUWC[] _0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D, _0023_003DzhlzU2HC7VAhe _0023_003DzG5DrMVi4EvFJ)
	{
		MeshBuilder<VertexPosition, VertexColor1, VertexEmpty> meshBuilder = new MeshBuilder<VertexPosition, VertexColor1, VertexEmpty>();
		PrimitiveBuilder<MaterialBuilder, VertexPosition, VertexColor1, VertexEmpty> primitiveBuilder = meshBuilder.UsePrimitive(_0023_003DzNIsqbFqkv1_ya0zSNA_003D_003D[0]._0023_003Dzm4_LMmM9K7Ev(), 2);
		VertexColor1 m = _0023_003DzEZ_0024X0WU_003D.GetColor(layers, _0023_003DzG5DrMVi4EvFJ._0023_003DzXiRgY5w_003D())._0023_003DzNwR9U5Yv1PP0();
		for (int i = 0; i < _0023_003DzEZ_0024X0WU_003D.Vertices.Length - 1; i++)
		{
			VertexPosition g = _0023_003DzEZ_0024X0WU_003D.Vertices[i]._0023_003DzM1r5Ziv2v6WP();
			VertexPosition g2 = _0023_003DzEZ_0024X0WU_003D.Vertices[i + 1]._0023_003DzM1r5Ziv2v6WP();
			VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> a = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(in g, in m);
			VertexBuilder<VertexPosition, VertexColor1, VertexEmpty> b = new VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>(in g2, in m);
			primitiveBuilder.AddLine(a, b);
		}
		return meshBuilder;
	}
}
