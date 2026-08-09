using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;
using System.Xml.Serialization;

namespace System.ServiceModel.Description;

public class XmlSerializerOperationBehavior : IOperationBehavior
{
	internal class Reflector
	{
		internal class OperationReflector
		{
			private readonly Reflector _parent;

			internal readonly OperationDescription Operation;

			internal readonly XmlSerializerFormatAttribute Attribute;

			internal readonly bool IsEncoded;

			internal readonly bool IsRpc;

			internal readonly bool IsOneWay;

			internal readonly bool RequestRequiresSerialization;

			internal readonly bool ReplyRequiresSerialization;

			private readonly string _keyBase;

			private MessageInfo _request;

			private MessageInfo _reply;

			private SynchronizedCollection<XmlSerializerFaultContractInfo> _xmlSerializerFaultContractInfos;

			private string ContractName => Operation.DeclaringContract.Name;

			private string ContractNamespace => Operation.DeclaringContract.Namespace;

			internal MessageInfo Request
			{
				get
				{
					_parent.EnsureMessageInfos();
					return _request;
				}
			}

			internal MessageInfo Reply
			{
				get
				{
					_parent.EnsureMessageInfos();
					return _reply;
				}
			}

			internal SynchronizedCollection<XmlSerializerFaultContractInfo> XmlSerializerFaultContractInfos
			{
				get
				{
					_parent.EnsureMessageInfos();
					return _xmlSerializerFaultContractInfos;
				}
			}

			internal OperationReflector(Reflector parent, OperationDescription operation, XmlSerializerFormatAttribute attr, bool reflectOnDemand)
			{
				OperationFormatter.Validate(operation, attr.Style == OperationFormatStyle.Rpc, attr.IsEncoded);
				_parent = parent;
				Operation = operation;
				Attribute = attr;
				IsEncoded = attr.IsEncoded;
				IsRpc = attr.Style == OperationFormatStyle.Rpc;
				IsOneWay = operation.Messages.Count == 1;
				RequestRequiresSerialization = !operation.Messages[0].IsUntypedMessage;
				ReplyRequiresSerialization = !IsOneWay && !operation.Messages[1].IsUntypedMessage;
				MethodInfo operationMethod = operation.OperationMethod;
				if (operationMethod == null)
				{
					_keyBase = string.Empty;
					if (operation.DeclaringContract != null)
					{
						_keyBase = operation.DeclaringContract.Name + "," + operation.DeclaringContract.Namespace + ":";
					}
					_keyBase += operation.Name;
				}
				else
				{
					_keyBase = operationMethod.DeclaringType.FullName + ":" + operationMethod.ToString();
				}
				foreach (MessageDescription message in operation.Messages)
				{
					foreach (MessageHeaderDescription header in message.Headers)
					{
						SetUnknownHeaderInDescription(header);
					}
				}
				if (!reflectOnDemand)
				{
					EnsureMessageInfos();
				}
			}

			private void SetUnknownHeaderInDescription(MessageHeaderDescription header)
			{
				if (header.AdditionalAttributesProvider == null)
				{
					return;
				}
				object[] customAttributes = header.AdditionalAttributesProvider.GetCustomAttributes(inherit: false);
				object[] array = customAttributes;
				foreach (object obj in array)
				{
					if (obj is XmlAnyElementAttribute && string.IsNullOrEmpty(((XmlAnyElementAttribute)obj).Name))
					{
						header.IsUnknownHeaderCollection = true;
					}
				}
			}

