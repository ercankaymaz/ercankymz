using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc;

public static class IfcStoreEditorExtensions
{
	public static IIfcApplication GetOrCreateApplication(this IModel model, XbimEditorCredentials editor, bool addDefaultRole = false)
	{
		if (editor == null)
		{
			return null;
		}
		IIfcApplication ifcApplication = (from a in model.Instances.OfType<IIfcApplication>()
			where a.ApplicationFullName == (IfcLabel)editor.ApplicationFullName
			where a.ApplicationIdentifier == (IfcIdentifier)editor.ApplicationIdentifier
			where a.Version == (IfcLabel)editor.ApplicationVersion
			select a).FirstOrDefault();
		if (ifcApplication != null)
		{
			return ifcApplication;
		}
		EntityCreator factory = new EntityCreator(model);
		return factory.Application(delegate(IIfcApplication a)
		{
			a.ApplicationDeveloper = model.Instances.OfType<IIfcOrganization>().FirstOrDefault((IIfcOrganization o) => o.Name == (IfcLabel)editor.ApplicationDevelopersName) ?? factory.Organization(delegate(IIfcOrganization o)
			{
				o.Name = editor.ApplicationDevelopersName;
				if (addDefaultRole)
				{
					o.Roles.Add(factory.ActorRole(delegate(IIfcActorRole r)
					{
						r.Role = IfcRoleEnum.USERDEFINED;
						r.UserDefinedRole = "Software Provider";
					}));
				}
			});
			a.ApplicationFullName = editor.ApplicationFullName;
			a.ApplicationIdentifier = editor.ApplicationIdentifier;
			a.Version = editor.ApplicationVersion;
		});
	}

	public static IIfcPersonAndOrganization GetOrCreateDefaultUser(this IModel model, XbimEditorCredentials editor)
	{
		if (editor == null)
		{
			return null;
		}
		EntityCreator entityCreator = new EntityCreator(model);
		IIfcPerson person = model.Instances.OfType<IIfcPerson>().FirstOrDefault((IIfcPerson p) => (editor.EditorsIdentifier != null && p.Identification == (IfcIdentifier?)(IfcIdentifier)editor.EditorsIdentifier) || (p.GivenName == (IfcLabel?)(IfcLabel)editor.EditorsGivenName && p.FamilyName == (IfcLabel?)(IfcLabel)editor.EditorsFamilyName)) ?? entityCreator.Person(delegate(IIfcPerson p)
		{
			p.Identification = editor.EditorsIdentifier;
			p.GivenName = editor.EditorsGivenName;
			p.FamilyName = editor.EditorsFamilyName;
		});
		IIfcOrganization organization = model.Instances.OfType<IIfcOrganization>().FirstOrDefault((IIfcOrganization o) => (editor.EditorsOrganisationIdentifier != null && o.Identification == (IfcIdentifier?)(IfcIdentifier)editor.EditorsOrganisationIdentifier) || o.Name == (IfcLabel)editor.EditorsOrganisationName) ?? entityCreator.Organization(delegate(IIfcOrganization o)
		{
			o.Name = editor.EditorsOrganisationName;
			o.Identification = editor.EditorsOrganisationIdentifier;
		});
		IIfcOrganization ifcOrganization = organization;
		IfcIdentifier? identification = ifcOrganization.Identification;
		IfcIdentifier valueOrDefault = identification.GetValueOrDefault();
		if (!identification.HasValue)
		{
			valueOrDefault = editor.EditorsOrganisationIdentifier;
			IfcIdentifier? identification2 = valueOrDefault;
			ifcOrganization.Identification = identification2;
		}
		return model.Instances.OfType<IIfcPersonAndOrganization>().FirstOrDefault((IIfcPersonAndOrganization po) => po.ThePerson == person && po.TheOrganization == organization) ?? entityCreator.PersonAndOrganization(delegate(IIfcPersonAndOrganization po)
		{
			po.TheOrganization = organization;
			po.ThePerson = person;
		});
	}
}
