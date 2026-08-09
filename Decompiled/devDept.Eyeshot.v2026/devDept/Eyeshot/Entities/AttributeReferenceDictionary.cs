using System;
using System.Runtime.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class AttributeReferenceDictionary : EyeshotDisposableDictionary<AttributeReference>
{
	internal bool needSynchronization;

	public override AttributeReference this[string name]
	{
		get
		{
			return base[name];
		}
		set
		{
			base[name] = value;
			needSynchronization = true;
		}
	}

	internal AttributeReferenceDictionary()
		: base((Document)null, StringComparer.CurrentCulture)
	{
	}

	protected AttributeReferenceDictionary(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public void Add(string tag, string value)
	{
		Add(tag, new AttributeReference(value)
		{
			needsSynchronization = true
		});
		needSynchronization = true;
	}
}
