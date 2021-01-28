using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DeveloperChallenge
{
	public class Skill
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)] // add this to say that id is use by mongoDB
		public string Id { get; set; }
		public string Name { get; set; }
		public ICollection<string> IdContact { get; set; }
	}
}
