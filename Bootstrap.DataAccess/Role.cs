﻿namespace Bootstrap.DataAccess
{
    public class Role
    {
        /// <summary>
        /// 获得/设置 角色主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 获得/设置 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 获得/设置 角色描述
        /// </summary>
        public string Description { get; set; }
    }
}
