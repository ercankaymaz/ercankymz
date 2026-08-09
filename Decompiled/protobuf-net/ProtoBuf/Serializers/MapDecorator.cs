using System;
using System.Collections.Generic;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers;

internal class MapDecorator<TDictionary, TKey, TValue> : ProtoDecoratorBase where TDictionary : class, IDictionary<TKey, TValue>
{
	private readonly Type concreteType;

	private readonly IProtoSerializer keyTail;

	private readonly int fieldNumber;

	private readonly WireType wireType;

	private static readonly MethodInfo indexerSet = GetIndexerSetter();

	private static readonly TKey DefaultKey = ((typeof(TKey) == typeof(string)) ? ((TKey)(object)"") : default(TKey));

	private static readonly TValue DefaultValue = ((typeof(TValue) == typeof(string)) ? ((TValue)(object)"") : default(TValue));

	public override Type ExpectedType => typeof(TDictionary);

	public override bool ReturnsValue => true;

	public override bool RequiresOldValue => AppendToCollection;

	private bool AppendToCollection { get; }

	internal MapDecorator(TypeModel model, Type concreteType, IProtoSerializer keyTail, IProtoSerializer valueTail, int fieldNumber, WireType wireType, WireType keyWireType, WireType valueWireType, bool overwriteList)
		: base((DefaultValue == null) ? ((ProtoDecoratorBase)new TagDecorator(2, valueWireType, strict: false, valueTail)) : ((ProtoDecoratorBase)new DefaultValueDecorator(model, DefaultValue, new TagDecorator(2, valueWireType, strict: false, valueTail))))
	{
		this.wireType = wireType;
		this.keyTail = new DefaultValueDecorator(model, DefaultKey, new TagDecorator(1, keyWireType, strict: false, keyTail));
		this.fieldNumber = fieldNumber;
		this.concreteType = concreteType ?? typeof(TDictionary);
		if (keyTail.RequiresOldValue)
		{
			throw new InvalidOperationException("Key tail should not require the old value");
		}
		if (!keyTail.ReturnsValue)
		{
			throw new InvalidOperationException("Key tail should return a value");
		}
		if (!valueTail.ReturnsValue)
		{
			throw new InvalidOperationException("Value tail should return a value");
		}
		AppendToCollection = !overwriteList;
	}

