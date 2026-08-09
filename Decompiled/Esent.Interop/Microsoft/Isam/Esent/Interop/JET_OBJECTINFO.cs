using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_OBJECTINFO
{
	public JET_objtyp objtyp { get; private set; }

	public ObjectInfoGrbit grbit { get; private set; }

	public ObjectInfoFlags flags { get; private set; }

	public int cRecord { get; private set; }

	public int cPage { get; private set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_OBJECTINFO({0})", flags);
	}

	internal void SetFromNativeObjectinfo(ref NATIVE_OBJECTINFO value)
	{
		objtyp = (JET_objtyp)value.objtyp;
		grbit = (ObjectInfoGrbit)value.grbit;
		flags = (ObjectInfoFlags)value.flags;
		cRecord = (int)value.cRecord;
		cPage = (int)value.cPage;
	}
}
