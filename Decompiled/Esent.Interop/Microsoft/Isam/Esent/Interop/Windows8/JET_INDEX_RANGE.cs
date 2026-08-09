using System.Globalization;
using Microsoft.Isam.Esent.Interop.Implementation;

namespace Microsoft.Isam.Esent.Interop.Windows8;

public class JET_INDEX_RANGE
{
	public JET_INDEX_COLUMN[] startColumns { get; set; }

	public JET_INDEX_COLUMN[] endColumns { get; set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_INDEX_RANGE");
	}

	internal NATIVE_INDEX_RANGE GetNativeIndexRange(ref GCHandleCollection handles)
	{
		NATIVE_INDEX_RANGE result = default(NATIVE_INDEX_RANGE);
		checked
		{
			if (startColumns != null)
			{
				NATIVE_INDEX_COLUMN[] array = new NATIVE_INDEX_COLUMN[startColumns.Length];
				for (int i = 0; i < startColumns.Length; i++)
				{
					array[i] = startColumns[i].GetNativeIndexColumn(ref handles);
				}
				result.rgStartColumns = handles.Add(array);
				result.cStartColumns = (uint)startColumns.Length;
			}
			if (endColumns != null)
			{
				NATIVE_INDEX_COLUMN[] array = new NATIVE_INDEX_COLUMN[endColumns.Length];
				for (int j = 0; j < endColumns.Length; j++)
				{
					array[j] = endColumns[j].GetNativeIndexColumn(ref handles);
				}
				result.rgEndColumns = handles.Add(array);
				result.cEndColumns = (uint)endColumns.Length;
			}
			return result;
		}
	}
}
