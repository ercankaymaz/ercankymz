using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Microsoft.Windows.Design.Metadata;

[Serializable]
public class AttributeTableValidationException : Exception
{
	private string[] _validationErrors;

	public IEnumerable<string> ValidationErrors => _validationErrors;

	public AttributeTableValidationException()
	{
	}

	public AttributeTableValidationException(string message)
		: base(message)
	{
	}

	public AttributeTableValidationException(string message, Exception inner)
		: base(message, inner)
	{
	}

	public AttributeTableValidationException(string message, IEnumerable<string> validationErrors)
		: base(message)
	{
		_validationErrors = CreateArray(validationErrors);
	}

	public AttributeTableValidationException(string message, Exception inner, IEnumerable<string> validationErrors)
		: base(message, inner)
	{
		_validationErrors = CreateArray(validationErrors);
	}

	protected AttributeTableValidationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		_validationErrors = (string[])info.GetValue("ValidationErrors", typeof(string[]));
	}

	private static string[] CreateArray(IEnumerable<string> validationErrors)
	{
		string[] array;
		if (validationErrors != null)
		{
			int num = 0;
			IEnumerator<string> enumerator = validationErrors.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num++;
			}
			enumerator.Reset();
			array = new string[num];
			num = 0;
			while (enumerator.MoveNext())
			{
				array[num++] = enumerator.Current;
			}
		}
		else
		{
			array = new string[0];
		}
		return array;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		base.GetObjectData(info, context);
		info.AddValue("ValidationErrors", _validationErrors);
	}
}
