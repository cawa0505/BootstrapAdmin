﻿using Longbow.Cache;
using Longbow.Data;
using System.Collections.Generic;
using System.Linq;

namespace Bootstrap.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public static class RoleHelper
    {
        public const string RetrieveRolesDataKey = "RoleHelper-RetrieveRoles";
        public const string RetrieveRolesByUserIdDataKey = "RoleHelper-RetrieveRolesByUserId";
        public const string RetrieveRolesByMenuIdDataKey = "RoleHelper-RetrieveRolesByMenuId";
        public const string RetrieveRolesByGroupIdDataKey = "RoleHelper-RetrieveRolesByGroupId";
        public const string RetrieveRolesByUserNameDataKey = "RoleHelper-RetrieveRolesByUserName";
        public const string RetrieveRolesByUrlDataKey = "RoleHelper-RetrieveRolesByUrl";
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Role> RetrieveRoles(int id = 0)
        {
            var ret = CacheManager.GetOrAdd(RetrieveRolesDataKey, key => DbAdapterManager.Create<Role>().RetrieveRoles(id));
            return id == 0 ? ret : ret.Where(t => id == t.Id);
        }
        /// <summary>
        /// 保存用户角色关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public static bool SaveRolesByUserId(int userId, IEnumerable<int> roleIds) => DbAdapterManager.Create<Role>().SaveRolesByUserId(userId, roleIds);
        /// <summary>
        /// 查询某个用户所拥有的角色
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Role> RetrieveRolesByUserId(int userId) => CacheManager.GetOrAdd($"{RetrieveRolesByUserIdDataKey}-{userId}", key => DbAdapterManager.Create<Role>().RetrieveRolesByUserId(userId), RetrieveRolesByUserIdDataKey);
        /// <summary>
        /// 删除角色表
        /// </summary>
        /// <param name="value"></param>
        public static bool DeleteRole(IEnumerable<int> value) => DbAdapterManager.Create<Role>().DeleteRole(value);
        /// <summary>
        /// 保存新建/更新的角色信息
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool SaveRole(Role p) => DbAdapterManager.Create<Role>().SaveRole(p);
        /// <summary>
        /// 查询某个菜单所拥有的角色
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static IEnumerable<Role> RetrieveRolesByMenuId(int menuId) => CacheManager.GetOrAdd(string.Format("{0}-{1}", RetrieveRolesByMenuIdDataKey, menuId), key => DbAdapterManager.Create<Role>().RetrieveRolesByMenuId(menuId), RetrieveRolesByMenuIdDataKey);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public static bool SavaRolesByMenuId(int id, IEnumerable<int> roleIds) => DbAdapterManager.Create<Role>().SavaRolesByMenuId(id, roleIds);
        /// <summary>
        /// 根据GroupId查询和该Group有关的所有Roles
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static IEnumerable<Role> RetrieveRolesByGroupId(int groupId) => CacheManager.GetOrAdd(string.Format("{0}-{1}", RetrieveRolesByGroupIdDataKey, groupId), key => DbAdapterManager.Create<Role>().RetrieveRolesByGroupId(groupId), RetrieveRolesByGroupIdDataKey);
        /// <summary>
        /// 根据GroupId更新Roles信息，删除旧的Roles信息，插入新的Roles信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public static bool SaveRolesByGroupId(int id, IEnumerable<int> roleIds) => DbAdapterManager.Create<Role>().SaveRolesByGroupId(id, roleIds);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static IEnumerable<string> RetrieveRolesByUserName(string userName) => CacheManager.GetOrAdd(string.Format("{0}-{1}", RetrieveRolesByUserNameDataKey, userName), key => DbAdapterManager.Create<Role>().RetrieveRolesByUserName(userName), RetrieveRolesByUserNameDataKey);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IEnumerable<string> RetrieveRolesByUrl(string url) => CacheManager.GetOrAdd(string.Format("{0}-{1}", RetrieveRolesByUrlDataKey, url), key => DbAdapterManager.Create<Role>().RetrieveRolesByUrl(url), RetrieveRolesByUrlDataKey);
    }
}