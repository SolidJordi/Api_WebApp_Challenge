using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DeveloperChallenge.Data.Configuration
{
	public class DatabaseSettings : IDatabaseSettings
	{
		public string DatabaseName { get; set; }
		public ICollection<string> CollectionNames { get; set; }
		public string ConnectionString { get; set; }
	}

	public interface IDatabaseSettings
	{
		string DatabaseName { get; set; }
		ICollection<string> CollectionNames { get; set; }
		string ConnectionString { get; set; }
	}
}
