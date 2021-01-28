using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_DeveloperChallenge.Data.Configuration;

namespace WebApp_DeveloperChallenge.Data
{
	public class ContactsDB
	{
		private readonly IMongoCollection<Contact> _contactsCollection;
		private int _tableIndex = 0;

		/// <summary>
		/// Constructor of the ContactsDB class
		/// </summary>
		/// <param name="settings">Settings of the database (name, collectionName and connection string</param>
		public ContactsDB(IDatabaseSettings settings)
		{
			var mdbClient = new MongoClient(settings.ConnectionString);
			var database = mdbClient.GetDatabase(settings.DatabaseName);
			_contactsCollection = database.GetCollection<Contact>(settings.CollectionNames.ElementAt(_tableIndex));
		}

		/// <summary>
		/// Get all contacts infos
		/// </summary>
		/// <returns>List of all contacts</returns>
		public List<Contact> GetContacts()
		{
			return _contactsCollection.Find(book => true).ToList();
		}

		/// <summary>
		/// Get a specific contact by his id
		/// </summary>
		/// <param name="id">Id of the contact</param>
		/// <returns>A specific contact</returns>
		public Contact GetContactById(string id)
		{
			return _contactsCollection.Find<Contact>(contact => contact.Id == id).FirstOrDefault();
		}

		/// <summary>
		/// Get all skill of a specific contact
		/// </summary>
		/// <param name="id">Id of the contact</param>
		/// <returns>A list of skills of a contact</returns>
		public List<Contact> GetSkillsByContactID(string id)
		{
			var filter = Builders<Contact>.Filter.Eq(x => x.Id, id);
			var contact = Builders<Contact>.Projection.Include(x => x.Skills);
			var skills = _contactsCollection.Find(filter).Project(contact).ToList();
			return null;

			//return _contactsCollection.Find<Contact>(contact => contact.Id == id).FirstOrDefault();
		}

		/// <summary>
		/// Create a new contact entry in the database
		/// </summary>
		/// <param name="contact">Informations of the contact</param>
		/// <returns>Created contact</returns>
		public Contact CreateContact(Contact contact)
		{
			_contactsCollection.InsertOne(contact);
			return contact;
		}

		/// <summary>
		/// Modify contact informations
		/// </summary>
		/// <param name="id">Id of the contact</param>
		/// <param name="newInfosContact">Informations of the contact</param>
		public void UptadeContact(string id, Contact newInfosContact)
		{
			newInfosContact.Id = id;
			_contactsCollection.ReplaceOne(contact => contact.Id == id, newInfosContact);
		}

		/// <summary>
		/// Delete a contact by Contact variable reference
		/// </summary>
		/// <param name="contactToDel">Id of the contact</param>
		public void DeleteContact(Contact contactToDel)
		{
			_contactsCollection.DeleteOne(contact => contact.Id == contactToDel.Id);
		}

		/// <summary>
		/// Delete a contact by id
		/// </summary>
		/// <param name="contactToDel">Id of the contact</param>
		public void DeleteContactByID(string id)
		{
			_contactsCollection.DeleteOne(contact => contact.Id == id);
		}
	}
}
