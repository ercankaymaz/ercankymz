using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Globalization;

namespace System.ComponentModel;

internal static class ExceptionBuilder
{
	public static Exception CreateDiscoveryException(string messageFormat, params string[] arguments)
	{
		return new InvalidOperationException(Format(messageFormat, arguments));
	}

	public static ArgumentException CreateContainsNullElement(string parameterName)
	{
		ArgumentNullException.ThrowIfNull(parameterName, "parameterName");
		string message = Format(System.SR.Argument_NullElement, parameterName);
		return new ArgumentException(message, parameterName);
	}

	public static ObjectDisposedException CreateObjectDisposed(object instance)
	{
		ArgumentNullException.ThrowIfNull(instance, "instance");
		return new ObjectDisposedException(instance.GetType().ToString());
	}

	public static NotImplementedException CreateNotOverriddenByDerived(string memberName)
	{
		ArgumentNullException.ThrowIfNull(memberName, "memberName");
		if (memberName.Length == 0)
		{
			throw new ArgumentException(System.SR.Format(System.SR.ArgumentException_EmptyString, "memberName"), "memberName");
		}
		string message = Format(System.SR.NotImplemented_NotOverriddenByDerived, memberName);
		return new NotImplementedException(message);
	}

	public static ArgumentException CreateExportDefinitionNotOnThisComposablePart(string parameterName)
	{
		ArgumentNullException.ThrowIfNull(parameterName, "parameterName");
		if (parameterName.Length == 0)
		{
			throw new ArgumentException(System.SR.ArgumentException_EmptyString);
		}
		string message = Format(System.SR.ExportDefinitionNotOnThisComposablePart, parameterName);
		return new ArgumentException(message, parameterName);
	}

	public static ArgumentException CreateImportDefinitionNotOnThisComposablePart(string parameterName)
	{
		ArgumentNullException.ThrowIfNull(parameterName, "parameterName");
		if (parameterName.Length == 0)
		{
			throw new ArgumentException(System.SR.Format(System.SR.ArgumentException_EmptyString, "parameterName"), "parameterName");
		}
		string message = Format(System.SR.ImportDefinitionNotOnThisComposablePart, parameterName);
		return new ArgumentException(message, parameterName);
	}

	public static CompositionException CreateCannotGetExportedValue(ComposablePart part, ExportDefinition definition, Exception innerException)
	{
		ArgumentNullException.ThrowIfNull(part, "part");
		ArgumentNullException.ThrowIfNull(definition, "definition");
		ArgumentNullException.ThrowIfNull(innerException, "innerException");
		return new CompositionException(ErrorBuilder.CreateCannotGetExportedValue(part, definition, innerException));
	}

	public static ArgumentException CreateReflectionModelInvalidPartDefinition(string parameterName, Type partDefinitionType)
	{
		ArgumentNullException.ThrowIfNull(parameterName, "parameterName");
		if (parameterName.Length == 0)
		{
			throw new ArgumentException(System.SR.Format(System.SR.ArgumentException_EmptyString, "parameterName"), "parameterName");
		}
		if (partDefinitionType == null)
		{
			throw new ArgumentNullException("partDefinitionType");
		}
		return new ArgumentException(System.SR.Format(System.SR.ReflectionModel_InvalidPartDefinition, partDefinitionType), parameterName);
	}

	public static ArgumentException ExportFactory_TooManyGenericParameters(string typeName)
	{
		ArgumentNullException.ThrowIfNull(typeName, "typeName");
		if (typeName.Length == 0)
		{
			throw new ArgumentException(System.SR.Format(System.SR.ArgumentException_EmptyString, "typeName"), "typeName");
		}
		string message = Format(System.SR.ExportFactory_TooManyGenericParameters, typeName);
		return new ArgumentException(message, typeName);
	}

	private static string Format(string format, params string[] arguments)
	{
		return string.Format(CultureInfo.CurrentCulture, format, arguments);
	}
}
