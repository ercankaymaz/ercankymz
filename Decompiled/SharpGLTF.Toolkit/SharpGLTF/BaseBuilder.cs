using System;
using System.Text.Json.Nodes;
using SharpGLTF.Schema2;

namespace SharpGLTF;

public abstract class BaseBuilder
{
	public string Name { get; set; }

	public JsonNode Extras { get; set; }

	protected BaseBuilder()
	{
	}

	protected BaseBuilder(string name)
	{
		Name = name;
	}

	protected BaseBuilder(string name, JsonNode extras)
	{
		Name = name;
		Extras = extras;
	}

	protected BaseBuilder(BaseBuilder other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		Name = other.Name;
		Extras = other.Extras?.DeepClone();
	}

	protected static int GetContentHashCode(BaseBuilder x)
	{
		int? obj;
		if (x == null)
		{
			obj = null;
		}
		else
		{
			string name = x.Name;
			obj = ((name != null) ? new int?(SharpGLTF._Extensions.GetHashCode(name, StringComparison.InvariantCulture)) : ((int?)null));
		}
		int? num = obj;
		return num.GetValueOrDefault();
	}

	protected static bool AreEqualByContent(BaseBuilder x, BaseBuilder y)
	{
		if ((x: x, y: y).AreSameReference(out var result))
		{
			return result;
		}
		if (x.Name != y.Name)
		{
			return false;
		}
		if (x.Extras == null && y.Extras == null)
		{
			return true;
		}
		if (x.Extras == null)
		{
			return false;
		}
		if (y.Extras == null)
		{
			return false;
		}
		return x.Extras.DeepEquals(y.Extras, 9.999999747378752E-05);
	}

	internal void SetNameAndExtrasFrom(BaseBuilder source)
	{
		Name = source?.Name;
		Extras = source?.Extras?.DeepClone();
	}

	internal void SetNameAndExtrasFrom(LogicalChildOfRoot source)
	{
		Name = source?.Name;
		Extras = source?.Extras?.DeepClone();
	}

	internal void TryCopyNameAndExtrasTo(LogicalChildOfRoot target)
	{
		target.Name = Name;
		target.Extras = Extras?.DeepClone();
	}
}
