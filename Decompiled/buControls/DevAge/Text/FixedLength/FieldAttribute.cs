using System;

namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property)]
public class FieldAttribute : Attribute
{
	private int fieldIndex;

	private int length;

	public int FieldIndex => fieldIndex;

	public int Length => length;

	public FieldAttribute(int fieldIndex, int length)
	{
		this.fieldIndex = fieldIndex;
		this.length = length;
	}
}