			internal void EnsureMessageInfos()
			{
				if (_request != null)
				{
					return;
				}
				foreach (Type knownType in Operation.KnownTypes)
				{
					if (knownType == null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxKnownTypeNull, Operation.Name)));
					}
					_parent._importer.IncludeType(knownType, IsEncoded);
				}
				_request = CreateMessageInfo(Operation.Messages[0], ":Request");
				bool flag = Fx.IsUap && GeneratedXmlSerializers.IsInitialized;
				if (_request != null && IsRpc && Operation.IsValidateRpcWrapperName && !flag && _request.BodyMapping.XsdElementName != Operation.Name)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxRpcMessageBodyPartNameInvalid, Operation.Name, Operation.Messages[0].MessageName, _request.BodyMapping.XsdElementName, Operation.Name)));
				}
				if (!IsOneWay)
				{
					_reply = CreateMessageInfo(Operation.Messages[1], ":Response");
					XmlName bodyWrapperResponseName = TypeLoader.GetBodyWrapperResponseName(Operation.Name);
					if (_reply != null && IsRpc && Operation.IsValidateRpcWrapperName && !flag && _reply.BodyMapping.XsdElementName != bodyWrapperResponseName.EncodedName)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxRpcMessageBodyPartNameInvalid, Operation.Name, Operation.Messages[1].MessageName, _reply.BodyMapping.XsdElementName, bodyWrapperResponseName.EncodedName)));
					}
				}
				if (Attribute.SupportFaults)
				{
					GenerateXmlSerializerFaultContractInfos();
				}
			}

			private void GenerateXmlSerializerFaultContractInfos()
			{
				SynchronizedCollection<XmlSerializerFaultContractInfo> synchronizedCollection = new SynchronizedCollection<XmlSerializerFaultContractInfo>();
				for (int i = 0; i < Operation.Faults.Count; i++)
				{
					FaultDescription faultDescription = Operation.Faults[i];
					FaultContractInfo faultContractInfo = new FaultContractInfo(faultDescription.Action, faultDescription.DetailType, faultDescription.ElementName, faultDescription.Namespace, Operation.KnownTypes);
					XmlQualifiedName elementName;
					XmlMembersMapping mapping = ImportFaultElement(faultDescription, out elementName);
					SerializerStub serializerStub = _parent._generation.AddSerializer(mapping);
					synchronizedCollection.Add(new XmlSerializerFaultContractInfo(faultContractInfo, serializerStub, elementName));
				}
				_xmlSerializerFaultContractInfos = synchronizedCollection;
			}

			private MessageInfo CreateMessageInfo(MessageDescription message, string key)
			{
				if (message.IsUntypedMessage)
				{
					return null;
				}
				MessageInfo messageInfo = new MessageInfo();
				if (message.IsTypedMessage)
				{
					string[] obj = new string[5]
					{
						message.MessageType.FullName,
						":",
						null,
						null,
						null
					};
					bool isEncoded = IsEncoded;
					obj[2] = isEncoded.ToString();
					obj[3] = ":";
					isEncoded = IsRpc;
					obj[4] = isEncoded.ToString();
					key = string.Concat(obj);
				}
				XmlMembersMapping xmlMembersMapping = LoadHeadersMapping(message, key + ":Headers");
				messageInfo.SetHeaders(_parent._generation.AddSerializer(xmlMembersMapping));
				messageInfo.SetBody(_parent._generation.AddSerializer(LoadBodyMapping(message, key, out var rpcEncodedTypedMessageBodyParts)), rpcEncodedTypedMessageBodyParts);
				CreateHeaderDescriptionTable(message, messageInfo, xmlMembersMapping);
				return messageInfo;
			}

			private void CreateHeaderDescriptionTable(MessageDescription message, MessageInfo info, XmlMembersMapping headersMapping)
			{
				int num = 0;
				OperationFormatter.MessageHeaderDescriptionTable messageHeaderDescriptionTable = new OperationFormatter.MessageHeaderDescriptionTable();
				info.SetHeaderDescriptionTable(messageHeaderDescriptionTable);
				foreach (MessageHeaderDescription header in message.Headers)
				{
					if (header.IsUnknownHeaderCollection)
					{
						info.SetUnknownHeaderDescription(header);
					}
					else
					{
						if (headersMapping == null)
						{
							continue;
						}
						XmlMemberMapping xmlMemberMapping = headersMapping[num++];
						if (GeneratedXmlSerializers.IsInitialized)
						{
							messageHeaderDescriptionTable.Add(header.Name, header.Namespace, header);
							continue;
						}
						string text;
						string text2;
						if (IsEncoded)
						{
							text = xmlMemberMapping.TypeName;
							text2 = xmlMemberMapping.TypeNamespace;
						}
						else
						{
							text = xmlMemberMapping.XsdElementName;
							text2 = xmlMemberMapping.Namespace;
						}
						if (text != header.Name)
						{
							if (message.MessageType != null)
							{
								throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxHeaderNameMismatchInMessageContract, message.MessageType, header.MemberInfo.Name, header.Name, text)));
							}
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxHeaderNameMismatchInOperation, Operation.Name, Operation.DeclaringContract.Name, Operation.DeclaringContract.Namespace, header.Name, text)));
						}
						if (text2 != header.Namespace)
						{
							if (message.MessageType != null)
							{
								throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxHeaderNamespaceMismatchInMessageContract, message.MessageType, header.MemberInfo.Name, header.Namespace, text2)));
							}
							throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxHeaderNamespaceMismatchInOperation, Operation.Name, Operation.DeclaringContract.Name, Operation.DeclaringContract.Namespace, header.Namespace, text2)));
						}
						messageHeaderDescriptionTable.Add(text, text2, header);
					}
				}
			}

			private XmlMembersMapping LoadBodyMapping(MessageDescription message, string mappingKey, out MessagePartDescriptionCollection rpcEncodedTypedMessageBodyParts)
			{
				MessagePartDescription messagePartDescription;
				MessagePartDescriptionCollection messagePartDescriptionCollection;
				string text;
				string ns;
				if (IsEncoded && message.IsTypedMessage && message.Body.WrapperName == null)
				{
					MessagePartDescription wrapperPart = GetWrapperPart(message);
					messagePartDescription = null;
					messagePartDescriptionCollection = (rpcEncodedTypedMessageBodyParts = GetWrappedParts(wrapperPart));
					text = wrapperPart.Name;
					ns = wrapperPart.Namespace;
				}
				else
				{
					rpcEncodedTypedMessageBodyParts = null;
					messagePartDescription = (OperationFormatter.IsValidReturnValue(message.Body.ReturnValue) ? message.Body.ReturnValue : null);
					messagePartDescriptionCollection = message.Body.Parts;
					text = message.Body.WrapperName;
					ns = message.Body.WrapperNamespace;
				}
				bool flag = text != null;
				bool flag2 = messagePartDescription != null;
				int num = messagePartDescriptionCollection.Count + (flag2 ? 1 : 0);
				if (num == 0 && !flag)
				{
					return null;
				}
				XmlReflectionMember[] array = new XmlReflectionMember[num];
				int num2 = 0;
				if (flag2)
				{
					array[num2++] = XmlSerializerHelper.GetXmlReflectionMember(messagePartDescription, IsRpc, IsEncoded, flag);
				}
				for (int i = 0; i < messagePartDescriptionCollection.Count; i++)
				{
					array[num2++] = XmlSerializerHelper.GetXmlReflectionMember(messagePartDescriptionCollection[i], IsRpc, IsEncoded, flag);
				}
				if (!flag)
				{
					ns = ContractNamespace;
				}
				return ImportMembersMapping(text, ns, array, flag, IsRpc, mappingKey);
			}

			private MessagePartDescription GetWrapperPart(MessageDescription message)
			{
				if (message.Body.Parts.Count != 1)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxRpcMessageMustHaveASingleBody, Operation.Name, message.MessageName)));
				}
				MessagePartDescription messagePartDescription = message.Body.Parts[0];
				Type type = messagePartDescription.Type;
				if (type.BaseType != null && type.BaseType != typeof(object))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxBodyObjectTypeCannotBeInherited, type.FullName)));
				}
				if (typeof(IEnumerable).IsAssignableFrom(type))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxBodyObjectTypeCannotBeInterface, type.FullName, typeof(IEnumerable).FullName)));
				}
				if (typeof(IXmlSerializable).IsAssignableFrom(type))
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxBodyObjectTypeCannotBeInterface, type.FullName, typeof(IXmlSerializable).FullName)));
				}
				return messagePartDescription;
			}

			private MessagePartDescriptionCollection GetWrappedParts(MessagePartDescription bodyPart)
			{
				Type type = bodyPart.Type;
				MessagePartDescriptionCollection messagePartDescriptionCollection = new MessagePartDescriptionCollection();
				MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public);
				foreach (MemberInfo memberInfo in members)
				{
					if ((memberInfo.MemberType & (MemberTypes.Field | MemberTypes.Property)) != 0 && !memberInfo.IsDefined(typeof(SoapIgnoreAttribute), inherit: false))
					{
						XmlName xmlName = new XmlName(memberInfo.Name);
						MessagePartDescription messagePartDescription = new MessagePartDescription(xmlName.EncodedName, string.Empty);
						MemberInfo additionalAttributesProvider = (messagePartDescription.MemberInfo = memberInfo);
						messagePartDescription.AdditionalAttributesProvider = additionalAttributesProvider;
						int index = (messagePartDescription.SerializationPosition = messagePartDescriptionCollection.Count);
						messagePartDescription.Index = index;
						messagePartDescription.Type = ((memberInfo.MemberType == MemberTypes.Property) ? ((PropertyInfo)memberInfo).PropertyType : ((FieldInfo)memberInfo).FieldType);
						if (bodyPart.HasProtectionLevel)
						{
							messagePartDescription.ProtectionLevel = bodyPart.ProtectionLevel;
						}
						messagePartDescriptionCollection.Add(messagePartDescription);
					}
				}
				return messagePartDescriptionCollection;
			}

			private XmlMembersMapping LoadHeadersMapping(MessageDescription message, string mappingKey)
			{
				int count = message.Headers.Count;
				if (count == 0)
				{
					return null;
				}
				int num = 0;
				int num2 = 0;
				XmlReflectionMember[] array = new XmlReflectionMember[count];
				for (int i = 0; i < count; i++)
				{
					MessageHeaderDescription messageHeaderDescription = message.Headers[i];
					if (!messageHeaderDescription.IsUnknownHeaderCollection)
					{
						array[num2++] = XmlSerializerHelper.GetXmlReflectionMember(messageHeaderDescription, isRpc: false, IsEncoded, isWrapped: false);
					}
					else
					{
						num++;
					}
				}
				if (num == count)
				{
					return null;
				}
				if (num > 0)
				{
					XmlReflectionMember[] array2 = new XmlReflectionMember[count - num];
					Array.Copy(array, array2, array2.Length);
					array = array2;
				}
				return ImportMembersMapping(ContractName, ContractNamespace, array, hasWrapperElement: false, rpc: false, mappingKey);
			}

			internal XmlMembersMapping ImportMembersMapping(string elementName, string ns, XmlReflectionMember[] members, bool hasWrapperElement, bool rpc, string mappingKey)
			{
				string mappingKey2 = (mappingKey.StartsWith(":", StringComparison.Ordinal) ? (_keyBase + mappingKey) : mappingKey);
				return _parent._importer.ImportMembersMapping(new XmlName(elementName, isEncoded: true), ns, members, hasWrapperElement, rpc, IsEncoded, mappingKey2);
			}

			internal XmlMembersMapping ImportFaultElement(FaultDescription fault, out XmlQualifiedName elementName)
			{
				XmlReflectionMember[] array = new XmlReflectionMember[1];
				XmlName xmlName = fault.ElementName;
				string text = fault.Namespace;
				if (xmlName == null)
				{
					XmlTypeMapping xmlTypeMapping = _parent._importer.ImportTypeMapping(fault.DetailType, IsEncoded);
					xmlName = new XmlName(xmlTypeMapping.ElementName, IsEncoded);
					text = xmlTypeMapping.Namespace;
					if (xmlName == null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxFaultTypeAnonymous, Operation.Name, fault.DetailType.FullName)));
					}
				}
				elementName = new XmlQualifiedName(xmlName.DecodedName, text);
				array[0] = XmlSerializerHelper.GetXmlReflectionMember(null, xmlName, text, fault.DetailType, null, isMultiple: false, IsEncoded, isWrapped: false);
				string mappingKey = "fault:" + xmlName.DecodedName + ":" + text;
				return ImportMembersMapping(xmlName.EncodedName, text, array, hasWrapperElement: false, IsRpc, mappingKey);
			}
		}

		private class XmlSerializerImporter
		{
			private readonly string _defaultNs;

			private XmlReflectionImporter _xmlImporter;

			private SoapReflectionImporter _soapImporter;

			private Dictionary<string, XmlMembersMapping> _xmlMappings;

			private HashSet<Type> _includedTypes;

			private SoapReflectionImporter SoapImporter
			{
				get
				{
					if (_soapImporter == null)
					{
						_soapImporter = new SoapReflectionImporter(NamingHelper.CombineUriStrings(_defaultNs, "encoded"));
					}
					return _soapImporter;
				}
			}

			private XmlReflectionImporter XmlImporter
			{
				get
				{
					if (_xmlImporter == null)
					{
						_xmlImporter = new XmlReflectionImporter(_defaultNs);
					}
					return _xmlImporter;
				}
			}

			private Dictionary<string, XmlMembersMapping> XmlMappings
			{
				get
				{
					if (_xmlMappings == null)
					{
						_xmlMappings = new Dictionary<string, XmlMembersMapping>();
					}
					return _xmlMappings;
				}
			}

			private HashSet<Type> IncludedTypes
			{
				get
				{
					if (_includedTypes == null)
					{
						_includedTypes = new HashSet<Type>();
					}
					return _includedTypes;
				}
			}

			internal XmlSerializerImporter(string defaultNs)
			{
				_defaultNs = defaultNs;
				_xmlImporter = null;
				_soapImporter = null;
			}

			internal XmlMembersMapping ImportMembersMapping(XmlName elementName, string ns, XmlReflectionMember[] members, bool hasWrapperElement, bool rpc, bool isEncoded, string mappingKey)
			{
				string decodedName = elementName.DecodedName;
				if (XmlMappings.TryGetValue(mappingKey, out var value))
				{
					return value;
				}
				value = ((!isEncoded) ? XmlImporter.ImportMembersMapping(decodedName, ns, members, hasWrapperElement, rpc) : SoapImporter.ImportMembersMapping(decodedName, ns, members, hasWrapperElement, rpc));
				if (Fx.IsUap)
				{
					value.SetKeyInternal(mappingKey);
				}
				else
				{
					value.SetKey(mappingKey);
				}
				XmlMappings.Add(mappingKey, value);
				return value;
			}

			internal XmlTypeMapping ImportTypeMapping(Type type, bool isEncoded)
			{
				if (isEncoded)
				{
					return SoapImporter.ImportTypeMapping(type);
				}
				return XmlImporter.ImportTypeMapping(type);
			}

			internal void IncludeType(Type knownType, bool isEncoded)
			{
				if (!IncludedTypes.Contains(knownType))
				{
					if (isEncoded)
					{
						SoapImporter.IncludeType(knownType);
					}
					else
					{
						XmlImporter.IncludeType(knownType);
					}
					IncludedTypes.Add(knownType);
				}
			}
		}

		internal class SerializerGenerationContext
		{
			private List<XmlMembersMapping> _mappings = new List<XmlMembersMapping>();

			private XmlSerializer[] _serializers;

			private Type _type;

			private object _thisLock = new object();

			internal SerializerGenerationContext(Type type)
			{
				_type = type;
			}

			internal SerializerStub AddSerializer(XmlMembersMapping mapping)
			{
				int handle = -1;
				if (mapping != null)
				{
					handle = ((IList)_mappings).Add((object?)mapping);
				}
				return new SerializerStub(this, mapping, handle);
			}

			internal XmlSerializer GetSerializer(int handle)
			{
				if (handle < 0)
				{
					return null;
				}
				if (_serializers == null)
				{
					lock (_thisLock)
					{
						if (_serializers == null)
						{
							_serializers = GenerateSerializers();
						}
					}
				}
				return _serializers[handle];
			}

			private XmlSerializer[] GenerateSerializers()
			{
				List<XmlMembersMapping> list = new List<XmlMembersMapping>();
				int[] array = new int[_mappings.Count];
				for (int i = 0; i < _mappings.Count; i++)
				{
					XmlMembersMapping item = _mappings[i];
					int num = list.IndexOf(item);
					if (num < 0)
					{
						list.Add(item);
						num = list.Count - 1;
					}
					array[i] = num;
				}
				XmlMapping[] mappings = list.ToArray();
				XmlSerializer[] array2 = CreateSerializersFromMappings(mappings, _type);
				if (list.Count == _mappings.Count)
				{
					return array2;
				}
				XmlSerializer[] array3 = new XmlSerializer[_mappings.Count];
				for (int j = 0; j < _mappings.Count; j++)
				{
					array3[j] = array2[array[j]];
				}
				return array3;
			}

			[SecuritySafeCritical]
			private XmlSerializer[] CreateSerializersFromMappings(XmlMapping[] mappings, Type type)
			{
				return XmlSerializerHelper.FromMappings(mappings, type);
			}
		}

		internal struct SerializerStub
		{
			private readonly SerializerGenerationContext _context;

			internal readonly XmlMembersMapping Mapping;

			internal readonly int Handle;

			internal SerializerStub(SerializerGenerationContext context, XmlMembersMapping mapping, int handle)
			{
				_context = context;
				Mapping = mapping;
				Handle = handle;
			}

			internal XmlSerializer GetSerializer()
			{
				return _context.GetSerializer(Handle);
			}
		}

		internal class XmlSerializerFaultContractInfo
		{
			private SerializerStub _serializerStub;

			private XmlSerializerObjectSerializer _serializer;

			internal FaultContractInfo FaultContractInfo { get; }

			internal XmlQualifiedName FaultContractElementName { get; }

			internal XmlSerializerObjectSerializer Serializer
			{
				get
				{
					if (_serializer == null)
					{
						_serializer = new XmlSerializerObjectSerializer(FaultContractInfo.Detail, FaultContractElementName, _serializerStub.GetSerializer());
					}
					return _serializer;
				}
			}

			internal XmlSerializerFaultContractInfo(FaultContractInfo faultContractInfo, SerializerStub serializerStub, XmlQualifiedName faultContractElementName)
			{
				FaultContractInfo = faultContractInfo ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("faultContractInfo");
				_serializerStub = serializerStub;
				FaultContractElementName = faultContractElementName ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("faultContractElementName");
			}
		}

		internal class MessageInfo : XmlSerializerOperationFormatter.MessageInfo
		{
			private SerializerStub _headers;

			private SerializerStub _body;

			private OperationFormatter.MessageHeaderDescriptionTable _headerDescriptionTable;

			private MessageHeaderDescription _unknownHeaderDescription;

			private MessagePartDescriptionCollection _rpcEncodedTypedMessageBodyParts;

			internal XmlMembersMapping BodyMapping => _body.Mapping;

			internal override XmlSerializer BodySerializer => _body.GetSerializer();

			internal XmlMembersMapping HeadersMapping => _headers.Mapping;

			internal override XmlSerializer HeaderSerializer => _headers.GetSerializer();

			internal override OperationFormatter.MessageHeaderDescriptionTable HeaderDescriptionTable => _headerDescriptionTable;

			internal override MessageHeaderDescription UnknownHeaderDescription => _unknownHeaderDescription;

			internal override MessagePartDescriptionCollection RpcEncodedTypedMessageBodyParts => _rpcEncodedTypedMessageBodyParts;

			internal void SetBody(SerializerStub body, MessagePartDescriptionCollection rpcEncodedTypedMessageBodyParts)
			{
				_body = body;
				_rpcEncodedTypedMessageBodyParts = rpcEncodedTypedMessageBodyParts;
			}

			internal void SetHeaders(SerializerStub headers)
			{
				_headers = headers;
			}

			internal void SetHeaderDescriptionTable(OperationFormatter.MessageHeaderDescriptionTable headerDescriptionTable)
			{
				_headerDescriptionTable = headerDescriptionTable;
			}

			internal void SetUnknownHeaderDescription(MessageHeaderDescription unknownHeaderDescription)
			{
				_unknownHeaderDescription = unknownHeaderDescription;
			}
		}

		private readonly XmlSerializerImporter _importer;

		private readonly SerializerGenerationContext _generation;

		private Collection<OperationReflector> _operationReflectors = new Collection<OperationReflector>();

		private object _thisLock = new object();

		internal Reflector(string defaultNs, Type type)
		{
			_importer = new XmlSerializerImporter(defaultNs);
			_generation = new SerializerGenerationContext(type);
		}

		internal void EnsureMessageInfos()
		{
			lock (_thisLock)
			{
				foreach (OperationReflector operationReflector in _operationReflectors)
				{
					operationReflector.EnsureMessageInfos();
				}
			}
		}

		private static XmlSerializerFormatAttribute FindAttribute(OperationDescription operation)
		{
			Type type = ((operation.DeclaringContract != null) ? operation.DeclaringContract.ContractType : null);
			XmlSerializerFormatAttribute defaultFormatAttribute = ((type != null) ? (TypeLoader.GetFormattingAttribute(type, null) as XmlSerializerFormatAttribute) : null);
			return TypeLoader.GetFormattingAttribute(operation.OperationMethod, defaultFormatAttribute) as XmlSerializerFormatAttribute;
		}

		internal OperationReflector ReflectOperation(OperationDescription operation)
		{
			XmlSerializerFormatAttribute xmlSerializerFormatAttribute = FindAttribute(operation);
			if (xmlSerializerFormatAttribute == null)
			{
				return null;
			}
			return ReflectOperation(operation, xmlSerializerFormatAttribute);
		}

		internal OperationReflector ReflectOperation(OperationDescription operation, XmlSerializerFormatAttribute attrOverride)
		{
			OperationReflector operationReflector = new OperationReflector(this, operation, attrOverride, reflectOnDemand: true);
			_operationReflectors.Add(operationReflector);
			return operationReflector;
		}
	}

	private readonly bool _builtInOperationBehavior;

	internal Reflector.OperationReflector OperationReflector { get; }

	internal bool IsBuiltInOperationBehavior => _builtInOperationBehavior;

	public XmlSerializerFormatAttribute XmlSerializerFormatAttribute => OperationReflector.Attribute;

	public XmlSerializerOperationBehavior(OperationDescription operation)
		: this(operation, null)
	{
	}

	public XmlSerializerOperationBehavior(OperationDescription operation, XmlSerializerFormatAttribute attribute)
	{
		if (operation == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("operation");
		}
		Reflector reflector = new Reflector(operation.DeclaringContract.Namespace, operation.DeclaringContract.ContractType);
		OperationReflector = reflector.ReflectOperation(operation, attribute ?? new XmlSerializerFormatAttribute());
	}

	internal XmlSerializerOperationBehavior(OperationDescription operation, XmlSerializerFormatAttribute attribute, Reflector parentReflector)
		: this(operation, attribute)
	{
		OperationReflector = parentReflector.ReflectOperation(operation, attribute ?? new XmlSerializerFormatAttribute());
	}

	private XmlSerializerOperationBehavior(Reflector.OperationReflector reflector, bool builtInOperationBehavior)
	{
		OperationReflector = reflector;
		_builtInOperationBehavior = builtInOperationBehavior;
	}

	internal static XmlSerializerOperationFormatter CreateOperationFormatter(OperationDescription operation)
	{
		return new XmlSerializerOperationBehavior(operation).CreateFormatter();
	}

	internal static XmlSerializerOperationFormatter CreateOperationFormatter(OperationDescription operation, XmlSerializerFormatAttribute attr)
	{
		return new XmlSerializerOperationBehavior(operation, attr).CreateFormatter();
	}

	internal static void AddBehaviors(ContractDescription contract)
	{
		AddBehaviors(contract, builtInOperationBehavior: false);
	}

	internal static void AddBuiltInBehaviors(ContractDescription contract)
	{
		AddBehaviors(contract, builtInOperationBehavior: true);
	}

	private static void AddBehaviors(ContractDescription contract, bool builtInOperationBehavior)
	{
		Reflector reflector = new Reflector(contract.Namespace, contract.ContractType);
		foreach (OperationDescription operation in contract.Operations)
		{
			Reflector.OperationReflector operationReflector = reflector.ReflectOperation(operation);
			if (operationReflector != null && operation.DeclaringContract == contract)
			{
				operation.Behaviors.Add(new XmlSerializerOperationBehavior(operationReflector, builtInOperationBehavior));
			}
		}
	}

	internal XmlSerializerOperationFormatter CreateFormatter()
	{
		return new XmlSerializerOperationFormatter(OperationReflector.Operation, OperationReflector.Attribute, OperationReflector.Request, OperationReflector.Reply);
	}

	private XmlSerializerFaultFormatter CreateFaultFormatter(SynchronizedCollection<FaultContractInfo> faultContractInfos)
	{
		return new XmlSerializerFaultFormatter(faultContractInfos, OperationReflector.XmlSerializerFaultContractInfos);
	}

	void IOperationBehavior.Validate(OperationDescription description)
	{
	}

	void IOperationBehavior.AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
	{
	}

	void IOperationBehavior.ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		if (dispatch == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("dispatch");
		}
		if (dispatch.Formatter == null)
		{
			dispatch.Formatter = CreateFormatter();
			dispatch.DeserializeRequest = OperationReflector.RequestRequiresSerialization;
			dispatch.SerializeReply = OperationReflector.ReplyRequiresSerialization;
		}
		if (OperationReflector.Attribute.SupportFaults && !dispatch.IsFaultFormatterSetExplicit)
		{
			dispatch.FaultFormatter = CreateFaultFormatter(dispatch.FaultContractInfos);
		}
	}

	void IOperationBehavior.ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		if (proxy == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("proxy");
		}
		if (proxy.Formatter == null)
		{
			proxy.Formatter = CreateFormatter();
			proxy.SerializeRequest = OperationReflector.RequestRequiresSerialization;
			proxy.DeserializeReply = OperationReflector.ReplyRequiresSerialization;
		}
		if (OperationReflector.Attribute.SupportFaults && !proxy.IsFaultFormatterSetExplicit)
		{
			proxy.FaultFormatter = CreateFaultFormatter(proxy.FaultContractInfos);
		}
	}

	public Collection<XmlMapping> GetXmlMappings()
	{
		Collection<XmlMapping> collection = new Collection<XmlMapping>();
		if (OperationReflector.Request != null && OperationReflector.Request.HeadersMapping != null)
		{
			collection.Add(OperationReflector.Request.HeadersMapping);
		}
		if (OperationReflector.Request != null && OperationReflector.Request.BodyMapping != null)
		{
			collection.Add(OperationReflector.Request.BodyMapping);
		}
		if (OperationReflector.Reply != null && OperationReflector.Reply.HeadersMapping != null)
		{
			collection.Add(OperationReflector.Reply.HeadersMapping);
		}
		if (OperationReflector.Reply != null && OperationReflector.Reply.BodyMapping != null)
		{
			collection.Add(OperationReflector.Reply.BodyMapping);
		}
		return collection;
	}
}
