using System;
using System.IO;
using System.Text;
using CSMath;

namespace ACadSharp.IO.DWG;

internal class DwgMergedStreamWriter : IDwgStreamWriter
{
	protected bool _savedPosition;

	public Encoding Encoding => Main.Encoding;

	public IDwgStreamWriter Main { get; }

	public IDwgStreamWriter TextWriter { get; }

	public IDwgStreamWriter HandleWriter { get; }

	public Stream Stream { get; }

	public long SavedPositionInBits { get; private set; }

	public long PositionInBits { get; private set; }

	public DwgMergedStreamWriter(Stream stream, IDwgStreamWriter main, IDwgStreamWriter textwriter, IDwgStreamWriter handlewriter)
	{
		Stream = stream;
		Main = main;
		TextWriter = textwriter;
		HandleWriter = handlewriter;
	}

	public void HandleReference(IHandledCadObject cadObject)
	{
		HandleWriter.HandleReference(cadObject);
	}

	public void HandleReference(DwgReferenceType type, IHandledCadObject cadObject)
	{
		HandleWriter.HandleReference(type, cadObject);
	}

	public void HandleReference(ulong handle)
	{
		HandleWriter.HandleReference(handle);
	}

	public void HandleReference(DwgReferenceType type, ulong handle)
	{
		HandleWriter.HandleReference(type, handle);
	}

	public void ResetStream()
	{
		Main.ResetStream();
		TextWriter.ResetStream();
		HandleWriter.ResetStream();
	}

	public void SavePositonForSize()
	{
		_savedPosition = true;
		PositionInBits = Main.PositionInBits;
		Main.WriteRawLong(0L);
	}

	public void Write2RawDouble(XY value)
	{
		Main.Write2RawDouble(value);
	}

	public void Write2BitDouble(XY value)
	{
		Main.Write2BitDouble(value);
	}

	public void Write3BitDouble(XYZ value)
	{
		Main.Write3BitDouble(value);
	}

	public void WriteBit(bool value)
	{
		Main.WriteBit(value);
	}

	public void Write2Bits(byte value)
	{
		Main.Write2Bits(value);
	}

	public void WriteBitDouble(double value)
	{
		Main.WriteBitDouble(value);
	}

	public void Write2BitDoubleWithDefault(XY def, XY value)
	{
		Main.Write2BitDoubleWithDefault(def, value);
	}

	public void Write3BitDoubleWithDefault(XYZ def, XYZ value)
	{
		Main.Write3BitDoubleWithDefault(def, value);
	}

	public void WriteBitDoubleWithDefault(double def, double value)
	{
		Main.WriteBitDoubleWithDefault(def, value);
	}

	public void WriteBitExtrusion(XYZ value)
	{
		Main.WriteBitExtrusion(value);
	}

	public void WriteBitLong(int value)
	{
		Main.WriteBitLong(value);
	}

	public void WriteBitLongLong(long value)
	{
		Main.WriteBitLongLong(value);
	}

	public void WriteBitShort(short value)
	{
		Main.WriteBitShort(value);
	}

	public void WriteBitThickness(double value)
	{
		Main.WriteBitThickness(value);
	}

	public void WriteByte(byte value)
	{
		Main.WriteByte(value);
	}

	public void WriteBytes(byte[] bytes)
	{
		Main.WriteBytes(bytes);
	}

	public void WriteCmColor(Color value)
	{
		Main.WriteCmColor(value);
	}

	public void WriteEnColor(Color color, Transparency transparency)
	{
		Main.WriteEnColor(color, transparency);
	}

	public void WriteDateTime(DateTime value)
	{
		Main.WriteDateTime(value);
	}

	public void Write8BitJulianDate(DateTime value)
	{
		Main.Write8BitJulianDate(value);
	}

	public void WriteInt(int value)
	{
		Main.WriteInt(value);
	}

	public void WriteObjectType(short value)
	{
		Main.WriteObjectType(value);
	}

	public void WriteObjectType(ObjectType value)
	{
		Main.WriteObjectType(value);
	}

	public void WriteRawDouble(double value)
	{
		Main.WriteRawDouble(value);
	}

	public void WriteRawLong(long value)
	{
		Main.WriteRawLong(value);
	}

	public void WriteRawShort(short value)
	{
		Main.WriteRawShort(value);
	}

	public void WriteRawShort(ushort value)
	{
		Main.WriteRawShort(value);
	}

	public virtual void WriteSpearShift()
	{
		long positionInBits = Main.PositionInBits;
		long positionInBits2 = TextWriter.PositionInBits;
		Main.WriteSpearShift();
		if (_savedPosition)
		{
			int num = (int)(positionInBits + positionInBits2 + 1);
			if (positionInBits2 > 0)
			{
				num += 16;
				if (positionInBits2 >= 32768)
				{
					num += 16;
					if (positionInBits2 >= 1073741824)
					{
						num += 16;
					}
				}
			}
			Main.SetPositionInBits(PositionInBits);
			Main.WriteRawLong(num);
			Main.WriteShiftValue();
		}
		Main.SetPositionInBits(positionInBits);
		if (positionInBits2 > 0)
		{
			TextWriter.WriteSpearShift();
			Main.WriteBytes(((MemoryStream)TextWriter.Stream).GetBuffer(), 0, (int)TextWriter.Stream.Length);
			Main.WriteSpearShift();
			Main.SetPositionInBits(positionInBits + positionInBits2);
			Main.SetPositionByFlag(positionInBits2);
			Main.WriteBit(value: true);
		}
		else
		{
			Main.WriteBit(value: false);
		}
		HandleWriter.WriteSpearShift();
		SavedPositionInBits = Main.PositionInBits;
		Main.WriteBytes(((MemoryStream)HandleWriter.Stream).GetBuffer(), 0, (int)HandleWriter.Stream.Length);
		Main.WriteSpearShift();
	}

	public void WriteTimeSpan(TimeSpan value)
	{
		Main.WriteTimeSpan(value);
	}

	public void WriteVariableText(string value)
	{
		TextWriter.WriteVariableText(value);
	}

	public void WriteTextUnicode(string value)
	{
		TextWriter.WriteTextUnicode(value);
	}

	public void SetPositionInBits(long posInBits)
	{
		throw new NotImplementedException();
	}

	public void SetPositionByFlag(long pos)
	{
		throw new NotImplementedException();
	}

	public void WriteShiftValue()
	{
		throw new NotImplementedException();
	}

	public void WriteBytes(byte[] bytes, int offset, int length)
	{
		Main.WriteBytes(bytes, offset, length);
	}

	public void WriteEnColor(Color color, Transparency transparency, bool isBookColor)
	{
		Main.WriteEnColor(color, transparency, isBookColor);
	}
}
