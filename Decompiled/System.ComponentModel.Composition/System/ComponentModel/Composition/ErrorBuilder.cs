using System.ComponentModel.Composition.Primitives;

namespace System.ComponentModel.Composition;

internal static class ErrorBuilder
{
	public static CompositionError PreventedByExistingImport(ComposablePart part, ImportDefinition import)
	{
		return CompositionError.Create(CompositionErrorId.ImportEngine_PreventedByExistingImport, System.SR.ImportEngine_PreventedByExistingImport, import.ToElement().DisplayName, part.ToElement().DisplayName);
	}

	public static CompositionError InvalidStateForRecompposition(ComposablePart part)
	{
		return CompositionError.Create(CompositionErrorId.ImportEngine_InvalidStateForRecomposition, System.SR.ImportEngine_InvalidStateForRecomposition, part.ToElement().DisplayName);
	}

	public static CompositionError ComposeTookTooManyIterations(int maximumNumberOfCompositionIterations)
	{
		return CompositionError.Create(CompositionErrorId.ImportEngine_ComposeTookTooManyIterations, System.SR.ImportEngine_ComposeTookTooManyIterations, maximumNumberOfCompositionIterations);
	}

	public static CompositionError CreateImportCardinalityMismatch(ImportCardinalityMismatchException exception, ImportDefinition definition)
	{
		ArgumentNullException.ThrowIfNull(exception, "exception");
		ArgumentNullException.ThrowIfNull(definition, "definition");
		return CompositionError.Create(CompositionErrorId.ImportEngine_ImportCardinalityMismatch, exception.Message, definition.ToElement(), null);
	}

	public static CompositionError CreatePartCannotActivate(ComposablePart part, Exception innerException)
	{
		ArgumentNullException.ThrowIfNull(part, "part");
		ArgumentNullException.ThrowIfNull(innerException, "innerException");
		ICompositionElement compositionElement = part.ToElement();
		return CompositionError.Create(CompositionErrorId.ImportEngine_PartCannotActivate, compositionElement, innerException, System.SR.ImportEngine_PartCannotActivate, compositionElement.DisplayName);
	}

	public static CompositionError CreatePartCannotSetImport(ComposablePart part, ImportDefinition definition, Exception innerException)
	{
		ArgumentNullException.ThrowIfNull(part, "part");
		ArgumentNullException.ThrowIfNull(definition, "definition");
		ArgumentNullException.ThrowIfNull(innerException, "innerException");
		ICompositionElement compositionElement = definition.ToElement();
		return CompositionError.Create(CompositionErrorId.ImportEngine_PartCannotSetImport, compositionElement, innerException, System.SR.ImportEngine_PartCannotSetImport, compositionElement.DisplayName, part.ToElement().DisplayName);
	}

	public static CompositionError CreateCannotGetExportedValue(ComposablePart part, ExportDefinition definition, Exception innerException)
	{
		ArgumentNullException.ThrowIfNull(part, "part");
		ArgumentNullException.ThrowIfNull(definition, "definition");
		ArgumentNullException.ThrowIfNull(innerException, "innerException");
		ICompositionElement compositionElement = definition.ToElement();
		return CompositionError.Create(CompositionErrorId.ImportEngine_PartCannotGetExportedValue, compositionElement, innerException, System.SR.ImportEngine_PartCannotGetExportedValue, compositionElement.DisplayName, part.ToElement().DisplayName);
	}

	public static CompositionError CreatePartCycle(ComposablePart part)
	{
		ArgumentNullException.ThrowIfNull(part, "part");
		ICompositionElement compositionElement = part.ToElement();
		return CompositionError.Create(CompositionErrorId.ImportEngine_PartCycle, compositionElement, System.SR.ImportEngine_PartCycle, compositionElement.DisplayName);
	}
}
