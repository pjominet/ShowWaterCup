using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using ShowWaterCup.Services.Entities;

namespace ShowWaterCup.Services.Repositories
{
    public class BaseRepository<TContext> where TContext : DbContext
    {
        private readonly Func<TContext> _contextFactory;
        private TContext _context;
        protected TContext Context => _context ?? (_context = _contextFactory());

        protected BaseRepository(TContext context)
        {
            _context = context;
            _contextFactory = () => context;
        }

        protected BaseRepository(Func<TContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        protected TResult Query<TEntity, TResult>(Func<IQueryable<TEntity>, TResult> query)
            where TEntity : class
        {
            using (var context = _contextFactory())
            {
                return query(context.Set<TEntity>());
            }
        }

        protected TResult ReadOnlyQuery<TEntity, TResult>(Func<IQueryable<TEntity>, TResult> query)
            where TEntity : class
        {
            using (var context = _contextFactory())
            {
                return query(context.Set<TEntity>().AsNoTracking());
            }
        }

        protected void Execute(Action<TContext> command)
        {
            using (var context = _contextFactory())
            {
                command(context);
            }
        }

        protected void Execute<TEntity>(Action<DbSet<TEntity>, Action> command) where TEntity : class
        {
            using (var context = _contextFactory())
            {
                command(context.Set<TEntity>(), () => Save(context));
            }
        }

        protected TResult Execute<TEntity, TResult>(Func<DbSet<TEntity>, Action, TResult> command) where TEntity : class
        {
            using (var context = _contextFactory())
            {
                return command(context.Set<TEntity>(), () => Save(context));
            }
        }

        public T Add<T>(T entity)
            where T : class
        {
            return Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> AddRange<T>(IEnumerable<T> entities)
            where T : class
        {
            return Context.Set<T>().AddRange(entities);
        }

        public bool Any<T>(Expression<Func<T, bool>> predicate, params string[] includes)
           where T : class
        {
            return GetAll(predicate, includes).Any();
        }

        public T Attach<T>(T entity)
            where T : class
        {
            return Context.Set<T>().Attach(entity);
        }

        public T Remove<T>(T entity)
            where T : class
        {
            return Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> RemoveRange<T>(IEnumerable<T> entities)
                    where T : class
        {
            return Context.Set<T>().RemoveRange(entities);
        }

        public T GetFirst<T>(Expression<Func<T, bool>> predicate)
            where T : class
        {
            return GetFirst(predicate, null);
        }

        public T GetFirst<T>(Expression<Func<T, bool>> predicate, params string[] includes)
            where T : class
        {
            return GetAll(predicate, includes).First();
        }

        public T GetFirstOrDefault<T>(Expression<Func<T, bool>> predicate, params string[] includes)
            where T : class
        {
            return GetAll(predicate, includes).FirstOrDefault();
        }

        public IQueryable<T> GetAll<T>(params string[] includes)
            where T : class
        {
            return GetAll<T>(null, includes);
        }

        public T GetMaxId<T>(Expression<Func<T, int>> predicate) where T : class
        {
            IQueryable<T> dbQuery = Context.Set<T>();

            return dbQuery.OrderByDescending(predicate).FirstOrDefault();

        }


        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate, params string[] includes)
           where T : class
        {
            IQueryable<T> dbQuery = Context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    dbQuery = dbQuery.Include(include);

            if (predicate != null)
                dbQuery = dbQuery.Where(predicate);

            return dbQuery;
        }

        private static void Save(TContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var message = dbEx
                    .EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Aggregate($"{dbEx.Message}{Environment.NewLine}",
                        (acc, error) => $"{acc}[{error.PropertyName}] => {error.ErrorMessage}{Environment.NewLine}");

                throw new FormatException(message, dbEx);
            }
        }

        public void SaveChanges() => Save(Context);
    }
}