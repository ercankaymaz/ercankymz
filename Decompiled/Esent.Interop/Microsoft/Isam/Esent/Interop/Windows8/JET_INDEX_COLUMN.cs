using System.Globalization;
using Microsoft.Isam.Esent.Interop.Implementation;

namespace Microsoft.Isam.Esent.Interop.Windows8;

public class JET_INDEX_COLUMN
{
	public JET_COLUMNID columnid { get; set; }

	public JetRelop relop { get; set; }

	public byte[] pvData { get; set; }

	public JetIndexColumnGrbit grbit { get; set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_INDEX_COLUMN(0x{0:x})", columnid);
	}

	internal NATIVE_INDEX_COLUMN GetNativeIndexColumn(ref GCHandleCollection handles)
	{
		checked
		{
			NATIVE_INDEX_COLUMN result = new NATIVE_INDEX_COLUMN
			{
				columnid = columnid.Value,
				relop = (uint)relop,
				grbit = (uint)grbit
			};
			if (pvData != null)
			{
				result.pvData = handles.Add(pvData);
				result.cbData = (uint)pvData.Length;
			}
			return result;
		}
	}
}