	private static MethodInfo GetIndexerSetter()
	{
		PropertyInfo[] properties = typeof(TDictionary).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (propertyInfo.Name != "Item" || propertyInfo.PropertyType != typeof(TValue))
			{
				continue;
			}
			ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
			if (indexParameters != null && indexParameters.Length == 1 && !(indexParameters[0].ParameterType != typeof(TKey)))
			{
				MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
				if (setMethod != null)
				{
					return setMethod;
				}
			}
		}
		throw new InvalidOperationException("Unable to resolve indexer for map");
	}

	public override object Read(object untyped, ProtoReader source)
	{
		TDictionary val = (AppendToCollection ? ((TDictionary)untyped) : null);
		if (val == null)
		{
			val = (TDictionary)Activator.CreateInstance(concreteType);
		}
		do
		{
			TKey key = DefaultKey;
			TValue val2 = DefaultValue;
			SubItemToken token = ProtoReader.StartSubItem(source);
			int num;
			while ((num = source.ReadFieldHeader()) > 0)
			{
				switch (num)
				{
				case 1:
					key = (TKey)keyTail.Read(null, source);
					break;
				case 2:
					val2 = (TValue)Tail.Read(Tail.RequiresOldValue ? ((object)val2) : null, source);
					break;
				default:
					source.SkipField();
					break;
				}
			}
			ProtoReader.EndSubItem(token, source);
			val[key] = val2;
		}
		while (source.TryReadFieldHeader(fieldNumber));
		return val;
	}

	public override void Write(object untyped, ProtoWriter dest)
	{
		foreach (KeyValuePair<TKey, TValue> item in (TDictionary)untyped)
		{
			ProtoWriter.WriteFieldHeader(fieldNumber, wireType, dest);
			SubItemToken token = ProtoWriter.StartSubItem(null, dest);
			if (item.Key != null)
			{
				keyTail.Write(item.Key, dest);
			}
			if (item.Value != null)
			{
				Tail.Write(item.Value, dest);
			}
			ProtoWriter.EndSubItem(token, dest);
		}
	}

	protected override void EmitWrite(CompilerContext ctx, Local valueFrom)
	{
		Type typeFromHandle = typeof(KeyValuePair<TKey, TValue>);
		MethodInfo moveNext;
		MethodInfo current;
		MethodInfo enumeratorInfo = ListDecorator.GetEnumeratorInfo(ctx.Model, ExpectedType, typeFromHandle, out moveNext, out current);
		Type returnType = enumeratorInfo.ReturnType;
		MethodInfo getMethod = typeFromHandle.GetProperty("Key").GetGetMethod();
		MethodInfo getMethod2 = typeFromHandle.GetProperty("Value").GetGetMethod();
		using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
		using Local local2 = new Local(ctx, returnType);
		using Local local3 = new Local(ctx, typeof(SubItemToken));
		using Local local4 = new Local(ctx, typeFromHandle);
		ctx.LoadAddress(local, ExpectedType);
		ctx.EmitCall(enumeratorInfo, ExpectedType);
		ctx.StoreValue(local2);
		using (ctx.Using(local2))
		{
			CodeLabel label = ctx.DefineLabel();
			CodeLabel label2 = ctx.DefineLabel();
			ctx.Branch(label2, @short: false);
			ctx.MarkLabel(label);
			ctx.LoadAddress(local2, returnType);
			ctx.EmitCall(current, returnType);
			if (typeFromHandle != ctx.MapType(typeof(object)) && current.ReturnType == ctx.MapType(typeof(object)))
			{
				ctx.CastFromObject(typeFromHandle);
			}
			ctx.StoreValue(local4);
			ctx.LoadValue(fieldNumber);
			ctx.LoadValue((int)wireType);
			ctx.LoadReaderWriter();
			ctx.EmitCall(ctx.MapType(typeof(ProtoWriter)).GetMethod("WriteFieldHeader"));
			ctx.LoadNullRef();
			ctx.LoadReaderWriter();
			ctx.EmitCall(ctx.MapType(typeof(ProtoWriter)).GetMethod("StartSubItem"));
			ctx.StoreValue(local3);
			ctx.LoadAddress(local4, typeFromHandle);
			ctx.EmitCall(getMethod, typeFromHandle);
			ctx.WriteNullCheckedTail(typeof(TKey), keyTail, null);
			ctx.LoadAddress(local4, typeFromHandle);
			ctx.EmitCall(getMethod2, typeFromHandle);
			ctx.WriteNullCheckedTail(typeof(TValue), Tail, null);
			ctx.LoadValue(local3);
			ctx.LoadReaderWriter();
			ctx.EmitCall(ctx.MapType(typeof(ProtoWriter)).GetMethod("EndSubItem"));
			ctx.MarkLabel(label2);
			ctx.LoadAddress(local2, returnType);
			ctx.EmitCall(moveNext, returnType);
			ctx.BranchIfTrue(label, @short: false);
		}
	}

	protected override void EmitRead(CompilerContext ctx, Local valueFrom)
	{
		using Local local = (AppendToCollection ? ctx.GetLocalWithValue(ExpectedType, valueFrom) : new Local(ctx, typeof(TDictionary)));
		using Local local2 = new Local(ctx, typeof(SubItemToken));
		using Local local3 = new Local(ctx, typeof(TKey));
		using Local local4 = new Local(ctx, typeof(TValue));
		using Local local5 = new Local(ctx, ctx.MapType(typeof(int)));
		if (!AppendToCollection)
		{
			ctx.LoadNullRef();
			ctx.StoreValue(local);
		}
		if (concreteType != null)
		{
			ctx.LoadValue(local);
			CodeLabel label = ctx.DefineLabel();
			ctx.BranchIfTrue(label, @short: true);
			ctx.EmitCtor(concreteType);
			ctx.StoreValue(local);
			ctx.MarkLabel(label);
		}
		CodeLabel label2 = ctx.DefineLabel();
		ctx.MarkLabel(label2);
		if (typeof(TKey) == typeof(string))
		{
			ctx.LoadValue("");
			ctx.StoreValue(local3);
		}
		else
		{
			ctx.InitLocal(typeof(TKey), local3);
		}
		if (typeof(TValue) == typeof(string))
		{
			ctx.LoadValue("");
			ctx.StoreValue(local4);
		}
		else
		{
			ctx.InitLocal(typeof(TValue), local4);
		}
		ctx.LoadReaderWriter();
		ctx.EmitCall(ctx.MapType(typeof(ProtoReader)).GetMethod("StartSubItem"));
		ctx.StoreValue(local2);
		CodeLabel label3 = ctx.DefineLabel();
		CodeLabel label4 = ctx.DefineLabel();
		ctx.Branch(label3, @short: false);
		ctx.MarkLabel(label4);
		ctx.LoadValue(local5);
		CodeLabel codeLabel = ctx.DefineLabel();
		CodeLabel codeLabel2 = ctx.DefineLabel();
		CodeLabel codeLabel3 = ctx.DefineLabel();
		ctx.Switch(new CodeLabel[3] { codeLabel, codeLabel2, codeLabel3 });
		ctx.MarkLabel(codeLabel);
		ctx.LoadReaderWriter();
		ctx.EmitCall(ctx.MapType(typeof(ProtoReader)).GetMethod("SkipField"));
		ctx.Branch(label3, @short: false);
		ctx.MarkLabel(codeLabel2);
		keyTail.EmitRead(ctx, null);
		ctx.StoreValue(local3);
		ctx.Branch(label3, @short: false);
		ctx.MarkLabel(codeLabel3);
		Tail.EmitRead(ctx, Tail.RequiresOldValue ? local4 : null);
		ctx.StoreValue(local4);
		ctx.MarkLabel(label3);
		ctx.EmitBasicRead("ReadFieldHeader", ctx.MapType(typeof(int)));
		ctx.CopyValue();
		ctx.StoreValue(local5);
		ctx.LoadValue(0);
		ctx.BranchIfGreater(label4, @short: false);
		ctx.LoadValue(local2);
		ctx.LoadReaderWriter();
		ctx.EmitCall(ctx.MapType(typeof(ProtoReader)).GetMethod("EndSubItem"));
		ctx.LoadAddress(local, ExpectedType);
		ctx.LoadValue(local3);
		ctx.LoadValue(local4);
		ctx.EmitCall(indexerSet);
		ctx.LoadReaderWriter();
		ctx.LoadValue(fieldNumber);
		ctx.EmitCall(ctx.MapType(typeof(ProtoReader)).GetMethod("TryReadFieldHeader"));
		ctx.BranchIfTrue(label2, @short: false);
		if (ReturnsValue)
		{
			ctx.LoadValue(local);
		}
	}
}
