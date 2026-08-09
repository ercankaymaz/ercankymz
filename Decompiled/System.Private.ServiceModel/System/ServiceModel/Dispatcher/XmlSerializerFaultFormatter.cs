using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace System.ServiceModel.Dispatcher;

internal class XmlSerializerFaultFormatter : FaultFormatter
{
	private SynchronizedCollection<XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo> _xmlSerializerFaultContractInfos;

	internal XmlSerializerFaultFormatter(Type[] detailTypes, SynchronizedCollection<XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo> xmlSerializerFaultContractInfos)
		: base(detailTypes)
	{
		Initialize(xmlSerializerFaultContractInfos);
	}

	internal XmlSerializerFaultFormatter(SynchronizedCollection<FaultContractInfo> faultContractInfoCollection, SynchronizedCollection<XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo> xmlSerializerFaultContractInfos)
		: base(faultContractInfoCollection)
	{
		Initialize(xmlSerializerFaultContractInfos);
	}

	private void Initialize(SynchronizedCollection<XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo> xmlSerializerFaultContractInfos)
	{
		_xmlSerializerFaultContractInfos = xmlSerializerFaultContractInfos ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("xmlSerializerFaultContractInfos");
	}

	protected override XmlObjectSerializer GetSerializer(Type detailType, string faultExceptionAction, out string action)
	{
		action = faultExceptionAction;
		XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo xmlSerializerFaultContractInfo = null;
		for (int i = 0; i < _xmlSerializerFaultContractInfos.Count; i++)
		{
			if (_xmlSerializerFaultContractInfos[i].FaultContractInfo.Detail == detailType)
			{
				xmlSerializerFaultContractInfo = _xmlSerializerFaultContractInfos[i];
				break;
			}
		}
		if (xmlSerializerFaultContractInfo != null)
		{
			if (action == null)
			{
				action = xmlSerializerFaultContractInfo.FaultContractInfo.Action;
			}
			return xmlSerializerFaultContractInfo.Serializer;
		}
		return new XmlSerializerObjectSerializer(detailType);
	}

	protected override FaultException CreateFaultException(MessageFault messageFault, string action)
	{
		IList<XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo> list;
		if (action != null)
		{
			list = new List<XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo>();
			for (int i = 0; i < _xmlSerializerFaultContractInfos.Count; i++)
			{
				if (_xmlSerializerFaultContractInfos[i].FaultContractInfo.Action == action || _xmlSerializerFaultContractInfos[i].FaultContractInfo.Action == "*")
				{
					list.Add(_xmlSerializerFaultContractInfos[i]);
				}
			}
		}
		else
		{
			list = _xmlSerializerFaultContractInfos;
		}
		Type type = null;
		object obj = null;
		for (int j = 0; j < list.Count; j++)
		{
			XmlSerializerOperationBehavior.Reflector.XmlSerializerFaultContractInfo xmlSerializerFaultContractInfo = list[j];
			XmlDictionaryReader readerAtDetailContents = messageFault.GetReaderAtDetailContents();
			XmlObjectSerializer serializer = xmlSerializerFaultContractInfo.Serializer;
			if (!serializer.IsStartObject(readerAtDetailContents))
			{
				continue;
			}
			type = xmlSerializerFaultContractInfo.FaultContractInfo.Detail;
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
}
