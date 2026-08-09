using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Description;

namespace System.ServiceModel.Dispatcher;

public class FaultContractInfo
{
	private string _ns;

	private DataContractSerializer _serializer;

	public string Action { get; }

	public Type Detail { get; }

	internal string ElementName { get; }

	internal string ElementNamespace => _ns;

	internal IList<Type> KnownTypes { get; }

	internal DataContractSerializer Serializer
	{
		get
		{
			if (_serializer == null)
			{
				if (ElementName == null)
				{
					_serializer = DataContractSerializerDefaults.CreateSerializer(Detail, KnownTypes, int.MaxValue);
				}
				else
				{
					_serializer = DataContractSerializerDefaults.CreateSerializer(Detail, KnownTypes, ElementName, (_ns == null) ? string.Empty : _ns, int.MaxValue);
				}
			}
			return _serializer;
		}
	}

	public FaultContractInfo(string action, Type detail)
		: this(action, detail, null, null, null)
	{
	}

	internal FaultContractInfo(string action, Type detail, XmlName elementName, string ns, IList<Type> knownTypes)
	{
		Action = action ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("action");
		Detail = detail ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("detail");
		if (elementName != null)
		{
			ElementName = elementName.EncodedName;
		}
		_ns = ns;
		KnownTypes = knownTypes;
	}
}
