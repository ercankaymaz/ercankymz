namespace Org.BouncyCastle.Asn1.Cmp;

public static class CmpObjectIdentifiers
{
	public static readonly DerObjectIdentifier passwordBasedMac = new DerObjectIdentifier("1.2.840.113533.7.66.13");

	public static readonly DerObjectIdentifier dhBasedMac = new DerObjectIdentifier("1.2.840.113533.7.66.30");

	public static readonly DerObjectIdentifier it_caProtEncCert = new DerObjectIdentifier("1.3.6.1.5.5.7.4.1");

	public static readonly DerObjectIdentifier it_signKeyPairTypes = new DerObjectIdentifier("1.3.6.1.5.5.7.4.2");

	public static readonly DerObjectIdentifier it_encKeyPairTypes = new DerObjectIdentifier("1.3.6.1.5.5.7.4.3");

	public static readonly DerObjectIdentifier it_preferredSymAlg = new DerObjectIdentifier("1.3.6.1.5.5.7.4.4");

	public static readonly DerObjectIdentifier it_caKeyUpdateInfo = new DerObjectIdentifier("1.3.6.1.5.5.7.4.5");

	public static readonly DerObjectIdentifier it_currentCRL = new DerObjectIdentifier("1.3.6.1.5.5.7.4.6");

	public static readonly DerObjectIdentifier it_unsupportedOIDs = new DerObjectIdentifier("1.3.6.1.5.5.7.4.7");

	public static readonly DerObjectIdentifier it_keyPairParamReq = new DerObjectIdentifier("1.3.6.1.5.5.7.4.10");

	public static readonly DerObjectIdentifier it_keyPairParamRep = new DerObjectIdentifier("1.3.6.1.5.5.7.4.11");

	public static readonly DerObjectIdentifier it_revPassphrase = new DerObjectIdentifier("1.3.6.1.5.5.7.4.12");

	public static readonly DerObjectIdentifier it_implicitConfirm = new DerObjectIdentifier("1.3.6.1.5.5.7.4.13");

	public static readonly DerObjectIdentifier it_confirmWaitTime = new DerObjectIdentifier("1.3.6.1.5.5.7.4.14");

	public static readonly DerObjectIdentifier it_origPKIMessage = new DerObjectIdentifier("1.3.6.1.5.5.7.4.15");

	public static readonly DerObjectIdentifier it_suppLangTags = new DerObjectIdentifier("1.3.6.1.5.5.7.4.16");

	public static readonly DerObjectIdentifier id_it_caCerts = new DerObjectIdentifier("1.3.6.1.5.5.7.4.17");

	public static readonly DerObjectIdentifier id_it_rootCaKeyUpdate = new DerObjectIdentifier("1.3.6.1.5.5.7.4.18");

	public static readonly DerObjectIdentifier id_it_certReqTemplate = new DerObjectIdentifier("1.3.6.1.5.5.7.4.19");

	public static readonly DerObjectIdentifier id_it_rootCaCert = new DerObjectIdentifier("1.3.6.1.5.5.7.4.20");

	public static readonly DerObjectIdentifier id_it_certProfile = new DerObjectIdentifier("1.3.6.1.5.5.7.4.21");

	public static readonly DerObjectIdentifier id_it_crlStatusList = new DerObjectIdentifier("1.3.6.1.5.5.7.4.22");

	public static readonly DerObjectIdentifier id_it_crls = new DerObjectIdentifier("1.3.6.1.5.5.7.4.23");

	public static readonly DerObjectIdentifier id_pkip = new DerObjectIdentifier("1.3.6.1.5.5.7.5");

	public static readonly DerObjectIdentifier id_regCtrl = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1");

	public static readonly DerObjectIdentifier id_regInfo = new DerObjectIdentifier("1.3.6.1.5.5.7.5.2");

	public static readonly DerObjectIdentifier regCtrl_regToken = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1.1");

	public static readonly DerObjectIdentifier regCtrl_authenticator = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1.2");

	public static readonly DerObjectIdentifier regCtrl_pkiPublicationInfo = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1.3");

	public static readonly DerObjectIdentifier regCtrl_pkiArchiveOptions = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1.4");

	public static readonly DerObjectIdentifier regCtrl_oldCertID = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1.5");

	public static readonly DerObjectIdentifier regCtrl_protocolEncrKey = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1.6");

	public static readonly DerObjectIdentifier regCtrl_altCertTemplate = new DerObjectIdentifier("1.3.6.1.5.5.7.5.1.7");

	public static readonly DerObjectIdentifier regInfo_utf8Pairs = new DerObjectIdentifier("1.3.6.1.5.5.7.5.2.1");

	public static readonly DerObjectIdentifier regInfo_certReq = new DerObjectIdentifier("1.3.6.1.5.5.7.5.2.2");

	public static readonly DerObjectIdentifier ct_encKeyWithID = new DerObjectIdentifier("1.2.840.113549.1.9.16.1.21");

	public static readonly DerObjectIdentifier id_regCtrl_algId = id_pkip.Branch("1.11");

	public static readonly DerObjectIdentifier id_regCtrl_rsaKeyLen = id_pkip.Branch("1.12");
}
