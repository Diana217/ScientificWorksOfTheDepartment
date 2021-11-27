using System.Collections.Generic;
using System.Xml;

namespace ScientificWorksOfTheDepartment
{
	class SAX : IStrategy
	{
		private List<Works> result_list = null;
		public List<Works> AnalyzeFile(Works search, string path)
		{
			XmlReader reader = XmlReader.Create(path);
			List<Works> result = new List<Works>();
			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						if(reader.Name == "work")
						{
							Works find = new Works();
							while (reader.MoveToNextAttribute())
							{
								if (reader.Name == "AUTHOR_NAME")
									find.author_name = reader.Value;
								if (reader.Name == "AUTHOR_FACULTY")
									find.author_faculty = reader.Value;
								if (reader.Name == "AUTHOR_CATHEDRA")
									find.author_cathedra = reader.Value;
								if (reader.Name == "AUTHOR_LABORATORY")
									find.author_laboratory = reader.Value;
								if (reader.Name == "AUTHOR_POSITION")
									find.author_position = reader.Value;
								if (reader.Name == "AUTHOR_START_OF_OFFICE")
									find.author_start_of_office = reader.Value;
								if (reader.Name == "AUTHOR_END_OF_OFFICE")
									find.author_end_of_office = reader.Value;
								if (reader.Name == "SCIENTIFIC_WORK")
									find.scientific_work = reader.Value;
								if (reader.Name == "CUSTOMER_NAME")
									find.customer_name = reader.Value;
								if (reader.Name == "CUSTOMER_ADDRESS")
									find.customer_address = reader.Value;
								if (reader.Name == "CUSTOMER_SUBORDINATION")
									find.customer_subordination = reader.Value;
								if (reader.Name == "CUSTOMER_FIELD_OF_WORK")
									find.customer_field_of_work = reader.Value;
							}
							result.Add(find);
						}
						break;
				}
			}
			result_list = Filter(result, search);
			return result_list;
		}

		private List<Works> Filter(List<Works> works_list, Works work)
		{
			List<Works> results = new List<Works>();
			if(works_list != null)
			{
				foreach(Works elem in works_list)
				{
					if((work.author_name == elem.author_name || work.author_name == null) &&
						(work.author_faculty == elem.author_faculty || work.author_faculty == null) &&
						(work.author_cathedra == elem.author_cathedra || work.author_cathedra == null) &&
						(work.author_laboratory == elem.author_laboratory || work.author_laboratory == null) &&
						(work.author_position == elem.author_position || work.author_position == null) &&
						(work.author_start_of_office == elem.author_start_of_office || work.author_start_of_office == null) &&
						(work.author_end_of_office == elem.author_end_of_office || work.author_end_of_office == null) &&
						(work.scientific_work == elem.scientific_work || work.scientific_work == null) &&
						(work.customer_name == elem.customer_name || work.customer_name == null) &&
						(work.customer_address == elem.customer_address || work.customer_address == null) &&
						(work.customer_subordination == elem.customer_subordination || work.customer_subordination == null) &&
						(work.customer_field_of_work == elem.customer_field_of_work || work.customer_field_of_work == null))
					{
						results.Add(elem);
					}
				}
			}
			return results;
		}
	}
}
