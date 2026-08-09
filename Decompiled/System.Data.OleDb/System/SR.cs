using System.Resources;
using FxResources.System.Data.OleDb;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = GetUsingResourceKeysSwitchValue();

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(FxResources.System.Data.OleDb.SR)));

	internal static string ADP_CollectionIndexInt32 => GetResourceString("ADP_CollectionIndexInt32");

	internal static string ADP_CollectionIndexString => GetResourceString("ADP_CollectionIndexString");

	internal static string ADP_CollectionInvalidType => GetResourceString("ADP_CollectionInvalidType");

	internal static string ADP_CollectionIsNotParent => GetResourceString("ADP_CollectionIsNotParent");

	internal static string ADP_CollectionNullValue => GetResourceString("ADP_CollectionNullValue");

	internal static string ADP_CollectionRemoveInvalidObject => GetResourceString("ADP_CollectionRemoveInvalidObject");

	internal static string ADP_ConnectionStateMsg_Closed => GetResourceString("ADP_ConnectionStateMsg_Closed");

	internal static string ADP_ConnectionStateMsg_Connecting => GetResourceString("ADP_ConnectionStateMsg_Connecting");

	internal static string ADP_ConnectionStateMsg_Open => GetResourceString("ADP_ConnectionStateMsg_Open");

	internal static string ADP_ConnectionStateMsg_OpenExecuting => GetResourceString("ADP_ConnectionStateMsg_OpenExecuting");

	internal static string ADP_ConnectionStateMsg_OpenFetching => GetResourceString("ADP_ConnectionStateMsg_OpenFetching");

	internal static string ADP_ConnectionStateMsg => GetResourceString("ADP_ConnectionStateMsg");

	internal static string ADP_ConnectionStringSyntax => GetResourceString("ADP_ConnectionStringSyntax");

	internal static string ADP_DataReaderClosed => GetResourceString("ADP_DataReaderClosed");

	internal static string ADP_InvalidEnumerationValue => GetResourceString("ADP_InvalidEnumerationValue");

	internal static string SqlConvert_ConvertFailed => GetResourceString("SqlConvert_ConvertFailed");

	internal static string ADP_InvalidConnectionOptionValue => GetResourceString("ADP_InvalidConnectionOptionValue");

	internal static string ADP_KeywordNotSupported => GetResourceString("ADP_KeywordNotSupported");

	internal static string ADP_InternalProviderError => GetResourceString("ADP_InternalProviderError");

	internal static string ADP_InvalidMultipartName => GetResourceString("ADP_InvalidMultipartName");

	internal static string ADP_InvalidMultipartNameQuoteUsage => GetResourceString("ADP_InvalidMultipartNameQuoteUsage");

	internal static string ADP_InvalidMultipartNameToManyParts => GetResourceString("ADP_InvalidMultipartNameToManyParts");

	internal static string OLEDB_OLEDBCommandText => GetResourceString("OLEDB_OLEDBCommandText");

	internal static string ADP_InvalidSourceBufferIndex => GetResourceString("ADP_InvalidSourceBufferIndex");

	internal static string ADP_InvalidDestinationBufferIndex => GetResourceString("ADP_InvalidDestinationBufferIndex");

	internal static string OleDb_SchemaRowsetsNotSupported => GetResourceString("OleDb_SchemaRowsetsNotSupported");

	internal static string OleDb_NoErrorInformation2 => GetResourceString("OleDb_NoErrorInformation2");

	internal static string OleDb_NoErrorInformation => GetResourceString("OleDb_NoErrorInformation");

	internal static string OleDb_MDACNotAvailable => GetResourceString("OleDb_MDACNotAvailable");

	internal static string OleDb_MSDASQLNotSupported => GetResourceString("OleDb_MSDASQLNotSupported");

	internal static string OleDb_PossiblePromptNotUserInteractive => GetResourceString("OleDb_PossiblePromptNotUserInteractive");

	internal static string OleDb_ProviderUnavailable => GetResourceString("OleDb_ProviderUnavailable");

	internal static string OleDb_CommandTextNotSupported => GetResourceString("OleDb_CommandTextNotSupported");

	internal static string OleDb_TransactionsNotSupported => GetResourceString("OleDb_TransactionsNotSupported");

	internal static string OleDb_AsynchronousNotSupported => GetResourceString("OleDb_AsynchronousNotSupported");

	internal static string OleDb_NoProviderSpecified => GetResourceString("OleDb_NoProviderSpecified");

	internal static string OleDb_InvalidProviderSpecified => GetResourceString("OleDb_InvalidProviderSpecified");

	internal static string OleDb_InvalidRestrictionsDbInfoKeywords => GetResourceString("OleDb_InvalidRestrictionsDbInfoKeywords");

	internal static string OleDb_InvalidRestrictionsDbInfoLiteral => GetResourceString("OleDb_InvalidRestrictionsDbInfoLiteral");

	internal static string OleDb_InvalidRestrictionsSchemaGuids => GetResourceString("OleDb_InvalidRestrictionsSchemaGuids");

	internal static string OleDb_NotSupportedSchemaTable => GetResourceString("OleDb_NotSupportedSchemaTable");

	internal static string OleDb_CommandParameterBadAccessor => GetResourceString("OleDb_CommandParameterBadAccessor");

	internal static string OleDb_CommandParameterCantConvertValue => GetResourceString("OleDb_CommandParameterCantConvertValue");

	internal static string OleDb_CommandParameterSignMismatch => GetResourceString("OleDb_CommandParameterSignMismatch");

	internal static string OleDb_CommandParameterDataOverflow => GetResourceString("OleDb_CommandParameterDataOverflow");

	internal static string OleDb_CommandParameterUnavailable => GetResourceString("OleDb_CommandParameterUnavailable");

	internal static string OleDb_CommandParameterDefault => GetResourceString("OleDb_CommandParameterDefault");

	internal static string OleDb_CommandParameterError => GetResourceString("OleDb_CommandParameterError");

	internal static string OleDb_BadStatus_ParamAcc => GetResourceString("OleDb_BadStatus_ParamAcc");

	internal static string OleDb_UninitializedParameters => GetResourceString("OleDb_UninitializedParameters");

	internal static string OleDb_NoProviderSupportForParameters => GetResourceString("OleDb_NoProviderSupportForParameters");

	internal static string OleDb_NoProviderSupportForSProcResetParameters => GetResourceString("OleDb_NoProviderSupportForSProcResetParameters");

	internal static string OleDb_Fill_NotADODB => GetResourceString("OleDb_Fill_NotADODB");

	internal static string OleDb_Fill_EmptyRecordSet => GetResourceString("OleDb_Fill_EmptyRecordSet");

	internal static string OleDb_Fill_EmptyRecord => GetResourceString("OleDb_Fill_EmptyRecord");

	internal static string OleDb_ISourcesRowsetNotSupported => GetResourceString("OleDb_ISourcesRowsetNotSupported");

	internal static string OleDb_IDBInfoNotSupported => GetResourceString("OleDb_IDBInfoNotSupported");

	internal static string OleDb_PropertyNotSupported => GetResourceString("OleDb_PropertyNotSupported");

	internal static string OleDb_PropertyBadValue => GetResourceString("OleDb_PropertyBadValue");

	internal static string OleDb_PropertyBadOption => GetResourceString("OleDb_PropertyBadOption");

	internal static string OleDb_PropertyBadColumn => GetResourceString("OleDb_PropertyBadColumn");

	internal static string OleDb_PropertyNotAllSettable => GetResourceString("OleDb_PropertyNotAllSettable");

	internal static string OleDb_PropertyNotSettable => GetResourceString("OleDb_PropertyNotSettable");

	internal static string OleDb_PropertyNotSet => GetResourceString("OleDb_PropertyNotSet");

	internal static string OleDb_PropertyConflicting => GetResourceString("OleDb_PropertyConflicting");

	internal static string OleDb_PropertyNotAvailable => GetResourceString("OleDb_PropertyNotAvailable");

	internal static string OleDb_PropertyStatusUnknown => GetResourceString("OleDb_PropertyStatusUnknown");

	internal static string OleDb_BadAccessor => GetResourceString("OleDb_BadAccessor");

	internal static string OleDb_BadStatusRowAccessor => GetResourceString("OleDb_BadStatusRowAccessor");

	internal static string OleDb_CantConvertValue => GetResourceString("OleDb_CantConvertValue");

	internal static string OleDb_CantCreate => GetResourceString("OleDb_CantCreate");

	internal static string OleDb_DataOverflow => GetResourceString("OleDb_DataOverflow");

	internal static string OleDb_GVtUnknown => GetResourceString("OleDb_GVtUnknown");

	internal static string OleDb_SignMismatch => GetResourceString("OleDb_SignMismatch");

	internal static string OleDb_SVtUnknown => GetResourceString("OleDb_SVtUnknown");

	internal static string OleDb_Unavailable => GetResourceString("OleDb_Unavailable");

	internal static string OleDb_UnexpectedStatusValue => GetResourceString("OleDb_UnexpectedStatusValue");

	internal static string OleDb_ThreadApartmentState => GetResourceString("OleDb_ThreadApartmentState");

	internal static string OleDb_NoErrorMessage => GetResourceString("OleDb_NoErrorMessage");

	internal static string OleDb_FailedGetDescription => GetResourceString("OleDb_FailedGetDescription");

	internal static string OleDb_FailedGetSource => GetResourceString("OleDb_FailedGetSource");

	internal static string OleDb_DBBindingGetVector => GetResourceString("OleDb_DBBindingGetVector");

	internal static string SQL_InvalidDataLength => GetResourceString("SQL_InvalidDataLength");

	internal static string PlatformNotSupported_OleDb => GetResourceString("PlatformNotSupported_OleDb");

	internal static string PlatformNotSupported_GetIDispatchForObject => GetResourceString("PlatformNotSupported_GetIDispatchForObject");

	internal static string ADP_EmptyString => GetResourceString("ADP_EmptyString");

	internal static string ADP_UdlFileError => GetResourceString("ADP_UdlFileError");

	internal static string ADP_InvalidUDL => GetResourceString("ADP_InvalidUDL");

	internal static string ADP_InvalidDataDirectory => GetResourceString("ADP_InvalidDataDirectory");

	internal static string ADP_InvalidKey => GetResourceString("ADP_InvalidKey");

	internal static string ADP_InvalidValue => GetResourceString("ADP_InvalidValue");

	internal static string ADP_NoConnectionString => GetResourceString("ADP_NoConnectionString");

	internal static string OleDb_ConfigUnableToLoadXmlMetaDataFile => GetResourceString("OleDb_ConfigUnableToLoadXmlMetaDataFile");

	internal static string OleDb_ConfigWrongNumberOfValues => GetResourceString("OleDb_ConfigWrongNumberOfValues");

	internal static string ADP_PooledOpenTimeout => GetResourceString("ADP_PooledOpenTimeout");

	internal static string ADP_NonPooledOpenTimeout => GetResourceString("ADP_NonPooledOpenTimeout");

	internal static string ADP_TransactionConnectionMismatch => GetResourceString("ADP_TransactionConnectionMismatch");

	internal static string ADP_TransactionRequired => GetResourceString("ADP_TransactionRequired");

	internal static string ADP_CommandTextRequired => GetResourceString("ADP_CommandTextRequired");

	internal static string ADP_ConnectionRequired => GetResourceString("ADP_ConnectionRequired");

	internal static string ADP_OpenConnectionRequired => GetResourceString("ADP_OpenConnectionRequired");

	internal static string ADP_NoStoredProcedureExists => GetResourceString("ADP_NoStoredProcedureExists");

	internal static string ADP_OpenReaderExists => GetResourceString("ADP_OpenReaderExists");

	internal static string ADP_TransactionCompleted => GetResourceString("ADP_TransactionCompleted");

	internal static string ADP_NonSeqByteAccess => GetResourceString("ADP_NonSeqByteAccess");

	internal static string ADP_NumericToDecimalOverflow => GetResourceString("ADP_NumericToDecimalOverflow");

	internal static string ADP_NonSequentialColumnAccess => GetResourceString("ADP_NonSequentialColumnAccess");

	internal static string ADP_FillRequiresSourceTableName => GetResourceString("ADP_FillRequiresSourceTableName");

	internal static string ADP_InvalidCommandTimeout => GetResourceString("ADP_InvalidCommandTimeout");

	internal static string ADP_DeriveParametersNotSupported => GetResourceString("ADP_DeriveParametersNotSupported");

	internal static string ADP_UninitializedParameterSize => GetResourceString("ADP_UninitializedParameterSize");

	internal static string ADP_PrepareParameterType => GetResourceString("ADP_PrepareParameterType");

	internal static string ADP_PrepareParameterSize => GetResourceString("ADP_PrepareParameterSize");

	internal static string ADP_PrepareParameterScale => GetResourceString("ADP_PrepareParameterScale");

	internal static string ADP_ClosedConnectionError => GetResourceString("ADP_ClosedConnectionError");

	internal static string ADP_ConnectionAlreadyOpen => GetResourceString("ADP_ConnectionAlreadyOpen");

	internal static string ADP_TransactionPresent => GetResourceString("ADP_TransactionPresent");

	internal static string ADP_LocalTransactionPresent => GetResourceString("ADP_LocalTransactionPresent");

	internal static string ADP_OpenConnectionPropertySet => GetResourceString("ADP_OpenConnectionPropertySet");

	internal static string ADP_EmptyDatabaseName => GetResourceString("ADP_EmptyDatabaseName");

	internal static string ADP_InternalConnectionError => GetResourceString("ADP_InternalConnectionError");

	internal static string ADP_InvalidConnectTimeoutValue => GetResourceString("ADP_InvalidConnectTimeoutValue");

	internal static string ADP_DataReaderNoData => GetResourceString("ADP_DataReaderNoData");

	internal static string ADP_InvalidDataType => GetResourceString("ADP_InvalidDataType");

	internal static string ADP_DbTypeNotSupported => GetResourceString("ADP_DbTypeNotSupported");

	internal static string ADP_UnknownDataTypeCode => GetResourceString("ADP_UnknownDataTypeCode");

	internal static string ADP_InvalidOffsetValue => GetResourceString("ADP_InvalidOffsetValue");

	internal static string ADP_InvalidSizeValue => GetResourceString("ADP_InvalidSizeValue");

	internal static string ADP_ParameterConversionFailed => GetResourceString("ADP_ParameterConversionFailed");

	internal static string ADP_ParallelTransactionsNotSupported => GetResourceString("ADP_ParallelTransactionsNotSupported");

	internal static string ADP_TransactionZombied => GetResourceString("ADP_TransactionZombied");

	internal static string MDF_AmbiguousCollectionName => GetResourceString("MDF_AmbiguousCollectionName");

	internal static string MDF_CollectionNameISNotUnique => GetResourceString("MDF_CollectionNameISNotUnique");

	internal static string MDF_DataTableDoesNotExist => GetResourceString("MDF_DataTableDoesNotExist");

	internal static string MDF_IncorrectNumberOfDataSourceInformationRows => GetResourceString("MDF_IncorrectNumberOfDataSourceInformationRows");

	internal static string MDF_InvalidRestrictionValue => GetResourceString("MDF_InvalidRestrictionValue");

	internal static string MDF_InvalidXml => GetResourceString("MDF_InvalidXml");

	internal static string MDF_InvalidXmlMissingColumn => GetResourceString("MDF_InvalidXmlMissingColumn");

	internal static string MDF_InvalidXmlInvalidValue => GetResourceString("MDF_InvalidXmlInvalidValue");

	internal static string MDF_MissingDataSourceInformationColumn => GetResourceString("MDF_MissingDataSourceInformationColumn");

	internal static string MDF_MissingRestrictionColumn => GetResourceString("MDF_MissingRestrictionColumn");

	internal static string MDF_MissingRestrictionRow => GetResourceString("MDF_MissingRestrictionRow");

	internal static string MDF_NoColumns => GetResourceString("MDF_NoColumns");

	internal static string MDF_QueryFailed => GetResourceString("MDF_QueryFailed");

	internal static string MDF_TooManyRestrictions => GetResourceString("MDF_TooManyRestrictions");

	internal static string MDF_UnableToBuildCollection => GetResourceString("MDF_UnableToBuildCollection");

	internal static string MDF_UndefinedCollection => GetResourceString("MDF_UndefinedCollection");

	internal static string MDF_UndefinedPopulationMechanism => GetResourceString("MDF_UndefinedPopulationMechanism");

	internal static string MDF_UnsupportedVersion => GetResourceString("MDF_UnsupportedVersion");

	internal static string ADP_QuotePrefixNotSet => GetResourceString("ADP_QuotePrefixNotSet");

	internal static string Odbc_MDACWrongVersion => GetResourceString("Odbc_MDACWrongVersion");

	internal static string OleDb_MDACWrongVersion => GetResourceString("OleDb_MDACWrongVersion");

	private static bool GetUsingResourceKeysSwitchValue()
	{
		if (!AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled))
		{
			return false;
		}
		return isEnabled;
	}

	internal static bool UsingResourceKeys()
	{
		return s_usingResourceKeys;
	}

	private static string GetResourceString(string resourceKey)
	{
		if (UsingResourceKeys())
		{
			return resourceKey;
		}
		string result = null;
		try
		{
			result = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		return result;
	}

	private static string GetResourceString(string resourceKey, string defaultString)
	{
		string resourceString = GetResourceString(resourceKey);
		if (!(resourceKey == resourceString) && resourceString != null)
		{
			return resourceString;
		}
		return defaultString;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(provider, resourceFormat, p1);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(provider, resourceFormat, p1, p2);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(provider, resourceFormat, p1, p2, p3);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(provider, resourceFormat, args);
		}
		return resourceFormat;
	}
}
