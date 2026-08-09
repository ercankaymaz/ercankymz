using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

public class FaultFormatter : IClientFaultFormatter, IDispatchFaultFormatter
{
	public class OperationFault<T> : XmlObjectSerializerFault
	{
		public OperationFault(XmlObjectSerializer serializer, FaultException<T> faultException)
			: base(faultException.Code, faultException.Reason, faultException.Detail, serializer, string.Empty, string.Empty)
		{
		}
	}

	private FaultContractInfo[] _faultContractInfos;

	internal FaultFormatter(Type[] detailTypes)
	{
		List<FaultContractInfo> list = new List<FaultContractInfo>();
		for (int i = 0; i < detailTypes.Length; i++)
		{
			list.Add(new FaultContractInfo("*", detailTypes[i]));
		}
		AddInfrastructureFaults(list);
		_faultContractInfos = GetSortedArray(list);
	}

	internal FaultFormatter(SynchronizedCollection<FaultContractInfo> faultContractInfoCollection)
	{
		List<FaultContractInfo> list;
		lock (faultContractInfoCollection.SyncRoot)
		{
			list = new List<FaultContractInfo>(faultContractInfoCollection);
		}
		AddInfrastructureFaults(list);
		_faultContractInfos = GetSortedArray(list);
	}

	public MessageFault Serialize(FaultException faultException, out string action)
	{
		XmlObjectSerializer serializer = null;
		Type detailType = null;
		string faultExceptionAction = (action = faultException.Action);
		Type type = null;
		Type type2 = faultException.GetType();
		while (type2 != typeof(FaultException))
		{
			if (type2.IsGenericType() && type2.GetGenericTypeDefinition() == typeof(FaultException<>))
			{
				type = type2;
				break;
			}
			type2 = type2.BaseType();
		}
		if (type != null)
		{
			detailType = type.GetGenericArguments()[0];
			serializer = GetSerializer(detailType, faultExceptionAction, out action);
		}
		return CreateMessageFault(serializer, faultException, detailType);
	}

	public FaultException Deserialize(MessageFault messageFault, string action)
	{
		if (!messageFault.HasDetail)
		{
			return new FaultException(messageFault, action);
		}
		return CreateFaultException(messageFault, action);
	}

	protected virtual XmlObjectSerializer GetSerializer(Type detailType, string faultExceptionAction, out string action)
	{
		action = faultExceptionAction;
		FaultContractInfo faultContractInfo = null;
		for (int i = 0; i < _faultContractInfos.Length; i++)
		{
			if (_faultContractInfos[i].Detail == detailType)
			{
				faultContractInfo = _faultContractInfos[i];
				break;
			}
		}
		if (faultContractInfo != null)
		{
			if (action == null)
			{
				action = faultContractInfo.Action;
			}
			return faultContractInfo.Serializer;
		}
		return DataContractSerializerDefaults.CreateSerializer(detailType, int.MaxValue);
	}

	protected virtual FaultException CreateFaultException(MessageFault messageFault, string action)
	{
		IList<FaultContractInfo> list;
		if (action != null)
		{
			list = new List<FaultContractInfo>();
			for (int i = 0; i < _faultContractInfos.Length; i++)
			{
				if (_faultContractInfos[i].Action == action || _faultContractInfos[i].Action == "*")
				{
					list.Add(_faultContractInfos[i]);
				}
			}
		}
		else
		{
			list = _faultContractInfos;
		}
		Type type = null;
		object obj = null;
		for (int j = 0; j < list.Count; j++)
		{
			FaultContractInfo faultContractInfo = list[j];
			XmlDictionaryReader readerAtDetailContents = messageFault.GetReaderAtDetailContents();
			XmlObjectSerializer serializer = faultContractInfo.Serializer;
			if (!serializer.IsStartObject(readerAtDetailContents))
			{
				continue;
			}
			type = faultContractInfo.Detail;
			try
			{
				obj = serializer.ReadObject(readerAtDetailContents);
				FaultException ex = CreateFaultException(messageFault, action, obj, type, readerAtDetailContents);
				if (ex != null)
				{
					return ex;
				}
			}
			catch (SerializationException)
			{
			}
		}
		return new FaultException(messageFault, action);
	}

	protected FaultException CreateFaultException(MessageFault messageFault, string action, object detailObj, Type detailType, XmlDictionaryReader detailReader)
	{
		if (!detailReader.EOF)
		{
			detailReader.MoveToContent();
			if (detailReader.NodeType != XmlNodeType.EndElement && !detailReader.EOF)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(System.SR.ExtraContentIsPresentInFaultDetail));
			}
		}
		bool flag = true;
		if ((detailObj != null) ? detailType.IsAssignableFrom(detailObj.GetType()) : (!detailType.IsValueType()))
		{
			Type type = typeof(FaultException<>).MakeGenericType(detailType);
			return (FaultException)Activator.CreateInstance(type, detailObj, messageFault.Reason, messageFault.Code, action);
		}
		return null;
	}

	private static FaultContractInfo[] GetSortedArray(List<FaultContractInfo> faultContractInfoList)
	{
		FaultContractInfo[] array = faultContractInfoList.ToArray();
		Array.Sort(array, (FaultContractInfo x, FaultContractInfo y) => string.CompareOrdinal(x.Action, y.Action));
		return array;
	}

	private static void AddInfrastructureFaults(List<FaultContractInfo> faultContractInfos)
	{
		faultContractInfos.Add(new FaultContractInfo("http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher/fault", typeof(ExceptionDetail)));
	}

	private static MessageFault CreateMessageFault(XmlObjectSerializer serializer, FaultException faultException, Type detailType)
	{
		if (detailType == null)
		{
			if (faultException.Fault != null)
			{
				return faultException.Fault;
			}
			return MessageFault.CreateFault(faultException.Code, faultException.Reason);
		}
		Type type = typeof(OperationFault<>).MakeGenericType(detailType);
		return (MessageFault)Activator.CreateInstance(type, serializer, faultException);
	}
}
