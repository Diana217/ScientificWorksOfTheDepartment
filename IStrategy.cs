using System.Collections.Generic;

namespace ScientificWorksOfTheDepartment
{
	public interface IStrategy
	{
		List<Works> AnalyzeFile(Works search, string path);
	}
}
