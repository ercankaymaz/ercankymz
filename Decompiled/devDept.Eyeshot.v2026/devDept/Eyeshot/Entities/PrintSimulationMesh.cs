using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class PrintSimulationMesh : MultiFastMesh
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<MotionRange, IntInterval> _0023_003DzTo4XDDj1vwXNMGu8Og_003D_003D;

		public static Func<IntInterval, MotionRange> _0023_003Dz7WKXDUM7qNCMbf2s2g_003D_003D;

		public static Func<MotionRangeStyle, MotionInterval> _0023_003Dz4BExgZY4uHZhaB5wjQ_003D_003D;

		public static Func<MotionInterval, MotionRangeStyle> _0023_003DzRQ9ZjnyC61T32HFDBQ_003D_003D;

		internal IntInterval _0023_003DzGAEswMOVZdtVkvJ4NPBRkoE_003D(MotionRange _0023_003DzuwH5j5s_003D)
		{
			return new IntInterval(_0023_003DzuwH5j5s_003D.Start, _0023_003DzuwH5j5s_003D.End);
		}

		internal MotionRange _0023_003DzpybNGFxB_0024I5ViOmxHo8E2C0_003D(IntInterval _0023_003DzuwH5j5s_003D)
		{
			return new MotionRange(_0023_003DzuwH5j5s_003D.Start, _0023_003DzuwH5j5s_003D.End);
		}

		internal MotionInterval _0023_003DzHkem5NTZ5hjqnV92BvmZ4rs_003D(MotionRangeStyle _0023_003DzuwH5j5s_003D)
		{
			return new MotionInterval(_0023_003DzuwH5j5s_003D.Range.Start, _0023_003DzuwH5j5s_003D.Range.End, _0023_003DzuwH5j5s_003D.ColorName);
		}

		internal MotionRangeStyle _0023_003Dz7rfoLyhqtUvMoEnNQ894hE9IrB0PcZTEsA_003D_003D(MotionInterval _0023_003DzuwH5j5s_003D)
		{
			return new MotionRangeStyle(_0023_003DzuwH5j5s_003D.Motions.Start, _0023_003DzuwH5j5s_003D.Motions.End, _0023_003DzuwH5j5s_003D.StyleName);
		}
	}

	[Serializable]
	public struct MotionInterval
	{
		public IntInterval Motions;

		public string StyleName;

		public MotionInterval(IntInterval motions, string styleName)
		{
			Motions = motions;
			StyleName = styleName;
		}

		public MotionInterval(int intervalStart, int intervalEnd, string styleName)
		{
			Motions = new IntInterval(intervalStart, intervalEnd);
			StyleName = styleName;
		}
	}

	[Serializable]
	internal struct MotionRange
	{
		public int Start;

		public int End;

		public MotionRange(int _0023_003DzAddCv_o_003D, int _0023_003Dz9iVQ96E_003D)
		{
			Start = _0023_003DzAddCv_o_003D;
			End = _0023_003Dz9iVQ96E_003D;
		}

		internal MotionRange(MotionRangeSurrogate _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D)
		{
			Start = _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.Start;
			End = _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.End;
		}

		internal MotionRangeSurrogate _0023_003Dz_0024xHo97pGU7zE()
		{
			return new MotionRangeSurrogate(this);
		}
	}

	[Serializable]
	internal struct MotionRangeStyle
	{
		public MotionRange Range;

		public string ColorName;

		public MotionRangeStyle(MotionRange _0023_003DzKXE0z8y9H8_wsH4M1A_003D_003D, string _0023_003DzQvukAtw_003D)
		{
			Range = _0023_003DzKXE0z8y9H8_wsH4M1A_003D_003D;
			ColorName = _0023_003DzQvukAtw_003D;
		}

		public MotionRangeStyle(int _0023_003DzKwjAZEk_003D, int _0023_003DzIneXloc_003D, string _0023_003DzQvukAtw_003D)
		{
			Range.Start = _0023_003DzKwjAZEk_003D;
			Range.End = _0023_003DzIneXloc_003D;
			ColorName = _0023_003DzQvukAtw_003D;
		}

		internal MotionRangeStyle(MotionRangeStyleSurrogate _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D)
		{
			Range = _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.Range;
			ColorName = _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.ColorName;
		}

		internal MotionRangeStyleSurrogate _0023_003Dz_0024xHo97pGU7zE()
		{
			return new MotionRangeStyleSurrogate(this);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly int[] _0023_003Dz5PjgdLvreIaQ44KYhQ_003D_003D = new int[24]
	{
		0, 1, 5, 0, 5, 4, 1, 2, 6, 1,
		6, 5, 2, 3, 7, 2, 7, 6, 3, 0,
		4, 3, 4, 7
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly int[] _0023_003DzbVGbqZJZFWV6qwIrBg_003D_003D = new int[36]
	{
		3, 2, 1, 3, 1, 0, 0, 1, 5, 0,
		5, 4, 1, 2, 6, 1, 6, 5, 2, 3,
		7, 2, 7, 6, 3, 0, 4, 3, 4, 7,
		4, 5, 6, 4, 6, 7
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly float[] _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D = new float[12]
	{
		-1f, 0f, 0f, 0f, -1f, 0f, 1f, 0f, 0f, 0f,
		1f, 0f
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Color _0023_003DzydaX3xW1RuPQ = Color.Magenta;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Color _0023_003Dz_0024WDW9ZCYKWI8hyJNxQ_003D_003D = Color.FromArgb(40, 40, 40);

	private Dictionary<string, Color> _styles;

	private List<MotionInterval> _motionIntervals;

	private List<MotionInterval> _motionIntervalsToDraw;

	private int _step;

	private bool _highlightCurrentLevel;

	private int _minL;

	private int _maxL;

	private IntInterval? _latestLevel;

	public int LayersCount => MotionsByLayer.Length;

	public int StepsCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < LayersCount; i++)
			{
				num += LayerStepsCount(i);
			}
			return num;
		}
	}

	public IntInterval[] MotionsByLayer { get; }

	public PrintSimulationMesh(Toolpath toolpath, IList<MotionInterval> ranges, Dictionary<string, Color> styles, Plane simulationPlane = null, float? travelWidthFactor = null)
		: base(_0023_003DzneuHX4GFvYpLmh9_0024UzhDlzI_003D(toolpath, (simulationPlane ?? Plane.XY).AxisZ, travelWidthFactor ?? _0023_003DzAspnlo5byIN31KGPjA_003D_003D(toolpath, (simulationPlane ?? Plane.XY).AxisZ, 0.15f)))
	{
		if (toolpath.MotionList.Count == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974588));
		}
		_0023_003Dz2cI422ziryBHT51kbU6kze4_003D(_0023_003DznTWHaead2G42nacJJZ7Peyc_003D(toolpath));
		_motionIntervals = new List<MotionInterval>(ranges);
		_0023_003Dza2wm_2wY3ZxJ(styles);
		ExtrudeTo(toolpath.MotionList.Count - 1, hightlightCurrentLayer: false);
	}

	public PrintSimulationMesh(Toolpath toolpath, Plane simulationPlane = null, Color? defaultColor = null, string defaultStyleName = "Default")
		: this(toolpath, new MotionInterval[1]
		{
			new MotionInterval(0, toolpath.MotionList.Count - 1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495))
		}, new Dictionary<string, Color> { 
		{
			defaultStyleName,
			defaultColor ?? _0023_003DzydaX3xW1RuPQ
		} }, simulationPlane)
	{
	}

	protected internal PrintSimulationMesh(PrintSimulationMesh other, bool keepTessellation = false)
		: base(other, keepTessellation)
	{
		_0023_003Dz2cI422ziryBHT51kbU6kze4_003D(new IntInterval[other.MotionsByLayer.Length]);
		Array.Copy(other.MotionsByLayer, MotionsByLayer, MotionsByLayer.Length);
		_motionIntervals = new List<MotionInterval>(other._motionIntervals);
		_motionIntervalsToDraw = new List<MotionInterval>(other._motionIntervalsToDraw);
		_styles = new Dictionary<string, Color>();
		foreach (KeyValuePair<string, Color> style in other._styles)
		{
			_styles[style.Key] = style.Value;
		}
	}

	protected internal PrintSimulationMesh(PrintSimulationMeshSurrogate surrogate)
		: base(surrogate)
	{
		_0023_003Dz2cI422ziryBHT51kbU6kze4_003D(_0023_003DzD3QnBxYg0jM_0024(surrogate.motionsByLevel).ToArray());
		_styles = surrogate.styleColors;
		_motionIntervals = _0023_003DzD3QnBxYg0jM_0024(surrogate.styleRanges).ToList();
		_motionIntervalsToDraw = _0023_003DzD3QnBxYg0jM_0024(surrogate.styleRangesToDraw).ToList();
	}

	protected PrintSimulationMesh(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_0023_003Dz2cI422ziryBHT51kbU6kze4_003D((IntInterval[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974538), typeof(IntInterval[])));
		_styles = (Dictionary<string, Color>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974527), typeof(Dictionary<string, Color>));
		_motionIntervals = (List<MotionInterval>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974484), typeof(List<MotionInterval>));
		_motionIntervalsToDraw = (List<MotionInterval>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974469), typeof(List<MotionInterval>));
	}

	private static void _0023_003DzqKowmqfb_XggKOX_0024mQ_003D_003D(Point3D _0023_003DzD96aR0k_003D, Point3D _0023_003DzGZE1eIs_003D, Vector3D _0023_003DzCBEAoWM_003D, float _0023_003DzNvvWKQRK2QV8, float _0023_003DzE3D9MtMnyhDk, out float[] _0023_003DzsSLPcz8_003D, out float[] _0023_003DzzYZPaELg0Y2i, out int[] _0023_003DzceNyInx9KKsG)
	{
		_0023_003DzsSLPcz8_003D = new float[24];
		_0023_003DzzYZPaELg0Y2i = new float[24];
		_0023_003DzceNyInx9KKsG = new int[_0023_003DzbVGbqZJZFWV6qwIrBg_003D_003D.Length];
		Vector3D asVector = (_0023_003DzGZE1eIs_003D - _0023_003DzD96aR0k_003D).AsVector;
		asVector.Normalize();
		Vector3D vector3D = Vector3D.Cross(_0023_003DzCBEAoWM_003D, asVector);
		vector3D.Normalize();
		Vector3D vector3D2 = Vector3D.Cross(asVector, vector3D);
		vector3D2.Normalize();
		float[] array = new float[16]
		{
			(float)vector3D.X,
			(float)vector3D2.X,
			(float)asVector.X,
			(float)_0023_003DzD96aR0k_003D.X,
			(float)vector3D.Y,
			(float)vector3D2.Y,
			(float)asVector.Y,
			(float)_0023_003DzD96aR0k_003D.Y,
			(float)vector3D.Z,
			(float)vector3D2.Z,
			(float)asVector.Z,
			(float)_0023_003DzD96aR0k_003D.Z,
			0f,
			0f,
			0f,
			1f
		};
		float num = (float)(_0023_003DzGZE1eIs_003D.X - _0023_003DzD96aR0k_003D.X);
		float num2 = (float)(_0023_003DzGZE1eIs_003D.Y - _0023_003DzD96aR0k_003D.Y);
		float num3 = (float)(_0023_003DzGZE1eIs_003D.Z - _0023_003DzD96aR0k_003D.Z);
		for (int i = 0; i < 4; i++)
		{
			float num4 = _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3];
			float num5 = _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 1];
			float num6 = _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 2];
			_0023_003DzsSLPcz8_003D[i * 3] = array[0] * _0023_003DzNvvWKQRK2QV8 * num4 + array[1] * _0023_003DzE3D9MtMnyhDk * num5 + array[2] * num6 + array[3];
			_0023_003DzsSLPcz8_003D[i * 3 + 1] = array[4] * _0023_003DzNvvWKQRK2QV8 * num4 + array[5] * _0023_003DzE3D9MtMnyhDk * num5 + array[6] * num6 + array[7];
			_0023_003DzsSLPcz8_003D[i * 3 + 2] = array[8] * _0023_003DzNvvWKQRK2QV8 * num4 + array[9] * _0023_003DzE3D9MtMnyhDk * num5 + array[10] * num6 + array[11];
			_0023_003DzzYZPaELg0Y2i[i * 3] = array[0] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3] + array[1] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 1] + array[2] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 2];
			_0023_003DzzYZPaELg0Y2i[i * 3 + 1] = array[4] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3] + array[5] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 1] + array[6] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 2];
			_0023_003DzzYZPaELg0Y2i[i * 3 + 2] = array[8] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3] + array[9] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 1] + array[10] * _0023_003Dzidfa1ED20EIMzVh8zQ_003D_003D[i * 3 + 2];
		}
		for (int j = 0; j < 4; j++)
		{
			_0023_003DzsSLPcz8_003D[j * 3 + 12] = _0023_003DzsSLPcz8_003D[j * 3] + num;
			_0023_003DzsSLPcz8_003D[j * 3 + 1 + 12] = _0023_003DzsSLPcz8_003D[j * 3 + 1] + num2;
			_0023_003DzsSLPcz8_003D[j * 3 + 2 + 12] = _0023_003DzsSLPcz8_003D[j * 3 + 2] + num3;
			_0023_003DzzYZPaELg0Y2i[j * 3 + 12] = _0023_003DzzYZPaELg0Y2i[j * 3];
			_0023_003DzzYZPaELg0Y2i[j * 3 + 1 + 12] = _0023_003DzzYZPaELg0Y2i[j * 3 + 1];
			_0023_003DzzYZPaELg0Y2i[j * 3 + 2 + 12] = _0023_003DzzYZPaELg0Y2i[j * 3 + 2];
		}
		Array.Copy(_0023_003DzbVGbqZJZFWV6qwIrBg_003D_003D, _0023_003DzceNyInx9KKsG, _0023_003DzceNyInx9KKsG.Length);
	}

	private static FastMesh _0023_003DzqKowmqfb_XggKOX_0024mQ_003D_003D(Line _0023_003DzQ9zpGF0_003D, Vector3D _0023_003DzCBEAoWM_003D, float _0023_003DzNvvWKQRK2QV8, float _0023_003DzE3D9MtMnyhDk)
	{
		_0023_003DzqKowmqfb_XggKOX_0024mQ_003D_003D(_0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint, _0023_003DzCBEAoWM_003D, _0023_003DzNvvWKQRK2QV8, _0023_003DzE3D9MtMnyhDk, out var _0023_003DzsSLPcz8_003D, out var _0023_003DzzYZPaELg0Y2i, out var _0023_003DzceNyInx9KKsG);
		return new FastMesh(_0023_003DzsSLPcz8_003D, _0023_003DzceNyInx9KKsG, _0023_003DzzYZPaELg0Y2i);
	}

	public int LayerStepsCount(int layer)
	{
		if (layer >= LayersCount || layer < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		return MotionsByLayer[layer].End - MotionsByLayer[layer].Start + 1;
	}

	public void ExtrudeTo(int motionIndex, bool hightlightCurrentLayer, int? minLayer = null, int? maxLayer = null)
	{
		if (motionIndex < 0 || motionIndex > MotionsByLayer.Last().End)
		{
			throw new ArgumentOutOfRangeException();
		}
		_step = motionIndex;
		_highlightCurrentLevel = hightlightCurrentLayer;
		_minL = minLayer.GetValueOrDefault();
		_maxL = maxLayer ?? (MotionsByLayer.Length - 1);
		_0023_003Dzy5TXmgoYWBLb(motionIndex, hightlightCurrentLayer, minLayer, maxLayer);
		_0023_003Dzz0xlFkw_003D();
	}

	public void SetVisualStyle(IList<MotionInterval> styleRanges, Dictionary<string, Color> styles)
	{
		_motionIntervals = new List<MotionInterval>(styleRanges);
		_0023_003Dza2wm_2wY3ZxJ(styles);
		ExtrudeTo(_step, _highlightCurrentLevel, _minL, _maxL);
	}

	public Color GetStyleColor(string styleName)
	{
		if (_styles.TryGetValue(styleName, out var value))
		{
			return value;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974690) + styleName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974667));
	}

	public void SetStyleColor(string styleName, Color color)
	{
		if (_styles.ContainsKey(styleName))
		{
			_styles[styleName] = color;
			ExtrudeTo(_step, _highlightCurrentLevel, _minL, _maxL);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974690) + styleName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974667));
	}

	private void _0023_003Dz2cI422ziryBHT51kbU6kze4_003D(IntInterval[] _0023_003DzPzO_0024GUk_003D)
	{
		MotionsByLayer = _0023_003DzPzO_0024GUk_003D;
	}

	internal Dictionary<string, Color> _0023_003Dz5uTfw_0024M6HLKSYSW8iw_003D_003D()
	{
		return _styles;
	}

	internal List<MotionInterval> _0023_003DzIo59z2K4DQp5kDt43JpS3MDl6pOU()
	{
		return _motionIntervals;
	}

	internal List<MotionInterval> _0023_003DzbUCR7FseKe01IU_0024huL_0mjaYYckaZbWYmw_003D_003D()
	{
		return _motionIntervalsToDraw;
	}

	public override object Clone()
	{
		return new PrintSimulationMesh(this);
	}

	public override object CloneWithTessellation()
	{
		return new PrintSimulationMesh(this, RegenMode != regenType.RegenAndCompile);
	}

	internal static IEnumerable<IntInterval> _0023_003DzD3QnBxYg0jM_0024(IList<MotionRange> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzGAEswMOVZdtVkvJ4NPBRkoE_003D);
	}

	internal new static IEnumerable<MotionRange> _0023_003Dzvv6hJ9KR6NHc(IList<IntInterval> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D.Select((IntInterval _0023_003DzuwH5j5s_003D) => new MotionRange(_0023_003DzuwH5j5s_003D.Start, _0023_003DzuwH5j5s_003D.End));
	}

	internal static IEnumerable<MotionInterval> _0023_003DzD3QnBxYg0jM_0024(IList<MotionRangeStyle> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzHkem5NTZ5hjqnV92BvmZ4rs_003D);
	}

	internal static IEnumerable<MotionRangeStyle> _0023_003DzVwW60Dtlh1G8E_4Wi06KgZQ_003D(IList<MotionInterval> _0023_003Dzb7SPTpc_003D)
	{
		return _0023_003Dzb7SPTpc_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz7rfoLyhqtUvMoEnNQ894hE9IrB0PcZTEsA_003D_003D);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new PrintSimulationMeshSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974538), MotionsByLayer);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974527), _styles);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974484), _motionIntervals);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974469), _motionIntervalsToDraw);
	}

	private void _0023_003Dza2wm_2wY3ZxJ(Dictionary<string, Color> _0023_003DzcnPftdo_003D)
	{
		_styles = new Dictionary<string, Color>(_0023_003DzcnPftdo_003D);
		_styles[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974628)] = _0023_003Dz_0024WDW9ZCYKWI8hyJNxQ_003D_003D;
	}

	private static float _0023_003DzAspnlo5byIN31KGPjA_003D_003D(Toolpath _0023_003DzySVR620_003D, Vector3D _0023_003Dz3JYqu3AVDXFp, float _0023_003DzwzMn4TDvq4kF)
	{
		Toolpath.Motion motion = _0023_003DzySVR620_003D.MotionList[0];
		double num = Vector3D.Dot(_0023_003DzySVR620_003D.MotionList[_0023_003DzySVR620_003D.MotionList.Capacity - 1].StartPoint - motion.EndPoint, _0023_003Dz3JYqu3AVDXFp);
		return _0023_003DzwzMn4TDvq4kF * (float)num / (float)Math.Max(_0023_003DzySVR620_003D.MotionList.Last().PrintLayer, 1);
	}

	private IList<IntInterval> _0023_003DzVf_5tAJdiaO7(Toolpath _0023_003DzySVR620_003D, Predicate<Toolpath.Motion> _0023_003DzV_0024Ui4m7SpXBg)
	{
		int num = -1;
		List<IntInterval> list = new List<IntInterval>();
		for (int i = 0; i < _0023_003DzySVR620_003D.MotionList.Count; i++)
		{
			Toolpath.Motion obj = _0023_003DzySVR620_003D.MotionList[i];
			if (_0023_003DzV_0024Ui4m7SpXBg(obj))
			{
				num = ((num < 0) ? i : num);
			}
			else if (num >= 0)
			{
				list.Add(new IntInterval(num, i - 1));
				num = -1;
			}
		}
		if (num >= 0)
		{
			list.Add(new IntInterval(num, _0023_003DzySVR620_003D.MotionList.Count - 1));
		}
		return list;
	}

	private static void _0023_003Dz5S_0024o8upNqk0v(Toolpath.Motion _0023_003DzdoW7ToAWvN60)
	{
		if (!(_0023_003DzdoW7ToAWvN60 is Toolpath.LinearMotion))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974639) + _0023_003DzdoW7ToAWvN60.GetType().ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975355));
		}
	}

	private static IntInterval[] _0023_003DznTWHaead2G42nacJJZ7Peyc_003D(Toolpath _0023_003DzySVR620_003D)
	{
		if (_0023_003DzySVR620_003D.MotionList.Count == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975312));
		}
		Toolpath.Motion motion = _0023_003DzySVR620_003D.MotionList.First();
		_0023_003Dz5S_0024o8upNqk0v(motion);
		if (((Toolpath.LinearMotion)motion).PrintLayer != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975481));
		}
		Toolpath.Motion motion2 = _0023_003DzySVR620_003D.MotionList.Last();
		_0023_003Dz5S_0024o8upNqk0v(motion2);
		IntInterval[] array = new IntInterval[((Toolpath.LinearMotion)motion2).PrintLayer + 1];
		int num = 0;
		int start = 0;
		for (int i = 0; i < _0023_003DzySVR620_003D.MotionList.Count; i++)
		{
			_0023_003Dz5S_0024o8upNqk0v(_0023_003DzySVR620_003D.MotionList[i]);
			Toolpath.LinearMotion linearMotion = (Toolpath.LinearMotion)_0023_003DzySVR620_003D.MotionList[i];
			if (linearMotion.PrintLayer != num)
			{
				if (linearMotion.PrintLayer != num + 1)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975405));
				}
				array[num] = new IntInterval(start, i - 1);
				num = linearMotion.PrintLayer;
				start = i;
			}
		}
		array[num] = new IntInterval(start, _0023_003DzySVR620_003D.MotionList.Count - 1);
		return array;
	}

	private static bool _0023_003Dz7S3KExhAsblN(Toolpath.LinearMotion _0023_003DzlIqj_Zk_003D)
	{
		if (_0023_003DzlIqj_Zk_003D.Code != motionType.G01)
		{
			return _0023_003DzlIqj_Zk_003D.Code != motionType.G00;
		}
		return false;
	}

	private static bool _0023_003Dz7OTFkhaGteXdYf_0024nkA_003D_003D(Toolpath.LinearMotion _0023_003DzlIqj_Zk_003D)
	{
		return _0023_003DzlIqj_Zk_003D.Code == motionType.G00;
	}

	private static bool _0023_003Dz9KjjikcKs01rM_0024vk2w_003D_003D(Toolpath.LinearMotion _0023_003DzPuH9cYsal_0024El, Toolpath.LinearMotion _0023_003Dz8UXzXB41mSoV)
	{
		if (_0023_003DzPuH9cYsal_0024El.Code == motionType.G01)
		{
			return _0023_003Dz8UXzXB41mSoV.Code == motionType.G01;
		}
		return false;
	}

	private static void _0023_003DzLvrwtezM6BuZdtHYGA_003D_003D(int[] _0023_003DzceNyInx9KKsG, int _0023_003DzfBEBL_o_003D)
	{
		for (int i = 0; i < _0023_003DzceNyInx9KKsG.Length; i++)
		{
			_0023_003DzceNyInx9KKsG[i] += _0023_003DzfBEBL_o_003D;
		}
	}

	private static void _0023_003Dz2ZgriLETGs1llxudJA_003D_003D(Point3D _0023_003DzD96aR0k_003D, Point3D _0023_003DzGZE1eIs_003D, Vector3D _0023_003Dz3JYqu3AVDXFp, float _0023_003DzitQT9ceeaqqs, float _0023_003DzvnJsOkCm9kMN, bool _0023_003DzJWSqCk7KA8UL, ref float[] _0023_003DzrdSL0CI_003D, int _0023_003Dz8WptWNGZ_00245Go, ref float[] _0023_003DzztJY0_0024dXEFMk, int _0023_003Dz2dYv2Av7_0024VkeDRK1fA_003D_003D, ref int[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, int _0023_003DzA37I9nwbSkYHHwHE4g_003D_003D, out int _0023_003DzZs09F7FzqLbY, out int _0023_003DzpFS5T_TzsvROab9i2g_003D_003D, out int _0023_003DzOEm_KDWyV9E2g2Zl_0024Q_003D_003D)
	{
		if (_0023_003DzitQT9ceeaqqs == 0f || _0023_003DzvnJsOkCm9kMN == 0f)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975047));
		}
		_0023_003DzqKowmqfb_XggKOX_0024mQ_003D_003D(_0023_003DzD96aR0k_003D, _0023_003DzGZE1eIs_003D, _0023_003Dz3JYqu3AVDXFp, _0023_003DzitQT9ceeaqqs, _0023_003DzvnJsOkCm9kMN, out var _0023_003DzsSLPcz8_003D, out var _0023_003DzzYZPaELg0Y2i, out var _0023_003DzceNyInx9KKsG);
		Array.Copy(_0023_003DzsSLPcz8_003D, 0, _0023_003DzrdSL0CI_003D, _0023_003Dz8WptWNGZ_00245Go, _0023_003DzsSLPcz8_003D.Length);
		Array.Copy(_0023_003DzzYZPaELg0Y2i, 0, _0023_003DzztJY0_0024dXEFMk, _0023_003Dz2dYv2Av7_0024VkeDRK1fA_003D_003D, _0023_003DzzYZPaELg0Y2i.Length);
		_0023_003DzLvrwtezM6BuZdtHYGA_003D_003D(_0023_003DzceNyInx9KKsG, _0023_003Dz8WptWNGZ_00245Go / 3);
		Array.Copy(_0023_003DzceNyInx9KKsG, 0, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzA37I9nwbSkYHHwHE4g_003D_003D, _0023_003DzceNyInx9KKsG.Length);
		_0023_003DzZs09F7FzqLbY = _0023_003DzsSLPcz8_003D.Length;
		_0023_003DzpFS5T_TzsvROab9i2g_003D_003D = _0023_003DzzYZPaELg0Y2i.Length;
		_0023_003DzOEm_KDWyV9E2g2Zl_0024Q_003D_003D = _0023_003DzceNyInx9KKsG.Length;
		if (_0023_003DzJWSqCk7KA8UL)
		{
			int num = _0023_003Dz5PjgdLvreIaQ44KYhQ_003D_003D.Length;
			int[] array = new int[num];
			Array.Copy(_0023_003Dz5PjgdLvreIaQ44KYhQ_003D_003D, array, num);
			_0023_003DzLvrwtezM6BuZdtHYGA_003D_003D(array, _0023_003Dz8WptWNGZ_00245Go / 3 - 4);
			Array.Copy(array, 0, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzA37I9nwbSkYHHwHE4g_003D_003D + _0023_003DzceNyInx9KKsG.Length, num);
			_0023_003DzOEm_KDWyV9E2g2Zl_0024Q_003D_003D += num;
		}
	}

	private static MultiFastMesh _0023_003DzneuHX4GFvYpLmh9_0024UzhDlzI_003D(Toolpath _0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D, Vector3D _0023_003Dz3JYqu3AVDXFp, float _0023_003DzzDhP9W4bHp_ghYP0Pw_003D_003D)
	{
		int count = _0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D.MotionList.Count;
		float[] _0023_003DzrdSL0CI_003D = new float[count * 8 * 3];
		float[] _0023_003DzztJY0_0024dXEFMk = new float[count * 8 * 3];
		int[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new int[count * _0023_003DzbVGbqZJZFWV6qwIrBg_003D_003D.Length * 2];
		IntInterval[] array = new IntInterval[count];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < _0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D.MotionList.Count; i++)
		{
			if (!(_0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D.MotionList[i] is Toolpath.LinearMotion))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974989));
			}
			Toolpath.LinearMotion linearMotion = (Toolpath.LinearMotion)_0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D.MotionList[i];
			if (!_0023_003Dz7S3KExhAsblN(linearMotion))
			{
				bool _0023_003DzJWSqCk7KA8UL = i > 0 && _0023_003Dz9KjjikcKs01rM_0024vk2w_003D_003D(linearMotion, (Toolpath.LinearMotion)_0023_003Dz_eBXzIwIpnfkzffQzw_003D_003D.MotionList[i - 1]);
				float _0023_003DzitQT9ceeaqqs = (_0023_003Dz7OTFkhaGteXdYf_0024nkA_003D_003D(linearMotion) ? _0023_003DzzDhP9W4bHp_ghYP0Pw_003D_003D : linearMotion.PrintExtrusionRadiusX);
				float _0023_003DzvnJsOkCm9kMN = (_0023_003Dz7OTFkhaGteXdYf_0024nkA_003D_003D(linearMotion) ? _0023_003DzzDhP9W4bHp_ghYP0Pw_003D_003D : linearMotion.PrintExtrusionRadiusY);
				_0023_003Dz2ZgriLETGs1llxudJA_003D_003D(linearMotion.StartPoint, linearMotion.EndPoint, _0023_003Dz3JYqu3AVDXFp, _0023_003DzitQT9ceeaqqs, _0023_003DzvnJsOkCm9kMN, _0023_003DzJWSqCk7KA8UL, ref _0023_003DzrdSL0CI_003D, num, ref _0023_003DzztJY0_0024dXEFMk, num, ref _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, num2, out var _0023_003DzZs09F7FzqLbY, out var _, out var _0023_003DzOEm_KDWyV9E2g2Zl_0024Q_003D_003D);
				array[num3] = new IntInterval(num2, num2 + _0023_003DzOEm_KDWyV9E2g2Zl_0024Q_003D_003D);
				num2 += _0023_003DzOEm_KDWyV9E2g2Zl_0024Q_003D_003D;
				num += _0023_003DzZs09F7FzqLbY;
			}
			else
			{
				Array.Copy(new float[3], 0, _0023_003DzrdSL0CI_003D, num, 3);
				Array.Copy(new float[3] { 0f, 0f, 1f }, 0, _0023_003DzztJY0_0024dXEFMk, num, 3);
				Array.Copy(new int[3], 0, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, num2, 3);
				array[num3] = new IntInterval(num2, num2 + 3);
				num2 += 3;
				num += 3;
			}
			num3++;
		}
		Array.Resize(ref _0023_003DzrdSL0CI_003D, num);
		Array.Resize(ref _0023_003DzztJY0_0024dXEFMk, num);
		Array.Resize(ref _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, num2);
		Array.Resize(ref array, num3);
		return new MultiFastMesh(_0023_003DzrdSL0CI_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, array);
	}

	private bool _0023_003Dzt9DBA5BU2Uz9(string _0023_003DzMc5f1FY_003D)
	{
		return _0023_003DzSonG_wLQYsdL(_0023_003DzMc5f1FY_003D).A > 0;
	}

	private Color _0023_003DzSonG_wLQYsdL(string _0023_003DzMc5f1FY_003D)
	{
		if (_styles.TryGetValue(_0023_003DzMc5f1FY_003D, out var value))
		{
			return value;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975140) + _0023_003DzMc5f1FY_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975865));
	}

	private static IntInterval? _0023_003DzjEbe97N1kIQV(int _0023_003DzPzO_0024GUk_003D, IList<IntInterval> _0023_003DzALQAPd7HMtS380Ir_0024A_003D_003D)
	{
		for (int i = 0; i < _0023_003DzALQAPd7HMtS380Ir_0024A_003D_003D.Count; i++)
		{
			if (_0023_003DzALQAPd7HMtS380Ir_0024A_003D_003D[i].ContainsValue(_0023_003DzPzO_0024GUk_003D))
			{
				return _0023_003DzALQAPd7HMtS380Ir_0024A_003D_003D[i];
			}
		}
		return null;
	}

	private IntInterval? _0023_003DzEs4z_00242e_7aol(int _0023_003Dzo8SBWVauXont)
	{
		if (_latestLevel.HasValue && _latestLevel.Value.ContainsValue(_0023_003Dzo8SBWVauXont))
		{
			return _latestLevel;
		}
		_latestLevel = _0023_003DzjEbe97N1kIQV(_0023_003Dzo8SBWVauXont, MotionsByLayer);
		return _latestLevel;
	}

	private void _0023_003Dzy5TXmgoYWBLb(int _0023_003DzIrPGUnY_003D, bool _0023_003DznuqCqDRdT0ocg47TaQ_003D_003D, int? _0023_003DzBMl6fFS_I5q_0024, int? _0023_003DzY8qwWXazwYMh)
	{
		int valueOrDefault = _0023_003DzBMl6fFS_I5q_0024.GetValueOrDefault();
		int num = _0023_003DzY8qwWXazwYMh ?? (MotionsByLayer.Length - 1);
		if (_motionIntervalsToDraw == null)
		{
			_motionIntervalsToDraw = new List<MotionInterval>();
		}
		_motionIntervalsToDraw.Clear();
		if (valueOrDefault > num)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975844) + string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975840), valueOrDefault, num));
		}
		IntInterval? intInterval = _0023_003DzEs4z_00242e_7aol(_0023_003DzIrPGUnY_003D);
		if (!intInterval.HasValue)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975790));
		}
		IntInterval.Intersection(new IntInterval(MotionsByLayer[valueOrDefault].Start, MotionsByLayer[num].End), new IntInterval(0, _0023_003DzIrPGUnY_003D), out var i);
		if (!i.HasValue)
		{
			return;
		}
		foreach (MotionInterval motionInterval in _motionIntervals)
		{
			if (!_0023_003Dzt9DBA5BU2Uz9(motionInterval.StyleName))
			{
				continue;
			}
			IntInterval.Intersection(motionInterval.Motions, i.Value, out var i2);
			if (i2.HasValue)
			{
				string styleName = motionInterval.StyleName;
				if (_0023_003DznuqCqDRdT0ocg47TaQ_003D_003D && IntInterval.Disjoint(intInterval.Value, motionInterval.Motions))
				{
					styleName = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974628);
				}
				_motionIntervalsToDraw.Add(new MotionInterval(i2.Value, styleName));
			}
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		base.Draw(data);
	}

	private void _0023_003Dzz0xlFkw_003D()
	{
		base.SubMeshIntervals.Clear();
		foreach (MotionInterval item in _motionIntervalsToDraw)
		{
			List<SubMeshInterval> subMeshIntervals = base.SubMeshIntervals;
			IntInterval motions = item.Motions;
			int start = motions.Start;
			motions = item.Motions;
			subMeshIntervals.Add(new SubMeshInterval(start, motions.End, _0023_003DzSonG_wLQYsdL(item.StyleName)));
		}
	}
}
