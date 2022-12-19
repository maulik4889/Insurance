using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Insurance.Application.Common.Interfaces;
using Insurance.Domain.Common;
using Insurance.Domain.Entities;

namespace Insurance.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        private IDbContextTransaction currentTransaction;

        public ApplicationDbContext(
            DbContextOptions options,
            
            ILogger<ApplicationDbContext> logger) : base(options)
        {
            
            _logger = logger;
        }

        // Core Tables
        public DbSet<Claims> Claims { get; protected set; }
        public DbSet<Company> Company { get; protected set; }
        public DbSet<ClaimType> ClaimType { get; protected set; }


        /// <summary>
        /// Finds all changed entities (table rows) and updates created and modified timestamps
        /// </summary>
        private void UpdateEntityDates()
        {
            var changedEntries = ChangeTracker.Entries().Where(e => e.Entity is AuditableEntity);

            foreach (var entry in changedEntries)
            {
                try
                {
                   
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    _logger.LogError("Audit operations cannot be applied to table\nException: {invalidOperationException}", invalidOperationException);
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                UpdateEntityDates();
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException is SqlException exception)
                {
                    var sqlExceptionNumber = exception.Number;
                    switch (sqlExceptionNumber)
                    {
                        default:
                        {
                            throw dbUpdateException.InnerException;
                        }
                    }
                }

                throw;
            }
        }

        public override int SaveChanges()
        {
            UpdateEntityDates();
            return base.SaveChanges();
        }

        public async Task BeginTransactionAsync()
        {
            if (currentTransaction != null)
            {
                return;
            }

            currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                currentTransaction?.Rollback();
            }
            finally
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            _logger.LogInformation("Model Creation Started");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
