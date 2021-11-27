using System.Collections.Generic;
using System.Xml;

namespace ScientificWorksOfTheDepartment
{
	class DOM : IStrategy
	{
		XmlDocument document = new XmlDocument();
		public List<Works> AnalyzeFile(Works search, string path)
		{
			document.Load(path);
			List<List<Works>> info = new List<List<Works>>();

			if (search.author_name == null && search.author_faculty == null &&
				search.author_cathedra == null && search.author_laboratory == null &&
				search.author_position == null && search.author_start_of_office == null &&
				search.author_end_of_office == null && search.scientific_work == null &&
				search.customer_name == null && search.customer_address == null &&
				search.customer_subordination == null && search.customer_field_of_work == null)
			{
				return ErrorCatch(document);
			}

			if (search.author_name != null)
				info.Add(SearchByAttribute("work", "AUTHOR_NAME", search.author_name, document));
			if (search.author_faculty != null)
				info.Add(SearchByAttribute("work", "AUTHOR_FACULTY", search.author_faculty, document));
			if (search.author_cathedra != null)
				info.Add(SearchByAttribute("work", "AUTHOR_CATHEDRA", search.author_cathedra, document));
			if (search.author_laboratory != null)
				info.Add(SearchByAttribute("work", "AUTHOR_LABORATORY", search.author_laboratory, document));
			if (search.author_position != null)
				info.Add(SearchByAttribute("work", "AUTHOR_POSITION", search.author_position, document));
			if (search.author_start_of_office != null)
				info.Add(SearchByAttribute("work", "AUTHOR_START_OF_OFFICE", search.author_start_of_office, document));
			if (search.author_end_of_office != null)
				info.Add(SearchByAttribute("work", "AUTHOR_END_OF_OFFICE", search.author_end_of_office, document));
			if (search.scientific_work != null)
				info.Add(SearchByAttribute("work", "SCIENTIFIC_WORK", search.scientific_work, document));
			if (search.customer_name != null)
				info.Add(SearchByAttribute("work", "CUSTOMER_NAME", search.customer_name, document));
			if (search.customer_address != null)
				info.Add(SearchByAttribute("work", "CUSTOMER_ADDRESS", search.customer_address, document));
			if (search.customer_subordination != null)
				info.Add(SearchByAttribute("work", "CUSTOMER_SUBORDINATION", search.customer_subordination, document));
			if (search.customer_field_of_work != null)
				info.Add(SearchByAttribute("work", "CUSTOMER_FIELD_OF_WORK", search.customer_field_of_work, document));

			return Cross(info, search);
		}

		public List<Works> SearchByAttribute(string node_name, string attribute, string temp, XmlDocument doc)
		{
			List<Works> find = new List<Works>();
			if (temp != null)
			{
				XmlNodeList node_list = doc.SelectNodes("//" + node_name + "[@" + attribute + "=\"" + temp + "\"]");
				foreach (XmlNode x in node_list)
				{
					find.Add(Info(x));
				}
			}
			return find;
		}

		public List<Works> ErrorCatch(XmlDocument doc)
		{
			List<Works> result = new List<Works>();
			XmlNodeList node_list = doc.SelectNodes("//" + "work");
			foreach (XmlNode elem in node_list)
			{
				result.Add(Info(elem));
			}
			return result;
		}

		public Works Info(XmlNode node)
		{
			Works search = new Works();
			search.author_name = node.Attributes.GetNamedItem("AUTHOR_NAME").Value;
			search.author_faculty = node.Attributes.GetNamedItem("AUTHOR_FACULTY").Value;
			search.author_cathedra = node.Attributes.GetNamedItem("AUTHOR_CATHEDRA").Value;
			search.author_laboratory = node.Attributes.GetNamedItem("AUTHOR_LABORATORY").Value;
			search.author_position = node.Attributes.GetNamedItem("AUTHOR_POSITION").Value;
			search.author_start_of_office = node.Attributes.GetNamedItem("AUTHOR_START_OF_OFFICE").Value;
			search.author_end_of_office = node.Attributes.GetNamedItem("AUTHOR_END_OF_OFFICE").Value;
			search.scientific_work = node.Attributes.GetNamedItem("SCIENTIFIC_WORK").Value;
			search.customer_name = node.Attributes.GetNamedItem("CUSTOMER_NAME").Value;
			search.customer_address = node.Attributes.GetNamedItem("CUSTOMER_ADDRESS").Value;
			search.customer_subordination = node.Attributes.GetNamedItem("CUSTOMER_SUBORDINATION").Value;
			search.customer_field_of_work = node.Attributes.GetNamedItem("CUSTOMER_FIELD_OF_WORK").Value;

			return search;
		}

		public List<Works> Cross(List<List<Works>> works_list, Works temp)
		{
			List<Works> result = new List<Works>();
			List<Works> clear = CheckNodes(works_list, temp);
			foreach (Works elem in clear)
			{
				bool isIn = false;
				foreach (Works w in result)
				{
					if (w.Compare(elem))
					{
						isIn = true;
					}
				}
				if (!isIn)
				{
					result.Add(elem);
				}
			}
			return result;
		}

		public List<Works> CheckNodes(List<List<Works>> works, Works temp)
		{
			List<Works> newresult = new List<Works>();
			foreach (List<Works> elem in works)
			{
				foreach (Works w in elem)
				{
					if ((temp.author_name == w.author_name || temp.author_name == null) &&
						(temp.author_faculty == w.author_faculty || temp.author_faculty == null) &&
						(temp.author_cathedra == w.author_cathedra || temp.author_cathedra == null) &&
						(temp.author_laboratory == w.author_laboratory || temp.author_laboratory == null) &&
						(temp.author_position == w.author_position || temp.author_position == null) &&
						(temp.author_start_of_office == w.author_start_of_office || temp.author_start_of_office == null) &&
						(temp.author_end_of_office == w.author_end_of_office || temp.author_end_of_office == null) &&
						(temp.scientific_work == w.scientific_work || temp.scientific_work == null) &&
						(temp.customer_name == w.customer_name || temp.customer_name == null) &&
						(temp.customer_address == w.customer_address || temp.customer_address == null) &&
						(temp.customer_subordination == w.customer_subordination || temp.customer_subordination == null) &&
						(temp.customer_field_of_work == w.customer_field_of_work || temp.customer_field_of_work == null))
					{
						newresult.Add(w);
					}
				}
			}
			return newresult;
		}
	}
}
