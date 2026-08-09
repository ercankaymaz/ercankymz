using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Isam.Esent.Interop;

public sealed class ColumnInfo
{
	private readonly ReadOnlyCollection<byte> defaultValue;

	public string Name { get; private set; }

	public JET_COLUMNID Columnid { get; private set; }

	public JET_coltyp Coltyp { get; private set; }

	public JET_CP Cp { get; private set; }

	public int MaxLength { get; private set; }

	public IList<byte> DefaultValue => defaultValue;

	public ColumndefGrbit Grbit { get; private set; }

	internal ColumnInfo(string name, JET_COLUMNID columnid, JET_coltyp coltyp, JET_CP cp, int maxLength, byte[] defaultValue, ColumndefGrbit grbit)
	{
		Name = name;
		Columnid = columnid;
		Coltyp = coltyp;
		Cp = cp;
		MaxLength = maxLength;
		this.defaultValue = ((defaultValue == null) ? null : new ReadOnlyCollection<byte>(defaultValue));
		Grbit = grbit;
	}

	public override string ToString()
	{
		return Name;
	}
}
