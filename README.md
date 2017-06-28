# HelloWorldExtensibleAPI

## WebAPI-based Hello World web service with MVC and console application examples

## Components
  * _HelloWorldExtensibleAPI_: 
    * WebAPI that returns text for two functions:
	  * Hello World! ```/api/Hello```
	  * An overridden/custom Hello [anyone] that takes input! ```/api/Hello?audience={0}```
	* MVC site that calls API functions via AJAX
	  * Uses responsive Bootstrap and jQuery
 * HelloWorldExtensibleDB
   * SQL Server Data Tools project (SSDT) that contains potential table DDL for MSSQL HelloWorldExtensibleDB
   * Connectionstring for database added to site's Web.Config above and EntityFramework6 added

## Hosting
  * Site and API are hosted [here](http://www.bairmon.com).