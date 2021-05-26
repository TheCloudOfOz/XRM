using System;
using Microsoft.Xrm.Sdk;

namespace XRM
{
    public static class AttributeExtensions
    {
        /// <summary>
        /// Get Attribute Value with default value option
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="attributeLogicalName">Attribute Logical Name</param>
        /// <param name="defaultValue">Default Value</param>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <returns>Returns Default Value if Attribute Value is null</returns>
        public static T GetAttributeValue<T>(this Entity entity, string attributeLogicalName, T defaultValue)
        {
            return entity.Contains(attributeLogicalName) && entity.GetAttributeValue<T>(attributeLogicalName) != null ? entity.GetAttributeValue<T>(attributeLogicalName) : defaultValue;
        }
        /// <summary>
        /// Get Attribute Value with default value option
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="image">Pre or Post Image</param>
        /// <param name="attributeLogicalName">Attribute Logical Name</param>
        /// <param name="defaultValue">Default Value</param>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <returns>Returns Default Value if Attribute Value or Image value is null</returns>
        public static T GetAttributeValue<T>(this Entity entity, Entity image, string attributeLogicalName, T defaultValue)
        {
            return entity.Contains(attributeLogicalName) && entity.GetAttributeValue<T>(attributeLogicalName) != null ? entity.GetAttributeValue<T>(attributeLogicalName) : image.GetAttributeValue<T>(attributeLogicalName, defaultValue);
        }
    }
}