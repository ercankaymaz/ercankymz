using System.Diagnostics.Tracing;
using System.Runtime;
using System.Xml;

namespace System.ServiceModel.Diagnostics;

internal class ExceptionUtility
{
	private const string ExceptionStackAsStringKey = "System.ServiceModel.Diagnostics.ExceptionUtility.ExceptionStackAsString";

	internal static ExceptionUtility mainInstance;

	[ThreadStatic]
	private static Guid s_activityId;

	public ArgumentException ThrowHelperArgument(string message)
	{
		return (ArgumentException)ThrowHelperError(new ArgumentException(message));
	}

	public ArgumentException ThrowHelperArgument(string paramName, string message)
	{
		return (ArgumentException)ThrowHelperError(new ArgumentException(message, paramName));
	}

	public ArgumentNullException ThrowHelperArgumentNull(string paramName, string message)
	{
		return (ArgumentNullException)ThrowHelperError(new ArgumentNullException(paramName, message));
	}

	public ArgumentException ThrowHelperArgumentNullOrEmptyString(string arg)
	{
		return (ArgumentException)ThrowHelperError(new ArgumentException(System.SR.StringNullOrEmpty, arg));
	}

	public Exception ThrowHelperFatal(string message, Exception innerException)
	{
		return ThrowHelperError(new FatalException(message, innerException));
	}

	public Exception ThrowHelperInternal(bool fatal)
	{
		if (!fatal)
		{
			return Fx.AssertAndThrow("InternalException should never be thrown.");
		}
		return Fx.AssertAndThrowFatal("Fatal InternalException should never be thrown.");
	}

	public Exception ThrowHelperInvalidOperation(string message)
	{
		return ThrowHelperError(new InvalidOperationException(message));
	}

	public Exception ThrowHelperCallback(string message, Exception innerException)
	{
		return ThrowHelperCritical(new CallbackException(message, innerException));
	}

	public Exception ThrowHelperCallback(Exception innerException)
	{
		return ThrowHelperCallback(System.SR.GenericCallbackException, innerException);
	}

	public Exception ThrowHelperCritical(Exception exception)
	{
		return ThrowHelper(exception, EventLevel.Critical);
	}

	public Exception ThrowHelperWarning(Exception exception)
	{
		return ThrowHelper(exception, EventLevel.Warning);
	}

	internal Exception ThrowHelperXml(XmlReader reader, string message)
	{
		return ThrowHelperXml(reader, message, null);
	}

	internal Exception ThrowHelperXml(XmlReader reader, string message, Exception inner)
	{
		IXmlLineInfo xmlLineInfo = reader as IXmlLineInfo;
		return ThrowHelperError(new XmlException(message, inner, xmlLineInfo?.LineNumber ?? 0, xmlLineInfo?.LinePosition ?? 0));
	}

	internal static void UseActivityId(Guid activityId)
	{
		s_activityId = activityId;
	}

	internal static void ClearActivityId()
	{
		s_activityId = Guid.Empty;
	}

	public Exception ThrowHelperError(Exception exception)
	{
		return ThrowHelper(exception, EventLevel.Error);
	}

	internal Exception ThrowHelperError(Exception exception, Guid activityId, object source)
	{
		return exception;
	}

	internal Exception ThrowHelper(Exception exception, EventLevel eventLevel)
	{
		FxTrace.Exception.TraceEtwException(exception, eventLevel);
		return exception;
	}

	internal ArgumentNullException ThrowHelperArgumentNull(string paramName)
	{
		return (ArgumentNullException)ThrowHelperError(new ArgumentNullException(paramName));
	}
}
