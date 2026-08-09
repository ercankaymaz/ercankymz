using System;
using System.Globalization;
using System.Numerics;
using System.Text.Json;

namespace SharpGLTF.IO;

internal static class _JSonSerializationExtensions
{
	public static bool AsBoolean(this in Utf8JsonReader reader)
	{
		return reader.TokenType switch
		{
			JsonTokenType.Null => false, 
			JsonTokenType.True => true, 
			JsonTokenType.False => false, 
			JsonTokenType.Number => reader.GetInt32() != 0, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static string AsString(this in Utf8JsonReader reader)
	{
		return reader.TokenType switch
		{
			JsonTokenType.Null => null, 
			JsonTokenType.String => reader.GetString(), 
			JsonTokenType.PropertyName => reader.GetString(), 
			JsonTokenType.True => "true", 
			JsonTokenType.False => "false", 
			JsonTokenType.Number => reader.GetDecimal().ToString(CultureInfo.InvariantCulture), 
			_ => throw new NotImplementedException(), 
		};
	}

	public static object AsEnum(this in Utf8JsonReader reader, Type enumType)
	{
		if (reader.TokenType == JsonTokenType.String)
		{
			string text = reader.GetString();
			try
			{
				return Enum.Parse(enumType, text, ignoreCase: true);
			}
			catch (ArgumentException innerException)
			{
				throw new JsonException($"Value '{text}' not found in '{enumType}'", innerException);
			}
		}
		if (reader.TokenType == JsonTokenType.Number)
		{
			if (reader.TryGetInt32(out var value))
			{
				return Enum.ToObject(enumType, value);
			}
			if (reader.TryGetInt64(out var value2))
			{
				return Enum.ToObject(enumType, value2);
			}
		}
		throw new NotImplementedException();
	}

	public static object GetAnyValue(this in Utf8JsonReader reader)
	{
		return reader.TokenType switch
		{
			JsonTokenType.Null => null, 
			JsonTokenType.True => true, 
			JsonTokenType.False => false, 
			JsonTokenType.String => reader.GetString(), 
			JsonTokenType.Number => reader.GetDecimal(), 
			JsonTokenType.PropertyName => reader.GetString(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public static object GetValueAs(this in Utf8JsonReader reader, Type vtype)
	{
		if (reader.TokenType == JsonTokenType.Null)
		{
			return null;
		}
		if (vtype == typeof(string))
		{
			return reader.AsString();
		}
		if (vtype == typeof(bool))
		{
			return reader.AsBoolean();
		}
		if (vtype == typeof(short))
		{
			return reader.GetInt16();
		}
		if (vtype == typeof(int))
		{
			return reader.GetInt32();
		}
		if (vtype == typeof(long))
		{
			return reader.GetInt64();
		}
		if (vtype == typeof(ushort))
		{
			return reader.GetUInt16();
		}
		if (vtype == typeof(uint))
		{
			return reader.GetUInt32();
		}
		if (vtype == typeof(ulong))
		{
			return reader.GetUInt64();
		}
		if (vtype == typeof(float))
		{
			return reader.GetSingle();
		}
		if (vtype == typeof(double))
		{
			return reader.GetDouble();
		}
		if (vtype == typeof(decimal))
		{
			return reader.GetDecimal();
		}
		return Convert.ChangeType(reader.GetString(), vtype, CultureInfo.InvariantCulture);
	}

	public static T GetValueAs<T>(this in Utf8JsonReader reader) where T : struct
	{
		return (T)reader.GetValueAs(typeof(T));
	}

	public static bool TryWriteProperty(this Utf8JsonWriter writer, string property, object value)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		if (!(value is string value2))
		{
			if (!(value is bool value3))
			{
				if (!(value is byte value4))
				{
					if (!(value is ushort value5))
					{
						if (!(value is uint value6))
						{
							if (!(value is ulong value7))
							{
								if (!(value is sbyte value8))
								{
									if (!(value is short value9))
									{
										if (!(value is int value10))
										{
											if (!(value is long value11))
											{
												if (!(value is float value12))
												{
													if (!(value is double value13))
													{
														if (!(value is decimal value14))
														{
															if (!(value is Vector2 v))
															{
																if (!(value is Vector3 v2))
																{
																	if (!(value is Vector4 v3))
																	{
																		if (!(value is Quaternion q))
																		{
																			if (value is Matrix4x4 m)
																			{
																				writer.WritePropertyName(property);
																				writer.WriteMatrix4x4(m);
																				return true;
																			}
																			return false;
																		}
																		writer.WritePropertyName(property);
																		writer.WriteQuaternion(q);
																		return true;
																	}
																	writer.WritePropertyName(property);
																	writer.WriteVector4(v3);
																	return true;
																}
																writer.WritePropertyName(property);
																writer.WriteVector3(v2);
																return true;
															}
															writer.WritePropertyName(property);
															writer.WriteVector2(v);
															return true;
														}
														writer.WriteNumber(property, value14);
														return true;
													}
													writer.WriteNumber(property, value13);
													return true;
												}
												writer.WriteNumber(property, value12);
												return true;
											}
											writer.WriteNumber(property, value11);
											return true;
										}
										writer.WriteNumber(property, value10);
										return true;
									}
									writer.WriteNumber(property, value9);
									return true;
								}
								writer.WriteNumber(property, value8);
								return true;
							}
							writer.WriteNumber(property, value7);
							return true;
						}
						writer.WriteNumber(property, value6);
						return true;
					}
					writer.WriteNumber(property, value5);
					return true;
				}
				writer.WriteNumber(property, value4);
				return true;
			}
			writer.WriteBoolean(property, value3);
			return true;
		}
		writer.WriteString(property, value2);
		return true;
	}

	public static bool TryWriteValue(this Utf8JsonWriter writer, object value)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		if (!(value is string value2))
		{
			if (!(value is bool value3))
			{
				if (!(value is byte value4))
				{
					if (!(value is ushort value5))
					{
						if (!(value is uint value6))
						{
							if (!(value is ulong value7))
							{
								if (!(value is sbyte value8))
								{
									if (!(value is short value9))
									{
										if (!(value is int value10))
										{
											if (!(value is long value11))
											{
												if (!(value is float value12))
												{
													if (!(value is double value13))
													{
														if (!(value is decimal value14))
														{
															if (!(value is Vector2 v))
															{
																if (!(value is Vector3 v2))
																{
																	if (!(value is Vector4 v3))
																	{
																		if (!(value is Quaternion q))
																		{
																			if (value is Matrix4x4 m)
																			{
																				writer.WriteMatrix4x4(m);
																				return true;
																			}
																			return false;
																		}
																		writer.WriteQuaternion(q);
																		return true;
																	}
																	writer.WriteVector4(v3);
																	return true;
																}
																writer.WriteVector3(v2);
																return true;
															}
															writer.WriteVector2(v);
															return true;
														}
														writer.WriteNumberValue(value14);
														return true;
													}
													writer.WriteNumberValue(value13);
													return true;
												}
												writer.WriteNumberValue(value12);
												return true;
											}
											writer.WriteNumberValue(value11);
											return true;
										}
										writer.WriteNumberValue(value10);
										return true;
									}
									writer.WriteNumberValue(value9);
									return true;
								}
								writer.WriteNumberValue(value8);
								return true;
							}
							writer.WriteNumberValue(value7);
							return true;
						}
						writer.WriteNumberValue(value6);
						return true;
					}
					writer.WriteNumberValue(value5);
					return true;
				}
				writer.WriteNumberValue(value4);
				return true;
			}
			writer.WriteBooleanValue(value3);
			return true;
		}
		writer.WriteStringValue(value2);
		return true;
	}

	public static void WriteVector2(this Utf8JsonWriter writer, Vector2 v)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		writer.WriteStartArray();
		writer.WriteNumberValue(v.X);
		writer.WriteNumberValue(v.Y);
		writer.WriteEndArray();
	}

	public static void WriteVector3(this Utf8JsonWriter writer, Vector3 v)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		writer.WriteStartArray();
		writer.WriteNumberValue(v.X);
		writer.WriteNumberValue(v.Y);
		writer.WriteNumberValue(v.Z);
		writer.WriteEndArray();
	}

	public static void WriteVector4(this Utf8JsonWriter writer, Vector4 v)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		writer.WriteStartArray();
		writer.WriteNumberValue(v.X);
		writer.WriteNumberValue(v.Y);
		writer.WriteNumberValue(v.Z);
		writer.WriteNumberValue(v.W);
		writer.WriteEndArray();
	}

