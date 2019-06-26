using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ewidencja.Models;
/// <summary>
/// Inicjalizer bazy danych
/// </summary>
namespace ewidencja.DAL
{/// <summary>
/// klasa inicjalizująca bazę danych na podstawie jej kontekstu w EwidencjaContext
/// </summary>
    public class EwidencjaInitializer:
        System.Data.Entity.DropCreateDatabaseIfModelChanges<EwidencjaContext>
    {
        protected override void Seed(EwidencjaContext context)
        {
            base.Seed(context);
        }

    }
}