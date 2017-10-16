using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.Attributes
{
    /// <summary>指定属性或事件的描述。</summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        ///   指定的默认值为 <see cref="T:System.ComponentModel.DescriptionAttribute" />, ，这是一个空字符串 ("")。
        ///    这 <see langword="static" /> 字段是只读的。
        /// </summary>
        public static readonly DescriptionAttribute Default = new DescriptionAttribute();
        private string description;

        /// <summary>
        ///   新实例初始化 <see cref="T:System.ComponentModel.DescriptionAttribute" /> 不带参数的类。
        /// </summary>
        public DescriptionAttribute()
          : this(string.Empty)
        {
        }

        /// <summary>
        ///   新实例初始化 <see cref="T:System.ComponentModel.DescriptionAttribute" /> 类的说明。
        /// </summary>
        /// <param name="description">说明文本中。</param>
        public DescriptionAttribute(string description)
        {
            this.description = description;
        }

        /// <summary>获取存储在此属性的说明。</summary>
        /// <returns>此属性中存储的说明。</returns>
        public virtual string Description
        {
            get
            {
                return this.DescriptionValue;
            }
        }

        /// <summary>获取或设置作为说明存储的字符串。</summary>
        /// <returns>
        ///   描述作为存储的字符串。
        ///    默认值为空字符串 ("")。
        /// </returns>
        protected string DescriptionValue
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        /// <summary>
        ///   返回给定对象的值是否等于当前 <see cref="T:System.ComponentModel.DescriptionAttribute" />。
        /// </summary>
        /// <param name="obj">要测试值的相等性的对象。</param>
        /// <returns>
        ///   <see langword="true" /> 如果给定对象的值是否等于当前;否则为 <see langword="false" />。
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            DescriptionAttribute descriptionAttribute = obj as DescriptionAttribute;
            if (descriptionAttribute != null)
                return descriptionAttribute.Description == this.Description;
            return false;
        }

        /// <summary>返回此实例的哈希代码。</summary>
        /// <returns>32 位有符号整数哈希代码。</returns>
        public override int GetHashCode()
        {
            return this.Description.GetHashCode();
        }
        
    }

}
