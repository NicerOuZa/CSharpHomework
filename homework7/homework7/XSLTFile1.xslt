<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
      <html>
        <body>
          <h2>订单明细</h2>
          <table border="1">
            <tr bgcolor="#9acd32">
              <th>订单号</th>
              <th>商品名称</th>
              <th>客户</th>
              <th>金额</th>
              <th>手机号</th>
            </tr>
            <xsl:for-each select="ArrayOfOrder/Order">
              <tr>
                <td>
                  <xsl:value-of select="OrderNum"/>
                </td>
                <td>
                  <xsl:value-of select="GoodName"/>
                </td>
                <td>
                  <xsl:value-of select="Client"/>
                </td>
                <td>
                  <xsl:value-of select="OrderSum"/>
                </td>
                <td>
                  <xsl:value-of select="PhoneNum"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
