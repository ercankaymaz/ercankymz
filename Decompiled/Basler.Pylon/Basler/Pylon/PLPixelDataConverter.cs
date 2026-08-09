using System.ComponentModel;

namespace Basler.Pylon;

public static class PLPixelDataConverter
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class InconvertibleEdgeHandlingEnum : ParameterListEnum
	{
		public override string Name => "@PixelDataConverter/InconvertibleEdgeHandling";

		public string SetZero => "SetZero";

		public string Extend => "Extend";

		public string Clip => "Clip";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class MonoConversionMethodEnum : ParameterListEnum
	{
		public override string Name => "@PixelDataConverter/MonoConversionMethod";

		public string Truncate => "Truncate";

		public string Gamma => "Gamma";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OutputBitAlignmentEnum : ParameterListEnum
	{
		public override string Name => "@PixelDataConverter/OutputBitAlignment";

		public string MsbAligned => "MsbAligned";

		public string LsbAligned => "LsbAligned";

		public override string ToString()
		{
			return Name;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OutputOrientationEnum : ParameterListEnum
	{
		public override string Name => "@PixelDataConverter/OutputOrientation";

		public string Unchanged => "Unchanged";

		public string TopDown => "TopDown";

		public string BottomUp => "BottomUp";

		public override string ToString()
		{
			return Name;
		}
	}

	private static InconvertibleEdgeHandlingEnum m_InconvertibleEdgeHandlingCached = null;

	private static MonoConversionMethodEnum m_MonoConversionMethodCached = null;

	private static OutputBitAlignmentEnum m_OutputBitAlignmentCached = null;

	private static OutputOrientationEnum m_OutputOrientationCached = null;

	public static IntegerName OutputPaddingX => new IntegerName("@PixelDataConverter/OutputPaddingX");

	public static OutputOrientationEnum OutputOrientation
	{
		get
		{
			if (m_OutputOrientationCached == null)
			{
				m_OutputOrientationCached = new OutputOrientationEnum();
			}
			return m_OutputOrientationCached;
		}
	}

	public static OutputBitAlignmentEnum OutputBitAlignment
	{
		get
		{
			if (m_OutputBitAlignmentCached == null)
			{
				m_OutputBitAlignmentCached = new OutputBitAlignmentEnum();
			}
			return m_OutputBitAlignmentCached;
		}
	}

	public static MonoConversionMethodEnum MonoConversionMethod
	{
		get
		{
			if (m_MonoConversionMethodCached == null)
			{
				m_MonoConversionMethodCached = new MonoConversionMethodEnum();
			}
			return m_MonoConversionMethodCached;
		}
	}

	public static IntegerName MaxNumThreads => new IntegerName("@PixelDataConverter/MaxNumThreads");

	public static InconvertibleEdgeHandlingEnum InconvertibleEdgeHandling
	{
		get
		{
			if (m_InconvertibleEdgeHandlingCached == null)
			{
				m_InconvertibleEdgeHandlingCached = new InconvertibleEdgeHandlingEnum();
			}
			return m_InconvertibleEdgeHandlingCached;
		}
	}

	public static FloatName Gamma => new FloatName("@PixelDataConverter/Gamma");

	public static IntegerName AdditionalLeftShift => new IntegerName("@PixelDataConverter/AdditionalLeftShift");
}
