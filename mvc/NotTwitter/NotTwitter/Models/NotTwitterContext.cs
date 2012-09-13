using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NotTwitter.Models
{
    public class NotTwitterContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<NotTwitter.Models.NotTwitterContext>());

		public DbSet<NotTwitter.Models.NotATweet> NotATweets { get; set; }
	}

	public class NotTwitterContextInitializer
	: DropCreateDatabaseAlways<NotTwitterContext>
	{
		protected override void Seed( NotTwitterContext context )
		{
			//create sample data and attach it to the context.
			new List<NotATweet>
			{
				new NotATweet { ID = 0, Published=new DateTime(2012,06,01), Text="Test Tweet 1", Username="kingbin"},
				new NotATweet { ID = 0, Published=new DateTime(2012,07,01), Text="Test Tweet 2", Username="kingbin"},
				new NotATweet { ID = 0, Published=new DateTime(2012,08,01), Text="Test Tweet 3", Username="kingbin"}
			}.ForEach( t => context.NotATweets.Add( t ) );

			base.Seed( context );
		}
	}
}