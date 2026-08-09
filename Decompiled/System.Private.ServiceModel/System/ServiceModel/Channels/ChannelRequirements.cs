using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel.Description;
using System.Text;

namespace System.ServiceModel.Channels;

internal struct ChannelRequirements
{
	public bool usesInput;

	public bool usesReply;

	public bool usesOutput;

	public bool usesRequest;

	public SessionMode sessionMode;

	public static void ComputeContractRequirements(ContractDescription contractDescription, out ChannelRequirements requirements)
	{
		requirements = default(ChannelRequirements);
		requirements.usesInput = false;
		requirements.usesReply = false;
		requirements.usesOutput = false;
		requirements.usesRequest = false;
		requirements.sessionMode = contractDescription.SessionMode;
		for (int i = 0; i < contractDescription.Operations.Count; i++)
		{
			OperationDescription operationDescription = contractDescription.Operations[i];
			bool isOneWay = operationDescription.IsOneWay;
			if (!operationDescription.IsServerInitiated())
			{
				if (isOneWay)
				{
					requirements.usesInput = true;
				}
				else
				{
					requirements.usesReply = true;
				}
			}
			else if (isOneWay)
			{
				requirements.usesOutput = true;
			}
			else
			{
				requirements.usesRequest = true;
			}
		}
	}

