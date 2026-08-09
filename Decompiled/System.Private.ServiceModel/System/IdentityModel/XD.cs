namespace System.IdentityModel;

internal static class XD
{
	private static ExclusiveC14NDictionary s_exclusiveC14NDictionary;

	private static SamlDictionary s_samlDictionary;

	private static SecureConversationDec2005Dictionary s_secureConversationDec2005Dictionary;

	private static SecureConversationFeb2005Dictionary s_secureConversationFeb2005Dictionary;

	private static SecurityAlgorithmDictionary s_securityAlgorithmDictionary;

	private static SecurityAlgorithmDec2005Dictionary s_securityAlgorithmDec2005Dictionary;

	private static SecurityJan2004Dictionary s_securityJan2004Dictionary;

	private static SecurityXXX2005Dictionary s_securityXXX2005Dictionary;

	private static TrustDec2005Dictionary s_trustDec2005Dictionary;

	private static TrustFeb2005Dictionary s_trustFeb2005Dictionary;

	private static UtilityDictionary s_utilityDictionary;

	private static XmlEncryptionDictionary s_xmlEncryptionDictionary;

	private static XmlSignatureDictionary s_xmlSignatureDictionary;

	public static IdentityModelDictionary Dictionary => IdentityModelDictionary.CurrentVersion;

	public static ExclusiveC14NDictionary ExclusiveC14NDictionary
	{
		get
		{
			if (s_exclusiveC14NDictionary == null)
			{
				s_exclusiveC14NDictionary = new ExclusiveC14NDictionary(Dictionary);
			}
			return s_exclusiveC14NDictionary;
		}
	}

	public static SamlDictionary SamlDictionary
	{
		get
		{
			if (s_samlDictionary == null)
			{
				s_samlDictionary = new SamlDictionary(Dictionary);
			}
			return s_samlDictionary;
		}
	}

	public static SecureConversationDec2005Dictionary SecureConversationDec2005Dictionary
	{
		get
		{
			if (s_secureConversationDec2005Dictionary == null)
			{
				s_secureConversationDec2005Dictionary = new SecureConversationDec2005Dictionary(Dictionary);
			}
			return s_secureConversationDec2005Dictionary;
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

	public static SecurityAlgorithmDec2005Dictionary SecurityAlgorithmDec2005Dictionary
	{
		get
		{
			if (s_securityAlgorithmDec2005Dictionary == null)
			{
				s_securityAlgorithmDec2005Dictionary = new SecurityAlgorithmDec2005Dictionary(Dictionary);
			}
			return s_securityAlgorithmDec2005Dictionary;
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

	public static TrustDec2005Dictionary TrustDec2005Dictionary
	{
		get
		{
			if (s_trustDec2005Dictionary == null)
			{
				s_trustDec2005Dictionary = new TrustDec2005Dictionary(Dictionary);
			}
			return s_trustDec2005Dictionary;
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

	public static XmlEncryptionDictionary XmlEncryptionDictionary
	{
		get
		{
			if (s_xmlEncryptionDictionary == null)
			{
				s_xmlEncryptionDictionary = new XmlEncryptionDictionary(Dictionary);
			}
			return s_xmlEncryptionDictionary;
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
