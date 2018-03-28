<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <!--xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" >-->

    <!--<xsl:output method="xml" indent="yes"/> -->
    <xsl:output method="html" />
  <!-- 
		Main template to kick off processing 
	-->
  <xsl:template match="/">
    <html>
      <head>
        <title>
          Purchase Request:  <xsl:value-of select="/PRRECORD/PR_Number"/>
        </title>
        <style>
          body,td {font-family:Tahoma,Arial; font-size:9pt;}
        </style>
      </head>
      <body>
        <p/>
        <b>Hello How are you?:</b>
        <br/>
        <br/>
        First Name: <xsl:value-of select="/PRRECORD/FirstName"/>
        <br/>
        Last Name: <xsl:value-of select="/PRRECORD/LastName"/>
        <br/>
        Purchase Number: <xsl:value-of select="/PRRECORD/PR_Number"/>
        <br/>
        Amount: <xsl:value-of select="/PRRECORD/Amount"/>
        <br/>
        Date: <xsl:value-of select="/PRRECORD/Date"/>
        <br/>
        Department: <xsl:value-of select="/PRRECORD/Department"/>
      </body>
    </html>
  </xsl:template>
    <!--<xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>-->
</xsl:stylesheet>
