using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Windows8;

[Serializable]
public sealed class JET_ERRINFOBASIC : IContentEquatable<JET_ERRINFOBASIC>, IDeepCloneable<JET_ERRINFOBASIC>
{
	private JET_err errorValue;

	private JET_ERRCAT errorcatMostSpecific;

	private JET_ERRCAT[] arrayCategoricalHierarchy;

	private int sourceLine;

	private string sourceFile;

	public JET_err errValue
	{
		[DebuggerStepThrough]
		get
		{
			return errorValue;
		}
		set
		{
			errorValue = value;
		}
	}

	public JET_ERRCAT errcat
	{
		[DebuggerStepThrough]
		get
		{
			return errorcatMostSpecific;
		}
		set
		{
			errorcatMostSpecific = value;
		}
	}

	public JET_ERRCAT[] rgCategoricalHierarchy
	{
		[DebuggerStepThrough]
		get
		{
			return arrayCategoricalHierarchy;
		}
		set
		{
			arrayCategoricalHierarchy = value;
		}
	}

	public int lSourceLine
	{
		[DebuggerStepThrough]
		get
		{
			return sourceLine;
		}
		set
		{
			sourceLine = value;
		}
	}

	public string rgszSourceFile
	{
		[DebuggerStepThrough]
		get
		{
			return sourceFile;
		}
		set
		{
			sourceFile = value;
		}
	}

	public JET_ERRINFOBASIC()
	{
		rgCategoricalHierarchy = new JET_ERRCAT[8];
	}

	public JET_ERRINFOBASIC DeepClone()
	{
		return (JET_ERRINFOBASIC)MemberwiseClone();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_ERRINFOBASIC({0}:{1}:{2}:{3})", errValue, errcat, rgszSourceFile, lSourceLine);
	}

	public bool ContentEquals(JET_ERRINFOBASIC other)
	{
		if (other == null)
		{
			return false;
		}
		if (errValue == other.errValue && errcat == other.errcat && lSourceLine == other.lSourceLine && rgszSourceFile == other.rgszSourceFile)
		{
			return Util.ArrayStructEquals(rgCategoricalHierarchy, other.rgCategoricalHierarchy, (rgCategoricalHierarchy != null) ? rgCategoricalHierarchy.Length : 0);
		}
		return false;
	}

	internal NATIVE_ERRINFOBASIC GetNativeErrInfo()
	{
		checked
		{
			NATIVE_ERRINFOBASIC result = new NATIVE_ERRINFOBASIC
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_ERRINFOBASIC)),
				errValue = errValue,
				errcatMostSpecific = errcat,
				rgCategoricalHierarchy = new byte[8]
			};
			if (rgCategoricalHierarchy != null)
			{
				for (int i = 0; i < rgCategoricalHierarchy.Length; i++)
				{
					result.rgCategoricalHierarchy[i] = (byte)rgCategoricalHierarchy[i];
				}
			}
			result.lSourceLine = (uint)lSourceLine;
			result.rgszSourceFile = rgszSourceFile;
			return result;
		}
	}

	internal void SetFromNative(ref NATIVE_ERRINFOBASIC value)
	{
		errValue = value.errValue;
		errcat = value.errcatMostSpecific;
		if (value.rgCategoricalHierarchy != null)
		{
			for (int i = 0; i < value.rgCategoricalHierarchy.Length; i++)
			{
				rgCategoricalHierarchy[i] = (JET_ERRCAT)value.rgCategoricalHierarchy[i];
			}
		}
		lSourceLine = (int)value.lSourceLine;
		rgszSourceFile = value.rgszSourceFile;
	}
}
