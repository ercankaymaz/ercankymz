using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Federation;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc;

public class XbimReferencedModel : IReferencedModel, IDisposable
{
	public IIfcDocumentInformation DocumentInformation;

	private readonly IfcStore _model;

	private bool disposedValue;

	public IModel Model => _model;

	public ITransaction DocumentInfoTransaction
	{
		get
		{
			if (DocumentInformation.Model.CurrentTransaction != null)
			{
				return new PlaceboTransaction();
			}
			return DocumentInformation.Model.BeginTransaction("Update ReferenceModel");
		}
	}

	public string Identifier => DocumentInformation.Identification;

	public string Name
	{
		get
		{
			return DocumentInformation.Name;
		}
		set
		{
			using ITransaction transaction = DocumentInfoTransaction;
			if (DocumentInformation is Xbim.Ifc2x3.ExternalReferenceResource.IfcDocumentInformation)
			{
				((Xbim.Ifc2x3.ExternalReferenceResource.IfcDocumentInformation)DocumentInformation).Name = value;
			}
			else
			{
				if (!(DocumentInformation is Xbim.Ifc4.ExternalReferenceResource.IfcDocumentInformation))
				{
					throw new Exception("Invalid IFC schema");
				}
				((Xbim.Ifc4.ExternalReferenceResource.IfcDocumentInformation)DocumentInformation).Name = value;
			}
			transaction.Commit();
		}
	}

	public string Role
	{
		get
		{
			if (!(DocumentInformation.DocumentOwner is IIfcOrganization ifcOrganization))
			{
				return null;
			}
			IIfcActorRole ifcActorRole = ifcOrganization.Roles.FirstOrDefault();
			if (ifcActorRole == null)
			{
				return null;
			}
			if (ifcActorRole.Role == Xbim.Ifc4.Interfaces.IfcRoleEnum.USERDEFINED)
			{
				IfcLabel? userDefinedRole = ifcActorRole.UserDefinedRole;
				if (!userDefinedRole.HasValue)
				{
					return null;
				}
				return userDefinedRole.GetValueOrDefault();
			}
			return ifcActorRole.Role.ToString();
		}
		set
		{
			using ITransaction transaction = DocumentInfoTransaction;
			if (DocumentInformation is Xbim.Ifc2x3.ExternalReferenceResource.IfcDocumentInformation)
			{
				Xbim.Ifc2x3.ActorResource.IfcOrganization ifcOrganization = DocumentInformation.DocumentOwner as Xbim.Ifc2x3.ActorResource.IfcOrganization;
				if (ifcOrganization == null)
				{
					ifcOrganization = DocumentInformation.Model.Instances.New<Xbim.Ifc2x3.ActorResource.IfcOrganization>();
					((Xbim.Ifc2x3.ExternalReferenceResource.IfcDocumentInformation)DocumentInformation).DocumentOwner = ifcOrganization;
				}
				Xbim.Ifc2x3.ActorResource.IfcActorRole ifcActorRole = ifcOrganization.Roles.FirstOrDefault();
				ifcOrganization.Roles.Clear();
				if (ifcActorRole == null)
				{
					ifcActorRole = DocumentInformation.Model.Instances.New<Xbim.Ifc2x3.ActorResource.IfcActorRole>();
				}
				if (!Enum.TryParse<Xbim.Ifc2x3.ActorResource.IfcRoleEnum>(value, ignoreCase: true, out var result))
				{
					ifcActorRole.UserDefinedRole = value;
					ifcActorRole.Role = Xbim.Ifc2x3.ActorResource.IfcRoleEnum.USERDEFINED;
				}
				else
				{
					ifcActorRole.Role = result;
				}
				ifcOrganization.Roles.Add(ifcActorRole);
			}
			else
			{
				if (!(DocumentInformation is Xbim.Ifc4.ExternalReferenceResource.IfcDocumentInformation))
				{
					throw new Exception("Invalid IFC schema");
				}
				Xbim.Ifc4.ActorResource.IfcOrganization ifcOrganization2 = DocumentInformation.DocumentOwner as Xbim.Ifc4.ActorResource.IfcOrganization;
				if (ifcOrganization2 == null)
				{
					ifcOrganization2 = DocumentInformation.Model.Instances.New<Xbim.Ifc4.ActorResource.IfcOrganization>();
					((Xbim.Ifc4.ExternalReferenceResource.IfcDocumentInformation)DocumentInformation).DocumentOwner = ifcOrganization2;
				}
				Xbim.Ifc4.ActorResource.IfcActorRole ifcActorRole2 = ifcOrganization2.Roles.FirstOrDefault();
				ifcOrganization2.Roles.Clear();
				if (ifcActorRole2 == null)
				{
					ifcActorRole2 = DocumentInformation.Model.Instances.New<Xbim.Ifc4.ActorResource.IfcActorRole>();
				}
				if (!Enum.TryParse<Xbim.Ifc4.Interfaces.IfcRoleEnum>(value, ignoreCase: true, out var result2))
				{
					ifcActorRole2.UserDefinedRole = value;
					ifcActorRole2.Role = Xbim.Ifc4.Interfaces.IfcRoleEnum.USERDEFINED;
				}
				else
				{
					ifcActorRole2.Role = result2;
				}
				ifcOrganization2.Roles.Add(ifcActorRole2);
			}
			transaction.Commit();
		}
	}

