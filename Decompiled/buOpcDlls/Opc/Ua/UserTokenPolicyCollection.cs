using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUserTokenPolicy", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UserTokenPolicy")]
[ComVisible(true)]
public class UserTokenPolicyCollection : List<UserTokenPolicy>, ICloneable
{
	public UserTokenPolicyCollection()
	{
	}

	public UserTokenPolicyCollection(int capacity)
		: base(capacity)
	{
	}

	public UserTokenPolicyCollection(IEnumerable<UserTokenPolicy> collection)
		: base(collection)
	{
	}

	public static implicit operator UserTokenPolicyCollection(UserTokenPolicy[] values)
	{
		if (values != null)
		{
			return new UserTokenPolicyCollection(values);
		}
		return new UserTokenPolicyCollection();
	}

	public static explicit operator UserTokenPolicy[](UserTokenPolicyCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UserTokenPolicyCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UserTokenPolicyCollection userTokenPolicyCollection = new UserTokenPolicyCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			userTokenPolicyCollection.Add((UserTokenPolicy)Utils.Clone(base[i]));
		}
		return userTokenPolicyCollection;
	}
}
