using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceOverview.Data
{
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;

    /// <summary>
    /// A base database context to use for standard projects.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDbContext"/> class.
        /// </summary>
        protected BaseDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        protected BaseDbContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Gets the set of entities represented in the database.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <returns>A <see cref="DbSet"/> for the requested entity</returns>
        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        /// <summary>
        /// Gets a set of entities represented in the database.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <returns>A <see cref="DbSet"/> for the requested entity</returns>
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>An enumerable of entities</returns>
        public int SqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>An enumerable of entities</returns>
        public IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TEntity>(sql, parameters);
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>An enumerable of entities</returns>
        public Task<int> SqlCommandAsync(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        /// <summary>
        /// Execute a raw sql query that returns an enumerable of entities.
        /// </summary>
        /// <typeparam name="TEntity">The entity.</typeparam>
        /// <param name="sql">The SQL query</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>An enumerable of entities</returns>
        public Task<List<TEntity>> SqlQueryAsync<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return this.Database.SqlQuery<TEntity>(sql, parameters).ToListAsync();
        }

        /// <summary>
        /// The model creating method used to override database settings.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected new virtual void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// The should validate entity.
        /// </summary>
        /// <param name="entityEntry">
        /// The entity entry.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected new virtual bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            return base.ShouldValidateEntity(entityEntry);
        }

        /// <summary>
        /// The validate entity.
        /// </summary>
        /// <param name="entityEntry">
        /// The entity entry.
        /// </param>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="DbEntityValidationResult"/>.
        /// </returns>
        protected new virtual DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected new virtual void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary>
        /// Marks the entity as Modified in the context. (Useful after attaching it to a DbSet)
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entity">The entity.</param>
        public virtual void MarkAsModified<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}