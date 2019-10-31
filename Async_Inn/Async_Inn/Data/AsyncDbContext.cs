using Microsoft.EntityFrameworkCore;
using System;

/// <summary>
/// Summary description for AsyncDbContext
/// </summary>
public class AsyncDbContext : DbContext
{
	public AsyncDbContext(DbContextOptions<AsyncDbContext>options): base(options)
	{
        
	}
}
