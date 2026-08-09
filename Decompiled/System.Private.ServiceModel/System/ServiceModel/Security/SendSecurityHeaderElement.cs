using System.IdentityModel;

namespace System.ServiceModel.Security;

internal class SendSecurityHeaderElement
{
	public string Id { get; private set; }

	public ISecurityElement Item { get; private set; }

	public bool MarkedForEncryption { get; set; }

	public SendSecurityHeaderElement(string id, ISecurityElement item)
	{
		Id = id;
		Item = item;
		MarkedForEncryption = false;
	}

	public bool IsSameItem(ISecurityElement item)
	{
		if (Item != item)
		{
			return Item.Equals(item);
		}
		return true;
	}

	public void Replace(string id, ISecurityElement item)
	{
		Item = item;
		Id = id;
	}
}
