using System.ComponentModel;

namespace System.ServiceModel.Description;

public class MessageBodyDescription
{
	private XmlName _wrapperName;

	private MessagePartDescription _returnValue;

	public MessagePartDescriptionCollection Parts { get; }

	[DefaultValue(null)]
	public MessagePartDescription ReturnValue
	{
		get
		{
			return _returnValue;
		}
		set
		{
			_returnValue = value;
		}
	}

	[DefaultValue(null)]
	public string WrapperName
	{
		get
		{
			if (!(_wrapperName == null))
			{
				return _wrapperName.EncodedName;
			}
			return null;
		}
		set
		{
			_wrapperName = new XmlName(value, isEncoded: true);
		}
	}

	[DefaultValue(null)]
	public string WrapperNamespace { get; set; }

	public MessageBodyDescription()
	{
		Parts = new MessagePartDescriptionCollection();
	}

	internal MessageBodyDescription(MessageBodyDescription other)
	{
		WrapperName = other.WrapperName;
		WrapperNamespace = other.WrapperNamespace;
		Parts = new MessagePartDescriptionCollection();
		foreach (MessagePartDescription part in other.Parts)
		{
			Parts.Add(part.Clone());
		}
		if (other.ReturnValue != null)
		{
			ReturnValue = other.ReturnValue.Clone();
		}
	}

	internal MessageBodyDescription Clone()
	{
		return new MessageBodyDescription(this);
	}
}
