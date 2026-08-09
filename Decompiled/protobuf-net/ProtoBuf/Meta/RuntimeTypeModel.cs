using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ProtoBuf.Compiler;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta;

public sealed class RuntimeTypeModel : TypeModel
{
	private sealed class Singleton
	{
		internal static readonly RuntimeTypeModel Value = new RuntimeTypeModel(isDefault: true);

		private Singleton()
		{
		}
	}

	[Flags]
	internal enum CommonImports
	{
		None = 0,
		Bcl = 1,
		Timestamp = 2,
		Duration = 4,
		Protogen = 8
	}

	private sealed class BasicType
	{
		private readonly Type type;

		private readonly IProtoSerializer serializer;

		public Type Type => type;

		public IProtoSerializer Serializer => serializer;

		public BasicType(Type type, IProtoSerializer serializer)
		{
			this.type = type;
			this.serializer = serializer;
		}
	}

	internal sealed class SerializerPair : IComparable
	{
		public readonly int MetaKey;

		public readonly int BaseKey;

		public readonly MetaType Type;

		public readonly MethodBuilder Serialize;

		public readonly MethodBuilder Deserialize;

		public readonly ILGenerator SerializeBody;

		public readonly ILGenerator DeserializeBody;

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentException("obj");
			}
			SerializerPair serializerPair = (SerializerPair)obj;
			if (BaseKey == MetaKey)
			{
				if (serializerPair.BaseKey == serializerPair.MetaKey)
				{
					return MetaKey.CompareTo(serializerPair.MetaKey);
				}
				return 1;
			}
			if (serializerPair.BaseKey == serializerPair.MetaKey)
			{
				return -1;
			}
			int num = BaseKey.CompareTo(serializerPair.BaseKey);
			if (num == 0)
			{
				num = MetaKey.CompareTo(serializerPair.MetaKey);
			}
			return num;
		}

		public SerializerPair(int metaKey, int baseKey, MetaType type, MethodBuilder serialize, MethodBuilder deserialize, ILGenerator serializeBody, ILGenerator deserializeBody)
		{
			MetaKey = metaKey;
			BaseKey = baseKey;
			Serialize = serialize;
			Deserialize = deserialize;
			SerializeBody = serializeBody;
			DeserializeBody = deserializeBody;
			Type = type;
		}
	}

	public sealed class CompilerOptions
	{
		private string targetFrameworkName;

		private string targetFrameworkDisplayName;

		private string typeName;

		private string outputPath;

		private string imageRuntimeVersion;

		private int metaDataVersion;

		private Accessibility accessibility;

		public string TargetFrameworkName
		{
			get
			{
				return targetFrameworkName;
			}
			set
			{
				targetFrameworkName = value;
			}
		}

		public string TargetFrameworkDisplayName
		{
			get
			{
				return targetFrameworkDisplayName;
			}
			set
			{
				targetFrameworkDisplayName = value;
			}
		}

		public string TypeName
		{
			get
			{
				return typeName;
			}
			set
			{
				typeName = value;
			}
		}

		public string OutputPath
		{
			get
			{
				return outputPath;
			}
			set
			{
				outputPath = value;
			}
		}

		public string ImageRuntimeVersion
		{
			get
			{
				return imageRuntimeVersion;
			}
			set
			{
				imageRuntimeVersion = value;
			}
		}

		public int MetaDataVersion
		{
			get
			{
				return metaDataVersion;
			}
			set
			{
				metaDataVersion = value;
			}
		}

		public string AssemblyCompanyName { get; set; }

		public string AssemblyCopyright { get; set; }

		public string AssemblyDescription { get; set; }

		public string AssemblyProductName { get; set; }

		public string AssemblyTitle { get; set; }

		public string AssemblyTrademark { get; set; }

		public Version AssemblyVersion { get; set; }

		public Version AssemblyProductVersion { get; set; }

		public Accessibility Accessibility
		{
			get
			{
				return accessibility;
			}
			set
			{
				accessibility = value;
			}
		}

		public void SetFrameworkOptions(MetaType from)
		{
			if (from == null)
			{
				throw new ArgumentNullException("from");
			}
			AttributeMap[] array = AttributeMap.Create(from.Model, Helpers.GetAssembly(from.Type));
			AttributeMap[] array2 = array;
			foreach (AttributeMap attributeMap in array2)
			{
				if (attributeMap.AttributeType.FullName == "System.Runtime.Versioning.TargetFrameworkAttribute")
				{
					if (attributeMap.TryGet("FrameworkName", out var value))
					{
						TargetFrameworkName = (string)value;
					}
					if (attributeMap.TryGet("FrameworkDisplayName", out value))
					{
						TargetFrameworkDisplayName = (string)value;
					}
					break;
				}
			}
		}
	}

	public enum Accessibility
	{
		Public,
		Internal
	}

	private ushort options;

	private const ushort OPTIONS_InferTagFromNameDefault = 1;

	private const ushort OPTIONS_IsDefaultModel = 2;

	private const ushort OPTIONS_Frozen = 4;

	private const ushort OPTIONS_AutoAddMissingTypes = 8;

	private const ushort OPTIONS_AutoCompile = 16;

	private const ushort OPTIONS_UseImplicitZeroDefaults = 32;

	private const ushort OPTIONS_AllowParseableTypes = 64;

	private const ushort OPTIONS_AutoAddProtoContractTypesOnly = 128;

	private const ushort OPTIONS_IncludeDateTimeKind = 256;

	private const ushort OPTIONS_DoNotInternStrings = 512;

	private static readonly BasicList.MatchPredicate MetaTypeFinder = MetaTypeFinderImpl;

	private static readonly BasicList.MatchPredicate BasicTypeFinder = BasicTypeFinderImpl;

	private BasicList basicTypes = new BasicList();

	private readonly BasicList types = new BasicList();

	private const int KnownTypes_Array = 1;

	private const int KnownTypes_Dictionary = 2;

	private const int KnownTypes_Hashtable = 3;

	private const int KnownTypes_ArrayCutoff = 20;

	private int metadataTimeoutMilliseconds = 5000;

	private int contentionCounter = 1;

	private MethodInfo defaultFactory;

	public bool InferTagFromNameDefault
	{
		get
		{
			return GetOption(1);
		}
		set
		{
			SetOption(1, value);
		}
	}

	public bool AutoAddProtoContractTypesOnly
	{
		get
		{
			return GetOption(128);
		}
		set
		{
			SetOption(128, value);
		}
	}

	public bool UseImplicitZeroDefaults
	{
		get
		{
			return GetOption(32);
		}
		set
		{
			if (!value && GetOption(2))
			{
				throw new InvalidOperationException("UseImplicitZeroDefaults cannot be disabled on the default model");
			}
			SetOption(32, value);
		}
	}

	public bool AllowParseableTypes
	{
		get
		{
			return GetOption(64);
		}
		set
		{
			SetOption(64, value);
		}
	}

	public bool IncludeDateTimeKind
	{
		get
		{
			return GetOption(256);
		}
		set
		{
			SetOption(256, value);
		}
	}

	public bool InternStrings
	{
		get
		{
			return !GetOption(512);
		}
		set
		{
			SetOption(512, !value);
		}
	}

	public static RuntimeTypeModel Default => Singleton.Value;

	public MetaType this[Type type] => (MetaType)types[FindOrAddAuto(type, demand: true, addWithContractOnly: false, addEvenIfAutoDisabled: false)];

	public bool AutoCompile
	{
		get
		{
			return GetOption(16);
		}
		set
		{
			SetOption(16, value);
		}
	}

	public bool AutoAddMissingTypes
	{
		get
		{
			return GetOption(8);
		}
		set
		{
			if (!value && GetOption(2))
			{
				throw new InvalidOperationException("The default model must allow missing types");
			}
			ThrowIfFrozen();
			SetOption(8, value);
		}
	}

	public int MetadataTimeoutMilliseconds
	{
		get
		{
			return metadataTimeoutMilliseconds;
		}
		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("MetadataTimeoutMilliseconds");
			}
			metadataTimeoutMilliseconds = value;
		}
	}

	public event LockContentedEventHandler LockContended;

	public event EventHandler<TypeAddedEventArgs> BeforeApplyDefaultBehaviour;

	public event EventHandler<TypeAddedEventArgs> AfterApplyDefaultBehaviour;

	private bool GetOption(ushort option)
	{
		return (options & option) == option;
	}

	private void SetOption(ushort option, bool value)
	{
		if (value)
		{
			options |= option;
		}
		else
		{
			options &= (ushort)(~option);
		}
	}

	protected internal override bool SerializeDateTimeKind()
	{
		return GetOption(256);
	}

	public IEnumerable GetTypes()
	{
		return types;
	}

	public override string GetSchema(Type type, ProtoSyntax syntax)
	{
		BasicList basicList = new BasicList();
		MetaType metaType = null;
		bool flag = false;
		if (type == null)
		{
			BasicList.NodeEnumerator enumerator = types.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MetaType metaType2 = (MetaType)enumerator.Current;
				MetaType surrogateOrBaseOrSelf = metaType2.GetSurrogateOrBaseOrSelf(deep: false);
				if (!basicList.Contains(surrogateOrBaseOrSelf))
				{
					basicList.Add(surrogateOrBaseOrSelf);
					CascadeDependents(basicList, surrogateOrBaseOrSelf);
				}
			}
		}
		else
		{
			Type underlyingType = Helpers.GetUnderlyingType(type);
			if (underlyingType != null)
			{
				type = underlyingType;
			}
			flag = ValueMember.TryGetCoreSerializer(this, DataFormat.Default, type, out var _, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false) != null;
			if (!flag)
			{
				int num = FindOrAddAuto(type, demand: false, addWithContractOnly: false, addEvenIfAutoDisabled: false);
				if (num < 0)
				{
					throw new ArgumentException("The type specified is not a contract-type", "type");
				}
				metaType = ((MetaType)types[num]).GetSurrogateOrBaseOrSelf(deep: false);
				basicList.Add(metaType);
				CascadeDependents(basicList, metaType);
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		string text = null;
		if (!flag)
		{
			IEnumerable enumerable = ((metaType == null) ? types : basicList);
			foreach (MetaType item in enumerable)
			{
				if (item.IsList)
				{
					continue;
				}
				string text2 = item.Type.Namespace;
				if (!string.IsNullOrEmpty(text2) && !text2.StartsWith("System."))
				{
					if (text == null)
					{
						text = text2;
					}
					else if (!(text == text2))
					{
						text = null;
						break;
					}
				}
			}
		}
		switch (syntax)
		{
		case ProtoSyntax.Proto2:
			stringBuilder.AppendLine("syntax = \"proto2\";");
			break;
		case ProtoSyntax.Proto3:
			stringBuilder.AppendLine("syntax = \"proto3\";");
			break;
		default:
			throw new ArgumentOutOfRangeException("syntax");
		}
		if (!string.IsNullOrEmpty(text))
		{
			stringBuilder.Append("package ").Append(text).Append(';');
			Helpers.AppendLine(stringBuilder);
		}
		CommonImports imports = CommonImports.None;
		StringBuilder stringBuilder2 = new StringBuilder();
		MetaType[] array = new MetaType[basicList.Count];
		basicList.CopyTo(array, 0);
		Array.Sort(array, MetaType.Comparer.Default);
		if (flag)
		{
			Helpers.AppendLine(stringBuilder2).Append("message ").Append(type.Name)
				.Append(" {");
			MetaType.NewLine(stringBuilder2, 1).Append((syntax == ProtoSyntax.Proto2) ? "optional " : "").Append(GetSchemaTypeName(type, DataFormat.Default, asReference: false, dynamicType: false, ref imports))
				.Append(" value = 1;");
			Helpers.AppendLine(stringBuilder2).Append('}');
		}
		else
		{
			foreach (MetaType metaType4 in array)
			{
				if (!metaType4.IsList || metaType4 == metaType)
				{
					metaType4.WriteSchema(stringBuilder2, 0, ref imports, syntax);
				}
			}
		}
		if ((imports & CommonImports.Bcl) != CommonImports.None)
		{
			stringBuilder.Append("import \"protobuf-net/bcl.proto\"; // schema for protobuf-net's handling of core .NET types");
			Helpers.AppendLine(stringBuilder);
		}
		if ((imports & CommonImports.Protogen) != CommonImports.None)
		{
			stringBuilder.Append("import \"protobuf-net/protogen.proto\"; // custom protobuf-net options");
			Helpers.AppendLine(stringBuilder);
		}
		if ((imports & CommonImports.Timestamp) != CommonImports.None)
		{
			stringBuilder.Append("import \"google/protobuf/timestamp.proto\";");
			Helpers.AppendLine(stringBuilder);
		}
		if ((imports & CommonImports.Duration) != CommonImports.None)
		{
			stringBuilder.Append("import \"google/protobuf/duration.proto\";");
			Helpers.AppendLine(stringBuilder);
		}
		return Helpers.AppendLine(stringBuilder.Append(stringBuilder2)).ToString();
	}

	private void CascadeDependents(BasicList list, MetaType metaType)
	{
		if (metaType.IsList)
		{
			Type listItemType = TypeModel.GetListItemType(this, metaType.Type);
			TryGetCoreSerializer(list, listItemType);
			return;
		}
		if (metaType.IsAutoTuple)
		{
			if (MetaType.ResolveTupleConstructor(metaType.Type, out var mappedMembers) != null)
			{
				for (int i = 0; i < mappedMembers.Length; i++)
				{
					Type itemType = null;
					if (mappedMembers[i] is PropertyInfo)
					{
						itemType = ((PropertyInfo)mappedMembers[i]).PropertyType;
					}
					else if (mappedMembers[i] is FieldInfo)
					{
						itemType = ((FieldInfo)mappedMembers[i]).FieldType;
					}
					TryGetCoreSerializer(list, itemType);
				}
			}
		}
		else
		{
			foreach (ValueMember field in metaType.Fields)
			{
				Type valueType = field.ItemType;
				if (field.IsMap)
				{
					field.ResolveMapTypes(out var _, out var _, out valueType);
				}
				if (valueType == null)
				{
					valueType = field.MemberType;
				}
				TryGetCoreSerializer(list, valueType);
			}
		}
		foreach (Type allGenericArgument in metaType.GetAllGenericArguments())
		{
			TryGetCoreSerializer(list, allGenericArgument);
		}
		MetaType surrogateOrSelf;
		if (metaType.HasSubtypes)
		{
			SubType[] subtypes = metaType.GetSubtypes();
			foreach (SubType subType in subtypes)
			{
				surrogateOrSelf = subType.DerivedType.GetSurrogateOrSelf();
				if (!list.Contains(surrogateOrSelf))
				{
					list.Add(surrogateOrSelf);
					CascadeDependents(list, surrogateOrSelf);
				}
			}
		}
		surrogateOrSelf = metaType.BaseType;
		if (surrogateOrSelf != null)
		{
			surrogateOrSelf = surrogateOrSelf.GetSurrogateOrSelf();
		}
		if (surrogateOrSelf != null && !list.Contains(surrogateOrSelf))
		{
			list.Add(surrogateOrSelf);
			CascadeDependents(list, surrogateOrSelf);
		}
	}

	private void TryGetCoreSerializer(BasicList list, Type itemType)
	{
		WireType defaultWireType;
		IProtoSerializer protoSerializer = ValueMember.TryGetCoreSerializer(this, DataFormat.Default, itemType, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false);
		if (protoSerializer != null)
		{
			return;
		}
		int num = FindOrAddAuto(itemType, demand: false, addWithContractOnly: false, addEvenIfAutoDisabled: false);
		if (num >= 0)
		{
			MetaType surrogateOrBaseOrSelf = ((MetaType)types[num]).GetSurrogateOrBaseOrSelf(deep: false);
			if (!list.Contains(surrogateOrBaseOrSelf))
			{
				list.Add(surrogateOrBaseOrSelf);
				CascadeDependents(list, surrogateOrBaseOrSelf);
			}
		}
	}

	public static RuntimeTypeModel Create(string name = null)
	{
		return new RuntimeTypeModel(isDefault: false);
	}

	private RuntimeTypeModel(bool isDefault)
	{
		AutoAddMissingTypes = true;
		UseImplicitZeroDefaults = true;
		SetOption(2, isDefault);
		try
		{
			AutoCompile = EnableAutoCompile();
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool EnableAutoCompile()
	{
		try
		{
			DynamicMethod dynamicMethod = new DynamicMethod("CheckCompilerAvailable", typeof(bool), new Type[1] { typeof(int) });
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldc_I4, 42);
			iLGenerator.Emit(OpCodes.Ceq);
			iLGenerator.Emit(OpCodes.Ret);
			Predicate<int> predicate = (Predicate<int>)dynamicMethod.CreateDelegate(typeof(Predicate<int>));
			return predicate(42);
		}
		catch (Exception)
		{
			return false;
		}
	}

	internal MetaType FindWithoutAdd(Type type)
	{
		BasicList.NodeEnumerator enumerator = types.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MetaType metaType = (MetaType)enumerator.Current;
			if (metaType.Type == type)
			{
				if (metaType.Pending)
				{
					WaitOnLock(metaType);
				}
				return metaType;
			}
		}
		Type type2 = TypeModel.ResolveProxies(type);
		if (!(type2 == null))
		{
			return FindWithoutAdd(type2);
		}
		return null;
	}

	private static bool MetaTypeFinderImpl(object value, object ctx)
	{
		return ((MetaType)value).Type == (Type)ctx;
	}

	private static bool BasicTypeFinderImpl(object value, object ctx)
	{
		return ((BasicType)value).Type == (Type)ctx;
	}

	private void WaitOnLock(MetaType type)
	{
		int opaqueToken = 0;
		try
		{
			TakeLock(ref opaqueToken);
		}
		finally
		{
			ReleaseLock(opaqueToken);
		}
	}

	internal IProtoSerializer TryGetBasicTypeSerializer(Type type)
	{
		int num = basicTypes.IndexOf(BasicTypeFinder, type);
		if (num >= 0)
		{
			return ((BasicType)basicTypes[num]).Serializer;
		}
		lock (basicTypes)
		{
			num = basicTypes.IndexOf(BasicTypeFinder, type);
			if (num >= 0)
			{
				return ((BasicType)basicTypes[num]).Serializer;
			}
			WireType defaultWireType;
			IProtoSerializer protoSerializer = ((MetaType.GetContractFamily(this, type, null) == MetaType.AttributeFamily.None) ? ValueMember.TryGetCoreSerializer(this, DataFormat.Default, type, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false) : null);
			if (protoSerializer != null)
			{
				basicTypes.Add(new BasicType(type, protoSerializer));
			}
			return protoSerializer;
		}
	}

	internal int FindOrAddAuto(Type type, bool demand, bool addWithContractOnly, bool addEvenIfAutoDisabled)
	{
		int num = types.IndexOf(MetaTypeFinder, type);
		if (num >= 0)
		{
			MetaType metaType = (MetaType)types[num];
			if (metaType.Pending)
			{
				WaitOnLock(metaType);
			}
			return num;
		}
		bool flag = AutoAddMissingTypes || addEvenIfAutoDisabled;
		if (!Helpers.IsEnum(type) && TryGetBasicTypeSerializer(type) != null)
		{
			if (flag && !addWithContractOnly)
			{
				throw MetaType.InbuiltType(type);
			}
			return -1;
		}
		Type type2 = TypeModel.ResolveProxies(type);
		if (type2 != null && type2 != type)
		{
			num = types.IndexOf(MetaTypeFinder, type2);
			type = type2;
		}
		if (num < 0)
		{
			int opaqueToken = 0;
			Type type3 = type;
			bool flag2 = false;
			try
			{
				TakeLock(ref opaqueToken);
				MetaType metaType;
				if ((metaType = RecogniseCommonTypes(type)) == null)
				{
					MetaType.AttributeFamily contractFamily = MetaType.GetContractFamily(this, type, null);
					if (contractFamily == MetaType.AttributeFamily.AutoTuple)
					{
						flag = (addEvenIfAutoDisabled = true);
					}
					if (!flag || (!Helpers.IsEnum(type) && addWithContractOnly && contractFamily == MetaType.AttributeFamily.None))
					{
						if (demand)
						{
							TypeModel.ThrowUnexpectedType(type);
						}
						return num;
					}
					metaType = Create(type);
				}
				metaType.Pending = true;
				int num2 = types.IndexOf(MetaTypeFinder, type);
				if (num2 < 0)
				{
					ThrowIfFrozen();
					num = types.Add(metaType);
					flag2 = true;
				}
				else
				{
					num = num2;
				}
				if (flag2)
				{
					metaType.ApplyDefaultBehaviour();
					metaType.Pending = false;
				}
			}
			finally
			{
				ReleaseLock(opaqueToken);
				if (flag2)
				{
					ResetKeyCache();
				}
			}
		}
		return num;
	}

	private MetaType RecogniseCommonTypes(Type type)
	{
		return null;
	}

	private MetaType Create(Type type)
	{
		ThrowIfFrozen();
		return new MetaType(this, type, defaultFactory);
	}

	public MetaType Add(Type type, bool applyDefaultBehaviour)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		MetaType metaType = FindWithoutAdd(type);
		if (metaType != null)
		{
			return metaType;
		}
		int opaqueToken = 0;
		if (type.IsInterface && MapType(MetaType.ienumerable).IsAssignableFrom(type) && TypeModel.GetListItemType(this, type) == null)
		{
			throw new ArgumentException("IEnumerable[<T>] data cannot be used as a meta-type unless an Add method can be resolved");
		}
		try
		{
			metaType = RecogniseCommonTypes(type);
			if (metaType != null)
			{
				if (!applyDefaultBehaviour)
				{
					throw new ArgumentException("Default behaviour must be observed for certain types with special handling; " + type.FullName, "applyDefaultBehaviour");
				}
				applyDefaultBehaviour = false;
			}
			if (metaType == null)
			{
				metaType = Create(type);
			}
			metaType.Pending = true;
			TakeLock(ref opaqueToken);
			if (FindWithoutAdd(type) != null)
			{
				throw new ArgumentException("Duplicate type", "type");
			}
			ThrowIfFrozen();
			types.Add(metaType);
			if (applyDefaultBehaviour)
			{
				metaType.ApplyDefaultBehaviour();
			}
			metaType.Pending = false;
			return metaType;
		}
		finally
		{
			ReleaseLock(opaqueToken);
			ResetKeyCache();
		}
	}

	private void ThrowIfFrozen()
	{
		if (GetOption(4))
		{
			throw new InvalidOperationException("The model cannot be changed once frozen");
		}
	}

	public void Freeze()
	{
		if (GetOption(2))
		{
			throw new InvalidOperationException("The default model cannot be frozen");
		}
		SetOption(4, value: true);
	}

	protected override int GetKeyImpl(Type type)
	{
		return GetKey(type, demand: false, getBaseKey: true);
	}

	internal int GetKey(Type type, bool demand, bool getBaseKey)
	{
		try
		{
			int num = FindOrAddAuto(type, demand, addWithContractOnly: true, addEvenIfAutoDisabled: false);
			if (num >= 0)
			{
				MetaType source = (MetaType)types[num];
				if (getBaseKey)
				{
					source = MetaType.GetRootType(source);
					num = FindOrAddAuto(source.Type, demand: true, addWithContractOnly: true, addEvenIfAutoDisabled: false);
				}
			}
			return num;
		}
		catch (NotSupportedException)
		{
			throw;
		}
		catch (Exception ex2)
		{
			if (ex2.Message.IndexOf(type.FullName) >= 0)
			{
				throw;
			}
			throw new ProtoException(ex2.Message + " (" + type.FullName + ")", ex2);
		}
	}

	protected internal override void Serialize(int key, object value, ProtoWriter dest)
	{
		((MetaType)types[key]).Serializer.Write(value, dest);
	}

	protected internal override object Deserialize(int key, object value, ProtoReader source)
	{
		IProtoSerializer serializer = ((MetaType)types[key]).Serializer;
		if (value == null && Helpers.IsValueType(serializer.ExpectedType))
		{
			if (serializer.RequiresOldValue)
			{
				value = Activator.CreateInstance(serializer.ExpectedType);
			}
			return serializer.Read(value, source);
		}
		return serializer.Read(value, source);
	}

	internal ProtoSerializer GetSerializer(IProtoSerializer serializer, bool compiled)
	{
		if (serializer == null)
		{
			throw new ArgumentNullException("serializer");
		}
		if (compiled)
		{
			return CompilerContext.BuildSerializer(serializer, this);
		}
		return serializer.Write;
	}

	public void CompileInPlace()
	{
		BasicList.NodeEnumerator enumerator = types.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MetaType metaType = (MetaType)enumerator.Current;
			metaType.CompileInPlace();
		}
	}

	private void BuildAllSerializers()
	{
		for (int i = 0; i < types.Count; i++)
		{
			MetaType metaType = (MetaType)types[i];
			if (metaType.Serializer == null)
			{
				throw new InvalidOperationException("No serializer available for " + metaType.Type.Name);
			}
		}
	}

	public TypeModel Compile()
	{
		CompilerOptions compilerOptions = new CompilerOptions();
		return Compile(compilerOptions);
	}

	private static ILGenerator Override(TypeBuilder type, string name)
	{
		MethodInfo method = type.BaseType.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
		ParameterInfo[] parameters = method.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		MethodBuilder methodBuilder = type.DefineMethod(method.Name, (method.Attributes & ~MethodAttributes.Abstract) | MethodAttributes.Final, method.CallingConvention, method.ReturnType, array);
		ILGenerator iLGenerator = methodBuilder.GetILGenerator();
		type.DefineMethodOverride(methodBuilder, method);
		return iLGenerator;
	}

	public TypeModel Compile(string name, string path)
	{
		CompilerOptions compilerOptions = new CompilerOptions();
		compilerOptions.TypeName = name;
		compilerOptions.OutputPath = path;
		return Compile(compilerOptions);
	}

	public TypeModel Compile(CompilerOptions options)
	{
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		string text = options.TypeName;
		string outputPath = options.OutputPath;
		BuildAllSerializers();
		Freeze();
		bool flag = !string.IsNullOrEmpty(outputPath);
		if (string.IsNullOrEmpty(text))
		{
			if (flag)
			{
				throw new ArgumentNullException("typeName");
			}
			text = Guid.NewGuid().ToString();
		}
		string text2;
		string name;
		if (outputPath == null)
		{
			text2 = text;
			name = text2 + ".dll";
		}
		else
		{
			text2 = new FileInfo(Path.GetFileNameWithoutExtension(outputPath)).Name;
			name = text2 + Path.GetExtension(outputPath);
		}
		AssemblyName assemblyName = new AssemblyName
		{
			Version = options.AssemblyVersion
		};
		assemblyName.Name = text2;
		AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, (!flag) ? AssemblyBuilderAccess.Run : AssemblyBuilderAccess.RunAndSave);
		ModuleBuilder module = (flag ? assemblyBuilder.DefineDynamicModule(name, outputPath) : assemblyBuilder.DefineDynamicModule(name));
		WriteAssemblyAttributes(options, text2, assemblyBuilder);
		TypeBuilder typeBuilder = WriteBasicTypeModel(options, text, module);
		WriteSerializers(options, text2, typeBuilder, out var index, out var hasInheritance, out var methodPairs, out var ilVersion);
		WriteGetKeyImpl(typeBuilder, hasInheritance, methodPairs, ilVersion, text2, out var il, out var knownTypesCategory, out var knownTypes, out var knownTypesLookupType);
		il = Override(typeBuilder, "SerializeDateTimeKind");
		il.Emit(IncludeDateTimeKind ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
		il.Emit(OpCodes.Ret);
		CompilerContext ctx = WriteSerializeDeserialize(text2, typeBuilder, methodPairs, ilVersion, ref il);
		WriteConstructors(typeBuilder, ref index, methodPairs, ref il, knownTypesCategory, knownTypes, knownTypesLookupType, ctx);
		Type type = typeBuilder.CreateType();
		if (!string.IsNullOrEmpty(outputPath))
		{
			try
			{
				assemblyBuilder.Save(outputPath);
			}
			catch (IOException ex)
			{
				throw new IOException(outputPath + ", " + ex.Message, ex);
			}
		}
		return (TypeModel)Activator.CreateInstance(type);
	}

	private void WriteConstructors(TypeBuilder type, ref int index, SerializerPair[] methodPairs, ref ILGenerator il, int knownTypesCategory, FieldBuilder knownTypes, Type knownTypesLookupType, CompilerContext ctx)
	{
		type.DefineDefaultConstructor(MethodAttributes.Public);
		il = type.DefineTypeInitializer().GetILGenerator();
		switch (knownTypesCategory)
		{
		case 1:
			CompilerContext.LoadValue(il, types.Count);
			il.Emit(OpCodes.Newarr, ctx.MapType(typeof(Type)));
			index = 0;
			foreach (SerializerPair serializerPair3 in methodPairs)
			{
				il.Emit(OpCodes.Dup);
				CompilerContext.LoadValue(il, index);
				il.Emit(OpCodes.Ldtoken, serializerPair3.Type.Type);
				il.EmitCall(OpCodes.Call, ctx.MapType(typeof(Type)).GetMethod("GetTypeFromHandle"), null);
				il.Emit(OpCodes.Stelem_Ref);
				index++;
			}
			il.Emit(OpCodes.Stsfld, knownTypes);
			il.Emit(OpCodes.Ret);
			break;
		case 2:
		{
			CompilerContext.LoadValue(il, types.Count);
			il.Emit(OpCodes.Newobj, knownTypesLookupType.GetConstructor(new Type[1] { MapType(typeof(int)) }));
			il.Emit(OpCodes.Stsfld, knownTypes);
			int num2 = 0;
			foreach (SerializerPair serializerPair2 in methodPairs)
			{
				il.Emit(OpCodes.Ldsfld, knownTypes);
				il.Emit(OpCodes.Ldtoken, serializerPair2.Type.Type);
				il.EmitCall(OpCodes.Call, ctx.MapType(typeof(Type)).GetMethod("GetTypeFromHandle"), null);
				int value2 = num2++;
				int baseKey2 = serializerPair2.BaseKey;
				if (baseKey2 != serializerPair2.MetaKey)
				{
					value2 = -1;
					for (int l = 0; l < methodPairs.Length; l++)
					{
						if (methodPairs[l].BaseKey == baseKey2 && methodPairs[l].MetaKey == baseKey2)
						{
							value2 = l;
							break;
						}
					}
				}
				CompilerContext.LoadValue(il, value2);
				il.EmitCall(OpCodes.Callvirt, knownTypesLookupType.GetMethod("Add", new Type[2]
				{
					MapType(typeof(Type)),
					MapType(typeof(int))
				}), null);
			}
			il.Emit(OpCodes.Ret);
			break;
		}
		case 3:
		{
			CompilerContext.LoadValue(il, types.Count);
			il.Emit(OpCodes.Newobj, knownTypesLookupType.GetConstructor(new Type[1] { MapType(typeof(int)) }));
			il.Emit(OpCodes.Stsfld, knownTypes);
			int num = 0;
			foreach (SerializerPair serializerPair in methodPairs)
			{
				il.Emit(OpCodes.Ldsfld, knownTypes);
				il.Emit(OpCodes.Ldtoken, serializerPair.Type.Type);
				il.EmitCall(OpCodes.Call, ctx.MapType(typeof(Type)).GetMethod("GetTypeFromHandle"), null);
				int value = num++;
				int baseKey = serializerPair.BaseKey;
				if (baseKey != serializerPair.MetaKey)
				{
					value = -1;
					for (int j = 0; j < methodPairs.Length; j++)
					{
						if (methodPairs[j].BaseKey == baseKey && methodPairs[j].MetaKey == baseKey)
						{
							value = j;
							break;
						}
					}
				}
				CompilerContext.LoadValue(il, value);
				il.Emit(OpCodes.Box, MapType(typeof(int)));
				il.EmitCall(OpCodes.Callvirt, knownTypesLookupType.GetMethod("Add", new Type[2]
				{
					MapType(typeof(object)),
					MapType(typeof(object))
				}), null);
			}
			il.Emit(OpCodes.Ret);
			break;
		}
		default:
			throw new InvalidOperationException();
		}
	}

	private CompilerContext WriteSerializeDeserialize(string assemblyName, TypeBuilder type, SerializerPair[] methodPairs, CompilerContext.ILVersion ilVersion, ref ILGenerator il)
	{
		il = Override(type, "Serialize");
		CompilerContext compilerContext = new CompilerContext(il, isStatic: false, isWriter: true, methodPairs, this, ilVersion, assemblyName, MapType(typeof(object)), "Serialize " + type.Name);
		CodeLabel[] array = new CodeLabel[types.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = compilerContext.DefineLabel();
		}
		il.Emit(OpCodes.Ldarg_1);
		compilerContext.Switch(array);
		compilerContext.Return();
		for (int j = 0; j < array.Length; j++)
		{
			SerializerPair serializerPair = methodPairs[j];
			compilerContext.MarkLabel(array[j]);
			il.Emit(OpCodes.Ldarg_2);
			compilerContext.CastFromObject(serializerPair.Type.Type);
			il.Emit(OpCodes.Ldarg_3);
			il.EmitCall(OpCodes.Call, serializerPair.Serialize, null);
			compilerContext.Return();
		}
		il = Override(type, "Deserialize");
		compilerContext = new CompilerContext(il, isStatic: false, isWriter: false, methodPairs, this, ilVersion, assemblyName, MapType(typeof(object)), "Deserialize " + type.Name);
		for (int k = 0; k < array.Length; k++)
		{
			array[k] = compilerContext.DefineLabel();
		}
		il.Emit(OpCodes.Ldarg_1);
		compilerContext.Switch(array);
		compilerContext.LoadNullRef();
		compilerContext.Return();
		for (int l = 0; l < array.Length; l++)
		{
			SerializerPair serializerPair2 = methodPairs[l];
			compilerContext.MarkLabel(array[l]);
			Type type2 = serializerPair2.Type.Type;
			if (Helpers.IsValueType(type2))
			{
				il.Emit(OpCodes.Ldarg_2);
				il.Emit(OpCodes.Ldarg_3);
				il.EmitCall(OpCodes.Call, EmitBoxedSerializer(type, l, type2, methodPairs, this, ilVersion, assemblyName), null);
				compilerContext.Return();
			}
			else
			{
				il.Emit(OpCodes.Ldarg_2);
				compilerContext.CastFromObject(type2);
				il.Emit(OpCodes.Ldarg_3);
				il.EmitCall(OpCodes.Call, serializerPair2.Deserialize, null);
				compilerContext.Return();
			}
		}
		return compilerContext;
	}

	private void WriteGetKeyImpl(TypeBuilder type, bool hasInheritance, SerializerPair[] methodPairs, CompilerContext.ILVersion ilVersion, string assemblyName, out ILGenerator il, out int knownTypesCategory, out FieldBuilder knownTypes, out Type knownTypesLookupType)
	{
		il = Override(type, "GetKeyImpl");
		CompilerContext compilerContext = new CompilerContext(il, isStatic: false, isWriter: false, methodPairs, this, ilVersion, assemblyName, MapType(typeof(Type), demand: true), "GetKeyImpl");
		if (types.Count <= 20)
		{
			knownTypesCategory = 1;
			knownTypesLookupType = MapType(typeof(Type[]), demand: true);
		}
		else
		{
			knownTypesLookupType = MapType(typeof(Dictionary<Type, int>), demand: false);
			if (knownTypesLookupType == null)
			{
				knownTypesLookupType = MapType(typeof(Hashtable), demand: true);
				knownTypesCategory = 3;
			}
			else
			{
				knownTypesCategory = 2;
			}
		}
		knownTypes = type.DefineField("knownTypes", knownTypesLookupType, FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.InitOnly);
		switch (knownTypesCategory)
		{
		case 1:
			il.Emit(OpCodes.Ldsfld, knownTypes);
			il.Emit(OpCodes.Ldarg_1);
			il.EmitCall(OpCodes.Callvirt, MapType(typeof(IList)).GetMethod("IndexOf", new Type[1] { MapType(typeof(object)) }), null);
			if (hasInheritance)
			{
				il.DeclareLocal(MapType(typeof(int)));
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Stloc_0);
				BasicList basicList = new BasicList();
				int num = -1;
				for (int i = 0; i < methodPairs.Length && methodPairs[i].MetaKey != methodPairs[i].BaseKey; i++)
				{
					if (num == methodPairs[i].BaseKey)
					{
						basicList.Add(basicList[basicList.Count - 1]);
						continue;
					}
					basicList.Add(compilerContext.DefineLabel());
					num = methodPairs[i].BaseKey;
				}
				CodeLabel[] array = new CodeLabel[basicList.Count];
				basicList.CopyTo(array, 0);
				compilerContext.Switch(array);
				il.Emit(OpCodes.Ldloc_0);
				il.Emit(OpCodes.Ret);
				num = -1;
				for (int num2 = array.Length - 1; num2 >= 0; num2--)
				{
					if (num != methodPairs[num2].BaseKey)
					{
						num = methodPairs[num2].BaseKey;
						int value = -1;
						for (int j = array.Length; j < methodPairs.Length; j++)
						{
							if (methodPairs[j].BaseKey == num && methodPairs[j].MetaKey == num)
							{
								value = j;
								break;
							}
						}
						compilerContext.MarkLabel(array[num2]);
						CompilerContext.LoadValue(il, value);
						il.Emit(OpCodes.Ret);
					}
				}
			}
			else
			{
				il.Emit(OpCodes.Ret);
			}
			break;
		case 2:
		{
			LocalBuilder local = il.DeclareLocal(MapType(typeof(int)));
			Label label2 = il.DefineLabel();
			il.Emit(OpCodes.Ldsfld, knownTypes);
			il.Emit(OpCodes.Ldarg_1);
			il.Emit(OpCodes.Ldloca_S, local);
			il.EmitCall(OpCodes.Callvirt, knownTypesLookupType.GetMethod("TryGetValue", BindingFlags.Instance | BindingFlags.Public), null);
			il.Emit(OpCodes.Brfalse_S, label2);
			il.Emit(OpCodes.Ldloc_S, local);
			il.Emit(OpCodes.Ret);
			il.MarkLabel(label2);
			il.Emit(OpCodes.Ldc_I4_M1);
			il.Emit(OpCodes.Ret);
			break;
		}
		case 3:
		{
			Label label = il.DefineLabel();
			il.Emit(OpCodes.Ldsfld, knownTypes);
			il.Emit(OpCodes.Ldarg_1);
			il.EmitCall(OpCodes.Callvirt, knownTypesLookupType.GetProperty("Item").GetGetMethod(), null);
			il.Emit(OpCodes.Dup);
			il.Emit(OpCodes.Brfalse_S, label);
			if (ilVersion == CompilerContext.ILVersion.Net1)
			{
				il.Emit(OpCodes.Unbox, MapType(typeof(int)));
				il.Emit(OpCodes.Ldobj, MapType(typeof(int)));
			}
			else
			{
				il.Emit(OpCodes.Unbox_Any, MapType(typeof(int)));
			}
			il.Emit(OpCodes.Ret);
			il.MarkLabel(label);
			il.Emit(OpCodes.Pop);
			il.Emit(OpCodes.Ldc_I4_M1);
			il.Emit(OpCodes.Ret);
			break;
		}
		default:
			throw new InvalidOperationException();
		}
	}

	private void WriteSerializers(CompilerOptions options, string assemblyName, TypeBuilder type, out int index, out bool hasInheritance, out SerializerPair[] methodPairs, out CompilerContext.ILVersion ilVersion)
	{
		index = 0;
		hasInheritance = false;
		methodPairs = new SerializerPair[types.Count];
		BasicList.NodeEnumerator enumerator = types.GetEnumerator();
		while (enumerator.MoveNext())
		{
			MetaType metaType = (MetaType)enumerator.Current;
			MethodBuilder methodBuilder = type.DefineMethod("Write", MethodAttributes.Private | MethodAttributes.Static, CallingConventions.Standard, MapType(typeof(void)), new Type[2]
			{
				metaType.Type,
				MapType(typeof(ProtoWriter))
			});
			MethodBuilder methodBuilder2 = type.DefineMethod("Read", MethodAttributes.Private | MethodAttributes.Static, CallingConventions.Standard, metaType.Type, new Type[2]
			{
				metaType.Type,
				MapType(typeof(ProtoReader))
			});
			SerializerPair serializerPair = new SerializerPair(GetKey(metaType.Type, demand: true, getBaseKey: false), GetKey(metaType.Type, demand: true, getBaseKey: true), metaType, methodBuilder, methodBuilder2, methodBuilder.GetILGenerator(), methodBuilder2.GetILGenerator());
			methodPairs[index++] = serializerPair;
			if (serializerPair.MetaKey != serializerPair.BaseKey)
			{
				hasInheritance = true;
			}
		}
		if (hasInheritance)
		{
			Array.Sort(methodPairs);
		}
		ilVersion = CompilerContext.ILVersion.Net2;
		if (options.MetaDataVersion == 65536)
		{
			ilVersion = CompilerContext.ILVersion.Net1;
		}
		for (index = 0; index < methodPairs.Length; index++)
		{
			SerializerPair serializerPair2 = methodPairs[index];
			CompilerContext compilerContext = new CompilerContext(serializerPair2.SerializeBody, isStatic: true, isWriter: true, methodPairs, this, ilVersion, assemblyName, serializerPair2.Type.Type, "SerializeImpl " + serializerPair2.Type.Type.Name);
			MemberInfo member = serializerPair2.Deserialize.ReturnType;
			compilerContext.CheckAccessibility(ref member);
			serializerPair2.Type.Serializer.EmitWrite(compilerContext, compilerContext.InputValue);
			compilerContext.Return();
			compilerContext = new CompilerContext(serializerPair2.DeserializeBody, isStatic: true, isWriter: false, methodPairs, this, ilVersion, assemblyName, serializerPair2.Type.Type, "DeserializeImpl " + serializerPair2.Type.Type.Name);
			serializerPair2.Type.Serializer.EmitRead(compilerContext, compilerContext.InputValue);
			if (!serializerPair2.Type.Serializer.ReturnsValue)
			{
				compilerContext.LoadValue(compilerContext.InputValue);
			}
			compilerContext.Return();
		}
	}

	private TypeBuilder WriteBasicTypeModel(CompilerOptions options, string typeName, ModuleBuilder module)
	{
		Type type = MapType(typeof(TypeModel));
		TypeAttributes typeAttributes = (type.Attributes & ~TypeAttributes.Abstract) | TypeAttributes.Sealed;
		if (options.Accessibility == Accessibility.Internal)
		{
			typeAttributes &= ~TypeAttributes.Public;
		}
		return module.DefineType(typeName, typeAttributes, type);
	}

	private void WriteAssemblyAttributes(CompilerOptions options, string assemblyName, AssemblyBuilder asm)
	{
		if (!string.IsNullOrEmpty(options.TargetFrameworkName))
		{
			Type type = null;
			try
			{
				type = GetType("System.Runtime.Versioning.TargetFrameworkAttribute", Helpers.GetAssembly(MapType(typeof(string))));
			}
			catch
			{
			}
			if (type != null)
			{
				PropertyInfo[] namedProperties;
				object[] propertyValues;
				if (string.IsNullOrEmpty(options.TargetFrameworkDisplayName))
				{
					namedProperties = new PropertyInfo[0];
					propertyValues = new object[0];
				}
				else
				{
					namedProperties = new PropertyInfo[1] { type.GetProperty("FrameworkDisplayName") };
					propertyValues = new object[1] { options.TargetFrameworkDisplayName };
				}
				CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(type.GetConstructor(new Type[1] { MapType(typeof(string)) }), new object[1] { options.TargetFrameworkName }, namedProperties, propertyValues);
				asm.SetCustomAttribute(customAttribute);
			}
		}
		Type type2 = null;
		try
		{
			type2 = MapType(typeof(InternalsVisibleToAttribute));
		}
		catch
		{
		}
		if (type2 != null)
		{
			BasicList basicList = new BasicList();
			BasicList basicList2 = new BasicList();
			BasicList.NodeEnumerator enumerator = types.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MetaType metaType = (MetaType)enumerator.Current;
				Assembly assembly = Helpers.GetAssembly(metaType.Type);
				if (basicList2.IndexOfReference(assembly) >= 0)
				{
					continue;
				}
				basicList2.Add(assembly);
				AttributeMap[] array = AttributeMap.Create(this, assembly);
				for (int i = 0; i < array.Length; i++)
				{
					if (!(array[i].AttributeType != type2))
					{
						array[i].TryGet("AssemblyName", out var value);
						string text = value as string;
						if (!(text == assemblyName) && !string.IsNullOrEmpty(text) && basicList.IndexOfString(text) < 0)
						{
							basicList.Add(text);
							CustomAttributeBuilder customAttribute2 = new CustomAttributeBuilder(type2.GetConstructor(new Type[1] { MapType(typeof(string)) }), new object[1] { text });
							asm.SetCustomAttribute(customAttribute2);
						}
					}
				}
			}
		}
		WriteAssemblyInfoAttributes(options, asm);
	}

	private void WriteAssemblyInfoAttributes(CompilerOptions options, AssemblyBuilder asm)
	{
		WriteAssemblyInfoAttribute<AssemblyFileVersionAttribute>(options, asm, options.AssemblyVersion?.ToString());
		WriteAssemblyInfoAttribute<AssemblyCompanyAttribute>(options, asm, options.AssemblyCompanyName);
		WriteAssemblyInfoAttribute<AssemblyCopyrightAttribute>(options, asm, options.AssemblyCopyright);
		WriteAssemblyInfoAttribute<AssemblyDescriptionAttribute>(options, asm, options.AssemblyDescription);
		WriteAssemblyInfoAttribute<AssemblyProductAttribute>(options, asm, options.AssemblyProductName);
		WriteAssemblyInfoAttribute<AssemblyTitleAttribute>(options, asm, options.AssemblyTitle);
		WriteAssemblyInfoAttribute<AssemblyTrademarkAttribute>(options, asm, options.AssemblyTrademark);
		WriteAssemblyInfoAttribute<AssemblyInformationalVersionAttribute>(options, asm, options.AssemblyProductVersion?.ToString());
		asm.DefineVersionInfoResource();
	}

	private void WriteAssemblyInfoAttribute<TA>(CompilerOptions options, AssemblyBuilder asm, string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			Type typeFromHandle = typeof(TA);
			Type[] array = new Type[1] { typeof(string) };
			ConstructorInfo constructor = typeFromHandle.GetConstructor(array);
			CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(constructor, new object[1] { value });
			asm.SetCustomAttribute(customAttribute);
		}
	}

	private static MethodBuilder EmitBoxedSerializer(TypeBuilder type, int i, Type valueType, SerializerPair[] methodPairs, TypeModel model, CompilerContext.ILVersion ilVersion, string assemblyName)
	{
		MethodInfo deserialize = methodPairs[i].Deserialize;
		MethodBuilder methodBuilder = type.DefineMethod("_" + i, MethodAttributes.Static, CallingConventions.Standard, model.MapType(typeof(object)), new Type[2]
		{
			model.MapType(typeof(object)),
			model.MapType(typeof(ProtoReader))
		});
		CompilerContext compilerContext = new CompilerContext(methodBuilder.GetILGenerator(), isStatic: true, isWriter: false, methodPairs, model, ilVersion, assemblyName, model.MapType(typeof(object)), "BoxedSerializer " + valueType.Name);
		compilerContext.LoadValue(compilerContext.InputValue);
		CodeLabel label = compilerContext.DefineLabel();
		compilerContext.BranchIfFalse(label, @short: true);
		compilerContext.LoadValue(compilerContext.InputValue);
		compilerContext.CastFromObject(valueType);
		compilerContext.LoadReaderWriter();
		compilerContext.EmitCall(deserialize);
		compilerContext.CastToObject(valueType);
		compilerContext.Return();
		compilerContext.MarkLabel(label);
		using Local local = new Local(compilerContext, valueType);
		compilerContext.LoadAddress(local, valueType);
		compilerContext.EmitCtor(valueType);
		compilerContext.LoadValue(local);
		compilerContext.LoadReaderWriter();
		compilerContext.EmitCall(deserialize);
		compilerContext.CastToObject(valueType);
		compilerContext.Return();
		return methodBuilder;
	}

	internal bool IsPrepared(Type type)
	{
		return FindWithoutAdd(type)?.IsPrepared() ?? false;
	}

	internal EnumSerializer.EnumPair[] GetEnumMap(Type type)
	{
		int num = FindOrAddAuto(type, demand: false, addWithContractOnly: false, addEvenIfAutoDisabled: false);
		if (num >= 0)
		{
			return ((MetaType)types[num]).GetEnumMap();
		}
		return null;
	}

	internal void TakeLock(ref int opaqueToken)
	{
		opaqueToken = 0;
		if (Monitor.TryEnter(types, metadataTimeoutMilliseconds))
		{
			opaqueToken = GetContention();
			return;
		}
		AddContention();
		throw new TimeoutException("Timeout while inspecting metadata; this may indicate a deadlock. This can often be avoided by preparing necessary serializers during application initialization, rather than allowing multiple threads to perform the initial metadata inspection; please also see the LockContended event");
	}

	private int GetContention()
	{
		return Interlocked.CompareExchange(ref contentionCounter, 0, 0);
	}

	private void AddContention()
	{
		Interlocked.Increment(ref contentionCounter);
	}

	internal void ReleaseLock(int opaqueToken)
	{
		if (opaqueToken == 0)
		{
			return;
		}
		Monitor.Exit(types);
		if (opaqueToken == GetContention())
		{
			return;
		}
		LockContentedEventHandler lockContentedEventHandler = this.LockContended;
		if (lockContentedEventHandler != null)
		{
			string stackTrace;
			try
			{
				throw new ProtoException();
			}
			catch (Exception ex)
			{
				stackTrace = ex.StackTrace;
			}
			lockContentedEventHandler(this, new LockContentedEventArgs(stackTrace));
		}
	}

	internal void ResolveListTypes(Type type, ref Type itemType, ref Type defaultType)
	{
		if (type == null || Helpers.GetTypeCode(type) != ProtoTypeCode.Unknown)
		{
			return;
		}
		if (type.IsArray)
		{
			if (type.GetArrayRank() != 1)
			{
				throw new NotSupportedException("Multi-dimension arrays are supported");
			}
			itemType = type.GetElementType();
			if (itemType == MapType(typeof(byte)))
			{
				defaultType = (itemType = null);
			}
			else
			{
				defaultType = type;
			}
		}
		else if (this[type].IgnoreListHandling)
		{
			return;
		}
		if (itemType == null)
		{
			itemType = TypeModel.GetListItemType(this, type);
		}
		if (itemType != null)
		{
			Type itemType2 = null;
			Type defaultType2 = null;
			ResolveListTypes(itemType, ref itemType2, ref defaultType2);
			if (itemType2 != null)
			{
				throw TypeModel.CreateNestedListsNotSupported(type);
			}
		}
		if (!(itemType != null) || !(defaultType == null))
		{
			return;
		}
		if (type.IsClass && !type.IsAbstract && Helpers.GetConstructor(type, Helpers.EmptyTypes, nonPublic: true) != null)
		{
			defaultType = type;
		}
		if (defaultType == null && type.IsInterface)
		{
			Type[] genericArguments;
			if (type.IsGenericType && type.GetGenericTypeDefinition() == MapType(typeof(IDictionary<, >)) && itemType == MapType(typeof(KeyValuePair<, >)).MakeGenericType(genericArguments = type.GetGenericArguments()))
			{
				defaultType = MapType(typeof(Dictionary<, >)).MakeGenericType(genericArguments);
			}
			else
			{
				defaultType = MapType(typeof(List<>)).MakeGenericType(itemType);
			}
		}
		if (defaultType != null && !Helpers.IsAssignableFrom(type, defaultType))
		{
			defaultType = null;
		}
	}

	internal string GetSchemaTypeName(Type effectiveType, DataFormat dataFormat, bool asReference, bool dynamicType, ref CommonImports imports)
	{
		Type underlyingType = Helpers.GetUnderlyingType(effectiveType);
		if (underlyingType != null)
		{
			effectiveType = underlyingType;
		}
		if (effectiveType == MapType(typeof(byte[])))
		{
			return "bytes";
		}
		WireType defaultWireType;
		IProtoSerializer protoSerializer = ValueMember.TryGetCoreSerializer(this, dataFormat, effectiveType, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false);
		if (protoSerializer == null)
		{
			if (asReference || dynamicType)
			{
				imports |= CommonImports.Bcl;
				return ".bcl.NetObjectProxy";
			}
			return this[effectiveType].GetSurrogateOrBaseOrSelf(deep: true).GetSchemaTypeName();
		}
		if (protoSerializer is ParseableSerializer)
		{
			if (asReference)
			{
				imports |= CommonImports.Bcl;
			}
			if (!asReference)
			{
				return "string";
			}
			return ".bcl.NetObjectProxy";
		}
		switch (Helpers.GetTypeCode(effectiveType))
		{
		case ProtoTypeCode.Boolean:
			return "bool";
		case ProtoTypeCode.Single:
			return "float";
		case ProtoTypeCode.Double:
			return "double";
		case ProtoTypeCode.String:
			if (asReference)
			{
				imports |= CommonImports.Bcl;
			}
			if (!asReference)
			{
				return "string";
			}
			return ".bcl.NetObjectProxy";
		case ProtoTypeCode.Char:
		case ProtoTypeCode.Byte:
		case ProtoTypeCode.UInt16:
		case ProtoTypeCode.UInt32:
			if (dataFormat == DataFormat.FixedSize)
			{
				return "fixed32";
			}
			return "uint32";
		case ProtoTypeCode.SByte:
		case ProtoTypeCode.Int16:
		case ProtoTypeCode.Int32:
			return dataFormat switch
			{
				DataFormat.ZigZag => "sint32", 
				DataFormat.FixedSize => "sfixed32", 
				_ => "int32", 
			};
		case ProtoTypeCode.UInt64:
			if (dataFormat == DataFormat.FixedSize)
			{
				return "fixed64";
			}
			return "uint64";
		case ProtoTypeCode.Int64:
			return dataFormat switch
			{
				DataFormat.ZigZag => "sint64", 
				DataFormat.FixedSize => "sfixed64", 
				_ => "int64", 
			};
		case ProtoTypeCode.DateTime:
			switch (dataFormat)
			{
			case DataFormat.FixedSize:
				return "sint64";
			case DataFormat.WellKnown:
				imports |= CommonImports.Timestamp;
				return ".google.protobuf.Timestamp";
			default:
				imports |= CommonImports.Bcl;
				return ".bcl.DateTime";
			}
		case ProtoTypeCode.TimeSpan:
			switch (dataFormat)
			{
			case DataFormat.FixedSize:
				return "sint64";
			case DataFormat.WellKnown:
				imports |= CommonImports.Duration;
				return ".google.protobuf.Duration";
			default:
				imports |= CommonImports.Bcl;
				return ".bcl.TimeSpan";
			}
		case ProtoTypeCode.Decimal:
			imports |= CommonImports.Bcl;
			return ".bcl.Decimal";
		case ProtoTypeCode.Guid:
			imports |= CommonImports.Bcl;
			return ".bcl.Guid";
		case ProtoTypeCode.Type:
			return "string";
		default:
			throw new NotSupportedException("No .proto map found for: " + effectiveType.FullName);
		}
	}

	public void SetDefaultFactory(MethodInfo methodInfo)
	{
		VerifyFactory(methodInfo, null);
		defaultFactory = methodInfo;
	}

	internal void VerifyFactory(MethodInfo factory, Type type)
	{
		if (factory != null)
		{
			if (type != null && Helpers.IsValueType(type))
			{
				throw new InvalidOperationException();
			}
			if (!factory.IsStatic)
			{
				throw new ArgumentException("A factory-method must be static", "factory");
			}
			if (type != null && factory.ReturnType != type && factory.ReturnType != MapType(typeof(object)))
			{
				throw new ArgumentException("The factory-method must return object" + ((type == null) ? "" : (" or " + type.FullName)), "factory");
			}
			if (!CallbackSet.CheckCallbackParameters(this, factory))
			{
				throw new ArgumentException("Invalid factory signature in " + factory.DeclaringType.FullName + "." + factory.Name, "factory");
			}
		}
	}

	internal static void OnBeforeApplyDefaultBehaviour(MetaType metaType, ref TypeAddedEventArgs args)
	{
		OnApplyDefaultBehaviour((metaType?.Model as RuntimeTypeModel)?.BeforeApplyDefaultBehaviour, metaType, ref args);
	}

	internal static void OnAfterApplyDefaultBehaviour(MetaType metaType, ref TypeAddedEventArgs args)
	{
		OnApplyDefaultBehaviour((metaType?.Model as RuntimeTypeModel)?.AfterApplyDefaultBehaviour, metaType, ref args);
	}

	private static void OnApplyDefaultBehaviour(EventHandler<TypeAddedEventArgs> handler, MetaType metaType, ref TypeAddedEventArgs args)
	{
		if (handler != null)
		{
			if (args == null)
			{
				args = new TypeAddedEventArgs(metaType);
			}
			handler(metaType.Model, args);
		}
	}
}
