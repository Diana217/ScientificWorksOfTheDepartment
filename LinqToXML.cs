using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ScientificWorksOfTheDepartment
{
	class LinqToXML : IStrategy
	{
		List<Works> find = null;
		XDocument document = new XDocument();

		public List<Works> AnalyzeFile(Works search, string path)
		{
			document = XDocument.Load(@path);
			find = new List<Works>();
			List<XElement> matches = (from value in document.Descendants("work")
									  where (search.author_name == null || search.author_name == value.Attribute("AUTHOR_NAME").Value) &&
									  (search.author_faculty == null || search.author_faculty == value.Attribute("AUTHOR_FACULTY").Value) &&
									  (search.author_cathedra == null || search.author_cathedra == value.Attribute("AUTHOR_CATHEDRA").Value) &&
									  (search.author_laboratory == null || search.author_laboratory == value.Attribute("AUTHOR_LABORATORY").Value) &&
									  (search.author_position == null || search.author_position == value.Attribute("AUTHOR_POSITION").Value) &&
									  (search.author_start_of_office == null || search.author_start_of_office == value.Attribute("AUTHOR_START_OF_OFFICE").Value) &&
									  (search.author_end_of_office == null || search.author_end_of_office == value.Attribute("AUTHOR_END_OF_OFFICE").Value) &&
									  (search.scientific_work == null || search.scientific_work == value.Attribute("SCIENTIFIC_WORK").Value) &&
									  (search.customer_name == null || search.customer_name == value.Attribute("CUSTOMER_NAME").Value) &&
									  (search.customer_address == null || search.customer_address == value.Attribute("CUSTOMER_ADDRESS").Value) &&
									  (search.customer_subordination == null || search.customer_subordination == value.Attribute("CUSTOMER_SUBORDINATION").Value) &&
									  (search.customer_field_of_work == null || search.customer_field_of_work == value.Attribute("CUSTOMER_FIELD_OF_WORK").Value)
									  select value).ToList();

			foreach(XElement match in matches)
			{
				Works result = new Works();
				result.author_name = match.Attribute("AUTHOR_NAME").Value;
				result.author_faculty = match.Attribute("AUTHOR_FACULTY").Value;
				result.author_cathedra = match.Attribute("AUTHOR_CATHEDRA").Value;
				result.author_laboratory = match.Attribute("AUTHOR_LABORATORY").Value;
				result.author_position = match.Attribute("AUTHOR_POSITION").Value;
				result.author_start_of_office = match.Attribute("AUTHOR_START_OF_OFFICE").Value;
				result.author_end_of_office = match.Attribute("AUTHOR_END_OF_OFFICE").Value;
				result.scientific_work = match.Attribute("SCIENTIFIC_WORK").Value;
				result.customer_name = match.Attribute("CUSTOMER_NAME").Value;
				result.customer_address = match.Attribute("CUSTOMER_ADDRESS").Value;
				result.customer_subordination = match.Attribute("CUSTOMER_SUBORDINATION").Value;
				result.customer_field_of_work = match.Attribute("CUSTOMER_FIELD_OF_WORK").Value;
				find.Add(result);
			}
			return find;
		}
	}
}
