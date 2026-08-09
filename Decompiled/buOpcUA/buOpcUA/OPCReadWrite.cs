using System;
using System.Collections.Generic;
using System.Reflection;
using Opc.Ua;
using Opc.Ua.Client;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buOpcUA;

public static class OPCReadWrite
{
	public static List<string> ErrorList;

	public static List<string> LocalErrorList;

	[NonSerialized]
	internal static GetString _0083;

	public static string WriteBOOLValue(bool value, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value2 = new Variant(value);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value2)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteBOOLValue(Session session, string nodeid, bool value)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value2 = new Variant(value);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value2)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteDINTValue(int value, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value2 = new Variant(value);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value2)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteINTValue(short value, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value2 = new Variant(value);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value2)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteLREALValue(double value, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value2 = new Variant(value);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value2)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteREALValue(float value, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value2 = new Variant(value);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value2)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteSTRINGValue(string value, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value2 = new Variant(value);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value2)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteBOOLList(List<bool> values, List<string> nodeidList, Session session)
	{
		string result;
		do
		{
			try
			{
				WriteValueCollection writeValueCollection = new WriteValueCollection();
				int num = 0;
				int num2;
				int num3;
				string text;
				while (true)
				{
					num2 = num;
					num3 = nodeidList.Count;
					StatusCodeCollection results;
					int num4;
					if (0 == 0)
					{
						if (num2 <= num3 - 1)
						{
							goto IL_0015;
						}
						DiagnosticInfoCollection diagnosticInfos;
						ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
						text = _0083(107396253);
						num4 = 0;
						goto IL_00f2;
					}
					goto IL_00fa;
					IL_00f2:
					num2 = num4;
					num3 = results.Count;
					goto IL_00fa;
					IL_0015:
					Variant value = new Variant(values[num]);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(nodeidList[num]),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					num++;
					continue;
					IL_00fa:
					while (num2 > num3 - 1)
					{
						if (6u != 0)
						{
							num2 = text.Length;
							num3 = 0;
							if (num3 == 0)
							{
								goto end_IL_0070;
							}
							continue;
						}
						goto IL_00bf;
					}
					if (StatusCode.IsBad(results[num4]))
					{
						goto IL_00bf;
					}
					goto IL_00e8;
					IL_00e8:
					int num5 = num4;
					do
					{
						num5++;
					}
					while (7 == 0);
					num4 = num5;
					goto IL_00f2;
					IL_00bf:
					StatusCode statusCode = results[num4];
					if (false)
					{
						goto IL_0015;
					}
					text = statusCode.ToString();
					num4 = results.Count;
					goto IL_00e8;
					continue;
					end_IL_0070:
					break;
				}
				result = ((num2 <= num3) ? _0083(107396307) : text);
			}
			catch (Exception ex)
			{
				while (false)
				{
				}
				result = _0083(107396302) + ex.Message;
			}
		}
		while (4 == 0);
		return result;
	}

	public static string WriteBOOLList(List<VariableBOOLDef> VarsStringList, Session session)
	{
		try
		{
			WriteValueCollection writeValueCollection;
			int num;
			if (5u != 0)
			{
				writeValueCollection = new WriteValueCollection();
				num = 0;
				goto IL_0083;
			}
			goto IL_0196;
			IL_00a4:
			StatusCodeCollection results = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
			string text = _0083(107396253);
			ErrorList.Clear();
			int num2 = 0;
			goto IL_0196;
			IL_0083:
			int num3;
			int num4;
			int num5;
			while (true)
			{
				num3 = num;
				num4 = VarsStringList.Count;
				if (uint.MaxValue != 0)
				{
					num5 = 1;
					if (num5 == 0)
					{
						break;
					}
					num3 = ((num3 > num4 - num5) ? 1 : 0);
					num4 = 0;
				}
				if (num3 == num4)
				{
					Variant value = new Variant(VarsStringList[num].Value);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(VarsStringList[num].Name),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					if (false)
					{
						continue;
					}
					goto IL_007d;
				}
				goto IL_00a4;
			}
			goto IL_019f;
			IL_0196:
			num3 = num2;
			num4 = results.Count;
			num5 = 1;
			goto IL_019f;
			IL_007d:
			num++;
			goto IL_0083;
			IL_0190:
			num2++;
			goto IL_0196;
			IL_019f:
			bool num6 = num3 > num4 - num5;
			if (3u != 0)
			{
				if (num6)
				{
					if (text.Length > 0)
					{
						return text;
					}
					if (0 == 0)
					{
						return _0083(107396307);
					}
					goto IL_0190;
				}
				num6 = StatusCode.IsBad(results[num2]);
			}
			if (num6)
			{
				bool flag = text == _0083(107396253);
				if (2 == 0)
				{
					goto IL_007d;
				}
				if (flag)
				{
					text = results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name;
				}
				ErrorList.Add(results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name);
			}
			goto IL_0190;
		}
		catch (Exception ex)
		{
			return _0083(107396302) + ex.Message;
		}
	}

	public static string WriteDINTList(List<int> values, List<string> nodeidList, Session session)
	{
		string result;
		do
		{
			try
			{
				WriteValueCollection writeValueCollection = new WriteValueCollection();
				int num = 0;
				int num2;
				int num3;
				string text;
				while (true)
				{
					num2 = num;
					num3 = nodeidList.Count;
					StatusCodeCollection results;
					int num4;
					if (0 == 0)
					{
						if (num2 <= num3 - 1)
						{
							goto IL_0015;
						}
						DiagnosticInfoCollection diagnosticInfos;
						ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
						text = _0083(107396253);
						num4 = 0;
						goto IL_00f2;
					}
					goto IL_00fa;
					IL_00f2:
					num2 = num4;
					num3 = results.Count;
					goto IL_00fa;
					IL_0015:
					Variant value = new Variant(values[num]);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(nodeidList[num]),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					num++;
					continue;
					IL_00fa:
					while (num2 > num3 - 1)
					{
						if (6u != 0)
						{
							num2 = text.Length;
							num3 = 0;
							if (num3 == 0)
							{
								goto end_IL_0070;
							}
							continue;
						}
						goto IL_00bf;
					}
					if (StatusCode.IsBad(results[num4]))
					{
						goto IL_00bf;
					}
					goto IL_00e8;
					IL_00e8:
					int num5 = num4;
					do
					{
						num5++;
					}
					while (7 == 0);
					num4 = num5;
					goto IL_00f2;
					IL_00bf:
					StatusCode statusCode = results[num4];
					if (false)
					{
						goto IL_0015;
					}
					text = statusCode.ToString();
					num4 = results.Count;
					goto IL_00e8;
					continue;
					end_IL_0070:
					break;
				}
				result = ((num2 <= num3) ? _0083(107396307) : text);
			}
			catch (Exception ex)
			{
				while (false)
				{
				}
				result = _0083(107396302) + ex.Message;
			}
		}
		while (4 == 0);
		return result;
	}

	public static string WriteDINTList(List<VariableDINTDef> VarsStringList, Session session)
	{
		try
		{
			WriteValueCollection writeValueCollection;
			int num;
			if (5u != 0)
			{
				writeValueCollection = new WriteValueCollection();
				num = 0;
				goto IL_0083;
			}
			goto IL_0196;
			IL_00a4:
			StatusCodeCollection results = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
			ErrorList.Clear();
			string text = _0083(107396253);
			int num2 = 0;
			goto IL_0196;
			IL_0083:
			int num3;
			int num4;
			int num5;
			while (true)
			{
				num3 = num;
				num4 = VarsStringList.Count;
				if (uint.MaxValue != 0)
				{
					num5 = 1;
					if (num5 == 0)
					{
						break;
					}
					num3 = ((num3 > num4 - num5) ? 1 : 0);
					num4 = 0;
				}
				if (num3 == num4)
				{
					Variant value = new Variant(VarsStringList[num].Value);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(VarsStringList[num].Name),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					if (false)
					{
						continue;
					}
					goto IL_007d;
				}
				goto IL_00a4;
			}
			goto IL_019f;
			IL_0196:
			num3 = num2;
			num4 = results.Count;
			num5 = 1;
			goto IL_019f;
			IL_007d:
			num++;
			goto IL_0083;
			IL_0190:
			num2++;
			goto IL_0196;
			IL_019f:
			bool num6 = num3 > num4 - num5;
			if (3u != 0)
			{
				if (num6)
				{
					if (text.Length > 0)
					{
						return text;
					}
					if (0 == 0)
					{
						return _0083(107396307);
					}
					goto IL_0190;
				}
				num6 = StatusCode.IsBad(results[num2]);
			}
			if (num6)
			{
				bool flag = text == _0083(107396253);
				if (2 == 0)
				{
					goto IL_007d;
				}
				if (flag)
				{
					text = results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name;
				}
				ErrorList.Add(results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name);
			}
			goto IL_0190;
		}
		catch (Exception ex)
		{
			return _0083(107396302) + ex.Message;
		}
	}

	public static string WriteINTList(List<short> values, List<string> nodeidList, Session session)
	{
		string result;
		do
		{
			try
			{
				WriteValueCollection writeValueCollection = new WriteValueCollection();
				int num = 0;
				int num2;
				int num3;
				string text;
				while (true)
				{
					num2 = num;
					num3 = nodeidList.Count;
					StatusCodeCollection results;
					int num4;
					if (0 == 0)
					{
						if (num2 <= num3 - 1)
						{
							goto IL_0015;
						}
						DiagnosticInfoCollection diagnosticInfos;
						ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
						text = _0083(107396253);
						num4 = 0;
						goto IL_00f2;
					}
					goto IL_00fa;
					IL_00f2:
					num2 = num4;
					num3 = results.Count;
					goto IL_00fa;
					IL_0015:
					Variant value = new Variant(values[num]);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(nodeidList[num]),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					num++;
					continue;
					IL_00fa:
					while (num2 > num3 - 1)
					{
						if (6u != 0)
						{
							num2 = text.Length;
							num3 = 0;
							if (num3 == 0)
							{
								goto end_IL_0070;
							}
							continue;
						}
						goto IL_00bf;
					}
					if (StatusCode.IsBad(results[num4]))
					{
						goto IL_00bf;
					}
					goto IL_00e8;
					IL_00e8:
					int num5 = num4;
					do
					{
						num5++;
					}
					while (7 == 0);
					num4 = num5;
					goto IL_00f2;
					IL_00bf:
					StatusCode statusCode = results[num4];
					if (false)
					{
						goto IL_0015;
					}
					text = statusCode.ToString();
					num4 = results.Count;
					goto IL_00e8;
					continue;
					end_IL_0070:
					break;
				}
				result = ((num2 <= num3) ? _0083(107396307) : text);
			}
			catch (Exception ex)
			{
				while (false)
				{
				}
				result = _0083(107396302) + ex.Message;
			}
		}
		while (4 == 0);
		return result;
	}

	public static string WriteINTList(List<VariableINTDef> VarsStringList, Session session)
	{
		try
		{
			WriteValueCollection writeValueCollection;
			int num;
			if (5u != 0)
			{
				writeValueCollection = new WriteValueCollection();
				num = 0;
				goto IL_0083;
			}
			goto IL_0196;
			IL_00a4:
			StatusCodeCollection results = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
			ErrorList.Clear();
			string text = _0083(107396253);
			int num2 = 0;
			goto IL_0196;
			IL_0083:
			int num3;
			int num4;
			int num5;
			while (true)
			{
				num3 = num;
				num4 = VarsStringList.Count;
				if (uint.MaxValue != 0)
				{
					num5 = 1;
					if (num5 == 0)
					{
						break;
					}
					num3 = ((num3 > num4 - num5) ? 1 : 0);
					num4 = 0;
				}
				if (num3 == num4)
				{
					Variant value = new Variant(VarsStringList[num].Value);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(VarsStringList[num].Name),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					if (false)
					{
						continue;
					}
					goto IL_007d;
				}
				goto IL_00a4;
			}
			goto IL_019f;
			IL_0196:
			num3 = num2;
			num4 = results.Count;
			num5 = 1;
			goto IL_019f;
			IL_007d:
			num++;
			goto IL_0083;
			IL_0190:
			num2++;
			goto IL_0196;
			IL_019f:
			bool num6 = num3 > num4 - num5;
			if (3u != 0)
			{
				if (num6)
				{
					if (text.Length > 0)
					{
						return text;
					}
					if (0 == 0)
					{
						return _0083(107396307);
					}
					goto IL_0190;
				}
				num6 = StatusCode.IsBad(results[num2]);
			}
			if (num6)
			{
				bool flag = text == _0083(107396253);
				if (2 == 0)
				{
					goto IL_007d;
				}
				if (flag)
				{
					text = results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name;
				}
				ErrorList.Add(results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name);
			}
			goto IL_0190;
		}
		catch (Exception ex)
		{
			return _0083(107396302) + ex.Message;
		}
	}

	public static string WriteLREALList(List<double> values, List<string> nodeidList, Session session)
	{
		string result;
		do
		{
			try
			{
				WriteValueCollection writeValueCollection = new WriteValueCollection();
				int num = 0;
				int num2;
				int num3;
				string text;
				while (true)
				{
					num2 = num;
					num3 = nodeidList.Count;
					StatusCodeCollection results;
					int num4;
					if (0 == 0)
					{
						if (num2 <= num3 - 1)
						{
							goto IL_0015;
						}
						DiagnosticInfoCollection diagnosticInfos;
						ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
						text = _0083(107396253);
						num4 = 0;
						goto IL_00f2;
					}
					goto IL_00fa;
					IL_00f2:
					num2 = num4;
					num3 = results.Count;
					goto IL_00fa;
					IL_0015:
					Variant value = new Variant(values[num]);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(nodeidList[num]),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					num++;
					continue;
					IL_00fa:
					while (num2 > num3 - 1)
					{
						if (6u != 0)
						{
							num2 = text.Length;
							num3 = 0;
							if (num3 == 0)
							{
								goto end_IL_0070;
							}
							continue;
						}
						goto IL_00bf;
					}
					if (StatusCode.IsBad(results[num4]))
					{
						goto IL_00bf;
					}
					goto IL_00e8;
					IL_00e8:
					int num5 = num4;
					do
					{
						num5++;
					}
					while (7 == 0);
					num4 = num5;
					goto IL_00f2;
					IL_00bf:
					StatusCode statusCode = results[num4];
					if (false)
					{
						goto IL_0015;
					}
					text = statusCode.ToString();
					num4 = results.Count;
					goto IL_00e8;
					continue;
					end_IL_0070:
					break;
				}
				result = ((num2 <= num3) ? _0083(107396307) : text);
			}
			catch (Exception ex)
			{
				while (false)
				{
				}
				result = _0083(107396302) + ex.Message;
			}
		}
		while (4 == 0);
		return result;
	}

	public static string WriteLREALList(List<VariableLREALDef> VarsStringList, Session session)
	{
		try
		{
			WriteValueCollection writeValueCollection;
			int num;
			if (5u != 0)
			{
				writeValueCollection = new WriteValueCollection();
				num = 0;
				goto IL_0083;
			}
			goto IL_0196;
			IL_00a4:
			StatusCodeCollection results = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
			ErrorList.Clear();
			string text = _0083(107396253);
			int num2 = 0;
			goto IL_0196;
			IL_0083:
			int num3;
			int num4;
			int num5;
			while (true)
			{
				num3 = num;
				num4 = VarsStringList.Count;
				if (uint.MaxValue != 0)
				{
					num5 = 1;
					if (num5 == 0)
					{
						break;
					}
					num3 = ((num3 > num4 - num5) ? 1 : 0);
					num4 = 0;
				}
				if (num3 == num4)
				{
					Variant value = new Variant(VarsStringList[num].Value);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(VarsStringList[num].Name),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					if (false)
					{
						continue;
					}
					goto IL_007d;
				}
				goto IL_00a4;
			}
			goto IL_019f;
			IL_0196:
			num3 = num2;
			num4 = results.Count;
			num5 = 1;
			goto IL_019f;
			IL_007d:
			num++;
			goto IL_0083;
			IL_0190:
			num2++;
			goto IL_0196;
			IL_019f:
			bool num6 = num3 > num4 - num5;
			if (3u != 0)
			{
				if (num6)
				{
					if (text.Length > 0)
					{
						return text;
					}
					if (0 == 0)
					{
						return _0083(107396307);
					}
					goto IL_0190;
				}
				num6 = StatusCode.IsBad(results[num2]);
			}
			if (num6)
			{
				bool flag = text == _0083(107396253);
				if (2 == 0)
				{
					goto IL_007d;
				}
				if (flag)
				{
					text = results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name;
				}
				ErrorList.Add(results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name);
			}
			goto IL_0190;
		}
		catch (Exception ex)
		{
			return _0083(107396302) + ex.Message;
		}
	}

	public static string WriteREALList(List<float> values, List<string> nodeidList, Session session)
	{
		string result;
		do
		{
			try
			{
				WriteValueCollection writeValueCollection = new WriteValueCollection();
				int num = 0;
				int num2;
				int num3;
				string text;
				while (true)
				{
					num2 = num;
					num3 = nodeidList.Count;
					StatusCodeCollection results;
					int num4;
					if (0 == 0)
					{
						if (num2 <= num3 - 1)
						{
							goto IL_0015;
						}
						DiagnosticInfoCollection diagnosticInfos;
						ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
						text = _0083(107396253);
						num4 = 0;
						goto IL_00f2;
					}
					goto IL_00fa;
					IL_00f2:
					num2 = num4;
					num3 = results.Count;
					goto IL_00fa;
					IL_0015:
					Variant value = new Variant(values[num]);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(nodeidList[num]),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					num++;
					continue;
					IL_00fa:
					while (num2 > num3 - 1)
					{
						if (6u != 0)
						{
							num2 = text.Length;
							num3 = 0;
							if (num3 == 0)
							{
								goto end_IL_0070;
							}
							continue;
						}
						goto IL_00bf;
					}
					if (StatusCode.IsBad(results[num4]))
					{
						goto IL_00bf;
					}
					goto IL_00e8;
					IL_00e8:
					int num5 = num4;
					do
					{
						num5++;
					}
					while (7 == 0);
					num4 = num5;
					goto IL_00f2;
					IL_00bf:
					StatusCode statusCode = results[num4];
					if (false)
					{
						goto IL_0015;
					}
					text = statusCode.ToString();
					num4 = results.Count;
					goto IL_00e8;
					continue;
					end_IL_0070:
					break;
				}
				result = ((num2 <= num3) ? _0083(107396307) : text);
			}
			catch (Exception ex)
			{
				while (false)
				{
				}
				result = _0083(107396302) + ex.Message;
			}
		}
		while (4 == 0);
		return result;
	}

	public static string WriteREALList(List<VariableREALDef> VarsRealList, Session session)
	{
		try
		{
			WriteValueCollection writeValueCollection;
			int num;
			if (5u != 0)
			{
				writeValueCollection = new WriteValueCollection();
				num = 0;
				goto IL_0083;
			}
			goto IL_0196;
			IL_00a4:
			StatusCodeCollection results = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
			ErrorList.Clear();
			string text = _0083(107396253);
			int num2 = 0;
			goto IL_0196;
			IL_0083:
			int num3;
			int num4;
			int num5;
			while (true)
			{
				num3 = num;
				num4 = VarsRealList.Count;
				if (uint.MaxValue != 0)
				{
					num5 = 1;
					if (num5 == 0)
					{
						break;
					}
					num3 = ((num3 > num4 - num5) ? 1 : 0);
					num4 = 0;
				}
				if (num3 == num4)
				{
					Variant value = new Variant(VarsRealList[num].Value);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(VarsRealList[num].Name),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					if (false)
					{
						continue;
					}
					goto IL_007d;
				}
				goto IL_00a4;
			}
			goto IL_019f;
			IL_0196:
			num3 = num2;
			num4 = results.Count;
			num5 = 1;
			goto IL_019f;
			IL_007d:
			num++;
			goto IL_0083;
			IL_0190:
			num2++;
			goto IL_0196;
			IL_019f:
			bool num6 = num3 > num4 - num5;
			if (3u != 0)
			{
				if (num6)
				{
					if (text.Length > 0)
					{
						return text;
					}
					if (0 == 0)
					{
						return _0083(107396307);
					}
					goto IL_0190;
				}
				num6 = StatusCode.IsBad(results[num2]);
			}
			if (num6)
			{
				bool flag = text == _0083(107396253);
				if (2 == 0)
				{
					goto IL_007d;
				}
				if (flag)
				{
					text = results[num2].ToString() + _0083(107396252) + VarsRealList[num2].Name;
				}
				ErrorList.Add(results[num2].ToString() + _0083(107396252) + VarsRealList[num2].Name);
			}
			goto IL_0190;
		}
		catch (Exception ex)
		{
			return _0083(107396302) + ex.Message;
		}
	}

	public static string WriteSTRINGList(List<string> values, List<string> nodeidList, Session session)
	{
		string result;
		do
		{
			try
			{
				WriteValueCollection writeValueCollection = new WriteValueCollection();
				int num = 0;
				int num2;
				int num3;
				string text;
				while (true)
				{
					num2 = num;
					num3 = nodeidList.Count;
					StatusCodeCollection results;
					int num4;
					if (0 == 0)
					{
						if (num2 <= num3 - 1)
						{
							goto IL_0015;
						}
						DiagnosticInfoCollection diagnosticInfos;
						ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
						text = _0083(107396253);
						num4 = 0;
						goto IL_00f2;
					}
					goto IL_00fa;
					IL_00f2:
					num2 = num4;
					num3 = results.Count;
					goto IL_00fa;
					IL_0015:
					Variant value = new Variant(values[num]);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(nodeidList[num]),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					num++;
					continue;
					IL_00fa:
					while (num2 > num3 - 1)
					{
						if (6u != 0)
						{
							num2 = text.Length;
							num3 = 0;
							if (num3 == 0)
							{
								goto end_IL_0070;
							}
							continue;
						}
						goto IL_00bf;
					}
					if (StatusCode.IsBad(results[num4]))
					{
						goto IL_00bf;
					}
					goto IL_00e8;
					IL_00e8:
					int num5 = num4;
					do
					{
						num5++;
					}
					while (7 == 0);
					num4 = num5;
					goto IL_00f2;
					IL_00bf:
					StatusCode statusCode = results[num4];
					if (false)
					{
						goto IL_0015;
					}
					text = statusCode.ToString();
					num4 = results.Count;
					goto IL_00e8;
					continue;
					end_IL_0070:
					break;
				}
				result = ((num2 <= num3) ? _0083(107396307) : text);
			}
			catch (Exception ex)
			{
				while (false)
				{
				}
				result = _0083(107396302) + ex.Message;
			}
		}
		while (4 == 0);
		return result;
	}

	public static string WriteSTRINGList(List<VariableSTRINGDef> VarsStringList, Session session)
	{
		try
		{
			WriteValueCollection writeValueCollection;
			int num;
			if (5u != 0)
			{
				writeValueCollection = new WriteValueCollection();
				num = 0;
				goto IL_0083;
			}
			goto IL_0196;
			IL_00a4:
			StatusCodeCollection results = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
			ErrorList.Clear();
			string text = _0083(107396253);
			int num2 = 0;
			goto IL_0196;
			IL_0083:
			int num3;
			int num4;
			int num5;
			while (true)
			{
				num3 = num;
				num4 = VarsStringList.Count;
				if (uint.MaxValue != 0)
				{
					num5 = 1;
					if (num5 == 0)
					{
						break;
					}
					num3 = ((num3 > num4 - num5) ? 1 : 0);
					num4 = 0;
				}
				if (num3 == num4)
				{
					Variant value = new Variant(VarsStringList[num].Value);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(VarsStringList[num].Name),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					if (false)
					{
						continue;
					}
					goto IL_007d;
				}
				goto IL_00a4;
			}
			goto IL_019f;
			IL_0196:
			num3 = num2;
			num4 = results.Count;
			num5 = 1;
			goto IL_019f;
			IL_007d:
			num++;
			goto IL_0083;
			IL_0190:
			num2++;
			goto IL_0196;
			IL_019f:
			bool num6 = num3 > num4 - num5;
			if (3u != 0)
			{
				if (num6)
				{
					if (text.Length > 0)
					{
						return text;
					}
					if (0 == 0)
					{
						return _0083(107396307);
					}
					goto IL_0190;
				}
				num6 = StatusCode.IsBad(results[num2]);
			}
			if (num6)
			{
				bool flag = text == _0083(107396253);
				if (2 == 0)
				{
					goto IL_007d;
				}
				if (flag)
				{
					text = results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name;
				}
				ErrorList.Add(results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name);
			}
			goto IL_0190;
		}
		catch (Exception ex)
		{
			return _0083(107396302) + ex.Message;
		}
	}

	public static string WriteENUMList(List<VariableENUMDef> VarsStringList, Session session)
	{
		try
		{
			WriteValueCollection writeValueCollection;
			int num;
			if (5u != 0)
			{
				writeValueCollection = new WriteValueCollection();
				num = 0;
				goto IL_0083;
			}
			goto IL_0196;
			IL_00a4:
			StatusCodeCollection results = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = session.Write(null, writeValueCollection, out results, out diagnosticInfos);
			ErrorList.Clear();
			string text = _0083(107396253);
			int num2 = 0;
			goto IL_0196;
			IL_0083:
			int num3;
			int num4;
			int num5;
			while (true)
			{
				num3 = num;
				num4 = VarsStringList.Count;
				if (uint.MaxValue != 0)
				{
					num5 = 1;
					if (num5 == 0)
					{
						break;
					}
					num3 = ((num3 > num4 - num5) ? 1 : 0);
					num4 = 0;
				}
				if (num3 == num4)
				{
					Variant value = new Variant((object)VarsStringList[num].Value);
					WriteValue item = new WriteValue
					{
						NodeId = new NodeId(VarsStringList[num].Name),
						AttributeId = 13u,
						Value = new DataValue(value)
					};
					writeValueCollection.Add(item);
					if (false)
					{
						continue;
					}
					goto IL_007d;
				}
				goto IL_00a4;
			}
			goto IL_019f;
			IL_0196:
			num3 = num2;
			num4 = results.Count;
			num5 = 1;
			goto IL_019f;
			IL_007d:
			num++;
			goto IL_0083;
			IL_0190:
			num2++;
			goto IL_0196;
			IL_019f:
			bool num6 = num3 > num4 - num5;
			if (3u != 0)
			{
				if (num6)
				{
					if (text.Length > 0)
					{
						return text;
					}
					if (0 == 0)
					{
						return _0083(107396307);
					}
					goto IL_0190;
				}
				num6 = StatusCode.IsBad(results[num2]);
			}
			if (num6)
			{
				bool flag = text == _0083(107396253);
				if (2 == 0)
				{
					goto IL_007d;
				}
				if (flag)
				{
					text = results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name;
				}
				ErrorList.Add(results[num2].ToString() + _0083(107396252) + VarsStringList[num2].Name);
			}
			goto IL_0190;
		}
		catch (Exception ex)
		{
			return _0083(107396302) + ex.Message;
		}
	}

	public static string WriteDINTArray(int[] list, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value = new Variant(list);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteINTArray(short[] list, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value = new Variant(list);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteBOOLArray(bool[] list, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value = new Variant(list);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteLREALArray(double[] list, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value = new Variant(list);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteREALArray(float[] list, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value = new Variant(list);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string WriteSTRINGArray(string[] list, string nodeid, Session session)
	{
		string result;
		try
		{
			StatusCodeCollection statusCodeCollection = default(StatusCodeCollection);
			DiagnosticInfoCollection diagnosticInfoCollection = default(DiagnosticInfoCollection);
			while (true)
			{
				Variant value = new Variant(list);
				WriteValue item = new WriteValue
				{
					NodeId = new NodeId(nodeid),
					AttributeId = 13u,
					Value = new DataValue(value)
				};
				ResponseHeader responseHeader = _000F._007E_0011(session, null, new WriteValueCollection { item }, ref statusCodeCollection, ref diagnosticInfoCollection);
				if (_0010._0012(statusCodeCollection[0]))
				{
					if (0 == 0)
					{
						if (false)
						{
							goto IL_00a1;
						}
						result = statusCodeCollection[0].ToString();
					}
					if (7u != 0)
					{
						break;
					}
					continue;
				}
				goto IL_00a1;
				IL_00a1:
				result = _0083(107396307);
				break;
			}
		}
		catch (Exception ex)
		{
			if (0 == 0 && 0 == 0)
			{
				result = _0012._0016(_0083(107396302), _0011._007E_0014(ex));
			}
		}
		return result;
	}

	public static string ReadBOOLsValueFromVariables(Session session, List<string> nodeidList, ref List<bool> Values)
	{
		List<string> ErrorList = new List<string>();
		string result = default(string);
		try
		{
			do
			{
				if (false || 3u != 0)
				{
				}
			}
			while (4 == 0);
			string text = ReadBOOLsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
			if (0 == 0)
			{
				result = text;
			}
		}
		catch (Exception ex)
		{
			while (true)
			{
				ErrorList.Add(_0083(107396302) + ex.Message);
				if (3u != 0)
				{
					result = _0083(107396302) + ex.Message;
					if (4u != 0)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public static string ReadBOOLsValueFromVariables(Session session, List<string> nodeidList, ref List<bool> Values, ref List<string> ErrorList)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection dataValueCollection = new DataValueCollection();
			DataValueCollection values;
			if (0 == 0)
			{
				values = dataValueCollection;
			}
			IList<ServiceResult> errors = null;
			int num = 0;
			while (true)
			{
				IL_004e:
				int num2 = num;
				int num3 = nodeidList.Count - 1;
				while (true)
				{
					if (num2 > num3)
					{
						session.ReadValues(list, out values, out errors);
						if (Values == null)
						{
							Values = new List<bool>();
						}
						Values.Clear();
						int num4 = 0;
						while (true)
						{
							if (num4 <= values.Count - 1)
							{
								if (uint.MaxValue != 0)
								{
									if (values[num4].Value == null || !(values[num4].Value.GetType() == typeof(bool)))
									{
										goto IL_00ee;
									}
									Values.Add((bool)values[num4].Value);
									goto IL_00f8;
								}
								goto IL_01b3;
							}
							int num5 = 0;
							while (true)
							{
								bool flag = num5 <= errors.Count - 1;
								if (7 == 0)
								{
									break;
								}
								if (!flag)
								{
									goto end_IL_00ff;
								}
								bool flag2 = errors[num5].Code != 0;
								if (0 == 0)
								{
									if (flag2)
									{
										ErrorList.Add(errors[num5].ToString() + _0083(107396252) + nodeidList[num5]);
									}
									num5++;
									continue;
								}
								goto IL_00ee;
							}
							continue;
							IL_00f8:
							num4++;
							continue;
							IL_00ee:
							Values.Add(item: false);
							goto IL_00f8;
							continue;
							end_IL_00ff:
							break;
						}
						num2 = ErrorList.Count;
						num3 = 0;
						if (num3 != 0)
						{
							continue;
						}
						if (num2 == num3)
						{
							result = _0083(107396307);
						}
						else if (2u != 0)
						{
							result = ErrorList[0];
							break;
						}
						goto IL_01b3;
					}
					list.Add(new NodeId(nodeidList[num]));
					if (8 == 0)
					{
					}
					goto IL_004a;
					IL_01b3:
					if (7u != 0)
					{
						break;
					}
					goto IL_004a;
					IL_004a:
					num++;
					goto IL_004e;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadBOOLsValueFromVariables(Session session, ref List<VariableBOOLDef> ReadVarBOOL)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection values = new DataValueCollection();
			IList<ServiceResult> errors;
			if (8u != 0)
			{
				errors = null;
			}
			int num;
			if (0 == 0)
			{
				num = 0;
				goto IL_0057;
			}
			goto IL_00de;
			IL_00de:
			int num2;
			ReadVarBOOL[num2].Value = false;
			goto IL_00ef;
			IL_020e:
			list.Add(new NodeId(ReadVarBOOL[num].Name));
			num++;
			goto IL_0057;
			IL_0121:
			if (6 == 0)
			{
				goto IL_00ef;
			}
			int i = 0;
			if (8u != 0)
			{
				for (; i <= errors.Count - 1; i++)
				{
					if (errors[i].Code != 0)
					{
						ErrorList.Add(errors[i].ToString() + _0083(107396252) + ReadVarBOOL[i].Name);
					}
				}
				if (ErrorList.Count == 0)
				{
					result = _0083(107396307);
					if (false)
					{
						goto IL_00ef;
					}
				}
				else
				{
					result = ErrorList[0];
				}
			}
			goto end_IL_0001;
			IL_0057:
			bool flag = num <= ReadVarBOOL.Count - 1;
			goto IL_0068;
			IL_0068:
			if (flag)
			{
				goto IL_020e;
			}
			session.ReadValues(list, out values, out errors);
			num2 = 0;
			goto IL_00f9;
			IL_00ef:
			if (7u != 0)
			{
				num2++;
				goto IL_00f9;
			}
			goto IL_0121;
			IL_00f9:
			if (false)
			{
				goto IL_020e;
			}
			if (num2 <= values.Count - 1)
			{
				if (values[num2].Value == null || !(values[num2].Value.GetType() == typeof(bool)))
				{
					goto IL_00de;
				}
				if (false)
				{
					goto IL_0068;
				}
				ReadVarBOOL[num2].Value = (bool)values[num2].Value;
				goto IL_00ef;
			}
			ErrorList.Clear();
			goto IL_0121;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadDINTsValueFromVariables(Session session, List<string> nodeidList, ref List<int> Values)
	{
		List<string> ErrorList = new List<string>();
		string result = default(string);
		try
		{
			do
			{
				if (false || 3u != 0)
				{
				}
			}
			while (4 == 0);
			string text = ReadDINTsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
			if (0 == 0)
			{
				result = text;
			}
		}
		catch (Exception ex)
		{
			while (true)
			{
				ErrorList.Add(_0083(107396302) + ex.Message);
				if (3u != 0)
				{
					result = _0083(107396302) + ex.Message;
					if (4u != 0)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public static string ReadDINTsValueFromVariables(Session session, List<string> nodeidList, ref List<int> Values, ref List<string> ErrorList)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection dataValueCollection = new DataValueCollection();
			DataValueCollection values;
			if (0 == 0)
			{
				values = dataValueCollection;
			}
			IList<ServiceResult> errors = null;
			int num = 0;
			while (true)
			{
				IL_004e:
				int num2 = num;
				int num3 = nodeidList.Count - 1;
				while (true)
				{
					if (num2 > num3)
					{
						session.ReadValues(list, out values, out errors);
						if (Values == null)
						{
							Values = new List<int>();
						}
						Values.Clear();
						int num4 = 0;
						while (true)
						{
							if (num4 <= values.Count - 1)
							{
								if (uint.MaxValue != 0)
								{
									if (values[num4].Value == null || !(values[num4].Value.GetType() == typeof(int)))
									{
										goto IL_00ee;
									}
									Values.Add((int)values[num4].Value);
									goto IL_00f8;
								}
								goto IL_01b3;
							}
							int num5 = 0;
							while (true)
							{
								bool flag = num5 <= errors.Count - 1;
								if (7 == 0)
								{
									break;
								}
								if (!flag)
								{
									goto end_IL_00ff;
								}
								bool flag2 = errors[num5].Code != 0;
								if (0 == 0)
								{
									if (flag2)
									{
										ErrorList.Add(errors[num5].ToString() + _0083(107396252) + nodeidList[num5]);
									}
									num5++;
									continue;
								}
								goto IL_00ee;
							}
							continue;
							IL_00f8:
							num4++;
							continue;
							IL_00ee:
							Values.Add(0);
							goto IL_00f8;
							continue;
							end_IL_00ff:
							break;
						}
						num2 = ErrorList.Count;
						num3 = 0;
						if (num3 != 0)
						{
							continue;
						}
						if (num2 == num3)
						{
							result = _0083(107396307);
						}
						else if (2u != 0)
						{
							result = ErrorList[0];
							break;
						}
						goto IL_01b3;
					}
					list.Add(new NodeId(nodeidList[num]));
					if (8 == 0)
					{
					}
					goto IL_004a;
					IL_01b3:
					if (7u != 0)
					{
						break;
					}
					goto IL_004a;
					IL_004a:
					num++;
					goto IL_004e;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadDINTsValueFromVariables(Session session, ref List<VariableDINTDef> ReadVarDINT)
	{
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection values = new DataValueCollection();
			IList<ServiceResult> errors;
			if (0 == 0)
			{
				errors = null;
			}
			int num = 0;
			int num4 = default(int);
			while (true)
			{
				int num2 = ((num > ReadVarDINT.Count - 1) ? 1 : 0);
				bool num3;
				if (true)
				{
					bool flag = num2 == 0;
					num3 = flag;
					goto IL_006a;
				}
				goto IL_01bf;
				IL_019b:
				ErrorList.Clear();
				if (5u != 0)
				{
					num4 = 0;
					goto IL_020b;
				}
				goto IL_023a;
				IL_01bf:
				if (num2 != 0)
				{
					ErrorList.Add(errors[num4].ToString() + _0083(107396252) + ReadVarDINT[num4].Name);
				}
				int num5 = num4;
				goto IL_0207;
				IL_023a:
				return _0083(107396307);
				IL_006a:
				int num7;
				int num8;
				int num9;
				if (!num3)
				{
					session.ReadValues(list, out values, out errors);
					int num6 = 0;
					while (true)
					{
						num7 = num6;
						num8 = values.Count - 1;
						if (7 == 0)
						{
							break;
						}
						if (num7 > num8)
						{
							goto IL_019b;
						}
						string text = values[num6].Value.GetType().ToString();
						num9 = ((values[num6].Value != null && values[num6].Value.GetType() == typeof(int)) ? 1 : 0);
						if (6u != 0)
						{
							if (num9 != 0)
							{
								ReadVarDINT[num6].Value = (int)values[num6].Value;
								goto IL_0176;
							}
							num5 = ((values[num6].Value != null && values[num6].Value.GetType() == typeof(short)) ? 1 : 0);
							if (0 == 0)
							{
								if (num5 != 0)
								{
									ReadVarDINT[num6].Value = Convert.ToInt32(values[num6].Value.ToString());
								}
								else
								{
									ReadVarDINT[num6].Value = 0;
								}
								goto IL_0176;
							}
							goto IL_0207;
						}
						goto IL_021a;
						IL_0176:
						num6++;
					}
					goto IL_0215;
				}
				list.Add(new NodeId(ReadVarDINT[num].Name));
				num++;
				continue;
				IL_0207:
				num4 = num5 + 1;
				goto IL_020b;
				IL_020b:
				num7 = num4;
				num8 = errors.Count - 1;
				goto IL_0215;
				IL_0215:
				num9 = ((num7 <= num8) ? 1 : 0);
				goto IL_021a;
				IL_021a:
				bool flag2 = (byte)num9 != 0;
				num3 = flag2;
				if (1 == 0)
				{
					goto IL_006a;
				}
				if (num3)
				{
					num2 = (int)errors[num4].Code;
					goto IL_01bf;
				}
				if (ErrorList.Count != 0 && 0 == 0)
				{
					break;
				}
				goto IL_023a;
			}
			return ErrorList[0];
		}
		catch (Exception ex)
		{
			if (8u != 0)
			{
				ErrorList.Add(_0083(107396302) + ex.Message);
			}
			return _0083(107396302) + ex.Message;
		}
	}

	public static string ReadINTsValueFromVariables(Session session, List<string> nodeidList, ref List<short> Values)
	{
		List<string> ErrorList = new List<string>();
		string result = default(string);
		try
		{
			do
			{
				if (false || 3u != 0)
				{
				}
			}
			while (4 == 0);
			string text = ReadINTsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
			if (0 == 0)
			{
				result = text;
			}
		}
		catch (Exception ex)
		{
			while (true)
			{
				ErrorList.Add(_0083(107396302) + ex.Message);
				if (3u != 0)
				{
					result = _0083(107396302) + ex.Message;
					if (4u != 0)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public static string ReadINTsValueFromVariables(Session session, List<string> nodeidList, ref List<short> Values, ref List<string> ErrorList)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection dataValueCollection = new DataValueCollection();
			DataValueCollection values;
			if (0 == 0)
			{
				values = dataValueCollection;
			}
			IList<ServiceResult> errors = null;
			int num = 0;
			while (true)
			{
				IL_004e:
				int num2 = num;
				int num3 = nodeidList.Count - 1;
				while (true)
				{
					if (num2 > num3)
					{
						session.ReadValues(list, out values, out errors);
						if (Values == null)
						{
							Values = new List<short>();
						}
						Values.Clear();
						int num4 = 0;
						while (true)
						{
							if (num4 <= values.Count - 1)
							{
								if (uint.MaxValue != 0)
								{
									if (values[num4].Value == null || !(values[num4].Value.GetType() == typeof(short)))
									{
										goto IL_00ee;
									}
									Values.Add((short)values[num4].Value);
									goto IL_00f8;
								}
								goto IL_01b3;
							}
							int num5 = 0;
							while (true)
							{
								bool flag = num5 <= errors.Count - 1;
								if (7 == 0)
								{
									break;
								}
								if (!flag)
								{
									goto end_IL_00ff;
								}
								bool flag2 = errors[num5].Code != 0;
								if (0 == 0)
								{
									if (flag2)
									{
										ErrorList.Add(errors[num5].ToString() + _0083(107396252) + nodeidList[num5]);
									}
									num5++;
									continue;
								}
								goto IL_00ee;
							}
							continue;
							IL_00f8:
							num4++;
							continue;
							IL_00ee:
							Values.Add(0);
							goto IL_00f8;
							continue;
							end_IL_00ff:
							break;
						}
						num2 = ErrorList.Count;
						num3 = 0;
						if (num3 != 0)
						{
							continue;
						}
						if (num2 == num3)
						{
							result = _0083(107396307);
						}
						else if (2u != 0)
						{
							result = ErrorList[0];
							break;
						}
						goto IL_01b3;
					}
					list.Add(new NodeId(nodeidList[num]));
					if (8 == 0)
					{
					}
					goto IL_004a;
					IL_01b3:
					if (7u != 0)
					{
						break;
					}
					goto IL_004a;
					IL_004a:
					num++;
					goto IL_004e;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadINTsValueFromVariables(Session session, ref List<VariableINTDef> ReadVarINT)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection values = new DataValueCollection();
			IList<ServiceResult> errors;
			if (8u != 0)
			{
				errors = null;
			}
			int num;
			if (0 == 0)
			{
				num = 0;
				goto IL_0057;
			}
			goto IL_00de;
			IL_00de:
			int num2;
			ReadVarINT[num2].Value = 0;
			goto IL_00ef;
			IL_020e:
			list.Add(new NodeId(ReadVarINT[num].Name));
			num++;
			goto IL_0057;
			IL_0121:
			if (6 == 0)
			{
				goto IL_00ef;
			}
			int i = 0;
			if (8u != 0)
			{
				for (; i <= errors.Count - 1; i++)
				{
					if (errors[i].Code != 0)
					{
						ErrorList.Add(errors[i].ToString() + _0083(107396252) + ReadVarINT[i].Name);
					}
				}
				if (ErrorList.Count == 0)
				{
					result = _0083(107396307);
					if (false)
					{
						goto IL_00ef;
					}
				}
				else
				{
					result = ErrorList[0];
				}
			}
			goto end_IL_0001;
			IL_0057:
			bool flag = num <= ReadVarINT.Count - 1;
			goto IL_0068;
			IL_0068:
			if (flag)
			{
				goto IL_020e;
			}
			session.ReadValues(list, out values, out errors);
			num2 = 0;
			goto IL_00f9;
			IL_00ef:
			if (7u != 0)
			{
				num2++;
				goto IL_00f9;
			}
			goto IL_0121;
			IL_00f9:
			if (false)
			{
				goto IL_020e;
			}
			if (num2 <= values.Count - 1)
			{
				if (values[num2].Value == null || !(values[num2].Value.GetType() == typeof(short)))
				{
					goto IL_00de;
				}
				if (false)
				{
					goto IL_0068;
				}
				ReadVarINT[num2].Value = (short)values[num2].Value;
				goto IL_00ef;
			}
			ErrorList.Clear();
			goto IL_0121;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadLREALsValueFromVariables(Session session, List<string> nodeidList, ref List<double> Values)
	{
		List<string> ErrorList = new List<string>();
		string result = default(string);
		try
		{
			do
			{
				if (false || 3u != 0)
				{
				}
			}
			while (4 == 0);
			string text = ReadLREALsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
			if (0 == 0)
			{
				result = text;
			}
		}
		catch (Exception ex)
		{
			while (true)
			{
				ErrorList.Add(_0083(107396302) + ex.Message);
				if (3u != 0)
				{
					result = _0083(107396302) + ex.Message;
					if (4u != 0)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public static string ReadLREALsValueFromVariables(Session session, List<string> nodeidList, ref List<double> Values, ref List<string> ErrorList)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection dataValueCollection = new DataValueCollection();
			DataValueCollection values;
			if (0 == 0)
			{
				values = dataValueCollection;
			}
			IList<ServiceResult> errors = null;
			int num = 0;
			while (true)
			{
				IL_004e:
				int num2 = num;
				int num3 = nodeidList.Count - 1;
				while (true)
				{
					if (num2 > num3)
					{
						session.ReadValues(list, out values, out errors);
						if (Values == null)
						{
							Values = new List<double>();
						}
						Values.Clear();
						int num4 = 0;
						while (true)
						{
							if (num4 <= values.Count - 1)
							{
								if (uint.MaxValue != 0)
								{
									if (values[num4].Value == null || !(values[num4].Value.GetType() == typeof(double)))
									{
										goto IL_00ee;
									}
									Values.Add((double)values[num4].Value);
									goto IL_0100;
								}
								goto IL_01bb;
							}
							int num5 = 0;
							while (true)
							{
								bool flag = num5 <= errors.Count - 1;
								if (7 == 0)
								{
									break;
								}
								if (!flag)
								{
									goto end_IL_0107;
								}
								bool flag2 = errors[num5].Code != 0;
								if (0 == 0)
								{
									if (flag2)
									{
										ErrorList.Add(errors[num5].ToString() + _0083(107396252) + nodeidList[num5]);
									}
									num5++;
									continue;
								}
								goto IL_00ee;
							}
							continue;
							IL_0100:
							num4++;
							continue;
							IL_00ee:
							Values.Add(0.0);
							goto IL_0100;
							continue;
							end_IL_0107:
							break;
						}
						num2 = ErrorList.Count;
						num3 = 0;
						if (num3 != 0)
						{
							continue;
						}
						if (num2 == num3)
						{
							result = _0083(107396307);
						}
						else if (2u != 0)
						{
							result = ErrorList[0];
							break;
						}
						goto IL_01bb;
					}
					list.Add(new NodeId(nodeidList[num]));
					if (8 == 0)
					{
					}
					goto IL_004a;
					IL_01bb:
					if (7u != 0)
					{
						break;
					}
					goto IL_004a;
					IL_004a:
					num++;
					goto IL_004e;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadLREALsValueFromVariables(Session session, ref List<VariableLREALDef> ReadVarLREAL)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection values = new DataValueCollection();
			IList<ServiceResult> errors;
			if (8u != 0)
			{
				errors = null;
			}
			int num;
			if (0 == 0)
			{
				num = 0;
				goto IL_0057;
			}
			goto IL_00e1;
			IL_00e1:
			int num2;
			ReadVarLREAL[num2].Value = 0.0;
			goto IL_00fa;
			IL_0219:
			list.Add(new NodeId(ReadVarLREAL[num].Name));
			num++;
			goto IL_0057;
			IL_012c:
			if (6 == 0)
			{
				goto IL_00fa;
			}
			int i = 0;
			if (8u != 0)
			{
				for (; i <= errors.Count - 1; i++)
				{
					if (errors[i].Code != 0)
					{
						ErrorList.Add(errors[i].ToString() + _0083(107396252) + ReadVarLREAL[i].Name);
					}
				}
				if (ErrorList.Count == 0)
				{
					result = _0083(107396307);
					if (false)
					{
						goto IL_00fa;
					}
				}
				else
				{
					result = ErrorList[0];
				}
			}
			goto end_IL_0001;
			IL_0057:
			bool flag = num <= ReadVarLREAL.Count - 1;
			goto IL_0068;
			IL_0068:
			if (flag)
			{
				goto IL_0219;
			}
			session.ReadValues(list, out values, out errors);
			num2 = 0;
			goto IL_0104;
			IL_00fa:
			if (7u != 0)
			{
				num2++;
				goto IL_0104;
			}
			goto IL_012c;
			IL_0104:
			if (false)
			{
				goto IL_0219;
			}
			if (num2 <= values.Count - 1)
			{
				if (values[num2].Value == null || !(values[num2].Value.GetType() == typeof(double)))
				{
					goto IL_00e1;
				}
				if (false)
				{
					goto IL_0068;
				}
				ReadVarLREAL[num2].Value = (double)values[num2].Value;
				goto IL_00fa;
			}
			ErrorList.Clear();
			goto IL_012c;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadREALsValueFromVariables(Session session, List<string> nodeidList, ref List<float> Values)
	{
		List<string> ErrorList = new List<string>();
		string result = default(string);
		try
		{
			do
			{
				if (false || 3u != 0)
				{
				}
			}
			while (4 == 0);
			string text = ReadREALsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
			if (0 == 0)
			{
				result = text;
			}
		}
		catch (Exception ex)
		{
			while (true)
			{
				ErrorList.Add(_0083(107396302) + ex.Message);
				if (3u != 0)
				{
					result = _0083(107396302) + ex.Message;
					if (4u != 0)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public static string ReadREALsValueFromVariables(Session session, List<string> nodeidList, ref List<float> Values, ref List<string> ErrorList)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection dataValueCollection = new DataValueCollection();
			DataValueCollection values;
			if (0 == 0)
			{
				values = dataValueCollection;
			}
			IList<ServiceResult> errors = null;
			int num = 0;
			while (true)
			{
				IL_004e:
				int num2 = num;
				int num3 = nodeidList.Count - 1;
				while (true)
				{
					if (num2 > num3)
					{
						session.ReadValues(list, out values, out errors);
						if (Values == null)
						{
							Values = new List<float>();
						}
						Values.Clear();
						int num4 = 0;
						while (true)
						{
							if (num4 <= values.Count - 1)
							{
								if (uint.MaxValue != 0)
								{
									if (values[num4].Value == null || !(values[num4].Value.GetType() == typeof(float)))
									{
										goto IL_00ee;
									}
									Values.Add((float)values[num4].Value);
									goto IL_00fc;
								}
								goto IL_01b7;
							}
							int num5 = 0;
							while (true)
							{
								bool flag = num5 <= errors.Count - 1;
								if (7 == 0)
								{
									break;
								}
								if (!flag)
								{
									goto end_IL_0103;
								}
								bool flag2 = errors[num5].Code != 0;
								if (0 == 0)
								{
									if (flag2)
									{
										ErrorList.Add(errors[num5].ToString() + _0083(107396252) + nodeidList[num5]);
									}
									num5++;
									continue;
								}
								goto IL_00ee;
							}
							continue;
							IL_00fc:
							num4++;
							continue;
							IL_00ee:
							Values.Add(0f);
							goto IL_00fc;
							continue;
							end_IL_0103:
							break;
						}
						num2 = ErrorList.Count;
						num3 = 0;
						if (num3 != 0)
						{
							continue;
						}
						if (num2 == num3)
						{
							result = _0083(107396307);
						}
						else if (2u != 0)
						{
							result = ErrorList[0];
							break;
						}
						goto IL_01b7;
					}
					list.Add(new NodeId(nodeidList[num]));
					if (8 == 0)
					{
					}
					goto IL_004a;
					IL_01b7:
					if (7u != 0)
					{
						break;
					}
					goto IL_004a;
					IL_004a:
					num++;
					goto IL_004e;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadREALsValueFromVariables(Session session, ref List<VariableREALDef> ReadVarREAL)
	{
		string result;
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection values = new DataValueCollection();
			IList<ServiceResult> errors;
			if (8u != 0)
			{
				errors = null;
			}
			int num;
			if (0 == 0)
			{
				num = 0;
				goto IL_0057;
			}
			goto IL_00e1;
			IL_00e1:
			int num2;
			ReadVarREAL[num2].Value = 0f;
			goto IL_00f6;
			IL_0215:
			list.Add(new NodeId(ReadVarREAL[num].Name));
			num++;
			goto IL_0057;
			IL_0128:
			if (6 == 0)
			{
				goto IL_00f6;
			}
			int i = 0;
			if (8u != 0)
			{
				for (; i <= errors.Count - 1; i++)
				{
					if (errors[i].Code != 0)
					{
						ErrorList.Add(errors[i].ToString() + _0083(107396252) + ReadVarREAL[i].Name);
					}
				}
				if (ErrorList.Count == 0)
				{
					result = _0083(107396307);
					if (false)
					{
						goto IL_00f6;
					}
				}
				else
				{
					result = ErrorList[0];
				}
			}
			goto end_IL_0001;
			IL_0057:
			bool flag = num <= ReadVarREAL.Count - 1;
			goto IL_0068;
			IL_0068:
			if (flag)
			{
				goto IL_0215;
			}
			session.ReadValues(list, out values, out errors);
			num2 = 0;
			goto IL_0100;
			IL_00f6:
			if (7u != 0)
			{
				num2++;
				goto IL_0100;
			}
			goto IL_0128;
			IL_0100:
			if (false)
			{
				goto IL_0215;
			}
			if (num2 <= values.Count - 1)
			{
				if (values[num2].Value == null || !(values[num2].Value.GetType() == typeof(float)))
				{
					goto IL_00e1;
				}
				if (false)
				{
					goto IL_0068;
				}
				ReadVarREAL[num2].Value = (float)values[num2].Value;
				goto IL_00f6;
			}
			ErrorList.Clear();
			goto IL_0128;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			result = _0083(107396302) + ex.Message;
		}
		return result;
	}

	public static string ReadSTRINGsValueFromVariables(Session session, List<string> nodeidList, ref List<string> Values)
	{
		List<string> ErrorList = new List<string>();
		string result = default(string);
		try
		{
			do
			{
				if (false || 3u != 0)
				{
				}
			}
			while (4 == 0);
			string text = ReadSTRINGsValueFromVariables(session, nodeidList, ref Values, ref ErrorList);
			if (0 == 0)
			{
				result = text;
			}
		}
		catch (Exception ex)
		{
			while (true)
			{
				ErrorList.Add(_0083(107396302) + ex.Message);
				if (3u != 0)
				{
					result = _0083(107396302) + ex.Message;
					if (4u != 0)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public static string ReadSTRINGsValueFromVariables(Session session, List<string> nodeidList, ref List<string> Values, ref List<string> ErrorList)
	{
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection values = new DataValueCollection();
			IList<ServiceResult> errors = null;
			int num = 0;
			int num4 = default(int);
			while (true)
			{
				int num2;
				int count;
				int num3;
				if (0 == 0)
				{
					num2 = num;
					count = nodeidList.Count;
					num3 = 1;
					goto IL_005a;
				}
				goto IL_00d4;
				IL_008c:
				Values.Clear();
				num4 = 0;
				goto IL_0111;
				IL_00d4:
				Values.Add((string)values[num4].Value);
				goto IL_010a;
				IL_010a:
				num4++;
				goto IL_0111;
				IL_0111:
				num2 = num4;
				count = values.Count;
				num3 = 1;
				goto IL_011a;
				IL_011a:
				if (num2 <= count - num3)
				{
					if (values[num4].Value != null && values[num4].Value.GetType() == typeof(double))
					{
						goto IL_00d4;
					}
					Values.Add(_0083(107396253));
					goto IL_010a;
				}
				int num5 = 0;
				goto IL_017f;
				IL_017c:
				int num6;
				num5 = num2 + num6;
				goto IL_017f;
				IL_017f:
				num2 = num5;
				count = errors.Count;
				num3 = 1;
				if (num3 == 0)
				{
					goto IL_011a;
				}
				if (num3 == 0)
				{
					goto IL_005a;
				}
				if (num2 <= count - num3)
				{
					if (errors[num5].Code != 0)
					{
						ErrorList.Add(errors[num5].ToString() + _0083(107396252) + nodeidList[num5]);
					}
					num2 = num5;
					num6 = 1;
					goto IL_017c;
				}
				bool flag = ErrorList.Count == 0;
				if (0 == 0 && flag)
				{
					return _0083(107396307);
				}
				if (5u != 0)
				{
					break;
				}
				goto IL_008c;
				IL_005a:
				num6 = count - num3;
				if (7u != 0)
				{
					if (num2 <= num6)
					{
						list.Add(new NodeId(nodeidList[num]));
						if (uint.MaxValue != 0)
						{
							num++;
							continue;
						}
					}
					else
					{
						session.ReadValues(list, out values, out errors);
					}
					if (Values == null)
					{
						Values = new List<string>();
					}
					goto IL_008c;
				}
				goto IL_017c;
			}
			return ErrorList[0];
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			return _0083(107396302) + ex.Message;
		}
	}

	public static string ReadSTRINGsValueFromVariables(Session session, ref List<VariableSTRINGDef> ReadVarSTRING)
	{
		try
		{
			List<NodeId> list = new List<NodeId>();
			DataValueCollection values = new DataValueCollection();
			IList<ServiceResult> errors = null;
			int num = 0;
			int num7 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					bool num3 = num2 <= ReadVarSTRING.Count - 1;
					int num5;
					int num6;
					if (6u != 0)
					{
						if (!num3)
						{
							session.ReadValues(list, out values, out errors);
							int num4 = 0;
							while (num4 <= values.Count - 1)
							{
								if (0 == 0)
								{
									if (values[num4].Value != null && values[num4].Value.GetType() == typeof(string))
									{
										ReadVarSTRING[num4].Value = (string)values[num4].Value;
									}
									else
									{
										ReadVarSTRING[num4].Value = _0083(107396253);
									}
									num5 = num4;
									num6 = 1;
									if (num6 != 0)
									{
										num4 = num5 + num6;
										continue;
									}
									goto IL_01a3;
								}
								goto IL_01e2;
							}
							ErrorList.Clear();
							num7 = 0;
							goto IL_0199;
						}
						list.Add(new NodeId(ReadVarSTRING[num2].Name));
						num2++;
						continue;
					}
					goto IL_01c1;
					IL_01e2:
					return ErrorList[0];
					IL_01bf:
					int num8;
					int num9;
					num3 = num8 == num9;
					goto IL_01c1;
					IL_0199:
					num5 = num7;
					num6 = errors.Count - 1;
					goto IL_01a3;
					IL_01c1:
					bool flag = num3;
					while (flag)
					{
						if (7u != 0)
						{
							return _0083(107396307);
						}
					}
					goto IL_01e2;
					IL_01a3:
					num8 = ((num5 > num6) ? 1 : 0);
					num9 = 0;
					while (num8 != num9)
					{
						num8 = ErrorList.Count;
						num9 = 0;
						if (num9 != 0)
						{
							continue;
						}
						goto IL_01bf;
					}
					num = (int)errors[num7].Code;
					if (false)
					{
						break;
					}
					int num10 = ((num != 0) ? 1 : 0);
					do
					{
						if (num10 != 0)
						{
							ErrorList.Add(errors[num7].ToString() + _0083(107396252) + ReadVarSTRING[num7].Name);
						}
						num10 = num7;
					}
					while (1 == 0);
					num7 = num10 + 1;
					goto IL_0199;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorList.Add(_0083(107396302) + ex.Message);
			return _0083(107396302) + ex.Message;
		}
	}

	public static string ReadBOOLValue(Session session, string nodeid, ref bool Value)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(bool).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396279);
				}
			}
			while (false);
			Value = (bool)obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadDINTValue(Session session, string nodeid, ref int Value)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(int).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396222);
				}
			}
			while (false);
			Value = (int)obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadINTValue(Session session, string nodeid, ref short Value)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(short).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396197);
				}
			}
			while (false);
			Value = (short)obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadLREALValue(Session session, string nodeid, ref double Value)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(double).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396168);
				}
			}
			while (false);
			Value = (double)obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadREALValue(Session session, string nodeid, ref float Value)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(float).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396171);
				}
			}
			while (false);
			Value = (float)obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadSTRINGValue(Session session, string nodeid, ref string Value)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(string).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396654);
				}
			}
			while (false);
			Value = (string)obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadDINTArray(Session session, string nodeid, ref int[] Values)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(int[]).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396625);
				}
			}
			while (false);
			Values = (int[])obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadINTArray(Session session, string nodeid, ref short[] Values)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(short[]).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396596);
				}
			}
			while (false);
			Values = (short[])obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadBOOLArray(Session session, string nodeid, ref bool[] Values)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(bool[]).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396567);
				}
			}
			while (false);
			Values = (bool[])obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadLREALArray(Session session, string nodeid, ref double[] Values)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(double[]).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396506);
				}
			}
			while (false);
			Values = (double[])obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadREALArray(Session session, string nodeid, ref float[] Values)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(float[]).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396505);
				}
			}
			while (false);
			Values = (float[])obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ReadSTRINGArray(Session session, string nodeid, ref string[] Values)
	{
		try
		{
			object obj;
			do
			{
				obj = _0014._007E_0018(_0013._007E_0017(session, new NodeId(nodeid)));
				while (true)
				{
					bool flag = obj != null && _0017._001D(_0015._007E_0019(obj), _0016._001C(typeof(string[]).TypeHandle));
					while (!flag)
					{
						if (false)
						{
							continue;
						}
						goto IL_0087;
					}
					break;
					IL_0087:
					if (false)
					{
						continue;
					}
					return _0083(107396444);
				}
			}
			while (false);
			Values = (string[])obj;
			if (5u != 0)
			{
				return _0083(107396307);
			}
		}
		catch (Exception ex)
		{
			return _0012._0016(_0083(107396302), _0011._007E_0014(ex));
		}
		string result;
		return result;
	}

	public static string ClassToPLC(object Variable, string RootString, Session session, string AfterString = "")
	{
		int num = _0018._001E();
		if (0 == 0)
		{
			int num2 = num;
		}
		string result;
		try
		{
			if (!AppBool.Connected)
			{
				result = _0083(107396411);
			}
			else if (Variable == null)
			{
				_0019._001F(_0083(107395870));
				result = _0083(107395861);
			}
			else
			{
				FieldInfo[] array = null;
				object obj = null;
				obj = Variable;
				List<VariableREALDef> list = new List<VariableREALDef>();
				List<VariableLREALDef> list2 = new List<VariableLREALDef>();
				List<VariableINTDef> list3 = new List<VariableINTDef>();
				List<VariableDINTDef> list4 = new List<VariableDINTDef>();
				List<VariableSTRINGDef> list5 = new List<VariableSTRINGDef>();
				List<VariableBOOLDef> list6 = new List<VariableBOOLDef>();
				List<VariableENUMDef> list7 = new List<VariableENUMDef>();
				string text = _0083(107396253);
				if (obj != null)
				{
					array = _001A._007E_007F(_0015._007E_0019(obj));
					if (array != null)
					{
						for (int i = 0; i <= array.Length - 1; i++)
						{
							object obj2 = null;
							FieldInfo fieldInfo = array[i];
							string text2 = _0011._007E_0015(fieldInfo);
							string text3 = _0011._007E_0015(fieldInfo);
							if (_001B._007E_0080(_0011._007E_0013(_0015._007E_001A(fieldInfo)), _0083(107395808)) >= 0)
							{
								continue;
							}
							obj2 = _001C._007E_0081(fieldInfo, obj);
							if (_0017._001D(_0015._007E_001B(_0015._007E_001A(fieldInfo)), _0016._001C(typeof(Enum).TypeHandle)))
							{
								short val = _001D._0082(obj2);
								VariableINTDef item = new VariableINTDef(_001E._0083(RootString, text2, AfterString), val);
								list3.Add(item);
							}
							if (_0017._001D(_0015._007E_0019(obj2), _0016._001C(typeof(double).TypeHandle)))
							{
								double val2 = _001F._0084(obj2);
								VariableLREALDef item2 = new VariableLREALDef(_001E._0083(RootString, text2, AfterString), val2);
								list2.Add(item2);
							}
							if (_0017._001D(_0015._007E_0019(obj2), _0016._001C(typeof(float).TypeHandle)))
							{
								float val3 = _007F._0086(obj2);
								VariableREALDef item3 = new VariableREALDef(_001E._0083(RootString, text2, AfterString), val3);
								list.Add(item3);
							}
							if (_0017._001D(_0015._007E_0019(obj2), _0016._001C(typeof(int).TypeHandle)))
							{
								int val4 = _0080._0087(obj2);
								VariableDINTDef item4 = new VariableDINTDef(_001E._0083(RootString, text2, AfterString), val4);
								list4.Add(item4);
							}
							if (_0017._001D(_0015._007E_0019(obj2), _0016._001C(typeof(short).TypeHandle)))
							{
								short val5 = _001D._0082(obj2);
								VariableINTDef item5 = new VariableINTDef(_001E._0083(RootString, text2, AfterString), val5);
								list3.Add(item5);
							}
							if (_0017._001D(_0015._007E_0019(obj2), _0016._001C(typeof(bool).TypeHandle)))
							{
								bool val6 = _0081._0088(obj2);
								VariableBOOLDef item6 = new VariableBOOLDef(_001E._0083(RootString, text2, AfterString), val6);
								list6.Add(item6);
							}
							if (_0017._001D(_0015._007E_0019(obj2), _0016._001C(typeof(string).TypeHandle)))
							{
								string text4 = _0082._0089(obj2);
								if (global::_0083._007E_008A(text4) > 0)
								{
									VariableSTRINGDef item7 = new VariableSTRINGDef(_001E._0083(RootString, text2, AfterString), text4);
									list5.Add(item7);
								}
							}
						}
					}
					List<string> list8 = new List<string>();
					text = _0083(107396253);
					if (list6.Count > 0)
					{
						string text5 = WriteBOOLList(list6, session);
						if (_0084._008B(text, _0083(107396253)) & _0084._008C(text5, _0083(107396307)))
						{
							text = text5;
						}
						list8.AddRange(ErrorList);
						ErrorList.Clear();
					}
					while (true)
					{
						if (list3.Count > 0)
						{
							string text6 = WriteINTList(list3, session);
							if (_0084._008B(text, _0083(107396253)) & _0084._008C(text6, _0083(107396307)))
							{
								text = text6;
							}
							list8.AddRange(ErrorList);
							ErrorList.Clear();
						}
						if (list4.Count > 0)
						{
							string text7 = WriteDINTList(list4, session);
							if (_0084._008B(text, _0083(107396253)) & _0084._008C(text7, _0083(107396307)))
							{
								text = text7;
							}
							list8.AddRange(ErrorList);
							ErrorList.Clear();
						}
						string text8;
						bool num3;
						if (list.Count > 0)
						{
							text8 = WriteREALList(list, session);
							num3 = _0084._008B(text, _0083(107396253));
							goto IL_05eb;
						}
						goto IL_062c;
						IL_05eb:
						if (num3 & _0084._008C(text8, _0083(107396307)))
						{
							text = text8;
						}
						list8.AddRange(ErrorList);
						ErrorList.Clear();
						goto IL_062c;
						IL_062c:
						if (list2.Count > 0)
						{
							string text9 = WriteLREALList(list2, session);
							if (_0084._008B(text, _0083(107396253)) & _0084._008C(text9, _0083(107396307)))
							{
								text = text9;
							}
							list8.AddRange(ErrorList);
							ErrorList.Clear();
						}
						bool flag = list5.Count > 0;
						num3 = flag;
						if (8u != 0)
						{
							if (num3)
							{
								string text10 = WriteSTRINGList(list5, session);
								if (_0084._008B(text, _0083(107396253)) & _0084._008C(text10, _0083(107396307)))
								{
									text = text10;
								}
								list8.AddRange(ErrorList);
								ErrorList.Clear();
							}
							if (list7.Count > 0)
							{
								string text11 = WriteENUMList(list7, session);
								if (_0084._008B(text, _0083(107396253)) & _0084._008C(text11, _0083(107396307)))
								{
									text = text11;
								}
								list8.AddRange(ErrorList);
								ErrorList.Clear();
							}
							if (_0084._008B(text, _0083(107396253)))
							{
								text = _0083(107396307);
							}
							ErrorList.AddRange(list8);
							result = text;
							if (0 == 0)
							{
								break;
							}
							continue;
						}
						goto IL_05eb;
					}
				}
				else
				{
					result = _0083(107395861);
				}
			}
		}
		catch (Exception ex)
		{
			string text12 = _0012._0016(_0083(107395831), _0011._007E_0013(Variable));
			_0086._008D(ex, _0083(107395782), false, text12);
			if (0 == 0)
			{
				result = _0083(107395797);
			}
		}
		return result;
	}

	static OPCReadWrite()
	{
		Strings.CreateGetStringDelegate(typeof(OPCReadWrite));
		ErrorList = new List<string>();
		LocalErrorList = new List<string>();
	}
}
