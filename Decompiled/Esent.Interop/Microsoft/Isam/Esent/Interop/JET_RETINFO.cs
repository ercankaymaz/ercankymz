using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public class JET_RETINFO : IContentEquatable<JET_RETINFO>, IDeepCloneable<JET_RETINFO>
{
	public int ibLongValue { get; set; }

	public int itagSequence { get; set; }

	public JET_COLUMNID columnidNextTagged { get; internal set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_RETINFO(ibLongValue={0},itagSequence={1})", ibLongValue, itagSequence);
	}

	public bool ContentEquals(JET_RETINFO other)
	{
		if (other == null)
		{
			return false;
		}
		if (ibLongValue == other.ibLongValue && itagSequence == other.itagSequence)
		{
			return columnidNextTagged == other.columnidNextTagged;
		}
		return false;
	}

	public JET_RETINFO DeepClone()
	{
		return (JET_RETINFO)MemberwiseClone();
	}

	internal NATIVE_RETINFO GetNativeRetinfo()
	{
		return checked(new NATIVE_RETINFO
		{
			cbStruct = (uint)NATIVE_RETINFO.Size,
			ibLongValue = (uint)ibLongValue,
			itagSequence = (uint)itagSequence
		});
	}

	internal void SetFromNativeRetinfo(NATIVE_RETINFO value)
	{
		checked
		{
			ibLongValue = (int)value.ibLongValue;
			itagSequence = (int)value.itagSequence;
			JET_COLUMNID jET_COLUMNID = new JET_COLUMNID
			{
				Value = value.columnidNextTagged
			};
			columnidNextTagged = jET_COLUMNID;
		}
	}
}
