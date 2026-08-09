namespace System.ServiceModel.Description;

internal class MessageDescriptionItems
{
	private MessageHeaderDescriptionCollection _headers;

	private MessageBodyDescription _body;

	private MessagePropertyDescriptionCollection _properties;

	internal MessageBodyDescription Body
	{
		get
		{
			if (_body == null)
			{
				_body = new MessageBodyDescription();
			}
			return _body;
		}
		set
		{
			_body = value;
		}
	}

	internal MessageHeaderDescriptionCollection Headers
	{
		get
		{
			if (_headers == null)
			{
				_headers = new MessageHeaderDescriptionCollection();
			}
			return _headers;
		}
	}

	internal MessagePropertyDescriptionCollection Properties
	{
		get
		{
			if (_properties == null)
			{
				_properties = new MessagePropertyDescriptionCollection();
			}
			return _properties;
		}
	}
}
