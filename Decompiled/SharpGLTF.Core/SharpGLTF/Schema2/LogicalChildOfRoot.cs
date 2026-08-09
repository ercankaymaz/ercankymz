using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
public abstract class LogicalChildOfRoot : ExtraProperties, IChildOfList<ModelRoot>
{
	public new const string SCHEMANAME = "glTFChildOfRootProperty";

	private string _name;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public ModelRoot LogicalParent { get; private set; }

	public int LogicalIndex { get; private set; } = -1;

	protected override string GetSchemaName()
	{
		return "glTFChildOfRootProperty";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "name";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "name")
		{
			value = FieldInfo.From("name", this, (LogicalChildOfRoot instance) => instance._name);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "name", _name);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "name")
		{
			JsonSerializable.DeserializePropertyValue<LogicalChildOfRoot, string>(ref reader, this, out _name);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	void IChildOfList<ModelRoot>.SetLogicalParent(ModelRoot parent, int index)
	{
		LogicalParent = parent;
		LogicalIndex = index;
	}

	protected bool SharesLogicalParent(params LogicalChildOfRoot[] items)
	{
		return items.All((LogicalChildOfRoot item) => LogicalParent == item.LogicalParent);
	}

	public static void RenameLogicalElements<T>(IEnumerable<T> collection, string namePrefix) where T : LogicalChildOfRoot
	{
		if (collection == null)
		{
			return;
		}
		HashSet<string> usedNames = new HashSet<string>();
		int num = -1;
		foreach (T item in collection)
		{
			num++;
			if (!string.IsNullOrWhiteSpace(item.Name) && item.RenameIfAvailable(item.Name, usedNames))
			{
				continue;
			}
			string newName = $"{namePrefix}{num}";
			if (item.RenameIfAvailable(newName, usedNames))
			{
				continue;
			}
			for (int i = 0; i < int.MaxValue; i++)
			{
				newName = $"{namePrefix}{num}-{i}";
				if (item.RenameIfAvailable(newName, usedNames))
				{
					break;
				}
			}
		}
	}

	private bool RenameIfAvailable(string newName, HashSet<string> usedNames)
	{
		if (usedNames.Contains(newName))
		{
			return false;
		}
		Name = newName;
		usedNames.Add(newName);
		return true;
	}
}
