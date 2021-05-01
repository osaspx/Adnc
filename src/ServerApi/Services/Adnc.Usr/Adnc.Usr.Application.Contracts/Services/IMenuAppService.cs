﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Adnc.Usr.Application.Contracts.Dtos;
using Adnc.Application.Shared.Interceptors;
using Adnc.Application.Shared.Services;
using Adnc.Infra.Caching.Interceptor;
using Adnc.Usr.Application.Contracts.Consts;

namespace Adnc.Usr.Application.Contracts.Services
{
    /// <summary>
    /// 菜单/权限服务
    /// </summary>
    public interface IMenuAppService : IAppService
    {
        Task<AppSrvResult<List<MenuNodeDto>>> GetlistAsync();

        Task<AppSrvResult<List<MenuRouterDto>>> GetMenusForRouterAsync(long[] roleIds);

        Task<AppSrvResult<MenuTreeDto>> GetMenuTreeListByRoleIdAsync(long roleId);

        [OpsLog(LogName = "新增菜单")]
        [CachingEvict(CacheKeys = new[] { EasyCachingConsts.MenuListCacheKey, EasyCachingConsts.MenuRelationCacheKey, EasyCachingConsts.MenuCodesCacheKey })]
        Task<AppSrvResult<long>> CreateAsync(MenuCreationDto input);

        [OpsLog(LogName = "修改菜单")]
        [CachingEvict(CacheKeys = new[] { EasyCachingConsts.MenuListCacheKey, EasyCachingConsts.MenuRelationCacheKey, EasyCachingConsts.MenuCodesCacheKey })]
        Task<AppSrvResult> UpdateAsync(long id,MenuUpdationDto input);

        [OpsLog(LogName = "删除菜单")]
        [CachingEvict(CacheKeys = new[] { EasyCachingConsts.MenuListCacheKey, EasyCachingConsts.MenuRelationCacheKey, EasyCachingConsts.MenuCodesCacheKey })]
        Task<AppSrvResult> DeleteAsync(long id);
    }
}