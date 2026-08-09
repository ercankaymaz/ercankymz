using System.ComponentModel;
using System.Diagnostics;
using System.Net.Security;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Xml;

namespace System.ServiceModel.Description;

[DebuggerDisplay("Action={Action}, Direction={Direction}, MessageType={MessageType}")]
public class MessageDescription
{
	private static Type s_typeOfUntypedMessage;

	private MessageDescriptionItems _items;

	private ProtectionLevel _protectionLevel;

	public string Action { get; internal set; }

	public MessageBodyDescription Body => Items.Body;

	public MessageDirection Direction { get; }

	public MessageHeaderDescriptionCollection Headers => Items.Headers;

	public MessagePropertyDescriptionCollection Properties => Items.Properties;

	internal MessageDescriptionItems Items
	{
		get
		{
			if (_items == null)
			{
				_items = new MessageDescriptionItems();
			}
			return _items;
		}
	}

	public ProtectionLevel ProtectionLevel
	{
		get
		{
			return _protectionLevel;
		}
		set
		{
			if (!ProtectionLevelHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_protectionLevel = value;
			HasProtectionLevel = true;
		}
	}

	public bool HasProtectionLevel { get; private set; }

	internal static Type TypeOfUntypedMessage
	{
		get
		{
			if (s_typeOfUntypedMessage == null)
			{
				s_typeOfUntypedMessage = typeof(Message);
			}
			return s_typeOfUntypedMessage;
		}
	}

	internal XmlName MessageName { get; set; }

	[DefaultValue(null)]
	public Type MessageType { get; set; }

	internal bool IsTypedMessage => MessageType != null;

	internal bool IsUntypedMessage
	{
		get
		{
			if (Body.ReturnValue == null || Body.Parts.Count != 0 || !(Body.ReturnValue.Type == TypeOfUntypedMessage))
			{
				if (Body.ReturnValue == null && Body.Parts.Count == 1)
				{
					return Body.Parts[0].Type == TypeOfUntypedMessage;
				}
				return false;
			}
			return true;
		}
	}

	internal bool IsVoid
	{
		get
		{
			if (!IsTypedMessage && Body.Parts.Count == 0)
			{
				if (Body.ReturnValue != null)
				{
					return Body.ReturnValue.Type == typeof(void);
				}
				return true;
			}
			return false;
		}
	}

	internal XmlQualifiedName XsdTypeName { get; set; }

	public MessageDescription(string action, MessageDirection direction)
		: this(action, direction, null)
	{
	}

	internal MessageDescription(string action, MessageDirection direction, MessageDescriptionItems items)
	{
		if (!MessageDirectionHelper.IsDefined(direction))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("direction"));
		}
		Action = action;
		Direction = direction;
		_items = items;
	}

	internal MessageDescription(MessageDescription other)
	{
		Action = other.Action;
		Direction = other.Direction;
		Items.Body = other.Items.Body.Clone();
		foreach (MessageHeaderDescription header in other.Items.Headers)
		{
			Items.Headers.Add(header.Clone() as MessageHeaderDescription);
		}
		foreach (MessagePropertyDescription property in other.Items.Properties)
		{
			Items.Properties.Add(property.Clone() as MessagePropertyDescription);
		}
		MessageName = other.MessageName;
		MessageType = other.MessageType;
		XsdTypeName = other.XsdTypeName;
		HasProtectionLevel = other.HasProtectionLevel;
		ProtectionLevel = other.ProtectionLevel;
	}

	internal MessageDescription Clone()
	{
		return new MessageDescription(this);
	}

	public bool ShouldSerializeProtectionLevel()
	{
		return HasProtectionLevel;
	}

	internal void ResetProtectionLevel()
	{
		_protectionLevel = ProtectionLevel.None;
		HasProtectionLevel = false;
	}
}
