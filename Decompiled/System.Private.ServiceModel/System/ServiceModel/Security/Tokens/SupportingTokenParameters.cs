using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace System.ServiceModel.Security.Tokens;

public class SupportingTokenParameters
{
	private Collection<SecurityTokenParameters> _signedEndorsing = new Collection<SecurityTokenParameters>();

	public Collection<SecurityTokenParameters> Endorsing { get; } = new Collection<SecurityTokenParameters>();

	public Collection<SecurityTokenParameters> SignedEndorsing => _signedEndorsing;

	public Collection<SecurityTokenParameters> Signed { get; } = new Collection<SecurityTokenParameters>();

	public Collection<SecurityTokenParameters> SignedEncrypted { get; } = new Collection<SecurityTokenParameters>();

	private SupportingTokenParameters(SupportingTokenParameters other)
	{
		if (other == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("other");
		}
		foreach (SecurityTokenParameters item in other.Signed)
		{
			Signed.Add(item.Clone());
		}
		foreach (SecurityTokenParameters item2 in other.SignedEncrypted)
		{
			SignedEncrypted.Add(item2.Clone());
		}
		foreach (SecurityTokenParameters item3 in other.Endorsing)
		{
			Endorsing.Add(item3.Clone());
		}
		foreach (SecurityTokenParameters item4 in other._signedEndorsing)
		{
			_signedEndorsing.Add(item4.Clone());
		}
	}

	public SupportingTokenParameters()
	{
	}

	public void SetKeyDerivation(bool requireDerivedKeys)
	{
		foreach (SecurityTokenParameters item in Endorsing)
		{
			if (item.HasAsymmetricKey)
			{
				item.RequireDerivedKeys = false;
			}
			else
			{
				item.RequireDerivedKeys = requireDerivedKeys;
			}
		}
		foreach (SecurityTokenParameters item2 in _signedEndorsing)
		{
			if (item2.HasAsymmetricKey)
			{
				item2.RequireDerivedKeys = false;
			}
			else
			{
				item2.RequireDerivedKeys = requireDerivedKeys;
			}
		}
	}

	internal bool IsSetKeyDerivation(bool requireDerivedKeys)
	{
		foreach (SecurityTokenParameters item in Endorsing)
		{
			if (item.RequireDerivedKeys != requireDerivedKeys)
			{
				return false;
			}
		}
		foreach (SecurityTokenParameters item2 in _signedEndorsing)
		{
			if (item2.RequireDerivedKeys != requireDerivedKeys)
			{
				return false;
			}
		}
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Endorsing.Count == 0)
		{
			stringBuilder.AppendLine("No endorsing tokens.");
		}
		else
		{
			for (int i = 0; i < Endorsing.Count; i++)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "Endorsing[{0}]", i.ToString(CultureInfo.InvariantCulture)));
				stringBuilder.AppendLine("  " + Endorsing[i].ToString().Trim().Replace("\n", "\n  "));
			}
		}
		if (Signed.Count == 0)
		{
			stringBuilder.AppendLine("No signed tokens.");
		}
		else
		{
			for (int i = 0; i < Signed.Count; i++)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "Signed[{0}]", i.ToString(CultureInfo.InvariantCulture)));
				stringBuilder.AppendLine("  " + Signed[i].ToString().Trim().Replace("\n", "\n  "));
			}
		}
		if (SignedEncrypted.Count == 0)
		{
			stringBuilder.AppendLine("No signed encrypted tokens.");
		}
		else
		{
			for (int i = 0; i < SignedEncrypted.Count; i++)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "SignedEncrypted[{0}]", i.ToString(CultureInfo.InvariantCulture)));
				stringBuilder.AppendLine("  " + SignedEncrypted[i].ToString().Trim().Replace("\n", "\n  "));
			}
		}
		if (_signedEndorsing.Count == 0)
		{
			stringBuilder.AppendLine("No signed endorsing tokens.");
		}
		else
		{
			for (int i = 0; i < _signedEndorsing.Count; i++)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "SignedEndorsing[{0}]", i.ToString(CultureInfo.InvariantCulture)));
				stringBuilder.AppendLine("  " + _signedEndorsing[i].ToString().Trim().Replace("\n", "\n  "));
			}
		}
		return stringBuilder.ToString().Trim();
	}

	public SupportingTokenParameters Clone()
	{
		SupportingTokenParameters supportingTokenParameters = CloneCore();
		if (supportingTokenParameters != null)
		{
			_ = supportingTokenParameters.GetType() != GetType();
		}
		return supportingTokenParameters;
	}

	protected virtual SupportingTokenParameters CloneCore()
	{
		return new SupportingTokenParameters(this);
	}

	internal bool IsEmpty()
	{
		if (Signed.Count == 0 && SignedEncrypted.Count == 0 && Endorsing.Count == 0)
		{
			return _signedEndorsing.Count == 0;
		}
		return false;
	}
}
