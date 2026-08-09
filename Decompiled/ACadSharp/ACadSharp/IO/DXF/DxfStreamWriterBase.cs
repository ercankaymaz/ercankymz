using System;
using CSMath;
using CSUtilities.Converters;

namespace ACadSharp.IO.DXF;

internal abstract class DxfStreamWriterBase : IDxfStreamWriter, IDisposable
{
	public bool WriteOptional { get; set; }

	public void Write(DxfCode code, object value, DxfClassMap map = null)
	{
		Write((int)code, value, map);
	}

	public void Write(DxfCode code, IVector value, DxfClassMap map = null)
	{
		Write((int)code, value, map);
	}

	public void Write(int code, IVector value, DxfClassMap map = null)
	{
		for (int i = 0; i < value.Dimension; i++)
		{
			Write(code + i * 10, value[i], map);
		}
	}

	public void WriteTrueColor(int code, Color color, DxfClassMap map = null)
	{
		byte[] bytes = new byte[4] { color.B, color.G, color.R, 0 };
		Write(code, LittleEndianConverter.Instance.ToInt32(bytes), map);
	}

	public void WriteCmColor(int code, Color color, DxfClassMap map = null)
	{
		if (GroupCodeValue.TransformValue(code) == GroupCodeValueType.Int16)
		{
			Write(code, Convert.ToInt16(color.GetApproxIndex()));
			return;
		}
		byte[] array = new byte[4];
		if (color.IsTrueColor)
		{
			array[0] = color.B;
			array[1] = color.G;
			array[2] = color.R;
			array[3] = 194;
		}
		else
		{
			array[3] = 193;
			array[0] = (byte)color.Index;
		}
		Write(code, LittleEndianConverter.Instance.ToInt32(array), map);
	}

	public void WriteHandle(int code, IHandledCadObject value, DxfClassMap map = null)
	{
		if (value != null)
		{
			Write(code, value.Handle, map);
		}
	}

	public void WriteName(int code, INamedCadObject value, DxfClassMap map = null)
	{
		if (value != null)
		{
			Write(code, value.Name, map);
		}
	}

	public void Write(int code, object value, DxfClassMap map = null)
	{
		if (value == null)
		{
			return;
		}
		if (map != null && map.DxfProperties.TryGetValue(code, out var value2))
		{
			if (value2.ReferenceType.HasFlag(DxfReferenceType.Optional) && !WriteOptional)
			{
				return;
			}
			if (value2.ReferenceType.HasFlag(DxfReferenceType.IsAngle))
			{
				value = MathHelper.RadToDeg((double)value);
			}
		}
		writeDxfCode(code);
		if (value is string text)
		{
			string value3 = text.Replace("^", "^ ").Replace("\n", "^J").Replace("\r", "^M")
				.Replace("\t", "^I");
			writeValue(code, value3);
		}
		else
		{
			writeValue(code, value);
		}
	}

	public abstract void Dispose();

	public abstract void Flush();

	public abstract void Close();

	protected abstract void writeDxfCode(int code);

	protected abstract void writeValue(int code, object value);
}
