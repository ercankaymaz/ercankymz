using System;
using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfSubClass(null, true)]
public abstract class NonGraphicalObject : CadObject, INamedCadObject
{
	private string _name = string.Empty;

	public virtual string Name
	{
		get
		{
			return _name;
		}
		set
		{
			this.OnNameChanged?.Invoke(this, new OnNameChangedArgs(_name, value));
			_name = value;
		}
	}

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public event EventHandler<OnNameChangedArgs> OnNameChanged;

	public NonGraphicalObject()
	{
	}

	public NonGraphicalObject(string name)
	{
		Name = name;
	}

	public override CadObject Clone()
	{
		NonGraphicalObject obj = (NonGraphicalObject)base.Clone();
		obj.OnNameChanged = null;
		return obj;
	}

	public override string ToString()
	{
		if (string.IsNullOrEmpty(Name))
		{
			return $"{ObjectName}:{base.Handle}";
		}
		return $"{ObjectName}:{Name}:{base.Handle}";
	}
}
