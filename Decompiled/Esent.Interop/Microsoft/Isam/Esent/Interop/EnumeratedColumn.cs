using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class EnumeratedColumn
{
	public class Value
	{
		public int Ordinal { get; set; }

		public JET_wrn Warning { get; set; }

		public byte[] Bytes { get; set; }

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "EnumeratedColumn.Value({0}: {1} Bytes[{2}] = {3}{4}{5}{6})", Ordinal, Warning, Bytes.Length, '{', BitConverter.ToString(Bytes, 0, Math.Min(Bytes.Length, 16)), (Bytes.Length > 16) ? "..." : string.Empty, '}');
		}
	}

	public JET_COLUMNID Id { get; set; }

	public JET_err Error { get; set; }

	public JET_wrn Warning { get; set; }

	public Value[] Values { get; set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "EnumeratedColumn(0x{0:x}: {1} Values[{2}])", Id, (Error != JET_err.Success) ? Error.ToString() : Warning.ToString(), Values.Length);
	}
}
