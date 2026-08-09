using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class MultiFastMesh : FastMesh
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<FastMesh, int> _0023_003Dz38_WZBhyB43pPpxcCQ_003D_003D;

		public static Func<FastMesh, int> _0023_003DzkiMeGQi_0024daIiqK5jTg_003D_003D;

		public static Func<FastMesh, int> _0023_003DzGh82OGe6rRnz7c6USw_003D_003D;

		public static Func<Tuple<int, int>, IntInterval> _0023_003Dzy7nEv89xDomyXIe12g_003D_003D;

		public static Func<IntInterval, Tuple<int, int>> _0023_003Dz4r8Rr35Bk_fzaIJ7Cg_003D_003D;

		public static Func<Tuple<int, int, Color>, SubMeshInterval> _0023_003DzctmtDKLXaeFxoDNAVA_003D_003D;

		public static Func<SubMeshInterval, Tuple<int, int, Color>> _0023_003DzHakk9KKVJNaTquf_0024Bg_003D_003D;

		internal int _0023_003DzN8cmEz7H6cAjUsgVU1BP_0024lA_003D(FastMesh _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D.PointArray.Length;
		}

		internal int _0023_003DzYNcIzSWVimlu_0024MH5Wa_0024tnyk_003D(FastMesh _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D.NormalArray.Length;
		}

		internal int _0023_003DzGjz9mfGzceoxDlD7EpE_2JQ_003D(FastMesh _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D.TriangleArray.Length;
		}

		internal IntInterval _0023_003DzF8q1BQFS3g_oglrTkRJ3wcc_003D(Tuple<int, int> _0023_003DzDVfrOi0_003D)
		{
			return new IntInterval(_0023_003DzDVfrOi0_003D.Item1, _0023_003DzDVfrOi0_003D.Item2 - 1);
		}

		internal Tuple<int, int> _0023_003Dz1ujct77We68rLtM_MCA5V40_003D(IntInterval _0023_003DzzJ_0024HnAY_003D)
		{
			return new Tuple<int, int>(_0023_003DzzJ_0024HnAY_003D.Start, _0023_003DzzJ_0024HnAY_003D.End + 1);
		}

		internal SubMeshInterval _0023_003Dzg3q2Mxm3HZ36mbpavdYbLbk_003D(Tuple<int, int, Color> _0023_003DzDVfrOi0_003D)
		{
			return new SubMeshInterval(_0023_003DzDVfrOi0_003D.Item1, _0023_003DzDVfrOi0_003D.Item2, _0023_003DzDVfrOi0_003D.Item3);
		}

		internal Tuple<int, int, Color> _0023_003DznFMclFFOITjhIB_00247H65Ltvo_003D(SubMeshInterval _0023_003DzzJ_0024HnAY_003D)
		{
			return new Tuple<int, int, Color>(_0023_003DzzJ_0024HnAY_003D.SubMeshes.Start, _0023_003DzzJ_0024HnAY_003D.SubMeshes.End, _0023_003DzzJ_0024HnAY_003D.Color);
		}
	}

	[Serializable]
	public struct SubMeshInterval
	{
		public IntInterval SubMeshes;

		public Color Color;

		public SubMeshInterval(IntInterval subMeshes, Color color)
		{
			SubMeshes = subMeshes;
			Color = color;
		}

		public SubMeshInterval(int subMeshStart, int subMeshEnd, Color color)
		{
			SubMeshes = new IntInterval(subMeshStart, subMeshEnd);
			Color = color;
		}
	}

	private readonly IntInterval[] _subMeshes;

	protected bool SuspendColor;

	public List<SubMeshInterval> SubMeshIntervals { get; set; }

	public int SubMeshesCount => _subMeshes.Length;

	protected internal MultiFastMesh(MultiFastMesh other, bool keepTessellation = false)
		: base(other, keepTessellation)
	{
		_subMeshes = new IntInterval[other._subMeshes.Length];
		for (int i = 0; i < other._subMeshes.Length; i++)
		{
			_subMeshes[i] = other._subMeshes[i];
		}
		SubMeshIntervals = new List<SubMeshInterval>(other.SubMeshIntervals);
	}

	public MultiFastMesh(float[] points, float[] normals, int[] triangles, IntInterval[] subMeshTriangles)
		: base(points, triangles, normals)
	{
		if (points == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973047));
		}
		if (normals == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973028));
		}
		if (triangles == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973037));
		}
		if (points.Length != normals.Length)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973018));
		}
		_subMeshes = subMeshTriangles;
		SubMeshIntervals = new List<SubMeshInterval>(new SubMeshInterval[1]
		{
			new SubMeshInterval(0, _subMeshes.Length - 1, Color.Gray)
		});
	}

	public MultiFastMesh(FastMesh[] subMeshes)
		: base(BatchAll(subMeshes))
	{
		if (subMeshes == null || subMeshes.Length == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972975), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973179));
		}
		_subMeshes = new IntInterval[subMeshes.Length];
		int i = 0;
		int num = 0;
		for (; i < subMeshes.Length; i++)
		{
			int num2 = num;
			int num3 = subMeshes[i].TriangleArray.Length;
			_subMeshes[i] = new IntInterval(num2, num2 + num3 - 1);
			num += num3;
		}
		SubMeshIntervals = new List<SubMeshInterval>(new SubMeshInterval[1]
		{
			new SubMeshInterval(0, _subMeshes.Length - 1, Color.Gray)
		});
	}

	protected internal MultiFastMesh(MultiFastMeshSurrogate surrogate)
		: base(surrogate)
	{
		SubMeshIntervals = _0023_003DzD3QnBxYg0jM_0024(surrogate.SubMeshColors).ToList();
		_subMeshes = _0023_003DzD3QnBxYg0jM_0024(surrogate.subMeshRanges).ToArray();
	}

	protected MultiFastMesh(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		SubMeshIntervals = (List<SubMeshInterval>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973160), typeof(List<SubMeshInterval>));
		_subMeshes = (IntInterval[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973150), typeof(IntInterval[]));
	}

	internal IntInterval[] _0023_003DzlTUjqXrVSKtY8Mj2rg_003D_003D()
	{
		return _subMeshes;
	}

	private static bool _0023_003DziflqeWGnWfr5ekagoQ_003D_003D(FastMesh[] _0023_003DzcDEsV8s_003D)
	{
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.Length; i++)
		{
			if (_0023_003DzcDEsV8s_003D[i].TriangleArray == null)
			{
				return false;
			}
		}
		return true;
	}

	protected static FastMesh BatchAll(params FastMesh[] list)
	{
		if (!_0023_003DziflqeWGnWfr5ekagoQ_003D_003D(list))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973108), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973823));
		}
		float[] array = new float[list.Sum((FastMesh _0023_003DzGcl_0024E9o_003D) => _0023_003DzGcl_0024E9o_003D.PointArray.Length)];
		float[] array2 = new float[list.Sum((FastMesh _0023_003DzGcl_0024E9o_003D) => _0023_003DzGcl_0024E9o_003D.NormalArray.Length)];
		int[] array3 = new int[((IEnumerable<FastMesh>)list).Sum((Func<FastMesh, int>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzGjz9mfGzceoxDlD7EpE_2JQ_003D)];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (FastMesh fastMesh in list)
		{
			Array.Copy(fastMesh.PointArray, 0, array, num, fastMesh.PointArray.Length);
			Array.Copy(fastMesh.NormalArray, 0, array2, num, fastMesh.NormalArray.Length);
			for (int num5 = 0; num5 < fastMesh.TriangleArray.Length; num5++)
			{
				array3[num5 + num2] = fastMesh.TriangleArray[num5] + num3;
			}
			num += fastMesh.PointArray.Length;
			num3 += fastMesh.PointArray.Length / 3;
			num2 += fastMesh.TriangleArray.Length;
		}
		return new FastMesh(array, array3, array2);
	}

	public override object Clone()
	{
		return new MultiFastMesh(this);
	}

	public override object CloneWithTessellation()
	{
		return new MultiFastMesh(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void Compile(CompileParams data)
	{
		base.Compile(data);
		if (!drawData.IsVbo())
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973804));
		}
	}

	internal static IEnumerable<IntInterval> _0023_003DzD3QnBxYg0jM_0024(IList<Tuple<int, int>> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D?.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzF8q1BQFS3g_oglrTkRJ3wcc_003D);
	}

	internal static IEnumerable<Tuple<int, int>> _0023_003Dzvv6hJ9KR6NHc(IList<IntInterval> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D?.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz1ujct77We68rLtM_MCA5V40_003D);
	}

	internal static IEnumerable<SubMeshInterval> _0023_003DzD3QnBxYg0jM_0024(IList<Tuple<int, int, Color>> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D?.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzg3q2Mxm3HZ36mbpavdYbLbk_003D);
	}

	internal static IEnumerable<Tuple<int, int, Color>> _0023_003Dzvv6hJ9KR6NHc(IList<SubMeshInterval> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D?.Select((SubMeshInterval _0023_003DzzJ_0024HnAY_003D) => new Tuple<int, int, Color>(_0023_003DzzJ_0024HnAY_003D.SubMeshes.Start, _0023_003DzzJ_0024HnAY_003D.SubMeshes.End, _0023_003DzzJ_0024HnAY_003D.Color));
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new MultiFastMeshSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973160), SubMeshIntervals);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973150), _subMeshes);
	}

	protected internal override void Draw(DrawParams data)
	{
		for (int i = 0; i < SubMeshIntervals.Count; i++)
		{
			if (!SuspendColor)
			{
				Entity.SetEntityColorForFace(data, SubMeshIntervals[i].Color);
			}
			int start = _subMeshes[SubMeshIntervals[i].SubMeshes.Start].Start;
			int end = _subMeshes[SubMeshIntervals[i].SubMeshes.End].End;
			data.RenderContext.Draw(drawData, primitiveType.Undefined, (uint)start, (uint)(end - start + 1));
		}
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams drawSilhouettesParams)
	{
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		Draw(data);
	}

	protected internal override void DrawSelected(DrawParams drawParams)
	{
		bool suspendColor = SuspendColor;
		SuspendColor = drawParams.Selected || drawParams.viewportInternal.parent.GetDisplayModeSettings(drawParams.viewportInternal.DisplayMode).EdgeColorMethod == edgeColorMethodType.SingleColor;
		Draw(drawParams);
		SuspendColor = suspendColor;
	}

	protected internal override void DrawForDepthPass(DrawParams drawParams)
	{
		bool suspendColor = SuspendColor;
		SuspendColor = true;
		Draw(drawParams);
		SuspendColor = suspendColor;
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		DrawForDepthPass(data);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		DrawForDepthPass(data);
	}
}
