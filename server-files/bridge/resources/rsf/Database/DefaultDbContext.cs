#define MertLocal

using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using rsf.Models;

namespace rsf.Database
{
    public class DefaultDbContext : DbContext
    {
        private static string _connectionString;

        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }

        public DefaultDbContext()
        {
        }


        // Account model class created somewhere else
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<CharacterDatenModel> CharacterDaten { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            // Config config = new Config { Address = "127.0.0.1", Username = "root", Password = null, Database = "gtalife", Port = 3306 };

            var path = Environment.CurrentDirectory + Path.DirectorySeparatorChar +
                       "bridge" + Path.DirectorySeparatorChar + "resources" +
                       Path.DirectorySeparatorChar + "rsf"; //+ Path.DirectorySeparatorChar + "config.json"


            var builder = new ConfigurationBuilder();
            builder.AddJsonFile($"{path}/config.json", false);

            var configuration = builder.Build();
#if MertLocal
            _connectionString = configuration.GetConnectionString("MertLocalConnection");
#else
            _connectionString = configuration.GetConnectionString("DefaultConnection");
#endif
            optionsBuilder.UseMySql(_connectionString);
        }
    }


    public class ContextFactory : IDesignTimeDbContextFactory<DefaultDbContext>
    {
        private static DefaultDbContext _instance;
        private static string _connectionString;

        public static DefaultDbContext Instance
        {
            get
            {
                if (_instance != null) return _instance;

                return _instance = new ContextFactory().CreateDbContext(new string[] { });
            }
            private set { }
        }

        public DefaultDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DefaultDbContext>();

            // Load the connection string for the first time
            if (string.IsNullOrEmpty(_connectionString)) LoadConnectionString();

            // Use it to init the connection
            builder.UseMySql(_connectionString,
                optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(typeof(DefaultDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new DefaultDbContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", false);

            var configuration = builder.Build();
            // Get the connection string located inside the appsettings.json file under the name "DefaultConnection"
#if MertLocal
            _connectionString = configuration.GetConnectionString("MertLocalConnection");
#else
            _connectionString = configuration.GetConnectionString("DefaultConnection");
#endif
        }
    }
}