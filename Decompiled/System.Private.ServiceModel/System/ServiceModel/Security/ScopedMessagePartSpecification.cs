using System.Collections.Generic;
using System.Xml;

namespace System.ServiceModel.Security;

public class ScopedMessagePartSpecification
{
	private Dictionary<string, MessagePartSpecification> _actionParts;

	private Dictionary<string, MessagePartSpecification> _readOnlyNormalizedActionParts;

	public ICollection<string> Actions => _actionParts.Keys;

	public MessagePartSpecification ChannelParts { get; }

	public bool IsReadOnly { get; private set; }

	public ScopedMessagePartSpecification()
	{
		ChannelParts = new MessagePartSpecification();
		_actionParts = new Dictionary<string, MessagePartSpecification>();
	}

	public ScopedMessagePartSpecification(ScopedMessagePartSpecification other)
		: this()
	{
		if (other == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("other"));
		}
		ChannelParts.Union(other.ChannelParts);
		if (other._actionParts == null)
		{
			return;
		}
		foreach (string key in other._actionParts.Keys)
		{
			MessagePartSpecification messagePartSpecification = new MessagePartSpecification();
			messagePartSpecification.Union(other._actionParts[key]);
			_actionParts[key] = messagePartSpecification;
		}
	}

	internal ScopedMessagePartSpecification(ScopedMessagePartSpecification other, bool newIncludeBody)
		: this(other)
	{
		ChannelParts.IsBodyIncluded = newIncludeBody;
		foreach (string key in _actionParts.Keys)
		{
			_actionParts[key].IsBodyIncluded = newIncludeBody;
		}
	}

	public void AddParts(MessagePartSpecification parts)
	{
		if (parts == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("parts"));
		}
		ThrowIfReadOnly();
		ChannelParts.Union(parts);
	}

	public void AddParts(MessagePartSpecification parts, string action)
	{
		if (action == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("action"));
		}
		if (parts == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("parts"));
		}
		ThrowIfReadOnly();
		if (!_actionParts.ContainsKey(action))
		{
			_actionParts[action] = new MessagePartSpecification();
		}
		_actionParts[action].Union(parts);
	}

	internal void AddParts(MessagePartSpecification parts, XmlDictionaryString action)
	{
		if (action == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("action"));
		}
		AddParts(parts, action.Value);
	}

	internal bool IsEmpty()
	{
		bool result;
		if (!ChannelParts.IsEmpty())
		{
			result = false;
		}
		else
		{
			result = true;
			foreach (string action in Actions)
			{
				if (TryGetParts(action, excludeChannelScope: true, out var parts) && !parts.IsEmpty())
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	public bool TryGetParts(string action, bool excludeChannelScope, out MessagePartSpecification parts)
	{
		if (action == null)
		{
			action = "*";
		}
		parts = null;
		if (IsReadOnly)
		{
			if (_readOnlyNormalizedActionParts.ContainsKey(action))
			{
				if (excludeChannelScope)
				{
					parts = _actionParts[action];
				}
				else
				{
					parts = _readOnlyNormalizedActionParts[action];
				}
			}
		}
		else if (_actionParts.ContainsKey(action))
		{
			MessagePartSpecification messagePartSpecification = new MessagePartSpecification();
			messagePartSpecification.Union(_actionParts[action]);
			if (!excludeChannelScope)
			{
				messagePartSpecification.Union(ChannelParts);
			}
			parts = messagePartSpecification;
		}
		return parts != null;
	}

	internal void CopyTo(ScopedMessagePartSpecification target)
	{
		if (target == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("target");
		}
		target.ChannelParts.IsBodyIncluded = ChannelParts.IsBodyIncluded;
		foreach (XmlQualifiedName headerType in ChannelParts.HeaderTypes)
		{
			if (!target.ChannelParts.IsHeaderIncluded(headerType.Name, headerType.Namespace))
			{
				target.ChannelParts.HeaderTypes.Add(headerType);
			}
		}
		foreach (string key in _actionParts.Keys)
		{
			target.AddParts(_actionParts[key], key);
		}
	}

	public bool TryGetParts(string action, out MessagePartSpecification parts)
	{
		return TryGetParts(action, excludeChannelScope: false, out parts);
	}

	public void MakeReadOnly()
	{
		if (IsReadOnly)
		{
			return;
		}
		_readOnlyNormalizedActionParts = new Dictionary<string, MessagePartSpecification>();
		foreach (string key in _actionParts.Keys)
		{
			MessagePartSpecification messagePartSpecification = new MessagePartSpecification();
			messagePartSpecification.Union(_actionParts[key]);
			messagePartSpecification.Union(ChannelParts);
			messagePartSpecification.MakeReadOnly();
			_readOnlyNormalizedActionParts[key] = messagePartSpecification;
		}
		IsReadOnly = true;
	}

	private void ThrowIfReadOnly()
	{
		if (IsReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
		}
	}
}
