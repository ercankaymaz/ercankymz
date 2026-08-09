using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_SPACEHINTS : IContentEquatable<JET_SPACEHINTS>, IDeepCloneable<JET_SPACEHINTS>
{
	private int initialDensity;

	private int initialSize;

	private SpaceHintsGrbit options;

	private int maintenanceDensity;

	private int growthPercent;

	private int minimumExtent;

	private int maximumExtent;

	public int ulInitialDensity
	{
		[DebuggerStepThrough]
		get
		{
			return initialDensity;
		}
		set
		{
			initialDensity = value;
		}
	}

	public int cbInitial
	{
		[DebuggerStepThrough]
		get
		{
			return initialSize;
		}
		set
		{
			initialSize = value;
		}
	}

	public SpaceHintsGrbit grbit
	{
		[DebuggerStepThrough]
		get
		{
			return options;
		}
		set
		{
			options = value;
		}
	}

	public int ulMaintDensity
	{
		[DebuggerStepThrough]
		get
		{
			return maintenanceDensity;
		}
		set
		{
			maintenanceDensity = value;
		}
	}

	public int ulGrowth
	{
		[DebuggerStepThrough]
		get
		{
			return growthPercent;
		}
		set
		{
			growthPercent = value;
		}
	}

	public int cbMinExtent
	{
		[DebuggerStepThrough]
		get
		{
			return minimumExtent;
		}
		set
		{
			minimumExtent = value;
		}
	}

	public int cbMaxExtent
	{
		[DebuggerStepThrough]
		get
		{
			return maximumExtent;
		}
		set
		{
			maximumExtent = value;
		}
	}

	public bool ContentEquals(JET_SPACEHINTS other)
	{
		if (other == null)
		{
			return false;
		}
		if (ulInitialDensity == other.ulInitialDensity && cbInitial == other.cbInitial && grbit == other.grbit && ulMaintDensity == other.ulMaintDensity && ulGrowth == other.ulGrowth && cbMinExtent == other.cbMinExtent)
		{
			return cbMaxExtent == other.cbMaxExtent;
		}
		return false;
	}

	public JET_SPACEHINTS DeepClone()
	{
		return (JET_SPACEHINTS)MemberwiseClone();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_SPACEHINTS({0})", grbit);
	}

	internal NATIVE_SPACEHINTS GetNativeSpaceHints()
	{
		return checked(new NATIVE_SPACEHINTS
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_SPACEHINTS)),
			ulInitialDensity = (uint)ulInitialDensity,
			cbInitial = (uint)cbInitial,
			grbit = (uint)grbit,
			ulMaintDensity = (uint)ulMaintDensity,
			ulGrowth = (uint)ulGrowth,
			cbMinExtent = (uint)cbMinExtent,
			cbMaxExtent = (uint)cbMaxExtent
		});
	}

	internal void SetFromNativeSpaceHints(NATIVE_SPACEHINTS value)
	{
		checked
		{
			ulInitialDensity = (int)value.ulInitialDensity;
			cbInitial = (int)value.cbInitial;
		}
		grbit = (SpaceHintsGrbit)checked((int)value.grbit);
		checked
		{
			ulMaintDensity = (int)value.ulMaintDensity;
			ulGrowth = (int)value.ulGrowth;
			cbMinExtent = (int)value.cbMinExtent;
			cbMaxExtent = (int)value.cbMaxExtent;
		}
	}
}
