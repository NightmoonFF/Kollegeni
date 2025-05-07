using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kollegeni.Data
{
    public class DbInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            // Guid projectId, string projectName, int quantityToProduce,DateTime createdAt, DateTime deadline, TimeSpan timeSpent, Status status
            //context.Biler.Add(new Models.Bil(1, "Honda", DateTime.Now));
            //context.RawMaterials.Add(new Models.RawMaterial("Grillspyd", new Models.MeasurementType("kg"), 20));
            //context.RawMaterials.Add(new Models.RawMaterial("Jernstang", new Models.MeasurementType("kg"), 20));
            //context.RawMaterials.Add(new Models.RawMaterial("Jernstang3", new Models.MeasurementType("kg"), 20));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
