using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryGroceries.Specs.Util
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class KnownLocationAttribute: Attribute
    {
        private string _relativeUrl;

        /// <summary>
        /// Initializes a new instance of <see cref="KnownLocationAttribute "/>
        /// </summary>
        /// <param name="relativeUrl"></param>
        public KnownLocationAttribute(string relativeUrl)
        {
            _relativeUrl = relativeUrl;
        }

        /// <summary>
        /// Gets the relative URL in the application for the known location
        /// </summary>
        public string RelativeUrl
        {
            get { return _relativeUrl; }
        }

        /// <summary>
        /// Parses the relative URL of a known location
        /// </summary>
        /// <param name="enumerationValue"></param>
        /// <returns></returns>
        public static string Parse(object enumerationValue)
        {
            var enumerationType = enumerationValue.GetType();
            var enumerationName = enumerationType.GetEnumName(enumerationValue);

            var enumerationField = enumerationType.GetField(enumerationName);

            var knownLocationAttribute = ((KnownLocationAttribute[])enumerationField.GetCustomAttributes(
                typeof (KnownLocationAttribute), true)).FirstOrDefault();

            if (knownLocationAttribute != null)
            {
                return knownLocationAttribute.RelativeUrl;
            }

            return null;
        }
    }
}
