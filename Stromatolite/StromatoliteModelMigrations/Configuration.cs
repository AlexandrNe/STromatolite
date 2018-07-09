namespace Stromatolite.StromatoliteModelMigrations

{

    using System;

    using System.Data.Entity;

    using System.Data.Entity.Migrations;

    using System.Linq;



    internal sealed class StromatoliteModelConfig : DbMigrationsConfiguration<Stromatolite.Models.StromatoliteModel>

    {

        public StromatoliteModelConfig()

        {

            AutomaticMigrationsEnabled = false;

            MigrationsDirectory = @"StromatoliteModelMigrations";

            ContextKey = "StromatoliteModel";

        }



        protected override void Seed(Stromatolite.Models.StromatoliteModel context)

        {

            //  This method will be called after migrating to the latest version.



            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 

            //  to avoid creating duplicate seed data. E.g.

            //

            //    context.People.AddOrUpdate(

            //      p => p.FullName,

            //      new Person { FullName = "Andrew Peters" },

            //      new Person { FullName = "Brice Lambson" },

            //      new Person { FullName = "Rowan Miller" }

            //    );

            //

        }

    }

}