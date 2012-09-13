using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NotTwitter.Models;

namespace NotTwitter.Controllers
{
	public class NotATwitterAPIController : ApiController
	{
		private readonly INotATweetRepository notatweetRepository;
		public NotATwitterAPIController( )
		{
			//System.Data.Entity.Database.SetInitializer( new NotTwitter.Models.NotTwitterContextInitializer() );
			//System.Data.Entity.Database.SetInitializer( new System.Data.Entity.DropCreateDatabaseIfModelChanges<NotTwitter.Models.NotTwitterContext>() );

			this.notatweetRepository = new NotATweetRepository();
		}

		//public NotATwitterAPIController( INotATweetRepository notatweetRepository )
		//    : base( new NotATweetRepository() )
		//{
		//    this.notatweetRepository = notatweetRepository;
		//}

		// GET /api/notatwitterapi
		public IQueryable<NotATweet> Get()
		{
			return notatweetRepository.All;
		}

		// GET /api/notatwitterapi/5
		public NotATweet Get( int id )
		{
			var notatweet = notatweetRepository.Find( id );
			if( notatweet == null )
				throw new HttpResponseException( HttpStatusCode.NotFound );
			return notatweet;
		}

		// POST /api/notatwitterapi
		public HttpResponseMessage Post( NotATweet value )
		{
			if( ModelState.IsValid ) {
				notatweetRepository.InsertOrUpdate( value );
				notatweetRepository.Save();

				//Created!
				//var response = new HttpResponseMessage<NotATweet>( value, HttpStatusCode.Created );
				HttpResponseMessage response = Request.CreateResponse( HttpStatusCode.Created, value );
				
				//Let them know where the new NotATweet is
				string uri = Url.Route( null, new { id = value.ID } );
				response.Headers.Location = new Uri( Request.RequestUri, uri );

				return response;

			}
			throw new HttpResponseException( HttpStatusCode.BadRequest );
		}

		// PUT /api/notatwitterapi/5
		public HttpResponseMessage Put( int id, NotATweet value )
		{
			if( ModelState.IsValid ) {
				notatweetRepository.InsertOrUpdate( value );
				notatweetRepository.Save();
				return new HttpResponseMessage( HttpStatusCode.NoContent );
			}
			throw new HttpResponseException( HttpStatusCode.BadRequest );
		}

		// DELETE /api/notatwitterapi/5
		public void Delete( int id )
		{
			var notatweet = notatweetRepository.Find( id );
			if( notatweet == null )
				throw new HttpResponseException( HttpStatusCode.NotFound );

			notatweetRepository.Delete( id );
		}
	}
}
