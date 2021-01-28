using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_DeveloperChallenge.Entities;

namespace WebApp_DeveloperChallenge
{
	public class Contact
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)] // add this to say that id is use by mongoDB
		public string Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Fullname { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public ICollection<ContactSkills> Skills { get; set; }
	}
}
