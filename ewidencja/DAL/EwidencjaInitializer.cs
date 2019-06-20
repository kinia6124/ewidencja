using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ewidencja.Models;

namespace ewidencja.DAL
{
    public class EwidencjaInitializer:
        System.Data.Entity.DropCreateDatabaseIfModelChanges<EwidencjaContext>
    {
        protected override void Seed(EwidencjaContext context)
        {
            base.Seed(context);
        }

    }
}