using System;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Transforms;

namespace SharpGLTF.Animations;

[DebuggerDisplay("{ToDebuggerDisplayString(),nq}")]
internal struct _CurveNode<T>
{
	public int Degree;

	public T IncomingTangent;

	public T Point;

	public T OutgoingTangent;

	private string ToDebuggerDisplayString()
	{
		return Degree switch
		{
			0 => _ToString(Point) ?? "", 
			1 => _ToString(Point) ?? "", 
			3 => _ToString(IncomingTangent) + " -> (" + _ToString(Point) + ") -> " + _ToString(OutgoingTangent), 
			_ => "Unsupported", 
		};
	}

	private static string _ToString(T value)
	{
		if (value is ArraySegment<float> arraySegment)
		{
			if (arraySegment.Count < 20)
			{
				return string.Join(" ", Enumerable.ToArray(arraySegment));
			}
			return SparseWeight8.Create(Enumerable.ToArray(arraySegment)).ToString();
		}
		if (value is SparseWeight8 sparseWeight)
		{
			return sparseWeight.ToString();
		}
		return value.ToString();
	}

	public _CurveNode(T value, bool isLinear)
	{
		Degree = (isLinear ? 1 : 0);
		IncomingTangent = default(T);
		Point = value;
		OutgoingTangent = default(T);
	}

	public _CurveNode(T incoming, T value, T outgoing)
	{
		Degree = 3;
		IncomingTangent = incoming;
		Point = value;
		OutgoingTangent = outgoing;
	}

	public _CurveNode<T> Clone(Func<T, T> cloneValue)
	{
		return new _CurveNode<T>
		{
			Degree = Degree,
			IncomingTangent = cloneValue(IncomingTangent),
			Point = cloneValue(Point),
			OutgoingTangent = cloneValue(OutgoingTangent)
		};
	}
}
