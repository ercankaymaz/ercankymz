using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

public class JET_INDEXRANGE : IContentEquatable<JET_INDEXRANGE>, IDeepCloneable<JET_INDEXRANGE>
{
	public JET_TABLEID tableid { get; set; }

	public IndexRangeGrbit grbit { get; set; }

	public JET_INDEXRANGE()
	{
		grbit = IndexRangeGrbit.RecordInIndex;
	}

	public JET_INDEXRANGE DeepClone()
	{
		return (JET_INDEXRANGE)MemberwiseClone();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_INDEXRANGE(0x{0:x},{1})", tableid.Value, grbit);
	}

	public bool ContentEquals(JET_INDEXRANGE other)
	{
		if (other == null)
		{
			return false;
		}
		if (tableid == other.tableid)
		{
			return grbit == other.grbit;
		}
		return false;
	}

	internal NATIVE_INDEXRANGE GetNativeIndexRange()
	{
		return checked(new NATIVE_INDEXRANGE
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_INDEXRANGE)),
			tableid = tableid.Value,
			grbit = (uint)grbit
		});
	}
}
