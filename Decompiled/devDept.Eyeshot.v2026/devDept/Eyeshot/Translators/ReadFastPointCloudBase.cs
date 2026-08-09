using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public abstract class ReadFastPointCloudBase : ReadFileAsync
{
	public enum formatType
	{
		Plain,
		Colors,
		Intensity,
		Classification
	}

	protected formatType _formatType;

	protected float[] points = new float[0];

	protected ushort maxIntensity;

	protected ushort minIntensity = ushort.MaxValue;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzlpPRfKZqAWd0MqVvxg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzHD2B_snQFOY9Qn9Zvw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ushort[] _0023_003DzJUzzmJbdiiPOsbgdfNr9lwEG638J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzuXGGqtGDIdclSLgqFKM4Xvg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzP2PxhgtBhBFpz8W5_i_eHms_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzRgvL52lPv3ksyz1cwpJ5emeIe94SJTHtIg_003D_003D;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public double[] Coordinates
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzlpPRfKZqAWd0MqVvxg_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzlpPRfKZqAWd0MqVvxg_003D_003D = value;
		}
	}

	public byte[] Colors
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzHD2B_snQFOY9Qn9Zvw_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzHD2B_snQFOY9Qn9Zvw_003D_003D = value;
		}
	}

	public ushort[] Intensities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJUzzmJbdiiPOsbgdfNr9lwEG638J;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzJUzzmJbdiiPOsbgdfNr9lwEG638J = value;
		}
	}

	public bool FillCoordinates
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzuXGGqtGDIdclSLgqFKM4Xvg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzuXGGqtGDIdclSLgqFKM4Xvg_003D = value;
		}
	}

	public bool FillColors
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzP2PxhgtBhBFpz8W5_i_eHms_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzP2PxhgtBhBFpz8W5_i_eHms_003D = value;
		}
	}

	public bool FillIntensities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRgvL52lPv3ksyz1cwpJ5emeIe94SJTHtIg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRgvL52lPv3ksyz1cwpJ5emeIe94SJTHtIg_003D_003D = value;
		}
	}

	protected ReadFastPointCloudBase(string filePath, formatType formatType = formatType.Plain)
		: base(filePath)
	{
		_formatType = formatType;
	}

	protected ReadFastPointCloudBase(Stream s, formatType formatType = formatType.Plain)
		: base(s)
	{
		_formatType = formatType;
	}
}
