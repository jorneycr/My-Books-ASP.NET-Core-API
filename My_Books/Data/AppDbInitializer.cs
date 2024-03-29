﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using My_Books.Data.Models;
using System;
using System.Linq;

namespace My_Books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope() )
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title= "1st Book Title",
                        Description= "Ist Book Description",
                        IsRead= true,
                        DateRead= DateTime.Now.AddDays(-10),
                        Rate= 4,
                        Genre= "Bio",
                        CoverUrl= "https://....",
                        DateAdded= DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2st Book Title",
                        Description = "2st Book Description",
                        IsRead = false,
                        Genre = "Math",
                        CoverUrl = "https://....",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
