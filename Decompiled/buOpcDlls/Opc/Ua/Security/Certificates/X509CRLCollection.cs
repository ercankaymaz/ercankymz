using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Security.Certificates;

[CollectionDataContract(Name = "ListOfX509CRL", ItemName = "X509CRL")]
[ComVisible(true)]
public class X509CRLCollection : List<X509CRL>
{
	public new X509CRL this[int index]
	{
		get
		{
			return base[index];
		}
		set
		{
			base[index] = value ?? throw new ArgumentNullException("value");
		}
	}

	public X509CRLCollection()
	{
	}

	public X509CRLCollection(X509CRL crl)
	{
		Add(crl);
	}

	public X509CRLCollection(X509CRLCollection crls)
	{
		AddRange(crls);
	}

	public X509CRLCollection(X509CRL[] crls)
	{
		AddRange(crls);
	}

	public static X509CRLCollection ToX509CRLCollection(X509CRL[] crls)
	{
		if (crls != null)
		{
			return new X509CRLCollection(crls);
		}
		return new X509CRLCollection();
	}

	public static implicit operator X509CRLCollection(X509CRL[] crls)
	{
		return ToX509CRLCollection(crls);
	}
}
