﻿using TccUmc.Domain.Enums;
using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IDashboardRepository
{
    Task<Dashboard> GetDashboard(int UserId);
}