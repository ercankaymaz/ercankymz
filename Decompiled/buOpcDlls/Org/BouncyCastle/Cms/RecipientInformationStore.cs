using System.Collections.Generic;

namespace Org.BouncyCastle.Cms;

public class RecipientInformationStore
{
	private readonly IList<RecipientInformation> m_all;

	private readonly IDictionary<RecipientID, IList<RecipientInformation>> m_table = new Dictionary<RecipientID, IList<RecipientInformation>>();

	public RecipientInformation this[RecipientID selector] => GetFirstRecipient(selector);

	public int Count => m_all.Count;

	public RecipientInformationStore(IEnumerable<RecipientInformation> recipientInfos)
	{
		foreach (RecipientInformation recipientInfo in recipientInfos)
		{
			RecipientID recipientID = recipientInfo.RecipientID;
			if (!m_table.TryGetValue(recipientID, out var value))
			{
				value = (m_table[recipientID] = new List<RecipientInformation>(1));
			}
			value.Add(recipientInfo);
		}
		m_all = new List<RecipientInformation>(recipientInfos);
	}

	public RecipientInformation GetFirstRecipient(RecipientID selector)
	{
		if (!m_table.TryGetValue(selector, out var value))
		{
			return null;
		}
		return value[0];
	}

	public IList<RecipientInformation> GetRecipients()
	{
		return new List<RecipientInformation>(m_all);
	}

	public IList<RecipientInformation> GetRecipients(RecipientID selector)
	{
		if (!m_table.TryGetValue(selector, out var value))
		{
			return new List<RecipientInformation>(0);
		}
		return new List<RecipientInformation>(value);
	}
}
