namespace ScientificWorksOfTheDepartment
{
	public class Works
	{
		public string author_name = null;
		public string author_faculty = null;
		public string author_cathedra = null;
		public string author_laboratory = null;
		public string author_position = null;
		public string author_start_of_office = null;
		public string author_end_of_office = null;
		public string scientific_work = null;

		public string customer_name = null;
		public string customer_address = null;
		public string customer_subordination = null;
		public string customer_field_of_work = null;

		public Works()
		{

		}
		public Works(string[] data)
		{
			author_name = data[0];
			author_faculty = data[1];
			author_cathedra = data[2];
			author_laboratory = data[3];
			author_position = data[4];
			author_start_of_office = data[5];
			author_end_of_office = data[6];
			scientific_work = data[7];
			customer_name = data[8];
			customer_address = data[9];
			customer_subordination = data[10];
			customer_field_of_work = data[11];
		}

		public bool Compare(Works obj)
		{
			if ((author_name == obj.author_name) &&
				(author_faculty == obj.author_faculty) &&
				(author_cathedra == obj.author_cathedra) &&
				(author_laboratory == obj.author_laboratory) &&
				(author_position == obj.author_position) &&
				(author_start_of_office == obj.author_start_of_office) &&
				(author_end_of_office == obj.author_end_of_office) &&
				(scientific_work == obj.scientific_work) &&
				(customer_name == obj.customer_name) &&
				(customer_address == obj.customer_address) &&
				(customer_subordination == obj.customer_subordination) &&
				(customer_field_of_work == obj.customer_field_of_work))
				return true;
			else return false;
		}
	}
}