	public static Type[] ComputeRequiredChannels(ref ChannelRequirements requirements)
	{
		if (requirements.usesOutput || requirements.usesRequest)
		{
			switch (requirements.sessionMode)
			{
			case SessionMode.Allowed:
				return new Type[2]
				{
					typeof(IDuplexChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.Required:
				return new Type[1] { typeof(IDuplexSessionChannel) };
			case SessionMode.NotAllowed:
				return new Type[1] { typeof(IDuplexChannel) };
			}
		}
		else if (requirements.usesInput && requirements.usesReply)
		{
			switch (requirements.sessionMode)
			{
			case SessionMode.Allowed:
				return new Type[4]
				{
					typeof(IRequestChannel),
					typeof(IRequestSessionChannel),
					typeof(IDuplexChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.Required:
				return new Type[2]
				{
					typeof(IRequestSessionChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.NotAllowed:
				return new Type[1] { typeof(IRequestChannel) };
			}
		}
		else if (requirements.usesInput)
		{
			switch (requirements.sessionMode)
			{
			case SessionMode.Allowed:
				return new Type[6]
				{
					typeof(IOutputChannel),
					typeof(IOutputSessionChannel),
					typeof(IRequestChannel),
					typeof(IRequestSessionChannel),
					typeof(IDuplexChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.Required:
				return new Type[3]
				{
					typeof(IOutputSessionChannel),
					typeof(IRequestSessionChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.NotAllowed:
				return new Type[3]
				{
					typeof(IOutputChannel),
					typeof(IRequestChannel),
					typeof(IDuplexChannel)
				};
			}
		}
		else if (requirements.usesReply)
		{
			switch (requirements.sessionMode)
			{
			case SessionMode.Allowed:
				return new Type[4]
				{
					typeof(IRequestChannel),
					typeof(IRequestSessionChannel),
					typeof(IDuplexChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.Required:
				return new Type[2]
				{
					typeof(IRequestSessionChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.NotAllowed:
				return new Type[2]
				{
					typeof(IRequestChannel),
					typeof(IDuplexChannel)
				};
			}
		}
		else
		{
			switch (requirements.sessionMode)
			{
			case SessionMode.Allowed:
				return new Type[6]
				{
					typeof(IOutputSessionChannel),
					typeof(IOutputChannel),
					typeof(IRequestSessionChannel),
					typeof(IRequestChannel),
					typeof(IDuplexChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.Required:
				return new Type[3]
				{
					typeof(IOutputSessionChannel),
					typeof(IRequestSessionChannel),
					typeof(IDuplexSessionChannel)
				};
			case SessionMode.NotAllowed:
				return new Type[3]
				{
					typeof(IOutputChannel),
					typeof(IRequestChannel),
					typeof(IDuplexChannel)
				};
			}
		}
		return null;
	}

	public static bool IsSessionful(Type channelType)
	{
		if (!(channelType == typeof(IDuplexSessionChannel)) && !(channelType == typeof(IOutputSessionChannel)) && !(channelType == typeof(IInputSessionChannel)) && !(channelType == typeof(IReplySessionChannel)))
		{
			return channelType == typeof(IRequestSessionChannel);
		}
		return true;
	}

	public static bool IsOneWay(Type channelType)
	{
		if (!(channelType == typeof(IOutputChannel)) && !(channelType == typeof(IInputChannel)) && !(channelType == typeof(IInputSessionChannel)))
		{
			return channelType == typeof(IOutputSessionChannel);
		}
		return true;
	}

	public static bool IsRequestReply(Type channelType)
	{
		if (!(channelType == typeof(IRequestChannel)) && !(channelType == typeof(IReplyChannel)) && !(channelType == typeof(IReplySessionChannel)))
		{
			return channelType == typeof(IRequestSessionChannel);
		}
		return true;
	}

	public static bool IsDuplex(Type channelType)
	{
		if (!(channelType == typeof(IDuplexChannel)))
		{
			return channelType == typeof(IDuplexSessionChannel);
		}
		return true;
	}

	public static Exception CantCreateListenerException(IEnumerable<Type> supportedChannels, IEnumerable<Type> requiredChannels, string bindingName)
	{
		string contractChannelTypesString = "";
		string bindingChannelTypesString = "";
		Exception ex = BindingContractMismatchException(supportedChannels, requiredChannels, bindingName, ref contractChannelTypesString, ref bindingChannelTypesString);
		if (ex == null)
		{
			ex = new InvalidOperationException(System.SR.Format(System.SR.EndpointListenerRequirementsCannotBeMetBy3, bindingName, contractChannelTypesString, bindingChannelTypesString));
		}
		return ex;
	}

	public static Exception CantCreateChannelException(IEnumerable<Type> supportedChannels, IEnumerable<Type> requiredChannels, string bindingName)
	{
		string contractChannelTypesString = "";
		string bindingChannelTypesString = "";
		Exception ex = BindingContractMismatchException(supportedChannels, requiredChannels, bindingName, ref contractChannelTypesString, ref bindingChannelTypesString);
		if (ex == null)
		{
			ex = new InvalidOperationException(System.SR.Format(System.SR.CouldnTCreateChannelForType2, bindingName, contractChannelTypesString));
		}
		return ex;
	}

	public static Exception BindingContractMismatchException(IEnumerable<Type> supportedChannels, IEnumerable<Type> requiredChannels, string bindingName, ref string contractChannelTypesString, ref string bindingChannelTypesString)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		bool flag5 = true;
		bool flag6 = true;
		foreach (Type requiredChannel in requiredChannels)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
				stringBuilder.Append(" ");
			}
			string text = requiredChannel.ToString();
			stringBuilder.Append(text.Substring(text.LastIndexOf('.') + 1));
			if (!IsOneWay(requiredChannel))
			{
				flag = false;
			}
			if (!IsRequestReply(requiredChannel))
			{
				flag2 = false;
			}
			if (!IsDuplex(requiredChannel))
			{
				flag3 = false;
			}
			if (!IsRequestReply(requiredChannel) && !IsDuplex(requiredChannel))
			{
				flag4 = false;
			}
			if (!IsSessionful(requiredChannel))
			{
				flag5 = false;
			}
			else
			{
				flag6 = false;
			}
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		bool flag7 = false;
		bool flag8 = false;
		bool flag9 = false;
		bool flag10 = false;
		bool flag11 = false;
		bool flag12 = false;
		foreach (Type supportedChannel in supportedChannels)
		{
			flag12 = true;
			if (stringBuilder2.Length > 0)
			{
				stringBuilder2.Append(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
				stringBuilder2.Append(" ");
			}
			string text2 = supportedChannel.ToString();
			stringBuilder2.Append(text2.Substring(text2.LastIndexOf('.') + 1));
			if (IsOneWay(supportedChannel))
			{
				flag7 = true;
			}
			if (IsRequestReply(supportedChannel))
			{
				flag8 = true;
			}
			if (IsDuplex(supportedChannel))
			{
				flag9 = true;
			}
			if (IsSessionful(supportedChannel))
			{
				flag10 = true;
			}
			else
			{
				flag11 = true;
			}
		}
		bool flag13 = flag8 || flag9;
		if (!flag12)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.BindingDoesnTSupportAnyChannelTypes1, bindingName));
		}
		if (flag5 && !flag10)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.BindingDoesnTSupportSessionButContractRequires1, bindingName));
		}
		if (flag6 && !flag11)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.BindingDoesntSupportDatagramButContractRequires, bindingName));
		}
		if (flag3 && !flag9)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.BindingDoesnTSupportDuplexButContractRequires1, bindingName));
		}
		if (flag2 && !flag8)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.BindingDoesnTSupportRequestReplyButContract1, bindingName));
		}
		if (flag && !flag7)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.BindingDoesnTSupportOneWayButContractRequires1, bindingName));
		}
		if (flag4 && !flag13)
		{
			return new InvalidOperationException(System.SR.Format(System.SR.BindingDoesnTSupportTwoWayButContractRequires1, bindingName));
		}
		contractChannelTypesString = stringBuilder.ToString();
		bindingChannelTypesString = stringBuilder2.ToString();
		return null;
	}
}
