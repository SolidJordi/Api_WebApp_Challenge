using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_DeveloperChallenge.Data;

namespace WebApp_DeveloperChallenge.Controllers
{
	[Route("api/skills")]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly SkillsDB _skillCollection;

		/// <summary>
		/// Constructor
		/// </summary>
		public SkillsController(SkillsDB skillCollection)
		{
			_skillCollection = skillCollection;
		}

		/// <summary>
		/// Get all skills
		/// </summary>
		/// <returns>StatusCode 200 if ok and 404 if something not found</returns>
		[HttpGet]
		public IActionResult GetSkill()
		{
			return Ok(_skillCollection.GetSkill());
		}

		/// <summary>
		/// Get a specific skill
		/// </summary>
		/// <param name="id">Id of the skill</param>
		/// <returns>StatusCode 204 if ok and 404 if something not found</returns>
		[HttpGet("{id:length(24)}", Name = "GetSkill")]
		public IActionResult GetSkillById(string id)
		{
			if (id == null) return NotFound();
			var skill = _skillCollection.GetSkillById(id);
			if (skill == null) return NotFound();
			return Ok(skill);
		}

		/// <summary>
		/// Create a new skill
		/// </summary>
		/// <param name="newS">Information of the new skill</param>
		/// <returns>StatusCode 201 if ok and 404 if something not found</returns>
		[HttpPost]
		public IActionResult CreateSkill(Skill newS)
		{
			if (newS == null) return NotFound();
			_skillCollection.CreateSkill(newS);
			return CreatedAtRoute("GetContact", new { id = newS.Id.ToString() }, newS);
		}

		/// <summary>
		/// Update a new skill
		/// </summary>
		/// <param name="id">Id of the skill</param>
		/// <param name="s">Information of the skill</param>
		/// <returns>StatusCode 204 if ok and 404 if something not found</returns>
		[HttpPut("{id:length(24)}")]
		public IActionResult UpdateSkill(string id, Skill s)
		{
			if (id == null) return NotFound();
			var skill = _skillCollection.GetSkillById(id);
			if (skill == null) return NotFound();
			if (s == null) return NotFound();
			_skillCollection.UpdateSkill(id, s);
			return NoContent();
		}

		/// <summary>
		/// Delete a skill by id
		/// </summary>
		/// <param name="id">Id of the skill</param>
		/// <returns>StatusCode 204 if ok and 404 if something not found</returns>
		[HttpDelete("{id:length(24)}")]
		public IActionResult DeleteSkill(string id)
		{
			if (id == null) return NotFound();
			var skill = _skillCollection.GetSkillById(id);
			if (skill == null) return NotFound();
			_skillCollection.DeleteSkillByID(skill.Id);
			return NoContent();
		}
	}
}