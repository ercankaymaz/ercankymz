using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace System.ServiceModel;

[DataContract]
public class ExceptionDetail
{
	private string _type;

	[DataMember]
	public string HelpLink { get; set; }

	[DataMember]
	public ExceptionDetail InnerException { get; set; }

	[DataMember]
	public string Message { get; set; }

	[DataMember]
	public string StackTrace { get; set; }

	[DataMember]
	public string Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	public ExceptionDetail(Exception exception)
	{
		if (exception == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("exception");
		}
		HelpLink = exception.HelpLink;
		Message = exception.Message;
		StackTrace = exception.StackTrace;
		_type = exception.GetType().ToString();
		if (exception.InnerException != null)
		{
			InnerException = new ExceptionDetail(exception.InnerException);
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}\n{1}", System.SR.SFxExceptionDetailFormat, ToStringHelper(isInner: false));
	}

	private string ToStringHelper(bool isInner)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}: {1}", Type, Message);
		if (InnerException != null)
		{
			stringBuilder.AppendFormat(" ----> {0}", InnerException.ToStringHelper(isInner: true));
		}
		else
		{
			stringBuilder.Append("\n");
		}
		stringBuilder.Append(StackTrace);
		if (isInner)
		{
			stringBuilder.AppendFormat("\n   {0}\n", System.SR.SFxExceptionDetailEndOfInner);
		}
		return stringBuilder.ToString();
	}
}
