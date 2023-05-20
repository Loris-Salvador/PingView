using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class WrapperBase : ViewModelBase
    {
        public object Content { get; set; }


        protected WrapperBase(object content)
        {
            Content = content;
        }
    }
}