	public static void WriteQuaternion(this Utf8JsonWriter writer, Quaternion q)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		writer.WriteStartArray();
		writer.WriteNumberValue(q.X);
		writer.WriteNumberValue(q.Y);
		writer.WriteNumberValue(q.Z);
		writer.WriteNumberValue(q.W);
		writer.WriteEndArray();
	}

	public static void WriteMatrix4x4(this Utf8JsonWriter writer, Matrix4x4 m)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		writer.WriteStartArray();
		writer.WriteNumberValue(m.M11);
		writer.WriteNumberValue(m.M12);
		writer.WriteNumberValue(m.M13);
		writer.WriteNumberValue(m.M14);
		writer.WriteNumberValue(m.M21);
		writer.WriteNumberValue(m.M22);
		writer.WriteNumberValue(m.M23);
		writer.WriteNumberValue(m.M24);
		writer.WriteNumberValue(m.M31);
		writer.WriteNumberValue(m.M32);
		writer.WriteNumberValue(m.M33);
		writer.WriteNumberValue(m.M34);
		writer.WriteNumberValue(m.M41);
		writer.WriteNumberValue(m.M42);
		writer.WriteNumberValue(m.M43);
		writer.WriteNumberValue(m.M44);
		writer.WriteEndArray();
	}
}
