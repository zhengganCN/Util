﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AmazedDataValidation.VerifyAttribute
{
    /// <summary>
    /// 文件类型验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FileTypeAttribute : ValidationAttribute
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public string[] FileType;
        /// <summary>
        /// 是否验证通过
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value is IFormFile)
            {
                var file = value as IFormFile;
                return ValidFileType(file);
            }
            else if (value is IFormCollection)
            {
                var files = value as IFormFileCollection;
                foreach (var file in files)
                {
                    if (!ValidFileType(file))
                    {
                        return false;
                    }
                }
                return true;
            }
            return true;
        }
        /// <summary>
        /// 验证文件类型
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool ValidFileType(IFormFile file)
        {
            var splits = file.FileName.Split('.');
            if (splits.Length >= 2)
            {
                string fileType = splits[splits.Length - 1].ToUpper();
                if (FileType.Any(entity => entity.ToUpper() == fileType))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}