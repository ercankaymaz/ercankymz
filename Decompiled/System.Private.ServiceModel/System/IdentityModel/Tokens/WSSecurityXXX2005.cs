using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel.Tokens;

internal class WSSecurityXXX2005 : WSSecurityJan2004
{
	private class SecurityTokenReferenceXXX2005ClauseEntry : SecurityTokenReferenceJan2004ClauseEntry
	{
		public SecurityTokenReferenceXXX2005ClauseEntry(bool emitBspRequiredAttributes, IList<SecurityTokenSerializer.StrEntry> strEntries)
			: base(emitBspRequiredAttributes, strEntries)
		{
		}

		protected override string ReadTokenType(XmlDictionaryReader reader)
		{
			return reader.GetAttribute(XD.SecurityXXX2005Dictionary.TokenTypeAttribute, XD.SecurityXXX2005Dictionary.Namespace);
		}

		public override void WriteKeyIdentifierClauseCore(XmlDictionaryWriter writer, SecurityKeyIdentifierClause keyIdentifierClause)
		{
			for (int i = 0; i < base.StrEntries.Count; i++)
			{
				if (base.StrEntries[i].SupportsCore(keyIdentifierClause))
				{
					writer.WriteStartElement(XD.SecurityJan2004Dictionary.Prefix.Value, XD.SecurityJan2004Dictionary.SecurityTokenReference, XD.SecurityJan2004Dictionary.Namespace);
					string tokenTypeUri = GetTokenTypeUri(base.StrEntries[i], keyIdentifierClause);
					if (tokenTypeUri != null)
					{
						writer.WriteAttributeString(XD.SecurityXXX2005Dictionary.Prefix.Value, XD.SecurityXXX2005Dictionary.TokenTypeAttribute, XD.SecurityXXX2005Dictionary.Namespace, tokenTypeUri);
					}
					base.StrEntries[i].WriteContent(writer, keyIdentifierClause);
					writer.WriteEndElement();
					return;
				}
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.StandardsManagerCannotWriteObject, keyIdentifierClause.GetType())));
		}

		private string GetTokenTypeUri(SecurityTokenSerializer.StrEntry str, SecurityKeyIdentifierClause keyIdentifierClause)
		{
			if (EmitTokenType(str))
			{
				string text;
				if (str is LocalReferenceStrEntry)
				{
					text = (str as LocalReferenceStrEntry).GetLocalTokenTypeUri(keyIdentifierClause);
					switch (text)
					{
					default:
						text = null;
						break;
					case "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV2.0":
					case "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1":
					case "http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKey":
					case "http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ":
						break;
					}
				}
				else
				{
					text = str.GetTokenTypeUri();
				}
				return text;
			}
			return null;
		}

		private bool EmitTokenType(SecurityTokenSerializer.StrEntry str)
		{
			return false;
		}
	}

	private class X509ThumbprintStrEntry : KeyIdentifierStrEntry
	{
		protected override Type ClauseType => typeof(X509ThumbprintKeyIdentifierClause);

		public override Type TokenType => typeof(X509SecurityToken);

		protected override string ValueTypeUri => "http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#ThumbprintSHA1";

		public X509ThumbprintStrEntry(bool emitBspRequiredAttributes)
			: base(emitBspRequiredAttributes)
		{
		}

		protected override SecurityKeyIdentifierClause CreateClause(byte[] bytes, byte[] derivationNonce, int derivationLength)
		{
			return new X509ThumbprintKeyIdentifierClause(bytes);
		}

		public override string GetTokenTypeUri()
		{
			return XD.SecurityXXX2005Dictionary.ThumbprintSha1ValueType.Value;
		}
	}

	public WSSecurityXXX2005(KeyInfoSerializer securityTokenSerializer)
		: base(securityTokenSerializer)
	{
	}

	public override void PopulateStrEntries(IList<SecurityTokenSerializer.StrEntry> strEntries)
	{
		PopulateJan2004StrEntries(strEntries);
		strEntries.Add(new X509ThumbprintStrEntry(base.SecurityTokenSerializer.EmitBspRequiredAttributes));
	}

	public override void PopulateTokenEntries(IList<SecurityTokenSerializer.TokenEntry> tokenEntryList)
	{
		PopulateJan2004TokenEntries(tokenEntryList);
	}

	public override void PopulateKeyIdentifierClauseEntries(IList<SecurityTokenSerializer.KeyIdentifierClauseEntry> clauseEntries)
	{
		List<SecurityTokenSerializer.StrEntry> strEntries = new List<SecurityTokenSerializer.StrEntry>();
		base.SecurityTokenSerializer.PopulateStrEntries(strEntries);
		SecurityTokenReferenceXXX2005ClauseEntry item = new SecurityTokenReferenceXXX2005ClauseEntry(base.SecurityTokenSerializer.EmitBspRequiredAttributes, strEntries);
		clauseEntries.Add(item);
	}
}
