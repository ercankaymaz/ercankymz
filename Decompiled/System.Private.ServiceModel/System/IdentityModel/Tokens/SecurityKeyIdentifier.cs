using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public class SecurityKeyIdentifier : IEnumerable<SecurityKeyIdentifierClause>, IEnumerable
{
	private const int InitialSize = 2;

	private readonly List<SecurityKeyIdentifierClause> _clauses;

	public SecurityKeyIdentifierClause this[int index] => _clauses[index];

	public bool CanCreateKey
	{
		get
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i].CanCreateKey)
				{
					return true;
				}
			}
			return false;
		}
	}

	public int Count => _clauses.Count;

	public bool IsReadOnly { get; private set; }

	public SecurityKeyIdentifier()
	{
		_clauses = new List<SecurityKeyIdentifierClause>(2);
	}

	public SecurityKeyIdentifier(params SecurityKeyIdentifierClause[] clauses)
	{
		if (clauses == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("clauses");
		}
		_clauses = new List<SecurityKeyIdentifierClause>(clauses.Length);
		for (int i = 0; i < clauses.Length; i++)
		{
			Add(clauses[i]);
		}
	}

	public void Add(SecurityKeyIdentifierClause clause)
	{
		if (IsReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
		}
		if (clause == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("clause"));
		}
		_clauses.Add(clause);
	}

	public SecurityKey CreateKey()
	{
		for (int i = 0; i < Count; i++)
		{
			if (this[i].CanCreateKey)
			{
				return this[i].CreateKey();
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.KeyIdentifierCannotCreateKey));
	}

	public TClause Find<TClause>() where TClause : SecurityKeyIdentifierClause
	{
		if (!TryFind<TClause>(out var clause))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.NoKeyIdentifierClauseFound, typeof(TClause)), "TClause"));
		}
		return clause;
	}

	public IEnumerator<SecurityKeyIdentifierClause> GetEnumerator()
	{
		return _clauses.GetEnumerator();
	}

	public void MakeReadOnly()
	{
		IsReadOnly = true;
	}

	public override string ToString()
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		stringWriter.WriteLine("SecurityKeyIdentifier");
		stringWriter.WriteLine("    (");
		stringWriter.WriteLine("    IsReadOnly = {0},", IsReadOnly);
		stringWriter.WriteLine("    Count = {0}{1}", Count, (Count > 0) ? "," : "");
		for (int i = 0; i < Count; i++)
		{
			stringWriter.WriteLine("    Clause[{0}] = {1}{2}", i, this[i], (i < Count - 1) ? "," : "");
		}
		stringWriter.WriteLine("    )");
		return stringWriter.ToString();
	}

	public bool TryFind<TClause>(out TClause clause) where TClause : SecurityKeyIdentifierClause
	{
		for (int i = 0; i < _clauses.Count; i++)
		{
			if (_clauses[i] is TClause val)
			{
				clause = val;
				return true;
			}
		}
		clause = null;
		return false;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
