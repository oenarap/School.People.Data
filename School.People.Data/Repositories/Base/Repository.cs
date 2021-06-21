using System;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data
{
    /// <summary>
    /// Base repository implementation.
    /// </summary>
    /// <typeparam name="T">Type of data in the repository.</typeparam>
    /// <typeparam name="TContext">A <see cref="DbContext"/>-derived type used by this repository.</typeparam>
    public abstract class Repository<TData, TContext> where TContext : DbContext
    {
        /// <inheritdoc/>
        protected Repository(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected readonly TContext Context;
    }
}
