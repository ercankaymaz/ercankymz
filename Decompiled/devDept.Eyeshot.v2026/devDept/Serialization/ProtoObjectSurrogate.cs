using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;

namespace devDept.Serialization;

public sealed class ProtoObjectSurrogate : Surrogate<ProtoObject>
{
	public object Object;

	private byte[] _object;

	public ProtoObjectSurrogate(ProtoObject protoObj)
		: base(protoObj)
	{
	}

	protected override ProtoObject ConvertToObject()
	{
		return new ProtoObject(Object);
	}

	protected override void CopyDataToObject(ProtoObject objWrap)
	{
	}

	protected override void CopyDataFromObject(ProtoObject objWrap)
	{
		Object = objWrap.Object;
	}

	private object _0023_003DzvJG2lGM_003D(Serializer _0023_003DzMTgjTZQ_003D)
	{
		if (_object == null)
		{
			return null;
		}
		object obj = null;
		MemoryStream memoryStream = new MemoryStream(_object);
		try
		{
			Type type = null;
			try
			{
				string text = _0023_003DzMTgjTZQ_003D.Model.DeserializeWithLengthPrefix(memoryStream, null, typeof(string), PrefixStyle.Base128, 1) as string;
				if (!string.IsNullOrEmpty(text))
				{
					if (base.Version < 7)
					{
						if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672141)) || text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672363)))
						{
							text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672329);
						}
						else if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672291)))
						{
							text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672266);
						}
						else if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671969)))
						{
							text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671968);
						}
					}
					type = _0023_003DzMTgjTZQ_003D.GetType(text);
					if (_0023_003DzMTgjTZQ_003D.Contains(type))
					{
						obj = _0023_003DzMTgjTZQ_003D.Model.Deserialize(memoryStream, null, type, new SerializationContext
						{
							Context = _0023_003DzMTgjTZQ_003D
						});
					}
					else
					{
						string text2 = ((type != null) ? type.ToString() : text);
						_0023_003DzMTgjTZQ_003D.WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671931) + text2);
					}
				}
			}
			catch (Exception ex)
			{
				string text3 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671873);
				text3 = ((!(type != null)) ? (text3 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290)) : (text3 + string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672097), type)));
				text3 = text3 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672084) + ex.Message;
				_0023_003DzMTgjTZQ_003D.WriteLog(text3);
				obj = null;
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
		Object = obj;
		return obj;
	}

	private void _0023_003DzoDcm1_s_003D(Serializer _0023_003DzMTgjTZQ_003D, object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003DzCX9Hbao_003D == null)
		{
			return;
		}
		using MemoryStream memoryStream = new MemoryStream();
		Type type = null;
		try
		{
			type = _0023_003DzCX9Hbao_003D.GetType();
			if (_0023_003DzMTgjTZQ_003D.Contains(type))
			{
				_0023_003DzMTgjTZQ_003D.Model.SerializeWithLengthPrefix(memoryStream, type.AssemblyQualifiedName, typeof(string), PrefixStyle.Base128, 1);
				_0023_003DzMTgjTZQ_003D.Model.Serialize(memoryStream, _0023_003DzCX9Hbao_003D, new SerializationContext
				{
					Context = _0023_003DzMTgjTZQ_003D
				});
				_object = memoryStream.ToArray();
			}
			else
			{
				_0023_003DzMTgjTZQ_003D.WriteLog(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672065), type));
			}
		}
		catch (Exception ex)
		{
			string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671873);
			text = ((!(type != null)) ? (text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290)) : (text + string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672097), type)));
			text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672084) + ex.Message;
			_0023_003DzMTgjTZQ_003D.WriteLog(text);
			_object = null;
		}
	}

	public static implicit operator ProtoObject(ProtoObjectSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator ProtoObjectSurrogate(ProtoObject source)
	{
		return source?.ConvertToSurrogate();
	}

	public static Dictionary<string, Dictionary<string, ProtoObject>> IfcPropertiesToProtoObjects(Dictionary<string, Dictionary<string, object>> properties)
	{
		Dictionary<string, Dictionary<string, ProtoObject>> dictionary = new Dictionary<string, Dictionary<string, ProtoObject>>();
		if (properties != null)
		{
			foreach (KeyValuePair<string, Dictionary<string, object>> property in properties)
			{
				string key = property.Key;
				Dictionary<string, ProtoObject> dictionary2 = new Dictionary<string, ProtoObject>();
				foreach (KeyValuePair<string, object> item in property.Value)
				{
					dictionary2.Add(item.Key, new ProtoObject(item.Value));
				}
				dictionary.Add(key, dictionary2);
			}
		}
		return dictionary;
	}

	public static Dictionary<string, Dictionary<string, object>> IfcPropertiesToObjects(Dictionary<string, Dictionary<string, ProtoObject>> wrapProps)
	{
		Dictionary<string, Dictionary<string, object>> dictionary = new Dictionary<string, Dictionary<string, object>>();
		if (wrapProps != null)
		{
			foreach (KeyValuePair<string, Dictionary<string, ProtoObject>> wrapProp in wrapProps)
			{
				string key = wrapProp.Key;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				if (wrapProp.Value != null)
				{
					foreach (KeyValuePair<string, ProtoObject> item in wrapProp.Value)
					{
						dictionary2.Add(item.Key, item.Value.Object);
					}
				}
				dictionary.Add(key, dictionary2);
			}
		}
		return dictionary;
	}

	[CLSCompliant(false)]
	protected override void AfterDeserialize(SerializationContext serializationContext)
	{
		base.AfterDeserialize(serializationContext);
		if (!(serializationContext.Context is Serializer _0023_003DzMTgjTZQ_003D))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670603));
		}
		_0023_003DzvJG2lGM_003D(_0023_003DzMTgjTZQ_003D);
	}

	[CLSCompliant(false)]
	protected override void BeforeSerialize(SerializationContext serializationContext)
	{
		base.BeforeSerialize(serializationContext);
		if (!(serializationContext.Context is Serializer serializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670603));
		}
		_0023_003DzoDcm1_s_003D(serializer, Object);
		serializer.WriteLog(base.Log);
	}
}
