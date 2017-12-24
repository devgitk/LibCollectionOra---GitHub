<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        List<BookDetails> bookDetailsReps = new List<BookDetails>();
        Application["bookDetailsRep"] = bookDetailsReps;
        /*bookDetailsReps.Add(new BookDetails { Name = "Name 1", Author = "Author 1", ISBNNumber = 123456 });
        bookDetailsReps.Add(new BookDetails { Name = "Name 2", Author = "Author 2", ISBNNumber = 345678 });*/

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
