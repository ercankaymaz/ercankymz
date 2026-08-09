using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using ProtoBuf;

namespace devDept.Serialization;

public abstract class Surrogate<T>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D = -1;

	public string Tag;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal StringBuilder _0023_003DzZ9xh1dFMrWh_0024;

	public int Version
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D = value;
		}
	}

	public string Log
	{
		get
		{
			if (_0023_003DzZ9xh1dFMrWh_0024 == null)
			{
				return null;
			}
			return _0023_003DzZ9xh1dFMrWh_0024.ToString();
		}
	}

	protected Surrogate(T obj)
	{
		_0023_003DzDBrp9S8_003D(obj);
	}

	internal Surrogate(int _0023_003DzN0lAKfo_003D)
	{
	}

	private void _0023_003DzDBrp9S8_003D(T _0023_003DzCX9Hbao_003D)
	{
		CopyDataFromObject(_0023_003DzCX9Hbao_003D);
	}

	protected abstract T ConvertToObject();

	protected abstract void CopyDataToObject(T obj);

	protected abstract void CopyDataFromObject(T obj);

	protected void WriteLog(string message)
	{
		if (!string.IsNullOrEmpty(message))
		{
			if (_0023_003DzZ9xh1dFMrWh_0024 == null)
			{
				_0023_003DzZ9xh1dFMrWh_0024 = new StringBuilder();
			}
			_0023_003DzZ9xh1dFMrWh_0024.AppendLine(message);
		}
	}

	[CLSCompliant(false)]
	protected virtual void BeforeDeserialize(SerializationContext serializationContext)
	{
		if (!(serializationContext.Context is Serializer serializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672501));
		}
		Version = serializer.HeaderVersion;
		Tag = serializer.HeaderTag;
		_0023_003DzZ9xh1dFMrWh_0024 = serializer._0023_003DzZ9xh1dFMrWh_0024;
	}

	[CLSCompliant(false)]
	protected virtual void AfterDeserialize(SerializationContext serializationContext)
	{
	}

	[CLSCompliant(false)]
	protected virtual void BeforeSerialize(SerializationContext serializationContext)
	{
		if (!(serializationContext.Context is Serializer serializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672501));
		}
		Version = serializer.HeaderVersion;
	}

	protected static void ThrowDeprecatedException()
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672472));
	}
}
