using System;
using System.Collections.Generic;
using System.Text;

namespace Meres1
{
    public class TFTDisplay : DisplayBase
    {
        public TFTDisplay( int _creationYear, int _size, int _responseTime, int _originalPrice )
        {
            this.manufacturingYear = _creationYear;
            this.size = _size;
            this.price = _originalPrice;
            this.responseTime = _responseTime;

        }

        int responseTime;
    }
}
