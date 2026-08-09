using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSignedSoftwareCertificate", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SignedSoftwareCertificate")]
[ComVisible(true)]
public class SignedSoftwareCertificateCollection : List<SignedSoftwareCertificate>, ICloneable
{
	public SignedSoftwareCertificateCollection()
	{
	}

	public SignedSoftwareCertificateCollection(int capacity)
		: base(capacity)
	{
	}

	public SignedSoftwareCertificateCollection(IEnumerable<SignedSoftwareCertificate> collection)
		: base(collection)
	{
	}

	public static implicit operator SignedSoftwareCertificateCollection(SignedSoftwareCertificate[] values)
	{
		if (values != null)
		{
			return new SignedSoftwareCertificateCollection(values);
		}
		return new SignedSoftwareCertificateCollection();
	}

	public static explicit operator SignedSoftwareCertificate[](SignedSoftwareCertificateCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SignedSoftwareCertificateCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SignedSoftwareCertificateCollection signedSoftwareCertificateCollection = new SignedSoftwareCertificateCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			signedSoftwareCertificateCollection.Add((SignedSoftwareCertificate)Utils.Clone(base[i]));
		}
		return signedSoftwareCertificateCollection;
	}
}
