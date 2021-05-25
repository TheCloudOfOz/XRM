using System;
using Microsoft.Xrm.Sdk;

namespace XRM
{
    public static class AttributeExtensions
    {
        public static T GetAttributeValue<T>(this Entity entity, string attributeLogicalName, T defaultValue)
        {
            return entity.Contains(attributeLogicalName) && entity.GetAttributeValue<T>(attributeLogicalName) != null ? entity.GetAttributeValue<T>(attributeLogicalName) : defaultValue;
        }

        public static T GetAttributeValue<T>(this Entity entity, Entity image, string attributeLogicalName, T defaultValue)
        {
            return entity.Contains(attributeLogicalName) && entity.GetAttributeValue<T>(attributeLogicalName) != null ? entity.GetAttributeValue<T>(attributeLogicalName) : image.Contains(attributeLogicalName) && image.GetAttributeValue<T>(attributeLogicalName) != null ? image.GetAttributeValue<T>(attributeLogicalName) : defaultValue;
        }
    }
}