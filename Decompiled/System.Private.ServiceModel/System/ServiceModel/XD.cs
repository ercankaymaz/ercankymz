namespace System.ServiceModel;

internal static class XD
{
	private static ActivityIdFlowDictionary s_activityIdFlowDictionary;

	private static AddressingDictionary s_addressingDictionary;

	private static Addressing10Dictionary s_addressing10Dictionary;

	private static Addressing200408Dictionary s_addressing200408Dictionary;

	private static AddressingNoneDictionary s_addressingNoneDictionary;

	private static DotNetSecurityDictionary s_dotNetSecurityDictionary;

	private static MessageDictionary s_messageDictionary;

	private static Message11Dictionary s_message11Dictionary;

	private static Message12Dictionary s_message12Dictionary;

	private static SecureConversationFeb2005Dictionary s_secureConversationFeb2005Dictionary;

	private static SecurityAlgorithmDictionary s_securityAlgorithmDictionary;

	private static SecurityJan2004Dictionary s_securityJan2004Dictionary;

	private static SecurityXXX2005Dictionary s_securityXXX2005Dictionary;

	private static TrustFeb2005Dictionary s_trustFeb2005Dictionary;

	private static UtilityDictionary s_utilityDictionary;

	private static WsrmFeb2005Dictionary s_wsrmFeb2005Dictionary;

	private static XmlSignatureDictionary s_xmlSignatureDictionary;

	public static ServiceModelDictionary Dictionary => ServiceModelDictionary.CurrentVersion;

	public static ActivityIdFlowDictionary ActivityIdFlowDictionary
	{
		get
		{
			if (s_activityIdFlowDictionary == null)
			{
				s_activityIdFlowDictionary = new ActivityIdFlowDictionary(Dictionary);
			}
			return s_activityIdFlowDictionary;
		}
	}

	public static AddressingDictionary AddressingDictionary
	{
		get
		{
			if (s_addressingDictionary == null)
			{
				s_addressingDictionary = new AddressingDictionary(Dictionary);
			}
			return s_addressingDictionary;
		}
	}

	public static Addressing10Dictionary Addressing10Dictionary
	{
		get
		{
			if (s_addressing10Dictionary == null)
			{
				s_addressing10Dictionary = new Addressing10Dictionary(Dictionary);
			}
			return s_addressing10Dictionary;
		}
	}

	public static Addressing200408Dictionary Addressing200408Dictionary
	{
		get
		{
			if (s_addressing200408Dictionary == null)
			{
				s_addressing200408Dictionary = new Addressing200408Dictionary(Dictionary);
			}
			return s_addressing200408Dictionary;
		}
	}

	public static AddressingNoneDictionary AddressingNoneDictionary
	{
		get
		{
			if (s_addressingNoneDictionary == null)
			{
				s_addressingNoneDictionary = new AddressingNoneDictionary(Dictionary);
			}
			return s_addressingNoneDictionary;
		}
	}

	public static DotNetSecurityDictionary DotNetSecurityDictionary
	{
		get
		{
			if (s_dotNetSecurityDictionary == null)
			{
				s_dotNetSecurityDictionary = new DotNetSecurityDictionary(Dictionary);
			}
			return s_dotNetSecurityDictionary;
		}
	}

	public static MessageDictionary MessageDictionary
	{
		get
		{
			if (s_messageDictionary == null)
			{
				s_messageDictionary = new MessageDictionary(Dictionary);
			}
			return s_messageDictionary;
		}
	}

	public static Message11Dictionary Message11Dictionary
	{
		get
		{
			if (s_message11Dictionary == null)
			{
				s_message11Dictionary = new Message11Dictionary(Dictionary);
			}
			return s_message11Dictionary;
		}
	}

	public static Message12Dictionary Message12Dictionary
	{
		get
		{
			if (s_message12Dictionary == null)
			{
				s_message12Dictionary = new Message12Dictionary(Dictionary);
			}
			return s_message12Dictionary;
		}
	}

	public static SecureConversationFeb2005Dictionary SecureConversationFeb2005Dictionary
	{
		get
		{
			if (s_secureConversationFeb2005Dictionary == null)
			{
				s_secureConversationFeb2005Dictionary = new SecureConversationFeb2005Dictionary(Dictionary);
			}
			return s_secureConversationFeb2005Dictionary;
		}
	}

	public static SecurityAlgorithmDictionary SecurityAlgorithmDictionary
	{
		get
		{
			if (s_securityAlgorithmDictionary == null)
			{
				s_securityAlgorithmDictionary = new SecurityAlgorithmDictionary(Dictionary);
			}
			return s_securityAlgorithmDictionary;
		}
	}

	public static SecurityJan2004Dictionary SecurityJan2004Dictionary
	{
		get
		{
			if (s_securityJan2004Dictionary == null)
			{
				s_securityJan2004Dictionary = new SecurityJan2004Dictionary(Dictionary);
			}
			return s_securityJan2004Dictionary;
		}
	}

	public static SecurityXXX2005Dictionary SecurityXXX2005Dictionary
	{
		get
		{
			if (s_securityXXX2005Dictionary == null)
			{
				s_securityXXX2005Dictionary = new SecurityXXX2005Dictionary(Dictionary);
			}
			return s_securityXXX2005Dictionary;
		}
	}

	public static TrustFeb2005Dictionary TrustFeb2005Dictionary
	{
		get
		{
			if (s_trustFeb2005Dictionary == null)
			{
				s_trustFeb2005Dictionary = new TrustFeb2005Dictionary(Dictionary);
			}
			return s_trustFeb2005Dictionary;
		}
	}

	public static UtilityDictionary UtilityDictionary
	{
		get
		{
			if (s_utilityDictionary == null)
			{
				s_utilityDictionary = new UtilityDictionary(Dictionary);
			}
			return s_utilityDictionary;
		}
	}

	public static WsrmFeb2005Dictionary WsrmFeb2005Dictionary
	{
		get
		{
			if (s_wsrmFeb2005Dictionary == null)
			{
				s_wsrmFeb2005Dictionary = new WsrmFeb2005Dictionary(Dictionary);
			}
			return s_wsrmFeb2005Dictionary;
		}
	}

	public static XmlSignatureDictionary XmlSignatureDictionary
	{
		get
		{
			if (s_xmlSignatureDictionary == null)
			{
				s_xmlSignatureDictionary = new XmlSignatureDictionary(Dictionary);
			}
			return s_xmlSignatureDictionary;
		}
	}
}
