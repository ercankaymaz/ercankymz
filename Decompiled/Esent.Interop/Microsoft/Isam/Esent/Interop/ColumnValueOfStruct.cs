using System;

namespace Microsoft.Isam.Esent.Interop;

public abstract class ColumnValueOfStruct<T> : ColumnValue where T : struct, IEquatable<T>
{
	private T? internalValue;

	public override object ValueAsObject => BoxedValueCache<T>.GetBoxedValue(Value);

	public T? Value
	{
		get
		{
			return internalValue;
		}
		set
		{
			internalValue = value;
			base.Error = ((!value.HasValue) ? JET_wrn.ColumnNull : JET_wrn.Success);
		}
	}

	public override int Length
	{
		get
		{
			if (!Value.HasValue)
			{
				return 0;
			}
			return Size;
		}
	}

	public override string ToString()
	{
		return Value.ToString();
	}

	protected void CheckDataCount(int count)
	{
		if (Size != count)
		{
			throw new EsentInvalidColumnException();
		}
	}
}
