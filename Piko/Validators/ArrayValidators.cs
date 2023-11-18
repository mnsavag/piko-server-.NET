using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace Piko.Validators
{
    public class CollectionLengthAttribute : ValidationAttribute
    {
        readonly int minLength;
        readonly int maxLength;

        public CollectionLengthAttribute(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value is ICollection == false) 
            { 
                return false; 
            }
            var length = ((ICollection)value).Count;
            return minLength <= length && length <= maxLength;
        }
    }

    public class CollectionAvailLengthsAttribute : ValidationAttribute
    {
        readonly int[] availableLength;

        public CollectionAvailLengthsAttribute(int[] arrayLengths)
        {
            this.availableLength = new int[arrayLengths.Length];
            Array.Copy(arrayLengths, this.availableLength, arrayLengths.Length);
        }

        public override bool IsValid(object value)
        {
            if (value is ICollection == false)
            {
                return false;
            }
            var length = ((ICollection)value).Count;
            return this.availableLength.Contains(length);
        }
    }
}
