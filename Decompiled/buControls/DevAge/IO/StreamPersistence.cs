using System;
using System.IO;
using System.Text;

namespace DevAge.IO;

public static class StreamPersistence
{
	public static void Write(Stream p_Stream, string p_Value, Encoding encoding)
	{
		byte[] bytes = encoding.GetBytes(p_Value);
		Write(p_Stream, bytes);
	}

	public static void Write(Stream p_Stream, byte p_Value)
	{
		p_Stream.WriteByte(p_Value);
	}

	public static void Write(Stream p_Stream, Guid p_Value)
	{
		byte[] p_Bytes = p_Value.ToByteArray();
		Write(p_Stream, p_Bytes);
	}

	public static void Write(Stream p_Stream, decimal p_Value)
	{
		int[] bits = decimal.GetBits(p_Value);
		Write(p_Stream, bits[0]);
		Write(p_Stream, bits[1]);
		Write(p_Stream, bits[2]);
		Write(p_Stream, bits[3]);
	}

	public static void Write(Stream p_Stream, DateTime p_Value)
	{
		Write(p_Stream, p_Value.ToOADate());
	}

	public static void Write(Stream p_Stream, short p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, int p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, long p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, float p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, double p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, char p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, bool p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, ushort p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, uint p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, ulong p_Value)
	{
		WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
	}

	public static void Write(Stream p_Stream, byte[] p_Bytes)
	{
		Write(p_Stream, p_Bytes.Length);
		WriteBytes(p_Stream, p_Bytes);
	}

	public static void Write(Stream stream, Type valueType, object val)
	{
		if (!(valueType == typeof(string)))
		{
			if (!(valueType == typeof(short)))
			{
				if (!(valueType == typeof(int)))
				{
					if (!(valueType == typeof(long)))
					{
						if (!(valueType == typeof(float)))
						{
							if (!(valueType == typeof(double)))
							{
								if (!(valueType == typeof(bool)))
								{
									if (!(valueType == typeof(decimal)))
									{
										if (!(valueType == typeof(char)))
										{
											if (!(valueType == typeof(byte)))
											{
												if (!(valueType == typeof(byte[])))
												{
													if (!(valueType == typeof(DateTime)))
													{
														if (!(valueType == typeof(Guid)))
														{
															throw new TypeNotSupportedException(valueType);
														}
														Write(stream, (Guid)val);
													}
													else
													{
														Write(stream, (DateTime)val);
													}
												}
												else
												{
													Write(stream, (byte[])val);
												}
											}
											else
											{
												Write(stream, (byte)val);
											}
										}
										else
										{
											Write(stream, (char)val);
										}
									}
									else
									{
										Write(stream, (decimal)val);
									}
								}
								else
								{
									Write(stream, (bool)val);
								}
							}
							else
							{
								Write(stream, (double)val);
							}
						}
						else
						{
							Write(stream, (float)val);
						}
					}
					else
					{
						Write(stream, (long)val);
					}
				}
				else
				{
					Write(stream, (int)val);
				}
			}
			else
			{
				Write(stream, (short)val);
			}
		}
		else
		{
			Write(stream, (string)val, Encoding.UTF8);
		}
	}

	public static void WriteBytes(Stream p_Stream, byte[] p_Bytes)
	{
		p_Stream.Write(p_Bytes, 0, p_Bytes.Length);
	}

	public static Guid ReadGuid(Stream stream)
	{
		byte[] b = ReadByteArray(stream);
		return new Guid(b);
	}

	public static decimal ReadDecimal(Stream stream)
	{
		int num = ReadInt32(stream);
		int num2 = ReadInt32(stream);
		int num3 = ReadInt32(stream);
		int num4 = ReadInt32(stream);
		decimal result = new decimal(new int[4] { num, num2, num3, num4 });
		return result;
	}

	public static DateTime ReadDateTime(Stream p_Stream)
	{
		double d = ReadDouble(p_Stream);
		return DateTime.FromOADate(d);
	}

	public static float ReadSingle(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes(0f);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToSingle(bytes, 0);
	}

	public static double ReadDouble(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes(0.0);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToDouble(bytes, 0);
	}

	public static short ReadInt16(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes((short)0);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToInt16(bytes, 0);
	}

	public static int ReadInt32(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes(0);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToInt32(bytes, 0);
	}

	public static long ReadInt64(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes(0L);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToInt64(bytes, 0);
	}

	public static ushort ReadUInt16(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes((ushort)0);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToUInt16(bytes, 0);
	}

	public static uint ReadUInt32(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes(0u);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToUInt32(bytes, 0);
	}

	public static ulong ReadUInt64(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes(0uL);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToUInt64(bytes, 0);
	}

	public static byte ReadByte(Stream p_Stream)
	{
		int num = p_Stream.ReadByte();
		if (num == -1)
		{
			throw new InvalidDataException();
		}
		return (byte)num;
	}

	public static char ReadChar(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes('\0');
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToChar(bytes, 0);
	}

	public static bool ReadBoolean(Stream p_Stream)
	{
		byte[] bytes = BitConverter.GetBytes(value: false);
		ReadBytes(p_Stream, bytes);
		return BitConverter.ToBoolean(bytes, 0);
	}

	public static string ReadString(Stream p_Stream, Encoding encoding)
	{
		byte[] bytes = ReadByteArray(p_Stream);
		return encoding.GetString(bytes);
	}

	public static byte[] ReadByteArray(Stream p_Stream)
	{
		int num = ReadInt32(p_Stream);
		byte[] array = new byte[num];
		ReadBytes(p_Stream, array);
		return array;
	}

	public static object Read(Stream stream, Type valueType)
	{
		if (!(valueType == typeof(string)))
		{
			if (!(valueType == typeof(char)))
			{
				if (!(valueType == typeof(bool)))
				{
					if (!(valueType == typeof(decimal)))
					{
						if (!(valueType == typeof(short)))
						{
							if (!(valueType == typeof(int)))
							{
								if (!(valueType == typeof(long)))
								{
									if (!(valueType == typeof(float)))
									{
										if (!(valueType == typeof(double)))
										{
											if (!(valueType == typeof(byte)))
											{
												if (!(valueType == typeof(byte[])))
												{
													if (!(valueType == typeof(DateTime)))
													{
														if (!(valueType == typeof(Guid)))
														{
															throw new TypeNotSupportedException(valueType);
														}
														return ReadGuid(stream);
													}
													return ReadDateTime(stream);
												}
												return ReadByteArray(stream);
											}
											return ReadByte(stream);
										}
										return ReadDouble(stream);
									}
									return ReadSingle(stream);
								}
								return ReadInt64(stream);
							}
							return ReadInt32(stream);
						}
						return ReadInt16(stream);
					}
					return ReadDecimal(stream);
				}
				return ReadBoolean(stream);
			}
			return ReadChar(stream);
		}
		return ReadString(stream, Encoding.UTF8);
	}

	public static void ReadBytes(Stream p_Stream, byte[] p_Value)
	{
		if (p_Stream.Read(p_Value, 0, p_Value.Length) != p_Value.Length)
		{
			throw new InvalidDataException();
		}
	}
}
