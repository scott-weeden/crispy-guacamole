using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerEFCoreSample.Data
{
    /// <summary>
    /// Context for the Contracts database.
    /// </summary>
    public class ContractContext : DbContext
    {
        /// <summary>
        /// Magic string.
        /// </summary>
        public static readonly string RowVersion = nameof(RowVersion);

        /// <summary>
        /// Magic strings.
        /// </summary>
        public static readonly string ContractsDb = nameof(ContractsDb).ToLower();

        /// <summary>
        /// Inject options.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions{ContractContext}"/>
        /// for the context
        /// </param>
        public ContractContext(DbContextOptions<ContractContext> options)
            : base(options)
        {
            Debug.WriteLine($"{ContextId} context created.");
        }

        /// <summary>
        /// List of <see cref="Contract"/>.
        /// </summary>
        public DbSet<Contract>? Contracts { get; set; }

        /// <summary>
        /// Define the model.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this property isn't on the C# class
            // so we set it up as a "shadow" property and use it for concurrency
            modelBuilder.Entity<Contract>()
                .Property<byte[]>(RowVersion)
                .IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        public override void Dispose()
        {
            Debug.WriteLine($"{ContextId} context disposed.");
            base.Dispose();
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/></returns>
        public override ValueTask DisposeAsync()
        {
            Debug.WriteLine($"{ContextId} context disposed async.");
            return base.DisposeAsync();
        }
    }
}