	public string OwningOrganisation
	{
		get
		{
			if (DocumentInformation.DocumentOwner is IIfcOrganization ifcOrganization)
			{
				return ifcOrganization.Name;
			}
			return null;
		}
		set
		{
			using ITransaction transaction = DocumentInfoTransaction;
			if (DocumentInformation is Xbim.Ifc2x3.ExternalReferenceResource.IfcDocumentInformation)
			{
				Xbim.Ifc2x3.ActorResource.IfcOrganization ifcOrganization = DocumentInformation.DocumentOwner as Xbim.Ifc2x3.ActorResource.IfcOrganization;
				if (ifcOrganization == null)
				{
					ifcOrganization = DocumentInformation.Model.Instances.New<Xbim.Ifc2x3.ActorResource.IfcOrganization>();
					((Xbim.Ifc2x3.ExternalReferenceResource.IfcDocumentInformation)DocumentInformation).DocumentOwner = ifcOrganization;
				}
				ifcOrganization.Name = value;
			}
			else
			{
				if (!(DocumentInformation is Xbim.Ifc4.ExternalReferenceResource.IfcDocumentInformation))
				{
					throw new Exception("Invalid IFC schema");
				}
				Xbim.Ifc4.ActorResource.IfcOrganization ifcOrganization2 = DocumentInformation.DocumentOwner as Xbim.Ifc4.ActorResource.IfcOrganization;
				if (ifcOrganization2 == null)
				{
					ifcOrganization2 = DocumentInformation.Model.Instances.New<Xbim.Ifc4.ActorResource.IfcOrganization>();
					((Xbim.Ifc4.ExternalReferenceResource.IfcDocumentInformation)DocumentInformation).DocumentOwner = ifcOrganization2;
				}
				ifcOrganization2.Name = value;
			}
			transaction.Commit();
		}
	}

	public XbimReferencedModel(IIfcDocumentInformation documentInformation)
		: this(documentInformation, "")
	{
	}

	public XbimReferencedModel(IIfcDocumentInformation documentInformation, string rootModelPath)
	{
		DocumentInformation = documentInformation;
		List<string> list = new List<string>();
		if (documentInformation.Model is IfcStore)
		{
			FileInfo fileInfo = new FileInfo((documentInformation.Model as IfcStore).FileName);
			list.Add(fileInfo.DirectoryName);
		}
		if (!string.IsNullOrEmpty(rootModelPath))
		{
			FileInfo fileInfo2 = new FileInfo(rootModelPath);
			list.Add(fileInfo2.DirectoryName);
		}
		string path = documentInformation.Model?.Header?.FileName?.Name;
		if (Path.IsPathRooted(path))
		{
			list.Add(Path.GetDirectoryName(path));
		}
		List<IfcURIReference?> list2 = DocumentInformation.HasDocumentReferences.Select((IIfcDocumentReference x) => x.Location).ToList();
		list2.Add(documentInformation.Name.ToString());
		string text = string.Empty;
		foreach (IfcURIReference? item in list2)
		{
			IfcURIReference? ifcURIReference = item;
			IfcURIReference? ifcURIReference2 = ifcURIReference;
			if (File.Exists(ifcURIReference2.HasValue ? ((string)ifcURIReference2.GetValueOrDefault()) : null))
			{
				ifcURIReference2 = ifcURIReference;
				text = (ifcURIReference2.HasValue ? ((string)ifcURIReference2.GetValueOrDefault()) : null);
				break;
			}
			ifcURIReference2 = item;
			if (Path.IsPathRooted(ifcURIReference2.HasValue ? ((string)ifcURIReference2.GetValueOrDefault()) : null))
			{
				continue;
			}
			foreach (string item2 in list)
			{
				ifcURIReference2 = item;
				ifcURIReference = Path.Combine(item2, ifcURIReference2.HasValue ? ((string)ifcURIReference2.GetValueOrDefault()) : null);
				ifcURIReference2 = ifcURIReference;
				if (File.Exists(ifcURIReference2.HasValue ? ((string)ifcURIReference2.GetValueOrDefault()) : null))
				{
					ifcURIReference2 = ifcURIReference;
					text = (ifcURIReference2.HasValue ? ((string)ifcURIReference2.GetValueOrDefault()) : null);
					goto end_IL_0221;
				}
			}
			continue;
			end_IL_0221:
			break;
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new XbimException($"Reference model not found for IfcDocumentInformation #{documentInformation.EntityLabel}.");
		}
		try
		{
			_model = IfcStore.Open(text);
		}
		catch (Exception inner)
		{
			throw new XbimException("Error opening referenced model: " + text, inner);
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing && Model != null)
			{
				Model.Dispose();
			}
			disposedValue = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	public void Close()
	{
		_model.Close();
	}
}
