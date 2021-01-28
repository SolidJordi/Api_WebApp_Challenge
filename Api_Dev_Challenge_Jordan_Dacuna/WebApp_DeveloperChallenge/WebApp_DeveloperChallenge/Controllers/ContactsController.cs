using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_DeveloperChallenge.Data;
using WebApp_DeveloperChallenge.Data.Configuration;

namespace WebApp_DeveloperChallenge.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
		private readonly ContactsDB _contactCollection;

		/// <summary>
		/// Constructor 
		/// </summary>
		public ContactsController(ContactsDB contactCollection)
		{
			_contactCollection = contactCollection;
		}

		/// <summary>
		/// Get all contacts
		/// </summary>
		[HttpGet]
		public IActionResult GetContact()
		{
			return Ok(_contactCollection.GetContacts());
		}

		/// <summary>
		/// Get contact by id
		/// </summary>
		/// <param name="id">id of the contact</param>
		/// <returns>StatusCode 200 if ok and 404 if something not found</returns>
		[HttpGet("{id:length(24)}", Name ="GetContact")]
		public IActionResult GetContactById(string id)
		{
			if (id == null) return NotFound();
			var contact = _contactCollection.GetContactById(id);
			if(contact == null) return NotFound();
			return Ok(contact);
		}

		/// <summary>
		/// Create a new contact
		/// </summary>
		/// <param name="newC">Informations of the new contact</param>
		/// <returns>StatusCode 201 if ok and 404 if something not found</returns>
		[HttpPost]
		public IActionResult CreateContact(Contact newC)
		{
			if (newC == null) return NotFound();
			_contactCollection.CreateContact(newC);
			return CreatedAtRoute("GetContact", new { id = newC.Id.ToString() }, newC);
		}

		/// <summary>
		/// Update informations of a contact
		/// </summary>
		/// <param name="id">Id of the contact</param>
		/// <param name="c">New information of the contact</param>
		/// <returns>StatusCode 204 if ok and 404 if something not found</returns>
		[HttpPut("{id:length(24)}")]
		public IActionResult UpdateContact(string id, Contact c)
		{
			if(id == null) return NotFound();
			var contact = _contactCollection.GetContactById(id);
			if(contact == null) return NotFound();
			if(c == null) return NotFound();
			_contactCollection.UptadeContact(id, c);
			return NoContent();
		}

		/// <summary>
		/// Delete a specific contact
		/// </summary>
		/// <param name="id">Id of the contact</param>
		/// <returns>StatusCode 204 if ok and 404 if something not found</returns>
		[HttpDelete("{id:length(24)}")]
		public IActionResult DeleteContactById(string id)
		{
			if (id == null) return NotFound();
			var contact = _contactCollection.GetContactById(id);
			if(contact == null) return NotFound();
			_contactCollection.DeleteContactByID(contact.Id);
			return NoContent();
		}

		//[HttpGet("contactSK/{id:length(24)}", Name = "GetSkillsByContactID")]
		//[Route("api/{id:int}")]
		//public IActionResult GetSkillsByContactID(string id)
		//{
		//	if (id == null) return NotFound();
		//	var skill = _contactCollection.GetSkillsByContactID(id);
		//	if (skill == null) return NotFound();
		//	return Ok(skill);
		//}
	}
}