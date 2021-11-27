<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
				xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output
		method="html"></xsl:output>
	<xsl:template match="/">
		<html>
			<body>
				<table border ="1">
					<TR>
						<th>AUTHOR_NAME</th>
						<th>AUTHOR_FACULTY</th>
						<th>AUTHOR_CATHEDRA</th>
						<th>AUTHOR_LABORATORY</th>
						<th>AUTHOR_POSITION</th>
						<th>AUTHOR_START_OF_OFFICE</th>
						<th>AUTHOR_END_OF_OFFICE</th>
						<th>SCIENTIFIC_WORK</th>
						<th>CUSTOMER_NAME</th>
						<th>CUSTOMER_ADDRESS</th>
						<th>CUSTOMER_SUBORDINATION</th>
						<th>CUSTOMER_FIELD_OF_WORK</th>
					</TR>
					<xsl:for-each select ="ScientificWorksOfTheDepartment/work">
						<tr>
							<td>
								<xsl:value-of select ="@AUTHOR_NAME"/>
							</td>
							<td>
								<xsl:value-of select ="@AUTHOR_FACULTY"/>
							</td>
							<td>
								<xsl:value-of select ="@AUTHOR_CATHEDRA"/>
							</td>
							<td>
								<xsl:value-of select ="@AUTHOR_LABORATORY"/>
							</td>
							<td>
								<xsl:value-of select ="@AUTHOR_POSITION"/>
							</td>
							<td>
								<xsl:value-of select ="@AUTHOR_START_OF_OFFICE"/>
							</td>
							<td>
								<xsl:value-of select ="@AUTHOR_END_OF_OFFICE"/>
							</td>
							<td>
								<xsl:value-of select ="@SCIENTIFIC_WORK"/>
							</td>
							<td>
								<xsl:value-of select ="@CUSTOMER_NAME"/>
							</td>
							<td>
								<xsl:value-of select ="@CUSTOMER_ADDRESS"/>
							</td>
							<td>
								<xsl:value-of select ="@CUSTOMER_SUBORDINATION"/>
							</td>
							<td>
								<xsl:value-of select ="@CUSTOMER_FIELD_OF_WORK"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>