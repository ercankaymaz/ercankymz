using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel;

[Serializable]
[KnownType(typeof(FaultCodeData))]
[KnownType(typeof(FaultCodeData[]))]
[KnownType(typeof(FaultReasonData))]
[KnownType(typeof(FaultReasonData[]))]
public class FaultException : CommunicationException
{
	[Serializable]
	internal class FaultCodeData
	{
		private string name;

		private string ns;

		internal static FaultCode Construct(FaultCodeData[] nodes)
		{
			FaultCode faultCode = null;
			for (int num = nodes.Length - 1; num >= 0; num--)
			{
				faultCode = new FaultCode(nodes[num].name, nodes[num].ns, faultCode);
			}
			return faultCode;
		}

		internal static FaultCodeData[] GetObjectData(FaultCode code)
		{
			FaultCodeData[] array = new FaultCodeData[GetDepth(code)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new FaultCodeData();
				array[i].name = code.Name;
				array[i].ns = code.Namespace;
				code = code.SubCode;
			}
			return array;
		}

		private static int GetDepth(FaultCode code)
		{
			int num = 0;
			while (code != null)
			{
				num++;
				code = code.SubCode;
			}
			return num;
		}
	}

	[Serializable]
	internal class FaultReasonData
	{
		private string xmlLang;

		private string text;

		internal static FaultReason Construct(FaultReasonData[] nodes)
		{
			FaultReasonText[] array = new FaultReasonText[nodes.Length];
			for (int i = 0; i < nodes.Length; i++)
			{
				array[i] = new FaultReasonText(nodes[i].text, nodes[i].xmlLang);
			}
			return new FaultReason(array);
		}

		internal static FaultReasonData[] GetObjectData(FaultReason reason)
		{
			SynchronizedReadOnlyCollection<FaultReasonText> translations = reason.Translations;
			FaultReasonData[] array = new FaultReasonData[translations.Count];
			for (int i = 0; i < translations.Count; i++)
			{
				array[i] = new FaultReasonData();
				array[i].xmlLang = translations[i].XmlLang;
				array[i].text = translations[i].Text;
			}
			return array;
		}
	}

	internal const string Namespace = "http://schemas.xmlsoap.org/Microsoft/WindowsCommunicationFoundation/2005/08/Faults/";

	public string Action { get; }

	public FaultCode Code { get; }

	private static FaultReason DefaultReason => new FaultReason(System.SR.SFxFaultReason);

	private static FaultCode DefaultCode => new FaultCode("Sender");

	public override string Message => GetSafeReasonText(Reason);

	public FaultReason Reason { get; }

	internal MessageFault Fault { get; }

	public FaultException()
		: base(System.SR.SFxFaultReason)
	{
		Code = DefaultCode;
		Reason = DefaultReason;
	}

	public FaultException(string reason)
		: base(reason)
	{
		Code = DefaultCode;
		Reason = CreateReason(reason);
	}

	public FaultException(FaultReason reason)
		: base(GetSafeReasonText(reason))
	{
		Code = DefaultCode;
		Reason = EnsureReason(reason);
	}

	public FaultException(string reason, FaultCode code)
		: base(reason)
	{
		Code = EnsureCode(code);
		Reason = CreateReason(reason);
	}

	public FaultException(FaultReason reason, FaultCode code)
		: base(GetSafeReasonText(reason))
	{
		Code = EnsureCode(code);
		Reason = EnsureReason(reason);
	}

	public FaultException(string reason, FaultCode code, string action)
		: base(reason)
	{
		Code = EnsureCode(code);
		Reason = CreateReason(reason);
		Action = action;
	}

	internal FaultException(string reason, FaultCode code, string action, Exception innerException)
		: base(reason, innerException)
	{
		Code = EnsureCode(code);
		Reason = CreateReason(reason);
		Action = action;
	}

	public FaultException(FaultReason reason, FaultCode code, string action)
		: base(GetSafeReasonText(reason))
	{
		Code = EnsureCode(code);
		Reason = EnsureReason(reason);
		Action = action;
	}

	internal FaultException(FaultReason reason, FaultCode code, string action, Exception innerException)
		: base(GetSafeReasonText(reason), innerException)
	{
		Code = EnsureCode(code);
		Reason = EnsureReason(reason);
		Action = action;
	}

	public FaultException(MessageFault fault)
		: base(GetSafeReasonText(GetReason(fault)))
	{
		if (fault == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("fault");
		}
		Code = EnsureCode(fault.Code);
		Reason = EnsureReason(fault.Reason);
		Fault = fault;
	}

	public FaultException(MessageFault fault, string action)
		: base(GetSafeReasonText(GetReason(fault)))
	{
		if (fault == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("fault");
		}
		Code = fault.Code;
		Reason = fault.Reason;
		Fault = fault;
		Action = action;
	}

