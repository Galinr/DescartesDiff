using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiffLibrary.DataBase
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DiffLibrary.DataBase.DiffDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<DiffDbContext>>()))
            {

                context.SaveChanges();
            }
            
        }


        
    }
}
