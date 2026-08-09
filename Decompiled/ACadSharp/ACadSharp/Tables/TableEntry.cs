using System;
using ACadSharp.Attributes;

namespace ACadSharp.Tables;

[DxfSubClass("AcDbSymbolTableRecord", true)]
public abstract class TableEntry : CadObject, INamedCadObject
{
	protected string name = string.Empty;

	[DxfCodeValue(new int[] { 70 })]
	public StandardFlags Flags { get; set; }

	[DxfCodeValue(new int[] { 2 })]
	public virtual string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException("value", "Table entry [" + GetType().FullName + "] must have a name");
			}
			this.OnNameChanged?.Invoke(this, new OnNameChangedArgs(name, value));
			name = value;
		}
	}

	public override string SubclassMarker => "AcDbSymbolTableRecord";

	public event EventHandler<OnNameChangedArgs> OnNameChanged;

	public TableEntry(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name", GetType().Name + " must have a name.");
		}
		Name = name;
	}

	internal TableEntry()
	{
	}

	public override CadObject Clone()
	{
		TableEntry obj = (TableEntry)base.Clone();
		obj.OnNameChanged = null;
		return obj;
	}

	public override string ToString()
	{
		return ObjectName + ":" + Name;
	}
}
