﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Data.Dapper
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="T">主键类型</typeparam>
    public class Entity<T> : IEntity
    {
        /// <summary>
        /// 泛型主键
        /// </summary>
        public T Id { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
