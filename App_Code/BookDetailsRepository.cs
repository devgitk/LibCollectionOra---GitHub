using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 Name: Keshav Sridhara
 Student No: 300948195
 */

/// <summary>
/// Summary description for BookDetailsRepository
/// </summary>
public class BookDetailsRepository
{
	public BookDetailsRepository()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<BookDetails> GetAllBooks()
    {
        return (List<BookDetails>)HttpContext.Current.Application["bookDetailsRep"];
    }
}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
