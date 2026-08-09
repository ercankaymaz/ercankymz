using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class JET_TABLECREATE : IContentEquatable<JET_TABLECREATE>, IDeepCloneable<JET_TABLECREATE>
{
	internal struct NATIVE_TABLECREATE2
	{
		public uint cbStruct;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string szTableName;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string szTemplateTableName;

		public uint ulPages;

		public uint ulDensity;

		public unsafe NATIVE_COLUMNCREATE* rgcolumncreate;

		public uint cColumns;

		public IntPtr rgindexcreate;

		public uint cIndexes;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string szCallback;

		public JET_cbtyp cbtyp;

		public uint grbit;

		public IntPtr tableid;

		public uint cCreated;
	}

	internal struct NATIVE_TABLECREATE3
	{
		public uint cbStruct;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string szTableName;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string szTemplateTableName;

		public uint ulPages;

		public uint ulDensity;

		public unsafe NATIVE_COLUMNCREATE* rgcolumncreate;

		public uint cColumns;

		public IntPtr rgindexcreate;

		public uint cIndexes;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string szCallback;

		public JET_cbtyp cbtyp;

		public uint grbit;

		public unsafe NATIVE_SPACEHINTS* pSeqSpacehints;

		public unsafe NATIVE_SPACEHINTS* pLVSpacehints;

		public uint cbSeparateLV;

		public IntPtr tableid;

		public uint cCreated;
	}

	private string tableName;

	private string templateTableName;

	private int initialPageAllocation;

	private int tableDensity;

	private JET_COLUMNCREATE[] columnCreates;

	private int columnCreateCount;

	private JET_INDEXCREATE[] indexCreates;

	private int indexCreateCount;

	private string callbackFunction;

	private JET_cbtyp callbackType;

	private CreateTableColumnIndexGrbit options;

	private JET_SPACEHINTS seqSpacehints;

	private JET_SPACEHINTS longValueSpacehints;

	private int separateLvThresholdHint;

	[NonSerialized]
	private JET_TABLEID tableIdentifier;

	private int objectsCreated;

	public string szTableName
	{
		[DebuggerStepThrough]
		get
		{
			return tableName;
		}
		set
		{
			tableName = value;
		}
	}

	public string szTemplateTableName
	{
		[DebuggerStepThrough]
		get
		{
			return templateTableName;
		}
		set
		{
			templateTableName = value;
		}
	}

	public int ulPages
	{
		[DebuggerStepThrough]
		get
		{
			return initialPageAllocation;
		}
		set
		{
			initialPageAllocation = value;
		}
	}

	public int ulDensity
	{
		[DebuggerStepThrough]
		get
		{
			return tableDensity;
		}
		set
		{
			tableDensity = value;
		}
	}

	public JET_COLUMNCREATE[] rgcolumncreate
	{
		[DebuggerStepThrough]
		get
		{
			return columnCreates;
		}
		set
		{
			columnCreates = value;
		}
	}

	public int cColumns
	{
		[DebuggerStepThrough]
		get
		{
			return columnCreateCount;
		}
		set
		{
			columnCreateCount = value;
		}
	}

	public JET_INDEXCREATE[] rgindexcreate
	{
		[DebuggerStepThrough]
		get
		{
			return indexCreates;
		}
		set
		{
			indexCreates = value;
		}
	}

	public int cIndexes
	{
		[DebuggerStepThrough]
		get
		{
			return indexCreateCount;
		}
		set
		{
			indexCreateCount = value;
		}
	}

	public string szCallback
	{
		[DebuggerStepThrough]
		get
		{
			return callbackFunction;
		}
		set
		{
			callbackFunction = value;
		}
	}

	public JET_cbtyp cbtyp
	{
		[DebuggerStepThrough]
		get
		{
			return callbackType;
		}
		set
		{
			callbackType = value;
		}
	}

	public CreateTableColumnIndexGrbit grbit
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

	public JET_SPACEHINTS pSeqSpacehints
	{
		[DebuggerStepThrough]
		get
		{
			return seqSpacehints;
		}
		set
		{
			seqSpacehints = value;
		}
	}

	public JET_SPACEHINTS pLVSpacehints
	{
		[DebuggerStepThrough]
		get
		{
			return longValueSpacehints;
		}
		set
		{
			longValueSpacehints = value;
		}
	}

	public int cbSeparateLV
	{
		[DebuggerStepThrough]
		get
		{
			return separateLvThresholdHint;
		}
		set
		{
			separateLvThresholdHint = value;
		}
	}

	public JET_TABLEID tableid
	{
		[DebuggerStepThrough]
		get
		{
			return tableIdentifier;
		}
		set
		{
			tableIdentifier = value;
		}
	}

	public int cCreated
	{
		[DebuggerStepThrough]
		get
		{
			return objectsCreated;
		}
		set
		{
			objectsCreated = value;
		}
	}

	public bool ContentEquals(JET_TABLECREATE other)
	{
		if (other == null)
		{
			return false;
		}
		CheckMembersAreValid();
		other.CheckMembersAreValid();
		if (true && szTableName == other.szTableName && szTemplateTableName == other.szTemplateTableName && ulPages == other.ulPages && ulDensity == other.ulDensity && cColumns == other.cColumns && cIndexes == other.cIndexes && szCallback == other.szCallback && cbtyp == other.cbtyp && grbit == other.grbit && cbSeparateLV == other.cbSeparateLV && Util.ObjectContentEquals(pSeqSpacehints, other.pSeqSpacehints) && Util.ObjectContentEquals(pLVSpacehints, other.pLVSpacehints) && tableid == other.tableid && cCreated == other.cCreated && Util.ArrayObjectContentEquals(rgcolumncreate, other.rgcolumncreate, cColumns))
		{
			return Util.ArrayObjectContentEquals(rgindexcreate, other.rgindexcreate, cIndexes);
		}
		return false;
	}

	public JET_TABLECREATE DeepClone()
	{
		JET_TABLECREATE obj = (JET_TABLECREATE)MemberwiseClone();
		obj.rgcolumncreate = Util.DeepCloneArray(rgcolumncreate);
		obj.rgindexcreate = Util.DeepCloneArray(rgindexcreate);
		obj.seqSpacehints = ((seqSpacehints == null) ? null : seqSpacehints.DeepClone());
		obj.pLVSpacehints = ((pLVSpacehints == null) ? null : pLVSpacehints.DeepClone());
		return obj;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_TABLECREATE({0}:{1} columns:{2} indices)", szTableName, cColumns, cIndexes);
	}

	internal void CheckMembersAreValid()
	{
		if (cColumns < 0)
		{
			throw new ArgumentOutOfRangeException("cColumns", cColumns, "cannot be negative");
		}
		if (rgcolumncreate != null && cColumns > rgcolumncreate.Length)
		{
			throw new ArgumentOutOfRangeException("cColumns", cColumns, "cannot be greater than rgcolumncreate.Length");
		}
		if (rgcolumncreate == null && cColumns != 0)
		{
			throw new ArgumentOutOfRangeException("cColumns", cColumns, "must be zero when rgcolumncreate is null");
		}
		if (cIndexes < 0)
		{
			throw new ArgumentOutOfRangeException("cIndexes", cIndexes, "cannot be negative");
		}
		if (rgindexcreate != null && cIndexes > rgindexcreate.Length)
		{
			throw new ArgumentOutOfRangeException("cIndexes", cIndexes, "cannot be greater than rgindexcreate.Length");
		}
		if (rgindexcreate == null && cIndexes != 0)
		{
			throw new ArgumentOutOfRangeException("cIndexes", cIndexes, "must be zero when rgindexcreate is null");
		}
	}

	internal NATIVE_TABLECREATE2 GetNativeTableCreate2()
	{
		CheckMembersAreValid();
		return checked(new NATIVE_TABLECREATE2
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_TABLECREATE2)),
			szTableName = szTableName,
			szTemplateTableName = szTemplateTableName,
			ulPages = (uint)ulPages,
			ulDensity = (uint)ulDensity,
			cColumns = (uint)cColumns,
			cIndexes = (uint)cIndexes,
			szCallback = szCallback,
			cbtyp = cbtyp,
			grbit = (uint)grbit,
			tableid = tableid.Value,
			cCreated = (uint)cCreated
		});
	}

	internal NATIVE_TABLECREATE3 GetNativeTableCreate3()
	{
		CheckMembersAreValid();
		return checked(new NATIVE_TABLECREATE3
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_TABLECREATE3)),
			szTableName = szTableName,
			szTemplateTableName = szTemplateTableName,
			ulPages = (uint)ulPages,
			ulDensity = (uint)ulDensity,
			cColumns = (uint)cColumns,
			cIndexes = (uint)cIndexes,
			szCallback = szCallback,
			cbtyp = cbtyp,
			grbit = (uint)grbit,
			cbSeparateLV = (uint)cbSeparateLV,
			tableid = tableid.Value,
			cCreated = (uint)cCreated
		});
	}

	internal NATIVE_TABLECREATE4 GetNativeTableCreate4()
	{
		CheckMembersAreValid();
		return checked(new NATIVE_TABLECREATE4
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_TABLECREATE4)),
			szTableName = szTableName,
			szTemplateTableName = szTemplateTableName,
			ulPages = (uint)ulPages,
			ulDensity = (uint)ulDensity,
			cColumns = (uint)cColumns,
			cIndexes = (uint)cIndexes,
			szCallback = szCallback,
			cbtyp = cbtyp,
			grbit = (uint)grbit,
			cbSeparateLV = (uint)cbSeparateLV,
			tableid = tableid.Value,
			cCreated = (uint)cCreated
		});
	}
}
