using System.Resources;
using FxResources.System.Speech;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string PlatformNotSupported_SystemSpeech => GetResourceString("PlatformNotSupported_SystemSpeech");

	internal static string NullParamIllegal => GetResourceString("NullParamIllegal");

	internal static string ArrayOfNullIllegal => GetResourceString("ArrayOfNullIllegal");

	internal static string ParamsEntryNullIllegal => GetResourceString("ParamsEntryNullIllegal");

	internal static string Unavailable => GetResourceString("Unavailable");

	internal static string UnexpectedError => GetResourceString("UnexpectedError");

	internal static string CollectionReadOnly => GetResourceString("CollectionReadOnly");

	internal static string StringCanNotBeEmpty => GetResourceString("StringCanNotBeEmpty");

	internal static string EnumInvalid => GetResourceString("EnumInvalid");

	internal static string NotSupportedWithThisVersionOfSAPI => GetResourceString("NotSupportedWithThisVersionOfSAPI");

	internal static string NotSupportedWithThisVersionOfSAPI2 => GetResourceString("NotSupportedWithThisVersionOfSAPI2");

	internal static string NotSupportedWithThisVersionOfSAPIBaseUri => GetResourceString("NotSupportedWithThisVersionOfSAPIBaseUri");

	internal static string NotSupportedWithThisVersionOfSAPITagFormat => GetResourceString("NotSupportedWithThisVersionOfSAPITagFormat");

	internal static string NotSupportedWithThisVersionOfSAPICompareOption => GetResourceString("NotSupportedWithThisVersionOfSAPICompareOption");

	internal static string MustBeGreaterThanZero => GetResourceString("MustBeGreaterThanZero");

	internal static string InvalidXml => GetResourceString("InvalidXml");

	internal static string OperationAborted => GetResourceString("OperationAborted");

	internal static string InvariantCultureInfo => GetResourceString("InvariantCultureInfo");

	internal static string DuplicatedEntry => GetResourceString("DuplicatedEntry");

	internal static string StreamMustBeReadable => GetResourceString("StreamMustBeReadable");

	internal static string StreamMustBeWriteable => GetResourceString("StreamMustBeWriteable");

	internal static string StreamMustBeSeekable => GetResourceString("StreamMustBeSeekable");

	internal static string StreamEndedUnexpectedly => GetResourceString("StreamEndedUnexpectedly");

	internal static string CannotReadFromDirectory => GetResourceString("CannotReadFromDirectory");

	internal static string UnknownMimeFormat => GetResourceString("UnknownMimeFormat");

	internal static string CannotLoadResourceFromManifest => GetResourceString("CannotLoadResourceFromManifest");

	internal static string TokenInUse => GetResourceString("TokenInUse");

	internal static string TokenDeleted => GetResourceString("TokenDeleted");

	internal static string TokenUninitialized => GetResourceString("TokenUninitialized");

	internal static string InvalidTokenId => GetResourceString("InvalidTokenId");

	internal static string NotFound => GetResourceString("NotFound");

	internal static string NoBackSlash => GetResourceString("NoBackSlash");

	internal static string InvalidRegistryEntry => GetResourceString("InvalidRegistryEntry");

	internal static string TokenCannotCreateInstance => GetResourceString("TokenCannotCreateInstance");

	internal static string InvalidXmlFormat => GetResourceString("InvalidXmlFormat");

	internal static string IncorrectAttributeValue => GetResourceString("IncorrectAttributeValue");

	internal static string MissingRequiredAttribute => GetResourceString("MissingRequiredAttribute");

	internal static string InvalidRuleRefSelf => GetResourceString("InvalidRuleRefSelf");

	internal static string InvalidDynamicExport => GetResourceString("InvalidDynamicExport");

	internal static string InvalidToken => GetResourceString("InvalidToken");

	internal static string MetaNameHTTPEquiv => GetResourceString("MetaNameHTTPEquiv");

	internal static string EmptyRule => GetResourceString("EmptyRule");

	internal static string InvalidTokenString => GetResourceString("InvalidTokenString");

	internal static string InvalidQuotedString => GetResourceString("InvalidQuotedString");

	internal static string ExportDynamicRule => GetResourceString("ExportDynamicRule");

	internal static string EmptyDisplayString => GetResourceString("EmptyDisplayString");

	internal static string EmptyPronunciationString => GetResourceString("EmptyPronunciationString");

	internal static string InvalidPhoneme => GetResourceString("InvalidPhoneme");

	internal static string MuliplePronunciationString => GetResourceString("MuliplePronunciationString");

	internal static string MultipleDisplayString => GetResourceString("MultipleDisplayString");

	internal static string RuleRedefinition => GetResourceString("RuleRedefinition");

	internal static string EmptyOneOf => GetResourceString("EmptyOneOf");

	internal static string InvalidGrammarOrdering => GetResourceString("InvalidGrammarOrdering");

	internal static string MinMaxOutOfRange => GetResourceString("MinMaxOutOfRange");

	internal static string InvalidExampleOrdering => GetResourceString("InvalidExampleOrdering");

	internal static string GrammarDefTwice => GetResourceString("GrammarDefTwice");

	internal static string UnsupportedFormat => GetResourceString("UnsupportedFormat");

	internal static string InvalidImport => GetResourceString("InvalidImport");

	internal static string DuplicatedRuleName => GetResourceString("DuplicatedRuleName");

	internal static string RootRuleAlreadyDefined => GetResourceString("RootRuleAlreadyDefined");

	internal static string RuleNameIdConflict => GetResourceString("RuleNameIdConflict");

	internal static string RuleNotDynamic => GetResourceString("RuleNotDynamic");

	internal static string StateWithNoArcs => GetResourceString("StateWithNoArcs");

	internal static string NoTerminatingRulePath => GetResourceString("NoTerminatingRulePath");

	internal static string RuleRefNoUri => GetResourceString("RuleRefNoUri");

	internal static string UnavailableProperty => GetResourceString("UnavailableProperty");

	internal static string MinGreaterThanMax => GetResourceString("MinGreaterThanMax");

	internal static string ReqConfidenceNotSupported => GetResourceString("ReqConfidenceNotSupported");

	internal static string SapiPropertiesAndSemantics => GetResourceString("SapiPropertiesAndSemantics");

	internal static string InvalidAttributeDefinedTwice => GetResourceString("InvalidAttributeDefinedTwice");

	internal static string GrammarCompilerError => GetResourceString("GrammarCompilerError");

	internal static string RuleScriptNotFound => GetResourceString("RuleScriptNotFound");

	internal static string DynamicRuleNotFound => GetResourceString("DynamicRuleNotFound");

	internal static string RuleScriptInvalidParameters => GetResourceString("RuleScriptInvalidParameters");

	internal static string RuleScriptInvalidReturnType => GetResourceString("RuleScriptInvalidReturnType");

	internal static string NoClassname => GetResourceString("NoClassname");

	internal static string EmbeddedClassLibraryFailed => GetResourceString("EmbeddedClassLibraryFailed");

	internal static string CannotFindClass => GetResourceString("CannotFindClass");

	internal static string StrongTypedGrammarNotAGrammar => GetResourceString("StrongTypedGrammarNotAGrammar");

	internal static string NoScriptsForRules => GetResourceString("NoScriptsForRules");

	internal static string ClassNotPublic => GetResourceString("ClassNotPublic");

	internal static string MethodNotPublic => GetResourceString("MethodNotPublic");

	internal static string IncompatibleLanguageProperties => GetResourceString("IncompatibleLanguageProperties");

	internal static string IncompatibleNamespaceProperties => GetResourceString("IncompatibleNamespaceProperties");

	internal static string IncompatibleDebugProperties => GetResourceString("IncompatibleDebugProperties");

	internal static string CannotLoadDotNetSemanticCode => GetResourceString("CannotLoadDotNetSemanticCode");

	internal static string InvalidSemanticProcessingType => GetResourceString("InvalidSemanticProcessingType");

	internal static string InvalidScriptDefinition => GetResourceString("InvalidScriptDefinition");

	internal static string InvalidMethodName => GetResourceString("InvalidMethodName");

	internal static string ConstructorNotAllowed => GetResourceString("ConstructorNotAllowed");

	internal static string OverloadNotAllowed => GetResourceString("OverloadNotAllowed");

	internal static string OnInitOnPublicRule => GetResourceString("OnInitOnPublicRule");

	internal static string ArgumentMismatch => GetResourceString("ArgumentMismatch");

	internal static string CantGetPropertyFromSerializedInfo => GetResourceString("CantGetPropertyFromSerializedInfo");

	internal static string CantFindAConstructor => GetResourceString("CantFindAConstructor");

	internal static string TooManyArcs => GetResourceString("TooManyArcs");

	internal static string TooManyRulesWithSemanticsGlobals => GetResourceString("TooManyRulesWithSemanticsGlobals");

	internal static string MaxTransitionsCount => GetResourceString("MaxTransitionsCount");

	internal static string UnknownElement => GetResourceString("UnknownElement");

	internal static string CircularRuleRef => GetResourceString("CircularRuleRef");

	internal static string InvalidFlagsSet => GetResourceString("InvalidFlagsSet");

	internal static string RuleDefinedMultipleTimes => GetResourceString("RuleDefinedMultipleTimes");

	internal static string RuleDefinedMultipleTimes2 => GetResourceString("RuleDefinedMultipleTimes2");

	internal static string RuleNotDefined => GetResourceString("RuleNotDefined");

	internal static string RootNotDefined => GetResourceString("RootNotDefined");

	internal static string InvalidLanguage => GetResourceString("InvalidLanguage");

	internal static string InvalidRuleId => GetResourceString("InvalidRuleId");

	internal static string InvalidRepeatProbability => GetResourceString("InvalidRepeatProbability");

	internal static string InvalidConfidence => GetResourceString("InvalidConfidence");

	internal static string InvalidMinRepeat => GetResourceString("InvalidMinRepeat");

	internal static string InvalidMaxRepeat => GetResourceString("InvalidMaxRepeat");

	internal static string InvalidWeight => GetResourceString("InvalidWeight");

	internal static string InvalidName => GetResourceString("InvalidName");

	internal static string InvalidValueType => GetResourceString("InvalidValueType");

	internal static string TagFormatNotSet => GetResourceString("TagFormatNotSet");

	internal static string NoName => GetResourceString("NoName");

	internal static string NoName1 => GetResourceString("NoName1");

	internal static string InvalidSpecialRuleRef => GetResourceString("InvalidSpecialRuleRef");

	internal static string InvalidRuleRef => GetResourceString("InvalidRuleRef");

	internal static string InvalidNotEmptyElement => GetResourceString("InvalidNotEmptyElement");

	internal static string InvalidEmptyElement => GetResourceString("InvalidEmptyElement");

	internal static string InvalidEmptyRule => GetResourceString("InvalidEmptyRule");

	internal static string UndefRuleRef => GetResourceString("UndefRuleRef");

	internal static string UnsupportedLanguage => GetResourceString("UnsupportedLanguage");

	internal static string UnsupportedPhoneticAlphabet => GetResourceString("UnsupportedPhoneticAlphabet");

	internal static string UnsupportedLexicon => GetResourceString("UnsupportedLexicon");

	internal static string InvalidScriptAttribute => GetResourceString("InvalidScriptAttribute");

	internal static string NoLanguageSet => GetResourceString("NoLanguageSet");

	internal static string MethodAttributeDefinedMultipleTimes => GetResourceString("MethodAttributeDefinedMultipleTimes");

	internal static string RuleAttributeDefinedMultipleTimes => GetResourceString("RuleAttributeDefinedMultipleTimes");

	internal static string InvalidAssemblyReferenceAttribute => GetResourceString("InvalidAssemblyReferenceAttribute");

	internal static string InvalidImportNamespaceAttribute => GetResourceString("InvalidImportNamespaceAttribute");

	internal static string NoUriForSpecialRuleRef => GetResourceString("NoUriForSpecialRuleRef");

	internal static string NoAliasForSpecialRuleRef => GetResourceString("NoAliasForSpecialRuleRef");

	internal static string NoSmlData => GetResourceString("NoSmlData");

	internal static string InvalidNameValueProperty => GetResourceString("InvalidNameValueProperty");

	internal static string InvalidTagInAnEmptyItem => GetResourceString("InvalidTagInAnEmptyItem");

	internal static string InvalidSrgs => GetResourceString("InvalidSrgs");

	internal static string InvalidSrgsNamespace => GetResourceString("InvalidSrgsNamespace");

	internal static string Line => GetResourceString("Line");

	internal static string Position => GetResourceString("Position");

	internal static string InvalidVersion => GetResourceString("InvalidVersion");

	internal static string InvalidTagFormat => GetResourceString("InvalidTagFormat");

	internal static string MissingTagFormat => GetResourceString("MissingTagFormat");

	internal static string InvalidGrammarMode => GetResourceString("InvalidGrammarMode");

	internal static string InvalidGrammarAttribute => GetResourceString("InvalidGrammarAttribute");

	internal static string InvalidRuleAttribute => GetResourceString("InvalidRuleAttribute");

	internal static string InvalidRulerefAttribute => GetResourceString("InvalidRulerefAttribute");

	internal static string InvalidOneOfAttribute => GetResourceString("InvalidOneOfAttribute");

	internal static string InvalidItemAttribute => GetResourceString("InvalidItemAttribute");

	internal static string InvalidTokenAttribute => GetResourceString("InvalidTokenAttribute");

	internal static string InvalidItemRepeatAttribute => GetResourceString("InvalidItemRepeatAttribute");

	internal static string InvalidReqConfAttribute => GetResourceString("InvalidReqConfAttribute");

	internal static string InvalidTagAttribute => GetResourceString("InvalidTagAttribute");

	internal static string InvalidLexiconAttribute => GetResourceString("InvalidLexiconAttribute");

	internal static string InvalidMetaAttribute => GetResourceString("InvalidMetaAttribute");

	internal static string InvalidItemAttribute2 => GetResourceString("InvalidItemAttribute2");

	internal static string InvalidElement => GetResourceString("InvalidElement");

	internal static string InvalidRuleScope => GetResourceString("InvalidRuleScope");

	internal static string InvalidDynamicSetting => GetResourceString("InvalidDynamicSetting");

	internal static string InvalidSubsetAttribute => GetResourceString("InvalidSubsetAttribute");

	internal static string InvalidVoiceElementInPromptOutput => GetResourceString("InvalidVoiceElementInPromptOutput");

	internal static string NoRuleId => GetResourceString("NoRuleId");

	internal static string PromptBuilderInvalideState => GetResourceString("PromptBuilderInvalideState");

	internal static string PromptBuilderStateEnded => GetResourceString("PromptBuilderStateEnded");

	internal static string PromptBuilderStateSentence => GetResourceString("PromptBuilderStateSentence");

	internal static string PromptBuilderStateParagraph => GetResourceString("PromptBuilderStateParagraph");

	internal static string PromptBuilderStateVoice => GetResourceString("PromptBuilderStateVoice");

	internal static string PromptBuilderStateStyle => GetResourceString("PromptBuilderStateStyle");

	internal static string PromptBuilderAgeOutOfRange => GetResourceString("PromptBuilderAgeOutOfRange");

	internal static string PromptBuilderMismatchStyle => GetResourceString("PromptBuilderMismatchStyle");

	internal static string PromptBuilderMismatchVoice => GetResourceString("PromptBuilderMismatchVoice");

	internal static string PromptBuilderMismatchParagraph => GetResourceString("PromptBuilderMismatchParagraph");

	internal static string PromptBuilderMismatchSentence => GetResourceString("PromptBuilderMismatchSentence");

	internal static string PromptBuilderNestedParagraph => GetResourceString("PromptBuilderNestedParagraph");

	internal static string PromptBuilderNestedSentence => GetResourceString("PromptBuilderNestedSentence");

	internal static string PromptBuilderInvalidAttribute => GetResourceString("PromptBuilderInvalidAttribute");

	internal static string PromptBuilderInvalidElement => GetResourceString("PromptBuilderInvalidElement");

	internal static string PromptBuilderInvalidVariant => GetResourceString("PromptBuilderInvalidVariant");

	internal static string PromptBuilderDatabaseName => GetResourceString("PromptBuilderDatabaseName");

	internal static string PromptAsyncOperationCancelled => GetResourceString("PromptAsyncOperationCancelled");

	internal static string SynthesizerPauseResumeMismatched => GetResourceString("SynthesizerPauseResumeMismatched");

	internal static string SynthesizerInvalidMediaType => GetResourceString("SynthesizerInvalidMediaType");

	internal static string SynthesizerUnknownMediaType => GetResourceString("SynthesizerUnknownMediaType");

	internal static string SynthesizerSpeakError => GetResourceString("SynthesizerSpeakError");

	internal static string SynthesizerInvalidWaveFile => GetResourceString("SynthesizerInvalidWaveFile");

	internal static string SynthesizerPromptInUse => GetResourceString("SynthesizerPromptInUse");

	internal static string SynthesizerUnknownPriority => GetResourceString("SynthesizerUnknownPriority");

	internal static string SynthesizerUnknownEvent => GetResourceString("SynthesizerUnknownEvent");

	internal static string SynthesizerVoiceFailed => GetResourceString("SynthesizerVoiceFailed");

	internal static string SynthesizerSetVoiceNoMatch => GetResourceString("SynthesizerSetVoiceNoMatch");

	internal static string SynthesizerNoCulture => GetResourceString("SynthesizerNoCulture");

	internal static string SynthesizerSyncSpeakWhilePaused => GetResourceString("SynthesizerSyncSpeakWhilePaused");

	internal static string SynthesizerSyncSetOutputWhilePaused => GetResourceString("SynthesizerSyncSetOutputWhilePaused");

	internal static string SynthesizerNoCulture2 => GetResourceString("SynthesizerNoCulture2");

	internal static string SynthesizerNoSpeak => GetResourceString("SynthesizerNoSpeak");

	internal static string SynthesizerSetOutputSpeaking => GetResourceString("SynthesizerSetOutputSpeaking");

	internal static string InvalidSpeakAttribute => GetResourceString("InvalidSpeakAttribute");

	internal static string UnsupportedAlphabet => GetResourceString("UnsupportedAlphabet");

	internal static string GrammarInvalidWeight => GetResourceString("GrammarInvalidWeight");

	internal static string GrammarInvalidPriority => GetResourceString("GrammarInvalidPriority");

	internal static string DictationInvalidTopic => GetResourceString("DictationInvalidTopic");

	internal static string DictationTopicNotFound => GetResourceString("DictationTopicNotFound");

	internal static string RecognizerGrammarNotFound => GetResourceString("RecognizerGrammarNotFound");

	internal static string RecognizerRuleNotFound => GetResourceString("RecognizerRuleNotFound");

	internal static string RecognizerInvalidBinaryGrammar => GetResourceString("RecognizerInvalidBinaryGrammar");

	internal static string RecognizerRuleNotFoundStream => GetResourceString("RecognizerRuleNotFoundStream");

	internal static string RecognizerNoRootRuleToActivate => GetResourceString("RecognizerNoRootRuleToActivate");

	internal static string RecognizerNoRootRuleToActivate1 => GetResourceString("RecognizerNoRootRuleToActivate1");

	internal static string RecognizerRuleActivationFailed => GetResourceString("RecognizerRuleActivationFailed");

	internal static string RecognizerAlreadyRecognizing => GetResourceString("RecognizerAlreadyRecognizing");

	internal static string RecognizerHasNoGrammar => GetResourceString("RecognizerHasNoGrammar");

	internal static string NegativeTimesNotSupported => GetResourceString("NegativeTimesNotSupported");

	internal static string AudioDeviceFormatError => GetResourceString("AudioDeviceFormatError");

	internal static string AudioDeviceError => GetResourceString("AudioDeviceError");

	internal static string AudioDeviceInternalError => GetResourceString("AudioDeviceInternalError");

	internal static string RecognizerNotFound => GetResourceString("RecognizerNotFound");

	internal static string RecognizerNotEnabled => GetResourceString("RecognizerNotEnabled");

	internal static string RecognitionNotSupported => GetResourceString("RecognitionNotSupported");

	internal static string RecognitionNotSupportedOn64bit => GetResourceString("RecognitionNotSupportedOn64bit");

	internal static string GrammarAlreadyLoaded => GetResourceString("GrammarAlreadyLoaded");

	internal static string RecognizerNoInputSource => GetResourceString("RecognizerNoInputSource");

	internal static string GrammarNotLoaded => GetResourceString("GrammarNotLoaded");

	internal static string GrammarLoadingInProgress => GetResourceString("GrammarLoadingInProgress");

	internal static string GrammarLoadFailed => GetResourceString("GrammarLoadFailed");

	internal static string GrammarWrongRecognizer => GetResourceString("GrammarWrongRecognizer");

	internal static string NotSupportedOnDictationGrammars => GetResourceString("NotSupportedOnDictationGrammars");

	internal static string LocalFilesOnly => GetResourceString("LocalFilesOnly");

	internal static string NotValidAudioFile => GetResourceString("NotValidAudioFile");

	internal static string NotValidAudioStream => GetResourceString("NotValidAudioStream");

	internal static string FileNotFound => GetResourceString("FileNotFound");

	internal static string CannotSetPriorityOnDictation => GetResourceString("CannotSetPriorityOnDictation");

	internal static string RecognizerUpdateTableTooLarge => GetResourceString("RecognizerUpdateTableTooLarge");

	internal static string MaxAlternatesInvalid => GetResourceString("MaxAlternatesInvalid");

	internal static string RecognizerSettingGetError => GetResourceString("RecognizerSettingGetError");

	internal static string RecognizerSettingUpdateError => GetResourceString("RecognizerSettingUpdateError");

	internal static string RecognizerSettingNotSupported => GetResourceString("RecognizerSettingNotSupported");

	internal static string ResourceUsageOutOfRange => GetResourceString("ResourceUsageOutOfRange");

	internal static string RateOutOfRange => GetResourceString("RateOutOfRange");

	internal static string EndSilenceOutOfRange => GetResourceString("EndSilenceOutOfRange");

	internal static string RejectionThresholdOutOfRange => GetResourceString("RejectionThresholdOutOfRange");

	internal static string ReferencedGrammarNotFound => GetResourceString("ReferencedGrammarNotFound");

	internal static string SapiErrorRuleNotFound2 => GetResourceString("SapiErrorRuleNotFound2");

	internal static string NoAudioAvailable => GetResourceString("NoAudioAvailable");

	internal static string ResultNotGrammarAvailable => GetResourceString("ResultNotGrammarAvailable");

	internal static string ResultInvalidFormat => GetResourceString("ResultInvalidFormat");

	internal static string UnhandledVariant => GetResourceString("UnhandledVariant");

	internal static string DupSemanticKey => GetResourceString("DupSemanticKey");

	internal static string DupSemanticValue => GetResourceString("DupSemanticValue");

	internal static string CannotUseCustomFormat => GetResourceString("CannotUseCustomFormat");

	internal static string NoPromptEngine => GetResourceString("NoPromptEngine");

	internal static string NoPromptEngineInterface => GetResourceString("NoPromptEngineInterface");

	internal static string SeekNotSupported => GetResourceString("SeekNotSupported");

	internal static string ExtraDataNotPresent => GetResourceString("ExtraDataNotPresent");

	internal static string BitsPerSampleInvalid => GetResourceString("BitsPerSampleInvalid");

	internal static string DataBlockSizeInvalid => GetResourceString("DataBlockSizeInvalid");

	internal static string NotWholeNumberBlocks => GetResourceString("NotWholeNumberBlocks");

	internal static string BlockSignatureInvalid => GetResourceString("BlockSignatureInvalid");

	internal static string NumberOfSamplesInvalid => GetResourceString("NumberOfSamplesInvalid");

	internal static string SapiErrorUninitialized => GetResourceString("SapiErrorUninitialized");

	internal static string SapiErrorAlreadyInitialized => GetResourceString("SapiErrorAlreadyInitialized");

	internal static string SapiErrorNotSupportedFormat => GetResourceString("SapiErrorNotSupportedFormat");

	internal static string SapiErrorInvalidFlags => GetResourceString("SapiErrorInvalidFlags");

	internal static string SapiErrorEndOfStream => GetResourceString("SapiErrorEndOfStream");

	internal static string SapiErrorDeviceBusy => GetResourceString("SapiErrorDeviceBusy");

	internal static string SapiErrorDeviceNotSupported => GetResourceString("SapiErrorDeviceNotSupported");

	internal static string SapiErrorDeviceNotEnabled => GetResourceString("SapiErrorDeviceNotEnabled");

	internal static string SapiErrorNoDriver => GetResourceString("SapiErrorNoDriver");

	internal static string SapiErrorFileMustBeUnicode => GetResourceString("SapiErrorFileMustBeUnicode");

	internal static string InsufficientData => GetResourceString("InsufficientData");

	internal static string SapiErrorInvalidPhraseID => GetResourceString("SapiErrorInvalidPhraseID");

	internal static string SapiErrorBufferTooSmall => GetResourceString("SapiErrorBufferTooSmall");

	internal static string SapiErrorFormatNotSpecified => GetResourceString("SapiErrorFormatNotSpecified");

	internal static string SapiErrorAudioStopped0 => GetResourceString("SapiErrorAudioStopped0");

	internal static string AudioPaused => GetResourceString("AudioPaused");

	internal static string SapiErrorRuleNotFound => GetResourceString("SapiErrorRuleNotFound");

	internal static string SapiErrorTTSEngineException => GetResourceString("SapiErrorTTSEngineException");

	internal static string SapiErrorTTSNLPException => GetResourceString("SapiErrorTTSNLPException");

	internal static string SapiErrorEngineBUSY => GetResourceString("SapiErrorEngineBUSY");

	internal static string AudioConversionEnabled => GetResourceString("AudioConversionEnabled");

	internal static string NoHypothesisAvailable => GetResourceString("NoHypothesisAvailable");

	internal static string SapiErrorCantCreate => GetResourceString("SapiErrorCantCreate");

	internal static string AlreadyInLex => GetResourceString("AlreadyInLex");

	internal static string SapiErrorNotInLex => GetResourceString("SapiErrorNotInLex");

	internal static string LexNothingToSync => GetResourceString("LexNothingToSync");

	internal static string SapiErrorLexVeryOutOfSync => GetResourceString("SapiErrorLexVeryOutOfSync");

	internal static string SapiErrorUndefinedForwardRuleRef => GetResourceString("SapiErrorUndefinedForwardRuleRef");

	internal static string SapiErrorEmptyRule => GetResourceString("SapiErrorEmptyRule");

	internal static string SapiErrorGrammarCompilerInternalError => GetResourceString("SapiErrorGrammarCompilerInternalError");

	internal static string SapiErrorRuleNotDynamic => GetResourceString("SapiErrorRuleNotDynamic");

	internal static string SapiErrorDuplicateRuleName => GetResourceString("SapiErrorDuplicateRuleName");

	internal static string SapiErrorDuplicateResourceName => GetResourceString("SapiErrorDuplicateResourceName");

	internal static string SapiErrorTooManyGrammars => GetResourceString("SapiErrorTooManyGrammars");

	internal static string SapiErrorCircularReference => GetResourceString("SapiErrorCircularReference");

	internal static string SapiErrorInvalidImport => GetResourceString("SapiErrorInvalidImport");

	internal static string SapiErrorInvalidWAVFile => GetResourceString("SapiErrorInvalidWAVFile");

	internal static string RequestPending => GetResourceString("RequestPending");

	internal static string SapiErrorAllWordsOptional => GetResourceString("SapiErrorAllWordsOptional");

	internal static string SapiErrorInstanceChangeInvalid => GetResourceString("SapiErrorInstanceChangeInvalid");

	internal static string SapiErrorRuleNameIdConflict => GetResourceString("SapiErrorRuleNameIdConflict");

	internal static string SapiErrorNoRules => GetResourceString("SapiErrorNoRules");

	internal static string SapiErrorCircularRuleRef => GetResourceString("SapiErrorCircularRuleRef");

	internal static string NoParseFound => GetResourceString("NoParseFound");

	internal static string SapiErrorInvalidHandle => GetResourceString("SapiErrorInvalidHandle");

	internal static string SapiErrorRemoteCallTimedout => GetResourceString("SapiErrorRemoteCallTimedout");

	internal static string SapiErrorAudioBufferOverflow => GetResourceString("SapiErrorAudioBufferOverflow");

	internal static string SapiErrorNoAudioData => GetResourceString("SapiErrorNoAudioData");

	internal static string SapiErrorDeadAlternate => GetResourceString("SapiErrorDeadAlternate");

	internal static string SapiErrorHighLowConfidence => GetResourceString("SapiErrorHighLowConfidence");

	internal static string SapiErrorInvalidFormatString => GetResourceString("SapiErrorInvalidFormatString");

	internal static string SPNotSupportedOnStreamInput => GetResourceString("SPNotSupportedOnStreamInput");

	internal static string SapiErrorAppLexReadOnly => GetResourceString("SapiErrorAppLexReadOnly");

	internal static string SapiErrorNoTerminatingRulePath => GetResourceString("SapiErrorNoTerminatingRulePath");

	internal static string WordExistsWithoutPronunciation => GetResourceString("WordExistsWithoutPronunciation");

	internal static string SapiErrorStreamClosed => GetResourceString("SapiErrorStreamClosed");

	internal static string SapiErrorNoMoreItems => GetResourceString("SapiErrorNoMoreItems");

	internal static string SapiErrorNotFound => GetResourceString("SapiErrorNotFound");

	internal static string SapiErrorInvalidAudioState => GetResourceString("SapiErrorInvalidAudioState");

	internal static string SapiErrorGenericMMSYS => GetResourceString("SapiErrorGenericMMSYS");

	internal static string SapiErrorMarshalerException => GetResourceString("SapiErrorMarshalerException");

	internal static string SapiErrorNotDynamicGrammar => GetResourceString("SapiErrorNotDynamicGrammar");

	internal static string SapiErrorAmbiguousProperty => GetResourceString("SapiErrorAmbiguousProperty");

	internal static string SapiErrorInvalidRegistrykey => GetResourceString("SapiErrorInvalidRegistrykey");

	internal static string SapiErrorInvalidTokenId => GetResourceString("SapiErrorInvalidTokenId");

	internal static string SapiErrorXMLBadSyntax => GetResourceString("SapiErrorXMLBadSyntax");

	internal static string SapiErrorXMLResourceNotFound => GetResourceString("SapiErrorXMLResourceNotFound");

	internal static string SapiErrorTokenInUse => GetResourceString("SapiErrorTokenInUse");

	internal static string SapiErrorTokenDeleted => GetResourceString("SapiErrorTokenDeleted");

	internal static string SapiErrorMultilingualNotSupported => GetResourceString("SapiErrorMultilingualNotSupported");

	internal static string SapiErrorExportDynamicRule => GetResourceString("SapiErrorExportDynamicRule");

	internal static string SapiErrorSTGF => GetResourceString("SapiErrorSTGF");

	internal static string SapiErrorWordFormat => GetResourceString("SapiErrorWordFormat");

	internal static string SapiErrorStreamNotActive => GetResourceString("SapiErrorStreamNotActive");

	internal static string SapiErrorEngineResponseInvalid => GetResourceString("SapiErrorEngineResponseInvalid");

	internal static string SapiErrorSREngineException => GetResourceString("SapiErrorSREngineException");

	internal static string SapiErrorStreamPosInvalid => GetResourceString("SapiErrorStreamPosInvalid");

	internal static string SapiErrorRecognizerInactive => GetResourceString("SapiErrorRecognizerInactive");

	internal static string SapiErrorRemoteCallOnWrongThread => GetResourceString("SapiErrorRemoteCallOnWrongThread");

	internal static string SapiErrorRemoteProcessTerminated => GetResourceString("SapiErrorRemoteProcessTerminated");

	internal static string SapiErrorRemoteProcessAlreadyRunning => GetResourceString("SapiErrorRemoteProcessAlreadyRunning");

	internal static string SapiErrorLangIdMismatch => GetResourceString("SapiErrorLangIdMismatch");

	internal static string SapiErrorPartialParseFound => GetResourceString("SapiErrorPartialParseFound");

	internal static string SapiErrorNotTopLevelRule => GetResourceString("SapiErrorNotTopLevelRule");

	internal static string SapiErrorNoRuleActive => GetResourceString("SapiErrorNoRuleActive");

	internal static string SapiErrorLexRequiresCookie => GetResourceString("SapiErrorLexRequiresCookie");

	internal static string SapiErrorStreamUninitialized => GetResourceString("SapiErrorStreamUninitialized");

	internal static string SapiErrorUnused0 => GetResourceString("SapiErrorUnused0");

	internal static string SapiErrorUnused1 => GetResourceString("SapiErrorUnused1");

	internal static string SapiErrorUnused2 => GetResourceString("SapiErrorUnused2");

	internal static string SapiErrorUnused3 => GetResourceString("SapiErrorUnused3");

	internal static string SapiErrorUnused4 => GetResourceString("SapiErrorUnused4");

	internal static string SapiErrorUnused5 => GetResourceString("SapiErrorUnused5");

	internal static string SapiErrorUnused6 => GetResourceString("SapiErrorUnused6");

	internal static string SapiErrorUnused7 => GetResourceString("SapiErrorUnused7");

	internal static string SapiErrorUnused8 => GetResourceString("SapiErrorUnused8");

	internal static string SapiErrorUnused9 => GetResourceString("SapiErrorUnused9");

	internal static string SapiErrorUnused10 => GetResourceString("SapiErrorUnused10");

	internal static string SapiErrorUnused11 => GetResourceString("SapiErrorUnused11");

	internal static string SapiErrorUnused12 => GetResourceString("SapiErrorUnused12");

	internal static string SapiErrorNotSupportedLang => GetResourceString("SapiErrorNotSupportedLang");

	internal static string SapiErrorVoicePaused => GetResourceString("SapiErrorVoicePaused");

	internal static string SapiErrorAudioBufferUnderflow => GetResourceString("SapiErrorAudioBufferUnderflow");

	internal static string SapiErrorAudioStoppedUnexpectedly => GetResourceString("SapiErrorAudioStoppedUnexpectedly");

	internal static string SapiErrorNoWordPronunciation => GetResourceString("SapiErrorNoWordPronunciation");

	internal static string SapiErrorAlternatesWouldBeInconsistent => GetResourceString("SapiErrorAlternatesWouldBeInconsistent");

	internal static string SapiErrorNotSupportedForSharedRecognizer => GetResourceString("SapiErrorNotSupportedForSharedRecognizer");

	internal static string SapiErrorTimeOut => GetResourceString("SapiErrorTimeOut");

	internal static string SapiErrorReenterSynchronize => GetResourceString("SapiErrorReenterSynchronize");

	internal static string SapiErrorStateWithNoArcs => GetResourceString("SapiErrorStateWithNoArcs");

	internal static string SapiErrorNotActiveSession => GetResourceString("SapiErrorNotActiveSession");

	internal static string SapiErrorAlreadyDeleted => GetResourceString("SapiErrorAlreadyDeleted");

	internal static string SapiErrorAudioStopped => GetResourceString("SapiErrorAudioStopped");

	internal static string SapiErrorRecoXMLGenerationFail => GetResourceString("SapiErrorRecoXMLGenerationFail");

	internal static string SapiErrorSMLGenerationFail => GetResourceString("SapiErrorSMLGenerationFail");

	internal static string SapiErrorNotPromptVoice => GetResourceString("SapiErrorNotPromptVoice");

	internal static string SapiErrorRootRuleAlreadyDefined => GetResourceString("SapiErrorRootRuleAlreadyDefined");

	internal static string SapiErrorScriptDisallowed => GetResourceString("SapiErrorScriptDisallowed");

	internal static string SapiErrorRemoteCallTimedOutStart => GetResourceString("SapiErrorRemoteCallTimedOutStart");

	internal static string SapiErrorRemoteCallTimedOutConnect => GetResourceString("SapiErrorRemoteCallTimedOutConnect");

	internal static string SapiErrorSecMgrChangeNotAllowed => GetResourceString("SapiErrorSecMgrChangeNotAllowed");

	internal static string SapiErrorCompleteButExtendable => GetResourceString("SapiErrorCompleteButExtendable");

	internal static string SapiErrorFailedToDeleteFile => GetResourceString("SapiErrorFailedToDeleteFile");

	internal static string SapiErrorSharedEngineDisabled => GetResourceString("SapiErrorSharedEngineDisabled");

	internal static string SapiErrorRecognizerNotFound => GetResourceString("SapiErrorRecognizerNotFound");

	internal static string SapiErrorAudioNotFound => GetResourceString("SapiErrorAudioNotFound");

	internal static string SapiErrorNoVowel => GetResourceString("SapiErrorNoVowel");

	internal static string SapiErrorNotSupportedPhoneme => GetResourceString("SapiErrorNotSupportedPhoneme");

	internal static string SapiErrorNoRulesToActivate => GetResourceString("SapiErrorNoRulesToActivate");

	internal static string SapiErrorNoWordEntryNotification => GetResourceString("SapiErrorNoWordEntryNotification");

	internal static string SapiErrorWordNeedsNormalization => GetResourceString("SapiErrorWordNeedsNormalization");

	internal static string SapiErrorCannotNormalize => GetResourceString("SapiErrorCannotNormalize");

	internal static string LimitReached => GetResourceString("LimitReached");

	internal static string NotSupported => GetResourceString("NotSupported");

	internal static string SapiErrorTopicNotAdaptable => GetResourceString("SapiErrorTopicNotAdaptable");

	internal static string SapiErrorPhonemeConversion => GetResourceString("SapiErrorPhonemeConversion");

	internal static string SapiErrorNotSupportedForInprocRecognizer => GetResourceString("SapiErrorNotSupportedForInprocRecognizer");

	internal static string SapiLexInvalidData => GetResourceString("SapiLexInvalidData");

	internal static string SapiLexUnexpectedFormat => GetResourceString("SapiLexUnexpectedFormat");

	internal static string SapiNonWordTransition => GetResourceString("SapiNonWordTransition");

	internal static string SapiSisrAttributesNotAllowed => GetResourceString("SapiSisrAttributesNotAllowed");

	internal static string SapiSisrMixedNotAllowed => GetResourceString("SapiSisrMixedNotAllowed");

	internal static string SapiStringEmpty => GetResourceString("SapiStringEmpty");

	internal static string SapiStringTooLong => GetResourceString("SapiStringTooLong");

	internal static string SapiVoiceNotFound => GetResourceString("SapiVoiceNotFound");

	internal static string SapiErrorOverload => GetResourceString("SapiErrorOverload");

	internal static string SapiConfigInvalidData => GetResourceString("SapiConfigInvalidData");

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
