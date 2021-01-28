using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_DeveloperChallenge.Data.Configuration;

namespace WebApp_DeveloperChallenge.Data
{
	public class SkillsDB
	{
		private int _tableIndex = 1;
		private readonly IMongoCollection<Skill> _skillsCollection;

		/// <summary>
		/// Constructor of the SkillDB class
		/// </summary>
		/// <param name="settings">Settings of the database (name, collectionName and connection string</param>
		public SkillsDB(IDatabaseSettings settings)
		{
			var mdbClient = new MongoClient(settings.ConnectionString);
			var database = mdbClient.GetDatabase(settings.DatabaseName);
			_skillsCollection = database.GetCollection<Skill>(settings.CollectionNames.ElementAt(_tableIndex));
		}
		
		/// <summary>
		/// Get all skills
		/// </summary>
		/// <returns>List of all skills</returns>
		public List<Skill> GetSkill()
		{
			return _skillsCollection.Find(book => true).ToList();
		}
		
		/// <summary>
		/// Get a specific skill
		/// </summary>
		/// <param name="id">Id of the skill</param>
		/// <returns>A specific skill</returns>
		public Skill GetSkillById(string id)
		{
			return _skillsCollection.Find<Skill>(skill => skill.Id == id).FirstOrDefault();
		}
		
		/// <summary>
		/// Create a new skill entry in the database
		/// </summary>
		/// <param name="skill">Informations of the skill</param>
		/// <returns>Created skill</returns>
		public Skill CreateSkill(Skill skill)
		{
			_skillsCollection.InsertOne(skill);
			return skill;
		}
		
		/// <summary>
		/// Modify skill informations
		/// </summary>
		/// <param name="id">Id of the skill</param>
		/// <param name="newInfosSkill">Informations of the skill</param>
		public void UpdateSkill(string id, Skill newInfosSkill)
		{
			newInfosSkill.Id = id;
			_skillsCollection.ReplaceOne(skill => skill.Id == id, newInfosSkill);
		}
		
		/// <summary>
		/// Delete a skill by skill variable reference
		/// </summary>
		/// <param name="skillToDel">Id of the skill</param>
		public void DeleteSkill(Skill skillToDel)
		{
			_skillsCollection.DeleteOne(skill => skill.Id == skillToDel.Id);
		}
		
		/// <summary>
		/// Delete a skill by id
		/// </summary>
		/// <param name="id">Id of the skill</param>
		public void DeleteSkillByID(string id)
		{
			_skillsCollection.DeleteOne(skill => skill.Id == id);
		}
	}
}
