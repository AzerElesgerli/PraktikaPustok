﻿using Microsoft.EntityFrameworkCore;
using PustokAB202.DAL;

namespace PustokAB202.Services
{
    public class LayoutServices
    {
        private readonly AppDbContext _context;

        public LayoutServices(AppDbContext context)
        {
            _context = context;
        }

      public async Task<Dictionary<string, string>> GetSettings()
        {
            var settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
            return settings;
        }
        }
    }

