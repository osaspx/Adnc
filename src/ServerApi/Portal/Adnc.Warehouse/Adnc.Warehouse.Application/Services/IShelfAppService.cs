﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Adnc.Application.Shared.Interceptors;
using Adnc.Application.Shared.Services;
using Adnc.Warehouse.Application.Dtos;

namespace Adnc.Warehouse.Application.Services
{
    public interface IShelfAppService: IAppService
    {
        [OpsLog(LogName = "创建货架")]
        Task<ShelfDto> CreateAsync(ShelfCreationDto input);

        [OpsLog(LogName = "分配货架")]
        Task<ShelfDto> AllocateShelfToProductAsync(long shelfId, ShelfAllocateToProductDto input);
    }
}