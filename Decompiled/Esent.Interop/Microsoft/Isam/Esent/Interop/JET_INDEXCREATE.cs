using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_INDEXCREATE : IContentEquatable<JET_INDEXCREATE>, IDeepCloneable<JET_INDEXCREATE>
{
	internal struct NATIVE_INDEXCREATE
	{
		public uint cbStruct;

		public IntPtr szIndexName;

		public IntPtr szKey;

		public uint cbKey;

		public uint grbit;

		public uint ulDensity;

		public unsafe NATIVE_UNICODEINDEX* pidxUnicode;

		public IntPtr cbVarSegMac;

		public IntPtr rgconditionalcolumn;

		public uint cConditionalColumn;

		public int err;
	}

	internal struct NATIVE_INDEXCREATE2
	{
		public NATIVE_INDEXCREATE1 indexcreate1;

		public IntPtr pSpaceHints;
	}

	internal struct NATIVE_INDEXCREATE1
	{
		public NATIVE_INDEXCREATE indexcreate;

		public uint cbKeyMost;
	}

	private string name;

	private string key;

	private int keyLength;

	private CreateIndexGrbit options;

	private int density;

	private JET_UNICODEINDEX unicodeOptions;

	private int maxSegmentLength;

	private JET_CONDITIONALCOLUMN[] conditionalColumns;

	private int numConditionalColumns;

	private JET_err errorCode;

	private int maximumKeyLength;

	private JET_SPACEHINTS spaceHints;

	public JET_err err
	{
		[DebuggerStepThrough]
		get
		{
			return errorCode;
		}
		set
		{
			errorCode = value;
		}
	}

	public string szIndexName
	{
		[DebuggerStepThrough]
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public string szKey
	{
		[DebuggerStepThrough]
		get
		{
			return key;
		}
		set
		{
			key = value;
		}
	}

	public int cbKey
	{
		[DebuggerStepThrough]
		get
		{
			return keyLength;
		}
		set
		{
			keyLength = value;
		}
	}

	public CreateIndexGrbit grbit
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

	public int ulDensity
	{
		[DebuggerStepThrough]
		get
		{
			return density;
		}
		set
		{
			density = value;
		}
	}

	public JET_UNICODEINDEX pidxUnicode
	{
		[DebuggerStepThrough]
		get
		{
			return unicodeOptions;
		}
		set
		{
			unicodeOptions = value;
		}
	}

	public int cbVarSegMac
	{
		[DebuggerStepThrough]
		get
		{
			return maxSegmentLength;
		}
		set
		{
			maxSegmentLength = value;
		}
	}

	public JET_CONDITIONALCOLUMN[] rgconditionalcolumn
	{
		[DebuggerStepThrough]
		get
		{
			return conditionalColumns;
		}
		set
		{
			conditionalColumns = value;
		}
	}

	public int cConditionalColumn
	{
		[DebuggerStepThrough]
		get
		{
			return numConditionalColumns;
		}
		set
		{
			numConditionalColumns = value;
		}
	}

	public int cbKeyMost
	{
		[DebuggerStepThrough]
		get
		{
			return maximumKeyLength;
		}
		set
		{
			maximumKeyLength = value;
		}
	}

	public JET_SPACEHINTS pSpaceHints
	{
		[DebuggerStepThrough]
		get
		{
			return spaceHints;
		}
		set
		{
			spaceHints = value;
		}
	}

	public JET_INDEXCREATE DeepClone()
	{
		JET_INDEXCREATE obj = (JET_INDEXCREATE)MemberwiseClone();
		obj.pidxUnicode = ((pidxUnicode == null) ? null : pidxUnicode.DeepClone());
		conditionalColumns = Util.DeepCloneArray(conditionalColumns);
		return obj;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_INDEXCREATE({0}:{1})", szIndexName, szKey);
	}

	public bool ContentEquals(JET_INDEXCREATE other)
	{
		if (other == null)
		{
			return false;
		}
		CheckMembersAreValid();
		other.CheckMembersAreValid();
		if (err == other.err && szIndexName == other.szIndexName && szKey == other.szKey && cbKey == other.cbKey && grbit == other.grbit && ulDensity == other.ulDensity && cbVarSegMac == other.cbVarSegMac && cbKeyMost == other.cbKeyMost && IsUnicodeIndexEqual(other))
		{
			return AreConditionalColumnsEqual(other);
		}
		return false;
	}

	internal void CheckMembersAreValid()
	{
		if (szIndexName == null)
		{
			throw new ArgumentNullException("szIndexName");
		}
		if (szKey == null)
		{
			throw new ArgumentNullException("szKey");
		}
		if (cbKey > checked(szKey.Length + 1))
		{
			throw new ArgumentOutOfRangeException("cbKey", cbKey, "cannot be greater than the length of szKey");
		}
		if (cbKey < 0)
		{
			throw new ArgumentOutOfRangeException("cbKey", cbKey, "cannot be negative");
		}
		if (ulDensity < 0)
		{
			throw new ArgumentOutOfRangeException("ulDensity", ulDensity, "cannot be negative");
		}
		if (cbKeyMost < 0)
		{
			throw new ArgumentOutOfRangeException("cbKeyMost", cbKeyMost, "cannot be negative");
		}
		if (cbVarSegMac < 0)
		{
			throw new ArgumentOutOfRangeException("cbVarSegMac", cbVarSegMac, "cannot be negative");
		}
		if ((cConditionalColumn > 0 && rgconditionalcolumn == null) || (cConditionalColumn > 0 && cConditionalColumn > rgconditionalcolumn.Length))
		{
			throw new ArgumentOutOfRangeException("cConditionalColumn", cConditionalColumn, "cannot be greater than the length of rgconditionalcolumn");
		}
		if (cConditionalColumn < 0)
		{
			throw new ArgumentOutOfRangeException("cConditionalColumn", cConditionalColumn, "cannot be negative");
		}
	}

	internal NATIVE_INDEXCREATE GetNativeIndexcreate()
	{
		CheckMembersAreValid();
		checked
		{
			return new NATIVE_INDEXCREATE
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_INDEXCREATE)),
				cbKey = (uint)cbKey,
				grbit = unchecked((uint)grbit),
				ulDensity = (uint)ulDensity,
				cbVarSegMac = new IntPtr(cbVarSegMac),
				cConditionalColumn = (uint)cConditionalColumn
			};
		}
	}

	internal NATIVE_INDEXCREATE1 GetNativeIndexcreate1()
	{
		NATIVE_INDEXCREATE1 result = default(NATIVE_INDEXCREATE1);
		result.indexcreate = GetNativeIndexcreate();
		checked
		{
			result.indexcreate.cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_INDEXCREATE1));
			if (cbKeyMost != 0)
			{
				result.cbKeyMost = (uint)cbKeyMost;
				result.indexcreate.grbit |= 32768u;
			}
			return result;
		}
	}

	internal NATIVE_INDEXCREATE2 GetNativeIndexcreate2()
	{
		NATIVE_INDEXCREATE2 result = default(NATIVE_INDEXCREATE2);
		result.indexcreate1 = GetNativeIndexcreate1();
		result.indexcreate1.indexcreate.cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_INDEXCREATE2)));
		return result;
	}

	internal void SetFromNativeIndexCreate(NATIVE_INDEXCREATE2 value)
	{
		SetFromNativeIndexCreate(value.indexcreate1);
	}

	internal void SetFromNativeIndexCreate(NATIVE_INDEXCREATE1 value)
	{
		SetFromNativeIndexCreate(value.indexcreate);
	}

	internal void SetFromNativeIndexCreate(NATIVE_INDEXCREATE value)
	{
		err = (JET_err)value.err;
	}

	private bool IsUnicodeIndexEqual(JET_INDEXCREATE other)
	{
		if (pidxUnicode != null)
		{
			return pidxUnicode.ContentEquals(other.pidxUnicode);
		}
		return other.pidxUnicode == null;
	}

	private bool AreConditionalColumnsEqual(JET_INDEXCREATE other)
	{
		if (cConditionalColumn != other.cConditionalColumn)
		{
			return false;
		}
		for (int i = 0; i < cConditionalColumn; i = checked(i + 1))
		{
			if (!rgconditionalcolumn[i].ContentEquals(other.rgconditionalcolumn[i]))
			{
				return false;
			}
		}
		return true;
	}

	internal NATIVE_INDEXCREATE3 GetNativeIndexcreate3()
	{
		CheckMembersAreValid();
		checked
		{
			NATIVE_INDEXCREATE3 result = new NATIVE_INDEXCREATE3
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_INDEXCREATE3)),
				cbKey = (uint)cbKey * 2,
				grbit = unchecked((uint)grbit),
				ulDensity = (uint)ulDensity,
				cbVarSegMac = new IntPtr(cbVarSegMac),
				cConditionalColumn = (uint)cConditionalColumn
			};
			if (cbKeyMost != 0)
			{
				result.cbKeyMost = (uint)cbKeyMost;
				result.grbit |= 32768u;
			}
			return result;
		}
	}

	internal void SetFromNativeIndexCreate(ref NATIVE_INDEXCREATE3 value)
	{
		err = (JET_err)value.err;
	}

	internal unsafe void SetAllFromNativeIndexCreate(ref NATIVE_INDEXCREATE3 value)
	{
		szIndexName = Marshal.PtrToStringUni(value.szIndexName);
		cbKey = (int)value.cbKey / 2;
		szKey = Marshal.PtrToStringUni(value.szKey, cbKey);
		if (cbKey != szKey.Length)
		{
			throw new ArgumentException($"cbKey {cbKey} != szKey.Length {szKey.Length}");
		}
		grbit = (CreateIndexGrbit)value.grbit;
		ulDensity = (int)value.ulDensity;
		pidxUnicode = new JET_UNICODEINDEX(ref *value.pidxUnicode);
		cbVarSegMac = (int)value.cbVarSegMac;
		cConditionalColumn = (int)value.cConditionalColumn;
		rgconditionalcolumn = new JET_CONDITIONALCOLUMN[cConditionalColumn];
		int num = Marshal.SizeOf(typeof(NATIVE_CONDITIONALCOLUMN));
		checked
		{
			for (int i = 0; i < cConditionalColumn; i++)
			{
				NATIVE_CONDITIONALCOLUMN native = (NATIVE_CONDITIONALCOLUMN)Marshal.PtrToStructure(value.rgconditionalcolumn + i * num, typeof(NATIVE_CONDITIONALCOLUMN));
				rgconditionalcolumn[i] = new JET_CONDITIONALCOLUMN(ref native);
			}
		}
		err = (JET_err)value.err;
		cbKeyMost = (int)value.cbKeyMost;
		NATIVE_SPACEHINTS fromNativeSpaceHints = (NATIVE_SPACEHINTS)Marshal.PtrToStructure(value.pSpaceHints, typeof(NATIVE_SPACEHINTS));
		pSpaceHints = new JET_SPACEHINTS();
		pSpaceHints.SetFromNativeSpaceHints(fromNativeSpaceHints);
	}
}
