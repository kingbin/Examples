using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NotTwitter.Models
{ 
    public class NotATweetRepository : INotATweetRepository
    {
        NotTwitterContext context = new NotTwitterContext();

        public IQueryable<NotATweet> All
        {
            get { return context.NotATweets; }
        }

        public IQueryable<NotATweet> AllIncluding(params Expression<Func<NotATweet, object>>[] includeProperties)
        {
            IQueryable<NotATweet> query = context.NotATweets;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public NotATweet Find(int id)
        {
            return context.NotATweets.Find(id);
        }

        public void InsertOrUpdate(NotATweet notatweet)
        {
            if (notatweet.ID == default(int)) {
                // New entity
                context.NotATweets.Add(notatweet);
            } else {
                // Existing entity
                context.Entry(notatweet).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var notatweet = context.NotATweets.Find(id);
            context.NotATweets.Remove(notatweet);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface INotATweetRepository : IDisposable
    {
        IQueryable<NotATweet> All { get; }
        IQueryable<NotATweet> AllIncluding(params Expression<Func<NotATweet, object>>[] includeProperties);
        NotATweet Find(int id);
        void InsertOrUpdate(NotATweet notatweet);
        void Delete(int id);
        void Save();
    }
}