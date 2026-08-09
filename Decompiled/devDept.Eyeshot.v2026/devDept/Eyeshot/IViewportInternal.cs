using System;

namespace devDept.Eyeshot;

internal interface IViewportInternal : IViewport, ICloneable
{
	IWorkspaceInternal parent { get; }

	float screenToWorld { get; }

	ILabelFactory LabelFactory { get; }

	IGrid Grid { get; }

	void SuspendNavigation(bool suspend);

	void UpdateWorkspace();

	void AddLabel(params ILabel[] labels);

	void RemoveLabel(params ILabel[] labels);

	ILabel[] GetLabels();
}