	protected FaultException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Code = ReconstructFaultCode(info, "code");
		Reason = ReconstructFaultReason(info, "reason");
		Fault = (MessageFault)info.GetValue("messageFault", typeof(MessageFault));
		Action = info.GetString("action");
	}

	internal void AddFaultCodeObjectData(SerializationInfo info, string key, FaultCode code)
	{
		info.AddValue(key, FaultCodeData.GetObjectData(code));
	}

	internal void AddFaultReasonObjectData(SerializationInfo info, string key, FaultReason reason)
	{
		info.AddValue(key, FaultReasonData.GetObjectData(reason));
	}

	public static FaultException CreateFault(MessageFault messageFault, params Type[] faultDetailTypes)
	{
		return CreateFault(messageFault, null, faultDetailTypes);
	}

	public static FaultException CreateFault(MessageFault messageFault, string action, params Type[] faultDetailTypes)
	{
		if (messageFault == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageFault");
		}
		if (faultDetailTypes == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("faultDetailTypes");
		}
		DataContractSerializerFaultFormatter dataContractSerializerFaultFormatter = new DataContractSerializerFaultFormatter(faultDetailTypes);
		return dataContractSerializerFaultFormatter.Deserialize(messageFault, action);
	}

	public virtual MessageFault CreateMessageFault()
	{
		if (Fault != null)
		{
			return Fault;
		}
		return MessageFault.CreateFault(Code, Reason);
	}

	private static FaultReason CreateReason(string reason)
	{
		if (reason == null)
		{
			return DefaultReason;
		}
		return new FaultReason(reason);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		AddFaultCodeObjectData(info, "code", Code);
		AddFaultReasonObjectData(info, "reason", Reason);
		info.AddValue("messageFault", Fault);
		info.AddValue("action", Action);
	}

	private static FaultReason GetReason(MessageFault fault)
	{
		if (fault == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("fault");
		}
		return fault.Reason;
	}

	internal static string GetSafeReasonText(MessageFault messageFault)
	{
		if (messageFault == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageFault");
		}
		return GetSafeReasonText(messageFault.Reason);
	}

	internal static string GetSafeReasonText(FaultReason reason)
	{
		if (reason == null)
		{
			return System.SR.SFxUnknownFaultNullReason0;
		}
		try
		{
			return reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text;
		}
		catch (ArgumentException)
		{
			if (reason.Translations.Count == 0)
			{
				return System.SR.SFxUnknownFaultZeroReasons0;
			}
			return System.SR.Format(System.SR.SFxUnknownFaultNoMatchingTranslation1, reason.Translations[0].Text);
		}
	}

	private static FaultCode EnsureCode(FaultCode code)
	{
		if (code == null)
		{
			return DefaultCode;
		}
		return code;
	}

	private static FaultReason EnsureReason(FaultReason reason)
	{
		if (reason == null)
		{
			return DefaultReason;
		}
		return reason;
	}

	internal FaultCode ReconstructFaultCode(SerializationInfo info, string key)
	{
		FaultCodeData[] nodes = (FaultCodeData[])info.GetValue(key, typeof(FaultCodeData[]));
		return FaultCodeData.Construct(nodes);
	}

	internal FaultReason ReconstructFaultReason(SerializationInfo info, string key)
	{
		FaultReasonData[] nodes = (FaultReasonData[])info.GetValue(key, typeof(FaultReasonData[]));
		return FaultReasonData.Construct(nodes);
	}
}
[Serializable]
[KnownType("GetKnownTypes")]
public class FaultException<TDetail> : FaultException
{
	private static Type[] s_knownTypes = new Type[1] { typeof(TDetail) };

	public TDetail Detail { get; }

	public FaultException(TDetail detail)
	{
		Detail = detail;
	}

	public FaultException(TDetail detail, string reason)
		: base(reason)
	{
		Detail = detail;
	}

	public FaultException(TDetail detail, FaultReason reason)
		: base(reason)
	{
		Detail = detail;
	}

	public FaultException(TDetail detail, string reason, FaultCode code)
		: base(reason, code)
	{
		Detail = detail;
	}

	public FaultException(TDetail detail, FaultReason reason, FaultCode code)
		: base(reason, code)
	{
		Detail = detail;
	}

	public FaultException(TDetail detail, string reason, FaultCode code, string action)
		: base(reason, code, action)
	{
		Detail = detail;
	}

	public FaultException(TDetail detail, FaultReason reason, FaultCode code, string action)
		: base(reason, code, action)
	{
		Detail = detail;
	}

	protected FaultException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Detail = (TDetail)info.GetValue("detail", typeof(TDetail));
	}

	public override MessageFault CreateMessageFault()
	{
		return MessageFault.CreateFault(base.Code, base.Reason, Detail);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("detail", Detail);
	}

	public override string ToString()
	{
		return System.SR.Format(System.SR.SFxFaultExceptionToString3, GetType(), Message, (Detail != null) ? Detail.ToString() : string.Empty);
	}

	internal static IEnumerable<Type> GetKnownTypes()
	{
		return s_knownTypes;
	}
}
