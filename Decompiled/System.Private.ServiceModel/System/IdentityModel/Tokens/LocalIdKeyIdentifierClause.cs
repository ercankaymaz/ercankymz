using System.Globalization;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public class LocalIdKeyIdentifierClause : SecurityKeyIdentifierClause
{
	private readonly Type[] _ownerTypes;

	public string LocalId { get; }

	public Type OwnerType
	{
		get
		{
			if (_ownerTypes != null && _ownerTypes.Length != 0)
			{
				return _ownerTypes[0];
			}
			return null;
		}
	}

	public LocalIdKeyIdentifierClause(string localId)
		: this(localId, (Type[])null)
	{
	}

	public LocalIdKeyIdentifierClause(string localId, Type ownerType)
		: this(localId, (ownerType == null) ? null : new Type[1] { ownerType })
	{
	}

	public LocalIdKeyIdentifierClause(string localId, byte[] derivationNonce, int derivationLength, Type ownerType)
		: this(null, derivationNonce, derivationLength, (ownerType == null) ? null : new Type[1] { ownerType })
	{
	}

	internal LocalIdKeyIdentifierClause(string localId, Type[] ownerTypes)
		: this(localId, null, 0, ownerTypes)
	{
	}

	internal LocalIdKeyIdentifierClause(string localId, byte[] derivationNonce, int derivationLength, Type[] ownerTypes)
		: base(null, derivationNonce, derivationLength)
	{
		if (localId == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("localId");
		}
		if (localId == string.Empty)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.LocalIdCannotBeEmpty);
		}
		LocalId = localId;
		_ownerTypes = ownerTypes;
	}

	public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		LocalIdKeyIdentifierClause localIdKeyIdentifierClause = keyIdentifierClause as LocalIdKeyIdentifierClause;
		if (this != localIdKeyIdentifierClause)
		{
			return localIdKeyIdentifierClause?.Matches(LocalId, OwnerType) ?? false;
		}
		return true;
	}

	public bool Matches(string localId, Type ownerType)
	{
		if (string.IsNullOrEmpty(localId))
		{
			return false;
		}
		if (LocalId != localId)
		{
			return false;
		}
		if (_ownerTypes == null || ownerType == null)
		{
			return true;
		}
		for (int i = 0; i < _ownerTypes.Length; i++)
		{
			if (_ownerTypes[i] == null || _ownerTypes[i] == ownerType)
			{
				return true;
			}
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "LocalIdKeyIdentifierClause(LocalId = '{0}', Owner = '{1}')", LocalId, OwnerType);
	}
}
