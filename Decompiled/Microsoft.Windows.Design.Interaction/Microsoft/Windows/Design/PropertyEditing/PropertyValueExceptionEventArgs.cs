using System;
using System.Reflection;

namespace Microsoft.Windows.Design.PropertyEditing;

public class PropertyValueExceptionEventArgs : EventArgs
{
	private string _message;

	private PropertyValue _value;

	private PropertyValueExceptionSource _source;

	private Exception _exception;

	public string Message => _message;

	public PropertyValue PropertyValue => _value;

	public PropertyValueExceptionSource Source => _source;

	public Exception Exception => _exception;

	public PropertyValueExceptionEventArgs(string message, PropertyValue value, PropertyValueExceptionSource source, Exception exception)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (!EnumValidator.IsValid(source))
		{
			throw new ArgumentOutOfRangeException("source");
		}
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		if ((object)exception.GetType() == typeof(TargetInvocationException))
		{
			exception = exception.InnerException;
		}
		_message = message;
		_value = value;
		_source = source;
		_exception = exception;
	}
}
