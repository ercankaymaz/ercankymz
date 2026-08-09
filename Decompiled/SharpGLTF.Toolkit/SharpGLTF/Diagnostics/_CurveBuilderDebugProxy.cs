using System.Collections.Generic;
using System.Diagnostics;
using SharpGLTF.Animations;

namespace SharpGLTF.Diagnostics;

internal abstract class _CurveBuilderDebugProxy<T> where T : struct
{
	[DebuggerDisplay("{Key} => {Point}")]
	private struct _Point
	{
		public float Key;

		public T Point;
	}

	[DebuggerDisplay("               \ud83e\udc56 {Tangent}")]
	private struct _OutTangent
	{
		public T Tangent;
	}

	[DebuggerDisplay("               \ud83e\udc57 {Tangent}")]
	private struct _InTangent
	{
		public T Tangent;
	}

	private readonly CurveBuilder<T> _Curve;

	private readonly List<object> _Items = new List<object>();

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public object[] Items => _Items.ToArray();

	public _CurveBuilderDebugProxy(CurveBuilder<T> curve)
	{
		_Curve = curve;
		_CreateItems(curve);
	}

	private void _CreateItems(CurveBuilder<T> curve)
	{
		_CurveNode<T>? curveNode = null;
		foreach (KeyValuePair<float, _CurveNode<T>> debugKey in curve._DebugKeys)
		{
			if (curveNode.HasValue)
			{
				switch (curveNode.Value.Degree)
				{
				case 1:
					_Items.Add(new _OutTangent
					{
						Tangent = GetTangent(curveNode.Value.Point, debugKey.Value.Point)
					});
					break;
				case 3:
					_Items.Add(new _OutTangent
					{
						Tangent = curveNode.Value.OutgoingTangent
					});
					_Items.Add(new _InTangent
					{
						Tangent = debugKey.Value.IncomingTangent
					});
					break;
				default:
					_Items.Add("ERROR: {d}");
					break;
				case 0:
					break;
				}
			}
			_Items.Add(new _Point
			{
				Key = debugKey.Key,
				Point = debugKey.Value.Point
			});
			curveNode = debugKey.Value;
		}
	}

	protected abstract T GetTangent(T a, T b);
}
