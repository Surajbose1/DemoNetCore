﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DempApp.Data
{
    public class ApplicationDbConnection : IdentityDbContext
    {
        public ApplicationDbConnection(DbContextOptions<ApplicationDbConnection> options) : base(options)
        {

        }
    }
}