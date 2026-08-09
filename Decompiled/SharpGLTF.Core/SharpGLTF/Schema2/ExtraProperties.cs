using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

public abstract class ExtraProperties : JsonReflectable, IExtraProperties
{
	private readonly struct _ExtensionsReflection(IReadOnlyList<JsonSerializable> extensions) : IReflectionObject
	{
		private readonly IReadOnlyList<JsonSerializable> _Extensions = extensions;

		public bool TryGetField(string name, out FieldInfo value)
		{
			JsonSerializable jsonSerializable = _Extensions.FirstOrDefault((JsonSerializable item) => item._SchemaName == name);
			if (jsonSerializable == null)
			{
				value = default(FieldInfo);
				return false;
			}
			value = FieldInfo.From(jsonSerializable._SchemaName, jsonSerializable, (JsonSerializable ext) => ext);
			return true;
		}

		public IEnumerable<FieldInfo> GetFields()
		{
			foreach (JsonSerializable extension in _Extensions)
			{
				yield return FieldInfo.From(extension._SchemaName, extension, (JsonSerializable ext) => ext);
			}
		}
	}

	private readonly List<JsonSerializable> _extensions = new List<JsonSerializable>();

	private JsonNode _extras;

	public new const string SCHEMANAME = "ExtraProperties";

	public IReadOnlyCollection<JsonSerializable> Extensions => _extensions;

	public JsonNode Extras
	{
		get
		{
			return _extras;
		}
		set
		{
			_extras = value?.DeepClone();
		}
	}

	protected override string GetSchemaName()
	{
		return "ExtraProperties";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "extensions";
		yield return "extras";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "extensions"))
		{
			if (name == "extras")
			{
				value = FieldInfo.From("extras", _extras, (JsonNode inst) => inst);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("extensions", _extensions, (List<JsonSerializable> exts) => new _ExtensionsReflection(exts));
		return true;
	}

	protected IEnumerable<ExtraProperties> GetLogicalChildren()
	{
		foreach (ExtraProperties item in _extensions.OfType<ExtraProperties>())
		{
			yield return item;
		}
		IReflectionObject reflectionObject = this;
		if (reflectionObject == null)
		{
			yield break;
		}
		foreach (FieldInfo field in reflectionObject.GetFields())
		{
			object value = field.Value;
			if (value is IReflectionArray array)
			{
				int i = 0;
				while (i < array.Count)
				{
					if (array.GetField(i).Value is ExtraProperties extraProperties)
					{
						yield return extraProperties;
					}
					int num = i + 1;
					i = num;
				}
			}
			else if (value is ExtraProperties extraProperties2)
			{
				yield return extraProperties2;
			}
		}
	}

	protected static IEnumerable<ExtraProperties> Flatten(ExtraProperties container)
	{
		if (container == null)
		{
			yield break;
		}
		yield return container;
		foreach (ExtraProperties logicalChild in container.GetLogicalChildren())
		{
			IEnumerable<ExtraProperties> enumerable = Flatten(logicalChild);
			foreach (ExtraProperties item in enumerable)
			{
				yield return item;
			}
		}
	}

	protected static void SetProperty<TParent, TProperty, TValue>(TParent parent, ref TProperty property, TValue value) where TParent : ExtraProperties where TProperty : class where TValue : TProperty
	{
		new ChildSetter<TParent>(parent).SetProperty(ref property, value);
	}

	protected static ChildSetter<T> GetChildSetter<T>(T owner) where T : ExtraProperties
	{
		return new ChildSetter<T>(owner);
	}

	public T GetExtension<T>() where T : JsonSerializable
	{
		return _extensions.OfType<T>().FirstOrDefault();
	}

	public T UseExtension<T>() where T : JsonSerializable
	{
		T extension = GetExtension<T>();
		if (extension != null)
		{
			return extension;
		}
		string text = ExtensionsFactory.Identify(GetType(), typeof(T));
		Guard.NotNull(text, "T");
		extension = ExtensionsFactory.Create(this, text) as T;
		Guard.NotNull(extension, "T");
		_extensions.Add(extension);
		return extension;
	}

	public void SetExtension<T>(T value) where T : JsonSerializable
	{
		Guard.NotNull(value, "value");
		int num = _extensions.IndexOf((JsonSerializable item) => item.GetType() == typeof(T));
		if (num >= 0)
		{
			_extensions[num] = value;
		}
		else
		{
			_extensions.Add(value);
		}
	}

	public void RemoveExtensions<T>(T value) where T : JsonSerializable
	{
		_extensions.RemoveAll((JsonSerializable item) => item == value);
	}

	public void RemoveExtensions<T>() where T : JsonSerializable
	{
		_extensions.RemoveAll((JsonSerializable item) => item.GetType() == typeof(T));
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		foreach (ExtraProperties logicalChild in GetLogicalChildren())
		{
			logicalChild.ValidateReferences(validate);
		}
		foreach (JsonSerializable extension in Extensions)
		{
			extension.ValidateReferences(validate);
		}
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		foreach (ExtraProperties logicalChild in GetLogicalChildren())
		{
			logicalChild.ValidateContent(validate);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		if (_extensions.Count > 0)
		{
			Dictionary<string, JsonSerializable> collection = _ToDictionary(this, _extensions);
			JsonSerializable.SerializeProperty(writer, "extensions", collection);
		}
		JsonNode extras = _extras;
		if (extras != null)
		{
			JsonSerializable.SerializeProperty(writer, "extras", extras);
		}
	}

	private static Dictionary<string, JsonSerializable> _ToDictionary(JsonSerializable context, IEnumerable<JsonSerializable> serializables)
	{
		Dictionary<string, JsonSerializable> dictionary = new Dictionary<string, JsonSerializable>();
		foreach (JsonSerializable serializable in serializables)
		{
			if (serializable != null)
			{
				string text = null;
				text = ((!(serializable is UnknownNode unknownNode)) ? ExtensionsFactory.Identify(context.GetType(), serializable.GetType()) : unknownNode.Name);
				if (text != null)
				{
					dictionary[text] = serializable;
				}
			}
		}
		return dictionary;
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		Guard.NotNullOrEmpty(jsonPropertyName, "jsonPropertyName");
		if (!(jsonPropertyName == "extensions"))
		{
			if (jsonPropertyName == "extras")
			{
				JsonNode extras = JsonNode.Parse(ref reader);
				_extras = extras;
			}
			else
			{
				reader.Skip();
			}
		}
		else
		{
			_DeserializeExtensions(this, ref reader, _extensions);
		}
	}

	private static void _DeserializeExtensions(JsonSerializable parent, ref Utf8JsonReader reader, List<JsonSerializable> extensions)
	{
		reader.Read();
		if (reader.TokenType == JsonTokenType.StartObject)
		{
			while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
			{
				string text = reader.GetString();
				JsonSerializable jsonSerializable = ExtensionsFactory.Create(parent, text);
				if (jsonSerializable == null)
				{
					jsonSerializable = new UnknownNode(text);
				}
				jsonSerializable.Deserialize(ref reader);
				extensions.Add(jsonSerializable);
			}
		}
		reader.Skip();
	}
}
